using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0981
{
    /// <summary>
    /// Your TimeMap object will be instantiated and called as such:
    /// TimeMap obj = new TimeMap();
    /// obj.Set(key,value,timestamp);
    /// string param_2 = obj.Get(key,timestamp);
    /// </summary>
    public interface Interface0981
    {
        // public TimeMap(){ }

        public void Set(string key, string value, int timestamp);

        public string Get(string key, int timestamp);
    }
}
