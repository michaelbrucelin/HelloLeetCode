using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2353
{
    /// <summary>
    /// Your FoodRatings object will be instantiated and called as such:
    /// FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
    /// obj.ChangeRating(food,newRating);
    /// string param_2 = obj.HighestRated(cuisine);
    /// </summary>
    public interface Interface2353
    {
        // public FoodRatings(string[] foods, string[] cuisines, int[] ratings) { }

        public void ChangeRating(string food, int newRating);

        public string HighestRated(string cuisine);
    }
}
