using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService,
            IProductCategoryService productCategoryService)
            : base(errorService)
        {
            _productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                var listProductCategory = _productCategoryService.GetAll();

                var totalRow = listProductCategory.Count();

                var query = listProductCategory.OrderByDescending(x => x.CreatedDate).Skip(page*pageSize).Take(pageSize);


                var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>,
                    IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>
                {
                    Items = listProductCategoryViewModel,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int) Math.Ceiling((decimal) totalRow/pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }
    }
}