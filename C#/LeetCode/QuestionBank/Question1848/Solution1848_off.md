### [到目标元素的最小距离](https://leetcode.cn/problems/minimum-distance-to-the-target-element/solutions/755634/dao-mu-biao-yuan-su-de-zui-xiao-ju-chi-b-v4ce/)

#### 方法一：模拟

**思路与算法**

我们对 $nums$ 进行遍历，并在遍历的过程中用 $res$ 来维护满足要求的 $\vert i-start\vert $ 的最小值。

注意 $res$ 的初始值需要大于等于 $\vert i-start\vert $ 的最大可能值，即 $nums.length-1$。在下面的代码中，我们选择值 $nums.length$。

**代码**

```C++
class Solution {
public:
    int getMinDistance(vector<int>& nums, int target, int start) {
        int res = nums.size();
        for (int i = 0; i < nums.size(); ++i){
            if (nums[i] == target){
                res = min(res, abs(i - start));
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def getMinDistance(self, nums: List[int], target: int, start: int) -> int:
        res = len(nums)
        for i, num in enumerate(nums):
            if num == target:
                res = min(res, abs(i - start))
        return res
```

**复杂度分析**

- 时间复杂度：$O(n)$，即为遍历数组的时间复杂度。
- 空间复杂度：$O(1)$。
