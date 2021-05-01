using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALPHA.Application.DTO;
using ALPHA.Application.Interface;
using ALPHA.Services.WebAPIRest.Helpers;
using ALPHA.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace ALPHA.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioApplication _Application;
        private readonly AppSettings _appSettings;

        public AuthController(IUsuarioApplication Application,
                                  IOptions<AppSettings> appSettings)
        {
            _Application = Application;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(UsuarioDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                string password = Encrypt.GetSHA256(model.Clave);
                model.Clave = password;

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
        public async Task<IActionResult> UpdateAsync(UsuarioDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();

                string password = Encrypt.GetSHA256(model.Clave);
                model.Clave = password;

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

        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> DeleteAsync(int IdUsuario)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _Application.DeleteAsync(IdUsuario);

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
            Response<IEnumerable<UsuarioDTO>> response = new Response<IEnumerable<UsuarioDTO>>();

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

        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> GetAsync(int IdUsuario)
        {
            Response<UsuarioDTO> response = new Response<UsuarioDTO>();

            try
            {
                response = await _Application.GetAsync(IdUsuario);
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
        public async Task<IActionResult> getLogin(UsuarioDTO model)
        {
            Response<UsuarioDTO> response = new Response<UsuarioDTO>();
            Token token = new Token();

            try
            {
                string password = Encrypt.GetSHA256(model.Clave);
                model.Clave = password;

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
