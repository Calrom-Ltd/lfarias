using System.ComponentModel.DataAnnotations;

namespace API_projTraining.Services
{
    public class Messages
    {
        //Foreign Key
        [Required]
        public int UserNameId { get; set; }
        
        //Primary key
        [Required]
        public int MsgId { get; set; }
        
        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string MessageBody { get; set; }
    }
}
