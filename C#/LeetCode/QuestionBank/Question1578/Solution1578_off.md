### [使绳子变成彩色的最短时间](https://leetcode.cn/problems/minimum-time-to-make-rope-colorful/solutions/440327/bi-mian-zhong-fu-zi-mu-de-zui-xiao-shan-chu-chen-4/)

#### 方法一：贪心

**思路与算法**

根据题意可以知道，如果字符串 $colors$ 中有若干相邻的重复颜色，则这些颜色中最多只能保留一个。因此，我们可以采取贪心的策略：在这一系列重复颜色中，我们保留删除成本最高的颜色，并删除其他颜色。这样得到的删除成本一定是最低的。

**代码**

```C++
class Solution {
public:
    int minCost(string colors, vector<int>& neededTime) {
        int i = 0, len = colors.length();
        int ret = 0;
        while (i < len) {
            char ch = colors[i];
            int maxValue = 0;
            int sum = 0;

            while (i < len && colors[i] == ch) {
                maxValue = max(maxValue, neededTime[i]);
                sum += neededTime[i];
                i++;
            }
            ret += sum - maxValue;
        }
        return ret;
    }
};
```

```Java
class Solution {
    public int minCost(String colors, int[] neededTime) {
        int i = 0, len = colors.length();
        int ret = 0;
        while (i < len) {
            char ch = colors.charAt(i);
            int maxValue = 0;
            int sum = 0;

            while (i < len && colors.charAt(i) == ch) {
                maxValue = Math.max(maxValue, neededTime[i]);
                sum += neededTime[i];
                i++;
            }
            ret += sum - maxValue;
        }
        return ret;
    }
}
```

```CSharp
public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        int i = 0, len = colors.Length;
        int ret = 0;
        while (i < len) {
            char ch = colors[i];
            int maxValue = 0;
            int sum = 0;

            while (i < len && colors[i] == ch) {
                maxValue = Math.Max(maxValue, neededTime[i]);
                sum += neededTime[i];
                i++;
            }
            ret += sum - maxValue;
        }
        return ret;
    }
}
```

```Python
class Solution:
    def minCost(self, colors: str, neededTime: List[int]) -> int:
        i = 0
        length = len(colors)
        ret = 0

        while i < length:
            ch = colors[i]
            maxValue = 0
            total = 0

            while i < length and colors[i] == ch:
                maxValue = max(maxValue, neededTime[i])
                total += neededTime[i]
                i += 1
            
            ret += total - maxValue
        
        return ret
```

```C
int minCost(char* colors, int* neededTime, int neededTimeSize) {
    int i = 0;
    int ret = 0;
    while (i < neededTimeSize) {
        char ch = colors[i];
        int maxValue = 0;
        int sum = 0;

        while (i < neededTimeSize && colors[i] == ch) {
            maxValue = fmax(maxValue, neededTime[i]);
            sum += neededTime[i];
            i++;
        }
        ret += sum - maxValue;
    }
    return ret;
}
```

```Go
func minCost(colors string, neededTime []int) int {
    i, n := 0, len(colors)
    ret := 0
    for i < n {
        ch := colors[i]
        maxValue := 0
        sum := 0
        
        for i < n && colors[i] == ch {
            if neededTime[i] > maxValue {
                maxValue = neededTime[i]
            }
            sum += neededTime[i]
            i++
        }
        ret += sum - maxValue
    }
    return ret
}
```

```JavaScript
var minCost = function(colors, neededTime) {
    let i = 0, len = colors.length;
    let ret = 0;
    while (i < len) {
        const ch = colors[i];
        let maxValue = 0;
        let sum = 0;

        while (i < len && colors[i] === ch) {
            maxValue = Math.max(maxValue, neededTime[i]);
            sum += neededTime[i];
            i++;
        }
        ret += sum - maxValue;
    }
    return ret;
};
```

```TypeScript
function minCost(colors: string, neededTime: number[]): number {
    let i = 0, len = colors.length;
    let ret = 0;
    while (i < len) {
        const ch = colors[i];
        let maxValue = 0;
        let sum = 0;

        while (i < len && colors[i] === ch) {
            maxValue = Math.max(maxValue, neededTime[i]);
            sum += neededTime[i];
            i++;
        }
        ret += sum - maxValue;
    }
    return ret;
};
```

```Rust
impl Solution {
    pub fn min_cost(colors: String, needed_time: Vec<i32>) -> i32 {
        let mut i = 0;
        let len = colors.len();
        let mut ret = 0;
        let colors = colors.chars().collect::<Vec<char>>();
        
        while i < len {
            let ch = colors[i];
            let mut max_value = 0;
            let mut sum = 0;

            while i < len && colors[i] == ch {
                max_value = max_value.max(needed_time[i]);
                sum += needed_time[i];
                i += 1;
            }
            ret += sum - max_value;
        }
        ret
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为字符串的长度。我们只需对字符串进行一次线性的扫描。
- 空间复杂度：$O(1)$。我们只开辟了常量大小的空间。
