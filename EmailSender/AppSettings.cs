namespace EmailSender;

public class AppSettings
{
    public string Account { get; set; } 
    public string Password { get; set; }
    public List<string> Receivers { get; set; }
    public string? Attachment { get; set; }
}