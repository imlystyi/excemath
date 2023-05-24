using System.Collections.ObjectModel;

namespace excemath.Models;

public class RatingCollection
{
    public RatingCollection()
    {
        LoadRatings();
    }

    public ObservableCollection<UserRating> Ratings { get; } = new();

    private void LoadRatings()
    {
        var list = Task.Run(ApiClient.GetRatingList).Result;
        list.ForEach(Ratings.Add);
    }
}
