#### [方法一：直接比较字符串](https://leetcode.cn/problems/determine-if-two-events-have-conflict/solutions/2272001/pan-duan-liang-ge-shi-jian-shi-fou-cun-z-cqcv/)

**思路**

当两个事件不存在冲突的充要条件是一个事件的结束时间早于另一个事件的开始时间，可以直接用字符串的比较判断两个事件是否存在冲突。

**代码**

```python
class Solution:
    def haveConflict(self, event1: List[str], event2: List[str]) -> bool:
        return not(event1[1] < event2[0] or event2[1] < event1[0])
```

```java
class Solution {
    public boolean haveConflict(String[] event1, String[] event2) {
        return !(event1[1].compareTo(event2[0]) < 0 || event2[1].compareTo(event1[0]) < 0);
    }
}
```

```csharp
public class Solution {
    public bool HaveConflict(string[] event1, string[] event2) {
        return !(event1[1].CompareTo(event2[0]) < 0 || event2[1].CompareTo(event1[0]) < 0);
    }
}
```

```cpp
class Solution {
public:
    bool haveConflict(vector<string>& event1, vector<string>& event2) {
        return !(event1[1] < event2[0] || event2[1] < event1[0]);
    }
};
```

```go
func haveConflict(event1 []string, event2 []string) bool {
    return !(event1[1] < event2[0] || event2[1] < event1[0]);
}
```

```javascript
var haveConflict = function(event1, event2) {
    return !(event1[1] < event2[0] || event2[1] < event1[0]);
};
```

```c
bool haveConflict(char ** event1, int event1Size, char ** event2, int event2Size) {
    return !(strcmp(event1[1], event2[0]) < 0 || strcmp(event2[1], event1[0]) < 0);
}
```

**复杂度分析**

-   时间复杂度：$O(1)$，仅使用常数时间。
-   空间复杂度：$O(1)$，仅使用常数空间。
