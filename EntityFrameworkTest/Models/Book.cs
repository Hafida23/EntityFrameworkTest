using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Book
    {

        public int BookId { get; set; }

        [Required()]
        [MaxLength(100)]
        public string? Title { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]//om the format zal correct in the frontent met MVC
        public DateTime Published { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
