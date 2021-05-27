namespace crud_pessoa.api.Configs.Notifications
{
    public class Notificacao
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string Metodo { get; set; }

        public Notificacao(string key, string message, string metodo = "")
        {
            Key = key;
            Message = message;
            Metodo = metodo;
        }

    }
}
