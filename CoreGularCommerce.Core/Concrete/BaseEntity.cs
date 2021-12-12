using CoreGularCommerce.Core.Abstract;

namespace CoreGularCommerce.Core.Concrete
{
    public class BaseEntity: IEntity
    {
        public int Id { get; set; }
    }
}