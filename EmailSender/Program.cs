using System.Net;
using System.Net.Mail;
using System.Text;
using EmailSender;

Console.WriteLine("Hello, World!");

var commandLineArgs = Environment.GetCommandLineArgs();

// TODO: iterator
var _ = commandLineArgs.ElementAtOrDefault(0) ?? throw new ArgumentException("ERROR: no command line arguments are provided");

if (commandLineArgs[1] is "help" or "h")
{
    Usage.Print();
    return 0;
}

const string account = "your gmail account";
const string password = "your gmail app password";
const string receiver = "receiver email address";

var mail = new MailMessage();
mail.From = new MailAddress(account);
mail.To.Add(receiver);

// TODO: should be from config or outside files.
mail.Subject = "測試信2";
mail.SubjectEncoding = Encoding.UTF8;
mail.IsBodyHtml = true;
mail.Body = "第一行<br> 第二行<br>第三行<br>";
mail.BodyEncoding = Encoding.UTF8;

// var attachment = new Attachment(@"C:\fakepath\test.txt");  
// mail.Attachments.Add(attachment);

using var client = new SmtpClient();
// TODO: should be configurable
client.Host = "smtp.gmail.com";
client.Port = 587;
client.Credentials = new NetworkCredential(account, password);
client.EnableSsl = true;

try
{
    client.Send(mail);
}
catch (Exception ex)
{
    Console.WriteLine($"Could not send the email: {ex.Message}");
    
    return 1;
}
finally
{
    // attachment.Dispose();
    mail.Dispose();
    client.Dispose();
}

return 0;