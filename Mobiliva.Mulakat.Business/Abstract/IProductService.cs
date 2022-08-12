namespace Mobiliva.Mulakat.Business.Abstract
{
    public interface IProductService
    {
        //object GetAll(Expression<Func<Product, bool>> filter = null);
        IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        IDataResult<List<Product>> GetById(int id);
        IDataResult<List<Product>> GetByCategory(string category);
        IResult Add(Product brand);
        IResult Delete(Product brand);
        IResult Update(Product brand);
    }
}