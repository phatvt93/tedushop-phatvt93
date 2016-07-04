using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;
        private IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        // GET: Product
        [HttpGet]
        public ActionResult Detail(int productId)
        {
            var productModel = _productService.GetById(productId);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(productModel);

            var listRelatedProduct = _productService.GetRelatedProducts(productId, 6);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listRelatedProduct);

            List<string> listImage = new JavaScriptSerializer().Deserialize<List<string>>(productModel.MoreImages);
            ViewBag.MoreImages = listImage;

            var listTag = _productService.GetListTagByProductId(productId);
            ViewBag.Tags = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(listTag);

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult Category(int id, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var listProductModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, sort,
                out totalRow);
            var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProductModel);

            int totalPage = (int) Math.Ceiling(((double) totalRow/pageSize));

            var category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = listProductViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        [HttpGet]
        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var listProductModel = _productService.Search(keyword, page, pageSize, sort, out totalRow);
            var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProductModel);
            int totalPage = (int) Math.Ceiling((double) totalRow/pageSize);

            ViewBag.KeyWord = keyword;
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = listProductViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }

        public ActionResult ListByTag(string tagId, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var listProduct = _productService.GetListProductByTag(tagId, page, pageSize, out totalRow);
            var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProduct);

            int totalPage = (int) Math.Ceiling((double) totalRow/pageSize);

            var tag = _productService.GetTag(tagId);
            ViewBag.Tag = Mapper.Map<Tag, TagViewModel>(tag);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = listProductViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListNameProductByName(keyword);
            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
    }
}