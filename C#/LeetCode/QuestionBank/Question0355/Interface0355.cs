using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0355
{
    /// <summary>
    /// Your Twitter object will be instantiated and called as such:
    /// Twitter obj = new Twitter();
    /// obj.PostTweet(userId,tweetId);
    /// IList<int> param_2 = obj.GetNewsFeed(userId);
    /// obj.Follow(followerId,followeeId);
    /// obj.Unfollow(followerId,followeeId);
    /// </summary>
    public interface Interface0355
    {
        // public Twitter(){ }

        public void PostTweet(int userId, int tweetId);

        public IList<int> GetNewsFeed(int userId);

        public void Follow(int followerId, int followeeId);

        public void Unfollow(int followerId, int followeeId);
    }
}
