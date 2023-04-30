using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1616
{
    public class Solution1616_2 : Interface1616
    {
        /// <summary>
        /// 与Solution1616一样
        /// 不过Solution1616是种中间向两边扩散，而这里是从两边向中间逼近
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckPalindromeFormation(string a, string b)
        {
            if (a.Length == 1) return true;

            int len = a.Length;
            // 验证a是否回文
            int ptr_l = 0, ptr_r = len - 1;
            while (ptr_l < ptr_r && a[ptr_l] == a[ptr_r]) { ptr_l++; ptr_r--; }
            if (ptr_l >= ptr_r) return true;
            // 验证a的前缀+b的后缀是否回文
            ptr_l = 0; ptr_r = len - 1;
            while (ptr_l < ptr_r && a[ptr_l] == b[ptr_r]) { ptr_l++; ptr_r--; }
            if (ptr_l >= ptr_r) return true;
            // // 验证a中间的字串是否回文
            int _ptr_l = ptr_l, _ptr_r = ptr_r;
            while (_ptr_l < _ptr_r && a[_ptr_l] == a[_ptr_r]) { _ptr_l++; _ptr_r--; }
            if (_ptr_l >= _ptr_r) return true;
            // // 验证b中间的字串是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l < _ptr_r && b[_ptr_l] == b[_ptr_r]) { _ptr_l++; _ptr_r--; }
            if (_ptr_l >= _ptr_r) return true;

            // 验证b是否回文
            ptr_l = 0; ptr_r = len - 1;
            while (ptr_l < ptr_r && b[ptr_l] == b[ptr_r]) { ptr_l++; ptr_r--; }
            if (ptr_l >= ptr_r) return true;
            // 验证b的前缀+a的后缀是否回文
            ptr_l = 0; ptr_r = len - 1;
            while (ptr_l < ptr_r && b[ptr_l] == a[ptr_r]) { ptr_l++; ptr_r--; }
            if (ptr_l >= ptr_r) return true;
            // // 验证b中间的字串是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l < _ptr_r && b[_ptr_l] == b[_ptr_r]) { _ptr_l++; _ptr_r--; }
            if (_ptr_l >= _ptr_r) return true;
            // // 验证a中间的字串是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l < _ptr_r && a[_ptr_l] == a[_ptr_r]) { _ptr_l++; _ptr_r--; }
            if (_ptr_l >= _ptr_r) return true;

            return false;
        }

        /// <summary>
        /// 与CheckPalindromeFormation()一样，使用编码的手段精简代码
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckPalindromeFormation2(string a, string b)
        {
            if (a.Length == 1) return true;

            return _CheckPalindromeFormation2(a, b) || _CheckPalindromeFormation2(b, a);
        }

        private bool _CheckPalindromeFormation2(string a, string b)
        {
            int len = a.Length;
            // 验证a是否回文
            int ptr_l = 0, ptr_r = len - 1;
            while (ptr_l < ptr_r && a[ptr_l] == a[ptr_r]) { ptr_l++; ptr_r--; }
            if (ptr_l >= ptr_r) return true;
            // 验证a的前缀+b的后缀是否回文
            ptr_l = 0; ptr_r = len - 1;
            while (ptr_l < ptr_r && a[ptr_l] == b[ptr_r]) { ptr_l++; ptr_r--; }
            if (ptr_l >= ptr_r) return true;
            // // 验证a中间的字串是否回文
            int _ptr_l = ptr_l, _ptr_r = ptr_r;
            while (_ptr_l < _ptr_r && a[_ptr_l] == a[_ptr_r]) { _ptr_l++; _ptr_r--; }
            if (_ptr_l >= _ptr_r) return true;
            // // 验证b中间的字串是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l < _ptr_r && b[_ptr_l] == b[_ptr_r]) { _ptr_l++; _ptr_r--; }
            if (_ptr_l >= _ptr_r) return true;

            return false;
        }
    }
}
