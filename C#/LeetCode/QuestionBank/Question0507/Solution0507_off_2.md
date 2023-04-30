#### [����������ѧ](https://leetcode.cn/problems/perfect-number/solutions/1179051/wan-mei-shu-by-leetcode-solution-d5pw/)

����ŷ�����-ŷ������ÿ��ż��ȫ��������д��

$$2^{p-1}(2^p-1)$$

����ʽ������ $p$ Ϊ������ $2^p-1$ Ϊ������

����Ŀǰ����ȫ����δ�����֣������Ŀ��Χ $[1,10^8]$ �ڵ���ȫ��������д��������ʽ��

��һ�������� $5$ ����

$$6, 28, 496, 8128, 33550336$$

```python
class Solution:
    def checkPerfectNumber(self, num: int) -> bool:
        return num == 6 or num == 28 or num == 496 or num == 8128 or num == 33550336
```

```cpp
class Solution {
public:
    bool checkPerfectNumber(int num) {
        return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
    }
};
```

```java
class Solution {
    public boolean checkPerfectNumber(int num) {
        return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
    }
}
```

```csharp
public class Solution {
    public bool CheckPerfectNumber(int num) {
        return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
    }
}
```

```go
func checkPerfectNumber(num int) bool {
    return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336
}
```

```c
bool checkPerfectNumber(int num){
    return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
}
```

```javascript
var checkPerfectNumber = function(num) {
    return num === 6 || num === 28 || num === 496 || num === 8128 || num === 33550336;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��
-   �ռ临�Ӷȣ�$O(1)$��
