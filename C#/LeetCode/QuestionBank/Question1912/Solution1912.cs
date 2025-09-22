using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1912
{
    public class Solution1912
    {
    }

    /// <summary>
    /// 堆，懒删除
    /// </summary>
    public class MovieRentingSystem : Interface1912
    {
        public MovieRentingSystem(int n, int[][] entries)
        {
            comparer = Comparer<(int, int)>.Create((x, y) => (x.Item1 != y.Item1) ? x.Item1 - y.Item1 : x.Item2 - y.Item2);
            have = new PriorityQueue<(int shop, int movie), (int, int)>(comparer);
            rent = new PriorityQueue<(int shop, int movie), (int, int)>(comparer);
            _rent = new HashSet<(int shop, int moive)>();
            _have = new HashSet<(int shop, int moive)>();
            price = new Dictionary<(int shop, int moive), int>();

            foreach (int[] entry in entries)
            {
                have.Enqueue((entry[0], entry[1]), (entry[2], entry[0]));
                _have.Add((entry[0], entry[1]));
                price.Add((entry[0], entry[1]), entry[2]);
            }
        }

        Comparer<(int, int)> comparer;
        PriorityQueue<(int, int), (int, int)> have, rent;
        HashSet<(int, int)> _have, _rent;
        Dictionary<(int, int), int> price;

        public void Drop(int shop, int movie)
        {
            _rent.Remove((shop, movie));
            _have.Add((shop, movie));
        }

        public void Rent(int shop, int movie)
        {
            _have.Remove((shop, movie));
            _rent.Add((shop, movie));
        }

        public IList<IList<int>> Report()
        {
            List<IList<int>> result = new List<IList<int>>();
            while (result.Count < 5 && rent.Count > 0)
            {
                (int shop, int movie) item = rent.Dequeue();
                if (_rent.Contains(item)) result.Add([item.shop, item.movie]);
            }

            return result;
        }

        public IList<int> Search(int movie)
        {
            throw new NotImplementedException();
        }
    }
}
