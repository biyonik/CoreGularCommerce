using CoreGularCommerce.Core.Abstract;
using CoreGularCommerce.Core.Specification.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CoreGularCommerce.Repo.Data.Drivers
{
    public class SpecificationDriver<TEntity> where TEntity: class, IEntity, new()
    {
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQueries, ISpecification<TEntity> specification) 
        {
            var query = inputQueries;
            if(specification.Criteria != null) {
                query = query.Where(specification.Criteria);
            }
            query = specification.Includes.Aggregate(query, (current, include)=> current.Include(include));
            return query;
        }
    }
}