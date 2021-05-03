using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALPHA.Application.DTO;
using ALPHA.Application.Interface;
using ALPHA.Transversal.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ALPHA.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CorrespondencesController : Controller
    {
        private readonly ICorrespondenceApplication _CorrespondenceApplication;
        private readonly AppSettings _appSettings;
        private readonly IValidator<CorrespondenceDTO> _messageValidator;

        public CorrespondencesController(ICorrespondenceApplication CorrespondenceApplication,
                                IValidator<CorrespondenceDTO> messageValidator,
                                IOptions<AppSettings> appSettings)
        {
            _CorrespondenceApplication = CorrespondenceApplication;
            _appSettings = appSettings.Value;
            _messageValidator = messageValidator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(CorrespondenceDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                #region Validaciones
                var validResult = _messageValidator.Validate(model);
                if (!validResult.IsValid)
                {
                    response.Data = string.Empty;

                    foreach (var error in validResult.Errors)
                    {
                        response.Data = error.ToString() + "|" + response.Data;
                    }

                    response.Data = response.Data.Substring(0, response.Data.Length - 1);
                    response.IsSuccess = false;
                    return BadRequest(response);
                }
                #endregion

                if (model == null)
                    return BadRequest();                

                response = await _CorrespondenceApplication.InsertAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CorrespondenceDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {

                #region Validaciones
                var validResult = _messageValidator.Validate(model);
                if (!validResult.IsValid)
                {
                    response.Data = string.Empty;

                    foreach (var error in validResult.Errors)
                    {
                        response.Data = error.ToString() + "|" + response.Data;
                    }

                    response.Data = response.Data.Substring(0, response.Data.Length - 1);
                    response.IsSuccess = false;
                    return BadRequest(response);
                }
                #endregion

                if (model == null)
                    return BadRequest();

                response = await _CorrespondenceApplication.UpdateAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
            
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _CorrespondenceApplication.DeleteAsync(Id);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<CorrespondenceDTO>> response = new Response<IEnumerable<CorrespondenceDTO>>();

            try
            {
                response = await _CorrespondenceApplication.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }


        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAsyncByUserId(int UserId)
        {            
            Response<IEnumerable<CorrespondenceDTO>> response = new Response<IEnumerable<CorrespondenceDTO>>();

            try
            {
                response = await _CorrespondenceApplication.GetAsyncByUserId(UserId);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            Response<CorrespondenceDTO> response = new Response<CorrespondenceDTO>();

            try
            {
                response = await _CorrespondenceApplication.GetAsync(Id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }        
    }
}
