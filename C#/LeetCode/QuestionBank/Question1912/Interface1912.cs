using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1912
{
    /// <summary>
    /// Your MovieRentingSystem object will be instantiated and called as such:
    /// MovieRentingSystem obj = new MovieRentingSystem(n, entries);
    /// IList<int> param_1 = obj.Search(movie);
    /// obj.Rent(shop,movie);
    /// obj.Drop(shop,movie);
    /// IList<IList<int>> param_4 = obj.Report();
    /// </summary>
    public interface Interface1912
    {
        // public MovieRentingSystem(int n, int[][] entries){}

        public IList<int> Search(int movie);

        public void Rent(int shop, int movie);

        public void Drop(int shop, int movie);

        public IList<IList<int>> Report();
    }
}
