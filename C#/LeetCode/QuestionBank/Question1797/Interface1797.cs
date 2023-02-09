using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1797
{
    /// <summary>
    /// Your AuthenticationManager object will be instantiated and called as such:
    /// AuthenticationManager obj = new AuthenticationManager(timeToLive);
    /// obj.Generate(tokenId,currentTime);
    /// obj.Renew(tokenId,currentTime);
    /// int param_3 = obj.CountUnexpiredTokens(currentTime);
    /// </summary>
    public interface Interface1797
    {
        public void Generate(string tokenId, int currentTime);

        public void Renew(string tokenId, int currentTime);

        public int CountUnexpiredTokens(int currentTime);
    }
}
