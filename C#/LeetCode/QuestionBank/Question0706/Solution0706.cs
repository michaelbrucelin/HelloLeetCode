using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0706
{
    public class Solution0706
    {
    }

    /// <summary>
    /// 暴力使用数组
    /// </summary>
    public class MyHashMap : Interface0706
    {
        public MyHashMap()
        {
            arr = new int[1000001];
            for (int i = 0; i < arr.Length; i++) arr[i] = -1;
        }

        private int[] arr;

        public int Get(int key)
        {
            return arr[key];
        }

        public void Put(int key, int value)
        {
            arr[key] = value;
        }

        public void Remove(int key)
        {
            arr[key] = -1;
        }
    }
}
