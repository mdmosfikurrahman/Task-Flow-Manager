﻿using Task_Flow_Manager.Dto.Request;
using Task_Flow_Manager.Utils;

namespace Task_Flow_Manager.Validators;

public static class ProjectsRequestValidator
{
    public static void Validate(ProjectsRequest request)
    {
        ValidatorUtils.NotEmpty(request.Name, nameof(request.Name));
        ValidatorUtils.MaxLength(request.Name, 100, nameof(request.Name));

        ValidatorUtils.NotEmpty(request.Description, nameof(request.Description));
        ValidatorUtils.MaxLength(request.Description, 500, nameof(request.Description));
        
        ValidatorUtils.NotNullDate(request.StartDate, nameof(request.StartDate));
        ValidatorUtils.NotNullDate(request.EndDate, nameof(request.EndDate));

        ValidatorUtils.EndDateNotBeforeStartDate(
            request.StartDate,
            request.EndDate,
            nameof(request.StartDate),
            nameof(request.EndDate)
        );
        
        ValidatorUtils.MustBePositive(request.ManagerId, nameof(request.ManagerId));
    }
}