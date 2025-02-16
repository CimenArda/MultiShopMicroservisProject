using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop İndirim!", "arda.1235850@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.To);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = $@"
               <div style=""font-family: 'Segoe UI', sans-serif; line-height: 1.8; color: #333;"">
    <h1 style=""color: #FF5722; font-size: 28px; text-transform: uppercase; margin-bottom: 10px;"">
        Tebrikler, <span style=""color: #FF9800;"">{mailRequest.Name}!</span>
    </h1>
    <p style=""font-size: 16px;"">🎉 MultiShop'tan özel bir <strong style=""color: #4CAF50;"">%25 indirim kodu</strong> kazandınız!</p>
    <p style=""font-size: 15px; margin-top: 10px;"">
        Giyimden elektroniğe, ev eşyalarından kozmetiğe kadar yüzlerce üründe bu kodu kullanarak indirimden faydalanabilirsiniz:
    </p>
    <div style=""padding: 15px; background: #FFF3E0; border-radius: 8px; border: 1px solid #FFCCBC; display: inline-block; margin: 15px 0;"">
        <strong style=""font-size: 22px; color: #FF5722;"">MULTISHOP25</strong>
    </div>
    <p style=""font-size: 15px; margin-top: 20px;"">
        Hemen alışverişe başlayın ve fırsatları kaçırmayın! <br>
        <strong style=""color: #FF9800;"">MultiShop</strong> 🛍️
    </p>
</div>
";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Tebrikler! %25 İndirim Kodunuzu Kazandınız";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("arda.1235850@gmail.com", "ivjbgyfcwrfqcryc");
            client.Send(mimeMessage);
            client.Disconnect(true);
            TempData["Message"] = "Mail başarıyla gönderildi!";
            return View();
        }
    }
}
