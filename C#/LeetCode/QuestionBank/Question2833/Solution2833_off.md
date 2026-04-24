### [距离原点最远的点](https://leetcode.cn/problems/furthest-point-from-origin/solutions/3952146/ju-chi-yuan-dian-zui-yuan-de-dian-by-lee-j058/)

#### 方法一：一次遍历

**思路与算法**

令 $L$ 为 $move$ 中 $'L'$ 的数量，$R$ 为 $move$ 中 $'R'$ 的数量，$B$ 为 $move$ 中 $'\_'$ 的数量。

在不考虑 $'\_'$ 的情况下，当前位置与原点的距离为 $\vert L-R\vert $。为了使得最终位置距离原点最远，显然应该将所有 $'\_'$ 全部移动到与当前方向相同的方向，即最远距离为 $\vert L-R\vert +B$。

**代码**

```C++
class Solution {
public:
    int furthestDistanceFromOrigin(string moves) {
        int L = 0, R = 0, B = 0;
        for (auto c : moves) {
            if (c == 'L') {
                L++;
            } else if (c == 'R') {
                R++;
            } else {
                B++;
            }
        }
        return abs(L - R) + B;
    }
};
```

```Python
class Solution:
    def furthestDistanceFromOrigin(self, moves: str) -> int:
        return abs(moves.count('R') - moves.count('L')) + moves.count('_')
```

```Rust
impl Solution {
    pub fn furthest_distance_from_origin(moves: String) -> i32 {
        let (mut l, mut r, mut b) = (0, 0, 0);
        for c in moves.chars() {
            match c {
                'L' => l += 1,
                'R' => r += 1,
                '_' => b += 1,
                _ => (),
            }
        }
        (l as i32 - r as i32).abs() + b as i32
    }
}
```

```Java
class Solution {
    public int furthestDistanceFromOrigin(String moves) {
        int L = 0, R = 0, B = 0;
        for (char c : moves.toCharArray()) {
            if (c == 'L') {
                L++;
            } else if (c == 'R') {
                R++;
            } else {
                B++;
            }
        }
        return Math.abs(L - R) + B;
    }
}
```

```CSharp
public class Solution {
    public int FurthestDistanceFromOrigin(string moves) {
        int L = 0, R = 0, B = 0;
        foreach (char c in moves) {
            if (c == 'L') {
                L++;
            } else if (c == 'R') {
                R++;
            } else {
                B++;
            }
        }
        return Math.Abs(L - R) + B;
    }
}
```

```Go
func furthestDistanceFromOrigin(moves string) int {
    L, R, B := 0, 0, 0
    for _, c := range moves {
        if c == 'L' {
            L++
        } else if c == 'R' {
            R++
        } else {
            B++
        }
    }
    return int(math.Abs(float64(L-R))) + B
}
```

```C
int furthestDistanceFromOrigin(char* moves) {
    int L = 0, R = 0, B = 0;
    int len = strlen(moves);
    for (int i = 0; i < len; i++) {
        char c = moves[i];
        if (c == 'L') {
            L++;
        } else if (c == 'R') {
            R++;
        } else {
            B++;
        }
    }
    return abs(L - R) + B;
}
```

```JavaScript
var furthestDistanceFromOrigin = function(moves) {
    let L = 0, R = 0, B = 0;
    for (const c of moves) {
        if (c === 'L') {
            L++;
        } else if (c === 'R') {
            R++;
        } else {
            B++;
        }
    }
    return Math.abs(L - R) + B;
};
```

```TypeScript
function furthestDistanceFromOrigin(moves: string): number {
    let L = 0, R = 0, B = 0;
    for (const c of moves) {
        if (c === 'L') {
            L++;
        } else if (c === 'R') {
            R++;
        } else {
            B++;
        }
    }
    return Math.abs(L - R) + B;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$。其中 $n$ 为 $move$ 的长度。
- 空间复杂度：$O(1)$。
