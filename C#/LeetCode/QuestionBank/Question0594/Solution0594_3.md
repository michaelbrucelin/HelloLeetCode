#### [方法一：枚举](https://leetcode.cn/problems/longest-harmonious-subsequence/solutions/1110137/zui-chang-he-xie-zi-xu-lie-by-leetcode-s-8cyr/)

**思路与算法**

我们可以枚举数组中的每一个元素，对于当前枚举的元素 $x$，它可以和 $x + 1$ 组成和谐子序列。我们只需要在数组中找出等于 $x$ 或 $x + 1$ 的元素个数，就可以得到以 $x$ 为最小值的和谐子序列的长度。

-   实际处理时，我们可以将数组按照从小到大进行排序，我们只需要依次找到相邻两个连续相同元素的子序列，检查该这两个子序列的元素的之差是否为 $1$。
-   利用类似于滑动窗口的做法，$begin$ 指向第一个连续相同元素的子序列的第一个元素，$end$ 指向相邻的第二个连续相同元素的子序列的末尾元素，如果满足二者的元素之差为 $1$，则当前的和谐子序列的长度即为两个子序列的长度之和，等于 $end - begin + 1$。

**代码**

```java
class Solution {
    public int findLHS(int[] nums) {
        Arrays.sort(nums);
        int begin = 0;
        int res = 0;
        for (int end = 0; end < nums.length; end++) {
            while (nums[end] - nums[begin] > 1) {
                begin++;
            }
            if (nums[end] - nums[begin] == 1) {
                res = Math.max(res, end - begin + 1);
            }
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    int findLHS(vector<int>& nums) {
        sort(nums.begin(),nums.end());
        int begin = 0;
        int res = 0;
        for (int end = 0; end < nums.size(); end++) {
            while (nums[end] - nums[begin] > 1) {
                begin++;
            }
            if (nums[end] - nums[begin] == 1) {
                res = max(res, end - begin + 1);
            }
        }
        return res;
    }
};
```

```csharp
public class Solution {
    public int FindLHS(int[] nums) {
        Array.Sort(nums);
        int begin = 0;
        int res = 0;
        for (int end = 0; end < nums.Length; end++) {
            while (nums[end] - nums[begin] > 1) {
                begin++;
            }
            if (nums[end] - nums[begin] == 1) {
                res = Math.Max(res, end - begin + 1);
            }
        }
        return res;
    }
}
```

```python
class Solution:
    def findLHS(self, nums: List[int]) -> int:
        nums.sort()
        res, begin = 0, 0
        for end in range(len(nums)):
            while nums[end] - nums[begin] > 1:
                begin += 1
            if nums[end] - nums[begin] == 1:
                res = max(res, end - begin + 1)
        return res
```

```javascript
var findLHS = function(nums) {
    nums.sort((a, b) => a - b);
    let begin = 0;
    let res = 0;
    for (let end = 0; end < nums.length; end++) {
        while (nums[end] - nums[begin] > 1) {
            begin++;
        }
        if (nums[end] - nums[begin] === 1) {
            res = Math.max(res, end - begin + 1);
        }
    }
    return res;
};
```

```go
func findLHS(nums []int) (ans int) {
    sort.Ints(nums)
    begin := 0
    for end, num := range nums {
        for num-nums[begin] > 1 {
            begin++
        }
        if num-nums[begin] == 1 && end-begin+1 > ans {
            ans = end - begin + 1
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(N\log N)$，其中 $N$ 为数组的长度。我们首先需要对数组进行排序，花费的时间复杂度为 $O(N\log N)$，我们需要利用双指针遍历数组花费的时间为 $O(2N)$，总的时间复杂度 $T(N) = O(N\log N) + O(2N) = O(N\log N)$。
-   空间复杂度：$O(1)$，需要常数个空间保存中间变量。
