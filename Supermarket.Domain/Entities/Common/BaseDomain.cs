using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Common
{
    public class BaseDomain
    {
        public BaseDomain()
        {
            Modifications = new List<Modification>();
        }
        public int Id { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int? DeleteBy { get; set; }
        public AppUser AppUsers { get; set; }
        public ICollection<Modification> Modifications { get; set; }
    }
}
