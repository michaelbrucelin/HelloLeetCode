### [最小操作次数使数组元素相等 III](https://leetcode.cn/problems/minimum-moves-to-equal-array-elements-iii/solutions/4046067/zui-xiao-cao-zuo-ci-shu-shi-shu-zu-yuan-qdsie/)

#### 方法一：贪心

**思路与算法**

由于每次操作只能将某个元素的值增加 $1$，并且最终所有元素的值都要相等，因此最终相等的值一定不小于数组中的最大值，记为 $mx$。如果最终相等的值大于 $mx$，那么每个元素都需要额外增加，操作次数一定不会更少。因此最优方案是将所有元素都变成数组中的最大值 $mx$。

所以，对于数组中的每个元素 $x$，它需要增加 $mx-x$ 次。答案为：

$$\sum\limits_{x\in nums} (mx-x)$$

具体实现时，先遍历一次数组求出最大值 $mx$，再遍历一次数组累加每个元素与最大值的差即可。

**代码**

```C++
class Solution {
public:
    int minMoves(vector<int>& nums) {
        int mx = nums[0];
        for (int x : nums) {
            mx = max(mx, x);
        }
        int ans = 0;
        for (int x : nums) {
            ans += mx - x;
        }
        return ans;
    }
};
```

```Go
func minMoves(nums []int) int {
    mx := nums[0]
    for _, x := range nums {
        mx = max(mx, x)
    }
    ans := 0
    for _, x := range nums {
        ans += mx - x
    }
    return ans
}
```

```Python
class Solution:
    def minMoves(self, nums: List[int]) -> int:
        mx = max(nums)
        return sum(mx - x for x in nums)
```

```Java
class Solution {
    public int minMoves(int[] nums) {
        int mx = nums[0];
        for (int x : nums) {
            mx = Math.max(mx, x);
        }
        int ans = 0;
        for (int x : nums) {
            ans += mx - x;
        }
        return ans;
    }
}
```

```TypeScript
function minMoves(nums: number[]): number {
    let mx = nums[0];
    for (const x of nums) {
        mx = Math.max(mx, x);
    }
    let ans = 0;
    for (const x of nums) {
        ans += mx - x;
    }
    return ans;
}
```

```JavaScript
var minMoves = function(nums) {
    let mx = nums[0];
    for (const x of nums) {
        mx = Math.max(mx, x);
    }
    let ans = 0;
    for (const x of nums) {
        ans += mx - x;
    }
    return ans;
};
```

```CSharp
public class Solution {
    public int MinMoves(int[] nums) {
        int mx = nums[0];
        foreach (int x in nums) {
            mx = Math.Max(mx, x);
        }
        int ans = 0;
        foreach (int x in nums) {
            ans += mx - x;
        }
        return ans;
    }
}
```

```C
int minMoves(int* nums, int numsSize) {
    int mx = nums[0];
    for (int i = 1; i < numsSize; i++) {
        mx = fmax(mx, nums[i]);
    }
    int ans = 0;
    for (int i = 0; i < numsSize; i++) {
        ans += mx - nums[i];
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn min_moves(nums: Vec<i32>) -> i32 {
        let mx = *nums.iter().max().unwrap();
        nums.iter().map(|x| mx - x).sum()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。需要遍历数组两次，一次求最大值，一次累加差值。
- 空间复杂度：$O(1)$，只需要常数个变量存储最大值与答案。
