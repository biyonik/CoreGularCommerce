using System.Linq.Expressions;

namespace CoreGularCommerce.Core.Specification.Abstract
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, object>>> Includes {get;}
    }
}