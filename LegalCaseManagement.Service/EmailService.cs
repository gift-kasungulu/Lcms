using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body, IFormFile? file)
    {
        var email = new MimeMessage();

        var fromAddress = _configuration["Email:From"];
        if (string.IsNullOrWhiteSpace(fromAddress))
        {
            throw new ArgumentException("From email address is not configured.");
        }
        email.From.Add(MailboxAddress.Parse(fromAddress));

        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        // Adding file to email
        if (file != null && file.Length > 0)
        {
            var attachment = new MimePart(MimeTypes.GetMimeType(file.FileName))
            {
                Content = new MimeContent(file.OpenReadStream(), ContentEncoding.Default),
                ContentDisposition = new MimeKit.ContentDisposition(MimeKit.ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(file.FileName)
            };
            var multipart = new Multipart("mixed");
            multipart.Add(email.Body);
            multipart.Add(attachment);
            email.Body = multipart;
        }

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration["Email:Host"], int.Parse(_configuration["Email:Port"]), SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendDefaultWelcomeEmailAsync(string toEmail)
    {
        var email = new MimeMessage();

        var fromAddress = _configuration["Email:From"];
        if (string.IsNullOrWhiteSpace(fromAddress))
        {
            throw new ArgumentException("From email address is not configured.");
        }
        email.From.Add(MailboxAddress.Parse(fromAddress));

        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = "Welcome to our App! ";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Thank you for signing up! Your Email Account has been registered with Us, you can login using the provided password: <strong>{password}</strong>" };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration["Email:Host"], int.Parse(_configuration["Email:Port"]), SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
