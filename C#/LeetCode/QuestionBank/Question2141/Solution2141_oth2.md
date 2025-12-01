### [二分答案的check函数的思考方式](https://leetcode.cn/problems/maximum-running-time-of-n-computers/solutions/1214304/er-fen-da-an-de-checkhan-shu-de-si-kao-f-g8no/)

本题来自ABC 227D。这题很容易想到二分答案，但是check函数稍微有点难想。
借用了张图来表达一下。[原日文博客](https://leetcode.cn/link/?target=https%3A%2F%2Fqiita.com%2Frecuraki%2Fitems%2F02e6127170eaa9ed5111) 
设本题电脑同时运行时间为P，这也是我们不断二分得到的结果。
设一共有K台电脑，我们的目的是在P的时间内不断运转他们。
因此，我们的目的其实是看电池的状态能不能填满P\*K的矩形。

![](./assets/img/Solution2141_oth2.png)
上部分代表了一种电池的合法分布情况。
很明显，当Batteries0(黄色)的数量超过了P，我们其实只需要P即可，剩下的都只能抛弃。
当Batteries1(橘色)的数量小于P，我们需要把当前电池全部用完。同时提前借用别的电池来填充该列。

然而，下面也有NG的情况。我们把橘色电池容量-1，红色的+1，再来看看我们构造的矩形。因为一行不能存在2个同样的颜色（即不能存在一个电池给2个电脑续航的情况)，所以红色的电池会浪费掉一个(对应了代码里的min(p, 红色电池容量))，最终导致矩形的构造失败。
总结一下可以用这个心态来构造矩形：小于P的时候，贪心地利用多个电池，但是同时不能在一行里有相同的颜色。

```cpp
auto check = [&](i64 mid) {
            i64 sum = 0;
            for(int x : batteries) sum += min(mid, (i64)x);
            return sum >= n * mid;
        };
```

全部代码:

```cpp
typedef long long i64;
class Solution {
public:
    long long maxRunTime(int n, vector<int>& batteries) {
        auto check = [&](i64 mid) {
            i64 sum = 0;
            for(int x : batteries) sum += min(mid, (i64)x);
            return sum >= n * mid;
        };
        i64 l = 0, r = 1e16/n;
        while (l < r) {
            i64 mid = l + r + 1>> 1;
            if (check(mid)) l = mid;
            else r = mid - 1;
        }
        return l;
    }
};
```
