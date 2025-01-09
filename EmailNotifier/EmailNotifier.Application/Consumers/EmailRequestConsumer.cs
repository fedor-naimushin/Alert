using EmailNotifier.Application.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MassTransit;
using Microsoft.Extensions.Options;
using MimeKit;
using Shared.Models;

namespace EmailNotifier.Application.Consumers;

public class EmailRequestConsumer : IConsumer<IEmail>, IDisposable
{
    private readonly ISmtpClient _smtpClient;
    private readonly string _fromEmail;
    private const string _textType = "plain";
    
    public EmailRequestConsumer(IOptions<Auth> options)
    {
        _smtpClient = new SmtpClient();
        _fromEmail = options.Value.Email;
        
        // Ensure that the connection and authentication are completed before proceeding
        ConnectAsync(options.Value.Host, options.Value.Port, options.Value.Email, options.Value.Password).GetAwaiter().GetResult();
    }

    private async Task ConnectAsync(string host, int port, string email, string password)
    {
        try
        {
            // Connect and authenticate asynchronously
            await _smtpClient.ConnectAsync(host, port, SecureSocketOptions.SslOnConnect);
            await _smtpClient.AuthenticateAsync(email, password);
        }
        catch (Exception ex)
        {
            // Log exception or handle it as needed
            throw new InvalidOperationException("Failed to connect or authenticate with SMTP server", ex);
        }
    }
    
    public async Task Consume(ConsumeContext<IEmail> context)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("", _fromEmail));
        email.To.Add(new MailboxAddress("", context.Message.To));
        email.Subject = context.Message.Subject;

        email.Body = new TextPart(_textType)
        {
            Text = context.Message.Body
        };

        try
        {
            await _smtpClient.SendAsync(email);
        }
        catch (Exception ex)
        {
            // Log the error or handle it as needed
            throw new InvalidOperationException("Failed to send email", ex);
        }
        finally
        {
            await _smtpClient.DisconnectAsync(true);
        }
    }

    public void Dispose()
    {
        _smtpClient.Dispose();
    }
}