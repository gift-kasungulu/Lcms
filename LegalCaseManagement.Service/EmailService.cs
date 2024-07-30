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
    private readonly UserManager<ApplicationUser> _userManager; 

    public EmailService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager; 
    }
    public async Task SendEmailAsync(string toEmail, string subject, string body, IFormFile? file = null)
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


    public async Task SendAppointmentNotificationAsync(Appointment appointment)
    {
        var sender = await _userManager.FindByIdAsync(appointment.CreatedBy);
        var recipient = await _userManager.FindByIdAsync(appointment.UserId);

        if (sender == null || recipient == null)
        {
            throw new ArgumentException("Sender or recipient not found.");
        }

        var subject = "New Appointment Created";
        var body = "";

        var senderRoles = await _userManager.GetRolesAsync(sender);
        var recipientRoles = await _userManager.GetRolesAsync(recipient);

        if (senderRoles.Contains("Client") && recipientRoles.Contains("Team"))
        {
            // Appointment created by Client with Lawyer
            body = $"Dear {recipient.Email},\n\n";
            body += $"You have a new appointment scheduled with {sender.Email} on {appointment.Date.ToShortDateString()} at {appointment.Time.ToString(@"hh\:mm")}.\n\n";
        }
        else if (senderRoles.Contains("Team") && recipientRoles.Contains("Client"))
        {
            // Appointment created by Lawyer with Client
            body = $"Dear {recipient.Email},\n\n";
            body += $"You have a new appointment scheduled with {sender.Email} on {appointment.Date.ToShortDateString()} at {appointment.Time.ToString(@"hh\:mm")}.\n\n";
        }
        else
        {
            throw new ArgumentException("Invalid appointment configuration.");
        }

        body += "Thank you.";

        await SendEmailAsync(recipient.Email, subject, body);
    }




    public async Task SendDefaultWelcomeEmailAsync(string toEmail, string password)
    {
        var email = new MimeMessage();

        var fromAddress = _configuration["Email:From"];
        if (string.IsNullOrWhiteSpace(fromAddress))
        {
            throw new ArgumentException("From email address is not configured.");
        }
        email.From.Add(MailboxAddress.Parse(fromAddress));

        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = "Welcome to our App!";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = $"Your email account has been registered with us. You can log in using the provided password: <strong>{password}</strong>"
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration["Email:Host"], int.Parse(_configuration["Email:Port"]), SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    public async Task SendDefaultWelcomeEmailToUserAsync(string toEmail, string firstName, string lastName, string password)
    {
        var useremail = new MimeMessage();

        var fromAddress = _configuration["Email:From"];
        if (string.IsNullOrWhiteSpace(fromAddress))
        {
            throw new ArgumentException("From email address is not configured.");
        }
        useremail.From.Add(MailboxAddress.Parse(fromAddress));

        useremail.To.Add(MailboxAddress.Parse(toEmail));
        useremail.Subject = "Welcome to our App!";
        useremail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = $"Dear {firstName} {lastName},<br/><br/>" +
                   $"Thank you for signing up! Your email account has been registered with us. " +
                   $"You can log in using the provided password: <strong>{password}</strong><br/><br/>" +
                   $"Best Regards,<br/>The Team"
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_configuration["Email:Host"], int.Parse(_configuration["Email:Port"]), SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);
        await smtp.SendAsync(useremail);
        await smtp.DisconnectAsync(true);
    }


}
