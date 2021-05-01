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
    public class ContactApplication : IContactApplication
    {
        private readonly IContactDomain _ContactsDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ContactApplication> _logger;

        public ContactApplication(IContactDomain ContactDomain, IMapper mapper, IAppLogger<ContactApplication> logger)
        {
            _ContactsDomain = ContactDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(ContactDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Contact>(model);
                response.Data = await _ContactsDomain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el Contact exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(ContactDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Contact>(model);
                response.Data = await _ContactsDomain.UpdateAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Contact exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int? Id)
        {
            var response = new Response<string>();

            try
            {
                response.Data = await _ContactsDomain.DeleteAsync(Id);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<ContactDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ContactDTO>>();
            try
            {
                var resp = await _ContactsDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ContactDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<ContactDTO>> GetAsync(int? Id)
        {
            var response = new Response<ContactDTO>();
            try
            {
                var clase = await _ContactsDomain.GetAsync(Id);

                response.Data = _mapper.Map<ContactDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
