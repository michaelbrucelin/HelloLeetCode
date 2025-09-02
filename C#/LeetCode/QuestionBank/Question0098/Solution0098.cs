using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0098
{
    public class Solution0098 : Interface0098
    {
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            List<int> list = new List<int>();
            dfs(root);
            int cnt = list.Count;
            for (int i = 1; i < cnt; i++) if (list[i] <= list[i - 1]) return false;
            return true;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                list.Add(node.val);
                dfs(node.right);
            }
        }

        /// <summary>
        /// 逻辑与IsValidBST()一样，提前剪枝
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST2(TreeNode root)
        {
            List<long> list = [long.MinValue];
            return dfs(root);

            bool dfs(TreeNode node)
            {
                if (node == null) return true;
                if (!dfs(node.left)) return false;
                if (node.val <= list[^1]) return false; else list.Add(node.val);
                return dfs(node.right);
            }
        }

        /// <summary>
        /// 逻辑同IsValidBST2()，通过抛异常跳出递归，真的很慢
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST3(TreeNode root)
        {
            List<long> list = [long.MinValue];
            try { dfs(root); } catch { return false; }
            return true;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                if (node.val <= list[^1]) goto FALSE; else list.Add(node.val);
                dfs(node.right);
                return;
            FALSE:;
                throw new Exception("break recursion");
            }
        }
        /* 这样是不可以的，所以上面采用了抛异常的处理方式
        public bool IsValidBST3(TreeNode root)
        {
            List<long> list = [long.MinValue];
            dfs(root);
            return true;
        FALSE:;
            return false;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                if (node.val <= list[^1]) goto FALSE; else list.Add(node.val);
                dfs(node.right);
            }
        }
         */

        /// <summary>
        /// 逻辑同IsValidBST3()，将递归改为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST4(TreeNode root)
        {
            List<long> list = [long.MinValue];
            Stack<(TreeNode node, bool flag)> stack = new Stack<(TreeNode node, bool flag)>();
            stack.Push((root, false));
            (TreeNode node, bool flag) item;
            while (stack.Count > 0)
            {
                if ((item = stack.Pop()).node == null) continue;
                if (item.flag)
                {
                    if (item.node.val <= list[^1]) return false; else list.Add(item.node.val);
                }
                else
                {
                    stack.Push((item.node.right, false));
                    stack.Push((item.node, true));
                    stack.Push((item.node.left, false));
                }
            }
            return true;
        }
    }
}
