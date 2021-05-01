using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALPHA.Application.DTO;
using ALPHA.Application.Interface;
using ALPHA.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ALPHA.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteApplication _clienteApplication;
        private readonly AppSettings _appSettings;

        public ClienteController(IClienteApplication clienteApplication,
                                  IOptions<AppSettings> appSettings)
        {
            _clienteApplication = clienteApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(ClienteDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();

                response = await _clienteApplication.InsertAsync(model);
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
        public async Task<IActionResult> UpdateAsync(ClienteDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();

                response = await _clienteApplication.UpdateAsync(model);
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

        [HttpDelete("{IdCliente}")]
        public async Task<IActionResult> DeleteAsync(int IdCliente)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _clienteApplication.DeleteAsync(IdCliente);

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
            Response<IEnumerable<ClienteDTO>> response = new Response<IEnumerable<ClienteDTO>>();

            try
            {
                response = await _clienteApplication.GetAllAsync();
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

        [HttpGet("{IdCliente}")]
        public async Task<IActionResult> GetAsync(int IdCliente)
        {
            Response<ClienteDTO> response = new Response<ClienteDTO>();

            try
            {
                response = await _clienteApplication.GetAsync(IdCliente);
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
        public async Task<IActionResult> GetClientesMayorCompra()
        {
            Response<IEnumerable<ClienteDTO>> response = new Response<IEnumerable<ClienteDTO>>();

            try
            {
                response = await _clienteApplication.GetClientesMayorCompra();
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
