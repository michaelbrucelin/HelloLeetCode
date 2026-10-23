### [脑筋急转弯](https://leetcode.cn/problems/maximum-k-to-sort-a-permutation/solutions/3748522/nao-jin-ji-zhuan-wan-by-tsreaper-265b/)

#### 解法：脑筋急转弯

假设答案为 $k$，那么所有满足 `nums[i] AND k == k` 的元素 `nums[i]` 都能以元素 $k$ 为中继点进行任意交换，而剩下的位置都无法改变元素。这也告诉我们，$k=0$ 至少是可行解。

`nums[i] AND k == k`，说明 $k$ 是 `nums[i]` 的子集。给很多个集合，求它们的最大公共子集，那就是所有集合的交，因此最大答案就是所有需要交换的元素 `AND` 起来。

只有 `nums[i] != i` 的元素才需要交换，所以答案就是所有这些元素 `AND` 起来的结果。复杂度 $O(n)$。

#### 参考代码（$c++$）

```cpp
class Solution {
public:
    int sortPermutation(vector<int>& nums) {
        int n = nums.size();
        int ans = (1 << 30) - 1;
        bool flag = true;
        for (int i = 0; i < n; i++) if (nums[i] != i) {
            ans &= nums[i];
            flag = false;
        }
        return flag ? 0 : ans;
    }
};
```
