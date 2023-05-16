using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using CorpU.Entitiy.Models.Dto.Unit;
using CorpU.Entitiy.Models.Dto.Referance;
using Microsoft.Extensions.Options;
using System.Net;

namespace CorpU.Business
{
    public class VacancyTypeManager : IVacancyTypeManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public VacancyTypeManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }
        public async Task<VacancyTypeDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.VacancyType.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<VacancyTypeDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.VacancyType.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
    }
}
