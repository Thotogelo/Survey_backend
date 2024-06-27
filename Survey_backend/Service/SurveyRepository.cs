using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Survey_backend.Model;

namespace Survey_backend.Service;

public class SurveyRepository
{
    private readonly IMongoCollection<SurveyDTO> _surveyCollection;
    private readonly IMongoCollection<UserDTO> _userCollection;

    public SurveyRepository(IOptions<SurveyDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _surveyCollection = mongoDatabase.GetCollection<SurveyDTO>(
            bookStoreDatabaseSettings.Value.SurveyCollectionName);
    }

    public IEnumerable<SurveyDTO> GetByType(string type) =>
        _surveyCollection.Find(survey => survey.Type == type).ToList();

    public SurveyDTO verifySurvey(string userId, string type) =>
        _surveyCollection.Find(survey => survey.User_id == userId && survey.Type == type).FirstOrDefault();

    public UserDTO verfiyUser(string userId) =>
        _userCollection.Find(user => user.Id == userId).FirstOrDefault();
}