using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBookShop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string BookId { get; set; }

        public Book Book { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [Required, MinLength(1)]

        public int Count { get; set; }



    }
}
