using FluentValidation.Results;
using System.Collections.Generic;

namespace crud_pessoa.api.Configs.Notifications
{
    public interface INotificacaoContext
    {
        void AddNotification(string key, string message, string metodo = "");
        void AddNotification(string key, string message);
        void AddNotification(Notificacao notification);
        void AddNotifications(IList<Notificacao> notifications);
        void AddNotifications(ValidationResult validationResult);
        List<Notificacao> RetornarNoticacoes();
        bool HasNotification();
    }
}
