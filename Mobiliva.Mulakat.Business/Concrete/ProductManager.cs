using Core.Aspects.Autofac.Caching;
using Mobiliva.Mulakat.Business.Constants;
using Mobiliva.Mulakat.Core.Aspects.Autofac.Caching;
using Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching;
//using Core.Aspects.Autofac.Validation;

namespace Mobiliva.Mulakat.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ICacheService CacheService { get; }

        public ProductManager(IProductDal productDal, ICacheService cacheService)
        {
            _productDal = productDal;
            CacheService = cacheService;
        }

        //[ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        //[CacheAspect]
        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return GetProductsFromCache();
        }

        private IDataResult<List<Product>> GetProductsFromCache()
        {
            return CacheService.GetOrAdd("getallproducts", () => { return new SuccessDataResult<List<Product>>(_productDal.GetAll()); });
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetByCategory(string category)
        {
            if (category == null)
                return new SuccessDataResult<List<Product>>(_productDal.GetAll());
            else
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.Category == category));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetById(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(b => b.Id == id));
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
