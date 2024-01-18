using FastApplication.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authorization;

public class EnvironmentRequirementHandler : AuthorizationHandler<EnvironmentRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EnvironmentRequirement requirement)
    {
        var currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
     
        if (currentEnvironment?.ToLower() == "development")
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        
        context.Fail();
        return Task.CompletedTask;
    }
}
