using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models;
using SystemManagement.Models.Dto;
using SystemManagement.Sevices;

namespace SystemManagement.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _reponse;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._reponse = new ResponseDto();
        }
        [Authorize(Policy = "PublicSecure")]
        [HttpGet]
        public async Task<Object> Get()
        {
            //IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            try
            {
                IEnumerable<ProductDto> productDtos=await _productRepository.GetProducts();
                _reponse.Result = productDtos;
            }
            catch(Exception ex)
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
        [HttpGet]
        [Route("{id}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ProductDto productDtos = await _productRepository.GetProductsById(id);
                _reponse.Result = productDtos;
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
        public async Task<Object> Post([FromBody]ProductDto productDto)
        {
            //ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
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
        public async Task<Object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
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
                Boolean isSuccess= await _productRepository.DeleteProduct(id);
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
