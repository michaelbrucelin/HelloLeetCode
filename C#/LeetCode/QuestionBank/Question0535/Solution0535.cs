using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0535
{
    public class Solution0535
    {
    }

    public class Codec : Interface0535
    {
        static Codec()
        {
            enmap = new Dictionary<string, string>();
            demap = new Dictionary<string, string>();
        }

        private static Dictionary<string, string> enmap, demap;

        public string encode(string longUrl)
        {
            if (enmap.ContainsKey(longUrl)) return enmap[longUrl];
            string shortUrl = Guid.NewGuid().ToString();
            enmap.Add(longUrl, shortUrl);
            demap.Add(shortUrl, longUrl);
            return shortUrl;
        }

        public string decode(string shortUrl)
        {
            return demap[shortUrl];
        }
    }
}
