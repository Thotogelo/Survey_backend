namespace Survey_backend.Model;

public class SurveyDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string SurveyCollectionName { get; set; } = null!;
}