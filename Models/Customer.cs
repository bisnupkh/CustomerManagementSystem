using System.ComponentModel.DataAnnotations;

namespace HimlayanEverestInsurance.Models
{
    public class Customer
    {
        
        [Key]
        public int Customer_Id { get; set; }
        [Required]
        public string Customer_Name { get; set; }

        [Required]  
        public string Customer_Email { get; set;}
        [Required]
        public string Customer_Phone { get; set;}
    }
}
