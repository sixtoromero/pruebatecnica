using AutoMapper;
using ALPHA.Application.DTO;
using ALPHA.Application.Interface;
using ALPHA.Domain.Entity;
using ALPHA.Domain.Interface;
using ALPHA.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALPHA.Application.Main
{
    public class CorrespondenceApplication : ICorrespondenceApplication
    {
        private readonly ICorrespondenceDomain _CorrespondencesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CorrespondenceApplication> _logger;

        public CorrespondenceApplication(ICorrespondenceDomain CorrespondenceDomain, IMapper mapper, IAppLogger<CorrespondenceApplication> logger)
        {
            _CorrespondencesDomain = CorrespondenceDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(CorrespondenceDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Correspondence>(model);
                response.Data = await _CorrespondencesDomain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado la Correspondencia exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado, por favor intente nuevamente " + response.Data);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(CorrespondenceDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Correspondence>(model);
                response.Data = await _CorrespondencesDomain.UpdateAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Correspondencia exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado, por favor intente nuevamente " + response.Data);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int? Id)
        {
            var response = new Response<string>();

            try
            {
                response.Data = await _CorrespondencesDomain.DeleteAsync(Id);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado, por favor intente nuevamente " + response.Data);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<CorrespondenceDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CorrespondenceDTO>>();
            try
            {
                var resp = await _CorrespondencesDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CorrespondenceDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                    _logger.LogWarning("Ha ocurrido un error inesperado consultando");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<CorrespondenceDTO>>> GetAsyncByUserId(int UserId)
        {
            var response = new Response<IEnumerable<CorrespondenceDTO>>();
            try
            {
                var resp = await _CorrespondencesDomain.GetAsyncByUserId(UserId);

                response.Data = _mapper.Map<IEnumerable<CorrespondenceDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                    _logger.LogWarning("Ha ocurrido un error consultando los registros por Id.");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }       

        public async Task<Response<CorrespondenceDTO>> GetAsync(int? Id)
        {
            var response = new Response<CorrespondenceDTO>();
            try
            {
                var clase = await _CorrespondencesDomain.GetAsync(Id);

                response.Data = _mapper.Map<CorrespondenceDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
                    _logger.LogWarning("Ha ocurrido un inconveniente al consultar los registros de Correspondencias");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }        
    }
}
