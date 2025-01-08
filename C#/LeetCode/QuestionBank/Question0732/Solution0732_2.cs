using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0732
{
    public class Solution0732_2
    {
    }

    /// <summary>
    /// 线段树，动态开点 + 延迟修改
    /// </summary>
    public class MyCalendarThree_2 : Interface0732
    {
        public MyCalendarThree_2()
        {
            LEFT = 0;
            RIGHT = (int)1e9;
            tree = new Dictionary<long, int[]>();
        }

        private int LEFT;
        private int RIGHT;
        private Dictionary<long, int[]> tree;  // value[0] max, value[1] lazy


        public int Book(int startTime, int endTime)
        {
            Update(startTime, endTime - 1, 1, LEFT, RIGHT, 1);

            return tree[1][0];
        }

        private void Update(int left, int right, int val, int Left, int Right, long idx)
        {
            if (!tree.ContainsKey(idx)) tree.Add(idx, new int[2]);
            if (left <= Left && right >= Right)
            {
                tree[idx][0] += val;
                tree[idx][1] += val;
                return;
            }

            int mid = Left + (Right - Left) / 2;
            if (tree[idx][1] > 0)
            {
                Update(Left, Right, tree[idx][1], Left, mid, idx << 1);
                Update(Left, Right, tree[idx][1], mid + 1, Right, idx << 1 | 1);
                tree[idx][1] = 0;
            }

            if (left <= mid) Update(left, right, val, Left, mid, idx << 1);
            if (right > mid) Update(left, right, val, mid + 1, Right, idx << 1 | 1);
            int lchild = tree.ContainsKey(idx << 1) ? tree[idx << 1][0] : 0;
            int rchild = tree.ContainsKey(idx << 1 | 1) ? tree[idx << 1 | 1][0] : 0;

            tree[idx][0] = Math.Max(lchild, rchild);
        }
    }
}
