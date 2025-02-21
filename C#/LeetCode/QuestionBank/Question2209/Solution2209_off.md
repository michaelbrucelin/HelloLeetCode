### [用地毯覆盖后的最少白色砖块](https://leetcode.cn/problems/minimum-white-tiles-after-covering-with-carpets/solutions/3069163/yong-di-tan-fu-gai-hou-de-zui-shao-bai-s-uav9/)

#### 方法一：

**思路**

题目给定了一个长度为$n$的字符串，其中只包含$0$或者$1$，$0$表示黑色砖块而$1$表示白色砖块，现在需要用若干个长度固定的黑色“地毯”去覆盖白色砖块，地毯之间可以相互覆盖，问无法覆盖的白色砖块的最少数目。

由于地毯之间可以相互覆盖，我们在从左到右放置地毯时不用关注上一个地毯的位置，只需要关注剩余的地毯数量，同时最小化未被覆盖的白色砖块数量。因此，动态规划呼之欲出，我们定义$d[i][j]$表示在前$i$个砖块上使用了$j$个地毯后，最少有多少未被覆盖的白色砖块。因此有转移方程：

$$d[i][j]=min(d[i-1][j]+[第i个砖块是否为白色砖块],d[i-carpetLen][j-1])$$

其中$carpetlen$表示砖块的长度，目标$d[i][j]$取自两个值的最小值：

- 在$i$处不放置地毯，由$d[i-1][j]$在加上i处是否为白色砖块得到
- 在$i$处放置地毯，由$d[i-carpetlen][j-1]$转移得到，$i-carpetlen$可能为负数，此时需要取$0$。

令砖块的下标从$1$开始，那么：

- 对于所有的$j \in [0,numCarpets]$，$d[0][j]$可初始化为$0$。
- 对于所有的$i \in [1,n]$，$d[i][0]$为前$i$个砖块中白色砖块的数量。
- $d$数组中其余的值都初始化为正无穷。

最终答案为$d[n][numCarpets]$。

**代码**

```Python
class Solution:
    def minimumWhiteTiles(self, floor: str, numCarpets: int, carpetLen: int) -> int:
        n = len(floor)
        INF = float('inf') 
        d = [[INF] * (numCarpets + 1) for _ in range(n + 1)]

        for j in range(numCarpets + 1):
            d[0][j] = 0

        for i in range(1, n + 1):
            d[i][0] = d[i - 1][0] + (1 if floor[i - 1] == '1' else 0)

        for i in range(1, n + 1):
            for j in range(1, numCarpets + 1):
                d[i][j] = d[i - 1][j] + (1 if floor[i - 1] == '1' else 0)
                d[i][j] = min(d[i][j], d[max(0, i - carpetLen)][j - 1])

        return d[n][numCarpets]
```

```C++
class Solution {
public:
    static constexpr int INF = 0x3f3f3f3f;
    int minimumWhiteTiles(string floor, int numCarpets, int carpetLen) {
        int n = floor.size();
        vector<vector<int>> d(n + 1, vector<int>(numCarpets + 1, INF));
        for (int j = 0; j <= numCarpets; j++) {
            d[0][j] = 0;
        }
        for (int i = 1; i <= n; i++) {
            d[i][0] = d[i - 1][0] + (floor[i - 1] == '1');
        }
        
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= numCarpets; j++) {
                d[i][j] = d[i - 1][j] + (floor[i - 1] == '1');
                d[i][j] = min(d[i][j], d[max(0, i - carpetLen)][j - 1]);
            }
        }

        return d[n][numCarpets];
    }
};
```

```Rust
use std::cmp::{max, min};
impl Solution {
    pub fn minimum_white_tiles(floor: String, num_carpets: i32, carpet_len: i32) -> i32 {
        let num_carpets = num_carpets as usize;
        let carpet_len = carpet_len as usize;
        let floor: Vec<_> = floor.chars().collect();
        let n = floor.len();
        let mut d = vec![vec![i32::MAX/2; num_carpets + 1]; n + 1];

        for j in 0..=num_carpets {
            d[0][j] = 0;
        }
        for i in 1..=n {
            d[i][0] = d[i - 1][0] + if floor[i - 1] == '1' { 1 } else { 0 };
        }

        for i in 1..=n {
            for j in 1..=num_carpets {
                d[i][j] = d[i - 1][j] + if floor[i - 1] == '1' { 1 } else { 0 };
                let p = if i >= carpet_len { i - carpet_len } else { 0 };
                d[i][j] = min(d[i][j], d[p][j - 1]);
            }
        }
        d[n][num_carpets]
    }
}
```

```Java
public class Solution {
    static final int INF = 0x3f3f3f3f;

    public int minimumWhiteTiles(String floor, int numCarpets, int carpetLen) {
        int n = floor.length();
        int[][] d = new int[n + 1][numCarpets + 1];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= numCarpets; j++) {
                d[i][j] = INF;
            }
        }
        for (int j = 0; j <= numCarpets; j++) {
            d[0][j] = 0;
        }
        for (int i = 1; i <= n; i++) {
            d[i][0] = d[i - 1][0] + (floor.charAt(i - 1) == '1' ? 1 : 0);
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= numCarpets; j++) {
                d[i][j] = d[i - 1][j] + (floor.charAt(i - 1) == '1' ? 1 : 0);
                d[i][j] = Math.min(d[i][j], d[Math.max(0, i - carpetLen)][j - 1]);
            }
        }
        return d[n][numCarpets];
    }
}
```

```CSharp
public class Solution {
    const int INF = 0x3f3f3f3f;
    
    public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen) {
        int n = floor.Length;
        int[,] d = new int[n + 1, numCarpets + 1];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= numCarpets; j++) {
                d[i, j] = INF;
            }
        }
        for (int j = 0; j <= numCarpets; j++) {
            d[0, j] = 0;
        }
        for (int i = 1; i <= n; i++) {
            d[i, 0] = d[i - 1, 0] + (floor[i - 1] == '1' ? 1 : 0);
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= numCarpets; j++) {
                d[i, j] = d[i - 1, j] + (floor[i - 1] == '1' ? 1 : 0);
                d[i, j] = Math.Min(d[i, j], d[Math.Max(0, i - carpetLen), j - 1]);
            }
        }
        return d[n, numCarpets];
    }
}
```

```Go
const INF = 0x3f3f3f3f

func minimumWhiteTiles(floor string, numCarpets int, carpetLen int) int {
    n := len(floor)
    d := make([][]int, n + 1)
    for i := range d {
        d[i] = make([]int, numCarpets+1)
        for j := range d[i] {
            d[i][j] = INF
        }
    }
    for j := 0; j <= numCarpets; j++ {
        d[0][j] = 0
    }
    for i := 1; i <= n; i++ {
        d[i][0] = d[i - 1][0]
        if floor[i - 1] == '1' {
            d[i][0]++
        }
    }
    for i := 1; i <= n; i++ {
        for j := 1; j <= numCarpets; j++ {
            d[i][j] = d[i - 1][j]
            if floor[i - 1] == '1' {
                d[i][j]++
            }
            d[i][j] = min(d[i][j], d[max(0, i - carpetLen)][j - 1])
        }
    }
    return d[n][numCarpets]
}
```

```C
#define INF 0x3f3f3f3f

int minimumWhiteTiles(char* floor, int numCarpets, int carpetLen) {
    int n = strlen(floor);
    int d[n + 1][numCarpets + 1];
    for (int i = 0; i <= n; i++) {
        for (int j = 0; j <= numCarpets; j++) {
            d[i][j] = INF;
        }
    }
    for (int j = 0; j <= numCarpets; j++) {
        d[0][j] = 0;
    }
    for (int i = 1; i <= n; i++) {
        d[i][0] = d[i - 1][0] + (floor[i - 1] == '1' ? 1 : 0);
    }
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= numCarpets; j++) {
            d[i][j] = d[i - 1][j] + (floor[i - 1] == '1' ? 1 : 0);
            d[i][j] = fmin(d[i][j], d[(int)fmax(0, i - carpetLen)][j - 1]);
        }
    }
    int result = d[n][numCarpets];
    return result;
}
```

```JavaScript
const INF = 0x3f3f3f3f;

var minimumWhiteTiles = function(floor, numCarpets, carpetLen) {
    const n = floor.length;
    const d = Array.from({ length: n + 1 }, () => Array(numCarpets + 1).fill(INF));
    for (let j = 0; j <= numCarpets; j++) {
        d[0][j] = 0;
    }
    for (let i = 1; i <= n; i++) {
        d[i][0] = d[i - 1][0] + (floor[i - 1] === '1' ? 1 : 0);
    }
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= numCarpets; j++) {
            d[i][j] = d[i - 1][j] + (floor[i - 1] === '1' ? 1 : 0);
            d[i][j] = Math.min(d[i][j], d[Math.max(0, i - carpetLen)][j - 1]);
        }
    }
    return d[n][numCarpets];
};
```

```TypeScript
const INF = 0x3f3f3f3f;

function minimumWhiteTiles(floor: string, numCarpets: number, carpetLen: number): number {
    const n = floor.length;
    const d: number[][] = Array.from({ length: n + 1 }, () => Array(numCarpets + 1).fill(INF));
    for (let j = 0; j <= numCarpets; j++) {
        d[0][j] = 0;
    }
    for (let i = 1; i <= n; i++) {
        d[i][0] = d[i - 1][0] + (floor[i - 1] === '1' ? 1 : 0);
    }
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= numCarpets; j++) {
            d[i][j] = d[i - 1][j] + (floor[i - 1] === '1' ? 1 : 0);
            d[i][j] = Math.min(d[i][j], d[Math.max(0, i - carpetLen)][j - 1]);
        }
    }
    return d[n][numCarpets];
};
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中$n$是字符串$floor$的长度，$m$是$numCarpets$。
- 空间复杂度：$O(nm)$。

#### 方法二：滚动数组优化

**思路**

我们的关注点重新聚焦在转移方程上，忽略$d$第一维的具体值和与$d$不相关的变量，那么转移方程可以看作：

$$d[][j]=min(d[][j],d[][j-1])$$

发现第二维可以简化成两层，因此可以使用滚动数组进行优化。我们优先在$[1,numCarpets]$中枚举$j$，然后从$[1,n]$中枚举$i$。因为调换枚举顺序并不会破坏动态规划中的依赖关系，当某个状态被计算时，其子状态的所有答案都已被算出，所以这样做不会影响答案的正确性。

**代码**

```C++
class Solution {
public:
    static constexpr int INF = 0x3f3f3f3f;
    int minimumWhiteTiles(string floor, int numCarpets, int carpetLen) {
        int n = floor.size();
        vector<int> d(n + 1, INF), f(n + 1, INF);
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + (floor[i - 1] == '1');
        }

        for (int j = 1; j <= numCarpets; j++) {
            f[0] = 0;
            for (int i = 1; i <= n; i++) {
                f[i] = f[i - 1] + (floor[i - 1] == '1');
                f[i] = min(f[i], d[max(0, i - carpetLen)]);
            }
            swap(d, f);
        }

        return d[n];
    }
};
```

```Python
class Solution:
    def minimumWhiteTiles(self, floor: str, numCarpets: int, carpetLen: int) -> int:
        n = len(floor)
        d = [float('inf')] * (n + 1)  # 使用 float('inf') 表示正无穷
        f = [float('inf')] * (n + 1)
        d[0] = 0

        for i in range(1, n + 1):
            d[i] = d[i - 1] + (1 if floor[i - 1] == '1' else 0)

        for _ in range(numCarpets):
            f[0] = 0
            for i in range(1, n + 1):
                f[i] = f[i - 1] + (1 if floor[i - 1] == '1' else 0)
                f[i] = min(f[i], d[max(0, i - carpetLen)])
            d, f = f, d

        return d[n]
```

```Rust
use std::cmp::{max, min};
use std::mem::swap;
impl Solution {
    pub fn minimum_white_tiles(floor: String, num_carpets: i32, carpet_len: i32) -> i32 {
        let num_carpets = num_carpets as usize;
        let carpet_len = carpet_len as usize;
        let floor: Vec<_> = floor.chars().collect();
        let n = floor.len();
        let inf = i32::MAX / 2;
        let mut d = vec![inf; n + 1];
        let mut f = vec![inf; n + 1];

        d[0] = 0;
        for i in 1..=n {
            d[i] = d[i - 1] + if floor[i - 1] == '1' { 1 } else { 0 };
        }

        for j in 1..=num_carpets {
            f[0] = 0;
            for i in 1..=n {
                f[i] = f[i - 1] + if floor[i - 1] == '1' { 1 } else { 0 };
                let p = if i >= carpet_len { i - carpet_len } else { 0 };
                f[i] = min(f[i], d[p]);
            }
            swap(&mut f, &mut d);
        }
        d[n]
    }
}
```

```Java
public class Solution {
    private static final int INF = 0x3f3f3f3f;

    public int minimumWhiteTiles(String floor, int numCarpets, int carpetLen) {
        int n = floor.length();
        int[] d = new int[n + 1];
        int[] f = new int[n + 1];
        Arrays.fill(d, INF);
        Arrays.fill(f, INF);
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + (floor.charAt(i - 1) == '1' ? 1 : 0);
        }
        for (int j = 1; j <= numCarpets; j++) {
            f[0] = 0;
            for (int i = 1; i <= n; i++) {
                f[i] = f[i - 1] + (floor.charAt(i - 1) == '1' ? 1 : 0);
                f[i] = Math.min(f[i], d[Math.max(0, i - carpetLen)]);
            }
            int[] temp = d;
            d = f;
            f = temp;
        }

        return d[n];
    }
}
```

```CSharp
public class Solution {
    private const int INF = 0x3f3f3f3f;

    public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen) {
        int n = floor.Length;
        int[] d = new int[n + 1];
        int[] f = new int[n + 1];
        Array.Fill(d, INF);
        Array.Fill(f, INF);
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + (floor[i - 1] == '1' ? 1 : 0);
        }
        for (int j = 1; j <= numCarpets; j++) {
            f[0] = 0;
            for (int i = 1; i <= n; i++) {
                f[i] = f[i - 1] + (floor[i - 1] == '1' ? 1 : 0);
                f[i] = Math.Min(f[i], d[Math.Max(0, i - carpetLen)]);
            }
            int[] temp = d;
            d = f;
            f = temp;
        }

        return d[n];
    }
}
```

```Go
const INF = 0x3f3f3f3f

func minimumWhiteTiles(floor string, numCarpets int, carpetLen int) int {
    n := len(floor)
    d := make([]int, n + 1)
    f := make([]int, n + 1)
    for i := range d {
        d[i] = INF
        f[i] = INF
    }
    d[0] = 0
    for i := 1; i <= n; i++ {
        d[i] = d[i - 1]
        if floor[i - 1] == '1' {
            d[i]++
        }
    }
    for j := 1; j <= numCarpets; j++ {
        f[0] = 0
        for i := 1; i <= n; i++ {
            f[i] = f[i - 1]
            if floor[i - 1] == '1' {
                f[i]++
            }
            f[i] = min(f[i], d[max(0, i - carpetLen)]);
        }
        d, f = f, d
    }
    return d[n]
}
```

```C
#define INF 0x3f3f3f3f

int minimumWhiteTiles(char* floor, int numCarpets, int carpetLen) {
    int n = strlen(floor);
    int *d = (int *)malloc(sizeof(int) * (n + 1));
    int *f = (int *)malloc(sizeof(int) * (n + 1));
    memset(d, INF, sizeof(int) * (n + 1));
    memset(f, INF, sizeof(int) * (n + 1));
    d[0] = 0;
    for (int i = 1; i <= n; i++) {
        d[i] = d[i - 1] + (floor[i - 1] == '1');
    }
    for (int j = 1; j <= numCarpets; j++) {
        f[0] = 0;
        for (int i = 1; i <= n; i++) {
            f[i] = f[i - 1] + (floor[i - 1] == '1');
            f[i] = fmin(f[i], d[(int)fmax(0, i - carpetLen)]);
        }
        int* temp = d;
        d = f;
        f = temp;
    }

    return d[n];
}
```

```JavaScript
const INF = 0x3f3f3f3f;

var minimumWhiteTiles = function(floor, numCarpets, carpetLen) {
    let n = floor.length;
    let d = new Array(n + 1).fill(INF);
    let f = new Array(n + 1).fill(INF);
    d[0] = 0;

    for (let i = 1; i <= n; i++) {
        d[i] = d[i - 1] + (floor[i - 1] === '1' ? 1 : 0);
    }

    for (let j = 1; j <= numCarpets; j++) {
        f[0] = 0;
        for (let i = 1; i <= n; i++) {
            f[i] = f[i - 1] + (floor[i - 1] === '1' ? 1 : 0);
            f[i] = Math.min(f[i], d[Math.max(0, i - carpetLen)]);
        }
        [d, f] = [f, d];
    }

    return d[n];
}
```

```TypeScript
const INF: number = 0x3f3f3f3f;

function minimumWhiteTiles(floor: string, numCarpets: number, carpetLen: number): number {
    let n: number = floor.length;
    let d: number[] = new Array(n + 1).fill(INF);
    let f: number[] = new Array(n + 1).fill(INF);
    d[0] = 0;

    for (let i = 1; i <= n; i++) {
        d[i] = d[i - 1] + (floor[i - 1] === '1' ? 1 : 0);
    }

    for (let j = 1; j <= numCarpets; j++) {
        f[0] = 0;
        for (let i = 1; i <= n; i++) {
            f[i] = f[i - 1] + (floor[i - 1] === '1' ? 1 : 0);
            f[i] = Math.min(f[i], d[Math.max(0, i - carpetLen)]);
        }
        [d, f] = [f, d];
    }

    return d[n];
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中$n$是字符串$floor$的长度，$m$是$numCarpets$。
- 空间复杂度：$O(n)$。
