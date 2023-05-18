using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Referance;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business
{
    public class ClassTypeManager : IClassTypeManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        public ClassTypeManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
        }
        public async Task<ClassTypeDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.ClassType.GetByIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<ClassTypeDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.ClassType.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
    }
}
