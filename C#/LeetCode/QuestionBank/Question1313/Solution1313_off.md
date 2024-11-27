### [解压缩编码列表](https://leetcode.cn/problems/decompress-run-length-encoded-list/solutions/101299/jie-ya-suo-bian-ma-lie-biao-by-leetcode-solution/)

#### 方法一：模拟

我们以步长（step）为 `2` 遍历数组 `nums`，对于当前遍历到的元素 `a` 和 `b`，我们将 `a` 个 `b` 添加进答案中即可。

```C++
class Solution {
public:
    vector<int> decompressRLElist(vector<int>& nums) {
        vector<int> ans;
        for (int i = 0; i < nums.size(); i += 2) {
            for (int j = 0; j < nums[i]; ++j) {
                ans.push_back(nums[i + 1]);
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def decompressRLElist(self, nums: List[int]) -> List[int]:
        ans = list()
        for i in range(0, len(nums), 2):
            ans.extend([nums[i + 1]] * nums[i])
        return ans
```

**复杂度分析**

- 时间复杂度：$O(N+\sum nums_{even})$，其中 $N$ 是数组 `nums` 的长度，$\sum nums_{even}$ 是数组 `nums` 中所有下标为偶数的元素之和。
- 空间复杂度：$O(\sum nums_{even})$。
