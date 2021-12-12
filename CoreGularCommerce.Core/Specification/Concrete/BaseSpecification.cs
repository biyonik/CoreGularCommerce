using System.Linq.Expressions;
using CoreGularCommerce.Core.Specification.Abstract;

namespace CoreGularCommerce.Core.Specification.Concrete
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, bool>> Criteria { get; }

        protected void AddInclude(Expression<Func<T, object>> includesExpression)
        {
            Includes.Add(includesExpression);
        }
    }
}