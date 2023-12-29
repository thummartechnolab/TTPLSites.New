using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace TTPLSite.New.Models
{
    public class ReCaptcha
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
        public string Version { get; set; }
    }

    public interface IReCaptchaSetting
    {
        Task<bool> IsValid(string captcha);
    }

    public class reCaptchaData
    {
        public string response { get; set; }
        public string secret { get; set; }
    }
    public class reCaptchaRespo
    {
        public bool success { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
        public long score { get; set; }
    }

    public class ReCaptchaSetting : IReCaptchaSetting
    {
        private readonly HttpClient captchaClient;
        private readonly ReCaptcha _reCaptcha;
        public ReCaptchaSetting(HttpClient captchaClient, IOptions<ReCaptcha> reCaptcha)
        {
            this.captchaClient = captchaClient;
            _reCaptcha = reCaptcha.Value;
        }
        public virtual async Task<bool> IsValid(string captcha)
        {
            try
            {
                var reCaptchaData = new reCaptchaData
                {
                    response = captcha,
                    secret = _reCaptcha.SecretKey
                };
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={reCaptchaData.secret}&response={reCaptchaData.response}");
                var reCaptcharesponse = JsonConvert.DeserializeObject<reCaptchaRespo>(response);
                return reCaptcharesponse.success;
            }
            catch (Exception e)
            {
                // TODO: log this (in elmah.io maybe?)
                return false;
            }
        }
    }
}
