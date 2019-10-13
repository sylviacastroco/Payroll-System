using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// **** Add the following at the top of the class file, 
// using namespace to send/receive mails
using System.Net.Mail;

//**** Add the following code inside the body of public class clsBusinessLayer ****


/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{
    //**** Add the following code inside the body of public class clsBusinessLayer ****
    public static bool SendEmail(string Sender, string Recipient, string bcc, string cc, string Subject, string Body)
    {
        try
        {

            // create an object for MailMessage
            MailMessage MyMailMessage = new MailMessage();
            // set the Sender value
            MyMailMessage.From = new MailAddress(Sender);
            // Set the recepient
            MyMailMessage.To.Add(new MailAddress(Recipient));

            // Checks if BCC are required
            if (bcc != null && bcc != string.Empty)
            {
                // Add BCC recepient
                MyMailMessage.Bcc.Add(new MailAddress(bcc));
            }

            // Checks if CC is required
            if (cc != null && cc != string.Empty)
            {
                // Add CC Recepient
                MyMailMessage.CC.Add(new MailAddress(cc));
            }

            // Set the subject of email
            MyMailMessage.Subject = Subject;
            // Set the email contents
            MyMailMessage.Body = Body;
            // Set the email format in HTML
            MyMailMessage.IsBodyHtml = true;
            // Set email priority to normal
            MyMailMessage.Priority = MailPriority.Normal;
            // Create an object for SMTP client
            SmtpClient MySmtpClient = new SmtpClient();
            // Set the port and server for email
            MySmtpClient.Port = 25;
            MySmtpClient.Host = "127.0.0.1";
            // Send the email
            MySmtpClient.Send(MyMailMessage);
            // Return true after message is sent
            return true;
        }
        catch (Exception ex)
        {
            // in case of exception return false
            return false;
        }
    }
}
