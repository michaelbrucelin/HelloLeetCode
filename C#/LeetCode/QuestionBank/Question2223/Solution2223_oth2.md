### [二分查找+字符串哈希+前缀和思想](https://leetcode.cn/problems/sum-of-scores-of-built-strings/solutions/1991577/er-fen-cha-zhao-gun-dong-ha-xi-qian-zhui-ym7u/)

首先要说一下，这道题的正解（z函数，也叫扩展KMP）是严重超纲的，而比赛期间国服前两页绝大多数人都用的是正解，可见LC平台的周赛活跃成员早已不仅是天坑转码人，明显有一些是不适合这个平台的。 竞赛党来这里如果像零神，灵神，TsReaper之类愿意为平台写高质量题解或做其他贡献，那当然是非常好的。如果是为了进货的，那只能说眼界不太够，周赛奖品的价值对OI/ACM大佬来说几乎可以忽略。如果是为了贬低这个平台，那还是滚得越远越好，虽然部分周赛确实该骂，但LC平台对于天坑转码人还是优秀的，即使有一些缺点也是瑕不掩瑜。

这道题相对没那么超纲的做法是二分查找+字符串哈希。考虑原串长度为$k$的后缀串，如果这个串和原串的前$m$个字符都相同，那么前$m-1$个字符也都相同，因此答案满足单调性，可以用二分猜答案的套路来解决。判断前$m$个字符是否相同可以用字符串哈希来实现，如果我们预处理所有从首字母开始的子串的哈希值，那么任何一个子串的哈希值，都可以$O(1)$时间直接拿到。从$l$到$r$（包括端点）的子串的哈希值的具体公式为$hash(s[l:r+1])=hash(s[:r+1])-hash(s[:l])\times (base^{(r-l+1)})$，这和预处理前缀和就能$O(1)$拿到任意区间和是很类似的。为了避免在二分查找的过程中花费大量时间计算$base$的各次幂，可以先预处理，在套公式计算$hash(s[l:r+1])$时直接使用。

由于单个字符的ascii值最大为$122$，哈希用的$base$应该选大于等于$127$的素数，$\bmod$ 可以用LC平台常用的值，如果不放心可以用更大的$base$，或多选几个$\bmod$ （python语言可以用超出32位整数的$\bmod$，但这也会增加运行时间，对于主站1923题很有必要，对于这个题没甚必要）

考虑到LC平台卡的是总时间，可以做如下处理：
1.把预处理base的各次幂放到class外面，这样所有case只需要预处理一次。
2.增加一个剪枝，如果长度为k的后缀串的首字母和原串首字母不同，就直接跳过。
3.如果所有字母均相同，上面一条剪枝无效，可以直接返回$n \times (n+1)//2$。

```c++
class Solution {
    const int MOD = 1000000007;

public:
    long long sumScores(string s) {
        int n = s.size();
        vector<long long> f(n + 1), P(n + 1);
        for (int i = 1; i <= n; i++) f[i] = (f[i - 1] * 171 + s[i - 1]) % MOD;
        P[0] = 1;
        for (int i = 1; i <= n; i++) P[i] = P[i - 1] * 171 % MOD;

        long long ans = 0;
        for (int i = n; i; i--) {
            int head = 0, tail = n - i + 1;
            while (head < tail) {
                int mid = (head + tail + 1) >> 1;
                long long h = (f[i + mid - 1] - f[i - 1] * P[mid] % MOD + MOD) % MOD;
                if (h == f[mid]) head = mid;
                else tail = mid - 1;
            }
            ans += head;
        }
        return ans;
    }
};
```

```python
base = 52579  # 10^18-1的素因子之一，对这题够用了
mod = 10**9+9
pw = [1]*100001
cur = 1
for j in range(1,100001): #预处理base的各次幂
    cur=cur*base%mod
    pw[j]=cur

class Solution:
    def sumScores(self, s: str) -> int:

        # if len(set(s))==1:  # 加上这个能快一倍不止，毕竟这符合LC的testcase风格
        #     return len(s)*(len(s)+1)//2

        pre = [0]*len(s)
        for j in range(len(s)): #预处理所有以首字母开头的子串的哈希值
            pre[j] = (pre[j-1]*base+ord(s[j]))%mod

        ans = len(s)  # 整个串对应的得分肯定是n，不用二分了
        for k in range(1,len(s)):
            if s[-k]!=s[0]: # 剪枝，首字母不一样得分一定是0，不浪费时间
                continue
            l = 1
            r = k
            while l<r:
                m = (l+r+1)//2 #上取整避免二分的区间剩2个数时死循环
                if (pre[len(s)-k+m-1]-pre[len(s)-k-1]*pw[m])%mod==pre[m-1]: #判断hash(s[-k:-k+m])与hash(s[:m])是否一样
                    l = m
                else:
                    r = m-1
            ans+=l
        return ans
```

时间复杂度：$O(n\log n)$，$n$为原串长度，预处理需要$O(n)$时间，二分查找n次，每次$\log n$时间，总复杂度$O(n\log n)$
空间复杂度：$O(n)$，主要门槛在于$pre$数组的空间
