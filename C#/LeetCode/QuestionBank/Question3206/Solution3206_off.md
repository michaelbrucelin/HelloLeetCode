### [交替组 I](https://leetcode.cn/problems/alternating-groups-i/solutions/2986844/jiao-ti-zu-i-by-leetcode-solution-k6sf/)

#### 方法一：模拟

**思路**

按照题意遍历数组 $colors$ 的每个元素，判断其前一个元素和后一个元素是否都与当前元素不同，如果满足，则将结果加 $1$。注意瓷砖是环形的，则数组的首尾元素是相邻的。最后返回结果。

**代码**

```Python
class Solution:
    def numberOfAlternatingGroups(self, colors: List[int]) -> int:
        n = len(colors)
        res = 0
        for i in range(n):
            if colors[i] != colors[i - 1] and colors[i] != colors[(i + 1) % n]:
                res += 1
        return res
```

```Java
class Solution {
    public int numberOfAlternatingGroups(int[] colors) {
        int n = colors.length;
        int res = 0;
        for (int i = 0; i < n; i++) {
            if (colors[i] != colors[(i - 1 + n) % n] && colors[i] != colors[(i + 1) % n]) {
                res += 1;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfAlternatingGroups(int[] colors) {
        int n = colors.Length;
        int res = 0;
        for (int i = 0; i < n; i++) {
            if (colors[i] != colors[(i - 1 + n) % n] && colors[i] != colors[(i + 1) % n]) {
                res += 1;
            }
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    int numberOfAlternatingGroups(vector<int>& colors) {
        int n = colors.size();
        int res = 0;
        for (int i = 0; i < n; i++) {
            if (colors[i] != colors[(i - 1 + n) % n] && colors[i] != colors[(i + 1) % n]) {
                res += 1;
            }
        }
        return res;
    }
};
```

```Go
func numberOfAlternatingGroups(colors []int) int {
    n := len(colors)
    res := 0
    for i := 0; i < n; i++ {
        if colors[i] != colors[(i-1+n)%n] && colors[i] != colors[(i+1)%n] {
            res++
        }
    }
    return res
}
```

```C
int numberOfAlternatingGroups(int* colors, int colorsSize) {
    int res = 0;
    for (size_t i = 0; i < colorsSize; i++) {
        if (colors[i] != colors[(i - 1 + colorsSize) % colorsSize] && colors[i] != colors[(i + 1) % colorsSize]) {
            res += 1;
        }
    }
    return res;
}
```

```JavaScript
var numberOfAlternatingGroups = function(colors) {
    const n = colors.length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        if (colors[i] !== colors[(i - 1 + n) % n] && colors[i] !== colors[(i + 1) % n]) {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function numberOfAlternatingGroups(colors: number[]): number {
    const n = colors.length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        if (colors[i] !== colors[(i - 1 + n) % n] && colors[i] !== colors[(i + 1) % n]) {
            res++;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn number_of_alternating_groups(colors: Vec<i32>) -> i32 {
        let n = colors.len();
        let mut res = 0;
        for i in 0..n {
            if colors[i] != colors[(i + n - 1) % n] && colors[i] != colors[(i + 1) % n] {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
