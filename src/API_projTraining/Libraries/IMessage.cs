namespace API_projTraining.Libraries
{
    public interface IMessage
    {
        string MessageBody { get; set; }
        int MessageId { get; set; }
        string MessageTitle { get; set; }
        string ReceiverEmail { get; set; }
        string SenderEmail { get; set; }
    }
}