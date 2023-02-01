#### [方法二：统计每个整数的出现次数](https://leetcode.cn/problems/intersection-of-multiple-arrays/solutions/1486063/duo-ge-shu-zu-qiu-jiao-ji-by-leetcode-so-5c9z/)

**思路与算法**

我们用 $n$ 表示二维数组 $nums$ 的长度。由于二维数组 $nums$ 里面的每个数组中的元素互不相同，因此如果一个元素在每个数组中均出现过，则它在 $nums$ 中的出现次数应当等于 $n$。

因此我们可以用哈希表 $freq$ 维护每个整数的出现次数，随后我们遍历 $nums$ 并维护哈希表 $freq$。最终，我们遍历 $freq$ 并用 $res$ 数组记录所有出现次数等于 $n$ 的整数，然后返回排序后的 $res$ 数组作为答案。

**代码**

```cpp
class Solution {
public:
    vector<int> intersection(vector<vector<int>>& nums) {
        int n = nums.size();
        unordered_map<int, int> freq;
        for (const auto& arr: nums) {
            for (int num: arr) {
                ++freq[num];
            }
        }
        vector<int> res;
        for (const auto& [k, v]: freq) {
            if (v == n) {
                res.push_back(k);
            }
        }
        sort(res.begin(), res.end());
        return res;
    }
};
```

```python
class Solution:
    def intersection(self, nums: List[List[int]]) -> List[int]:
        n = len(nums)
        freq = defaultdict(int)
        for arr in nums:
            for num in arr:
                freq[num] += 1
        res = []
        for k, v in freq.items():
            if v == n:
                res.append(k)
        return sorted(res)
```

**复杂度分析**

-   时间复杂度：$O(\sum_i n_i + \min(n_i)\log\min(n_i))$，其中 $n_i$ 为 $nums[i]$ 的长度。即为遍历统计每个整数出现次数，遍历哈希表统计结果以及排序的时间复杂度。
-   空间复杂度：$O(\max_i n_i)$，即为辅助哈希表的时间复杂度。
