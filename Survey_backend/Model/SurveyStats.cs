namespace Survey_backend.Model;

public class SurveyStats
{
    public int TotalSurveys { get; set; }
    public string AvarageAge { get; set; }
    public string OldAge { get; set; }
    public string YoungAge { get; set; }

    public double PizzaLovers { get; set; }
    public double PastaLovers { get; set; }
    public double PapAndWorsLovers { get; set; }

    public double MovieLovers { get; set; }
    public double RadioLovers { get; set; }
    public double EatOutLovers { get; set; }
    public double TvLovers { get; set; }

    public SurveyStats()
    {
    }

    public SurveyStats(int totalSurveys, string avarageAge, string oldAge, string youngAge, double pizzaLovers,
        double pastaLovers, double papAndWorsLovers, double movieLovers, double radioLovers, double eatOutLovers,
        double tvLovers)
    {
        TotalSurveys = totalSurveys;
        AvarageAge = avarageAge;
        OldAge = oldAge;
        YoungAge = youngAge;
        PizzaLovers = pizzaLovers;
        PastaLovers = pastaLovers;
        PapAndWorsLovers = papAndWorsLovers;
        MovieLovers = movieLovers;
        RadioLovers = radioLovers;
        EatOutLovers = eatOutLovers;
        TvLovers = tvLovers;
    }
}