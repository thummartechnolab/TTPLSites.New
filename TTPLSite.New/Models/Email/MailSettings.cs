
namespace TTPLSite.New.Models.Email
{
    public class MailSettings
    {
        public string From { get; set; }
        public string[] To { get; set; }
        public string[] Cc { get; set; }
        public string[] Bcc { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
