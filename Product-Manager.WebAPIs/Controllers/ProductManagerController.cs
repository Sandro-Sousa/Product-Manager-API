using Cross.Pagination;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Manager.WebAPIs.Controllers
{
    [ApiController]
    [Route("api/ProductManager")]
    public class ProductManagerController : Controller
    {
        private readonly IProductManagerService _productManagerService;

        public ProductManagerController(IProductManagerService productManagerService)
        {
            this._productManagerService = productManagerService;
        }


        [HttpGet("v1/ProductManagerGetAllPagination")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<IEnumerable<CardDTO>>> ProductManagerGetAllPagination([FromQuery] ProductsParameters productsParameters)
        {
            try
            {
                var result = await this._productManagerService.GetAllProducts(productsParameters);
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/productManagerGetAll")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult> ProductManagerGetAll()
        {
            try
            {
                var result = await this._productManagerService.GetAll();
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/productManagerById/{productManagerId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult> ProductManagerById(int productManagerId)
        {
            try
            {
                var result = await this._productManagerService.GetById(productManagerId);

                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/insertProductManager")]
        [SwaggerResponse(StatusCodes.Status200OK, "Inserted Successfully", typeof(CardDTOInsert))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult> InsertProductManager(CardDTOInsert cardDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("the fields are invalid");
            }

            try
            {
                var result = await this._productManagerService.Insert(cardDTO);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/updateProductManager/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Updated Successfully", typeof(CardDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult> UpdateProductManager(int id, [FromBody] CardDTO cardDTO)
        {
            if (id != cardDTO.Id)
            {
                return BadRequest("Invalid ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("the fields are invalid");
            }

            try
            {
                var result = await this._productManagerService.Update(cardDTO);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("v1/deleteProductManager/{productManagerId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Deleted Successfully", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult> DeleteProductManager(int productManagerId)
        {
            try
            {
                var result = await this._productManagerService.Delete(productManagerId);

                if (result == false) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
