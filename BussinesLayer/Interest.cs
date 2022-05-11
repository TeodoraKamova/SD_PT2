using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Interest
    {
        [Key]
        public int Id { get; private set; }
        [MaxLength(20)] [Required]
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        public Field Field { get; set; }
        private Interest()
        {

        }

        public Interest(string name, Field field)
        {
            Name = name;
            Field = field;
        }
    }
}
