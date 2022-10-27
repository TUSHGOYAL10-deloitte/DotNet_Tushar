using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Sevices;

namespace SystemManagement.Controllers
{
    [Route("api/warehouses")]
    public class WareHouseController : ControllerBase
    {
        protected ResponseDto _reponse;
        private IWareHouseRepository _wareHouseRepository;

        public WareHouseController(IWareHouseRepository wareHouseRepository)
        {

            _wareHouseRepository = wareHouseRepository;
            this._reponse = new ResponseDto();
        }

        [Authorize(Policy = "PublicSecure")]
        [HttpGet]
        public async Task<Object> Get()
        {
            //IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            try
            {
                IEnumerable<WareHouseDto> wareHouseDtos = await _wareHouseRepository.GetWareHouses();
                _reponse.Result = wareHouseDtos;
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
        public async Task<Object> Get(int id)
        {
            try
            {
                WareHouseDto wareHouseDto = await _wareHouseRepository.GetWareHouseById(id);
                _reponse.Result = wareHouseDto;
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
        public async Task<Object> Post([FromBody] WareHouseDto wareHouseDto)
        {
            //ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            try
            {
                WareHouseDto model = await _wareHouseRepository.CreateUpdateWareHouse(wareHouseDto);

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

        [Authorize(Policy = "PublicSecure")]
        [HttpPut]
        public async Task<Object> Put([FromBody] WareHouseDto wareHouseDto)
        {
            try
            {
                WareHouseDto model = await _wareHouseRepository.CreateUpdateWareHouse(wareHouseDto);
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

        [Authorize(Policy = "PublicSecure")]
        [HttpDelete]
        public async Task<Object> Delete(int id)
        {
            try
            {
                Boolean isSuccess = await _wareHouseRepository.DeleteWareHouse(id);
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
