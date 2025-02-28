using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2353
{
    public class Solution2353
    {
    }

    /// <summary>
    /// 对于每一个类别，本质上需要一个可以自定义排序的字典这样的数据结构，但是C#中没有这种数据结构
    /// 所以这里使用一个 大顶堆（延迟删除） + 字典 来实现
    /// </summary>
    public class FoodRatings : Interface2353
    {
        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            rate = new Dictionary<string, int>();
            kind = new Dictionary<string, string>();
            IComparer<(string food, int rate)> comparer = Comparer<(string food, int rate)>.Create((a, b) => a.rate != b.rate ? b.rate - a.rate : a.food.CompareTo(b.food));
            sort = new Dictionary<string, PriorityQueue<(string food, int rate), (string food, int rate)>>();

            for (int i = 0; i < cuisines.Length; i++)
            {
                rate.Add(foods[i], ratings[i]);
                kind.Add(foods[i], cuisines[i]);
                if (!sort.ContainsKey(cuisines[i]))
                {
                    sort.Add(cuisines[i], new PriorityQueue<(string food, int rate), (string food, int rate)>(comparer));
                    sort[cuisines[i]].Enqueue((foods[i], ratings[i]), (foods[i], ratings[i]));
                }
                else
                {
                    sort[cuisines[i]].Enqueue((foods[i], ratings[i]), (foods[i], ratings[i]));
                }
            }
        }

        private Dictionary<string, int> rate;
        private Dictionary<string, string> kind;
        private Dictionary<string, PriorityQueue<(string food, int rate), (string food, int rate)>> sort;

        public void ChangeRating(string food, int newRating)
        {
            rate[food] = newRating;
            sort[kind[food]].Enqueue((food, newRating), (food, newRating));
        }

        public string HighestRated(string cuisine)
        {
            while (true) if (sort[cuisine].Peek().rate != rate[sort[cuisine].Peek().food]) sort[cuisine].Dequeue(); else break;  // 延迟删除
            return sort[cuisine].Peek().food;
        }
    }
}
