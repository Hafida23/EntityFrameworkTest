using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required()]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required()]
        [MaxLength(30)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
