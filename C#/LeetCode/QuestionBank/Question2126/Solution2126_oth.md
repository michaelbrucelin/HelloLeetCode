### [一种线性做法](https://leetcode.cn/problems/destroying-asteroids/solutions/1187861/yi-chong-xian-xing-zuo-fa-by-heltion-i6y4/?envType=problem-list-v2&envId=ySsxoJfz)

如果使用基于比较的排序，那么复杂度是O(nlogn)的。
但是排序不是必须的，考虑将所有值按$[1,2),[2,4),\dots,[2^i,2^{i+1}],\dots$分组，按顺序考虑所有非空的组，如果当前$mass$小于组内最小值,那么答案是$false$；如果当前$mass$大于等于组内最小值，那么加上最小值之后必然大于组内所有值，所以可以直接加上组内所有值。

参考代码:

```cpp
class Solution {
public:
    bool asteroidsDestroyed(int mass, vector<int>& asteroids) {
        vector<int> min(17, -1);
        vector<long long> sum(17);
        for (int i = 0; i < asteroids.size(); i += 1) {
            int h = 31 - __builtin_clz(asteroids[i]);
            if (min[h] == -1 or asteroids[i] < min[h]) min[h] = asteroids[i];
            sum[h] += asteroids[i];
        }
        long long cur = mass;
        for (int i = 0; i < 17; i += 1) {
            if (cur < min[i]) return false;
            cur += sum[i];
        }
        return true;
    }
};
```
