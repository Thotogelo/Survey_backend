using Survey_backend.Enum;
using Survey_backend.Model;

namespace Survey_backend.Service;

public interface ISurveyService
{
    static SurveyStats GetSurveyStats(LinkedList<SurveyDTO> list)
    {
        SurveyStats stats = new SurveyStats();
        stats.TotalSurveys = list.Count;
        stats.OldAge = CalculateAge(GetDate(list, true)) + "";
        stats.AvarageAge = CalculateAge(GetAverageDateOfBirth(list)) + "";
        stats.YoungAge = CalculateAge(GetDate(list, false)) + "";

        stats.PizzaLovers = GetPercentageOfFoodLovers(list, FoodEnum.PIZZA.ToString());
        stats.PastaLovers = GetPercentageOfFoodLovers(list, FoodEnum.PASTA.ToString());
        stats.PapAndWorsLovers = GetPercentageOfFoodLovers(list, FoodEnum.PAP_AND_WORS.ToString());

        stats.MovieLovers = GetMoviePercentageOfStronglyAgreeAndAgree(list);
        stats.RadioLovers = GetRadioPercentageOfStronglyAgreeAndAgree(list);
        stats.EatOutLovers = GetEatoutAverageMoviePercentage(list);
        stats.TvLovers = GetTvPercentageOfStronglyAgreeAndAgreeIn(list);

        return stats;
    }

    public static string GetDate(LinkedList<SurveyDTO> list, bool findMax)
    {
        string myDate = "No dates found.";
        if (list.Count > 0)
        {
            var date = findMax
                ? list.Max(survey => DateTime.Parse(survey.DateOfBirth))
                : list.Min(survey => DateTime.Parse(survey.DateOfBirth));
            myDate = date.ToString("dd MMMM yyyy");
        }

        return myDate;
    }


    public static string GetAverageDateOfBirth(LinkedList<SurveyDTO> list)
    {
        if (list.Count == 0)
            return "No Average found";

        long totalTicks = 0;
        foreach (var survey in list)
        {
            DateTime dateOfBirth = DateTime.Parse(survey.DateOfBirth);
            totalTicks += dateOfBirth.Ticks;
        }

        long averageTicks = totalTicks / list.Count;
        DateTime averageDate = new DateTime(averageTicks);

        return averageDate.ToString("dd MMMM yyyy");
    }

    public static double GetMoviePercentageOfStronglyAgreeAndAgree(LinkedList<SurveyDTO> list)
    {
        int totalSurveyed = list.Count;
        int totalStronglyAgreeAndAgree = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.LikeMovies;
            if (RateEnum.STRONGLY_AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase) ||
                RateEnum.AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalStronglyAgreeAndAgree++;
            }
        }

        return (double)totalStronglyAgreeAndAgree / totalSurveyed * 100;
    }

    public static double GetRadioPercentageOfStronglyAgreeAndAgree(LinkedList<SurveyDTO> list)
    {
        int totalSurveyed = list.Count;
        int totalStronglyAgreeAndAgree = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.ListenToRadio;
            if (RateEnum.STRONGLY_AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase) ||
                RateEnum.AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalStronglyAgreeAndAgree++;
            }
        }

        return (double)totalStronglyAgreeAndAgree / totalSurveyed * 100;
    }

    public static int CalculateAge(string dateOfBirth)
    {
        DateTime dob = DateTime.Parse(dateOfBirth);
        DateTime today = DateTime.Today;
        int age = today.Year - dob.Year;
        if (dob > today.AddYears(-age)) age--;

        return age;
    }

    public static double GetEatoutAverageMoviePercentage(LinkedList<SurveyDTO> list)
    {
        int totalSurveyed = list.Count;
        int totalStronglyAgreeAndAgree = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.EatOut;
            if (RateEnum.STRONGLY_AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase) ||
                RateEnum.AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalStronglyAgreeAndAgree++;
            }
        }

        return (double)totalStronglyAgreeAndAgree / totalSurveyed * 100;
    }

    public static double GetTvPercentageOfStronglyAgreeAndAgreeIn(LinkedList<SurveyDTO> list)
    {
        int totalSurveyed = list.Count;
        int totalStronglyAgreeAndAgree = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.WatchTV;
            if (RateEnum.STRONGLY_AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase) ||
                RateEnum.AGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalStronglyAgreeAndAgree++;
            }
        }

        return (double)totalStronglyAgreeAndAgree / totalSurveyed * 100;
    }

    public static double GetPercentageOfFoodLovers(LinkedList<SurveyDTO> list, string food)
    {
        int totalSurveyed = list.Count;
        int totalFoodLovers = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.FavouriteFood;
            if (food.Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalFoodLovers++;
            }
        }

        return (double)totalFoodLovers / totalSurveyed * 100;
    }

    public static double GetPercentageOfNeutral(LinkedList<SurveyDTO> list)
    {
        int totalSurveyed = list.Count;
        int totalNeutral = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.LikeMovies;
            if (RateEnum.NEUTRAL.ToString().Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalNeutral++;
            }
        }

        return (double)totalNeutral / totalSurveyed * 100;
    }

    public static double GetPercentageOfStronglyDisagreeAndDisagree(LinkedList<SurveyDTO> list)
    {
        int totalSurveyed = list.Count;
        int totalStronglyDisagreeAndDisagree = 0;

        foreach (SurveyDTO survey in list)
        {
            string response = survey.LikeMovies;
            if (RateEnum.STRONGLY_DISAGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase) ||
                RateEnum.DISAGREE.ToString().Equals(response, StringComparison.OrdinalIgnoreCase))
            {
                totalStronglyDisagreeAndDisagree++;
            }
        }

        return (double)totalStronglyDisagreeAndDisagree / totalSurveyed * 100;
    }
}