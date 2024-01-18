using Microsoft.AspNetCore.Authorization;

namespace FastApplication.Infrastructure.Configurations
{
    public class EnvironmentRequirement : IAuthorizationRequirement
    {
        public string[] AllowedEnvironments { get; }

        public EnvironmentRequirement(params string[] allowedEnvironments)
        {
            AllowedEnvironments = allowedEnvironments;
        }
    }
}
