using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Application;
using CorpU.Entitiy.Models.Dto.Shortlist;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business
{
    public class ShortlistManager: IShortlistManager
    {
        private IUnitOfWork _unitOfWork;
        private readonly IApplicationManager _applicationManager;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public ShortlistManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings, IApplicationManager ApplicationManager)
        {
            _unitOfWork = unitOfWork;
            _applicationManager = ApplicationManager;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }
        public async Task<ShortlistDetailDto> GetShortlistByApplicationId(int id)
        {
            try
            {
                return await _unitOfWork.Shortlist.GetByIdAsync(id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<ShortlistDetailDto>> GetAllShortlistAsync()
        {
            try
            {
                return await _unitOfWork.Shortlist.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<ShortlistDetailDto> CreateShortlistAsync(ShortlistRegisterDto entity)
        {
            ShortlistDetailDto shortlistDto = new()
            {
                Application_id = entity.Application_id,
                emp_id = entity.emp_id,
                interview_date = DateTime.Now,
                status = entity.status,
                comments = entity.comments
            };

            var shortlistReuslt = await _unitOfWork.Shortlist.Insert(shortlistDto);

            if (shortlistReuslt > 0)
            {
                ApplicationUpdateDto applicationDto = new()
                {
                    Application_id = entity.Application_id,
                    status = entity.status
                };

                await _applicationManager.UpdateApplicationAsync(applicationDto);
            }

            var shortlist = await GetShortlistByApplicationId(shortlistDto.Application_id);
            return shortlist;
        }
        public async Task<OperationResult> UpdateShortlistAsync(ShortlistUpdateDto entity)
        {
            try
            {
                ShortlistDetailDto shortlistDto = new ShortlistDetailDto();
                shortlistDto.shortlist_id= entity.shortlist_id;
                shortlistDto.Application_id = entity.Application_id;
                shortlistDto.emp_id = entity.emp_id;
                shortlistDto.interview_date= entity.interview_date;
                shortlistDto.status = entity.status;    
                shortlistDto.comments = entity.comments;

                var shortlistReuslt = await _unitOfWork.Shortlist.Update(shortlistDto);

                var applicant = await GetShortlistByApplicationId(shortlistDto.Application_id);

                _or = new OperationResult
                {
                    Message = "Shortlist successfully updated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicant
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Shortlist update faild!",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }
    }
}
