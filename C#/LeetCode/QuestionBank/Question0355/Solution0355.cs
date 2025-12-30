using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0355
{
    public class Solution0355
    {
    }

    /// <summary>
    /// 每个用户用独立的List记录每一条推文及其时间，自然就是按时间有序的
    /// 用容量为10的小顶堆实现GetNewsFeed()
    /// </summary>
    public class Twitter : Interface0355
    {
        public Twitter()
        {
            tweets = new List<(int, DateTime)>[501];
            follows = new HashSet<int>[501];
            minpq = new PriorityQueue<int, DateTime>();
        }

        private List<(int, DateTime)>[] tweets;
        private HashSet<int>[] follows;
        private PriorityQueue<int, DateTime> minpq;

        public void PostTweet(int userId, int tweetId)
        {
            if (tweets[userId] == null) tweets[userId] = new List<(int, DateTime)>();
            tweets[userId].Add((tweetId, DateTime.Now));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            minpq.Clear();
            List<(int, DateTime)> _tweets = tweets[userId];
            if (_tweets != null) for (int i = _tweets.Count - 1, j = 9; i >= 0 && j >= 0; i--, j--) minpq.Enqueue(_tweets[i].Item1, _tweets[i].Item2);
            if (follows[userId] != null) foreach (int followeeId in follows[userId])
                {
                    _tweets = tweets[followeeId];
                    if (_tweets != null) for (int i = _tweets.Count - 1, j = 9; i >= 0 && j >= 0; i--, j--)
                        {
                            minpq.Enqueue(_tweets[i].Item1, _tweets[i].Item2);
                            if (minpq.Count > 10) minpq.Dequeue();
                        }
                }

            int cnt = minpq.Count;
            int[] result = new int[cnt];
            for (int i = cnt - 1; i >= 0; i--) result[i] = minpq.Dequeue();
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
