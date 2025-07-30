using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Models;

namespace MdmApi.Repository
{
    public interface IEmailServiceRepository
    {
        bool SendEmail(EmailData emailData);
        bool SendEmailWithAttachment(EmailDataWithAttachment emailData);
        bool SendUserWelcomeEmail(UserData userData);
        bool SendEmailWithExcelAttachment(EmailData emailData, DataSet ds);
    }
}
