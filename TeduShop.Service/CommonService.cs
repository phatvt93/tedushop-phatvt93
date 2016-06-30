using System.Collections.Generic;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService : ICommonService
    {

        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository, ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            _footerRepository = footerRepository;
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
    }
}