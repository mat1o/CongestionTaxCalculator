using CongestionTaxCalculator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entity
{
    public class CarTollType: BaseEntity
    {
        public VehicleType VehicleType { get; set; }
        public bool TollFree { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
