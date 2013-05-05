using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;

namespace StrongbrookInfo
{
    /// <summary>
    /// Class containing methods to send email messages
    /// </summary>
    public class Emailer : System.Web.UI.Page
    {
        public Emailer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region email settings
        string host = "smtpout.secureserver.net";
        Int16 port = 25;
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("support@strongbrookdirect.com", "Reic2012");
        #endregion

        /// <summary>
        /// Transmit an email using HTML, returns true if email sent successfully
        /// </summary>
        /// <param name="to">string: To Address</param>
        /// <param name="from">string: From Address</param>
        /// <param name="fromName">string: From Display Name</param>
        /// <param name="subject">string: Subject Line</param>
        /// <param name="body">StringBuilder: Message Body in HTML or Text</param>
        /// <param name="IsHtml">Bool: Is Email Message HTML</param>
        public bool SendMessage(string to, string from, string fromName, string subject, StringBuilder body, bool IsHtml)
        {
            try
            {
                MailMessage message = new MailMessage(from, to, subject, body.ToString());
                message.IsBodyHtml = IsHtml;

                SmtpClient client = new SmtpClient(host, port);

                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                client.Send(message);

                message.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string OptOut(int customerID)
        {
            string OptedOut = "false";

            try
            {

            }
            catch
            {
                OptedOut += "|We could not complete this as requested, if this continues please contact support";
            }

            return OptedOut;
        }

        public string OptOut(string emailAddress)
        {
            string OptedOut = "false";

            try
            {

            }
            catch
            {
                OptedOut += "|We could not complete this as requested, if this continues please contact support";
            }

            return OptedOut;
        }
    }
}






