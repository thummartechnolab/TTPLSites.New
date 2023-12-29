using Microsoft.AspNetCore.Mvc;

namespace TTPLSite.New.Models.Email
{
    public class InquiryRequest
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string Captcha { get; set; }
    }
}
