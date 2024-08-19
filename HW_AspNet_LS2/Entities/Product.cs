using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_AspNet_LS2.Entities
{
    public class Product
    {
        [DisplayName("Product_ID")]
        public int ID { get; set; }


        [DisplayName("Product_Name")]
        [Required(ErrorMessage = "Product Name can not be empty !")]
        public string Name { get; set; }


        [DisplayName("Product_Price")]
        [Required(ErrorMessage = "Product Price can not be empty !")]
        //[Range(0.1, 12, ErrorMessage = "Price must be 1 or greater than !")]burda default olaraq int-tipinde goturur
        [Range(0.1, double.MaxValue,ErrorMessage ="Price can not be smaller than 0.1 !")]////bu min-0.1-den ve yuxari
        [RegularExpression(@"^\d+,\d+$",ErrorMessage = "TRUE_FORMAT(0,1) - FALSE_FORMAT(0.1)")]
        public double Price { get; set; }                                                //double deyerler demekedir


        [DisplayName("Product_Description")]
        [Required(ErrorMessage = "Product Description can not be empty !")]
        public string Description { get; set; }


        [DisplayName("Product_ImagePath")]
        [Required(ErrorMessage = "Product ImagePath can not be empty !")]
        public string ImagePath { get; set; }


        [DisplayName("Product_Discount")]
        [Required(ErrorMessage = "Product Discount can not be empty !")]
        [Range(0.5, double.MaxValue, ErrorMessage = "Discount can not be smaller than 0.5 !")]
        [RegularExpression(@"^\d+,\d+$",ErrorMessage = "TRUE_FORMAT(0,1) - FALSE_FORMAT(0.1)")]
        public double Discount { get; set; }
    }
}


