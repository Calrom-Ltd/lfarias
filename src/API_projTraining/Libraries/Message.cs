using System.ComponentModel.DataAnnotations;

namespace API_projTraining.Libraries
{
    public class Message
    {
        //[Required]
        public int MessageId { get; set; }

        [Required]
        public string MessageTitle { get; set; }

        [Required]
        public string MessageBody { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [MaxLength(100)]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [MaxLength(100)]
        public string ReceiverEmail { get; set; }
    }
}