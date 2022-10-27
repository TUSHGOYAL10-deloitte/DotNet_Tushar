using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models;
using SystemManagement.Models.Dto;

namespace SystemManagement.Sevices
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductsById(int productId);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);


        Task<bool> DeleteProduct(int productId);

    }
}
