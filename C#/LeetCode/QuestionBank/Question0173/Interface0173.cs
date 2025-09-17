using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0173
{
    /// <summary>
    /// Your BSTIterator object will be instantiated and called as such:
    /// BSTIterator obj = new BSTIterator(root);
    /// int param_1 = obj.Next();
    /// bool param_2 = obj.HasNext();
    /// </summary>
    public interface Interface0173
    {
        // public BSTIterator(TreeNode root){}

        public int Next();

        public bool HasNext();
    }
}
