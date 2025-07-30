using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MdmApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using OfficeOpenXml;

namespace MdmApi.Repository
{
    public class EmailServiceRepository : IEmailServiceRepository
    {
        EmailSettings _emailSettings = null;
        public EmailServiceRepository(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = emailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                MailKit.Net.Smtp.SmtpClient emailClient = new MailKit.Net.Smtp.SmtpClient();
                //emailClient.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                // emailClient.Authenticate(_emailSettings.EmailId, "auophaofuumeexwu");
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();


                return true;
            }
            catch (SmtpException ex)
            {
                var statusCode = ex.StatusCode;
                var message = ex.Message;
                //Log Exception Details
                return false;
            }
        }

        public bool SendEmailWithAttachment(EmailDataWithAttachment emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = emailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();

                if (emailData.EmailAttachments != null)
                {
                    byte[] attachmentFileByteArray;
                    foreach (IFormFile attachmentFile in emailData.EmailAttachments)
                    {
                        if (attachmentFile.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachmentFile.CopyTo(memoryStream);
                                attachmentFileByteArray = memoryStream.ToArray();
                            }
                            emailBodyBuilder.Attachments.Add(attachmentFile.FileName, attachmentFileByteArray, ContentType.Parse(attachmentFile.ContentType));
                        }
                    }
                }

                emailBodyBuilder.TextBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                MailKit.Net.Smtp.SmtpClient emailClient = new MailKit.Net.Smtp.SmtpClient();
                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }

        public bool SendUserWelcomeEmail(UserData userData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(userData.UserName, userData.UserEmailId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = "Welcome To Pro Code Guide";

                string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeEmail.html";
                string EmailTemplateText = File.ReadAllText(FilePath);

                EmailTemplateText = string.Format(EmailTemplateText, userData.UserName, DateTime.Now.Date.ToShortDateString());

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                MailKit.Net.Smtp.SmtpClient emailClient = new MailKit.Net.Smtp.SmtpClient();
                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }

        public bool SendEmailWithExcelAttachment(EmailData emailData, DataSet ds)
        {
            try
            {
                // Create a DataSet (replace this with your actual DataSet)
                DataSet dataSet = ds;
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                // Create a new Excel package
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    //foreach (DataTable table in dataSet.Tables)
                    //{
                    //    // Create a worksheet for each table in the DataSet
                    //    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(table.TableName);
                    //    worksheet.Cells["A1"].LoadFromDataTable(table, true);
                    //}
                    // Create a worksheet for each table in the DataSet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(ds.Tables[1].TableName);
                    worksheet.Cells["A1"].LoadFromDataTable(ds.Tables[1], true);
                    // Convert the Excel package to a byte array
                    byte[] excelBytes = package.GetAsByteArray();

                    MimeMessage emailMessage = new MimeMessage();

                    MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                    emailMessage.From.Add(emailFrom);

                    MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = emailData.EmailSubject;
                    // Create a MIME part for the email body
                    var bodyBuilder = new BodyBuilder();

                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers", "Imagies", "7f166ot7.png");
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    string base64Image = Convert.ToBase64String(imageBytes);

                    string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers", "htmlpage.html");
                    string htmlContent = File.ReadAllText(htmlFilePath);
                    bodyBuilder.HtmlBody = htmlContent.Replace("@base64Image", base64Image);

                    

                    //bodyBuilder.TextBody = "Please find the attached Excel file.";

                    // Create a MIME part for the Excel attachment
                    var attachment = bodyBuilder.Attachments.Add("ExcelFile.xlsx", excelBytes, ContentType.Parse("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

                    // Add the body and attachment to the MimeMessage
                    emailMessage.Body = bodyBuilder.ToMessageBody();

                    MailKit.Net.Smtp.SmtpClient emailClient = new MailKit.Net.Smtp.SmtpClient();
                    emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                    emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                    emailClient.Send(emailMessage);
                    emailClient.Disconnect(true);
                    emailClient.Dispose();

                    return true;
                }
            }
            catch (SmtpException ex)
            {
                var statusCode = ex.StatusCode;
                var message = ex.Message;
                //Log Exception Details
                return false;
            }
        }
    }
}
