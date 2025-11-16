### [统计 1 显著的字符串的数量](https://leetcode.cn/problems/count-the-number-of-substrings-with-dominant-ones/solutions/3825138/tong-ji-1-xian-zhu-de-zi-fu-chuan-de-shu-6cnn/)

#### 方法一：枚举

**思路与算法**

直接枚举所有子串并判断是否是 $1$ 显著的字符串将消耗大量的时间，考虑到 $1$ 显著的字符串的特性，$1$ 的个数要大于等于 $0$ 的个数的平方，因此我们可以枚举子串中 $0$ 出现的次数，枚举的范围将缩小至 $\sqrt{n}$，其中 $n$ 是字符串的长度。

考虑枚举子串的右边界 $i$，然后枚举子串中 $0$ 出现的次数 $cnt_0$，假设前面第 $cnt_0$ 个 $0$ 出现的位置是 $j$，计算第 $cnt_0$ 至第 $cnt_0+1$ 个 $0$ 之间有多少个合法的左边界。不难想到，$cnt_0$ 的上限是 $n$，这样处理的时间复杂度总共为 $O(n\sqrt{n})$。

为了方便描述，我们定义 $pre[j]$ 为位置 $j$ 之前最近的一个 $0$ 出现的位置，那么以 $i$ 为右端点并且包含 $cnt_0$ 个 $0$ 的子串最多可以包含 $cnt_1=i-pre[j]-cnt_0$ 个 $1$，分情况做以下考虑：

- 如果 $cnt_1$ 小于 $cnt_0^2$，那么表示不存在满足当前条件的 $1$ 显著字符串。
- 否则，存在满足当前条件的 $1$ 显著字符串。不过，合法的左边界数量受到 $j-pre[j]$ 和 $cnt_1-cnt_0^2+1$ 共同限制。

我们对每个 $i$ 做如上处理，累加所有合法的左边界数量，即可得到答案。为了方便处理字符串最左侧的连续的 $1$，我们可以给原字符串左端加一个哨兵 $0$。

**代码**

```C++
class Solution {
public:
    int numberOfSubstrings(string s) {
        int n = s.size();
        vector<int> pre(n + 1);
        pre[0] = -1;
        for (int i = 0; i < n; i++) {
            if (i == 0 || (i > 0 && s[i - 1] == '0')) {
                pre[i + 1] = i;
            } else {
                pre[i + 1] = pre[i];
            }
        }
        int res = 0;
        for (int i = 1; i <= n; i++) {
            int cnt0 = s[i - 1] == '0';
            int j = i;
            while (j > 0 && cnt0 * cnt0 <= n) {
                int cnt1 = (i - pre[j]) - cnt0;
                if (cnt0 * cnt0 <= cnt1) {
                    res += min(j - pre[j], cnt1 - cnt0 * cnt0 + 1);
                }
                j = pre[j];
                cnt0++;
            }
        }
        return res;
    }
};
```

```Rust
impl Solution {
    pub fn number_of_substrings(s: String) -> i32 {
        let chars: Vec<char> = s.chars().collect();
        let n = chars.len();
        let mut pre = vec![-1; n + 1];
        for i in 0..n {
            if i == 0 || chars[i - 1] == '0' {
                pre[i + 1] = i as i32;
            } else {
                pre[i + 1] = pre[i];
            }
        }

        let mut res = 0i32;
        for i in 1..=n {
            let mut cnt0 = if chars[i - 1] == '0' { 1 } else { 0 };
            let mut j = i as i32;
            while j > 0 && (cnt0 * cnt0) as usize <= n {
                let cnt1 = (i as i32 - pre[j as usize]) - cnt0;
                if cnt0 * cnt0 <= cnt1 {
                    res += std::cmp::min(j - pre[j as usize], cnt1 - cnt0 * cnt0 + 1);
                }
                j = pre[j as usize];
                cnt0 += 1;
            }
        }
        res
    }
}
```

```Python
class Solution:
    def numberOfSubstrings(self, s: str) -> int:
        n = len(s)
        pre = [-1] * (n + 1)
        for i in range(n):
            if i == 0 or s[i - 1] == '0':
                pre[i + 1] = i
            else:
                pre[i + 1] = pre[i]

        res = 0
        for i in range(1, n + 1):
            cnt0 = 1 if s[i - 1] == '0' else 0
            j = i
            while j > 0 and cnt0 * cnt0 <= n:
                cnt1 = (i - pre[j]) - cnt0
                if cnt0 * cnt0 <= cnt1:
                    res += min(j - pre[j], cnt1 - cnt0 * cnt0 + 1)
                j = pre[j]
                cnt0 += 1
        return res
```

```Java
class Solution {
    public int numberOfSubstrings(String s) {
        int n = s.length();
        int[] pre = new int[n + 1];
        pre[0] = -1;
        for (int i = 0; i < n; i++) {
            if (i == 0 || (i > 0 && s.charAt(i - 1) == '0')) {
                pre[i + 1] = i;
            } else {
                pre[i + 1] = pre[i];
            }
        }
        int res = 0;
        for (int i = 1; i <= n; i++) {
            int cnt0 = s.charAt(i - 1) == '0' ? 1 : 0;
            int j = i;
            while (j > 0 && cnt0 * cnt0 <= n) {
                int cnt1 = (i - pre[j]) - cnt0;
                if (cnt0 * cnt0 <= cnt1) {
                    res += Math.min(j - pre[j], cnt1 - cnt0 * cnt0 + 1);
                }
                j = pre[j];
                cnt0++;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfSubstrings(string s) {
        int n = s.Length;
        int[] pre = new int[n + 1];
        pre[0] = -1;
        for (int i = 0; i < n; i++) {
            if (i == 0 || (i > 0 && s[i - 1] == '0')) {
                pre[i + 1] = i;
            } else {
                pre[i + 1] = pre[i];
            }
        }
        int res = 0;
        for (int i = 1; i <= n; i++) {
            int cnt0 = s[i - 1] == '0' ? 1 : 0;
            int j = i;
            while (j > 0 && cnt0 * cnt0 <= n) {
                int cnt1 = (i - pre[j]) - cnt0;
                if (cnt0 * cnt0 <= cnt1) {
                    res += Math.Min(j - pre[j], cnt1 - cnt0 * cnt0 + 1);
                }
                j = pre[j];
                cnt0++;
            }
        }
        return res;
    }
}
```

```Go
func numberOfSubstrings(s string) int {
    n := len(s)
    pre := make([]int, n+1)
    pre[0] = -1
    for i := 0; i < n; i++ {
        if i == 0 || (i > 0 && s[i - 1] == '0') {
            pre[i + 1] = i
        } else {
            pre[i + 1] = pre[i]
        }
    }
    res := 0
    for i := 1; i <= n; i++ {
        cnt0 := 0
        if s[i - 1] == '0' {
            cnt0 = 1
        }
        j := i
        for j > 0 && cnt0 * cnt0 <= n {
            cnt1 := (i - pre[j]) - cnt0
            if cnt0 * cnt0 <= cnt1 {
                add := j - pre[j]
                if cnt1 - cnt0 * cnt0 + 1 < add {
                    add = cnt1 - cnt0 * cnt0 + 1
                }
                res += add
            }
            j = pre[j]
            cnt0++
        }
    }
    return res
}
```

```C
int numberOfSubstrings(char* s) {
    int n = strlen(s);
    int* pre = (int*)malloc((n + 1) * sizeof(int));
    pre[0] = -1;
    for (int i = 0; i < n; i++) {
        if (i == 0 || (i > 0 && s[i - 1] == '0')) {
            pre[i + 1] = i;
        } else {
            pre[i + 1] = pre[i];
        }
    }
    int res = 0;
    for (int i = 1; i <= n; i++) {
        int cnt0 = s[i - 1] == '0' ? 1 : 0;
        int j = i;
        while (j > 0 && cnt0 * cnt0 <= n) {
            int cnt1 = (i - pre[j]) - cnt0;
            if (cnt0 * cnt0 <= cnt1) {
                int add = j - pre[j];
                if (cnt1 - cnt0 * cnt0 + 1 < add) {
                    add = cnt1 - cnt0 * cnt0 + 1;
                }
                res += add;
            }
            j = pre[j];
            cnt0++;
        }
    }
    free(pre);
    return res;
}
```

```JavaScript
var numberOfSubstrings = function(s) {
    const n = s.length;
    const pre = new Array(n + 1);
    pre[0] = -1;
    for (let i = 0; i < n; i++) {
        if (i === 0 || (i > 0 && s[i - 1] === '0')) {
            pre[i + 1] = i;
        } else {
            pre[i + 1] = pre[i];
        }
    }
    let res = 0;
    for (let i = 1; i <= n; i++) {
        let cnt0 = s[i - 1] === '0' ? 1 : 0;
        let j = i;
        while (j > 0 && cnt0 * cnt0 <= n) {
            const cnt1 = (i - pre[j]) - cnt0;
            if (cnt0 * cnt0 <= cnt1) {
                res += Math.min(j - pre[j], cnt1 - cnt0 * cnt0 + 1);
            }
            j = pre[j];
            cnt0++;
        }
    }
    return res;
};
```

```TypeScript
function numberOfSubstrings(s: string): number {
    const n = s.length;
    const pre: number[] = new Array(n + 1);
    pre[0] = -1;
    for (let i = 0; i < n; i++) {
        if (i === 0 || (i > 0 && s[i - 1] === '0')) {
            pre[i + 1] = i;
        } else {
            pre[i + 1] = pre[i];
        }
    }
    let res = 0;
    for (let i = 1; i <= n; i++) {
        let cnt0 = s[i - 1] === '0' ? 1 : 0;
        let j = i;
        while (j > 0 && cnt0 * cnt0 <= n) {
            const cnt1 = (i - pre[j]) - cnt0;
            if (cnt0 * cnt0 <= cnt1) {
                res += Math.min(j - pre[j], cnt1 - cnt0 * cnt0 + 1);
            }
            j = pre[j];
            cnt0++;
        }
    }
    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(n\sqrt{n})$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(n)$。我们使用了数组 $pre$ 来标记每个位置前面最近的一个 $0$ 出现的位置，因此空间复杂度是 $O(n)$。
