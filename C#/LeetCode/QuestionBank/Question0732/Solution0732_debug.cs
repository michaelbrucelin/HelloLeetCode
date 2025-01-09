using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0732
{
    public class Solution0732_debug
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class MyCalendarThree_debug : Interface0732
    {
        public MyCalendarThree_debug()
        {
            LEFT = 0;
            // RIGHT = (int)1e9;
            RIGHT = 60;
            tree = new Dictionary<long, long[]>();
        }

        private int LEFT;
        private int RIGHT;
        private Dictionary<long, long[]> tree;

        public int Book(int startTime, int endTime)
        {
            Update(startTime, endTime - 1, 1, LEFT, RIGHT, 1);

            // return Query(startTime, endTime - 1, LEFT, RIGHT, 1);
            return (int)tree[1][0];
        }

        private void Update(int left, int right, int val, int Left, int Right, long idx)
        {
            if (!tree.ContainsKey(idx)) tree.Add(idx, [0, Left, Right]);
            if (Left == Right)  // if (left <= Left && right >= Right)
            {
                tree[idx][0] += val; return;
            }

            int mid = Left + ((Right - Left) >> 1), lchild = 0, rchild = 0;
            if (left <= mid) Update(left, right, val, Left, mid, idx << 1);
            if (right > mid) Update(left, right, val, mid + 1, Right, idx << 1 | 1);
            lchild = tree.ContainsKey(idx << 1) ? (int)tree[idx << 1][0] : 0;
            rchild = tree.ContainsKey(idx << 1 | 1) ? (int)tree[idx << 1 | 1][0] : 0;
            tree[idx][0] = Math.Max(lchild, rchild);
        }

        private int Query(int left, int right, int Left, int Right, long idx)
        {
            if (!tree.ContainsKey(idx)) return 0;
            if (left <= Left && right >= Right) return (int)tree[idx][0];

            int mid = Left + ((Right - Left) >> 1), lchild = 0, rchild = 0;
            if (left <= mid) lchild = Query(left, right, Left, mid, idx << 1);
            if (right > mid) rchild = Query(left, right, mid + 1, Right, idx << 1 | 1);

            return Math.Max(lchild, rchild);
        }
    }
}
