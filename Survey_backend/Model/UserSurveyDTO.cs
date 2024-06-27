namespace Survey_backend.Model;

public class UserSurveyDTO
{
    public UserDTO User { get; set; }
    public SurveyDTO Survey { get; set; }

    public UserSurveyDTO()
    {
    }

    public UserSurveyDTO(UserDTO user, SurveyDTO survey)
    {
        User = user;
        Survey = survey;
    }
}