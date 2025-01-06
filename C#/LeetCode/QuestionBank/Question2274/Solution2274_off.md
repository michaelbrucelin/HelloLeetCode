### [不含特殊楼层的最大连续楼层数](https://leetcode.cn/problems/maximum-consecutive-floors-without-special-floors/solutions/1501551/bu-han-te-shu-lou-ceng-de-zui-da-lian-xu-ktg1/)

#### 方法一：排序

**思路与算法**

如果我们将给定的数组 $special$ 按照升序排序，那么相邻两个元素之间的楼层就都不是特殊楼层。如果相邻的两个元素分别为 $x,y$，那么非特殊楼层的数量即为 $y-x-1$。

但这样会忽略最开始和结束的非特殊楼层，因此我们可以在排序前将 $bottom-1$ 和 $top+1$ 也放入数组中，一起进行排序。这样一来，所有 $y-x-1$ 中的最大值即为答案。

**代码**

```C++
class Solution {
public:
    int maxConsecutive(int bottom, int top, vector<int>& special) {
        special.push_back(bottom - 1);
        special.push_back(top + 1);
        sort(special.begin(), special.end());

        int n = special.size();
        int ans = 0;
        for (int i = 0; i < n - 1; ++i) {
            ans = max(ans, special[i + 1] - special[i] - 1);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maxConsecutive(self, bottom: int, top: int, special: List[int]) -> int:
        special.extend([bottom - 1, top + 1])
        special.sort()
        
        n = len(special)
        ans = 0
        for i in range(n - 1):
            ans = max(ans, special[i + 1] - special[i] - 1)
        return ans
```

```Go
func maxConsecutive(bottom int, top int, special []int) int {
    special = append(special, bottom - 1)
    special = append(special, top + 1)
    sort.Ints(special)
    ans := 0
    for i := 0; i < len(special) - 1; i++ {
        ans = max(ans, special[i + 1] - special[i] - 1)
    }
    return ans
}
```

```Java
class Solution {
    public int maxConsecutive(int bottom, int top, int[] special) {
        Arrays.sort(special);
        int ans = 0;
        ans = Math.max(ans, special[0] - bottom);
        for (int i = 1; i < special.length; ++i) {
            ans = Math.max(ans, special[i] - special[i - 1] - 1);
        }
        ans = Math.max(ans, top - special[special.length - 1]);
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxConsecutive(int bottom, int top, int[] special) {
        Array.Sort(special);
        int ans = 0;
        ans = Math.Max(ans, special[0] - bottom);
        for (int i = 1; i < special.Length; ++i) {
            ans = Math.Max(ans, special[i] - special[i - 1] - 1);
        }
        ans = Math.Max(ans, top - special[special.Length - 1]);
        return ans;
    }
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int maxConsecutive(int bottom, int top, int* special, int specialSize) {
    qsort(special, specialSize, sizeof(int), compare);
    int ans = 0;
    ans = fmax(special[0] - bottom, ans);
    for (int i = 1; i < specialSize; ++i) {
        ans = fmax(ans, special[i] - special[i - 1] - 1);
    }
    ans = fmax(ans, top - special[specialSize - 1]);
    return ans;
}
```

```JavaScript
var maxConsecutive = function(bottom, top, special) {
    special.push(bottom - 1);
    special.push(top + 1);
    special.sort((a, b) => a - b);
    let ans = 0;
    for (let i = 0; i < special.length - 1; ++i) {
        ans = Math.max(ans, special[i + 1] - special[i] - 1);
    }
    return ans;
};
```

```TypeScript
function maxConsecutive(bottom: number, top: number, special: number[]): number {
    special.push(bottom - 1);
    special.push(top + 1);
    special.sort((a, b) => a - b);
    let ans = 0;
    for (let i = 0; i < special.length - 1; ++i) {
        ans = Math.max(ans, special[i + 1] - special[i] - 1);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn max_consecutive(bottom: i32, top: i32, special: Vec<i32>) -> i32 {
        let mut special = special;
        special.push(bottom - 1);
        special.push(top + 1);
        special.sort();
        let mut ans = 0;
        for i in 0..special.len() - 1 {
            ans = ans.max(special[i + 1] - special[i] - 1);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 是数组 $special$ 的长度。
- 空间复杂度：$O(logn)$，即为排序需要使用的栈空间。
