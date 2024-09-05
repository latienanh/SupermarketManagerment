using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity() { }

        protected Entity(Guid id)
        {
            Id=id;
        }
        public Guid Id { get;  set; }
        public bool? IsDelete { get;  set; }
        public Guid? CreateBy { get; set; }
        public DateTime CreateTime { get;  set; }
        public Guid? DeleteBy { get;  set; }
        public AppUser UserCreate { get;protected set; }
        public AppUser UserDelete { get;protected set; }
    }
}