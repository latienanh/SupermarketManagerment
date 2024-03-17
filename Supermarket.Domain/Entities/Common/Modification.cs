using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Entities.Common
{
    public class Modification
    {
        public int Id { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int EntityId { get; set; }
        public BaseDomain EntityModified { get; set; }
    }
}
