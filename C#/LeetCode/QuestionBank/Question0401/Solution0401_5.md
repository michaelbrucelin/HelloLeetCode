#### [方法二：二进制枚举](https://leetcode.cn/problems/binary-watch/solutions/837337/er-jin-zhi-shou-biao-by-leetcode-solutio-3559/)

另一种枚举方法是枚举所有 $2^{10}=1024$ 种灯的开闭组合，即用一个二进制数表示灯的开闭，其高 $4$ 位为小时，低 $6$ 位为分钟。若小时和分钟的值均在合法范围内，且二进制中 $1$ 的个数为 $turnedOn$，则将其加入到答案中。

```cpp
class Solution {
public:
    vector<string> readBinaryWatch(int turnedOn) {
        vector<string> ans;
        for (int i = 0; i < 1024; ++i) {
            int h = i >> 6, m = i & 63; // 用位运算取出高 4 位和低 6 位
            if (h < 12 && m < 60 && __builtin_popcount(i) == turnedOn) {
                ans.push_back(to_string(h) + ":" + (m < 10 ? "0" : "") + to_string(m));
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public List<String> readBinaryWatch(int turnedOn) {
        List<String> ans = new ArrayList<String>();
        for (int i = 0; i < 1024; ++i) {
            int h = i >> 6, m = i & 63; // 用位运算取出高 4 位和低 6 位
            if (h < 12 && m < 60 && Integer.bitCount(i) == turnedOn) {
                ans.add(h + ":" + (m < 10 ? "0" : "") + m);
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        IList<String> ans = new List<String>();
        for (int i = 0; i < 1024; ++i) {
            int h = i >> 6, m = i & 63; // 用位运算取出高 4 位和低 6 位
            if (h < 12 && m < 60 && BitCount(i) == turnedOn) {
                ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
            }
        }
        return ans;
    }

    private static int BitCount(int i) {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        i = (i + (i >> 4)) & 0x0f0f0f0f;
        i = i + (i >> 8);
        i = i + (i >> 16);
        return i & 0x3f;
    }
}
```

```go
func readBinaryWatch(turnedOn int) (ans []string) {
    for i := 0; i < 1024; i++ {
        h, m := i>>6, i&63 // 用位运算取出高 4 位和低 6 位
        if h < 12 && m < 60 && bits.OnesCount(uint(i)) == turnedOn {
            ans = append(ans, fmt.Sprintf("%d:%02d", h, m))
        }
    }
    return
}
```

```javascript
var readBinaryWatch = function(turnedOn) {
    const ans = [];
    for (let i = 0; i < 1024; ++i) {
        let h = i >> 6, m = i & 63; // 用位运算取出高 4 位和低 6 位
        if (h < 12 && m < 60 && i.toString(2).split('0').join('').length === turnedOn) {
            ans.push(h + ":" + (m < 10 ? "0" : "") + m);
        }
    }
    return ans;
};
```

```python
class Solution:
    def readBinaryWatch(self, turnedOn: int) -> List[str]:
        ans = list()
        for i in range(1024):
            h, m = i >> 6, i & 0x3f   # 用位运算取出高 4 位和低 6 位
            if h < 12 and m < 60 and bin(i).count("1") == turnedOn:
                ans.append(f"{h}:{m:02d}")
        return ans
```

```c
char** readBinaryWatch(int turnedOn, int* returnSize) {
    char** ans = malloc(sizeof(char*) * 12 * 60);
    *returnSize = 0;
    for (int i = 0; i < 1024; ++i) {
        int h = i >> 6, m = i & 63;  // 用位运算取出高 4 位和低 6 位
        if (h < 12 && m < 60 && __builtin_popcount(i) == turnedOn) {
            char* tmp = malloc(sizeof(char) * 6);
            sprintf(tmp, "%d:%02d", h, m);
            ans[(*returnSize)++] = tmp;
        }
    }

    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(1)$。枚举的次数是一个与输入无关的定值。
-   空间复杂度：$O(1)$。仅使用了常数大小的空间。注意返回值不计入空间复杂度。

本题还有利用位运算，枚举恰好有 $turnedOn$ 个 $1$ 的二进制数的方法，但超出了这篇题解的范围，有兴趣的读者可自行查阅相关资料。
