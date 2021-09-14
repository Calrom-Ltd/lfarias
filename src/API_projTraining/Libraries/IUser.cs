namespace API_projTraining.Libraries
{
    public interface IUser
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        int UserId { get; set; }
    }
}