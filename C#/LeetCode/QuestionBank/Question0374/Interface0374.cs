using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0374
{
    /// <summary>
    /// Forward declaration of guess API.
    /// @param  num   your guess
    /// @return       -1 if num is higher than the picked number
    ///                1 if num is lower than the picked number
    ///               otherwise return 0
    /// int guess(int num);
    /// 
    /// public class Solution : GuessGame {
    ///     public int GuessNumber(int n) {
    ///         
    ///     }
    /// }
    /// </summary>
    public interface Interface0374
    {
        public int GuessNumber(int n);
    }
}
