### [检查是否有合法括号字符串路径](https://leetcode.cn/problems/check-if-there-is-a-valid-parentheses-string-path/solutions/4032286/jian-cha-shi-fou-you-he-fa-gua-hao-zi-fu-k3fd/)

#### 方法一：动态规划

**思路与算法**

首先根据括号序列的性质，我们可以推出以下几个推论：

- 一个合法括号序列的长度必定是偶数；
- 一个合法括号序列必定以字符 $'('$ 开头，以字符 $')'$ 结尾；
- 以及最重要的，在从左到右遍历一个括号序列的过程中，记遇到的字符 $'('$ 数量为 $l_1$，遇到的 $')'$ 字符数量为 $l_2$，那么在任意时刻，都有：$l_1\ge l_2$。即，未配对的左括号数量总是大于等于 $0$ 的。

考虑使用动态规划求解，用 $dp[i][j]$ 记录从左上角走到位置 $(i,j)$ 的所有路径中，**可能出现的未匹配左括号数量集合**，然后查看左侧和上方两个方向的转移：

- 如果当前位置的字符是 $'('$，那么就将这个集合内的全部值加一，代表后续从该状态转移时需要更多的右括号来匹配。
- 反之，如果当前位置的字符是 $')'$，那么就将这个集合内的全部值都减一。
- 如果匹配到 $')'$，当前未匹配的左括号数量小于 $0$，说明这是一个非法状态，将其从集合中移除。

写成转移方程有：

$$dp[i][j]=\{x+\Delta_{i,j} \vert x\in (dp[i-1][j]\cup dp[i][j-1]),x+\Delta_{i,j}\ge 0\}$$

其中：

$$\Delta_{i,j}=\begin{cases}1, & if grid[i][j]='(', \\ -1, & if grid[i][j]=')'.\end{cases}$$

初始化时，因为若 $grid[0][0]$ 处的字符是 $')'$，则不存在合法的括号序列，排除掉这种情况和，我们可以直接给 $dp[0][0]$ 赋值 ${1}$。

设 $grid$ 大小为 $n\times m$，最终判断集合 $dp[n-1][m-1]$ 内是否包含 $0$ 即为所求。

**状态转移实现细节**

在实现时，如果直接按照上述思路进行状态转移，则需要一个存储合法值的容器。因为我们不关心元素间的顺序，哈希集是一个比较好的选择。考虑到我们需要在每一轮对集合内的所有元素进行变更，还需要剔除非法值，因此直接构造下一轮的完整集合会比原地修改更合适。在这种实现下，转移需要的时间复杂度为 $O(n+m)$。

除了使用哈希集，由于每个状态间的变化值为 $\pm 1$，故未配对括号数目的量级为 $O(n+m)$，即从左上到右下的路径长度，故也可以使用布尔数组来维护该集合。我们将存在于集合中的值标为 $True$，不存在于集合的值标为 $False$，也能在 $O(n+m)$ 的时间内实现状态转移。

再换个角度，我们每次转移的目的是为了让集合中的元素全体 $+1$ 或者 $-1$，故该状态转移还可以使用位运算优化。我们可以使用 $BitSet$ 或大整数代替上面的布尔数组，然后使用移位操作进行状态转移，右移时的自然截断刚好对应非法值的舍弃。此时的状态转移就被优化到了 $O(\dfrac{n+m}{W})$，其中 $W$ 是机器字长，现代系统中一般为 $64$。

**代码**

```C++
class Solution {
public:
    bool hasValidPath(vector<vector<char>>& grid) {
        const int n = grid.size();
        const int m = grid[0].size();
        const int pathLen = n + m - 1;

        if (pathLen % 2 == 1) {
            return false;
        }
        if (grid[0][0] != '(' || grid[n - 1][m - 1] != ')') {
            return false;
        }

        vector<vector<bitset<201>>> dp(n, vector<bitset<201>>(m));

        dp[0][0].set(1);

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                const int change = grid[i][j] == '(' ? 1 : -1;

                if (i > 0) {
                    if (change == 1) {
                        dp[i][j] |= dp[i - 1][j] << 1;
                    } else {
                        dp[i][j] |= dp[i - 1][j] >> 1;
                    }
                }

                if (j > 0) {
                    if (change == 1) {
                        dp[i][j] |= dp[i][j - 1] << 1;
                    } else {
                        dp[i][j] |= dp[i][j - 1] >> 1;
                    }
                }
            }
        }

        return dp[n - 1][m - 1].test(0);
    }
};
```

```Python
class Solution:
    def hasValidPath(self, grid: list[list[str]]) -> bool:
        n = len(grid)
        m = len(grid[0])
        path_len = n + m - 1

        if path_len % 2 == 1:
            return False
        if grid[0][0] != "(" or grid[n - 1][m - 1] != ")":
            return False

        dp = [[0] * m for _ in range(n)]

        dp[0][0] = 1 << 1

        for i in range(n):
            for j in range(m):
                change = 1 if grid[i][j] == "(" else -1

                if i > 0:
                    if change == 1:
                        dp[i][j] |= dp[i - 1][j] << 1
                    else:
                        dp[i][j] |= dp[i - 1][j] >> 1

                if j > 0:
                    if change == 1:
                        dp[i][j] |= dp[i][j - 1] << 1
                    else:
                        dp[i][j] |= dp[i][j - 1] >> 1

        return bool(dp[n - 1][m - 1] & 1)
```

```C
#define BITSET_WORDS 4
#define MAXM 105

typedef struct {
    unsigned long long words[BITSET_WORDS];
} Bitset;

static inline void bitset_clear(Bitset *bs) {
    memset(bs->words, 0, sizeof(bs->words));
}

static inline void bitset_set(Bitset *bs, int pos) {
    bs->words[pos >> 6] |= 1ULL << (pos & 63);
}

static inline bool bitset_test(const Bitset *bs, int pos) {
    return (bs->words[pos >> 6] >> (pos & 63)) & 1ULL;
}

static inline void bitset_or(Bitset *dst, const Bitset *src) {
    for (int w = 0; w < BITSET_WORDS; ++w) {
        dst->words[w] |= src->words[w];
    }
}

static inline void bitset_or_shift_left(Bitset *dst, const Bitset *src) {
    unsigned long long carry = 0;
    for (int w = 0; w < BITSET_WORDS; ++w) {
        unsigned long long cur = src->words[w];
        dst->words[w] |= (cur << 1) | carry;
        carry = cur >> 63;
    }
}

static inline void bitset_or_shift_right(Bitset *dst, const Bitset *src) {
    unsigned long long carry = 0;
    for (int w = BITSET_WORDS - 1; w >= 0; --w) {
        unsigned long long cur = src->words[w];
        dst->words[w] |= (cur >> 1) | carry;
        carry = cur << 63;
    }
}

bool hasValidPath(char** grid, int gridSize, int* gridColSize) {
    const int n = gridSize;
    const int m = gridColSize[0];
    const int pathLen = n + m - 1;

    if (pathLen % 2 == 1) {
        return false;
    }
    if (grid[0][0] != '(' || grid[n - 1][m - 1] != ')') {
        return false;
    }
    Bitset (*dp)[MAXM] = calloc(n * MAXM, sizeof(Bitset));
    bitset_set(&dp[0][0], 1);

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < m; ++j) {
            const int change = grid[i][j] == '(' ? 1 : -1;
            if (i > 0) {
                if (change == 1) {
                    bitset_or_shift_left(&dp[i][j], &dp[i - 1][j]);
                } else {
                    bitset_or_shift_right(&dp[i][j], &dp[i - 1][j]);
                }
            }

            if (j > 0) {
                if (change == 1) {
                    bitset_or_shift_left(&dp[i][j], &dp[i][j - 1]);
                } else {
                    bitset_or_shift_right(&dp[i][j], &dp[i][j - 1]);
                }
            }
        }
    }

    bool result = bitset_test(&dp[n - 1][m - 1], 0);
    free(dp);
    return result;
}
```

```Go
func hasValidPath(grid [][]byte) bool {
	n := len(grid)
	m := len(grid[0])
	pathLen := n + m - 1

	if pathLen%2 == 1 {
		return false
	}
	if grid[0][0] != '(' || grid[n-1][m-1] != ')' {
		return false
	}

	dp := make([][]*big.Int, n)
	for i := 0; i < n; i++ {
		dp[i] = make([]*big.Int, m)
		for j := 0; j < m; j++ {
			dp[i][j] = new(big.Int)
		}
	}

	dp[0][0].SetInt64(2)

	tmp := new(big.Int)
	for i := 0; i < n; i++ {
		for j := 0; j < m; j++ {
			change := -1
			if grid[i][j] == '(' {
				change = 1
			}

			if i > 0 {
				if change == 1 {
					tmp.Lsh(dp[i-1][j], 1)
				} else {
					tmp.Rsh(dp[i-1][j], 1)
				}
				dp[i][j].Or(dp[i][j], tmp)
			}

			if j > 0 {
				if change == 1 {
					tmp.Lsh(dp[i][j-1], 1)
				} else {
					tmp.Rsh(dp[i][j-1], 1)
				}
				dp[i][j].Or(dp[i][j], tmp)
			}
		}
	}

	return dp[n-1][m-1].Bit(0) == 1
}
```

```Java
class Solution {
    public boolean hasValidPath(char[][] grid) {
        int n = grid.length;
        int m = grid[0].length;
        int pathLen = n + m - 1;

        if (pathLen % 2 == 1) {
            return false;
        }
        if (grid[0][0] != '(' || grid[n - 1][m - 1] != ')') {
            return false;
        }

        boolean[][][] dp = new boolean[n][m][pathLen + 1];

        dp[0][0][1] = true;

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                int change = grid[i][j] == '(' ? 1 : -1;

                if (i > 0) {
                    for (int balance = 0; balance <= pathLen; ++balance) {
                        if (!dp[i - 1][j][balance]) {
                            continue;
                        }

                        int next = balance + change;

                        if (next >= 0) {
                            dp[i][j][next] = true;
                        }
                    }
                }

                if (j > 0) {
                    for (int balance = 0; balance <= pathLen; ++balance) {
                        if (!dp[i][j - 1][balance]) {
                            continue;
                        }

                        int next = balance + change;

                        if (next >= 0) {
                            dp[i][j][next] = true;
                        }
                    }
                }
            }
        }

        return dp[n - 1][m - 1][0];
    }
}
```

```CSharp
public class Solution {
    public bool HasValidPath(char[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        int pathLen = n + m - 1;

        if (pathLen % 2 == 1) {
            return false;
        }
        if (grid[0][0] != '(' || grid[n - 1][m - 1] != ')') {
            return false;
        }

        BigInteger[][] dp = new BigInteger[n][];

        for (int i = 0; i < n; ++i) {
            dp[i] = new BigInteger[m];
        }

        dp[0][0] = BigInteger.One << 1;

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                int change = grid[i][j] == '(' ? 1 : -1;

                if (i > 0) {
                    if (change == 1) {
                        dp[i][j] |= dp[i - 1][j] << 1;
                    } else {
                        dp[i][j] |= dp[i - 1][j] >> 1;
                    }
                }

                if (j > 0) {
                    if (change == 1) {
                        dp[i][j] |= dp[i][j - 1] << 1;
                    } else {
                        dp[i][j] |= dp[i][j - 1] >> 1;
                    }
                }
            }
        }

        return (dp[n - 1][m - 1] & 1) == 1;
    }
}
```

```JavaScript
var hasValidPath = function (grid) {
    const n = grid.length;
    const m = grid[0].length;
    const pathLen = n + m - 1;

    if (pathLen % 2 === 1) {
        return false;
    }
    if (grid[0][0] !== '(' || grid[n - 1][m - 1] !== ')') {
        return false;
    }

    const dp = Array.from({ length: n }, () => new Array(m).fill(0n));

    dp[0][0] = 1n << 1n;

    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < m; ++j) {
            const change = grid[i][j] === '(' ? 1 : -1;

            if (i > 0) {
                if (change === 1) {
                    dp[i][j] |= dp[i - 1][j] << 1n;
                } else {
                    dp[i][j] |= dp[i - 1][j] >> 1n;
                }
            }

            if (j > 0) {
                if (change === 1) {
                    dp[i][j] |= dp[i][j - 1] << 1n;
                } else {
                    dp[i][j] |= dp[i][j - 1] >> 1n;
                }
            }
        }
    }

    return (dp[n - 1][m - 1] & 1n) !== 0n;
};
```

```TypeScript
function hasValidPath(grid: string[][]): boolean {
    const n = grid.length;
    const m = grid[0].length;
    const pathLen = n + m - 1;

    if (pathLen % 2 === 1) {
        return false;
    }
    if (grid[0][0] !== '(' || grid[n - 1][m - 1] !== ')') {
        return false;
    }

    const dp: bigint[][] = Array.from({ length: n }, () => new Array(m).fill(0n));

    dp[0][0] = 1n << 1n;

    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < m; ++j) {
            const change = grid[i][j] === '(' ? 1 : -1;

            if (i > 0) {
                if (change === 1) {
                    dp[i][j] |= dp[i - 1][j] << 1n;
                } else {
                    dp[i][j] |= dp[i - 1][j] >> 1n;
                }
            }

            if (j > 0) {
                if (change === 1) {
                    dp[i][j] |= dp[i][j - 1] << 1n;
                } else {
                    dp[i][j] |= dp[i][j - 1] >> 1n;
                }
            }
        }
    }

    return (dp[n - 1][m - 1] & 1n) !== 0n;
}
```

```Rust
impl Solution {
    pub fn has_valid_path(grid: Vec<Vec<char>>) -> bool {
        let n = grid.len();
        let m = grid[0].len();
        let path_len = n + m - 1;

        if path_len % 2 == 1 {
            return false;
        }
        if grid[0][0] != '(' || grid[n - 1][m - 1] != ')' {
            return false;
        }

        let mut dp = vec![vec![vec![false; path_len + 1]; m]; n];

        dp[0][0][1] = true;

        for i in 0..n {
            for j in 0..m {
                let change = if grid[i][j] == '(' { 1 } else { -1 };

                if i > 0 {
                    for balance in 0..=path_len {
                        if !dp[i - 1][j][balance] {
                            continue;
                        }

                        let next = balance as isize + change;

                        if next >= 0 {
                            dp[i][j][next as usize] = true;
                        }
                    }
                }

                if j > 0 {
                    for balance in 0..=path_len {
                        if !dp[i][j - 1][balance] {
                            continue;
                        }

                        let next = balance as isize + change;

                        if next >= 0 {
                            dp[i][j][next as usize] = true;
                        }
                    }
                }
            }
        }

        dp[n - 1][m - 1][0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm\dfrac{n+m}{W})$ 或 $O(nm(n+m))$，其中 $W$ 是机器字长，设输入的 $grid$ 是一个 $n\times m$ 的矩阵，一共有 $n\cdot m$ 个格子，每个格子有 $n+m$ 种状态要进行转移。根据实现不同，该状态转移可能有不同的时间复杂度，详见之前的 **状态转移实现细节** 一节。
- 空间复杂度：$O(nm(n+m))$，即为动态规划数组的空间开销。
