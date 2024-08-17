namespace Application.Responses.Auth;

public class RegisteredUserResponse
{
    public List<string> Errors { get; set; } = new List<string>();
    public string UserEmail { get; set; }
    public void AddErrors(string erro) => Errors.Add(erro);
    public void SetError(List<string> errors) => Errors = errors;
}