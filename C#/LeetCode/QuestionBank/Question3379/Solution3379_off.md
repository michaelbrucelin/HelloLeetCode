### [转换数组](https://leetcode.cn/problems/transformed-array/solutions/3892290/zhuan-huan-shu-zu-by-leetcode-solution-xkww/)

#### 方法一：遍历

**思路与算法**

题目要求我们根据给定的规则转换数组。对于每个位置 $i$，我们需要计算新的值为 $nums[((i+nums[i])\bmod n+n)\bmod n]$，其中 $n$ 是数组的长度。这一公式的作用是确保索引始终在合法范围内，即 $[0,n-1]$。

具体实现中，我们可以遍历数组的每个位置 $i$，按照公式计算新的值，并将结果存储到一个新的数组中，最后返回结果数组。

**代码**

```C++
class Solution {
public:
    vector<int> constructTransformedArray(vector<int>& nums) {
        int n = nums.size();
        vector<int> res(n);
        for (int i = 0; i < n; i++) {
            res[i] = nums[((i + nums[i]) % n + n) % n];
        }
        return res;
    }
};
```

```Go
func constructTransformedArray(nums []int) []int {
    n := len(nums)
    res := make([]int, n)
    for i := 0; i < n; i++ {
        res[i] = nums[((i + nums[i]) % n + n) % n]
    }
    return res
}
```

```Python
class Solution:
    def constructTransformedArray(self, nums):
        n = len(nums)
        return [nums[((i + nums[i]) % n + n) % n] for i in range(n)]
```

```Java
class Solution {
    public int[] constructTransformedArray(int[] nums) {
        int n = nums.length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = nums[((i + nums[i]) % n + n) % n];
        }
        return res;
    }
}
```

```TypeScript
function constructTransformedArray(nums: number[]): number[] {
    const n = nums.length;
    const res: number[] = new Array(n);
    for (let i = 0; i < n; i++) {
        res[i] = nums[((i + nums[i]) % n + n) % n];
    }
    return res;
}
```

```JavaScript
var constructTransformedArray = function(nums) {
    const n = nums.length;
    const res = new Array(n);
    for (let i = 0; i < n; i++) {
        res[i] = nums[((i + nums[i]) % n + n) % n];
    }
    return res;
};
```

```CSharp
public class Solution {
    public int[] ConstructTransformedArray(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = nums[((i + nums[i]) % n + n) % n];
        }
        return res;
    }
}
```

```C
int* constructTransformedArray(int* nums, int numsSize, int* returnSize) {
    *returnSize = numsSize;
    int* res = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; i++) {
        res[i] = nums[((i + nums[i]) % numsSize + numsSize) % numsSize];
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn construct_transformed_array(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();
        nums.iter()
            .enumerate()
            .map(|(i, &num)| nums[((i as i32 + num) % n as i32 + n as i32) as usize % n])
            .collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。我们需要遍历整个数组一次，计算每个位置的值。
- 空间复杂度：$O(n)$，用于存储结果数组。
