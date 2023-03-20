#### [�����������ֲ���](https://leetcode.cn/problems/jJ0w9p/solutions/1398892/qiu-ping-fang-gen-by-leetcode-solution-ybnw/)

���� $x$ ƽ�������������� $ans$ ��**���� $k^2 \leq x$ ����� $k$ ֵ**��������ǿ��Զ� $k$ ���ж��ֲ��ң��Ӷ��õ��𰸡�

���ֲ��ҵ��½�Ϊ $0$���Ͻ���Դ��Ե��趨Ϊ $x$���ڶ��ֲ��ҵ�ÿһ���У�����ֻ��Ҫ�Ƚ��м�Ԫ�� $mid$ ��ƽ���� $x$ �Ĵ�С��ϵ����ͨ���ȽϵĽ���������½�ķ�Χ�������������е����㶼���������㣬�������������ڵõ����յĴ� $ans$ ��Ҳ�Ͳ���Ҫ��ȥ���� $ans + 1$ �ˡ�

```cpp
class Solution {
public:
    int mySqrt(int x) {
        int l = 0, r = x, ans = -1;
        while (l <= r) {
            int mid = l + (r - l) / 2;
            if ((long long)mid * mid <= x) {
                ans = mid;
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int mySqrt(int x) {
        int l = 0, r = x, ans = -1;
        while (l <= r) {
            int mid = l + (r - l) / 2;
            if ((long) mid * mid <= x) {
                ans = mid;
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def mySqrt(self, x: int) -> int:
        l, r, ans = 0, x, -1
        while l <= r:
            mid = (l + r) // 2
            if mid * mid <= x:
                ans = mid
                l = mid + 1
            else:
                r = mid - 1
        return ans
```

```go
func mySqrt(x int) int {
    l, r := 0, x
    ans := -1
    for l <= r {
        mid := l + (r - l) / 2
        if mid * mid <= x {
            ans = mid
            l = mid + 1
        } else {
            r = mid - 1
        }
    }
    return ans
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(\log x)$����Ϊ���ֲ�����Ҫ�Ĵ�����
-   �ռ临�Ӷȣ�$O(1)$��
