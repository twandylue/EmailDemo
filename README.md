# Demo for Sending Email

This is a demo project for sending email through Gmail SMTP in C#.

## Quick Start

Setting up your basic config in `./EmailSender/appsettings.json`

```json
{
  "AppSettings": {
    "Account": "sender@gmail.com",
    "Password": "your email password",
    "Receivers": [
      "receiver1@gmail.com",
      "receiver2@gmail.com"
    ],
    "Attachment": "attachment file path"
  }
}
```

Sending email

```console
cd ./EmailSender
$ dotnet run
Hello, World!
Successfully sent the email from sender@gmail.com to receiver1@gmail.com
Successfully sent the email from sender@gmail.com to receiver2@gmail.com
```

## References

- [What is SMTP](https://www.cloudflare.com/zh-tw/learning/email-security/what-is-smtp/)
- [GMail寄信程式碼(C#)](https://dotblogs.azurewebsites.net/Leon-Yang/2020/12/18/120055)
- [Google App Password](https://support.google.com/accounts/answer/185833?hl=zh-Hant&sjid=3067595440307416640-AP)
- [Gmail new policy](https://blog.no2don.com/2022/06/c-gmail-2022.html)
