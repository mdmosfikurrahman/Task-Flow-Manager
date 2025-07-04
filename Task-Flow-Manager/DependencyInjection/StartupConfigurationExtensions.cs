﻿using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Task_Flow_Manager.Data;

namespace Task_Flow_Manager.DependencyInjection;

public static class StartupConfigurationExtensions
{
    public static void ConfigureProjectSettings(this WebApplicationBuilder builder)
    {
        builder.ConfigureDatabase();
        builder.ConfigureApiVersioning();
        builder.ConfigureMvcAndSwagger();
        builder.ConfigureGraphQl();
        builder.Services.RegisterApplicationServices();
    }

    private static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("TaskFlowManagerDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'TaskFlowManagerDb' is not configured.");
        }

        builder.Services.AddDbContext<TaskFlowManagerDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    private static void ConfigureApiVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        });
    }

    private static void ConfigureMvcAndSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
            });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpContextAccessor();
    }

    private static void ConfigureGraphQl(this WebApplicationBuilder builder)
    {
        var assembly = typeof(StartupConfigurationExtensions).Assembly;

        var queryResolvers = assembly.GetTypes().Where(type =>
            type is { IsClass: true, IsAbstract: false, Namespace: not null } &&
            type.Namespace.StartsWith("Task_Flow_Manager.Resolvers") &&
            type.GetCustomAttributes(typeof(ExtendObjectTypeAttribute), true)
                .Any(attr => ((ExtendObjectTypeAttribute)attr).Name == "Query")
        );

        var mutationResolvers = assembly.GetTypes().Where(type =>
            type is { IsClass: true, IsAbstract: false, Namespace: not null } &&
            type.Namespace.StartsWith("Task_Flow_Manager.Resolvers") &&
            type.GetCustomAttributes(typeof(ExtendObjectTypeAttribute), true)
                .Any(attr => ((ExtendObjectTypeAttribute)attr).Name == "Mutation")
        );

        var schemaBuilder = builder.Services.AddGraphQLServer()
            .AddQueryType(objectTypeDescriptor => objectTypeDescriptor.Name("Query"))
            .AddMutationType(objectTypeDescriptor => objectTypeDescriptor.Name("Mutation"));

        foreach (var resolver in queryResolvers)
        {
            schemaBuilder.AddTypeExtension(resolver);
        }

        foreach (var resolver in mutationResolvers)
        {
            schemaBuilder.AddTypeExtension(resolver);
        }
    }
}