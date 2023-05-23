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
    public class VacancyManager : IVacancyManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public VacancyManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }
        public async Task<VacancyDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.Vacancy.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<VacancyDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Vacancy.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<VacancyDto>> SearchVacancyAsync(string text)
        {
            try
            {
                return await _unitOfWork.Vacancy.SearchVacancyAsync(text);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<VacancyDto> CreateVacancyAsync(VacancyRegisterDto entity)
        {
            VacancyDto vacancyDto = new VacancyDto();
            vacancyDto.vacancy_type_id=entity.vacancy_type_id;
            vacancyDto.class_type_id= entity.class_type_id;
            vacancyDto.emp_id=entity.emp_id;
            vacancyDto.unit_id=entity.unit_id;
            vacancyDto.title=entity.title;
            vacancyDto.description=entity.description;
            vacancyDto.publish_date=entity.publish_date;
            vacancyDto.closing_date=entity.closing_date;
            vacancyDto.status=entity.status;

            var vacancyReuslt = await _unitOfWork.Vacancy.Insert(vacancyDto);

            var vacancy = await GetByIdAsync(vacancyDto.vacancy_id);
            return vacancy;
        }
        public async Task<OperationResult> UpdateVacancyAsync(VacancyUpadteDto entity)
        {
            try
            {
                VacancyDto vacancyDto = new VacancyDto();
                vacancyDto.vacancy_id = entity.vacancy_id;
                vacancyDto.vacancy_type_id= entity.vacancy_type_id;
                vacancyDto.class_type_id=entity.class_type_id;
                vacancyDto.emp_id=entity.emp_id;
                vacancyDto.unit_id = entity.unit_id;
                vacancyDto.title=entity.title;
                vacancyDto.description=entity.description;
                vacancyDto.status=entity.status;
                vacancyDto.publish_date = entity.publish_date;
                vacancyDto.closing_date = entity.closing_date;

                var vacancyReuslt = await _unitOfWork.Vacancy.Update(vacancyDto);

                var applicant = await GetByIdAsync(vacancyDto.vacancy_id);

                _or = new OperationResult
                {
                    Message = "Vacancy successfully updated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicant
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Vacancy update faild!",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }
    }
}
