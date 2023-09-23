using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1993
{
    public class Solution1993
    {
    }

    /// <summary>
    /// 模拟
    /// 1. 找祖先节点，利用已知的parent数组即可
    /// 2. 找子孙节点，预处理一棵树，使用List<int>[]即可
    /// 3. 记录锁状态，使用一个整型数组，记录每个节点具体被哪个用户锁定的，0表示未被锁定
    /// </summary>
    public class LockingTree : Interface1993
    {
        public LockingTree(int[] parent)
        {
            int len = parent.Length;
            this.parent = parent;
            state = new int[len];
            child = new List<int>[len];
            for (int i = 0; i < len; i++) child[i] = new List<int>();
            for (int i = 0; i < len; i++) if (parent[i] != -1) child[parent[i]].Add(i);
        }

        private int[] parent;
        private List<int>[] child;
        private int[] state;

        public bool Lock(int num, int user)
        {
            if (state[num] > 0) return false;
            state[num] = user;
            return true;
        }

        public bool Unlock(int num, int user)
        {
            if (state[num] == user)
            {
                state[num] = 0; return true;
            }
            return false;
        }

        public bool Upgrade(int num, int user)
        {
            if (state[num] > 0) return false;

            // 祖先节点
            int id = num;
            while (parent[id] != -1)
            {
                id = parent[id];
                if (state[id] > 0) return false;
            }

            // 子孙节点
            bool flag = false;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(num);
            while (queue.Count > 0)
            {
                id = queue.Dequeue();
                if (state[id] > 0)
                {
                    state[id] = 0; flag = true;
                }
                foreach (int _id in child[id]) queue.Enqueue(_id);
            }
            if (flag) state[num] = user;

            return flag;
        }
    }
}
