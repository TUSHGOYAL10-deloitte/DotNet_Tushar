using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Database;
using SystemManagement.Models;
using SystemManagement.Models.Dto;

namespace SystemManagement.Sevices
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _dbcontext;
        private IMapper _mapper;

        public ProductRepository(ApiDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;

        }


        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _dbcontext.Products.Update(product);

            }
            else
            {
                _dbcontext.Products.Add(product);
            }
            await _dbcontext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

       
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _dbcontext.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _dbcontext.Remove(product);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _dbcontext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
        
        public async Task<ProductDto> GetProductsById(int productId)
        {
            Product product = await _dbcontext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);

        }
    }
}
