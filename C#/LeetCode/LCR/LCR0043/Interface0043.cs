using LeetCode.QuestionBank.Question2069;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0043
{
    /// <summary>
    /// Your CBTInserter object will be instantiated and called as such:
    /// CBTInserter obj = new CBTInserter(root);
    /// int param_1 = obj.Insert(v);
    /// TreeNode param_2 = obj.Get_root();
    /// </summary>
    public interface Interface0043
    {
        // public CBTInserter(TreeNode root){ }

        public int Insert(int v);

        public TreeNode Get_root();
    }
}
