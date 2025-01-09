using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0729
{
    public class Solution0729_4
    {
    }

    public class MyCalendar_4 : Interface0729
    {
        /// <summary>
        /// 线段树
        /// </summary>
        public MyCalendar_4()
        {
            LEFT = 0;
            RIGHT = (int)1e9;
            tree = new Dictionary<int, int[]>();
        }

        private int LEFT;
        private int RIGHT;
        private Dictionary<int, int[]> tree;  // value[0]: max, value[1]: lazy

        public bool Book(int startTime, int endTime)
        {
            Update(startTime, endTime - 1, 1, LEFT, RIGHT, 1);

            if (tree[1][0] < 2) return true;
            Update(startTime, endTime - 1, -1, LEFT, RIGHT, 1);
            return false;
        }

        private void Update(int left, int right, int val, int Left, int Right, int idx)
        {
            if (!tree.ContainsKey(idx)) tree.Add(idx, new int[2]);
            if (left <= Left && right >= Right)
            {
                tree[idx][0] += val;
                tree[idx][1] += val;
                return;
            }

            int mid = Left + ((Right - Left) >> 1), lchild = 0, rchild = 0;
            if (tree[idx][1] > 0)
            {
                Update(Left, Right, tree[idx][1], Left, mid, idx << 1);
                Update(Left, Right, tree[idx][1], mid + 1, Right, idx << 1 | 1);
                tree[idx][1] = 0;
            }
            if (left <= mid) Update(left, right, val, Left, mid, idx << 1);
            if (right > mid) Update(left, right, val, mid + 1, Right, idx << 1 | 1);

            if (tree.ContainsKey(idx << 1)) lchild = tree[idx << 1][0];
            if (tree.ContainsKey(idx << 1 | 1)) rchild = tree[idx << 1 | 1][0];

            tree[idx][0] = Math.Max(lchild, rchild);
        }
    }
}
