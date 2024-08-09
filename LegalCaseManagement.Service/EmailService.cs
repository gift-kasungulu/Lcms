using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
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

    public async Task SendEmailAsync(string toEmail, string subject, string body)
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
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = " Thank you for signing up! Yor Email Account has been Registered With DICT's HelpDesk System, Use the link below to log in and use the app. Click <a href='#'>here</a> to log in to our app." };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration["Email:Host"], int.Parse(_configuration["Email:Port"]), SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}