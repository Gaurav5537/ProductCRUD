using System.ComponentModel.DataAnnotations;

namespace ProductCRUD.Models
{
    public class Product
    {
        [Display(Name ="ProductId")]
        public int id { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Product Description")]
        public string ProductDesc { get; set; } = string.Empty;

        public DateTime? CreatedTime { get; set; }
    }
}
