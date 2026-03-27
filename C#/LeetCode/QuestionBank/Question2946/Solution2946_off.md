### [循环移位后的矩阵相似检查](https://leetcode.cn/problems/matrix-similarity-after-cyclic-shifts/solutions/3929537/xun-huan-yi-wei-hou-de-ju-zhen-xiang-si-tta49/)

#### 方法一：遍历

**思路与算法**

判断某一行循环右移 $k$ 位后是否与之前完全相同，等价于将其循环左移 $k$ 位后是否与之前完全相同。本质上，都是在判断 $mat[i][j]$ 是否等于 $mat[i][(j+k)(\bmod n)]$，其中 $n$ 是列的个数。

因此，我们不需要区分是偶数行还是奇数行，在遍历每一行时，遇到发现不满足上述条件的，直接返回 $false$。

**代码**

```C++
class Solution {
public:
    bool areSimilar(vector<vector<int>>& mat, int k) {
        int m = mat.size(), n = mat[0].size();
        k %= n;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] != mat[i][(j + k) % n]) {
                    return false;
                }
            }
        }
        return true;
    }
};
```

```Python
class Solution:
    def areSimilar(self, mat: List[List[int]], k: int) -> bool:
        m, n = len(mat), len(mat[0])
        k %= n

        for i in range(m):
            for j in range(n):
                if mat[i][j] != mat[i][(j + k) % n]:
                    return False
        return True
```

```Rust
impl Solution {
    pub fn are_similar(mat: Vec<Vec<i32>>, k: i32) -> bool {
        let m = mat.len();
        let n = mat[0].len();
        let k = (k as usize) % n;

        for i in 0..m {
            for j in 0..n {
                if mat[i][j] != mat[i][(j + k) % n] {
                    return false;
                }
            }
        }
        true
    }
}
```

```Java
class Solution {
    public boolean areSimilar(int[][] mat, int k) {
        int m = mat.length;
        int n = mat[0].length;
        k %= n;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] != mat[i][(j + k) % n]) {
                    return false;
                }
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public bool AreSimilar(int[][] mat, int k) {
        int m = mat.Length;
        int n = mat[0].Length;
        k %= n;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] != mat[i][(j + k) % n]) {
                    return false;
                }
            }
        }
        return true;
    }
}
```

```Go
func areSimilar(mat [][]int, k int) bool {
    m := len(mat)
    n := len(mat[0])
    k %= n

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if mat[i][j] != mat[i][(j + k) % n] {
                return false
            }
        }
    }
    return true
}
```

```C
bool areSimilar(int** mat, int matSize, int* matColSize, int k) {
    int m = matSize;
    int n = matColSize[0];
    k %= n;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (mat[i][j] != mat[i][(j + k) % n]) {
                return false;
            }
        }
    }
    return true;
}
```

```JavaScript
var areSimilar = function(mat, k) {
    const m = mat.length;
    const n = mat[0].length;
    k %= n;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (mat[i][j] !== mat[i][(j + k) % n]) {
                return false;
            }
        }
    }
    return true;
};
```

```TypeScript
function areSimilar(mat: number[][], k: number): boolean {
    const m: number = mat.length;
    const n: number = mat[0].length;
    k %= n;

    for (let i: number = 0; i < m; i++) {
        for (let j: number = 0; j < n; j++) {
            if (mat[i][j] !== mat[i][(j + k) % n]) {
                return false;
            }
        }
    }
    return true;
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 是 $mat$ 的行数，$n$ 是 $mat$ 的列数。
- 空间复杂度：$O(1)$。
