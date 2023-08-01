using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2681
{
    public class Solution2681 : Interface2681
    {
        /// <summary>
        /// 暴力枚举
        /// 1. 枚举出所有的组合，每遍历一个新的元素，都保留所有当前的组合，再用新元素和所有当前组合集合一下，用1 2 3来举例
        ///     初始状态  {}  只有一个空集
        ///     元素1，   {} {1}
        ///     元素2，   {} {1} {2} {1 2}
        ///     元素3，   {} {1} {2} {1 2} {3} {1 3} {2 3} {1 2 3}
        /// 2. 使用一个值元组记录每一个组合，只记录组合中的最大值，最小值，以及“力量”即可
        ///     由于每一个组合只记录其最大值，最小值以及“力量”，所以会有大量的重复，这里使用字典记录每一种组合的数量来节省内存开销
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例06，才898个元素就超时了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfPower(int[] nums)
        {
            long result = 0;
            const int MOD = 1000000007;
            Dictionary<(int max, int min, int power), int> set = new Dictionary<(int max, int min, int power), int>();
            Dictionary<(int max, int min, int power), int> _set = new Dictionary<(int max, int min, int power), int>();
            (int max, int min, int power) _key;
            for (int i = 0, num; i < nums.Length; i++)
            {
                num = nums[i];
                _set.Add((num, num, (int)(((long)num) * num % MOD * num % MOD)), 1);
                foreach (var key in set.Keys)
                {
                    if (key.min <= num && num <= key.max)
                    {
                        if (_set.ContainsKey(key)) _set[key] = (_set[key] + set[key]) % MOD; else _set.Add(key, set[key]);
                    }
                    else  // if (num < key.min || key.max < num)
                    {
                        if (num < key.min)
                            _key = (key.max, num, (int)(((long)key.max) * key.max % MOD * num % MOD));
                        else  // if(key.max < num)
                            _key = (num, key.min, (int)(((long)num) * num % MOD * key.min % MOD));
                        if (_set.ContainsKey(_key)) _set[_key] = (_set[_key] + set[key]) % MOD; else _set.Add(_key, set[key]);
                    }
                }

                foreach (var key in _set.Keys)
                {
                    result = (result + ((long)key.power) * (_set[key] % MOD) % MOD) % MOD;
                    if (set.ContainsKey(key)) set[key] = (set[key] + _set[key]) % MOD; else set.Add(key, _set[key]);
                }
                _set.Clear();
            }

            return (int)result;
        }
    }
}
