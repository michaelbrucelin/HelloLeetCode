using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2296
{
    public class Solution2296
    {
    }

    public class TextEditor : Interface2296
    {
        public TextEditor()
        {
            editor = new LinkedList<char>();
            editor.AddLast(NULLCHAR);
            cursor = editor.First;
        }

        private const char NULLCHAR = '\0';
        private LinkedList<char> editor;
        private LinkedListNode<char> cursor;

        public void AddText(string text)
        {
            foreach (char c in text)
            {
                editor.AddAfter(cursor, c);
                cursor = cursor.Next;
            }
        }

        public int DeleteText(int k)
        {
            int cnt = 0;
            LinkedListNode<char> p = cursor.Previous;
            for (int i = 0; i < k && p != null; i++, p = p.Previous)
            {
                if (p.Value != NULLCHAR) { editor.Remove(p); cnt++; } else break;
            }

            return cnt;
        }

        public string CursorLeft(int k)
        {
            for (int i = 0; i < 10 && cursor.Previous != null; i++) cursor = cursor.Previous;
            List<char> buffer = new List<char>();
            LinkedListNode<char> p = cursor.Previous;
            for (int i = 0; i < 10 && p != null; i++, p = p.Previous)
            {
                if (p.Value != NULLCHAR) buffer.Add(p.Value); else break;
            }

            buffer.Reverse();
            return new string([.. buffer]);
        }

        public string CursorRight(int k)
        {
            for (int i = 0; i < 10 && cursor.Next != null; i++) cursor = cursor.Next;
            List<char> buffer = new List<char>();
            LinkedListNode<char> p = cursor.Previous;
            for (int i = 0; i < 10 && p != null; i++, p = p.Previous)
            {
                if (p.Value != NULLCHAR) buffer.Add(p.Value); else break;
            }

            buffer.Reverse();
            return new string([.. buffer]);
        }
    }
}
