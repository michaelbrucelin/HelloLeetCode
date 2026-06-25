using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0981
{
    public class Solution0981
    {
    }

    /// <summary>
    /// Hash列表
    /// </summary>
    public class TimeMap : Interface0981
    {
        public TimeMap()
        {
            map = new Dictionary<int, Dictionary<string, string>>();
        }

        private Dictionary<int, Dictionary<string, string>> map;

        public void Set(string key, string value, int timestamp)
        {
            if (map.TryGetValue(timestamp, out var _map))
            {
                if (_map.ContainsKey(key)) _map[key] = value; else _map.Add(key, value);
            }
            else
            {
                map.Add(timestamp, new Dictionary<string, string>() { { key, value } });
            }
        }

        public string Get(string key, int timestamp)
        {
            throw new NotImplementedException();
        }
    }
}
