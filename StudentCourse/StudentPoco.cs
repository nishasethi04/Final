using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentCourse
{
    
    [Table("Student")]
   public  class StudentPoco
    {
        
        [Key]
        public Guid ID { get; set; }
               
        [Column("StudentName")]
         public string Name { get; set; }
        public virtual ICollection<BookPoco> Books { get; set; }
    }
}
