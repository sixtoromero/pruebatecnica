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
    public class ViewFacturaController : Controller
    {
        private readonly IViewFacturaApplication _Application;
        private readonly AppSettings _appSettings;

        public ViewFacturaController(IViewFacturaApplication iApplication,
                                  IOptions<AppSettings> appSettings)
        {
            _Application = iApplication;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetViewFactura()
        {
            Response<IEnumerable<ViewFacturaDTO>> response = new Response<IEnumerable<ViewFacturaDTO>>();

            try
            {
                response = await _Application.getListFactura();
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
        public async Task<IActionResult> GetViewFacturaByFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            Response<IEnumerable<ViewFacturaDTO>> response = new Response<IEnumerable<ViewFacturaDTO>>();

            try
            {
                response = await _Application.getListFacturaByFecha(FechaInicio, FechaFin);
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
        public async Task<IActionResult> GetTotalesporCamarero()
        {
            Response<IEnumerable<TotalesByCamareroDTO>> response = new Response<IEnumerable<TotalesByCamareroDTO>>();

            try
            {
                response = await _Application.getTotalesporCamarero();
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
