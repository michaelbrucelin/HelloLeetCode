#### 数学

##### 描述

1. $n$可以分解为$2$的幂的和的形式，就是二进制的形式
    - $n = 2^{n_1} + 2^{n_2} + ... + 2^{n_k}$
2. 调整上面的表达式，调整为：
    - 如果$n_k$是偶数，这一项的系数是$1$
    - 如果$n_k$是奇数，这一项的系数是$-1$
3. 调整方法
    - 从低幂项向高幂项逐项处理
    - 如果$n_k$是偶数，这一项不变
    - 如果$n_k$是奇数，这一项拆成两项：$2^{n_k} = 2^{n_k + 1} - 2^{n_k}$
        - 注意，额外产生的$2^{n_k + 1}$可能会改变原有表达式的项

##### 示例

例如$n = 28$

1. $n = 28 = 2^4 + 2^3 + 2^2$
2. 调整$2^2$，幂$2$是偶数，这一项不变，表达式不变
3. 调整$2^3$，幂$3$是奇数，调整这一项为：$2^3 = 2^4 - 2^3$
    - 原表达式中含有$2^4$，这时又新增加了$2^4$，所以原表达式变为：$2^4 + 2^4 - 2^3 + 2^2 = 2^5 - 2^3 + 2^2$
4. 调整$2^5$，幂$5$是奇数，调整这一项为：$2^5 = 2^6 - 2^5$
    - 表达式变为：$2^6 - 2^5 - 2^3 + 2^2$
5. 调整$2^6$，幂$6$是偶数，这一项不变，表达式不变
6. 所有项处理完成，最终结果为：$1101100$

---

#### [C++ 正负K进制转换通用题解](https://leetcode.cn/problems/convert-to-base-2/solutions/36486/c-zheng-fu-kjin-zhi-zhuan-huan-tong-yong-ti-jie-by/)

通过数学推导可以得到`+K/-K`进制的通用转化法。

```cpp
class Solution {
public:
    // 无论K是正数还是负数都支持（只支持-10～10进制，因为更高进制需要引入字母）
    vector<int> baseK(int N, int K) {
        if (N == 0) return {0};
        vector<int> res;
        while (N != 0) {
            int r = ((N % K) + abs(K)) % abs(K); // 此处为关键
            res.push_back(r);
            N -= r;
            N /= K;
        }
        reverse(res.begin(), res.end());
        return res;
    }
    string baseNeg2(int N) {
        vector<int> nums = baseK(N, -2);
        string res;
        for (auto x : nums) res += to_string(x);
        return res;
    }
};
```
