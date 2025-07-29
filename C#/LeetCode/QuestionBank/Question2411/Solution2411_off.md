### [按位或最大的最小子数组长度](https://leetcode.cn/problems/smallest-subarrays-with-maximum-bitwise-or/solutions/3730081/an-wei-huo-zui-da-de-zui-xiao-zi-shu-zu-v5dt7/)

#### 方法一：记录每个二进制位的最近出现位置

**思路与算法**

对于数组中的元素 $nums[i]$，它的范围在 $[0,10^9]$ 之间，最多包含 $31$ 个二进制位。

对于它的第 $bit$ 个二进制位：

- 如果是 $1$，那么与任何数进行按位或运算后，这个二进制位仍然是 $1$，因此不会有任何影响；
- 如果是 $0$，那么我们需要找到一个最小的 $j$，满足 $j>i$，并且 $nums[j]$ 的第 $bit$ 个二进制位是 $1$。这样在进行按位或运算时，才能达到最大的值。需要注意，可能不存在这样的 $j$。

因此，我们可以按照下标从大到小的顺序对数组 $nums$ 进行遍历，同时用数组 $pos$ 记录每一个二进制位**最近一次**出现为 $1$ 的位置（如果没有这样的位置，则为默认值 $-1$）。当我们遍历到 $nums[i]$ 时，对于它的第 $bit$ 个二进制位：

- 如果是 $1$，就将 $pos[bit]$ 更新为 $i$；
- 如果是 $0$，且 $pos[bit]$ 不为 $-1$，那么要以 $i$ 为左边界得到最大的按位或运算值，右边界至少要为 $pos[bit]$。

这样一来，我们就可以依次得到每个 $i$ 作为左边界时，右边界的最小值，也就可以得到子数组的最小长度。

**代码**

```C++
class Solution {
public:
    vector<int> smallestSubarrays(vector<int>& nums) {
        int n = nums.size();
        vector<int> pos(31, -1);
        vector<int> ans(n);
        for (int i = n - 1; i >= 0; --i) {
            int j = i;
            for (int bit = 0; bit < 31; ++bit) {
                if (!(nums[i] & (1 << bit))) {
                    if (pos[bit] != -1) {
                        j = max(j, pos[bit]);
                    }
                }
                else {
                    pos[bit] = i;
                }
            }
            ans[i] = j - i + 1;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def smallestSubarrays(self, nums: List[int]) -> List[int]:
        n = len(nums)
        pos = [-1] * 31
        ans = [0] * n
        for i in range(n - 1, -1, -1):
            j = i
            for bit in range(31):
                if (nums[i] & (1 << bit)) == 0:
                    if pos[bit] != -1:
                        j = max(j, pos[bit])
                else:
                    pos[bit] = i
            ans[i] = j - i + 1
        return ans
```

```Java
class Solution {
    public int[] smallestSubarrays(int[] nums) {
        int n = nums.length;
        int[] pos = new int[31];
        Arrays.fill(pos, -1);
        int[] ans = new int[n];
        for (int i = n - 1; i >= 0; --i) {
            int j = i;
            for (int bit = 0; bit < 31; ++bit) {
                if ((nums[i] & (1 << bit)) == 0) {
                    if (pos[bit] != -1) {
                        j = Math.max(j, pos[bit]);
                    }
                } else {
                    pos[bit] = i;
                }
            }
            ans[i] = j - i + 1;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] SmallestSubarrays(int[] nums) {
        int n = nums.Length;
        int[] pos = new int[31];
        Array.Fill(pos, -1);
        int[] ans = new int[n];
        for (int i = n - 1; i >= 0; --i) {
            int j = i;
            for (int bit = 0; bit < 31; ++bit) {
                if ((nums[i] & (1 << bit)) == 0) {
                    if (pos[bit] != -1) {
                        j = Math.Max(j, pos[bit]);
                    }
                } else {
                    pos[bit] = i;
                }
            }
            ans[i] = j - i + 1;
        }
        return ans;
    }
}
```

```Go
func smallestSubarrays(nums []int) []int {
    n := len(nums)
    pos := make([]int, 31)
    for i := range pos {
        pos[i] = -1
    }
    ans := make([]int, n)
    for i := n - 1; i >= 0; i-- {
        j := i
        for bit := 0; bit < 31; bit++ {
            if (nums[i] & (1 << bit)) == 0 {
                if pos[bit] != -1 {
                    j = max(j, pos[bit])
                }
            } else {
                pos[bit] = i
            }
        }
        ans[i] = j - i + 1
    }
    return ans
}
```

```C
int* smallestSubarrays(int* nums, int numsSize, int* returnSize) {
    int* pos = (int*)malloc(31 * sizeof(int));
    memset(pos, -1, 31 * sizeof(int));
    int* ans = (int*)malloc(numsSize * sizeof(int));
    for (int i = numsSize - 1; i >= 0; --i) {
        int j = i;
        for (int bit = 0; bit < 31; ++bit) {
            if (!(nums[i] & (1 << bit))) {
                if (pos[bit] != -1) {
                    j = fmax(j, pos[bit]);
                }
            } else {
                pos[bit] = i;
            }
        }
        ans[i] = j - i + 1;
    }
    free(pos);
    *returnSize = numsSize;
    return ans;
}
```

```JavaScript
var smallestSubarrays = function(nums) {
    const n = nums.length;
    const pos = new Array(31).fill(-1);
    const ans = new Array(n);
    for (let i = n - 1; i >= 0; --i) {
        let j = i;
        for (let bit = 0; bit < 31; ++bit) {
            if (!(nums[i] & (1 << bit))) {
                if (pos[bit] !== -1) {
                    j = Math.max(j, pos[bit]);
                }
            } else {
                pos[bit] = i;
            }
        }
        ans[i] = j - i + 1;
    }
    return ans;
};
```

```TypeScript
function smallestSubarrays(nums: number[]): number[] {
    const n = nums.length;
    const pos: number[] = new Array(31).fill(-1);
    const ans: number[] = new Array(n);
    for (let i = n - 1; i >= 0; --i) {
        let j = i;
        for (let bit = 0; bit < 31; ++bit) {
            if (!(nums[i] & (1 << bit))) {
                if (pos[bit] !== -1) {
                    j = Math.max(j, pos[bit]);
                }
            } else {
                pos[bit] = i;
            }
        }
        ans[i] = j - i + 1;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn smallest_subarrays(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();
        let mut pos = vec![-1; 31];
        let mut ans = vec![0; n];
        for i in (0..n).rev() {
            let mut j = i;
            for bit in 0..31 {
                if (nums[i] & (1 << bit)) == 0 {
                    if pos[bit] != -1 {
                        j = j.max(pos[bit] as usize);
                    }
                } else {
                    pos[bit] = i as i32;
                }
            }
            ans[i] = (j - i + 1) as i32;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\times \log C)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 中的元素的范围。
- 空间复杂度：$O(\log C)$，即为数组 $pos$ 需要使用的空间。
