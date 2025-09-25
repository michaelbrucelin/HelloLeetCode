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
    /// 
    /// 逻辑没问题，TLE，推测是因为Search与Report时，需要出队列再进队列导致的，可以改为SortedDictionary试试
    /// 再次提交通过了...，不写了，官解用的就是SortedDictionary，由于Search与Report的数量是5，直接上堆+懒删除效率不比有序Hash慢
    /// </summary>
    public class MovieRentingSystem : Interface1912
    {
        public MovieRentingSystem(int n, int[][] entries)
        {
            count = 5;
            comparer2 = Comparer<(int, int)>.Create((x, y) => (x.Item1 != y.Item1) ? x.Item1 - y.Item1 : x.Item2 - y.Item2);
            comparer3 = Comparer<(int, int, int)>.Create((x, y) => (x.Item1 != y.Item1) ? x.Item1 - y.Item1 : ((x.Item2 != y.Item2) ? x.Item2 - y.Item2 : x.Item3 - y.Item3));
            have = new Dictionary<int, PriorityQueue<int, (int price, int shop)>>();
            rent = new PriorityQueue<(int shop, int movie), (int price, int shop, int moive)>(comparer3);
            _rent = new HashSet<(int shop, int moive)>();
            _have = new HashSet<(int shop, int moive)>();
            price = new Dictionary<(int shop, int moive), int>();

            foreach (int[] entry in entries)
            {
                if (have.TryGetValue(entry[1], out var shops))
                    shops.Enqueue(entry[0], (entry[2], entry[0]));
                else
                    have.Add(entry[1], new PriorityQueue<int, (int, int)>([(entry[0], (entry[2], entry[0]))], comparer2));
                _have.Add((entry[0], entry[1]));
                price.Add((entry[0], entry[1]), entry[2]);
            }
        }

        private int count;
        private Comparer<(int, int)> comparer2;
        private Comparer<(int, int, int)> comparer3;
        private Dictionary<int, PriorityQueue<int, (int, int)>> have;
        private PriorityQueue<(int, int), (int, int, int)> rent;
        private HashSet<(int, int)> _have, _rent;
        private Dictionary<(int, int), int> price;

        public void Drop(int shop, int movie)
        {
            int _price = price[(shop, movie)];
            _rent.Remove((shop, movie));
            _have.Add((shop, movie));
            if (have.TryGetValue(movie, out var shops))
                shops.Enqueue(shop, (_price, shop));
            else
                have.Add(movie, new PriorityQueue<int, (int, int)>([(shop, (_price, shop))], comparer2));
        }

        public void Rent(int shop, int movie)
        {
            int _price = price[(shop, movie)];
            _have.Remove((shop, movie));
            _rent.Add((shop, movie));
            rent.Enqueue((shop, movie), (_price, shop, movie));
        }

        public IList<IList<int>> Report()
        {
            List<IList<int>> result = new List<IList<int>>();
            while (result.Count < count && rent.Count > 0)
            {
                (int shop, int movie) item = rent.Dequeue();
                while (rent.Count > 0 && rent.Peek() == item) rent.Dequeue();
                if (_rent.Contains(item)) result.Add([item.shop, item.movie]);
            }
            foreach (var item in result) rent.Enqueue((item[0], item[1]), (price[(item[0], item[1])], item[0], item[1]));

            return result;
        }

        public IList<int> Search(int movie)
        {
            List<int> result = new List<int>();
            if (!have.TryGetValue(movie, out var shops) || shops.Count == 0) return result;
            int shop;
            while (result.Count < count && shops.Count > 0)
            {
                shop = shops.Dequeue();
                while (shops.Count > 0 && shops.Peek() == shop) shops.Dequeue();
                if (_have.Contains((shop, movie))) result.Add(shop);
            }
            foreach (int _shop in result) shops.Enqueue(_shop, (price[(_shop, movie)], _shop));

            return result;
        }
    }
}
