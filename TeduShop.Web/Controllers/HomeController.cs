using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        private ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService, IProductService productService, ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var listSlide = _commonService.GetSlides();
            var listLastestProduct = _productService.GetLastest(3);
            var listHotSaleProduct = _productService.GetHotProduct(3);

            var listSlideViewModel = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(listSlide);
            var listLastestProductViewModel =
                Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listLastestProduct);
            var listHotSaleProductViewModel =
               Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listHotSaleProduct);

            var homeViewModel = new HomeViewModel()
            {
                Slides = listSlideViewModel,
                LastestProducts = listLastestProductViewModel,
                TopSaleProducts = listHotSaleProductViewModel
            };
            return View(homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel =
                Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}