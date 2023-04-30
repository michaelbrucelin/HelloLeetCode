using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1797
{
    public class Solution1797
    {
    }

    public class AuthenticationManager : Interface1797
    {
        public AuthenticationManager(int timeToLive)
        {
            tokens = new Dictionary<string, int>();
            ttl = timeToLive;
        }

        private Dictionary<string, int> tokens;
        private int ttl;

        public int CountUnexpiredTokens(int currentTime)
        {
            int count = 0;
            foreach (string key in tokens.Keys)
                if (tokens[key] > currentTime) count++; else tokens.Remove(key);

            return count;
        }

        public void Generate(string tokenId, int currentTime)
        {
            tokens.Add(tokenId, currentTime + ttl);  // 题目保证：所有generate函数的调用都会包含独一无二的tokenId值。
        }

        public void Renew(string tokenId, int currentTime)
        {
            if (tokens.ContainsKey(tokenId))
            {
                if (tokens[tokenId] > currentTime)
                    tokens[tokenId] = currentTime + ttl;
                else
                    tokens.Remove(tokenId);
            }
        }
    }
}
