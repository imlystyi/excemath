using System.Collections.ObjectModel;

namespace excemath.Models;

public class RatingsList
{
    public RatingsList()
    {
        var list = Task.Run(ApiClient.GetRatingList).Result;
        collection = new(list);
    }

    public List<UserRating> collection;
}
