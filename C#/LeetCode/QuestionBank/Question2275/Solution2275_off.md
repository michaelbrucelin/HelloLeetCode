### [按位与结果大于零的最长组合](https://leetcode.cn/problems/largest-combination-with-bitwise-and-greater-than-zero/solutions/1538671/an-wei-yu-jie-guo-da-yu-ling-de-zui-chan-hm7c/)

#### 方法一：逐位计算

**提示 1**

数组 $candidates$ 的某个组合按位与结果大于零，当且仅当至少存在一个特定的二进制位，该组合中的所有整数的该位数值均为 $1$。

**提示 1 解释**

上述命题的必要性显然。

对于充分性，我们可以通过证明其逆否命题来证明，即「如果组合中不存在任何二进制位使得所有元素在该位的数值均为 $1$，则该组合的按位与结果为 $0$」。该命题可以通过遍历所有存在该位为 $1$ 元素的二进制位证明。

**提示 2**

我们可以遍历所有存在该位为 $1$ 元素的二进制位，并统计这些位数值为 $1$ 的元素个数。这些个数的最大值即为按位与结果大于零的组合的最大长度。

**提示 2 解释**

首先，根据 **提示 1**，任何长度大于该最大值的组合都不会存在某一个数值均为 $1$ 的二进制位，因此该组合的按位与结果一定为 $0$。

其次，为了构造可以达到最大长度的按位与非零组合，我们只需要找到二进制位为 $1$ 元素数量最大的二进制位，并将该位数值为 $1$ 的元素挑选成为组合，此时该组合不仅按位与的结果非零，且该组合的长度等于最大长度。

**思路与算法**

根据 **提示 2**，我们可以遍历所有存在该位为 $1$ 元素的二进制位，并统计对应位数值为 $1$ 的元素个数及最大值。

对于二进制位的范围，由于 $candidates$ 中的整数的取值范围均在 $[1,10^7]$ 闭区间内，同时我们有 $2^23 < 10^7 < 2^24$，因此我们只需要遍历最低的 $24$ 个二进制位即可。

我们用 $res$ 来维护该最大值。在遍历二进制位时，我们用函数 $maxlen(k)$ 来表示 $candidates$ 中从低到高第 $k$ 位为 $1$ 的元素数量。具体地，我们遍历 $candidates$ 中的每个元素，检查该元素的第 $k$ 为是否为 $1$，并统计为 $1$ 的元素数量，最终返回该数量。

当遍历完成所有二进制位后，$res$ 即为 $candidates$ 中按位与非零组合的最大长度，我们返回该数值作为答案。

**代码**

```C++
class Solution {
public:
    int largestCombination(vector<int>& candidates) {
        // 计算从低到高第 k 个二进制位数值为 1 的元素个数
        auto maxlen = [&](int k) -> int {
            int res = 0;
            for (int num: candidates) {
                if (num & (1 << k)) {
                    ++res;
                }
            }
            return res;
        };
        
        int res = 0;
        for (int i = 0; i < 24; ++i) {
            // 遍历二进制位
            res = max(res, maxlen(i));
        }
        return res;
    }
};
```

```Python
class Solution:
    def largestCombination(self, candidates: List[int]) -> int:
        # 计算从低到高第 k 个二进制位数值为 1 的元素个数
        def maxlen(k: int):
            res = 0
            for num in candidates:
                if num & (1 << k):
                    res += 1
            return res
        
        res = 0
        for i in range(24):
            # 遍历二进制位
            res = max(res, maxlen(i))
        return res
```

```C
// 计算从低到高第 k 个二进制位数值为 1 的元素个数
int maxlen(int* candidates, int candidatesSize, int k) {
    int res = 0;
    for (int i = 0; i < candidatesSize; ++i) {
        if (candidates[i] & (1 << k)) {
            ++res;
        }
    }
    return res;
}

int largestCombination(int* candidates, int candidatesSize) {
    int res = 0;
    for (int i = 0; i < 24; ++i) {
        // 遍历二进制位
        res = fmax(res, maxlen(candidates, candidatesSize, i));
    }
    return res;
}
```

```Go
func largestCombination(candidates []int) int {
    // 计算从低到高第 k 个二进制位数值为 1 的元素个数
    maxlen := func(k int) int {
        res := 0
        for _, num := range candidates {
            if num & (1 << k) != 0 {
                res++
            }
        }
        return res
    }

    res := 0
    for i := 0; i < 24; i++ {
        // 遍历二进制位
        res = max(res, maxlen(i))
    }
    return res
}
```

```Java
class Solution {
    // 计算从低到高第 k 个二进制位数值为 1 的元素个数
    public int maxlen(int[] candidates, int k) {
        int res = 0;
        for (int num : candidates) {
            if ((num & (1 << k)) != 0) {
                res++;
            }
        }
        return res;
    }

    public int largestCombination(int[] candidates) {
        int res = 0;
        for (int i = 0; i < 24; i++) {
            // 遍历二进制位
            res = Math.max(res, maxlen(candidates, i));
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    // 计算从低到高第 k 个二进制位数值为 1 的元素个数
    public int Maxlen(int[] candidates, int k) {
        int res = 0;
        foreach (int num in candidates) {
            if ((num & (1 << k)) != 0) {
                res++;
            }
        }
        return res;
    }

    public int LargestCombination(int[] candidates) {
        int res = 0;
        for (int i = 0; i < 24; i++) {
            // 遍历二进制位
            res = Math.Max(res, Maxlen(candidates, i));
        }
        return res;
    }
}
```

```JavaScript
var largestCombination = function(candidates) {
    // 计算从低到高第 k 个二进制位数值为 1 的元素个数
    const maxlen = (k) => {
        let res = 0;
        for (let num of candidates) {
            if (num & (1 << k)) {
                res++;
            }
        }
        return res;
    };

    let res = 0;
    for (let i = 0; i < 24; i++) {
        // 遍历二进制位
        res = Math.max(res, maxlen(i));
    }
    return res;
};
```

```TypeScript
function largestCombination(candidates: number[]): number {
    // 计算从低到高第 k 个二进制位数值为 1 的元素个数
    const maxlen = (k: number): number => {
        let res = 0;
        for (let num of candidates) {
            if (num & (1 << k)) {
                res++;
            }
        }
        return res;
    };

    let res = 0;
    for (let i = 0; i < 24; i++) {
        // 遍历二进制位
        res = Math.max(res, maxlen(i));
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn largest_combination(candidates: Vec<i32>) -> i32 {
        // 计算从低到高第 k 个二进制位数值为 1 的元素个数
        fn maxlen(candidates: &Vec<i32>, k: i32) -> i32 {
            let mut res = 0;
            for &num in candidates.iter() {
                if num & (1 << k) != 0 {
                    res += 1;
                }
            }
            res
        }

        let mut res = 0;
        for i in 0..24 {
            // 遍历二进制位
            res = res.max(maxlen(&candidates, i));
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log M)$，其中 $n$ 为 $candidates$ 的长度，$M$ 为 $candidates$ 中元素的数值上界。我们总共需要枚举 $O(logM)$ 个二进制位，其中每个二进制位都需要 $O(n)$ 的时间遍历数组。
- 空间复杂度：$O(1)$。
