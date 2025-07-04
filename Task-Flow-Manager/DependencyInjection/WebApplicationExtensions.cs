﻿using System.Diagnostics;
using Task_Flow_Manager.Middlewares;

namespace Task_Flow_Manager.DependencyInjection;

public static class WebApplicationExtensions
{
    public static void UseProjectConfiguration(this WebApplication app)
    {
        app.UseGlobalExceptionHandling();
        app.UseSwaggerIfDevelopment();
        app.UseRoutingAndAuthorization();
    }

    private static void UseGlobalExceptionHandling(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }

    private static void UseSwaggerIfDevelopment(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return;

        app.UseSwagger();
        app.UseSwaggerUI();

        const string swaggerUrl = "http://localhost:8080/swagger/index.html";
        _ = Task.Run(() => OpenBrowser(swaggerUrl));
    }

    private static void UseRoutingAndAuthorization(this WebApplication app)
    {
        app.UseAuthorization();
        app.MapControllers();
        app.MapGraphQL("/api/v1/graphql");
    }

    private static void OpenBrowser(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Browser Launch Error] {ex.Message}");
        }
    }
}