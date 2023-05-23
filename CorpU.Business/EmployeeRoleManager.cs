using CorpU.Business.Interfaces;

using CorpU.Common;

using CorpU.Data.Repository.Interfaces;

using CorpU.Entitiy.Models.Dto.Referance;

using Microsoft.Extensions.Options;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace CorpU.Business

{

    public class EmployeeRoleManager : IEmployeeRoleManager

    {

        private IUnitOfWork _unitOfWork;

        readonly AuthenticationOptions _AuthenticationOptions;

        public EmployeeRoleManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)

        {

            _unitOfWork = unitOfWork;

            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);

        }

        public async Task<EmployeeRoleDto> GetByIdAsync(int Id)

        {

            try

            {

                return await _unitOfWork.EmployeeRole.GetByIdAsync(Id);

            }

            catch (Exception ex)

            {

                //TODO log error and haddle the error

            }

            return null;

        }

        //public async Task<IEnumerable<EmployeeRoleDto>> GetAllAsync()

        //{

        //    try

        //    {

        //        return await _unitOfWork.EmployeeRole.GetAllAsync();

        //    }

        //    catch (Exception ex)

        //    {

        //        //TODO log error and haddle the error

        //    }

        //    return null;

        //}

    }

}