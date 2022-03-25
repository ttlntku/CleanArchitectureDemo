using Employee.API.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public BaseEntity()
        {
            CreatedBy = "KIEU";
            CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            UpdatedBy = "KIEU";
            UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
        }
    }
}
