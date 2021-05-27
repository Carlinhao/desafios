using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace crud_pessoa.api.Configs.Notifications
{
    public class NotificacaoContext : INotificacaoContext
    {
        private readonly List<Notificacao> _notificacoes;

        public NotificacaoContext()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AddNotification(string key, string message, string metodo = "")
        {
            _notificacoes.Add(new Notificacao(key, message, metodo));
        }

        public void AddNotification(string key, string message)
        {
            _notificacoes.Add(new Notificacao(key, message));
        }

        public void AddNotification(Notificacao notification)
        {
            _notificacoes.Add(notification);
        }

        public void AddNotifications(IList<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
        public bool HasNotification()
        {
            return _notificacoes.Any();
        }

        public List<Notificacao> RetornarNoticacoes()
        {
            return _notificacoes;
        }
    }
}
