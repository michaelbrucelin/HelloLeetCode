### [找到最近的人](https://leetcode.cn/problems/find-closest-person/solutions/3762861/zhao-dao-zui-jin-de-ren-by-leetcode-solu-sq71/)

#### 方法一：数学

根据题意，第 $1$ 个人和第 $2$ 个人以相同的速度向第 $3$ 个人移动，那么与第 $3$ 个人的距离越近，越先到达。计算第 $1$ 个人与第 $3$ 个人的距离 $d_{xz}=\vert x-z\vert$，第 $2$ 个人与第 $3$ 个人的距离 $d_{yz}=\vert y-z\vert$，那么：

- $d_{xz}<d_{yz}$ 时，返回 $1$
- $d_{xz}>d_{yz}$ 时，返回 $2$
- 否则，返回 $0$

```C++
class Solution {
public:
    int findClosest(int x, int y, int z) {
        int dxz = abs(x - z), dyz = abs(y - z);
        if (dxz < dyz) {
            return 1;
        } else if (dxz > dyz) {
            return 2;
        } else {
            return 0;
        }
    }
};
```

```Go
func findClosest(x int, y int, z int) int {
    dxz := int(math.Abs(float64(x - z)))
    dyz := int(math.Abs(float64(y - z)))
    if dxz < dyz {
        return 1
    } else if dxz > dyz {
        return 2
    } else {
        return 0
    }
}
```

```Python
class Solution:
    def findClosest(self, x: int, y: int, z: int) -> int:
        dxz = abs(x - z)
        dyz = abs(y - z)
        if dxz < dyz:
            return 1
        elif dxz > dyz:
            return 2
        else:
            return 0
```

```Java
class Solution {
    public int findClosest(int x, int y, int z) {
        int dxz = Math.abs(x - z), dyz = Math.abs(y - z);
        if (dxz < dyz) {
            return 1;
        } else if (dxz > dyz) {
            return 2;
        } else {
            return 0;
        }
    }
}
```

```TypeScript
function findClosest(x: number, y: number, z: number): number {
    const dxz = Math.abs(x - z), dyz = Math.abs(y - z);
    if (dxz < dyz) {
        return 1;
    } else if (dxz > dyz) {
        return 2;
    } else {
        return 0;
    }
};
```

```JavaScript
var findClosest = function(x, y, z) {
    const dxz = Math.abs(x - z), dyz = Math.abs(y - z);
    if (dxz < dyz) {
        return 1;
    } else if (dxz > dyz) {
        return 2;
    } else {
        return 0;
    }
};
```

```CSharp
public class Solution {
    public int FindClosest(int x, int y, int z) {
        int dxz = Math.Abs(x - z), dyz = Math.Abs(y - z);
        if (dxz < dyz) {
            return 1;
        } else if (dxz > dyz) {
            return 2;
        } else {
            return 0;
        }
    }
}
```

```C
int findClosest(int x, int y, int z) {
    int dxz = abs(x - z), dyz = abs(y - z);
    if (dxz < dyz) {
        return 1;
    } else if (dxz > dyz) {
        return 2;
    } else {
        return 0;
    }
}
```

```Rust
impl Solution {
    pub fn find_closest(x: i32, y: i32, z: i32) -> i32 {
        let dxz = (x - z).abs();
        let dyz = (y - z).abs();
        if dxz < dyz {
            1
        } else if dxz > dyz {
            2
        } else {
            0
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
