#### [���׹�ʽ](https://leetcode.cn/problems/power-of-three/solutions/84773/huan-di-gong-shi-by-yzh/)

##### ����˼·

��$n$��$3$���ݣ���ô$\log_3^{n}$һ���Ǹ��������ɻ��׹�ʽ���Եĵõ�$\log_3^{n} = \log_{10}^{n} / \log_{10}^{3}$��ֻ��Ҫ�ж�$\log_3^{n}$�ǲ����������ɣ�ͬ��ù�ʽ�����ƹ㵽$n$���ݡ�

##### ����

```cpp
class Solution {
public:
    bool isPowerOfThree(int n) {
        double res = log10(n) / log10(3);
        return res - (int)res == 0?true:false;
    }
};
```
