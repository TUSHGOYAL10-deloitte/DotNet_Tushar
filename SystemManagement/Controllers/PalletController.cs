using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Sevices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SystemManagement.Controllers
{
    [Route("api/pallets")]
    //[ApiController]
    public class PalletController : ControllerBase
    {
        protected ResponseDto _reponse;
        private IPalletRepository _palletRepository;
        public PalletController(IPalletRepository palletRepository)
        {
            _palletRepository = palletRepository;
            this._reponse = new ResponseDto();
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            //IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            try
            {
                IEnumerable<PalletDto> palletDtos = await _palletRepository.GetPallets();
                _reponse.Result = palletDtos;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.ErrorMessage = new List<String>()
                {
                    ex.ToString()
                };
            }
            return _reponse;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetById(int id)
        {
            try
            {
                PalletDto palletDto = await _palletRepository.GetPalletById(id);
                _reponse.Result = palletDto;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.ErrorMessage = new List<String>()
                {
                    ex.ToString()
                };
            }
            return _reponse;
        }

        [HttpPost]
        public async Task<Object> Post([FromBody] PalletDto palletDto)
        {
            //ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            try
            {
                PalletDto model = await _palletRepository.CreateUpdatePallet(palletDto);
                _reponse.Result = model;

            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.ErrorMessage = new List<String>()
                {
                    ex.ToString()
                };
            }
            return _reponse;


        }

        [HttpPut]
        public async Task<Object> Put([FromBody] PalletDto palletDto)
        {
            try
            {
                PalletDto model = await _palletRepository.CreateUpdatePallet(palletDto);
                _reponse.Result = model;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.ErrorMessage = new List<String>()
                {
                    ex.ToString()
                };
            }
            return _reponse;
        }

        [HttpDelete]
        public async Task<Object> Delete(int id)
        {
            try
            {
                Boolean isSuccess = await _palletRepository.DeletePallet(id);
                _reponse.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _reponse.IsSuccess = false;
                _reponse.ErrorMessage = new List<String>()
                {
                    ex.ToString()
                };
            }
            return _reponse;
        }
    }
}
