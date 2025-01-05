### [在区间范围内统计奇数数目](https://leetcode.cn/problems/count-odd-numbers-in-an-interval-range/solutions/371283/zai-qu-jian-fan-wei-nei-tong-ji-qi-shu-shu-mu-by-l/)

#### 方法一：前缀和思想

**思路与算法**

如果我们暴力枚举 ${\rm [low, high]}$ 中的所有元素会超出时间限制。

我们可以使用前缀和思想来解决这个问题，定义 ${\rm pre}(x)$ 为区间 $[0, x]$ 中奇数的个数，很显然：

$${\rm pre}(x) = \lfloor \frac{x + 1}{2} \rfloor$$

故答案为 $\rm pre(high) - pre(low - 1)$。

**代码**

```cpp
class Solution {
public:
    int pre(int x) {
        return (x + 1) >> 1;
    }
    
    int countOdds(int low, int high) {
        return pre(high) - pre(low - 1);
    }
};
```

```java
class Solution {
    public int countOdds(int low, int high) {
        return pre(high) - pre(low - 1);
    }

    public int pre(int x) {
        return (x + 1) >> 1;
    }
}
```

```python
class Solution:
    def countOdds(self, low: int, high: int) -> int:
        pre = lambda x: (x + 1) >> 1
        return pre(high) - pre(low - 1)
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
