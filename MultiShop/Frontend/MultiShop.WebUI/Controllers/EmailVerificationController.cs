using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MultiShop.WebUI.Controllers
{
    public class EmailVerificationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendCode()
        {
            var email = "mustafarslan492@gmail.com"; // Mail adresini burada sabit verdin

            // 6 haneli rastgele kod oluştur
            var random = new Random();
            string verificationCode = random.Next(100000, 999999).ToString();

            // Session'a kod ve geçerlilik süresi kaydet (2 dakika)
            HttpContext.Session.SetString("VerificationCode", verificationCode);
            HttpContext.Session.SetString("VerificationCodeExpire", DateTime.Now.AddMinutes(2).ToString());

            // Mail gönderimi
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("MultiShop", "mustafarslan0214@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("User", email));

            mimeMessage.Subject = "Doğrulama Kodu";
            var bodyBuilder = new BodyBuilder
            {
                TextBody = $"Doğrulama kodunuz: {verificationCode}. Kod 2 dakika geçerlidir."
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtpClient.Authenticate("mustafarslan0214@gmail.com", "kxdp alht rare owcp"); // şifreyi koru
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }

            return Ok("Kod gönderildi");
        }

        [HttpGet]
        public IActionResult VerifyCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyCode(string[] code)
        {
            string inputCode = string.Join("", code);
            var savedCode = HttpContext.Session.GetString("VerificationCode");
            var expireStr = HttpContext.Session.GetString("VerificationCodeExpire");

            if (string.IsNullOrEmpty(savedCode) || string.IsNullOrEmpty(expireStr))
            {
                ViewBag.Error = "Kod süresi dolmuş veya bulunamadı.";
                return View();
            }

            DateTime expireTime = DateTime.Parse(expireStr);
            if (DateTime.Now > expireTime)
            {
                ViewBag.Error = "Kodun süresi doldu. Lütfen yeniden isteyin.";
                return View();
            }

            if (inputCode == savedCode)
            {
                return RedirectToAction("Success");
            }

            ViewBag.Error = "Kod yanlış. Lütfen tekrar deneyin.";
            return View();
        }

        public IActionResult Success()
        {
            return Content("Doğrulama başarılı! 🎉");
        }
    }
}
