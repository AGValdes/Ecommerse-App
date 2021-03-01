using Ecommerce_App.Services.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Services.Email.Interfaces
{
    public interface IEmail
    {
        public Task<EmailResponse> SendEmailAsync(Message message);
    }
}
