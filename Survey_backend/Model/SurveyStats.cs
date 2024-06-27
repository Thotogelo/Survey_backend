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
}