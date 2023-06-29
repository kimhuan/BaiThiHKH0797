using System.ComponentModel.DataAnnotations;

namespace BaiThiHKH.Models
{
    public class HKHcau3
    {
        [Key]
        [Display (Name = "Mã nhân dân")]
        public int? PersonID { get; set; }

        [Display (Name = "Tên nhân dân")]
        public string? PersonName { get; set; }
        
        [Display (Name = "Điện thoại liên hệ")]
        public string? PersonNumber { get; set; }  

        [Display (Name = "Địa chỉ")]
        public string? PersonAddress { get; set; }   
    }
}