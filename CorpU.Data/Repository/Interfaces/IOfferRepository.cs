using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IOfferRepository<T> : IRepository<T> where T : class
    {
        //Task<IEnumerable<ApplicantDto>> SearchApplicantAsync(string name);
    }
}
