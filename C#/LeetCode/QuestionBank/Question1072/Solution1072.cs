using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1072
{
    public class Solution1072 : Interface1072
    {
        /// <summary>
        /// 类DP
        /// 具体分析见Solution1072.md
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            List<List<int>> list = new List<List<int>>();

            list.Add(Enumerable.Range(0, rcnt).ToList());
            for (int i = 1; i < ccnt; i++)
            {
                List<List<int>> _list = new List<List<int>>();
                int _cnt = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    int cnt1 = 0, cnt2 = 0;
                    List<int> list1 = new List<int>(), list2 = new List<int>();
                    for (int k = 0, id; k < list[j].Count; k++)
                    {
                        id = list[j][k];
                        if (matrix[id][i] == matrix[id][0]) { list1.Add(id); cnt1++; }
                        else { list2.Add(id); cnt2++; }
                    }

                    if (cnt1 > cnt2)
                    {
                        if (cnt1 > _cnt)
                        {
                            _cnt = cnt1; _list.Clear(); _list.Add(list1);
                        }
                        else if (cnt1 == _cnt) _list.Add(list1);
                    }
                    else if (cnt2 > cnt1)
                    {
                        if (cnt2 > _cnt)
                        {
                            _cnt = cnt2; _list.Clear(); _list.Add(list2);
                        }
                        else if (cnt2 == _cnt) _list.Add(list2);
                    }
                    else  // if(cnt1 == cnt2)
                    {
                        if (cnt1 > _cnt)
                        {
                            _cnt = cnt1; _list.Clear(); _list.Add(list1); _list.Add(list2);
                        }
                        else if (cnt1 == _cnt)
                        {
                            _list.Add(list1); _list.Add(list2);
                        }
                    }
                }
                if (_cnt == 1) return 1;
                list = _list;
            }

            return list[0].Count;
        }

        /// <summary>
        /// 这段代码是Solution1072的编码，逻辑是错误的
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaxEqualRowsAfterFlips_error(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            List<List<int>> list = new List<List<int>>();

            list.Add(Enumerable.Range(0, rcnt).ToList());
            for (int i = 1; i < ccnt; i++)
            {
                List<List<int>> _list = new List<List<int>>();
                int _cnt = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    int cnt1 = 0, cnt2 = 0;
                    List<int> list1 = new List<int>(), list2 = new List<int>();
                    for (int k = 0, id; k < list[j].Count; k++)
                    {
                        id = list[j][k];
                        if (matrix[id][i] == matrix[id][0]) { list1.Add(id); cnt1++; }
                        else { list2.Add(id); cnt2++; }
                    }

                    if (cnt1 > cnt2)
                    {
                        if (cnt1 > _cnt)
                        {
                            _cnt = cnt1; _list.Clear(); _list.Add(list1);
                        }
                        else if (cnt1 == _cnt) _list.Add(list1);
                    }
                    else if (cnt2 > cnt1)
                    {
                        if (cnt2 > _cnt)
                        {
                            _cnt = cnt2; _list.Clear(); _list.Add(list2);
                        }
                        else if (cnt2 == _cnt) _list.Add(list2);
                    }
                    else  // if(cnt1 == cnt2)
                    {
                        if (cnt1 > _cnt)
                        {
                            _cnt = cnt1; _list.Clear(); _list.Add(list1); _list.Add(list2);
                        }
                        else if (cnt1 == _cnt)
                        {
                            _list.Add(list1); _list.Add(list2);
                        }
                    }
                }
                if (_cnt == 1) return 1;
                list = _list;
            }

            return list[0].Count;
        }
    }
}
