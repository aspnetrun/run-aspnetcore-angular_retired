using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AspnetRunAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;

        public ProductController(IMediator mediator, IProductService productService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await _productService.GetProductList();

            return Ok(products);
        }

        /*
                Task<ProductModel> GetProductById(Guid productId);
                Task<IEnumerable<ProductModel>> GetProductByName(string name);
                Task<IEnumerable<ProductModel>> GetProductByCategoryId(Guid categoryId);
                Task<ProductModel> Create(ProductModel product);
                Task Update(ProductModel product);
                Task Delete(ProductModel product);
        */
    }
}