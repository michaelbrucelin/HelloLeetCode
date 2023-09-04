using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0449
{
    public class Test0449
    {
        public void Test()
        {
            Interface0449 solution = new Codec();
            TreeNode root; string data;

            // 1. 
            root = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) };
            data = solution.serialize(root);
            solution.deserialize(data);
        }
    }
}
