### [O(n) 一次遍历（Python/Java/C++/Go）](https://leetcode.cn/problems/time-needed-to-rearrange-a-binary-string/solutions/1763650/by-endlesscheng-pq2x/?envType=problem-list-v2&envId=ySsxoJfz)

把 $s$ 看成是一条道路，$1$ 看成车，替换操作看成是车往左移动（如果左侧为 $0$ 的话）。

定义 $f[i]$ 表示 $s$ 的前 $i$ 个字符中的车完成移动所需的秒数。

如果 $s[i]=0$，此处无车，则 $f[i]=f[i-1]$。

如果 $s[i]=1$，记前 $i$ 个字符中 $0$ 的个数为 $pre_0[i]$，则 $f[i]$ 至少为 $pre_0[i]$。记 $s[i]$ 为 $B$，它左边那辆车为 $A$，如果 $B$ 在移动的过程中被 $A$ 堵住（两辆车紧贴），那么当 $A$ 到达 $A$ 的目标位置时，$B$ 不会也同时到达 $B$ 的目标位置（题目不允许两辆紧贴的车同时向左开），也不会与 $A$ 相距超过 $1$（B 左边有空位时，下一秒就会立刻向左移动），因此 $B$ 恰好会在 $A$ 到达目标位置的下一秒到达 $B$ 的目标位置，即 $f[i]=f[i-1]+1$。

这两者取最大值，即

$$f[i]=max(f[i-1]+1,pre_0[i])$$

答案为 $f[n-1]$。

代码实现时 $f$ 和 $pre_0$ 都可以压缩成一个变量。

```Python
class Solution:
    def secondsToRemoveOccurrences(self, s: str) -> int:
        f = pre0 = 0
        for c in s:
            if c == '0': pre0 += 1
            elif pre0: f = max(f + 1, pre0)  # 前面有 0 的时候才会移动
        return f
```

```Java
class Solution {
    public int secondsToRemoveOccurrences(String s) {
        int f = 0, pre0 = 0;
        for (var i = 0; i < s.length(); i++)
            if (s.charAt(i) == '0') ++pre0;
            else if (pre0 > 0) f = Math.max(f + 1, pre0); // 前面有 0 的时候才会移动
        return f;
    }
}
```

```C++
class Solution {
public:
    int secondsToRemoveOccurrences(string &s) {
        int f = 0, pre0 = 0;
        for (char c : s)
            if (c == '0') ++pre0;
            else if (pre0) f = max(f + 1, pre0); // 前面有 0 的时候才会移动
        return f;
    }
};
```

```Go
func secondsToRemoveOccurrences(s string) (f int) {
    pre0 := 0
    for _, c := range s {
        if c == '0' {
            pre0++
        } else if pre0 > 0 { // 前面有 0 的时候才会移动
            f = max(f+1, pre0)
        }
    }
    return
}

func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $s$ 的长度。
- 空间复杂度：$O(1)$，仅用到若干变量。
