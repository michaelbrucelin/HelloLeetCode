### [气温变化趋势](https://leetcode.cn/problems/6CE719/solutions/2813272/qi-wen-bian-hua-qu-shi-by-leetcode-solut-j2w4/)

#### 方法一：一次遍历

**思路与算法**

我们对每天的气温进行一次遍历。在第 $i~(i \geq 1)$ 天时，根据给定的两个数组，得到从第 $i-1$ 天到第 $i$ 天的气温变化趋势 $\textit{ta}$ 和 $\textit{tb}$。如果二者相同，那么连续天数增加 $1$，否则连续天数清零。

这里 $\textit{ta}$ 和 $\textit{tb}$ 可以用 $\{ -1, 0, 1 \}$ 中的元素进行表示：$-1$ 表示上升趋势，$0$ 表示平稳趋势，$1$ 表示下降趋势。这样就可以直接对趋势进行比较。

遍历完成后，连续天数的最大值即为答案。

**代码**

```C++
class Solution {
public:
    int temperatureTrend(vector<int>& temperatureA, vector<int>& temperatureB) {
        auto getTrend = [](int x, int y) -> int {
            if (x == y) {
                return 0;
            }
            return x < y ? -1 : 1;
        };

        int n = temperatureA.size();
        int ans = 0, cur = 0;
        for (int i = 1; i < n; ++i) {
            int ta = getTrend(temperatureA[i - 1], temperatureA[i]);
            int tb = getTrend(temperatureB[i - 1], temperatureB[i]);
            if (ta == tb) {
                ++cur;
                ans = max(ans, cur);
            }
            else {
                cur = 0;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int temperatureTrend(int[] temperatureA, int[] temperatureB) {
        int n = temperatureA.length;
        int ans = 0, cur = 0;
        for (int i = 1; i < n; ++i) {
            int ta = getTrend(temperatureA[i - 1], temperatureA[i]);
            int tb = getTrend(temperatureB[i - 1], temperatureB[i]);
            if (ta == tb) {
                ++cur;
                ans = Math.max(ans, cur);
            } else {
                cur = 0;
            }
        }
        return ans;
    }

    public int getTrend(int x, int y) {
        if (x == y) {
            return 0;
        }
        return x < y ? -1 : 1;
    }
}
```

```CSharp
public class Solution {
    public int TemperatureTrend(int[] temperatureA, int[] temperatureB) {
        int n = temperatureA.Length;
        int ans = 0, cur = 0;
        for (int i = 1; i < n; ++i) {
            int ta = GetTrend(temperatureA[i - 1], temperatureA[i]);
            int tb = GetTrend(temperatureB[i - 1], temperatureB[i]);
            if (ta == tb) {
                ++cur;
                ans = Math.Max(ans, cur);
            } else {
                cur = 0;
            }
        }
        return ans;
    }

    public int GetTrend(int x, int y) {
        if (x == y) {
            return 0;
        }
        return x < y ? -1 : 1;
    }
}
```

```Python
class Solution:
    def temperatureTrend(self, temperatureA: List[int], temperatureB: List[int]) -> int:
        def getTrend(x: int, y: int) -> int:
            if x == y:
                return 0
            return -1 if x < y else 1
        
        n = len(temperatureA)
        ans = cur = 0
        for i in range(1, n):
            ta = getTrend(temperatureA[i - 1], temperatureA[i])
            tb = getTrend(temperatureB[i - 1], temperatureB[i])
            if ta == tb:
                cur += 1
                ans = max(ans, cur)
            else:
                cur = 0
        return ans
```

```C
static int getTrend(int x, int y) {
    if (x == y) {
        return 0;
    }
    return x < y ? -1 : 1;
};

int temperatureTrend(int* temperatureA, int temperatureASize, int* temperatureB, int temperatureBSize) {
    int n = temperatureASize;
    int ans = 0, cur = 0;
    for (int i = 1; i < n; ++i) {
        int ta = getTrend(temperatureA[i - 1], temperatureA[i]);
        int tb = getTrend(temperatureB[i - 1], temperatureB[i]);
        if (ta == tb) {
            ++cur;
            ans = fmax(ans, cur);
        }
        else {
            cur = 0;
        }
    }
    return ans;
}
```

```Go
func temperatureTrend(temperatureA []int, temperatureB []int) int {
    n := len(temperatureA)
    ans := 0
    cur := 0
    for i := 1; i < n; i++ {
        ta := getTrend(temperatureA[i - 1], temperatureA[i])
        tb := getTrend(temperatureB[i - 1], temperatureB[i])
        if ta == tb {
            cur++
            ans = max(ans, cur)
        } else {
            cur = 0
        }
    }
    return ans
}

func getTrend(x, y int) int {
    if x == y {
        return 0
    }
    if x < y {
        return -1
    }
    return 1
}
```

```JavaScript
var temperatureTrend = function(temperatureA, temperatureB) {
    const getTrend = (x, y) => {
        if (x === y) {
            return 0;
        }
        return x < y ? -1 : 1;
    }

    const n = temperatureA.length;
    let ans = 0, cur = 0;
    for (let i = 1; i < n; ++i) {
        const ta = getTrend(temperatureA[i - 1], temperatureA[i]);
        const tb = getTrend(temperatureB[i - 1], temperatureB[i]);
        if (ta === tb) {
        ++cur;
        ans = Math.max(ans, cur);
        } else {
        cur = 0;
        }
    }
    return ans;
};
```

```TypeScript
function temperatureTrend(temperatureA: number[], temperatureB: number[]): number {
    const n = temperatureA.length;
    let ans = 0, cur = 0;
    for (let i = 1; i < n; ++i) {
        const ta = getTrend(temperatureA[i - 1], temperatureA[i]);
        const tb = getTrend(temperatureB[i - 1], temperatureB[i]);
        if (ta === tb) {
            ++cur;
            ans = Math.max(ans, cur);
        } else {
            cur = 0;
        }
    }
    return ans;
};

function getTrend(x: number, y: number): number {
    if (x === y) {
        return 0;
    }
    return x < y ? -1 : 1;
}
```

```Rust
impl Solution {
    pub fn temperature_trend(temperature_a: Vec<i32>, temperature_b: Vec<i32>) -> i32 {
        fn get_trend(x: i32, y: i32) -> i32 {
            if x == y {
                return 0;
            }
            return if x < y {-1} else {1};
        }

        let n = temperature_a.len();
        let mut ans = 0;
        let mut cur = 0;
        for i in 1..n {
            let ta = get_trend(temperature_a[i - 1], temperature_a[i]);
            let tb = get_trend(temperature_b[i - 1], temperature_b[i]);
            if ta == tb {
                cur += 1;
                ans = ans.max(cur);
            } else {
                cur = 0;
            }
        }
        ans
    }
    
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $\textit{temperatureA}$ 的长度。
- 空间复杂度：$O(1)$。
