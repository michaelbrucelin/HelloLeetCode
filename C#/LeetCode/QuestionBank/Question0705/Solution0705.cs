using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0705
{
    public class Solution0705
    {
    }

    /// <summary>
    /// 暴力使用数组
    /// </summary>
    public class MyHashSet : Interface0705
    {
        public MyHashSet()
        {
            arr = new bool[1000001];
        }

        bool[] arr;

        public void Add(int key)
        {
            arr[key] = true;
        }

        public bool Contains(int key)
        {
            return arr[key];
        }

        public void Remove(int key)
        {
            arr[key] = false;
        }
    }
}
