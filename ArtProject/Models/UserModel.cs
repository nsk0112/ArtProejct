using System.ComponentModel.DataAnnotations;

namespace ArtProject.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Key]
        public int Id { get; set; }

        public UserModel(string name, int age, string email, string username, string password, int id)
        {
            Name = name;
            Age = age;
            Email = email;
            Username = username;
            Password = password;
            Id = id;
        }

        public UserModel()
        {
        }
    }
}
