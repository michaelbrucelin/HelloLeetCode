using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1616
{
    public class Solution1616 : Interface1616
    {
        /// <summary>
        /// 双指针
        /// 具体分析见Solution1616.md
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckPalindromeFormation(string a, string b)
        {
            if (a.Length == 1) return true;

            int len = a.Length;
            // 找出a从中间起最长的回文子串
            int ptr_l = (len - 1) >> 1, ptr_r = len >> 1;
            while (ptr_l >= 0 && a[ptr_l] == a[ptr_r]) { ptr_l--; ptr_r++; }
            if (ptr_l == -1) return true;
            // 验证a的前缀与b的后缀是否回文
            int _ptr_l = ptr_l, _ptr_r = ptr_r;
            while (_ptr_l >= 0 && a[_ptr_l] == b[_ptr_r]) { _ptr_l--; _ptr_r++; }
            if (_ptr_l == -1) return true;
            // 验证a的后缀与b的前缀是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l >= 0 && b[_ptr_l] == a[_ptr_r]) { _ptr_l--; _ptr_r++; }
            if (_ptr_l == -1) return true;

            // 找出b从中间起最长的回文子串
            ptr_l = (len - 1) >> 1; ptr_r = len >> 1;
            while (ptr_l >= 0 && b[ptr_l] == b[ptr_r]) { ptr_l--; ptr_r++; }
            if (ptr_l == -1) return true;
            // 验证b的前缀与a的后缀是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l >= 0 && b[_ptr_l] == a[_ptr_r]) { _ptr_l--; _ptr_r++; }
            if (_ptr_l == -1) return true;
            // 验证b的后缀与a的前缀是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l >= 0 && a[_ptr_l] == b[_ptr_r]) { _ptr_l--; _ptr_r++; }
            if (_ptr_l == -1) return true;

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
            // 找出a从中间起最长的回文子串
            int ptr_l = (len - 1) >> 1, ptr_r = len >> 1;
            while (ptr_l >= 0 && a[ptr_l] == a[ptr_r]) { ptr_l--; ptr_r++; }
            if (ptr_l == -1) return true;
            // 验证a的前缀与b的后缀是否回文
            int _ptr_l = ptr_l, _ptr_r = ptr_r;
            while (_ptr_l >= 0 && a[_ptr_l] == b[_ptr_r]) { _ptr_l--; _ptr_r++; }
            if (_ptr_l == -1) return true;
            // 验证a的后缀与b的前缀是否回文
            _ptr_l = ptr_l; _ptr_r = ptr_r;
            while (_ptr_l >= 0 && b[_ptr_l] == a[_ptr_r]) { _ptr_l--; _ptr_r++; }
            if (_ptr_l == -1) return true;

            return false;
        }

        /// <summary>
        /// 与CheckPalindromeFormation()一样，使用编码的手段精简代码
        /// 貌似也没精简多少，就算是封装吧
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CheckPalindromeFormation3(string a, string b)
        {
            if (a.Length == 1) return true;

            int len = a.Length; (bool ifis, int ptr_l, int ptr_r) info, _info;
            // 找出a从中间起最长的回文子串
            int ptr_l = (len - 1) >> 1, ptr_r = len >> 1;
            info = _CheckPalindromeFormation3(a, a, ptr_l, ptr_r);
            if (info.ifis) return true;
            // 验证a的前缀与b的后缀是否回文
            _info = _CheckPalindromeFormation3(a, b, info.ptr_l, info.ptr_r);
            if (_info.ifis) return true;
            // 验证a的后缀与b的前缀是否回文
            _info = _CheckPalindromeFormation3(b, a, info.ptr_l, info.ptr_r);
            if (_info.ifis) return true;

            // 找出b从中间起最长的回文子串
            ptr_l = (len - 1) >> 1; ptr_r = len >> 1;
            info = _CheckPalindromeFormation3(b, b, ptr_l, ptr_r);
            if (info.ifis) return true;
            // 验证b的前缀与a的后缀是否回文
            _info = _CheckPalindromeFormation3(b, a, info.ptr_l, info.ptr_r);
            if (_info.ifis) return true;
            // 验证b的后缀与a的前缀是否回文
            _info = _CheckPalindromeFormation3(a, b, info.ptr_l, info.ptr_r);
            if (_info.ifis) return true;

            return false;
        }

        private (bool ifis, int ptr_l, int ptr_r) _CheckPalindromeFormation3(string str_l, string str_r, int ptr_l, int ptr_r)
        {
            while (ptr_l >= 0 && str_l[ptr_l] == str_r[ptr_r]) { ptr_l--; ptr_r++; }

            return ptr_l != -1 ? (false, ptr_l, ptr_r) : (true, int.MinValue, int.MaxValue);
        }
    }
}
