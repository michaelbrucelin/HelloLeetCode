using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2641
{
    public class Test2641
    {
        public void Test()
        {
            Interface2641 solution = new Solution2641_2_2();
            TreeNode root;
            TreeNode result, answer;
            int id = 0;

            // 1. 
            root = new TreeNode(5) { left = new TreeNode(4) { left = new TreeNode(1), right = new TreeNode(10) }, right = new TreeNode(9) { right = new TreeNode(7) } };
            answer = new TreeNode(0) { left = new TreeNode(0) { left = new TreeNode(7), right = new TreeNode(7) }, right = new TreeNode(0) { right = new TreeNode(11) } };
            result = solution.ReplaceValueInTree(root);

            // 2. 
            root = new TreeNode(3) { left = new TreeNode(1), right = new TreeNode(2) };
            answer = new TreeNode(0) { left = new TreeNode(0), right = new TreeNode(0) };
            result = solution.ReplaceValueInTree(root);
        }
    }
}
