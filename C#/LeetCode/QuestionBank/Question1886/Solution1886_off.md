### [判断矩阵经轮转后是否一致](https://leetcode.cn/problems/determine-whether-matrix-can-be-obtained-by-rotation/solutions/815371/pan-duan-ju-zhen-jing-lun-zhuan-hou-shi-qa9d0/)

#### 方法一：模拟轮转操作

**提示 1**

将一个矩阵 $90$ 度顺时针旋转 $4$ 次，旋转后的矩阵与本身一致。

**思路与算法**

根据 **提示 1**，我们可以模拟 $4$ 次将 $mat 90$ 度顺时针旋转的操作，并在每次旋转操作后与 $target$ 比较。

对于旋转操作，可以建立额外数组实现，也可以原地旋转。不同方法的具体细节与相关推导读者可以参考[「48. 旋转图像」的题解](https://leetcode-cn.com/problems/rotate-image/solution/xuan-zhuan-tu-xiang-by-leetcode-solution-vu3m/)。

本文中，我们采用原地旋转的方式（即上文题解链接中的 **方法二**）实现旋转操作。

**代码**

```C++
class Solution {
public:
    int temp;
    bool flag;

    bool findRotation(vector<vector<int>>& mat, vector<vector<int>>& target) {
        int n = mat.size();
        // 最多旋转 4 次
        for (int k = 0; k < 4; ++k) {
            // 旋转操作
            for (int i = 0; i < n / 2; ++i) {
                for (int j = 0; j < (n + 1) / 2; ++j) {
                    temp = mat[i][j];
                    mat[i][j] = mat[n-1-j][i];
                    mat[n-1-j][i] = mat[n-1-i][n-1-j];
                    mat[n-1-i][n-1-j] = mat[j][n-1-i];
                    mat[j][n-1-i] = temp;
                }
            }

            if (mat == target) {
                return true;
            }
        }
        return false;
    }
};
```

```Python
class Solution:
    def findRotation(self, mat: List[List[int]], target: List[List[int]]) -> bool:
        n = len(mat)
        # 最多旋转 4 次
        for k in range(4):
            # 旋转操作
            for i in range(n // 2):
                for j in range((n + 1) // 2):
                    mat[i][j], mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i] \
                        = mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i], mat[i][j]

            if mat == target:
                return True
        return False
```

```Java
class Solution {
    public boolean findRotation(int[][] mat, int[][] target) {
        int n = mat.length;
        // 最多旋转 4 次
        for (int k = 0; k < 4; k++) {
            // 旋转操作
            for (int i = 0; i < n / 2; i++) {
                for (int j = 0; j < (n + 1) / 2; j++) {
                    int temp = mat[i][j];
                    mat[i][j] = mat[n-1-j][i];
                    mat[n-1-j][i] = mat[n-1-i][n-1-j];
                    mat[n-1-i][n-1-j] = mat[j][n-1-i];
                    mat[j][n-1-i] = temp;
                }
            }

            if (isEqual(mat, target)) {
                return true;
            }
        }
        return false;
    }

    private boolean isEqual(int[][] mat, int[][] target) {
        int n = mat.length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] != target[i][j]) {
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
    public bool FindRotation(int[][] mat, int[][] target) {
        int n = mat.Length;
        // 最多旋转 4 次
        for (int k = 0; k < 4; k++) {
            // 旋转操作
            for (int i = 0; i < n / 2; i++) {
                for (int j = 0; j < (n + 1) / 2; j++) {
                    int temp = mat[i][j];
                    mat[i][j] = mat[n-1-j][i];
                    mat[n-1-j][i] = mat[n-1-i][n-1-j];
                    mat[n-1-i][n-1-j] = mat[j][n-1-i];
                    mat[j][n-1-i] = temp;
                }
            }

            if (IsEqual(mat, target)) {
                return true;
            }
        }
        return false;
    }

    private bool IsEqual(int[][] mat, int[][] target) {
        int n = mat.Length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] != target[i][j]) {
                    return false;
                }
            }
        }
        return true;
    }
}
```

```Go
func findRotation(mat [][]int, target [][]int) bool {
    n := len(mat)
    // 最多旋转 4 次
    for k := 0; k < 4; k++ {
        // 旋转操作
        for i := 0; i < n/2; i++ {
            for j := 0; j < (n+1)/2; j++ {
                mat[i][j], mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i] =
                    mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i], mat[i][j]
            }
        }

        if isEqual(mat, target) {
            return true
        }
    }
    return false
}

func isEqual(mat, target [][]int) bool {
    n := len(mat)
    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            if mat[i][j] != target[i][j] {
                return false
            }
        }
    }
    return true
}
```

```C
bool isEqual(int** mat, int** target, int n) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (mat[i][j] != target[i][j]) {
                return false;
            }
        }
    }
    return true;
}

bool findRotation(int** mat, int matSize, int* matColSize, int** target, int targetSize, int* targetColSize) {
    int n = matSize;

    // 最多旋转 4 次
    for (int k = 0; k < 4; k++) {
        // 旋转操作
        for (int i = 0; i < n / 2; i++) {
            for (int j = 0; j < (n + 1) / 2; j++) {
                int temp = mat[i][j];
                mat[i][j] = mat[n-1-j][i];
                mat[n-1-j][i] = mat[n-1-i][n-1-j];
                mat[n-1-i][n-1-j] = mat[j][n-1-i];
                mat[j][n-1-i] = temp;
            }
        }

        if (isEqual(mat, target, n)) {
            return true;
        }
    }
    return false;
}
```

```JavaScript
var findRotation = function(mat, target) {
    const n = mat.length;
    // 最多旋转 4 次
    for (let k = 0; k < 4; k++) {
        // 旋转操作
        for (let i = 0; i < Math.floor(n / 2); i++) {
            for (let j = 0; j < Math.floor((n + 1) / 2); j++) {
                [mat[i][j], mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i]] =
                    [mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i], mat[i][j]]
            }
        }

        if (isEqual(mat, target)) {
            return true;
        }
    }
    return false;
};

function isEqual(mat, target) {
    const n = mat.length;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (mat[i][j] !== target[i][j]) {
                return false;
            }
        }
    }
    return true;
}
```

```TypeScript
function findRotation(mat: number[][], target: number[][]): boolean {
    const n = mat.length;
    // 最多旋转 4 次
    for (let k = 0; k < 4; k++) {
        // 旋转操作
        for (let i = 0; i < Math.floor(n / 2); i++) {
            for (let j = 0; j < Math.floor((n + 1) / 2); j++) {
                [mat[i][j], mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i]] =
                    [mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i], mat[i][j]]
            }
        }

        if (isEqual(mat, target)) {
            return true;
        }
    }
    return false;
}

function isEqual(mat: number[][], target: number[][]): boolean {
    const n = mat.length;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (mat[i][j] !== target[i][j]) {
                return false;
            }
        }
    }
    return true;
}
```

```Rust
impl Solution {
    pub fn find_rotation(mat: Vec<Vec<i32>>, target: Vec<Vec<i32>>) -> bool {
        let n = mat.len();
        let mut mat = mat;

        // 最多旋转 4 次
        for _ in 0..4 {
            // 旋转操作
            for i in 0..n/2 {
                for j in 0..(n+1)/2 {
                    let temp = mat[i][j];
                    mat[i][j] = mat[n-1-j][i];
                    mat[n-1-j][i] = mat[n-1-i][n-1-j];
                    mat[n-1-i][n-1-j] = mat[j][n-1-i];
                    mat[j][n-1-i] = temp;
                }
            }

            if mat == target {
                return true;
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 为 $mat$ 的边长。我们最多进行 $4$ 次旋转与比较操作，每次旋转操作的时间复杂度为 $O(n^2)$，每次比较操作的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(1)$。
