namespace Survey_backend.Model;

public class SurveyDTO
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string DateOfBirth { get; set; }
    public string FavouriteFood { get; set; }
    public string LikeMovies { get; set; }
    public string ListenToRadio { get; set; }
    public string EatOut { get; set; }
    public string WatchTV { get; set; }
    public string User_id { get; set; }

    public SurveyDTO()
    {
    }

    public SurveyDTO(string id, string type, string dateOfBirth, string favouriteFood, string likeMovies,
        string listenToRadio, string eatOut, string watchTv, string userId)
    {
        Id = id;
        Type = type;
        DateOfBirth = dateOfBirth;
        FavouriteFood = favouriteFood;
        LikeMovies = likeMovies;
        ListenToRadio = listenToRadio;
        EatOut = eatOut;
        WatchTV = watchTv;
        User_id = userId;
    }
}