using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
  
        [MaxLength(13)]
        public string ISBN { get; set; }

        [Required,
        DataType(DataType.Date),
        Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }

        [Required,
        DataType(DataType.Currency)]
        public int Price { get; set; }

        [Required]
        public string Author { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int SubCategory SubCategory {get; set;}


}
}
