#### [����һ��ö��ʱ��](https://leetcode.cn/problems/binary-watch/solutions/837337/er-jin-zhi-shou-biao-by-leetcode-solutio-3559/)

�������֪��Сʱ�� $4$ �����ر�ʾ�������� $6$ �����ر�ʾ������λֵΪ $0$ ��ʾ����Ϊ $1$ ��ʾ������

���ǿ���ö��Сʱ�����п���ֵ $[0,11]$���Լ����ӵ����п���ֵ $[0,59]$����������ߵĶ������� $1$ �ĸ���֮�ͣ���Ϊ $turnedOn$��������뵽���С�

```cpp
class Solution {
public:
    vector<string> readBinaryWatch(int turnedOn) {
        vector<string> ans;
        for (int h = 0; h < 12; ++h) {
            for (int m = 0; m < 60; ++m) {
                if (__builtin_popcount(h) + __builtin_popcount(m) == turnedOn) {
                    ans.push_back(to_string(h) + ":" + (m < 10 ? "0" : "") + to_string(m));
                }
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
        for (int h = 0; h < 12; ++h) {
            for (int m = 0; m < 60; ++m) {
                if (Integer.bitCount(h) + Integer.bitCount(m) == turnedOn) {
                    ans.add(h + ":" + (m < 10 ? "0" : "") + m);
                }
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
        for (int h = 0; h < 12; ++h) {
            for (int m = 0; m < 60; ++m) {
                if (BitCount(h) + BitCount(m) == turnedOn) {
                    ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
                }
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
    for h := uint8(0); h < 12; h++ {
        for m := uint8(0); m < 60; m++ {
            if bits.OnesCount8(h)+bits.OnesCount8(m) == turnedOn {
                ans = append(ans, fmt.Sprintf("%d:%02d", h, m))
            }
        }
    }
    return
}
```

```javascript
var readBinaryWatch = function(turnedOn) {
    const ans = [];
    for (let h = 0; h < 12; ++h) {
        for (let m = 0; m < 60; ++m) {
            if (h.toString(2).split('0').join('').length + m.toString(2).split('0').join('').length === turnedOn) {
                ans.push(h + ":" + (m < 10 ? "0" : "") + m);
            }
        }
    }
    return ans;
};
```

```python
class Solution:
    def readBinaryWatch(self, turnedOn: int) -> List[str]:
        ans = list()
        for h in range(12):
            for m in range(60):
                if bin(h).count("1") + bin(m).count("1") == turnedOn:
                    ans.append(f"{h}:{m:02d}")
        return ans
```

```c
char** readBinaryWatch(int turnedOn, int* returnSize) {
    char** ans = malloc(sizeof(char*) * 12 * 60);
    *returnSize = 0;
    for (int h = 0; h < 12; ++h) {
        for (int m = 0; m < 60; ++m) {
            if (__builtin_popcount(h) + __builtin_popcount(m) == turnedOn) {
                char* tmp = malloc(sizeof(char) * 6);
                sprintf(tmp, "%d:%02d", h, m);
                ans[(*returnSize)++] = tmp;
            }
        }
    }
    return ans;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��ö�ٵĴ�����һ���������޹صĶ�ֵ��
-   �ռ临�Ӷȣ�$O(1)$����ʹ���˳�����С�Ŀռ䡣ע�ⷵ��ֵ������ռ临�Ӷȡ�
