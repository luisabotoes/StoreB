namespace StoreB.Web.Data
{
    using System.Linq;
    using StoreB.Web.Data.Entities;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}
