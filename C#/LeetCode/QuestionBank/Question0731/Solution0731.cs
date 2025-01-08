using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0731
{
    public class Solution0731
    {
    }

    public class MyCalendarTwo : Interface0731
    {
        public MyCalendarTwo()
        {
            tree = new Dictionary<long, int[]>();
            LEFT = 0;
            RIGHT = (int)1e9;
        }

        private Dictionary<long, int[]> tree;  // value[0] max, value[1] lazy
        private int LEFT;
        private int RIGHT;

        public bool Book(int startTime, int endTime)
        {
            Update(startTime, endTime - 1, 1, LEFT, RIGHT, 1);

            // if (Query(startTime, endTime - 1, LEFT, RIGHT, 1) < 3) return true;
            if (tree[1][0] < 3) return true;
            Update(startTime, endTime - 1, -1, LEFT, RIGHT, 1);
            return false;
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

            int mid = Left + (Right - Left) / 2, lchild = 0, rchild = 0;
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

        private int Query(int left, int right, int Left, int Right, long idx)
        {
            if (!tree.ContainsKey(idx)) return 0;
            if (left <= Left && right >= Right) return tree[idx][0];

            int mid = Left + (Right - Left) / 2, lchild = 0, rchild = 0;
            if (tree[idx][1] > 0)
            {
                Update(Left, Right, tree[idx][1], Left, mid, idx << 1);
                Update(Left, Right, tree[idx][1], mid + 1, Right, idx << 1 | 1);
                tree[idx][1] = 0;
            }
            if (left <= mid) lchild = Query(left, right, Left, mid, idx << 1);
            if (right > mid) rchild = Query(left, right, mid + 1, Right, idx << 1 | 1);

            return Math.Max(lchild, rchild);
        }
    }
}
