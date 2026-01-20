### [构造最小位运算数组 II](https://leetcode.cn/problems/construct-the-minimum-bitwise-array-i/solutions/3878889/gou-zao-zui-xiao-wei-yun-suan-shu-zu-i-b-1yc3/)

#### 方法一：位运算

**思路及解法**

根据题目要求：为 $nums$ 中的每一个 $x$ 找到一个最小的 $ans$ 使得 $ans\vert (ans+1)=x$。

观察 $ans+1$，易知 $ans+1$ 的作用是将 $ans$ 中从低位到高位第一个 $0$ 变成 $1$ 并且使该 $0$ 之前的全部低位 $1$ 变为 $0$，那么 $ans\vert (ans+1)$ 的作用即是将ans 中从低位到高位第一个 $0$ 变成 $1$。

由此可知，对于 $x$ 二进制位从低位到高位的第一个 $0$ 之前的所有 $1$，任取一个 $1$ 变为 $0$ 都可以求得一个 $ans$，使得 $ans\vert (ans+1)=x$。

题目要求找到最小的 $ans$，因此我们只需要找到每个 $x$ 中第一位 $0$ 的位置 $pos$ 并将 $pos-1$ 处的 $1$ 变为 $0$ 即可，具体代码逻辑如下：使用 $d$ 来判断当前二进制位是否为 $0$，假设当前二进制位为 $1$，那么将 $res$ 更新为 $x-d$，也就是使当前二进制位变为 $0$，然后将 $d$ 左移一位，继续判断下一位二进制位是否为 $0$。如果当前二进制位为 $0$，那么说明已经没有更小的 $ans$ 了。

只有当 $x=2$ 时，答案取 $-1$，这是因为 $2$ 是质数，并且最低位 $0$ 之前没有更低位 $1$，导致无法求得答案。

**代码**

```C++
class Solution {
public:
    vector<int> minBitwiseArray(vector<int>& nums) {
        for (int& x : nums) {
            int res = -1;
            int d = 1;
            while ((x & d) != 0) {
                res = x - d;
                d <<= 1;
            }
            x = res;
        }
        return nums;
    }
};
```

```Java
class Solution {
    public int[] minBitwiseArray(List<Integer> nums) {
        int n = nums.size();
        int[] result = new int[n];
        for (int i = 0; i < n; i++) {
            int x = nums.get(i);
            int res = -1;
            int d = 1;
            while ((x & d) != 0) {
                res = x - d;
                d <<= 1;
            }
            result[i] = res;
        }
        return result;
    }
}
```

```Python
class Solution:
    def minBitwiseArray(self, nums: List[int]) -> List[int]:
        for i in range(len(nums)):
            res = -1
            d = 1
            while (nums[i] & d) != 0:
                res = nums[i] - d
                d <<= 1
            nums[i] = res
        return nums
```

```CSharp
public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) {
        for (int i = 0; i < nums.Count; i++) {
            int x = nums[i];
            int res = -1;
            int d = 1;
            while ((x & d) != 0) {
                res = x - d;
                d <<= 1;
            }
            nums[i] = res;
        }
        return nums.ToArray();
    }
}
```

```Go
func minBitwiseArray(nums []int) []int {
    for i, x := range nums {
        res := -1
        d := 1
        for (x & d) != 0 {
            res = x - d
            d <<= 1
        }
        nums[i] = res
    }
    return nums
}
```

```C
int* minBitwiseArray(int* nums, int numsSize, int* returnSize) {
    *returnSize = numsSize;
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        int res = -1;
        int d = 1;
        while ((x & d) != 0) {
            res = x - d;
            d <<= 1;
        }
        nums[i] = res;
    }
    return nums;
}
```

```JavaScript
var minBitwiseArray = function(nums) {
    for (let i = 0; i < nums.length; i++) {
        let x = nums[i];
        let res = -1;
        let d = 1;
        while ((x & d) !== 0) {
            res = x - d;
            d <<= 1;
        }
        nums[i] = res;
    }
    return nums;
};
```

```TypeScript
function minBitwiseArray(nums: number[]): number[] {
    for (let i = 0; i < nums.length; i++) {
        let x = nums[i];
        let res = -1;
        let d = 1;
        while ((x & d) !== 0) {
            res = x - d;
            d <<= 1;
        }
        nums[i] = res;
    }
    return nums;
}
```

```Rust
impl Solution {
    pub fn min_bitwise_array(nums:Vec<i32>) -> Vec<i32> {
        let mut nums = nums.clone();
        for x in nums.iter_mut() {
            let mut res = -1;
            let mut d = 1;
            let val = *x;
            while (val & d) != 0 {
                res = val - d;
                d <<= 1;
            }
            *x = res;
        }
        nums.clone()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log m)$，其中 $n$ 是数组 $nums$ 的长度，$m$ 是数组中的最大值。
- 空间复杂度：$O(1)$。
