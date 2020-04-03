using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentCourse
{
    [Table("Book")]
    public class BookPoco
    {
        [Key]
        public int BookId { get; set; }
        [Column("BookName")]
        public string BookName { get; set; }
        
        public virtual StudentPoco Student { get; set; }
    }
}
