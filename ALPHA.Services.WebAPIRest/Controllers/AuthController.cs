using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALPHA.Application.DTO;
using ALPHA.Application.Interface;
using ALPHA.InfraStructure.DAL;
using ALPHA.Services.WebAPIRest.Helpers;
using ALPHA.Services.WebAPIRest.Validator;
using ALPHA.Transversal.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace ALPHA.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserApplication _Application;
        private readonly AppSettings _appSettings;
        private readonly DbContextOptions<ALPHADataContext> options;
        private readonly IValidator<UserDTO> _userValidator;

        public AuthController(IUserApplication Application,
                                IOptions<AppSettings> appSettings,
                                IValidator<UserDTO> userValidator,
                                DbContextOptions<ALPHADataContext> options)
        {
            _Application = Application;
            _appSettings = appSettings.Value;
            _userValidator = userValidator;
            this.options = options;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(UserDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                #region Validaciones
                var validResult = _userValidator.Validate(model);
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

                string password = Encrypt.GetSHA256(model.Password);
                model.Password = password;

                if (model == null)
                    return BadRequest();

                response = await _Application.InsertAsync(model);
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
        public async Task<IActionResult> UpdateAsync(UserDTO model)
        {

            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();


                #region Validaciones
                var validResult = _userValidator.Validate(model);
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

                string password = Encrypt.GetSHA256(model.Password);
                model.Password = password;

                response = await _Application.UpdateAsync(model);
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

        [HttpDelete("{IdUser}")]
        public async Task<IActionResult> DeleteAsync(int IdUser)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _Application.DeleteAsync(IdUser);

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
            Response<IEnumerable<UserDTO>> response = new Response<IEnumerable<UserDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
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

        [HttpGet("{IdUser}")]
        public async Task<IActionResult> GetAsync(int IdUser)
        {
            Response<UserDTO> response = new Response<UserDTO>();

            try
            {
                response = await _Application.GetAsync(IdUser);
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
        
        [HttpPost]
        public async Task<IActionResult> getLogin(UserDTO model)
        {
            Response<UserDTO> response = new Response<UserDTO>();
            Token token = new Token();

            try
            {
                string password = Encrypt.GetSHA256(model.Password);
                model.Password = password;

                if (model == null)
                    return BadRequest();

                response = await _Application.getLogin(model);
                if (response.IsSuccess)
                {
                    response.Data.Token = token.GetToken(response.Data, _appSettings);
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
