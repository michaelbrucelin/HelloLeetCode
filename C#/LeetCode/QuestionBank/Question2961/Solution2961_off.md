### [双模幂运算](https://leetcode.cn/problems/double-modular-exponentiation/solutions/2857776/shuang-mo-mi-yun-suan-by-leetcode-soluti-tque/)

#### 方法一：快速幂

**思路**

按题意扫描一遍 $variables$ 数组进行模拟，找到满足要求的下标即可。在模拟时，使用了快速幂算法来计算幂运算。以下是关于快速幂的简单介绍，详细内容可以访问 「[50\. Pow(x, n)](https://leetcode.cn/problems/powx-n/description/)」。

「快速幂算法」的本质是分治算法。举个例子，如果我们要计算 x^64，我们可以按照：

$$x \rightarrow x^2 \rightarrow x^4 \rightarrow x^8 \rightarrow x^16 \rightarrow x^32 \rightarrow x^64$$

的顺序，从 $x$ 开始，每次直接把上一次的结果进行平方，计算 $6$ 次就可以得到 $x^64$ 的值，而不需要对 $x$ 乘 $63$ 次 $x$。

再举一个例子，如果我们要计算 $x^77$，我们可以按照：

$$x \rightarrow x^2 \rightarrow x^4 \rightarrow x^9 \rightarrow x^19 \rightarrow x^38 \rightarrow x^77$$

的顺序，在 $x \rightarrow x^2$，$x^2 \rightarrow x^4$，$x^19 \rightarrow x^38$ 这些步骤中，我们直接把上一次的结果进行平方，而在 $x^4 \rightarrow x^9$，$x^9 \rightarrow x^19$，$x^38 \rightarrow x^77$ 这些步骤中，我们把上一次的结果进行平方后，还要额外乘一个 $x$。

直接从左到右进行推导看上去很困难，因为在每一步中，我们不知道在将上一次的结果平方之后，还需不需要额外乘 $x$。但如果我们从右往左看，分治的思想就十分明显了：

- 当我们要计算 $x^n$ 时，我们可以先递归地计算出 $y = x^{\lfloor n/2 \rfloor}$，其中 $\lfloor a \rfloor$ 表示对 $a$ 进行下取整；
- 根据递归计算的结果，如果 $n$ 为偶数，那么 $x^n = y^2$；如果 $n$ 为奇数，那么 $x^n = y^2 \times x$；
- 递归的边界为 $n = 0$，任意数的 $0$ 次方均为 $1$。

由于每次递归都会使得指数减少一半，因此递归的层数为 $O(logn)$，算法可以在很快的时间内得到结果。

**代码**

```C++
class Solution {
public:
    int pow_mod(int x, int y, int mod) {
        int res = 1;
        while (y) {
            if (y & 1) {
                res = res * x % mod;
            }

            x = x * x % mod;
            y >>= 1;
        }   
    return res;
    }
    
    vector<int> getGoodIndices(vector<vector<int>>& variables, int target) {
        vector<int> ans;
        
        for (int i = 0; i < variables.size(); i++) {
            auto &v = variables[i];
            if (pow_mod(pow_mod(v[0], v[1], 10), v[2], v[3]) == target) {
                ans.push_back(i);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<Integer> getGoodIndices(int[][] variables, int target) {
        List<Integer> ans = new ArrayList<Integer>();
        for (int i = 0; i < variables.length; i++) {
            int[] v = variables[i];
            if (powMod(powMod(v[0], v[1], 10), v[2], v[3]) == target) {
                ans.add(i);
            }
        }
        return ans;
    }

    public int powMod(int x, int y, int mod) {
        int res = 1;
        while (y != 0) {
            if ((y & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
            y >>= 1;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public IList<int> GetGoodIndices(int[][] variables, int target) {
        IList<int> ans = new List<int>();
        for (int i = 0; i < variables.Length; i++) {
            int[] v = variables[i];
            if (PowMod(PowMod(v[0], v[1], 10), v[2], v[3]) == target) {
                ans.Add(i);
            }
        }
        return ans;
    }

    public int PowMod(int x, int y, int mod) {
        int res = 1;
        while (y != 0) {
            if ((y & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
            y >>= 1;
        }
        return res;
    }
}
```

```C
int pow_mod(int x, int y, int mod) {
    int res = 1;
    while (y) {
        if (y & 1) {
            res = res * x % mod;
        }

        x = x * x % mod;
        y >>= 1;
    }
    return res;
}

int* getGoodIndices(int** variables, int variablesSize, int* variablesColSize, int target, int* returnSize) {
    int *ans = (int *)malloc(sizeof(int) * variablesSize);
    int pos = 0;
    for (int i = 0; i < variablesSize; i++) {
        int *v = variables[i];
        if (pow_mod(pow_mod(v[0], v[1], 10), v[2], v[3]) == target) {
            ans[pos++] = i;
        }
    }
    *returnSize = pos;
    return ans;
}
```

```Python
class Solution:
    def getGoodIndices(self, variables: List[List[int]], target: int) -> List[int]:
        ans = []
        for i, v in enumerate(variables):
            if pow(pow(v[0], v[1], 10), v[2], v[3]) == target:
                ans.append(i)
        return ans
```

```Go
func getGoodIndices(variables [][]int, target int) []int {
    ans := []int{}
    for i, v := range variables {
        if pow_mod(pow_mod(v[0], v[1], 10), v[2], v[3]) == target {
            ans = append(ans, i)
        }
    }
    return ans
}

func pow_mod(x, y, mod int) int {
    res := 1
    for y > 0 {
        if (y & 1) == 1 {
            res = res * x % mod
        }
        x = x * x % mod
        y >>= 1
    }
    return res
}
```

```JavaScript
var getGoodIndices = function(variables, target) {
    const ans = [];
    for (let i = 0; i < variables.length; i++) {
        const v = variables[i];
        if (powMod(powMod(v[0], v[1], 10), v[2], v[3]) === target) {
            ans.push(i);
        }
    }
    return ans;
};

function powMod(x, y, mod) {
    let res = 1;
    while (y > 0) {
        if ((y & 1) === 1) {
            res = (res * x) % mod;
        }
        x = (x * x) % mod;
        y >>= 1;
    }
    return res;
}
```

```TypeScript
function getGoodIndices(variables: number[][], target: number): number[] {
    const ans: number[] = [];
    for (let i = 0; i < variables.length; i++) {
        const v = variables[i];
        if (powMod(powMod(v[0], v[1], 10), v[2], v[3]) === target) {
            ans.push(i);
        }
    }
    return ans;
};

function powMod(x: number, y: number, mod: number): number {
    let res = 1;
    while (y > 0) {
        if ((y & 1) === 1) {
            res = (res * x) % mod;
        }
        x = (x * x) % mod;
        y >>= 1;
    }
    return res;
}
```

```Rust
fn pow_mod(mut x: i32, mut y: i32, mod_: i32) -> i32 {
    let mut res = 1;
    while y > 0 {
        if (y & 1) == 1 {
            res = res * x % mod_;
        }
        x = x * x % mod_;
        y >>= 1;
    }
    res
}

impl Solution {
    pub fn get_good_indices(variables: Vec<Vec<i32>>, target: i32) -> Vec<i32> {
        let mut ans = Vec::new();
        for (i, v) in variables.iter().enumerate() {
            if pow_mod(pow_mod(v[0], v[1], 10), v[2], v[3]) == target {
                ans.push(i as i32);
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogv)$，其中 $n$ 为数组的长度，$v$ 为元素的取值，在本题中最大为 $1000$。
- 空间复杂度：$O(1)$。
