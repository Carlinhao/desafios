using crud_pessoa.api.Configs.Notifications;
using crud_pessoa.api.Repositories;
using crud_pessoa.api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace crud_pessoa.api.DbContextConfig.DependencyInjection
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            // Repositories
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            // Services
            services.AddTransient<IPessoaService, PessoaService>();

            //Notification
            services.AddSingleton<INotificacaoContext, NotificacaoContext>();
        }
    }
}
