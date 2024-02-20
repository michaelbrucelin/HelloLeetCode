using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0105
{
    public static class Utils0105
    {
        public static bool TreeCompare(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            if (t1.val != t2.val) return false;
            if (!TreeCompare(t1.left, t2.left)) return false;
            return TreeCompare(t1.right, t2.right);
        }

        public static List<int> LevelOrder(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; bool flag; TreeNode node;
            while ((cnt = queue.Count) > 0)
            {
                flag = true;
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    if (node != null)
                    {
                        result.Add(node.val);
                        queue.Enqueue(node.left); queue.Enqueue(node.right);
                        if (node.left != null || node.right != null) flag = false;
                    }
                    else
                    {
                        result.Add(int.MinValue);  // 使用int.MinValue代替null，题目限定了node.val 在 [-3000, 3000] 之间
                        queue.Enqueue(null); queue.Enqueue(null);
                    }
                }
                if (flag) break;
            }

            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i] != int.MinValue) break;
                result.RemoveAt(i);
            }

            return result;
        }
    }
}
