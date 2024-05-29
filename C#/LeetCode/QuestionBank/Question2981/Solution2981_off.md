### [找出出现至少三次的最长特殊子字符串 I](https://leetcode.cn/problems/find-longest-special-substring-that-occurs-thrice-i/solutions/2787295/zhao-chu-chu-xian-zhi-shao-san-ci-de-zui-a109/)

#### 方法一：一次遍历

**思路**

因字符串仅含有小写字母，所以可以对每种字母单独处理。对于每一种字母，统计出每部分连续子串的长度，并储存在数组 $\textit{chs}$ 中。因题目要求出现至少三次，因此只要维护前三大的长度即可。每次往 $\textit{chs}$ 中添加元素时，可采用冒泡的方法使其有序。如果长度超过 $3$，则将末尾元素 $\textit{pop}$ 掉。

更新答案时，主要有三种：

- 最长的 $\textit{chs}[0]$ 可贡献出 $3$ 个长为 $\textit{chs}[0]-2$ 的子串，并且需要满足 $\textit{chs}[0] > 2$。
- 当 $\textit{chs}[0]$ 与 $\textit{chs}[1]$ 相等时，可贡献出 $4$ 个长为 $\textit{chs}[0]-1$ 的子串。不等时可由 $\textit{chs}[0]$ 贡献出 $2$ 个长为 $\textit{chs}[1]$ 的子串，加上 $\textit{chs}[1]$ 本身一共 $3$ 个，并且需要满足 $\textit{chs}[0] > 1$。
- 可由 $\textit{chs}[0]$ 与 $\textit{chs}[1]$ 加上 $\textit{chs}[2]$ 本身贡献 $3$ 个长为 $\textit{chs}[2]$ 的子串。

没有更新答案时，则输出 $-1$。

**代码**

```C++
class Solution {
public:
    int maximumLength(string s) {
        int ans = -1;
        int len = s.size();

        vector<int> chs[26];
        int cnt = 0;
        for (int i = 0; i < len; i++) {
            cnt++;
            if (i + 1 == len || s[i] != s[i + 1]) {
                int ch = s[i] - 'a';
                chs[ch].push_back(cnt);
                cnt = 0;

                for (int j = chs[ch].size() - 1; j > 0; j--) {
                    if (chs[ch][j] > chs[ch][j - 1]) {
                        swap(chs[ch][j], chs[ch][j - 1]);
                    } else {
                        break;
                    }
                }

                if (chs[ch].size() > 3) {
                    chs[ch].pop_back();
                }
            }
        }

        for (int i = 0; i < 26; i++) {
            if (chs[i].size() > 0 && chs[i][0] > 2) {
                ans = max(ans, chs[i][0] - 2);
            }
            if (chs[i].size() > 1 && chs[i][0] > 1) {
                ans = max(ans, min(chs[i][0] - 1, chs[i][1]));
            }
            if (chs[i].size() > 2) {
                ans = max(ans, chs[i][2]);
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int maximumLength(String s) {
        int ans = -1;
        int len = s.length();

        List<Integer>[] chs = new List[26];
        for (int i = 0; i < 26; i++) {
            chs[i] = new ArrayList<Integer>();
        }
        int cnt = 0;
        for (int i = 0; i < len; i++) {
            cnt++;
            if (i + 1 == len || s.charAt(i) != s.charAt(i + 1)) {
                int ch = s.charAt(i) - 'a';
                chs[ch].add(cnt);
                cnt = 0;

                for (int j = chs[ch].size() - 1; j > 0; j--) {
                    if (chs[ch].get(j) > chs[ch].get(j - 1)) {
                        Collections.swap(chs[ch], j, j - 1);
                    } else {
                        break;
                    }
                }

                if (chs[ch].size() > 3) {
                    chs[ch].remove(chs[ch].size() - 1);
                }
            }
        }

        for (int i = 0; i < 26; i++) {
            if (chs[i].size() > 0 && chs[i].get(0) > 2) {
                ans = Math.max(ans, chs[i].get(0) - 2);
            }
            if (chs[i].size() > 1 && chs[i].get(0) > 1) {
                ans = Math.max(ans, Math.min(chs[i].get(0) - 1, chs[i].get(1)));
            }
            if (chs[i].size() > 2) {
                ans = Math.max(ans, chs[i].get(2));
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLength(string s) {
        int ans = -1;
        int len = s.Length;

        IList<int>[] chs = new IList<int>[26];
        for (int i = 0; i < 26; i++) {
            chs[i] = new List<int>();
        }
        int cnt = 0;
        for (int i = 0; i < len; i++) {
            cnt++;
            if (i + 1 == len || s[i] != s[i + 1]) {
                int ch = s[i] - 'a';
                chs[ch].Add(cnt);
                cnt = 0;

                for (int j = chs[ch].Count - 1; j > 0; j--) {
                    if (chs[ch][j] > chs[ch][j - 1]) {
                        int temp = chs[ch][j];
                        chs[ch][j] = chs[ch][j - 1];
                        chs[ch][j - 1] = temp;
                    } else {
                        break;
                    }
                }

                if (chs[ch].Count > 3) {
                    chs[ch].RemoveAt(chs[ch].Count - 1);
                }
            }
        }

        for (int i = 0; i < 26; i++) {
            if (chs[i].Count > 0 && chs[i][0] > 2) {
                ans = Math.Max(ans, chs[i][0] - 2);
            }
            if (chs[i].Count > 1 && chs[i][0] > 1) {
                ans = Math.Max(ans, Math.Min(chs[i][0] - 1, chs[i][1]));
            }
            if (chs[i].Count > 2) {
                ans = Math.Max(ans, chs[i][2]);
            }
        }

        return ans;
    }
}
```

```Go
func maximumLength(s string) int {
    ans := -1
    length := len(s)

    chs := make([][]int, 26)
    cnt := 0
    for i := 0; i < length; i++ {
        cnt++
        if i + 1 == length || s[i] != s[i+1] {
            ch := int(s[i] - 'a')
            chs[ch] = append(chs[ch], cnt)
            cnt = 0

            for j := len(chs[ch]) - 1; j > 0; j-- {
                if chs[ch][j] > chs[ch][j - 1] {
                    tmp := chs[ch][j - 1]
                    chs[ch][j - 1] = chs[ch][j]
                    chs[ch][j] = tmp
                } else {
                    break
                }
            }

            if len(chs[ch]) > 3 {
                chs[ch] = chs[ch][:len(chs[ch]) - 1]
            }
        }
    }

    for i := 0; i < 26; i++ {
        if len(chs[i]) > 0 && chs[i][0] > 2 {
            ans = max(ans, chs[i][0] - 2)
        }
        if len(chs[i]) > 1 && chs[i][0] > 1 {
            ans = max(ans, min(chs[i][0] - 1, chs[i][1]))
        }
        if len(chs[i]) > 2 {
            ans = max(ans, chs[i][2])
        }
    }

    return ans
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
```

```Python
class Solution:
    def maximumLength(self, s: str) -> int:
        ans = -1

        chs = [[] for _ in range(26)]
        cnt = 0
        for i in range(len(s)):
            cnt += 1
            if i + 1 == len(s) or s[i] != s[i + 1]:
                ch = ord(s[i]) - ord('a')
                chs[ch].append(cnt)
                cnt = 0
                for j in range(len(chs[ch]) - 1, 0, -1):
                    if chs[ch][j] > chs[ch][j - 1]:
                        chs[ch][j], chs[ch][j - 1] = chs[ch][j - 1], chs[ch][j]
                    else:
                        break
                if len(chs[ch]) > 3:
                    chs[ch].pop()

        for i in range(26):
            if len(chs[i]) > 0 and chs[i][0] > 2:
                ans = max(ans, chs[i][0] - 2)
            if len(chs[i]) > 1 and chs[i][0] > 1:
                ans = max(ans, min(chs[i][0] - 1, chs[i][1]))
            if len(chs[i]) > 2:
                ans = max(ans, chs[i][2])

        return ans
```

```C
int maximumLength(char* s) {
    int ans = -1;
    int len = strlen(s);
    int chs[26][4];
    int chsSize[26];
    int cnt = 0;
    memset(chs, 0, sizeof(chs));
    memset(chsSize, 0, sizeof(chsSize));

    for (int i = 0; i < len; i++) {
        cnt++;
        if (i + 1 == len || s[i] != s[i + 1]) {
            int ch = s[i] - 'a';
            chs[ch][chsSize[ch]] = cnt;
            chsSize[ch]++;
            cnt = 0;
            for (int j = chsSize[ch] - 1; j > 0; j--) {
                if (chs[ch][j] > chs[ch][j - 1]) {
                    int temp = chs[ch][j];
                    chs[ch][j] = chs[ch][j - 1];
                    chs[ch][j - 1] = temp;
                } else {
                    break;
                }
            }
            if (chsSize[ch] > 3) {
                chsSize[ch]--;
            }
        }
    }
    for (int i = 0; i < 26; i++) {
        if (chsSize[i] > 0 && chs[i][0] > 2) {
            ans = fmax(ans, chs[i][0] - 2);
        }
        if (chsSize[i] > 1 && chs[i][0] > 1) {
            ans = fmax(ans, fmin(chs[i][0] - 1, chs[i][1]));
        }
        if (chsSize[i] > 2) {
            ans = fmax(ans, chs[i][2]);
        }
    }
    return ans;
}
```

```JavaScript
var maximumLength = function(s) {
    let ans = -1;
    const len = s.length;
    const chs = Array.from({ length: 26 }, () => []);
    let cnt = 0;

    for (let i = 0; i < len; i++) {
        cnt++;
        if (i + 1 === len || s[i] !== s[i + 1]) {
            const ch = s[i].charCodeAt(0) - 'a'.charCodeAt(0);
            chs[ch].push(cnt);
            cnt = 0;
            for (let j = chs[ch].length - 1; j > 0; j--) {
                if (chs[ch][j] > chs[ch][j - 1]) {
                    [chs[ch][j], chs[ch][j - 1]] = [chs[ch][j - 1], chs[ch][j]];
                } else {
                    break;
                }
            }
            if (chs[ch].length > 3) {
                chs[ch].pop();
            }
        }
    }

    for (let i = 0; i < 26; i++) {
        if (chs[i].length > 0 && chs[i][0] > 2) {
            ans = Math.max(ans, chs[i][0] - 2);
        }
        if (chs[i].length > 1 && chs[i][0] > 1) {
            ans = Math.max(ans, Math.min(chs[i][0] - 1, chs[i][1]));
        }
        if (chs[i].length > 2) {
            ans = Math.max(ans, chs[i][2]);
        }
    }

    return ans;
};
```

```TypeScript
function maximumLength(s: string): number {
    let ans = -1;
    const len = s.length;
    const chs: number[][] = Array.from({ length: 26 }, () => []);
    let cnt = 0;

    for (let i = 0; i < len; i++) {
        cnt++;
        if (i + 1 === len || s[i] !== s[i + 1]) {
            const ch = s[i].charCodeAt(0) - 'a'.charCodeAt(0);
            chs[ch].push(cnt);
            cnt = 0;
            for (let j = chs[ch].length - 1; j > 0; j--) {
                if (chs[ch][j] > chs[ch][j - 1]) {
                    [chs[ch][j], chs[ch][j - 1]] = [chs[ch][j - 1], chs[ch][j]];
                } else {
                    break;
                }
            }
            if (chs[ch].length > 3) {
                chs[ch].pop();
            }
        }
    }

    for (let i = 0; i < 26; i++) {
        if (chs[i].length > 0 && chs[i][0] > 2) {
            ans = Math.max(ans, chs[i][0] - 2);
        }
        if (chs[i].length > 1 && chs[i][0] > 1) {
            ans = Math.max(ans, Math.min(chs[i][0] - 1, chs[i][1]));
        }
        if (chs[i].length > 2) {
            ans = Math.max(ans, chs[i][2]);
        }
    }

    return ans;
};
```

```Rust
impl Solution {
    pub fn maximum_length(s: String) -> i32 {
        let mut ans = -1;
        let len = s.len();
        let mut chs: Vec<Vec<i32>> = vec![vec![]; 26];
        let mut cnt = 0;
        let s_bytes = s.as_bytes();

        for i in 0..len {
            cnt += 1;
            if i + 1 == len || s_bytes[i] != s_bytes[i + 1] {
                let ch = (s_bytes[i] - b'a') as usize;
                chs[ch].push(cnt);
                cnt = 0;
                for j in (1..chs[ch].len()).rev() {
                    if chs[ch][j] > chs[ch][j - 1] {
                        chs[ch].swap(j, j - 1);
                    } else {
                        break;
                    }
                }
                if chs[ch].len() > 3 {
                    chs[ch].pop();
                }
            }
        }

        for i in 0..26 {
            if chs[i].len() > 0 && chs[i][0] > 2 {
                ans = ans.max(chs[i][0] - 2);
            }
            if chs[i].len() > 1 && chs[i][0] > 1 {
                ans = ans.max((chs[i][0] - 1).min(chs[i][1]));
            }
            if chs[i].len() > 2 {
                ans = ans.max(chs[i][2]);
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组的长度。
- 空间复杂度：$O(C)$，其中 $C = 26$ 为小写字母个数。每种字母维护前三大的长度。
