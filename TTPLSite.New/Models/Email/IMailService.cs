namespace TTPLSite.New.Models.Email
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendInquiryEmailWithTemplateAsync(InquiryRequest request);
    }
}
