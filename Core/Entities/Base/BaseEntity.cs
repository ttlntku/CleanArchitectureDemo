using Core.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Base
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
