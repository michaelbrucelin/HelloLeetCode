### [镜面反射](https://leetcode.cn/problems/mirror-reflection/solutions/20108/jing-mian-fan-she-by-leetcode/)

#### 方法一：模拟

最初的光线可以看成是从 `(x, y) = (0, 0)` 发出，方向为 `(rx, ry) = (p, q)`。这样我们就可以通过模拟的方法来找到光线会先碰到哪一面镜子，以及碰到镜子的哪一个位置。随后，我们通过反射定律计算出新的光线方向。我们进行模拟，知道光线到达某一个接收器。

```Java
class Solution {
    double EPS = 1e-6;

    public int mirrorReflection(int p, int q) {
        double x = 0, y = 0;
        double rx = p, ry = q;

        // While it hasn't reached a receptor,...
        while (!( close(x, p) && (close(y, 0) || close(y, p))
                  || close(x, 0) && close (y, p) )) {
            // Want smallest t so that some x + rx, y + ry is 0 or p
            // x + rxt = 0, then t = -x/rx etc.
            double t = 1e9;
            if ((-x / rx) > EPS) t = Math.min(t, -x / rx);
            if ((-y / ry) > EPS) t = Math.min(t, -y / ry);
            if (((p-x) / rx) > EPS) t = Math.min(t, (p-x) / rx);
            if (((p-y) / ry) > EPS) t = Math.min(t, (p-y) / ry);

            x += rx * t;
            y += ry * t;

            if (close(x, p) || close(x, 0)) rx *= -1;
            if (close(y, p) || close(y, 0)) ry *= -1;
        }

        if (close(x, p) && close(y, p)) return 1;
        return close(x, p) ? 0 : 2;
    }

    public boolean close(double x, double y) {
        return Math.abs(x - y) < EPS;
    }
}
```

```Python
class Solution(object):
    def mirrorReflection(self, p, q):
        from fractions import Fraction as F

        x = y = 0
        rx, ry = p, q
        targets = [(p, 0), (p, p), (0, p)]

        while (x, y) not in targets:
            #Want smallest t so that some x + rx, y + ry is 0 or p
            #x + rxt = 0, then t = -x/rx etc.
            t = float('inf')
            for v in [F(-x,rx), F(-y,ry), F(p-x,rx), F(p-y,ry)]:
                if v > 0: t = min(t, v)

            x += rx * t
            y += ry * t

            #update rx, ry
            if x == p or x == 0: # bounced from east/west wall, so reflect on y axis
                rx *= -1
            if y == p or y == 0:
                ry *= -1

        return 1 if x==y==p else 0 if x==p else 2
```

**复杂度分析**

- 时间复杂度：$O(p)$，我们可以通过方法二证明该时间复杂度上界。
- 空间复杂度：$O(1)$。

#### 方法二：数学

我们把光线的运动拆分成水平和垂直两个方向来看。在水平和竖直方向，光线都在 `0` 到 `p` 之间往返运动，并且水平方向的运动速度是竖直方向的 `p/q` 倍。我们可以将光线的运动抽象成：

每过一个时间步，光线在水平方向从一侧跳动到另一侧（即移动 `p` 的距离），同时在竖直方向前进 `q` 的距离，如果到达了边界就折返。

由于接收器的位置在水平方向的两侧，因此只有当光线经过整数个时间步后，才有可能到达某一个接收器。而由于接收器的位置也在垂直方向的两侧，因此光线经过 `k` 个时间步后，它在竖直方向移动的总距离 `kq` 必须是 `p` 的倍数，才会碰到垂直方向的两侧。

因此，我们需要找到最小的 `k` 使得 `kq` 是 `p` 的倍数，并且根据 `k` 的奇偶性可以得知光线到达了左侧还是右侧；根据 `kq / p` 的奇偶性可以得知光线到达了上方还是下方，从而得知光线到达的接收器的编号。

显然，设 `g = gcd(p, q)` 为 `p` 和 `q` 的最大公约数，那么 `s = pq / gcd(p, q)` 是最小的同时整除 `p` 和 `q` 的数，即 `p` 和 `q` 的最小公倍数。因此 `k` 的值为 `s / q = p / gcd(p, q)`。

```Java
class Solution {

    public int mirrorReflection(int p, int q) {
        int g = gcd(p, q);
        p /= g; p %= 2;
        q /= g; q %= 2;

        if (p == 1 && q == 1) return 1;
        return p == 1 ? 0 : 2;
    }

    public int gcd(int a, int b) {
        if (a == 0) return b;
        return gcd(b % a, a);
    }
}
```

```Python
class Solution(object):
    def mirrorReflection(self, p, q):
        from fractions import gcd
        g = gcd(p, q)
        p = (p / g) % 2
        q = (q / g) % 2

        return 1 if p and q else 0 if p else 2
```

**复杂度分析**

- 时间复杂度：$O(\log P)$，为求出最大公约数的时间复杂度。
- 空间复杂度：$O(1)$。
