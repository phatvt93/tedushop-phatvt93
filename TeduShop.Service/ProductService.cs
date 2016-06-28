using System.Collections.Generic;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        Product GetById(int id);

        void Save();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, ITagRepository tagRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public Product Add(Product entity)
        {
            var product = _productRepository.Add(entity);
            _unitOfWork.Commit();

            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                foreach (string tag in tags)
                {
                    var tagId = StringHelper.ToUnsignString(tag);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        var newTag = new Tag()
                        {
                            ID = tagId,
                            Name = tag,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(newTag);
                    }

                    var productTag = new ProductTag()
                    {
                        ProductID = product.ID,
                        TagID = tagId
                    };
                    _productTagRepository.Add(productTag);
                }
            }

            return product;
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);

            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                foreach (string tag in tags)
                {
                    var tagId = StringHelper.ToUnsignString(tag);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        var newTag = new Tag()
                        {
                            ID = tagId,
                            Name = tag,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(newTag);
                    }

                    _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);

                    var productTag = new ProductTag()
                    {
                        ProductID = product.ID,
                        TagID = tagId
                    };
                    _productTagRepository.Add(productTag);
                }
            }
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _productRepository.GetAll();
            }
                
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}