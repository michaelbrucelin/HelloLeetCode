### [将所有元素变为 0 的最少操作次数](https://leetcode.cn/problems/minimum-operations-to-convert-all-elements-to-zero/solutions/3819899/jiang-suo-you-yuan-su-bian-wei-0-de-zui-6f2r3/)

#### 方法一：单调栈

**思路与算法**

首先通过观察发现：

- 规律一：把若干相同的最小值同时变为 $0$，可以节省操作次数。
- 规律二：如果两个相同的数之间有更小的数，则他们一定不同一起被变为 $0$。

我们遍历数组，维护一个单调递增栈，表示当前递增的非零元素序列。

对于每个元素 $a$，如果栈顶元素大于 $a$，根据规律二，栈顶元素不可能和之后的元素一起操作，需要弹出栈顶。 如果 $a$ 已经为 $0$，跳过，因为已经不需要操作。如果栈为空或栈顶元素小于 $a$，说明我们需要新的一次操作来覆盖 $a$，并把它加入栈，并把操作次数加一。

最后返回所有的操作次数。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<int>& nums) {
        vector<int> s;
        int res = 0;
        for (int a : nums) {
            while (!s.empty() && s.back() > a) {
                s.pop_back();
            }
            if (a == 0) continue;
            if (s.empty() || s.back() < a) {
                ++res;
                s.push_back(a);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int minOperations(int[] nums) {
        List<Integer> s = new ArrayList<>();
        int res = 0;
        for (int a : nums) {
            while (!s.isEmpty() && s.get(s.size() - 1) > a) {
                s.remove(s.size() - 1);
            }
            if (a == 0) continue;
            if (s.isEmpty() || s.get(s.size() - 1) < a) {
                res++;
                s.add(a);
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def minOperations(self, nums: List[int]) -> int:
        s = []
        res = 0
        for a in nums:
            while s and s[-1] > a:
                s.pop()
            if a == 0:
                continue
            if not s or s[-1] < a:
                res += 1
                s.append(a)
        return res
```

```JavaScript
var minOperations = function(nums) {
    const s = [];
    let res = 0;
    for (const a of nums) {
        while (s.length && s[s.length - 1] > a) {
            s.pop();
        }
        if (a === 0) continue;
        if (!s.length || s[s.length - 1] < a) {
            res++;
            s.push(a);
        }
    }
    return res;
};
```

```TypeScript
function minOperations(nums: number[]): number {
    const s = [];
    let res = 0;
    for (const a of nums) {
        while (s.length && s[s.length - 1] > a) {
            s.pop();
        }
        if (a === 0) continue;
        if (!s.length || s[s.length - 1] < a) {
            res++;
            s.push(a);
        }
    }
    return res;
};
```

```Go
func minOperations(nums []int) int {
    s := []int{}
    res := 0
    for _, a := range nums {
        for len(s) > 0 && s[len(s)-1] > a {
            s = s[:len(s)-1]
        }
        if a == 0 {
            continue
        }
        if len(s) == 0 || s[len(s)-1] < a {
            res++
            s = append(s, a)
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int MinOperations(int[] nums) {
        var s = new List<int>();
        int res = 0;
        foreach (int a in nums) {
            while (s.Count > 0 && s[s.Count - 1] > a) s.RemoveAt(s.Count - 1);
            if (a == 0) continue;
            if (s.Count == 0 || s[s.Count - 1] < a) {
                res++;
                s.Add(a);
            }
        }
        return res;
    }
}
```

```C
int minOperations(int* nums, int numsSize) {
    int *s = (int*)malloc(sizeof(int) * numsSize);
    if (!s) return 0; // allocation failure -> safe fallback
    int top = 0, res = 0;
    for (int i = 0; i < numsSize; ++i) {
        int a = nums[i];
        while (top > 0 && s[top - 1] > a) {
            --top;
        }
        if (a == 0) continue;
        if (top == 0 || s[top - 1] < a) {
            res++;
            s[top++] = a;
        }
    }
    free(s);
    return res;
}
```

```Rust
impl Solution {
    pub fn min_operations(nums: Vec<i32>) -> i32 {
        let mut s: Vec<i32> = Vec::new();
        let mut res: i32 = 0;
        for a in nums {
            while s.last().map_or(false, |&x| x > a) {
                s.pop();
            }
            if a == 0 { continue; }
            if s.last().map_or(true, |&x| x < a) {
                res += 1;
                s.push(a);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
