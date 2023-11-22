using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.Domain.Annotations;

namespace CongestionTaxCalculator.Domain.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "smalldatetime")]
        [DatetimeRangeAnnotation]
        public DateTime CreatedAt { get; set; }
    }
}
