### [基于排列构建数组](https://leetcode.cn/problems/build-array-from-permutation/solutions/858017/ji-yu-pai-lie-gou-jian-shu-zu-by-leetcod-gjcn/)

#### 方法一：按要求构建

**思路与算法**

我们可以构建一个与原数组 $nums$ 等长的新数组，同时令新数组中下标为 $i$ 的元素等于 $nums[nums[i]]$。

**代码**

```C++
class Solution {
public:
    vector<int> buildArray(vector<int>& nums) {
        int n = nums.size();
        vector<int> ans;
        for (int i = 0; i < n; ++i){
            ans.push_back(nums[nums[i]]);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def buildArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        return [nums[nums[_]] for _ in range(n)]
```

```Java
class Solution {
    public int[] buildArray(int[] nums) {
        int n = nums.length;
        int[] ans = new int[n];
        for (int i = 0; i < n; ++i) {
            ans[i] = nums[nums[i]];
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] BuildArray(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; ++i) {
            ans[i] = nums[nums[i]];
        }
        return ans;
    }
}
```

```Go
func buildArray(nums []int) []int {
    n := len(nums)
    ans := make([]int, n)
    for i := 0; i < n; i++ {
        ans[i] = nums[nums[i]]
    }
    return ans
}
```

```C
int* buildArray(int* nums, int numsSize, int* returnSize) {
    int* ans = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; ++i) {
        ans[i] = nums[nums[i]];
    }
    *returnSize = numsSize;
    return ans;
}
```

```JavaScript
var buildArray = function(nums) {
    const n = nums.length;
    const ans = [];
    for (let i = 0; i < n; ++i) {
        ans.push(nums[nums[i]]);
    }
    return ans;
};
```

```TypeScript
function buildArray(nums: number[]): number[] {
    const n = nums.length;
    const ans: number[] = [];
    for (let i = 0; i < n; ++i) {
        ans.push(nums[nums[i]]);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn build_array(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();
        let mut ans = Vec::with_capacity(n);
        for i in 0..n {
            ans.push(nums[nums[i] as usize]);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。即为构建新数组的时间复杂度。
- 空间复杂度：$O(1)$，输出数组不计入空间复杂度。

#### 方法二：原地构建

**思路与算法**

我们也可以直接对原数组 $nums$ 进行修改。

为了使得构建过程可以完整进行，我们需要让 $nums$ 中的每个元素 $nums[i]$ 能够同时存储「当前值」（即 $nums[i]$）和「最终值」（即 $nums[nums[i]]$）。

我们注意到 $nums$ 中元素的取值范围为 $[0,999]$ 闭区间，这意味着 $nums$ 中的每个元素的「当前值」和「最终值」都在 $[0,999]$ 闭区间内。

因此，我们可以使用类似「1000 进制」的思路来表示每个元素的「当前值」和「最终值」。对于每个元素，我们用它除以 $1000$ 的商数表示它的「最终值」，而用余数表示它的「当前值」。

那么，我们首先遍历 $nums$，计算每个元素的「最终值」，并乘以 $1000$ 加在该元素上。随后，我们再次遍历数组，并将每个元素的值除以 $1000$ 保留其商数。此时 $nums$ 即为构建完成的数组，我们返回该数组作为答案。

**细节**

在计算 $nums[i]$ 的「最终值」并修改该元素时，我们需要计算**修改前** $nums[nums[i]]$ 的值，而 $nums$ 中下标为 $nums[i]$ 的元素可能已被修改，因此我们需要将取下标得到的值对 $1000$ 取模得到「最终值」。

**代码**

```C++
class Solution {
public:
    vector<int> buildArray(vector<int>& nums) {
        int n = nums.size();
        // 第一次遍历编码最终值
        for (int i = 0; i < n; ++i){
            nums[i] += 1000 * (nums[nums[i]] % 1000);
        }
        // 第二次遍历修改为最终值
        for (int i = 0; i < n; ++i){
            nums[i] /= 1000;
        }
        return nums;
    }
};
```

```Python
class Solution:
    def buildArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        # 第一次遍历编码最终值
        for i in range(n):
            nums[i] += 1000 * (nums[nums[i]] % 1000) 
        # 第二次遍历修改为最终值
        for i in range(n):
            nums[i] //= 1000
        return nums
```

```Java
class Solution {
    public int[] buildArray(int[] nums) {
        int n = nums.length;
        // 第一次遍历编码最终值
        for (int i = 0; i < n; ++i) {
            nums[i] += 1000 * (nums[nums[i]] % 1000);
        }
        // 第二次遍历修改为最终值
        for (int i = 0; i < n; ++i) {
            nums[i] /= 1000;
        }
        return nums;
    }
}
```

```CSharp
public class Solution {
    public int[] BuildArray(int[] nums) {
        int n = nums.Length;
        // 第一次遍历编码最终值
        for (int i = 0; i < n; ++i) {
            nums[i] += 1000 * (nums[nums[i]] % 1000);
        }
        // 第二次遍历修改为最终值
        for (int i = 0; i < n; ++i) {
            nums[i] /= 1000;
        }
        return nums;
    }
}
```

```Go
func buildArray(nums []int) []int {
    n := len(nums)
    // 第一次遍历编码最终值
    for i := 0; i < n; i++ {
        nums[i] += 1000 * (nums[nums[i]] % 1000)
    }
    // 第二次遍历修改为最终值
    for i := 0; i < n; i++ {
        nums[i] /= 1000
    }
    return nums
}
```

```C
int* buildArray(int* nums, int numsSize, int* returnSize) {
    // 第一次遍历编码最终值
    for (int i = 0; i < numsSize; ++i) {
        nums[i] += 1000 * (nums[nums[i]] % 1000);
    }
    // 第二次遍历修改为最终值
    for (int i = 0; i < numsSize; ++i) {
        nums[i] /= 1000;
    }
    *returnSize = numsSize;
    return nums;
}
```

```JavaScript
var buildArray = function(nums) {
    const n = nums.length;
    // 第一次遍历编码最终值
    for (let i = 0; i < n; ++i) {
        nums[i] += 1000 * (nums[nums[i]] % 1000);
    }
    // 第二次遍历修改为最终值
    for (let i = 0; i < n; ++i) {
        nums[i] = Math.floor(nums[i] / 1000);
    }
    return nums;
};
```

```TypeScript
function buildArray(nums: number[]): number[] {
    const n = nums.length;
    // 第一次遍历编码最终值
    for (let i = 0; i < n; ++i) {
        nums[i] += 1000 * (nums[nums[i]] % 1000);
    }
    // 第二次遍历修改为最终值
    for (let i = 0; i < n; ++i) {
        nums[i] = Math.floor(nums[i] / 1000);
    }
    return nums;
};
```

```Rust
impl Solution {
    pub fn build_array(mut nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();
        // 第一次遍历编码最终值
        for i in 0..n {
            nums[i] += 1000 * (nums[nums[i] as usize] % 1000);
        }
        // 第二次遍历修改为最终值
        for i in 0..n {
            nums[i] /= 1000;
        }
        nums
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。我们遍历了两次 $nums$ 数组并进行修改，每次遍历并修改的时间复杂度均为 $O(n)$。
- 空间复杂度：$O(1)$。
