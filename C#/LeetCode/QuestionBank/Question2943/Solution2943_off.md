### [最大化网格图中正方形空洞的面积](https://leetcode.cn/problems/maximize-area-of-square-hole-in-grid/solutions/3878490/zui-da-hua-wang-ge-tu-zhong-zheng-fang-x-wbvk/)

#### 方法一：排序

**思路与算法**

题目要求通过移除部分横线段和竖线段，使剩余网格图中的正方形空洞面积最大。可以发现，正方形空洞的边长取决于移除的横向和纵向最大连续线段数目。因此，具体做法如下：

1. 首先对 $hBars$ 和 $vBars$ 从小到大进行排序，方便后续计算连续线段数目。
2. 分别遍历排序后的数组 $hBars$ 和 $vBars$，统计横向最大连续线段数目 $hmax$ 和纵向最大连续线段数目 $vmax$。
3. 计算最大正方形边长 $side$ 为 $min(hmax,vmax)+1$，返回面积即为边长的平方 $side^2$。

**代码**

```C++
class Solution {
public:
    int maximizeSquareHoleArea(int n, int m, vector<int>& hBars, vector<int>& vBars) {
        sort(hBars.begin(), hBars.end());
        sort(vBars.begin(), vBars.end());
        int hmax = 1, vmax = 1;
        int hcur = 1, vcur = 1;
        for (int i = 1; i < hBars.size(); i++) {
            if (hBars[i] == hBars[i - 1] + 1) {
                hcur++;
            } else {
                hcur = 1;
            }
            hmax = max(hmax, hcur);
        }
        for (int i = 1; i < vBars.size(); i++) {
            if (vBars[i] == vBars[i - 1] + 1) {
                vcur++;
            } else {
                vcur = 1;
            }
            vmax = max(vmax, vcur);
        }
        int side = min(hmax, vmax) + 1;
        return side * side;
    }
};
```

```Go
func maximizeSquareHoleArea(n int, m int, hBars []int, vBars []int) int {
    sort.Ints(hBars)
    sort.Ints(vBars)
    hmax, vmax := 1, 1
    hcur, vcur := 1, 1
    for i := 1; i < len(hBars); i++ {
        if hBars[i] == hBars[i - 1] + 1 {
            hcur++
        } else {
            hcur = 1
        }
        hmax = max(hmax, hcur)
    }
    for i := 1; i < len(vBars); i++ {
        if vBars[i] == vBars[i - 1] + 1 {
            vcur++
        } else {
            vcur = 1
        }
        vmax = max(vmax, vcur)
    }
    side := min(hmax, vmax) + 1
    return side * side
}
```

```Python
class Solution:
    def maximizeSquareHoleArea(self, n: int, m: int, hBars: List[int], vBars: List[int]) -> int:
        hBars.sort()
        vBars.sort()
        hmax, vmax = 1, 1
        hcur, vcur = 1, 1
        for i in range(1, len(hBars)):
            if hBars[i] == hBars[i - 1] + 1:
                hcur += 1
            else:
                hcur = 1
            hmax = max(hmax, hcur)
        for i in range(1, len(vBars)):
            if vBars[i] == vBars[i - 1] + 1:
                vcur += 1
            else:
                vcur = 1
            vmax = max(vmax, vcur)
        side = min(hmax, vmax) + 1
        return side * side
```

```Java
class Solution {
    public int maximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        Arrays.sort(hBars);
        Arrays.sort(vBars);
        int hmax = 1, vmax = 1;
        int hcur = 1, vcur = 1;
        for (int i = 1; i < hBars.length; i++) {
            if (hBars[i] == hBars[i - 1] + 1) {
                hcur++;
            } else {
                hcur = 1;
            }
            hmax = Math.max(hmax, hcur);
        }
        for (int i = 1; i < vBars.length; i++) {
            if (vBars[i] == vBars[i - 1] + 1) {
                vcur++;
            } else {
                vcur = 1;
            }
            vmax = Math.max(vmax, vcur);
        }
        int side = Math.min(hmax, vmax) + 1;
        return side * side;
    }
}
```

```TypeScript
function maximizeSquareHoleArea(n: number, m: number, hBars: number[], vBars: number[]): number {
    hBars.sort((a, b) => a - b);
    vBars.sort((a, b) => a - b);
    let hmax = 1, vmax = 1;
    let hcur = 1, vcur = 1;
    for (let i = 1; i < hBars.length; i++) {
        if (hBars[i] === hBars[i - 1] + 1) {
            hcur++;
        } else {
            hcur = 1;
        }
        hmax = Math.max(hmax, hcur);
    }
    for (let i = 1; i < vBars.length; i++) {
        if (vBars[i] === vBars[i - 1] + 1) {
            vcur++;
        } else {
            vcur = 1;
        }
        vmax = Math.max(vmax, vcur);
    }
    const side = Math.min(hmax, vmax) + 1;
    return side * side;
}
```

```JavaScript
function maximizeSquareHoleArea(n, m, hBars, vBars) {
    hBars.sort((a, b) => a - b);
    vBars.sort((a, b) => a - b);
    let hmax = 1, vmax = 1;
    let hcur = 1, vcur = 1;
    for (let i = 1; i < hBars.length; i++) {
        if (hBars[i] === hBars[i - 1] + 1) {
            hcur++;
        } else {
            hcur = 1;
        }
        hmax = Math.max(hmax, hcur);
    }
    for (let i = 1; i < vBars.length; i++) {
        if (vBars[i] === vBars[i - 1] + 1) {
            vcur++;
        } else {
            vcur = 1;
        }
        vmax = Math.max(vmax, vcur);
    }
    const side = Math.min(hmax, vmax) + 1;
    return side * side;
}
```

```CSharp
public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        Array.Sort(hBars);
        Array.Sort(vBars);
        int hmax = 1, vmax = 1;
        int hcur = 1, vcur = 1;
        for (int i = 1; i < hBars.Length; i++) {
            if (hBars[i] == hBars[i - 1] + 1) {
                hcur++;
            } else {
                hcur = 1;
            }
            hmax = Math.Max(hmax, hcur);
        }
        for (int i = 1; i < vBars.Length; i++) {
            if (vBars[i] == vBars[i - 1] + 1) {
                vcur++;
            } else {
                vcur = 1;
            }
            vmax = Math.Max(vmax, vcur);
        }
        int side = Math.Min(hmax, vmax) + 1;
        return side * side;
    }
}
```

```C
int compare(const void* a, const void* b) {
    return *(int*)a - *(int*)b;
}

int maximizeSquareHoleArea(int n, int m, int* hBars, int hBarsSize, int* vBars, int vBarsSize) {
    qsort(hBars, hBarsSize, sizeof(int), compare);
    qsort(vBars, vBarsSize, sizeof(int), compare);
    int hmax = 1, vmax = 1;
    int hcur = 1, vcur = 1;
    for (int i = 1; i < hBarsSize; i++) {
        if (hBars[i] == hBars[i - 1] + 1) {
            hcur++;
        } else {
            hcur = 1;
        }
        hmax = fmax(hmax, hcur);
    }
    for (int i = 1; i < vBarsSize; i++) {
        if (vBars[i] == vBars[i - 1] + 1) {
            vcur++;
        } else {
            vcur = 1;
        }
        vmax = fmax(vmax, vcur);
    }
    int side = fmin(hmax, vmax) + 1;
    return side * side;
}
```

```Rust
use std::cmp;

impl Solution {
    pub fn maximize_square_hole_area(n: i32, m: i32, mut h_bars: Vec<i32>, mut v_bars: Vec<i32>) -> i32 {
        h_bars.sort_unstable();
        v_bars.sort_unstable();
        let mut hmax = 1;
        let mut vmax = 1;
        let mut hcur = 1;
        let mut vcur = 1;
        for i in 1..h_bars.len() {
            if h_bars[i] == h_bars[i - 1] + 1 {
                hcur += 1;
            } else {
                hcur = 1;
            }
            hmax = cmp::max(hmax, hcur);
        }
        for i in 1..v_bars.len() {
            if v_bars[i] == v_bars[i - 1] + 1 {
                vcur += 1;
            } else {
                vcur = 1;
            }
            vmax = cmp::max(vmax, vcur);
        }
        let side = cmp::min(hmax, vmax) + 1;
        side * side
    }
}
```

**复杂度分析**

- 时间复杂度：$O(h\log h+v\log v)$，其中 $h$ 和 $v$ 分别为数组 $hBars$ 和 $vBars$ 的长度。对 $hBars$ 和 $vBars$ 排序分别需要 $O(h\log h)$ 和 $O(v\log v)$。
- 空间复杂度：$O(\log h+\log v)$。对 $hBars$ 和 $vBars$ 排序分别需要 $O(\log h)$ 和 $O(\log v)$ 的栈空间。
