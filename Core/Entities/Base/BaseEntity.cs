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

        public BaseEntity(string createdBy, string updatedBy)
        {
            CreatedBy = createdBy;
            CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            UpdatedBy = updatedBy;
            UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
        }

        public BaseEntity(string updatedBy)
        {
            UpdatedBy = updatedBy;
            UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
        }

        public BaseEntity()
        {
        }
    }
}
