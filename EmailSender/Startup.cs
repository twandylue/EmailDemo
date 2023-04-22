using Microsoft.Extensions.Configuration;

namespace EmailSender;

public class Startup
{
    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
        var config = builder.Build();
        
        this.AppSettings = config.GetSection("AppSettings").Get<AppSettings>();
    }
    
    public AppSettings AppSettings { get; set; }
}