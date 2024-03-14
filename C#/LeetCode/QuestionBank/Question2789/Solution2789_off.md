### [合并后数组中的最大元素](https://leetcode.cn/problems/largest-element-in-an-array-after-merge-operations/solutions/2679835/he-bing-hou-shu-zu-zhong-de-zui-da-yuan-s2b5o/)

#### 方法一：贪心 + 倒序遍历数组

##### 思路

首先理解题意，题目中的一次替换删除操作，其实是相当于将两个相邻并且非递减的数字进行求和合并。两个数字的和来替换掉原来的两个数字。而经过若干次这样的合并，整个数组的和是不变的。合并后数组中的每个元素，都是原数组的某个子数组的和，并且这些子数组拼接起来能构成整个原数组。为了使数组的最大值最大，我们可以贪心地做尽可能多的合并，直到整个数组都不能进行合并。合并的要求是后面的数字不小于前面的数字，我们就尽可能先合并靠后的数字，使其尽快能大，才能够合并前面的数字。

我们从后往前倒序遍历一次数组，依次比较两个相邻的元素，如果两个相邻的元素能够合并，就将其合并。如果不能合并，就继续往前判断。因为这样的操作流程，在比较过程中，靠后的数是所有操作流程可能性中能产生的最大值，而靠前的数，是所有操作流程可能性中能产生的最小值。如果在遍历过程中，比较的结果是不能合并，那么其他任何操作流程都无法合并这两个数。如果可以合并，那我们就贪心地合并，因为这样能使接下来的比较中，靠后的数字尽可能大。

在具体实现上，我们可以倒序遍历 $\textit{nums}$，然后依次比较所有 $\textit{nums}[i+1]$ 和 $\textit{nums}[i]$。如果 $\textit{nums}[i+1] \geq \textit{nums}[i]$，那么就将 $\textit{nums}[i]$ 更新为 $\textit{nums}[i+1] + \textit{nums}[i]$。这样的操作相当于进行了合并，因为我们不会再访问 $\textit{nums}[i+1]$。遍历完后直接返回 $\textit{nums}[0]$，因为合并完后的数组肯定是递减的，否则可以继续合并，这样的话首元素就是数组最大值。

##### 代码

```python
class Solution:
    def maxArrayValue(self, nums: List[int]) -> int:
        for i in range(len(nums) - 2, -1, -1):
            if nums[i] <= nums[i + 1]:
                nums[i] += nums[i + 1]
        return nums[0]
```

```java
class Solution {
    public long maxArrayValue(int[] nums) {
        long sum = nums[nums.length - 1];
        for (int i = nums.length - 2; i >= 0; i--) {
            sum = nums[i] <= sum ? nums[i] + sum : nums[i];
        }
        return sum;
    }
}
```

```csharp
public class Solution {
    public long MaxArrayValue(int[] nums) {
        long sum = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--) {
            sum = nums[i] <= sum ? nums[i] + sum : nums[i];
        }
        return sum;
    }
}
```

```c++
class Solution {
public:
    long long maxArrayValue(vector<int>& nums) {
        long long sum = nums.back();
        for (int i = nums.size() - 2; i >= 0; i--) {
            sum = nums[i] <= sum ? nums[i] + sum : nums[i];
        }
        return sum;
    }
};
```

```c
long long maxArrayValue(int* nums, int numsSize){
    long long sum = nums[numsSize - 1];
    for (int i = numsSize - 2; i >= 0; i--) {
        sum = nums[i] <= sum ? nums[i] + sum : nums[i];
    }
    return sum;
}
```

```go
func maxArrayValue(nums []int) int64 {
    sum := int64(nums[len(nums)-1])
    for i := len(nums) - 2; i >= 0; i-- {
        if int64(nums[i]) <= sum {
            sum = int64(nums[i]) + sum
        } else {
            sum = int64(nums[i])
        }
    }
    return sum
}
```

```javascript
var maxArrayValue = function(nums) {
    let sum = nums[nums.length - 1];
    for (let i = nums.length - 2; i >= 0; i--) {
        sum = nums[i] <= sum ? nums[i] + sum : nums[i];
    }
    return sum;
};
```

```typescript
function maxArrayValue(nums: number[]): number {
    let sum: number = nums[nums.length - 1];
    for (let i = nums.length - 2; i >= 0; i--) {
        sum = nums[i] <= sum ? nums[i] + sum : nums[i];
    }
    return sum;
};
```

```rust
impl Solution {
    pub fn max_array_value(nums: Vec<i32>) -> i64 {
        let mut sum = nums[nums.len() - 1] as i64;
        for i in (0..nums.len() - 1).rev() {
            sum = if nums[i] as i64 <= sum {nums[i] as i64 + sum } else {nums[i] as i64};
        }
        sum
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $\textit{nums}$ 的长度。我们仅遍历一遍数组。
- 时间复杂度：$O(1)$。
