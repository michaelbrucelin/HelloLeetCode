### [交替组 II](https://leetcode.cn/problems/alternating-groups-ii/solutions/2986846/jiao-ti-zu-ii-by-leetcode-solution-7912/)

#### 方法一：模拟

**思路**

遍历数组 $colors$，用一个整数 $cnt$ 代表遍历到当前元素时，已经有的连续交替瓷砖的数量。如果当前元素与前一个元素不同，则将 $cnt$ 加 $1$，否则将其置为 $1$。 如果当前 $cnt$ 大于等于 $k$，则将结果加 $1$。注意到瓷砖是环形的，因此，在遍历第一个数组时，我们就需要知道当前的 $cnt$。为了得到初始的 $cnt$ 值，我们需要将遍历的起点往前推 $k-2$ 步，这样在遍历到数组的第一个元素时，我们就可以知道当前是否有 $k$ 块连续的交替瓷砖。最后返回结果。

**代码**

```Python
class Solution:
    def numberOfAlternatingGroups(self, colors: List[int], k: int) -> int:
        n = len(colors)
        res, cnt = 0, 1
        for i in range(-k + 2, n, 1):
            if colors[i] != colors[i - 1]:
                cnt += 1
            else:
                cnt = 1
            if cnt >= k:
                res += 1
        return res
```

```Java
class Solution {
    public int numberOfAlternatingGroups(int[] colors, int k) {
        int n = colors.length;
        int res = 0, cnt = 1;
        for (int i = -k + 2; i < n; i++) {
            if (colors[(i + n) % n] != colors[(i - 1 + n) % n]) {
                cnt += 1;
            } else {
                cnt = 1;
            }
            if (cnt >= k) {
                res += 1;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfAlternatingGroups(int[] colors, int k) {
        int n = colors.Length;
        int res = 0, cnt = 1;
        for (int i = -k + 2; i < n; i++) {
            if (colors[(i + n) % n] != colors[(i - 1 + n) % n]) {
                cnt += 1;
            } else {
                cnt = 1;
            }
            if (cnt >= k) {
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
    int numberOfAlternatingGroups(vector<int>& colors, int k) {
        int n = colors.size();
        int res = 0, cnt = 1;
        for (int i = -k + 2; i < n; i++) {
            if (colors[(i + n) % n] != colors[(i - 1 + n) % n]) {
                cnt += 1;
            } else {
                cnt = 1;
            }
            if (cnt >= k) {
                res += 1;
            }
        }
        return res;
    }
};
```

```Go
func numberOfAlternatingGroups(colors []int, k int) int {
    n := len(colors)
    res, cnt := 0, 1
    for i := -k + 2; i < n; i++ {
        if colors[(i + n) % n] != colors[(i - 1 + n) % n] {
            cnt++
        } else {
            cnt = 1
        }
        if cnt >= k {
            res++
        }
    }
    return res
}
```

```C
int numberOfAlternatingGroups(int* colors, int colorsSize, int k) {
    int res = 0, cnt = 1;
    for (int i = -k + 2; i < colorsSize; i++) {
        if (colors[(i + colorsSize) % colorsSize] != colors[(i - 1 + colorsSize) % colorsSize]) {
            cnt += 1;
        } else {
            cnt = 1;
        }
        if (cnt >= k) {
            res += 1;
        }
    }
    return res;
}
```

```JavaScript
var numberOfAlternatingGroups = function(colors, k) {
    const n = colors.length;
    let res = 0, cnt = 1;
    for (let i = -k + 2; i < n; i++) {
        if (colors[(i + n) % n] !== colors[(i - 1 + n) % n]) {
            cnt++;
        } else {
            cnt = 1;
        }
        if (cnt >= k) {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function numberOfAlternatingGroups(colors: number[], k: number): number {
    const n = colors.length;
    let res = 0, cnt = 1;
    for (let i = -k + 2; i < n; i++) {
        if (colors[(i + n) % n] !== colors[(i - 1 + n) % n]) {
            cnt++;
        } else {
            cnt = 1;
        }
        if (cnt >= k) {
            res++;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn number_of_alternating_groups(colors: Vec<i32>, k: i32) -> i32 {
        let n = colors.len() as i32;
        let mut res = 0;
        let mut cnt = 1;
        for i in (-k + 2)..n {
            if colors[((i + n) % n) as usize] != colors[((i - 1 + n) % n) as usize] {
                cnt += 1;
            } else {
                cnt = 1;
            }
            if cnt >= k {
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
