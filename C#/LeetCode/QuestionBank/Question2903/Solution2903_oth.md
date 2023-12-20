### [O(n) 做法：双指针+维护最大最小（Python/Java/C++/Go）](https://leetcode.cn/problems/find-indices-with-index-and-value-difference-i/solutions/2483162/on-zuo-fa-shuang-zhi-zhen-wei-hu-zui-da-rkbk9/)

下午两点[【b站@灵茶山艾府】](https://leetcode.cn/link/?target=https%3A%2F%2Fb23.tv%2FJMcHRRp)直播讲题，欢迎关注！

不妨设 $i \le j - indexDifference$。

类似 [121. 买卖股票的最佳时机](https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/)，我们可以在枚举 $j$ 的同时，维护 $nums[i]$ 的最大值 $mx$ 和最小值 $mn$。

那么只要满足下面两个条件中的一个，就可以返回答案了。

- $mx -nums[j] \ge valueDifference$
- $nums[j] - mn \ge valueDifference$

代码实现时，可以维护最大值的下标 $maxIdx$ 和最小值的下标 $minIdx$。

#### 答疑

**问：** 为什么不用算绝对值？如果 $mx < nums[j]$ 并且 $|mx - nums[j]| \ge valueDifference$，不就错过答案了吗？

**答：** 不会的，如果出现这种情况，那么一定会有 $nums[j] - mn \ge valueDifference$。

```python
class Solution:
    def findIndices(self, nums: List[int], indexDifference: int, valueDifference: int) -> List[int]:
        max_idx = min_idx = 0
        for j in range(indexDifference, len(nums)):
            i = j - indexDifference
            if nums[i] > nums[max_idx]:
                max_idx = i
            elif nums[i] < nums[min_idx]:
                min_idx = i
            if nums[max_idx] - nums[j] >= valueDifference:
                return [max_idx, j]
            if nums[j] - nums[min_idx] >= valueDifference:
                return [min_idx, j]
        return [-1, -1]
```

```java
class Solution {
    public int[] findIndices(int[] nums, int indexDifference, int valueDifference) {
        int maxIdx = 0, minIdx = 0;
        for (int j = indexDifference; j < nums.length; j++) {
            int i = j - indexDifference;
            if (nums[i] > nums[maxIdx]) {
                maxIdx = i;
            } else if (nums[i] < nums[minIdx]) {
                minIdx = i;
            }
            if (nums[maxIdx] - nums[j] >= valueDifference) {
                return new int[]{maxIdx, j};
            }
            if (nums[j] - nums[minIdx] >= valueDifference) {
                return new int[]{minIdx, j};
            }
        }
        return new int[]{-1, -1};
    }
}
```

```c++
class Solution {
public:
    vector<int> findIndices(vector<int> &nums, int indexDifference, int valueDifference) {
        int max_idx = 0, min_idx = 0;
        for (int j = indexDifference; j < nums.size(); j++) {
            int i = j - indexDifference;
            if (nums[i] > nums[max_idx]) {
                max_idx = i;
            } else if (nums[i] < nums[min_idx]) {
                min_idx = i;
            }
            if (nums[max_idx] - nums[j] >= valueDifference) {
                return {max_idx, j};
            }
            if (nums[j] - nums[min_idx] >= valueDifference) {
                return {min_idx, j};
            }
        }
        return {-1, -1};
    }
};
```

```go
func findIndices(nums []int, indexDifference, valueDifference int) []int {
    maxIdx, minIdx := 0, 0
    for j := indexDifference; j < len(nums); j++ {
        i := j - indexDifference
        if nums[i] > nums[maxIdx] {
            maxIdx = i
        } else if nums[i] < nums[minIdx] {
            minIdx = i
        }
        if nums[maxIdx]-nums[j] >= valueDifference {
            return []int{maxIdx, j}
        }
        if nums[j]-nums[minIdx] >= valueDifference {
            return []int{minIdx, j}
        }
    }
    return []int{-1, -1}
}
```

#### 复杂度分析

- 时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $nums$ 的长度。
- 空间复杂度：$\mathcal{O}(1)$。
