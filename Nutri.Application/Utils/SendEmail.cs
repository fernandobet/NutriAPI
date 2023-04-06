using Nutri.Application.DTO.Patients;
using System.Net;
using System.Net.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Nutri.Application.Utils
{
    public static class SendEmail
    {
        private const string PATH = @"C:\Temp\PLAN.pdf";

        public static void Send(EmailModel mailMessage, string nombrePaciente, string destino)
        {

            var pdfBinary = Convert.FromBase64String(mailMessage.Attachment);
            if (!Directory.Exists(@"C:\Temp)"))
                Directory.CreateDirectory(@"C:\Temp");
            using (FileStream file = System.IO.File.Create(PATH))
            {
                file.Write(pdfBinary, 0, pdfBinary.Length);
                file.Close();
                file.Dispose();
            }
            sendAction(PATH, nombrePaciente, destino);
            if (System.IO.File.Exists(PATH))
                System.IO.File.Delete(PATH);
        }
        private static void sendAction(string path, string nombrePaciente, string emailDestino)
        {
            string emailOrigin = "yeyoyectaclan@outlook.com";
            string contraseña = "Tumama.123$";

            MailMessage onMailMessage = new MailMessage(emailOrigin, emailDestino, "PLAN ALIMENTICIO", "Querido(a) " + nombrePaciente + " a continuacion le anexamos su plan alimenticio <br/> Saludos.<br/> <strong>YEYO ADAME</strong> <br/><strong>Este es un sistema automatizado, favor de no responder este mensaje</strong>");
            onMailMessage.Attachments.Add(new Attachment(path));
            onMailMessage.IsBodyHtml = true;
            SmtpClient onSmptClient = new SmtpClient("smtp.outlook.com");
            onSmptClient.EnableSsl = true;         
            onSmptClient.Port = 587;
            onSmptClient.Credentials = new NetworkCredential(emailOrigin, contraseña);
            onSmptClient.Send(onMailMessage);

            onSmptClient.Dispose();
            onMailMessage.Attachments.Dispose();
            //sendWhatsApp();
        }
        public static void sendWhatsApp()
        {
            var accountSid = "ACb40d0c059cd9f83a2ec19c55fc4ab5c0";
            var authToken = "ebc58b28d3562519c7099960426e0f71";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+5218711355665"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = "Hola desde el robot de tu amorsito.Saludos";
            messageOptions.MediaUrl = new List<Uri> { new Uri("https://i.pinimg.com/originals/3c/2d/1b/3c2d1b10bb5529519c29b88ee64f7ef5.png") };  
            var message = MessageResource.Create(messageOptions);
          Console.WriteLine(message.Body);
        }
    }
}
