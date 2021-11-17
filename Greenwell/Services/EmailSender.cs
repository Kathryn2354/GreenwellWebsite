
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System;

/*This file comprises the majority of the email sending functionality of the website.
 * SendEmailAsync calls execute, which contains the info for the email.
 * Something to note- for this to work, an email address needs to be entered in for "yourEmail@smcm.edu" and the machine running it will need
 * a SendGrid API key named "greenwellSG" stored in it's environment variables. Instructions on how to do this are in the comment below.
 * 
 * Last edited by William Field 11/17/21
 */
namespace Greenwell.Services
{
    public class EmailSender : IEmailSender
    {   
   
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("greenwellSG");//use this line to access the API key on the machine. 
            /*
        * TO CREATE AN API KEY:
        *  follow this link https://docs.sendgrid.com/api-reference/api-keys/create-api-keys
        *  create an account with twilio, generate an API key, and update your system variables.
        *  
        *  To update system variables on windows, go to settings>advanced system settings>environment variables>then create a new user variable.
        *  
        *  Name this new user variable "greenwellSG" and paste the value as your sendgrid API key
        */
            return Execute(apiKey, subject, message, email);//make sure to take in apiKey
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                /* For testing purposes I've been using my St. Mary's email. Down the line this email will be the hostgator domain registered to greenwell's
                 * account. Something to not is that gmail does not work well as a sending address because it tends to block sendgrids service.
                 */
                From = new EmailAddress("yourEmail@smcm.edu", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
