using System.ComponentModel.DataAnnotations;

namespace API_projTraining.Libraries
{
    public class Message
    {
        //Primary key
        [Required]
        public int MessageId { get; set; }

        [Required]
        public string MessageTitle { get; set; }

        [Required]
        public string MessageBody { get; set; }

        //Foreign Key / Navigation properties
        [Required]
        public User UserId { get;  set; }
        public User User { get; set; }
    }
}