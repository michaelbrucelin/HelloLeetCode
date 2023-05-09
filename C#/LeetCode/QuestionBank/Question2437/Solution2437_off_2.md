#### [方法二：分开枚举](https://leetcode.cn/problems/number-of-valid-clock-times/solutions/2261803/you-xiao-shi-jian-de-shu-mu-by-leetcode-j7gqz/)

**思路与算法**

由于题目中小时和分钟的限制不同，因此没有必要枚举所有可能的数字，由于小时和分钟限制如下：

-   $"00" \le hh \le "23"$；
-   $"00" \le mm \le "59"$；

我们检测所有符合当前字符串 $time$ 匹配的小时 $hh$ 的数目为 $countHour$，同时检测检测所有符合当前字符串 $time$ 匹配的分钟 $hh$ 的数目为 $countMinute$，则合法有效的时间数目为 $countHour \times countMinute$。

**代码**

```cpp
class Solution {
public:
    int countTime(string time) {
        int countHour = 0;
        int countMinute = 0;
        for (int i = 0; i < 24; i++) {
            int hiHour = i / 10;
            int loHour = i % 10;
            if ((time[0] == '?' || time[0] == hiHour + '0') && 
                (time[1] == '?' || time[1] == loHour + '0')) {
                countHour++;
            }
        } 
        for (int i = 0; i < 60; i++) {
            int hiMinute = i / 10;
            int loMinute = i % 10;
            if ((time[3] == '?' || time[3] == hiMinute + '0') && 
                (time[4] == '?' || time[4] == loMinute + '0')) {
                countMinute++;
            }
        }
        return countHour * countMinute;
    }
};
```

```java
class Solution {
    public int countTime(String time) {
        int countHour = 0;
        int countMinute = 0;
        for (int i = 0; i < 24; i++) {
            int hiHour = i / 10;
            int loHour = i % 10;
            if ((time.charAt(0) == '?' || time.charAt(0) == hiHour + '0') && 
                (time.charAt(1) == '?' || time.charAt(1) == loHour + '0')) {
                countHour++;
            }
        } 
        for (int i = 0; i < 60; i++) {
            int hiMinute = i / 10;
            int loMinute = i % 10;
            if ((time.charAt(3) == '?' || time.charAt(3) == hiMinute + '0') && 
                (time.charAt(4) == '?' || time.charAt(4) == loMinute + '0')) {
                countMinute++;
            }
        }
        return countHour * countMinute;
    }
}
```

```csharp
public class Solution {
    public int CountTime(string time) {
        int countHour = 0;
        int countMinute = 0;
        for (int i = 0; i < 24; i++) {
            int hiHour = i / 10;
            int loHour = i % 10;
            if ((time[0] == '?' || time[0] == hiHour + '0') && 
                (time[1] == '?' || time[1] == loHour + '0')) {
                countHour++;
            }
        } 
        for (int i = 0; i < 60; i++) {
            int hiMinute = i / 10;
            int loMinute = i % 10;
            if ((time[3] == '?' || time[3] == hiMinute + '0') && 
                (time[4] == '?' || time[4] == loMinute + '0')) {
                countMinute++;
            }
        }
        return countHour * countMinute;
    }
}
```

```c
int countTime(char * time) {
    int countHour = 0;
    int countMinute = 0;
    for (int i = 0; i < 24; i++) {
        int hiHour = i / 10;
        int loHour = i % 10;
        if ((time[0] == '?' || time[0] == hiHour + '0') && 
            (time[1] == '?' || time[1] == loHour + '0')) {
            countHour++;
        }
    } 
    for (int i = 0; i < 60; i++) {
        int hiMinute = i / 10;
        int loMinute = i % 10;
        if ((time[3] == '?' || time[3] == hiMinute + '0') && 
            (time[4] == '?' || time[4] == loMinute + '0')) {
            countMinute++;
        }
    }
    return countHour * countMinute;
}
```

```python
class Solution:
    def countTime(self, time: str) -> int:
        countHour = 0
        countMinute = 0
        for i in range(24):
            hiHour = i // 10
            loHour = i % 10
            if ((time[0] == '?' or int(time[0]) == hiHour) and
                    (time[1] == '?' or int(time[1]) == loHour)):
                countHour += 1

        for i in range(60):
            hiMinute = i // 10
            loMinute = i % 10
            if ((time[3] == '?' or int(time[3]) == hiMinute) and
                    (time[4] == '?' or int(time[4]) == loMinute)):
                countMinute += 1

        return countHour * countMinute
```

```javascript
var countTime = function(time) {
    let res = 0;
        const dfs = (arr, pos) => {
        if (pos === arr.length) {
            if (check(arr)) {
                res++;
            }
            return;
        }
        if (arr[pos] === '?') {
            for (let i = 0; i <= 9; i++) {
                arr[pos] = String.fromCharCode('0'.charCodeAt() + i);
                dfs(arr, pos + 1);
                arr[pos] = '?';
            }
        } else {
            dfs(arr, pos + 1);
        }
    }

    const check = (arr) => {
        const hh = (arr[0].charCodeAt() - '0'.charCodeAt()) * 10 + arr[1].charCodeAt() - '0'.charCodeAt();
        const mm = (arr[3].charCodeAt() - '0'.charCodeAt()) * 10 + arr[4].charCodeAt() - '0'.charCodeAt();
        return hh < 24 && mm < 60;
    };
    const arr = [...time];
    dfs(arr, 0);
    return res;
}
```

```go
func countTime(time string) int {
    countHour := 0
    countMinute := 0
    for i := 0; i < 24; i++ {
        hiHour := byte(i / 10)
        loHour := byte(i % 10)
        if (time[0] == '?' || time[0] == hiHour+'0') &&
            (time[1] == '?' || time[1] == loHour+'0') {
            countHour++
        }
    }
    for i := 0; i < 60; i++ {
        hiMinute := byte(i / 10)
        loMinute := byte(i % 10)
        if (time[3] == '?' || time[3] == hiMinute+'0') &&
            (time[4] == '?' || time[4] == loMinute+'0') {
            countMinute++
        }
    }
    return countHour * countMinute
}
```

**复杂度分析**

-   时间复杂度：$O(1)$。由于时钟的最大值为 $24$，分钟的最大值为 $60$，在此题解中分别枚举所可能的时钟，以及所有可能分钟，时间复杂度为 $O(24 + 60) = O(1)$。
-   空间复杂度：$O(1)$。
