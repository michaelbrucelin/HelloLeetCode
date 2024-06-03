### [换底公式](https://leetcode.cn/problems/power-of-three/solutions/84773/huan-di-gong-shi-by-yzh/)

#### 解题思路

若$n$是$3$的幂，那么$\log_3^{n}$一定是个整数，由换底公式可以的得到$\log_3^{n} = \log_{10}^{n} / \log_{10}^{3}$，只需要判断$\log_3^{n}$是不是整数即可，同理该公式可以推广到$n$的幂。

#### 代码

```cpp
class Solution {
public:
    bool isPowerOfThree(int n) {
        double res = log10(n) / log10(3);
        return res - (int)res == 0?true:false;
    }
};
```
