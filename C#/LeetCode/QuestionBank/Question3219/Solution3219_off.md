### [切蛋糕的最小总开销 II](https://leetcode.cn/problems/minimum-cost-for-cutting-cake-ii/solutions/3024578/qie-dan-gao-de-zui-xiao-zong-kai-xiao-ii-oisi/)

#### 方法一：贪心

**思路**

我们先尝试按照两种顺序切，第一种顺序是横着切一次，竖着沿着一条线连续切两次，开销是 $horizontalCut[i]+2 \times verticalCut[j]$；第二种顺序是竖着切一次，横着沿着一条线连续切两次，开销是 $verticalCut[j]+2 \times horizontalCut[j]$。这么一比较，这两种顺序的切法，切出来的一样的，但是开销却有不同。贪心地看，第一刀应该选择开销最大的线来切。因此，我们就提出一个贪心的猜想，将 $horizontalCut$ 和 $verticalCut$ 分别排序，每次切的时候都挑选最大的开销，并切到底。

接下来证明，按照这样的顺序，交换相邻两刀，不会使得开销更小。假设当前蛋糕已经沿着水平线切了 $p$ 刀，沿着垂直线切了 $q$ 刀。我们尝试交换接下来两刀：

- 如果接下来两刀都是水平或者垂直，那么交换这两刀对开销不会产生任何影响。
- 如果先是一刀水平，再是一刀垂直，那么开销就是 $(q+1) \times horizontalCut[i]+(p+2) \times verticalCut[j]$。如果我们交换这两刀的顺序，那么开销就是 $(q+2) \times horizontalCut[i]+(p+1) \times verticalCut[j]$。因为是原来是先切水平，再切垂直，那么会有 $horizontalCut[i] \ge verticalCut[j]$。因此，交换顺序并不会使得开销变小。
- 如果先是一刀垂直，再是一刀水平。相似的论证，交换顺序并不会使得开销变小。

因此，按照这样的顺序，交换相邻两刀，不会使得开销更小。而交换任意两刀的顺序，可以通过多次交换相邻两刀的顺序得到。因此，交换任意两刀，不会使得开销更小。

**代码**

```Python
class Solution:
    def minimumCost(self, m: int, n: int, H: List[int], V: List[int]) -> int:  
        H.sort(), V.sort()
        h, v = 1, 1
        res = 0
        while H or V:
            if not V or (H and H[-1] > V[-1]):
                res += H.pop() * h
                v += 1
            else:
                res += V.pop() * v
                h += 1
        return res
```

```Java
class Solution {
    public long minimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        Arrays.sort(horizontalCut);
        Arrays.sort(verticalCut);
        int h = 1, v = 1;
        long res = 0;
        int horizontalIndex = horizontalCut.length - 1, verticalIndex = verticalCut.length - 1;
        while (horizontalIndex >= 0 || verticalIndex >= 0) {
            if (verticalIndex < 0 || (horizontalIndex >= 0 && horizontalCut[horizontalIndex] > verticalCut[verticalIndex])) {
                res += horizontalCut[horizontalIndex--] * h;
                v++;
            } else {
                res += verticalCut[verticalIndex--] * v;
                h++;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        Array.Sort(horizontalCut);
        Array.Sort(verticalCut);
        int h = 1, v = 1;
        long res = 0;
        int horizontalIndex = horizontalCut.Length - 1, verticalIndex = verticalCut.Length - 1;
        while (horizontalIndex >= 0 || verticalIndex >= 0) {
            if (verticalIndex < 0 || (horizontalIndex >= 0 && horizontalCut[horizontalIndex] > verticalCut[verticalIndex])) {
                res += horizontalCut[horizontalIndex--] * h;
                v++;
            } else {
                res += verticalCut[verticalIndex--] * v;
                h++;
            }
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    long long minimumCost(int m, int n, vector<int>& horizontalCut, vector<int>& verticalCut) {
        sort(horizontalCut.begin(), horizontalCut.end());
        sort(verticalCut.begin(), verticalCut.end());
        long long h = 1, v = 1;
        long long res = 0;
        while (!horizontalCut.empty() || !verticalCut.empty()) {
            if (verticalCut.empty() || !horizontalCut.empty() && horizontalCut.back() > verticalCut.back()) {
                res += horizontalCut.back() * h;
                horizontalCut.pop_back();
                v++;
            } else {
                res += verticalCut.back() * v;
                verticalCut.pop_back();
                h++;
            }
        }
        return res;
    }
};
```

```Go
func minimumCost(m int, n int, horizontalCut []int, verticalCut []int) int64 {
    sort.Ints(horizontalCut)
    sort.Ints(verticalCut)
    h, v := 1, 1
    var res int64
    for len(horizontalCut) > 0 || len(verticalCut) > 0 {
        if len(verticalCut) == 0 || len(horizontalCut) > 0 && horizontalCut[len(horizontalCut) - 1] > verticalCut[len(verticalCut) - 1] {
            res += int64(horizontalCut[len(horizontalCut) - 1] * h)
            horizontalCut = horizontalCut[:len(horizontalCut) - 1]
            v++
        } else {
            res += int64(verticalCut[len(verticalCut) - 1] * v)
            verticalCut = verticalCut[:len(verticalCut) - 1]
            h++
        }
    }
    return res
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)b - *(int*)a);
}

long long minimumCost(int m, int n, int* horizontalCut, int horizontalCutSize, int* verticalCut, int verticalCutSize) {
    qsort(horizontalCut, horizontalCutSize, sizeof(int), compare);
    qsort(verticalCut, verticalCutSize, sizeof(int), compare);
    long long h = 1, v = 1;
    long long res = 0;
    int hIndex = 0, vIndex = 0;
    while (hIndex < horizontalCutSize || vIndex < verticalCutSize) {
        if (vIndex == verticalCutSize || (hIndex < horizontalCutSize && horizontalCut[hIndex] > verticalCut[vIndex])) {
            res += horizontalCut[hIndex++] * h;
            v++;
        } else {
            res += verticalCut[vIndex++] * v;
            h++;
        }
    }
    return res;
}
```

```JavaScript
var minimumCost = function(m, n, horizontalCut, verticalCut) {
    horizontalCut.sort((a, b) => a - b);
    verticalCut.sort((a, b) => a - b);
    let h = 1, v = 1;
    let res = 0;
    while (horizontalCut.length || verticalCut.length) {
        if (!verticalCut.length || (horizontalCut.length && horizontalCut[horizontalCut.length - 1] > verticalCut[verticalCut.length - 1])) {
            res += horizontalCut[horizontalCut.length - 1] * h;
            horizontalCut.pop();
            v++;
        } else {
            res += verticalCut[verticalCut.length - 1] * v;
            verticalCut.pop();
            h++;
        }
    }
    return res;
};
```

```TypeScript
function minimumCost(m: number, n: number, horizontalCut: number[], verticalCut: number[]): number {
    horizontalCut.sort((a, b) => a - b);
    verticalCut.sort((a, b) => a - b);
    let h = 1, v = 1;
    let res = 0;
    while (horizontalCut.length || verticalCut.length) {
        if (!verticalCut.length || (horizontalCut.length && horizontalCut[horizontalCut.length - 1] > verticalCut[verticalCut.length - 1])) {
            res += horizontalCut[horizontalCut.length - 1] * h;
            horizontalCut.pop();
            v++;
        } else {
            res += verticalCut[verticalCut.length - 1] * v;
            verticalCut.pop();
            h++;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn minimum_cost(m: i32, n: i32, horizontal_cut: Vec<i32>, vertical_cut: Vec<i32>) -> i64 {
        let mut horizontal_cut = horizontal_cut.into_iter().collect::<Vec<_>>();
        let mut vertical_cut = vertical_cut.into_iter().collect::<Vec<_>>();
        horizontal_cut.sort_unstable();
        vertical_cut.sort_unstable();
        let mut h = 1;
        let mut v = 1;
        let mut res = 0i64;
        while !horizontal_cut.is_empty() || !vertical_cut.is_empty() {
            if vertical_cut.is_empty() || (!horizontal_cut.is_empty() && horizontal_cut.last().unwrap() > vertical_cut.last().unwrap()) {
                res += (*horizontal_cut.last().unwrap() as i64) * h as i64;
                horizontal_cut.pop();
                v += 1;
            } else {
                res += (*vertical_cut.last().unwrap() as i64) * v as i64;
                vertical_cut.pop();
                h += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m \times logm+n \times logn)$。
- 空间复杂度：$O(logm+logn)$。
