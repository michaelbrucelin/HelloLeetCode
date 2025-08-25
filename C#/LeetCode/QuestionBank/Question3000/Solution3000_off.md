### [对角线最长的矩形的面积](https://leetcode.cn/problems/maximum-area-of-longest-diagonal-rectangle/solutions/3756161/dui-jiao-xian-zui-chang-de-ju-xing-de-mi-t0ux/)

#### 方法一：遍历

**思路与算法**

遍历所有长方形：

- 根据勾股定理，求出长方形的对角线的平方 $diaS_q$。
- 根据长方形面积公式，求出长方形的面积 $area$。

比较对角线的长度：

- 等于当前最大的对角线平方，比较面积最大值并更新。
- 大于当前最大的对角线平方，更新对角线平方最大值，并更新面积最大值。

最后返回面积最大值即可。

**代码**

```C++
class Solution {
public:
    int areaOfMaxDiagonal(vector<vector<int>>& dimensions) {
        int maxDiaSq = 0, maxArea = 0;
        for (const auto& dim : dimensions) {
            int l = dim[0], w = dim[1];
            int diaSq = l * l + w * w, area = l * w;
            if (diaSq > maxDiaSq) {
                maxDiaSq = diaSq;
                maxArea = area;
            } else if (diaSq == maxDiaSq) {
                maxArea = max(maxArea, area);
            }
        }
        return maxArea;
    }
};
```

```Java
class Solution {
    public int areaOfMaxDiagonal(int[][] dimensions) {
        int maxDiaSq = 0;
        int maxArea = 0;
        for (int[] dim : dimensions) {
            int l = dim[0];
            int w = dim[1];
            int diaSq = l * l + w * w;
            int area = l * w;
            if (diaSq > maxDiaSq) {
                maxDiaSq = diaSq;
                maxArea = area;
            } else if (diaSq == maxDiaSq) {
                maxArea = Math.max(maxArea, area);
            }
        }
        return maxArea;
    }
}
```

```Python
class Solution:
    def areaOfMaxDiagonal(self, dimensions: List[List[int]]) -> int:
        max_dia_sq = 0
        max_area = 0
        for l, w in dimensions:
            dia_sq = l * l + w * w
            area = l * w
            if dia_sq > max_dia_sq:
                max_dia_sq = dia_sq
                max_area = area
            elif dia_sq == max_dia_sq:
                max_area = max(max_area, area)
        return max_area
```

```JavaScript
var areaOfMaxDiagonal = function(dimensions) {
    let maxDiaSq = 0;
    let maxArea = 0;
    for (const dim of dimensions) {
        const l = dim[0];
        const w = dim[1];
        const diaSq = l * l + w * w;
        const area = l * w;
        if (diaSq > maxDiaSq) {
            maxDiaSq = diaSq;
            maxArea = area;
        } else if (diaSq === maxDiaSq) {
            maxArea = Math.max(maxArea, area);
        }
    }
    return maxArea;
};
```

```TypeScript
function areaOfMaxDiagonal(dimensions: number[][]): number {
    let maxDiaSq = 0;
    let maxArea = 0;
    for (const dim of dimensions) {
        const l = dim[0];
        const w = dim[1];
        const diaSq = l * l + w * w;
        const area = l * w;
        if (diaSq > maxDiaSq) {
            maxDiaSq = diaSq;
            maxArea = area;
        } else if (diaSq === maxDiaSq) {
            maxArea = Math.max(maxArea, area);
        }
    }
    return maxArea;
};
```

```Go
func areaOfMaxDiagonal(dimensions [][]int) int {
    maxDiaSq := 0
    maxArea := 0
    for _, dim := range dimensions {
        l := dim[0]
        w := dim[1]
        diaSq := l*l + w*w
        area := l*w
        if diaSq > maxDiaSq {
            maxDiaSq = diaSq
            maxArea = area
        } else if diaSq == maxDiaSq {
            if area > maxArea {
                maxArea = area
            }
        }
    }
    return maxArea
}
```

```CSharp
public class Solution {
    public int AreaOfMaxDiagonal(int[][] dimensions) {
        int maxDiaSq = 0;
        int maxArea = 0;
        foreach (var dim in dimensions) {
            int l = dim[0];
            int w = dim[1];
            int diaSq = l * l + w * w;
            int area = l * w;
            if (diaSq > maxDiaSq) {
                maxDiaSq = diaSq;
                maxArea = area;
            } else if (diaSq == maxDiaSq) {
                maxArea = Math.Max(maxArea, area);
            }
        }
        return maxArea;
    }
}
```

```C
int areaOfMaxDiagonal(int** dimensions, int dimensionsSize, int* dimensionsColSize) {
    int maxDiaSq = 0;
    int maxArea = 0;
    for (int i = 0; i < dimensionsSize; i++) {
        int l = dimensions[i][0];
        int w = dimensions[i][1];
        int diaSq = l * l + w * w;
        int area = l * w;
        if (diaSq > maxDiaSq) {
            maxDiaSq = diaSq;
            maxArea = area;
        } else if (diaSq == maxDiaSq) {
            if (area > maxArea) {
                maxArea = area;
            }
        }
    }
    return maxArea;
}
```

```Rust
impl Solution {
    pub fn area_of_max_diagonal(dimensions: Vec<Vec<i32>>) -> i32 {
        let mut max_dia_sq = 0;
        let mut max_area = 0;
        for dim in dimensions {
            let l = dim[0];
            let w = dim[1];
            let dia_sq = l * l + w * w;
            let area = l * w;
            if dia_sq > max_dia_sq {
                max_dia_sq = dia_sq;
                max_area = area;
            } else if dia_sq == max_dia_sq {
                max_area = std::cmp::max(max_area, area);
            }
        }
        max_area
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。
