using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; private set; }
        [MaxLength(20)]  [Required]
        public string Name { get; set; }
        [MaxLength(20)]  [Required]
        public string Surname { get; set; }
        [Range(18, 81, ErrorMessage = "Must be number between 18 and 81")]
        public int Age { get; set; }
        [MaxLength(20)] [Required]
        public string Username { get; set; }
        [MaxLength(20)] [Required]
        public string Email { get; set; }
        [MaxLength(70)] [Required]
        public string Password { get; set; }
        public IEnumerable<User> Friends { get; set; }
        public IEnumerable<Interest> Interests { get; set; }
        private User()
        {

        }

        public User(string name, string surname, int age, string username, string email, string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
