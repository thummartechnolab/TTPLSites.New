using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using TTPLSite.New.Models;
using TTPLSite.New.Models.Email;
using MimeKit;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TTPLSite.New.Pages
{
    public class contact_usModel : PageModel
    {
        private readonly IMailService _mailService;
        private readonly IExceptionLogging _exceptionLogging;
        private readonly IReCaptchaSetting _reCaptchaSetting;
        private readonly MailSettings _mailSettings;

        [BindProperty]
        public InquiryRequest Inquiry { get; set; }

        public contact_usModel(IMailService mailService, IExceptionLogging exceptionLogging,
            IReCaptchaSetting reCaptchaSetting, IOptions<MailSettings> mailSettings)
        {
            _mailService = mailService;
            _exceptionLogging = exceptionLogging;
            _reCaptchaSetting = reCaptchaSetting;
            _mailSettings = mailSettings.Value;
        }
        public void OnGet()
        {
        }


        //[ValidateReCaptcha]
        [ValidateAntiForgeryToken]
        public async Task OnPost(InquiryRequest inquiry)
        {
            try
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                if (await _reCaptchaSetting.IsValid(inquiry.Captcha) && ModelState.IsValid)
                {
                    //string body = "We have new inqury received: \n" +
                    //               "User Name: " + inquiry.UserName + "\n" +
                    //               "Email: " + inquiry.Email + "\n" +
                    //               "Phone: " + inquiry.Phone + "\n" +
                    //               "Message: " + inquiry.Message + "\n";

                    //await SendMail2StepAsync(_mailSettings, "New Inquiry", body);

                    var inquiryRequest = new InquiryRequest
                    {
                        UserName = inquiry.UserName,
                        Email = inquiry.Email,
                        Phone = inquiry.Phone,
                        Message = inquiry.Message,
                        Captcha = inquiry.Captcha,
                    };

                   await _mailService.SendInquiryEmailWithTemplateAsync(inquiryRequest);
                }
            }
            catch (Exception ex)
            {
                _exceptionLogging.WriteError(ex);
                throw;
            }

        }
        private async Task SendMail2StepAsync(MailSettings _mailSettings, string Subject, string Body)
        {
            //var smtpClient = new MailKit.Net.Smtp.SmtpClient(_mailSettings.Host, _mailSettings.Port)
            //{
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    EnableSsl = true
            //};
            //smtpClient.Credentials = new NetworkCredential(_mailSettings.From, _mailSettings.Password); //Use the new password, generated from google!

            var mailFrom = InternetAddress.Parse(_mailSettings.From);

            InternetAddressList toList = new InternetAddressList();
            foreach (var mail in _mailSettings.To)
            {
                toList.Add(new MailboxAddress(mail, mail));
            }

            InternetAddressList CcList = new InternetAddressList();
            foreach (var mail in _mailSettings.Cc)
            {
                CcList.Add(new MailboxAddress(mail, mail));
            }

            InternetAddressList BccList = new InternetAddressList();
            foreach (var mail in _mailSettings.Bcc)
            {
                BccList.Add(new MailboxAddress(mail, mail));
            }

            var message = new MimeMessage();
            message.Subject = Subject;
            message.From.Add(mailFrom);
            message.To.AddRange(toList);
            message.Cc.AddRange(CcList);
            message.Cc.AddRange(BccList);

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, false);

                // Note: only needed if the SMTP server requires authentication
                await smtp.AuthenticateAsync(_mailSettings.From, _mailSettings.Password);

                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
