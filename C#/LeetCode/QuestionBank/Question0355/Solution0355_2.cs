using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0355
{
    public class Solution0355_2
    {
    }

    /// <summary>
    /// 逻辑同Solution0355，稍加优化
    /// </summary>
    public class Twitter_2 : Interface0355
    {
        public Twitter_2()
        {
            tweets = new List<(int, DateTime)>[501];
            follows = new HashSet<int>[501];
            minpq = new PriorityQueue<(int, DateTime), DateTime>();
        }

        private List<(int, DateTime)>[] tweets;
        private HashSet<int>[] follows;
        private PriorityQueue<(int, DateTime), DateTime> minpq;

        public void PostTweet(int userId, int tweetId)
        {
            if (tweets[userId] == null) tweets[userId] = new List<(int, DateTime)>();
            tweets[userId].Add((tweetId, DateTime.Now));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            minpq.Clear();
            List<(int, DateTime)> _tweets = tweets[userId];
            if (_tweets != null) for (int i = _tweets.Count - 1, j = 9; i >= 0 && j >= 0; i--, j--) minpq.Enqueue((_tweets[i].Item1, _tweets[i].Item2), _tweets[i].Item2);
            if (follows[userId] != null) foreach (int followeeId in follows[userId])
                {
                    _tweets = tweets[followeeId];
                    if (_tweets != null) for (int i = _tweets.Count - 1, j = 9; i >= 0 && j >= 0; i--, j--)
                        {
                            if (minpq.Count == 10 && _tweets[i].Item2 <= minpq.Peek().Item2) break;
                            minpq.Enqueue((_tweets[i].Item1, _tweets[i].Item2), _tweets[i].Item2);
                            if (minpq.Count > 10) minpq.Dequeue();
                        }
                }

            int cnt = minpq.Count;
            int[] result = new int[cnt];
            for (int i = cnt - 1; i >= 0; i--) result[i] = minpq.Dequeue().Item1;
            return result;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (follows[followerId] == null) follows[followerId] = new HashSet<int>();
            follows[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (follows[followerId] != null) follows[followerId].Remove(followeeId);
        }
    }
}
