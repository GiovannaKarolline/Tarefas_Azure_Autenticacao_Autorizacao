using Microsoft.Identity.Web;
using System.Security.Claims;
using Tarefas.Application.Abstractions.Usuario;

namespace Tarefas.Api.Auth
{
    public sealed class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private ClaimsPrincipal Usuario => _httpContextAccessor.HttpContext?.User ?? throw new NullReferenceException("A requisição não foi realizada.");

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public string Id => Usuario.GetObjectId() ?? throw new UnauthorizedAccessException("Usuário não identificado.");

        public bool AcessoTotal => Usuario.IsInRole(Permissions.RoleAdmin) || Usuario.IsInRole(Permissions.AppRoleLerTodasAsTarefas);
    }
}