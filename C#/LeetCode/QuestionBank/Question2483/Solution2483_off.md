### [商店的最少代价](https://leetcode.cn/problems/minimum-penalty-for-a-shop/solutions/3859791/shang-dian-de-zui-shao-dai-jie-by-leetco-ddq9/)

#### 方法一：枚举

**思路与算法**

由题意可知，假设第 $i$ 小时关门，那么我们需要统计 $customers[j](0\le j<i)$ 中 ‘N’ 的数量以及 $customers[j](i\le j<n)$ 中 ‘Y’ 的数量之和，其中 $n$ 是 $customers$ 的长度。

我们可以首先统计 $customers$ 中 ‘Y’ 的数量，记为 $suf$。接着，我们从 $i=0$ 开始遍历，使用 $pre$ 记录 $customers[j](0\le j<i)$ 中 ‘N’ 的数量，使用 $suf$ 记录 $customers[j](i\le j<n)$ 中 ‘Y’ 的数量，每次使用 $pre$ 加上 $suf$ 来更新答案。然后，每次 $customers[i]$ 为 ‘N’ 时，令 $pre$ 增加 $1$，否则 $customers[i]$ 为 ‘Y’，令 $suf$ 减去 $1$。遍历结束可以求出令 $pre+suf$ 取得最小值时最小的 $i$，即为答案。

值得一提的是，题目并不关心最小代价的具体数值，因此最初统计 $suf$ 的逻辑可以省去，我们可以把第一天就关门的代价作为基准代价，然后在此基础上求解代价最小时的最早关门时间。

**代码**

```C++
class Solution {
public:
    int bestClosingTime(string customers) {
        int n = customers.size();
        int suf = 0;
        int pre = 0;
        int min_cost = 0, res = 0;
        for (int i = 0; i <= n; i++) {
            if (min_cost > suf + pre) {
                min_cost = suf + pre;
                res = i;
            }
            if (i < n && customers[i] == 'N') {
                pre++;
            } else {
                suf--;
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def bestClosingTime(self, customers: str) -> int:
        n = len(customers)
        suf = 0 
        pre = 0
        min_cost = 0
        res = 0
        
        for i in range(n + 1):
            cost = suf + pre
            
            if min_cost > cost:
                min_cost = cost
                res = i
            
            if i < n:
                if customers[i] == 'N':
                    pre += 1
                else:
                    suf -= 1
        
        return res
```

```Rust
impl Solution {
    pub fn best_closing_time(customers: String) -> i32 {
        let n = customers.len();
        let chars: Vec<char> = customers.chars().collect();
        
        let mut suf = 0;
        let mut pre = 0;
        let mut min_cost = 0;
        let mut res = 0;
        
        for i in 0..=n {
            let cost = suf + pre;

            if min_cost > cost {
                min_cost = cost;
                res = i as i32;
            }

            if i < n {
                if chars[i] == 'N' {
                    pre += 1;
                } else {
                    suf -= 1;
                }
            }
        }
        
        res
    }
}
```

```Java
class Solution {
    public int bestClosingTime(String customers) {
        int n = customers.length();
        int suf = 0;
        int pre = 0;
        int minCost = 0;
        int res = 0;
        
        for (int i = 0; i <= n; i++) {
            if (minCost > suf + pre) {
                minCost = suf + pre;
                res = i;
            }
            if (i < n && customers.charAt(i) == 'N') {
                pre++;
            } else if (i < n) {
                suf--;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int BestClosingTime(string customers) {
        int n = customers.Length;
        int suf = 0;
        int pre = 0;
        int minCost = 0;
        int res = 0;
        
        for (int i = 0; i <= n; i++) {
            if (minCost > suf + pre) {
                minCost = suf + pre;
                res = i;
            }
            if (i < n && customers[i] == 'N') {
                pre++;
            } else if (i < n) {
                suf--;
            }
        }
        return res;
    }
}
```

```Go
func bestClosingTime(customers string) int {
    n := len(customers)
    suf := 0
    pre := 0
    minCost := 0
    res := 0
    
    for i := 0; i <= n; i++ {
        if minCost > suf + pre {
            minCost = suf + pre
            res = i
        }
        if i < n && customers[i] == 'N' {
            pre++
        } else if i < n {
            suf--
        }
    }
    return res
}
```

```C
int bestClosingTime(char* customers) {
    int n = strlen(customers);
    int suf = 0;
    int pre = 0;
    int min_cost = 0;
    int res = 0;
    
    for (int i = 0; i <= n; i++) {
        if (min_cost > suf + pre) {
            min_cost = suf + pre;
            res = i;
        }
        if (i < n && customers[i] == 'N') {
            pre++;
        } else if (i < n) {
            suf--;
        }
    }
    return res;
}
```

```JavaScript
var bestClosingTime = function(customers) {
    const n = customers.length;
    let suf = 0;
    let pre = 0;
    let minCost = 0;
    let res = 0;
    
    for (let i = 0; i <= n; i++) {
        if (minCost > suf + pre) {
            minCost = suf + pre;
            res = i;
        }
        if (i < n && customers[i] === 'N') {
            pre++;
        } else if (i < n) {
            suf--;
        }
    }
    return res;
};
```

```TypeScript
function bestClosingTime(customers: string): number {
    const n = customers.length;
    let suf = 0;
    let pre = 0;
    let minCost = 0;
    let res = 0;
    
    for (let i = 0; i <= n; i++) {
        if (minCost > suf + pre) {
            minCost = suf + pre;
            res = i;
        }
        if (i < n && customers[i] === 'N') {
            pre++;
        } else if (i < n) {
            suf--;
        }
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $customers$ 的长度。我们需要 $O(n)$ 的时间遍历 $i$ 并计算答案。
- 空间复杂度：$O(1)$。我们只额外申请了常数个变量。
