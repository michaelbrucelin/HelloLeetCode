using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    public class Solution1825_3
    {
    }

    public class MKAverage_3 : Interface1825
    {
        public MKAverage_3(int m, int k)
        {
            this.m = m;
            this.k = k;
            queue = new Queue<int>();
            s1 = new SortedDictionary<int, int>();
            s2 = new SortedDictionary<int, int>();
            s3 = new SortedDictionary<int, int>();
            cnt1 = 0; cnt2 = 0; cnt3 = 0;
            sum = 0; cnt = m - (k << 1);
        }

        private Queue<int> queue;
        private SortedDictionary<int, int> s1, s2, s3;
        private int cnt1, cnt2, cnt3;
        private long sum;
        private int cnt;
        private int m, k;

        public void AddElement(int num)
        {
            queue.Enqueue(num);
            if (queue.Count <= m)
            {
                AddNum(s2, num, ref cnt2); sum += num;
                if (queue.Count == m)
                {
                    while (cnt1 < k)  // 将s2中前k个元素移到s1中
                    {
                        int _num = s2.First().Key, _cnt = s2.First().Value;
                        if (_cnt <= k - cnt1)
                        {
                            s2.Remove(_num); cnt2 -= _cnt; sum -= _num * _cnt;
                            s1.Add(_num, _cnt); cnt1 += _cnt;
                        }
                        else
                        {
                            s2[_num] -= k - cnt1; cnt2 -= k - cnt1; sum -= _num * (k - cnt1);
                            s1.Add(_num, k - cnt1); cnt1 = k;
                        }
                    }
                    while (cnt3 < k)  // 将s2中后k个元素移到s3中
                    {
                        int _num = s2.Last().Key, _cnt = s2.Last().Value;
                        if (_cnt <= k - cnt3)
                        {
                            s2.Remove(_num); cnt2 -= _cnt; sum -= _num * _cnt;
                            s3.Add(_num, _cnt); cnt3 += _cnt;
                        }
                        else
                        {
                            s2[_num] -= k - cnt3; cnt2 -= k - cnt3; sum -= _num * (k - cnt3);
                            s3.Add(_num, k - cnt3); cnt3 = k;
                        }
                    }
                }
            }
            else
            {
                int num_rm = queue.Dequeue();
                if (num_rm == num) return;

                #region 将num插入s1|s2|s3
                if (num < s1.Last().Key)
                {
                    AddNum(s1, num, ref cnt1);
                }
                else if (num > s3.First().Key)
                {
                    AddNum(s3, num, ref cnt3);
                }
                else
                {
                    AddNum(s2, num, ref cnt2); sum += num;
                }
                #endregion

                #region 将num_rm从s1|s2|s3中移除
                if (s1.ContainsKey(num_rm) && cnt1 > k)
                {
                    RemoveNum(s1, num_rm, ref cnt1);
                }
                else if (s2.ContainsKey(num_rm) && cnt2 > cnt)
                {
                    RemoveNum(s2, num_rm, ref cnt2); sum -= num_rm;
                }
                else if (s3.ContainsKey(num_rm) && cnt3 > k)
                {
                    RemoveNum(s3, num_rm, ref cnt3);
                }
                else if (s1.ContainsKey(num_rm))
                {
                    RemoveNum(s1, num_rm, ref cnt1);
                    int _num = s2.First().Key; MoveNum(s2, s1, _num, ref cnt2, ref cnt1); sum -= _num;  // 将s2中最大的元素移到s1中
                    if (cnt3 > k)
                    {
                        _num = s3.First().Key; MoveNum(s3, s2, _num, ref cnt3, ref cnt2); sum += _num;  // 将s3中最大的元素移到s2中
                    }
                }
                else if (s2.ContainsKey(num_rm))
                {
                    RemoveNum(s2, num_rm, ref cnt2); sum -= num_rm;
                    int _num;
                    if (cnt1 > k)
                    {
                        _num = s1.Last().Key; MoveNum(s1, s2, _num, ref cnt1, ref cnt2); sum += _num;   // 将s1中最大的元素移到s2中
                    }
                    else  // cnt3 > k
                    {
                        _num = s3.First().Key; MoveNum(s3, s2, _num, ref cnt3, ref cnt2); sum += _num;  // 将s3中最大的元素移到s2中
                    }
                }
                else  // s3.ContainsKey(_num)
                {
                    RemoveNum(s3, num_rm, ref cnt3);
                    int _num = s2.Last().Key; MoveNum(s2, s3, _num, ref cnt2, ref cnt3); sum -= _num;   // 将s2中最大的元素移到s3中
                    if (cnt1 > k)
                    {
                        _num = s1.Last().Key; MoveNum(s1, s2, _num, ref cnt1, ref cnt2); sum += _num;   // 将s1中最大的元素移到s2中
                    }
                }
                #endregion
            }
        }

        public int CalculateMKAverage()
        {
            if (queue.Count < m) return -1;

            return (int)(sum / cnt);
        }

        private void AddNum(SortedDictionary<int, int> dic, int num, ref int cnt)
        {
            if (dic.ContainsKey(num)) dic[num]++; else dic.Add(num, 1);
            cnt++;
        }

        private void RemoveNum(SortedDictionary<int, int> dic, int num, ref int cnt)
        {
            if (dic[num] > 1) dic[num]--; else dic.Remove(num);
            cnt--;
        }

        private void MoveNum(SortedDictionary<int, int> from, SortedDictionary<int, int> to, int num, ref int cnt_from, ref int cnt_to)
        {
            RemoveNum(from, num, ref cnt_from);
            AddNum(to, num, ref cnt_to);
        }
    }
}
