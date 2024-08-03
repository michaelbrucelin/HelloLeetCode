### [正方形中的最多点数](https://leetcode.cn/problems/maximum-points-inside-the-square/solutions/2862469/zheng-fang-xing-zhong-de-zui-duo-dian-sh-qd5w/)

#### 方法一：维护次小半径

**思路与算法**

我们定义正方形的半径为边长的一半，每个点所在正方形，其半径为点 $(x,y)$ 到 $(0,0)$ 的「切比雪夫距离」，即 $max(\vert x \vert,\vert y \vert)$。

对于每个字符，计算字符到原点的最小的半径，并维护所有字符的次小半径。根据题意，半径小于次小半径的正方形，是合法正方形。

最后遍历所有字符的最小距离，返回在合法正方形内的个数。

**代码**

```C++
class Solution {
public:
    int maxPointsInsideSquare(vector<vector<int>>& points, string s) {
        vector<int> min1(26, 1000000001);
        int min2 = 1000000001;
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            int x = points[i][0], y = points[i][1], j = s[i] - 'a';
            int d = max(abs(x), abs(y));
            if (d < min1[j]) {
                min2 = min(min2, min1[j]);
                min1[j] = d;
            } else if (d < min2) {
                min2 = d;
            }
        }
        int res = 0;
        for (int d : min1) {
            if (d < min2) {
                ++res;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int maxPointsInsideSquare(int[][] points, String s) {
        int[] min1 = new int[26];
        Arrays.fill(min1, 1000000001);
        int min2 = 1000000001, n = s.length();
        for (int i = 0; i < n; ++i) {
            int x = points[i][0], y = points[i][1], j = s.charAt(i) - 'a';
            int d = Math.max(Math.abs(x), Math.abs(y));
            if (d < min1[j]) {
                min2 = Math.min(min2, min1[j]);
                min1[j] = d;
            } else if (d < min2) {
                min2 = d;
            }
        }
        int res = 0;
        for (int d : min1) {
            if (d < min2) {
                ++res;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def maxPointsInsideSquare(self, points: List[List[int]], s: str) -> int:
        min1 = [inf] * 26
        min2 = inf
        n = len(s)
        for i in range(n):
            x, y = points[i]
            j = ord(s[i]) - ord('a')
            d = max(abs(x), abs(y))
            if d < min1[j]:
                min2 = min(min2, min1[j])
                min1[j] = d
            elif d < min2:
                min2 = d
        return sum(d < min2 for d in min1)
```

```JavaScript
var maxPointsInsideSquare = function(points, s) {
    const min1 = new Array(26).fill(1000000001);
    let min2 = 1000000001;
    const n = s.length;
    for (let i = 0; i < n; ++i) {
        const [x, y] = points[i];
        const j = s.charCodeAt(i) - 'a'.charCodeAt(0);
        const d = Math.max(Math.abs(x), Math.abs(y));
        if (d < min1[j]) {
            min2 = Math.min(min2, min1[j]);
            min1[j] = d;
        } else if (d < min2) {
            min2 = d;
        }
    }
    let res = 0;
    for (const d of min1) {
        if (d < min2) {
            ++res;
        }
    }
    return res;
};
```

```TypeScript
function maxPointsInsideSquare(points: number[][], s: string): number {
    const min1 = new Array(26).fill(1000000001);
    let min2 = 1000000001;
    const n = s.length;
    for (let i = 0; i < n; ++i) {
        const [x, y] = points[i];
        const j = s.charCodeAt(i) - 'a'.charCodeAt(0);
        const d = Math.max(Math.abs(x), Math.abs(y));
        if (d < min1[j]) {
            min2 = Math.min(min2, min1[j]);
            min1[j] = d;
        } else if (d < min2) {
            min2 = d;
        }
    }
    let res = 0;
    for (const d of min1) {
        if (d < min2) {
            ++res;
        }
    }
    return res;
};
```

```Go
func maxPointsInsideSquare(points [][]int, s string) int {
    min1 := make([]int, 26)
    for i := range min1 {
        min1[i] = 1000000001
    }
    min2 := 1000000001
    for i, ch := range s {
        x, y := points[i][0], points[i][1]
        j := int(ch - 'a')
        d := max(abs(x), abs(y))
        if d < min1[j] {
            min2 = min(min2, min1[j])
            min1[j] = d
        } else if d < min2 {
            min2 = d
        }
    }
    res := 0
    for _, d := range min1 {
        if d < min2 {
            res++
        }
    }
    return res
}

func abs(a int) int {
    if (a > 0) {
        return a
    }
    return -a
}
```

```CSharp
public class Solution {
    public int MaxPointsInsideSquare(int[][] points, string s) {
        int[] min1 = new int[26];
        Array.Fill(min1, 1000000001);
        int min2 = 1000000001;
        int n = s.Length;
        for (int i = 0; i < n; ++i) {
            int x = points[i][0], y = points[i][1], j = s[i] - 'a';
            int d = Math.Max(Math.Abs(x), Math.Abs(y));
            if (d < min1[j]) {
                min2 = Math.Min(min2, min1[j]);
                min1[j] = d;
            } else if (d < min2) {
                min2 = d;
            }
        }
        int res = 0;
        foreach (int d in min1) {
            if (d < min2) {
                ++res;
            }
        }
        return res;
    }
}
```

```C
int maxPointsInsideSquare(int** points, int pointsSize, int* pointsColSize, char* s) {
    int min1[26];
    for(int i = 0; i < 26; i++) {
        min1[i] = INT_MAX;
    }
    int min2 = INT_MAX;
    int n = pointsSize;
    for (int i = 0; i < n; ++i) {
        int x = points[i][0], y = points[i][1], j = s[i] - 'a';
        int d = (abs(x) > abs(y)) ? abs(x) : abs(y);
        if (d < min1[j]) {
            min2 = (min2 < min1[j]) ? min2 : min1[j];
            min1[j] = d;
        } else if (d < min2) {
            min2 = d;
        }
    }
    int res = 0;
    for (int i = 0; i < 26; i++) {
        if (min1[i] < min2) {
            ++res;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn max_points_inside_square(points: Vec<Vec<i32>>, s: String) -> i32 {
        let mut min1 = vec![1000000001; 26];
        let mut min2 = 1000000001;
        let n = s.len();
        for (i, ch) in s.chars().enumerate() {
            let x = points[i][0];
            let y = points[i][1];
            let j = (ch as u8 - b'a') as usize;
            let d = x.abs().max(y.abs());
            if d < min1[j] {
                min2 = min2.min(min1[j]);
                min1[j] = d;
            } else if d < min2 {
                min2 = d;
            }
        }
        let mut res = 0;
        for d in min1 {
            if d < min2 {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(\vert\sum\vert)$，其中 $\sum$ 是小写字符集的大小，$\sum=26$。
