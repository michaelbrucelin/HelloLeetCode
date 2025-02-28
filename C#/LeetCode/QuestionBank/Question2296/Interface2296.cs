using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2296
{
    /// <summary>
    /// Your TextEditor object will be instantiated and called as such:
    /// TextEditor obj = new TextEditor();
    /// obj.AddText(text);
    /// int param_2 = obj.DeleteText(k);
    /// string param_3 = obj.CursorLeft(k);
    /// string param_4 = obj.CursorRight(k);
    /// </summary>
    public interface Interface2296
    {
        // public TextEditor() { }

        public void AddText(string text);

        public int DeleteText(int k);

        public string CursorLeft(int k);

        public string CursorRight(int k);
    }
}
