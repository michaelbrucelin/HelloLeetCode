using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0535
{
    /// <summary>
    /// Your Codec object will be instantiated and called as such:
    /// Codec codec = new Codec();
    /// codec.decode(codec.encode(url));
    /// </summary>
    public interface Interface0535
    {
        // Encodes a URL to a shortened URL
        public string encode(string longUrl);

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl);
    }
}
