using System.ComponentModel.DataAnnotations;

namespace ArtProject.Models
{
    public class UserExhModel
    {
        public string Username { get; set; }
        public string ExhId { get; set; }

        [Key]
        public int RecId { get; set; }


        public UserExhModel(string username, string exhid, int id)
        {
            Username = username;
            ExhId = exhid;
            RecId = id;
        }

        public UserExhModel()
        {
            
        }
    }
}
