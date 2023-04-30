#### [���������ж��Ƿ�Ϊ��� $3$ ���ݵ�Լ��](https://leetcode.cn/problems/power-of-three/solutions/1011809/3de-mi-by-leetcode-solution-hnap/)

**˼·���㷨**

���ǻ�����ʹ��һ�ֽ�Ϊȡ�ɵ�������

����Ŀ������ $32$ λ�з��������ķ�Χ�ڣ����� $3$ ����Ϊ $3^{19} = 1162261467$������ֻ��Ҫ�ж� $n$ �Ƿ��� $3^{19}$ ��Լ�����ɡ�

�뷽��һ��ͬ���ǣ�������Ҫ�����ж� $n$ �Ǹ����� $0$ �������

**����**

```cpp
class Solution {
public:
    bool isPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
};
```

```java
class Solution {
    public boolean isPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
}
```

```c
public class Solution {
    public bool IsPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
}
```

```python
class Solution:
    def isPowerOfThree(self, n: int) -> bool:
        return n > 0 and 1162261467 % n == 0
```

```javascript
var isPowerOfThree = function(n) {
    return n > 0 && 1162261467 % n === 0;
};
```

```go
func isPowerOfThree(n int) bool {
    return n > 0 && 1162261467%n == 0
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��
-   �ռ临�Ӷȣ�$O(1)$��
