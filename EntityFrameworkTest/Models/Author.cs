using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Author
    {

        public int AuthorId { get; set; }

        [Required()]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required()]
        [MaxLength(30)]
        public string? SurName { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }

    }
}
