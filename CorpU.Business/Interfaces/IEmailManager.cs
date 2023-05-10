using CorpU.Entitiy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IEmailManager
    {
        Task<OperationResult> SendPaymentSuccessfulEmail();
    }
}
