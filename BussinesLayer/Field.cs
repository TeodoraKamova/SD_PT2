using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Field
    {
        [Key]
        public int Id { get; private set; }
        [MaxLength(20)] [Required]
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        private Field()
        {

        }

        public Field(string name)
        {
            Name = name;
        }
    }
}
