

namespace StoreB.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Product {
        public int Id { get; set; }

        [MaxLength(50,ErrorMessage ="The field {0} can only contain {1} characters length." )]
        [Required]
        public string Name { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }


        [Display(Name = "Image")]
        public decimal ImageUrl { get; set; }


        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }


        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }


        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Double Stock { get; set; }
    }
}
