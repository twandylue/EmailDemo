using System.Net;
using System.Net.Mail;
using System.Text;
using EmailSender;

Console.WriteLine("Hello, World!");

var startup = new Startup();

var mail = new MailMessage();
mail.From = new MailAddress(startup.AppSettings.Account);
mail.To.Add(startup.AppSettings.Receiver);

// TODO: should be from config or outside files.
mail.Subject = "測試信3";
mail.SubjectEncoding = Encoding.UTF8;
mail.IsBodyHtml = true;
mail.Body = "第一行<br> 第二行<br>第三行<br>";
mail.BodyEncoding = Encoding.UTF8;

if (!string.IsNullOrEmpty(startup.AppSettings.Attachment))
{
    var attachment = new Attachment(startup.AppSettings.Attachment);  
    mail.Attachments.Add(attachment);
}

using var client = new SmtpClient();
// TODO: should be configurable
client.Host = "smtp.gmail.com";
client.Port = 587;
client.Credentials = new NetworkCredential(startup.AppSettings.Account, startup.AppSettings.Password);
client.EnableSsl = true;

try
{
    client.Send(mail);
}
catch (Exception ex)
{
    Console.WriteLine($"Could not send the email to {startup.AppSettings.Receiver} : {ex.Message}");
    
    return 1;
}
finally
{
    mail.Dispose();
    client.Dispose();
}

Console.WriteLine($"Successfully sent the email from {startup.AppSettings.Account} to {startup.AppSettings.Receiver}");
return 0;