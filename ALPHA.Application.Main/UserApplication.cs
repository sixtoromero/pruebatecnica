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
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserApplication> _logger;

        public UserApplication(IUserDomain Domain, IMapper mapper, IAppLogger<UserApplication> logger)
        {
            _Domain = Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(UserDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<User>(model);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el User exitosamente.";                    
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado registrando el usuario " + model.Username + ", (" + response.Data + ")");
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

        public async Task<Response<string>> UpdateAsync(UserDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<User>(model);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el User exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado actualizando el usuario " + model.Username + ", (" + response.Data + ")");
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
                response.Data = await _Domain.DeleteAsync(Id);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado eliminando al usuario " + Id.ToString() + ", (" + response.Data + ")");
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

        public async Task<Response<IEnumerable<UserDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UserDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<UserDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;                    
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                    _logger.LogWarning("Ha ocurrido un error consultando los registros.");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<UserDTO>> GetAsync(int? Id)
        {
            var response = new Response<UserDTO>();
            try
            {
                var clase = await _Domain.GetAsync(Id);

                response.Data = _mapper.Map<UserDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
                    _logger.LogWarning("Ha ocurrido un error consultando el registro con Id. " + Id.ToString());
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<UserDTO>> getLogin(UserDTO model)
        {
            var response = new Response<UserDTO>();
            try
            {
                var resp = _mapper.Map<User>(model);
                var result = await _Domain.getLogin(resp);

                response.Data = _mapper.Map<UserDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Usuario o contraseña incorrecta";
                    _logger.LogWarning("Usuario o contraseña incorrecta (" + model.Username + ")");
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
