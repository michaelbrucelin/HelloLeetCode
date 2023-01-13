#### ����һ��[ѭ����������λ](https://leetcode.cn/problems/number-of-1-bits/solutions/672082/wei-1de-ge-shu-by-leetcode-solution-jnwf/)

**˼·���ⷨ**

���ǿ���ֱ��ѭ������������ $n$ �Ķ�����λ��ÿһλ�Ƿ�Ϊ $1$��

��������У������� $i$ λʱ�����ǿ����� $n$ �� $2^i$ ���������㣬���ҽ��� $n$ �ĵ� $i$ λΪ $1$ ʱ����������Ϊ $0$��

**����**

```cpp
class Solution {
public:
    int hammingWeight(uint32_t n) {
        int ret = 0;
        for (int i = 0; i < 32; i++) {
            if (n & (1 << i)) {
                ret++;
            }
        }
        return ret;
    }
};
```

```java
public class Solution {
    public int hammingWeight(int n) {
        int ret = 0;
        for (int i = 0; i < 32; i++) {
            if ((n & (1 << i)) != 0) {
                ret++;
            }
        }
        return ret;
    }
}
```

```python
class Solution:
    def hammingWeight(self, n: int) -> int:
        ret = sum(1 for i in range(32) if n & (1 << i)) 
        return ret
```

```go
func hammingWeight(num uint32) (ones int) {
    for i := 0; i < 32; i++ {
        if 1<<i&num > 0 {
            ones++
        }
    }
    return
}
```

```javascript
var hammingWeight = function(n) {
    let ret = 0;
    for (let i = 0; i < 32; i++) {
        if ((n & (1 << i)) !== 0) {
            ret++;
        }
    }
    return ret;
};
```

```c
int hammingWeight(uint32_t n) {
    int ret = 0;
    for (int i = 0; i < 32; i++) {
        if (n & (1u << i)) {
            ret++;
        }
    }
    return ret;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(k)$������ $k$ �� $int$ �͵Ķ�����λ����$k=32$��������Ҫ��� $n$ �Ķ�����λ��ÿһλ��һ����Ҫ��� $32$ λ��
-   �ռ临�Ӷȣ�$O(1)$������ֻ��Ҫ�����Ŀռ䱣�����ɱ�����
