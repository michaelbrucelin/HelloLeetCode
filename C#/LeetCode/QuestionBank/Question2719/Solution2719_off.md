### [统计整数数目](https://leetcode.cn/problems/count-of-integers/solutions/2601111/tong-ji-zheng-shu-shu-mu-by-leetcode-sol-qxqd/)

#### 方法一：数位动态规划

##### 思路与算法

题目要求求解数值范围在 $nums_1$ 到 $nums_2$ 之间，并且数位和在 $min\_sum$ 到 $max\_sum$ 之间的整数个数，其中 $nums_1$ 和 $nums_2$ 以字符串形式给出。

此类题目通常使用数位动态规划来求解，关于数位动态规划的详细介绍可以参考[「数位DP(OI Wiki)」](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Fnumber%2F)，类似的题目有[「233. 数字 1 的个数」](https://leetcode.cn/problems/number-of-digit-one/description/)、[「600. 不含连续1的非负整数」](https://leetcode.cn/problems/non-negative-integers-without-consecutive-ones/description/)和[「1012. 至少有 1 位重复的数字」](https://leetcode.cn/problems/numbers-with-repeated-digits/description/)等。

定义函数 $get(num)$，用于求解 $1 \sim num$ 范围内有多少整数数位和介于 $min\_sum \sim max\_sum$ 之间，那么原问题就转换为求解 $get(num_2) - get(num_1 - 1)$。因此下文将着重讨论如何求解 $get(num)$。

设 $num$ 共有 $n$ 位，我们从最高位（即第 $n-1$ 位）开始遍历，目前聚焦于第 $i$ 位，前面第 $n-1$ 位到第 $i + 1$ 位的数位和为 $sum$，现在需要考虑第 $i$ 位填充的数字 $x$。通常 $x$ 可以取 $0\sim 9$ 中的任意一个数字，但当第 $n-1$ 位到第 $i + 1$ 位放置的数字都与 $num$ 一样时，$x$ 的取值范围缩小至 $0 \sim num[i]$，在代码中，当 $limit$ 为 $true$ 时，表示这一特殊情况发生。

试想，如果 $limit$ 标识为 $false$，$x$ 取值范围为 $0 \sim 9$，那么后续的第 $i - 1$ 到第 $0$ 位的取值范围都是 $0 \sim 9$。这样一来，子问题就与 $num$ 的值无关。我们定义状态 $d[i][j]$ 表示还剩第 $i$ 位到第 $0$ 位的数字未填，而已填的数字位数之和为 $j$ 时，符合条件的数字个数有多少个。在求解时，子问题与 $n$ 的值无关，也与 $num$ 无关，因此只有当 $limit$ 为 $false$ 可以使用或更新 $d[i][j]$。

当然，$limit$ 这一维度也可以加入到状态中，但 $limit$ 为 $true$ 的子问题只会被调用一次，将答案记忆化存储毫无意义，并且每次重新调用 $get$ 时都需要重新计算所有状态答案，得不偿失。因此定义函数 $dfs(i, j, limit)$ 用于问题求解，在 $limit$ 为 $false$ 时借助 $d[i][j]$ 防止重复计算，加快执行速度。

##### 细节

我们采用记忆化搜索的方式实现数位动态规划，将所有 $d[i][j]$ 的初始值设置为 $-1$。递归过程：

- 若 $limit$ 为 $true$ 时，在 $0 \sim num[i]$ 范围内遍历 $x$，并递归调用 $dfs(i - 1, j + x, limit \&\& x == nums[i])$，统计所有返回值的和作为答案。
- 若 $limit$ 为 $false$ 时，若 $d[i][j] \neq -1$，则直接返回 $d[i][j]$，否则在 $0 \sim 9$ 范围内遍历 $x$，并递归调用 $dfs(i - 1, j + x, false)$，统计所有返回值的和并更新 $d[i][j]$。

若 $j$ 已经大于 $max\_sum$，可以剪枝，直接返回 $0$。当 $i$ 等于 $-1$ 时，递归结束，此时若 $j \ge min_sum$ 则返回 $1$，否则返回 $0$。

需要注意的是，由于上文中第 $n - 1$ 位表示数字的最高位，第 $0$ 位表示数字的最低位（即个位），因此需要将题目中输入的数字翻转。

##### 代码

```c++
class Solution {
    static constexpr int N = 23;
    static constexpr int M = 401;
    static constexpr int MOD = 1e9 + 7;
    int d[N][M];
    string num;
    int min_sum;
    int max_sum;

    int dfs(int i, int j, bool limit) {
        if (j > max_sum) {
            return 0;
        }
        if (i == -1) {
            return j >= min_sum;
        }
        if (!limit && d[i][j] != -1) {
            return d[i][j];
        }
        int res = 0;
        int up = limit ? num[i] - '0' : 9;
        for (int x = 0; x <= up; x++) {
            res = (res + dfs(i - 1, j + x, limit && x == up)) % MOD;
        }
        if (!limit) {
            d[i][j] = res;
        }
        return res;
    }

    int get(string num) {
        reverse(num.begin(), num.end());
        this->num = num;
        return dfs(num.size() - 1, 0, true);
    }

    // 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
    string sub(string num) {
        int i = num.size() - 1;
        while (num[i] == '0') {
            i--;
        }
        num[i]--;
        i++;
        while (i < num.size()) {
            num[i] = '9';
            i++;
        }
        return num;
    }
public:
    int count(string num1, string num2, int min_sum, int max_sum) {
        memset(d, -1, sizeof d);
        this->min_sum = min_sum;
        this->max_sum = max_sum;
        return (get(num2) - get(sub(num1)) + MOD) % MOD;
    }
};
```

```java
class Solution {
    static final int N = 23;
    static final int M = 401;
    static final int MOD = 1000000007;
    int[][] d;
    String num;
    int min_sum;
    int max_sum;

    public int count(String num1, String num2, int min_sum, int max_sum) {
        d = new int[N][M];
        for (int i = 0; i < N; i++) {
            Arrays.fill(d[i], -1);
        }
        this.min_sum = min_sum;
        this.max_sum = max_sum;
        return (get(num2) - get(sub(num1)) + MOD) % MOD;
    }

    public int get(String num) {
        this.num = new StringBuffer(num).reverse().toString();
        return dfs(num.length() - 1, 0, true);
    }

    // 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
    public String sub(String num) {
        char[] arr = num.toCharArray();
        int i = arr.length - 1;
        while (arr[i] == '0') {
            i--;
        }
        arr[i]--;
        i++;
        while (i < arr.length) {
            arr[i] = '9';
            i++;
        }
        return new String(arr);
    }

    public int dfs(int i, int j, boolean limit) {
        if (j > max_sum) {
            return 0;
        }
        if (i == -1) {
            return j >= min_sum ? 1 : 0;
        }
        if (!limit && d[i][j] != -1) {
            return d[i][j];
        }
        int res = 0;
        int up = limit ? num.charAt(i) - '0' : 9;
        for (int x = 0; x <= up; x++) {
            res = (res + dfs(i - 1, j + x, limit && x == up)) % MOD;
        }
        if (!limit) {
            d[i][j] = res;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    const int N = 23;
    const int M = 401;
    const int MOD = 1000000007;
    int[][] d;
    string num;
    int min_sum;
    int max_sum;

    public int Count(string num1, string num2, int min_sum, int max_sum) {
        d = new int[N][];
        for (int i = 0; i < N; i++) {
            d[i] = new int[M];
            Array.Fill(d[i], -1);
        }
        this.min_sum = min_sum;
        this.max_sum = max_sum;
        return (Get(num2) - Get(Sub(num1)) + MOD) % MOD;
    }

    public int Get(string num) {
        StringBuilder sb = new StringBuilder();
        for (int i = num.Length - 1; i >= 0; i--) {
            sb.Append(num[i]);
        }
        this.num = sb.ToString();
        return DFS(num.Length - 1, 0, true);
    }

    // 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
    public string Sub(string num) {
        char[] arr = num.ToCharArray();
        int i = arr.Length - 1;
        while (arr[i] == '0') {
            i--;
        }
        arr[i]--;
        i++;
        while (i < arr.Length) {
            arr[i] = '9';
            i++;
        }
        return new string(arr);
    }

    public int DFS(int i, int j, bool limit) {
        if (j > max_sum) {
            return 0;
        }
        if (i == -1) {
            return j >= min_sum ? 1 : 0;
        }
        if (!limit && d[i][j] != -1) {
            return d[i][j];
        }
        int res = 0;
        int up = limit ? num[i] - '0' : 9;
        for (int x = 0; x <= up; x++) {
            res = (res + DFS(i - 1, j + x, limit && x == up)) % MOD;
        }
        if (!limit) {
            d[i][j] = res;
        }
        return res;
    }
}
```

```c
const int N = 23;
const int M = 401;
const int MOD = 1000000007;

int dfs(char *num, int i, int j, int limit, int **d, int min_sum, int max_sum) {
    if (j > max_sum) {
        return 0;
    }
    if (i == -1) {
        return j >= min_sum;
    }
    if (!limit && d[i][j] != -1) {
        return d[i][j];
    }
    int res = 0;
    int up = limit ? num[i] - '0' : 9;
    for (int x = 0; x <= up; x++) {
        res = (res + dfs(num, i - 1, j + x, limit && x == up, d, min_sum, max_sum)) % MOD;
    }
    if (!limit) {
        d[i][j] = res;
    }
    return res;
}

int get(char *num, int **d, int min_sum, int max_sum) {
    int len = strlen(num);
    for (int i = 0, j = len - 1; i < j; i++, j--) {
        char ch = num[i];
        num[i] = num[j];
        num[j] = ch;
    }
    return dfs(num, len - 1, 0, 1, d, min_sum, max_sum);
}

char* sub(char *num) {
    int len = strlen(num);
    int i = len - 1;
    while (num[i] == '0') {
        i--;
    }
    num[i]--;
    i++;
    while (i < len) {
        num[i] = '9';
        i++;
    }
    return num;
}

int count(char * num1, char * num2, int min_sum, int max_sum) {
    int **d = (int **)malloc(sizeof(int *) * N);
    for (int i = 0; i < N; i++) {
        d[i] = (int *)malloc(sizeof(int) * M);
        for (int j = 0; j < M; j++) {
            d[i][j] = -1;
        }
    }
    int ret = (get(num2, d, min_sum, max_sum) - get(sub(num1), d, min_sum, max_sum) + MOD) % MOD;
    for (int i = 0; i < N; i++) {
        free(d[i]);
    }
    free(d);
    return ret;
}
```

```python
class Solution:
    def count(self, num1: str, num2: str, min_sum: int, max_sum: int) -> int:
        def dfs(num, i, j, limit) -> int:
            if j > max_sum:
                return 0
            if i == -1:
                return j >= min_sum
            if not limit and d[i][j] != -1:
                return d[i][j]
            res = 0
            up = ord(num[i]) - ord('0') if limit > 0 else 9
            for x in range(up + 1):
                res = (res + dfs(num, i - 1, j + x, limit and x == up)) % MOD
            if not limit:
                d[i][j] = res
            return res

        def get(num):
            num = num[::-1]
            return dfs(num, len(num) - 1, 0, True)

        # 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
        def sub(num):
            i = len(num) - 1
            arr = list(num)
            while arr[i] == '0':
                i -= 1
            arr[i] = chr(ord(arr[i]) - 1)
            i += 1
            while i < len(num):
                arr[i] = '9'
                i += 1
            return ''.join(arr)

        N, M = 23, 401
        MOD = 10**9 + 7
        d = [[-1] * M for _ in range(N)]
        return (get(num2) - get(sub(num1)) + MOD) % MOD
```

```go
const MOD = 1000000007
const N = 23
const M = 401

func count(num1 string, num2 string, min_sum int, max_sum int) int {
    d := make([][]int, N)
    for i := range d {
        d[i] = make([]int, M)
        for j := range d[i] {
            d[i][j] = -1
        }
    }

    var dfs func(num string, i int, j int, limit bool) int
    dfs = func(num string, i int, j int, limit bool) int {
        if j > max_sum {
            return 0
        }
        if i == -1 {
            if j >= min_sum {
                return 1
            }
            return 0
        }
        if !limit && d[i][j] != -1 {
            return d[i][j]
        }

        res := 0
        var up int
        if limit {
            up = int(num[i] - '0')
        } else {
            up = 9
        }

        for x := 0; x <= up; x++ {
            res = (res + dfs(num, i - 1, j + x, limit && x == up)) % MOD
        }

        if !limit {
            d[i][j] = res
        }
        return res
    }

    get := func(num string) int {
        num = reverse(num)
        return dfs(num, len(num) - 1, 0, true)
    }
    // 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
    sub := func(num string) string {
        i := len(num) - 1
        arr := []byte(num)
        for arr[i] == '0' {
            i--
        }
        arr[i]--
        i++
        for ; i < len(num); i++ {
            arr[i] = '9'
        }
        return string(arr)
    }

    return (get(num2) - get(sub(num1)) + MOD) % MOD
}

func reverse(s string) string {
    runes := []rune(s)
    for i, j := 0, len(runes) - 1; i < j; i, j = i+1, j-1 {
        runes[i], runes[j] = runes[j], runes[i]
    }
    return string(runes)
}
```

```javascript
var count = function(num1, num2, min_sum, max_sum) {
    const N = 23, M = 401;
    const MOD = 1000000007;
    let d = new Array(N).fill(null).map(() => new Array(M).fill(-1));

    function dfs(num, i, j, limit) {
        if (j > max_sum) {
            return 0;
        }
        if (i === -1) {
            return j >= min_sum ? 1 : 0;
        }
        if (!limit && d[i][j] !== -1) {
            return d[i][j];
        }
        
        let res = 0;
        const up = limit ? num.charCodeAt(i) - '0'.charCodeAt(0) : 9;
        for (let x = 0; x <= up; x++) {
            res = (res + dfs(num, i - 1, j + x, limit && x === up)) % MOD;
        }

        if (!limit) {
            d[i][j] = res;
        }
        return res;
    }

    function get(num) {
        num = num.split("").reverse().join("");
        return dfs(num, num.length - 1, 0, true);
    }

    // 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
    function sub(num) {
        let i = num.length - 1;
        let arr = num.split("");
        while (arr[i] === '0') {
            i--;
        }
        arr[i] = String.fromCharCode(arr[i].charCodeAt(0) - 1);
        i++;
        while (i < num.length) {
            arr[i] = '9';
            i++;
        }
        return arr.join("");
    }

    return (get(num2) - get(sub(num1)) + MOD) % MOD;
};
```

```typescript
function count(num1: string, num2: string, min_sum: number, max_sum: number): number {
    const N: number = 23;
    const M: number = 401;
    const MOD: number = 1000000007;
    let d: number[][] = new Array(N).fill(null).map(() => new Array(M).fill(-1));

    const dfs = (num: string, i: number, j: number, limit: boolean): number => {
        if (j > max_sum) {
            return 0;
        }
        if (i === -1) {
            return j >= min_sum ? 1 : 0;
        }
        if (!limit && d[i][j] !== -1) {
            return d[i][j];
        }
        
        let res: number = 0;
        const up: number = limit ? num.charCodeAt(i) - '0'.charCodeAt(0) : 9;
        for (let x = 0; x <= up; x++) {
            res = (res + dfs(num, i - 1, j + x, limit && x === up)) % MOD;
        }

        if (!limit) {
            d[i][j] = res;
        }
        return res;
    };

    const get = (num: string): number => {
        num = num.split("").reverse().join("");
        return dfs(num, num.length - 1, 0, true);
    };

    // 求解 num - 1，先把最后一个非 0 字符减去 1，再把后面的 0 字符变为 9
    const sub = (num: string): string => {
        let i: number = num.length - 1;
        let arr: string[] = num.split("");
        while (arr[i] === '0') {
            i--;
        }
        arr[i] = String.fromCharCode(arr[i].charCodeAt(0) - 1);
        i++;
        while (i < num.length) {
            arr[i] = '9';
            i++;
        }
        return arr.join("");
    };

    return (get(num2) - get(sub(num1)) + MOD) % MOD;
};
```

#### 复杂度分析

- 时间复杂度：$O(10 \times nm)$，其中 $n$ 为 $num_2$ 的长度，$m$ 为 $max\_sum$。动态规划的状态个数为 $O(nm)$，每个状态求解的时间复杂度为 $O(10)$，因此总的时间复杂度为 $O(10 \times nm)$。
- 空间复杂度：$O(nm)$。
