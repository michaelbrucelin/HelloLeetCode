#### [��������������ö��](https://leetcode.cn/problems/binary-watch/solutions/837337/er-jin-zhi-shou-biao-by-leetcode-solutio-3559/)

��һ��ö�ٷ�����ö������ $2^{10}=1024$ �ֵƵĿ�����ϣ�����һ������������ʾ�ƵĿ��գ���� $4$ λΪСʱ���� $6$ λΪ���ӡ���Сʱ�ͷ��ӵ�ֵ���ںϷ���Χ�ڣ��Ҷ������� $1$ �ĸ���Ϊ $turnedOn$��������뵽���С�

```cpp
class Solution {
public:
    vector<string> readBinaryWatch(int turnedOn) {
        vector<string> ans;
        for (int i = 0; i < 1024; ++i) {
            int h = i >> 6, m = i & 63; // ��λ����ȡ���� 4 λ�͵� 6 λ
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
            int h = i >> 6, m = i & 63; // ��λ����ȡ���� 4 λ�͵� 6 λ
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
            int h = i >> 6, m = i & 63; // ��λ����ȡ���� 4 λ�͵� 6 λ
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
        h, m := i>>6, i&63 // ��λ����ȡ���� 4 λ�͵� 6 λ
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
        let h = i >> 6, m = i & 63; // ��λ����ȡ���� 4 λ�͵� 6 λ
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
            h, m = i >> 6, i & 0x3f   # ��λ����ȡ���� 4 λ�͵� 6 λ
            if h < 12 and m < 60 and bin(i).count("1") == turnedOn:
                ans.append(f"{h}:{m:02d}")
        return ans
```

```c
char** readBinaryWatch(int turnedOn, int* returnSize) {
    char** ans = malloc(sizeof(char*) * 12 * 60);
    *returnSize = 0;
    for (int i = 0; i < 1024; ++i) {
        int h = i >> 6, m = i & 63;  // ��λ����ȡ���� 4 λ�͵� 6 λ
        if (h < 12 && m < 60 && __builtin_popcount(i) == turnedOn) {
            char* tmp = malloc(sizeof(char) * 6);
            sprintf(tmp, "%d:%02d", h, m);
            ans[(*returnSize)++] = tmp;
        }
    }

    return ans;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��ö�ٵĴ�����һ���������޹صĶ�ֵ��
-   �ռ临�Ӷȣ�$O(1)$����ʹ���˳�����С�Ŀռ䡣ע�ⷵ��ֵ������ռ临�Ӷȡ�

���⻹������λ���㣬ö��ǡ���� $turnedOn$ �� $1$ �Ķ��������ķ���������������ƪ���ķ�Χ������Ȥ�Ķ��߿����в���������ϡ�
