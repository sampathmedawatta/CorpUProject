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

    public class FacultyManager : IFacultyManager

    {

        private IUnitOfWork _unitOfWork;

        readonly AuthenticationOptions _AuthenticationOptions;

        public FacultyManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)

        {

            _unitOfWork = unitOfWork;

            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);

        }

        public async Task<FacultyDto> GetByIdAsync(int Id)

        {

            try

            {

                return await _unitOfWork.Faculty.GetByIdAsync(Id);

            }

            catch (Exception ex)

            {

                //TODO log error and haddle the error

            }

            return null;

        }

        public async Task<IEnumerable<FacultyDto>> GetAllAsync()

        {

            try

            {

                return await _unitOfWork.Faculty.GetAllAsync();

            }

            catch (Exception ex)

            {

                //TODO log error and haddle the error

            }

            return null;

        }

    }

}