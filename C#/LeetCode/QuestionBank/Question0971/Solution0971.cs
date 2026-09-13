using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0971
{
    public class Solution0971 : Interface0971
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <param name="voyage"></param>
        /// <returns></returns>
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            if (root.val != voyage[0]) return [-1];

            List<int> result = [];
            if (!rec(root, voyage, 0, voyage.Length - 1, result)) return [-1];
            return result;

            static bool rec(TreeNode node, int[] voyage, int left, int right, List<int> result)
            {
                if (node.val != voyage[left]) return false;
                switch ((node.left, node.right))
                {
                    case (null, null): return left == right;
                    case (_, null): return rec(node.left, voyage, left + 1, right, result);
                    case (null, _): return rec(node.right, voyage, left + 1, right, result);
                    case (_, _):
                        if (right < left + 2) return false;
                        if (voyage[left + 1] != node.left.val && voyage[left + 1] != node.right.val) return false;
                        if (voyage[left + 1] == node.left.val)
                        {
                            int _left = left + 2;
                            while (_left <= right && voyage[_left] != node.right.val) _left++;
                            if (_left > right) return false;
                            return rec(node.left, voyage, left + 1, _left - 1, result) && rec(node.right, voyage, _left, right, result);
                        }
                        else  // if (voyage[left + 1] == node.right.val)
                        {
                            result.Add(node.val);
                            int _left = left + 2;
                            while (_left <= right && voyage[_left] != node.left.val) _left++;
                            if (_left > right) return false;
                            return rec(node.right, voyage, left + 1, _left - 1, result) && rec(node.left, voyage, _left, right, result);
                        }
                }
            }
        }
    }
}
