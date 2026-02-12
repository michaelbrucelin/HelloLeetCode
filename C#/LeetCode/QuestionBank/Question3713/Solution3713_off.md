### [最长的平衡子串 I](https://leetcode.cn/problems/longest-balanced-substring-i/solutions/3895131/zui-chang-de-ping-heng-zi-chuan-i-by-lee-a90a/)

#### 方法一：枚举

**思路与算法**

我们可以枚举每个子串，然后找出长度最长的平衡子串。

具体来说：

- 我们首先枚举子串的左端点 $i$，然后再枚举子串的右端点 $j(i\le j<n)$。
- 在枚举右端点的过程中，使用哈希表 $cnt$ 统计每种字符的出现次数。
- 遍历 $cnt$，判断当前子串 $[i,j]$ 是否由个数相同的不同字符组成。若是，则更新答案。

**代码**

```C++
class Solution {
public:
    int longestBalanced(string s) {
        int n = s.size();
        int res = 0;
        vector<int> cnt(26);
        for (int i = 0; i < n; i++) {
            fill(cnt.begin(), cnt.end(), 0);
            for (int j = i; j < n; j++) {
                bool flag = true;
                int c = s[j] - 'a';
                cnt[c]++;
                for (auto x : cnt) {
                    if (x > 0 && x != cnt[c]) {
                        flag = false;
                        break;
                    }
                }
                if (flag) {
                    res = max(res, j - i + 1);
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def longestBalanced(self, s: str) -> int:
        n = len(s)
        res = 0
        for i in range(n):
            cnt = defaultdict(int)
            for j in range(i, n):
                cnt[s[j]] += 1
                if len(set(cnt.values())) == 1:
                    res = max(res, j - i + 1)
        return res
```

```Rust
impl Solution {
    pub fn longest_balanced(s: String) -> i32 {
        let n = s.len();
        let mut res = 0;
        let bytes = s.as_bytes();

        for i in 0..n {
            let mut cnt = [0; 26];
            for j in i..n {
                let c = (bytes[j] - b'a') as usize;
                cnt[c] += 1;

                let mut flag = true;
                for k in 0..26 {
                    if cnt[k] > 0 && cnt[k] != cnt[c] {
                        flag = false;
                        break;
                    }
                }

                if flag {
                    res = res.max((j - i + 1) as i32);
                }
            }
        }

        res
    }
}
```

```Java
class Solution {
    public int longestBalanced(String s) {
        int n = s.length();
        int res = 0;
        int[] cnt = new int[26];

        for (int i = 0; i < n; i++) {
            Arrays.fill(cnt, 0);
            for (int j = i; j < n; j++) {
                boolean flag = true;
                int c = s.charAt(j) - 'a';
                cnt[c]++;

                for (int x : cnt) {
                    if (x > 0 && x != cnt[c]) {
                        flag = false;
                        break;
                    }
                }

                if (flag) {
                    res = Math.max(res, j - i + 1);
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int LongestBalanced(string s) {
        int n = s.Length;
        int res = 0;
        int[] cnt = new int[26];

        for (int i = 0; i < n; i++) {
            Array.Fill(cnt, 0);
            for (int j = i; j < n; j++) {
                bool flag = true;
                int c = s[j] - 'a';
                cnt[c]++;

                foreach (int x in cnt) {
                    if (x > 0 && x != cnt[c]) {
                        flag = false;
                        break;
                    }
                }

                if (flag) {
                    res = Math.Max(res, j - i + 1);
                }
            }
        }
        return res;
    }
}
```

```Go
func longestBalanced(s string) int {
    n := len(s)
    res := 0

    for i := 0; i < n; i++ {
        cnt := make([]int, 26)

        for j := i; j < n; j++ {
            c := s[j] - 'a'
            cnt[c]++
            flag := true

            for _, x := range cnt {
                if x > 0 && x != cnt[c] {
                    flag = false
                    break
                }
            }

            if flag && (j-i+1) > res {
                res = j - i + 1
            }
        }
    }
    return res
}
```

```C
int longestBalanced(char* s) {
    int n = strlen(s);
    int res = 0;
    int cnt[26];

    for (int i = 0; i < n; i++) {
        memset(cnt, 0, sizeof(cnt));
        for (int j = i; j < n; j++) {
            bool flag = true;
            int c = s[j] - 'a';
            cnt[c]++;

            for (int k = 0; k < 26; k++) {
                if (cnt[k] > 0 && cnt[k] != cnt[c]) {
                    flag = false;
                    break;
                }
            }

            if (flag) {
                int length = j - i + 1;
                if (length > res) {
                    res = length;
                }
            }
        }
    }
    return res;
}
```

```JavaScript
var longestBalanced = function(s) {
    const n = s.length;
    let res = 0;

    for (let i = 0; i < n; i++) {
        const cnt = new Array(26).fill(0);

        for (let j = i; j < n; j++) {
            let flag = true;
            const c = s.charCodeAt(j) - 97;
            cnt[c]++;
            for (const x of cnt) {
                if (x > 0 && x !== cnt[c]) {
                    flag = false;
                    break;
                }
            }

            if (flag) {
                res = Math.max(res, j - i + 1);
            }
        }
    }
    return res;
};
```

```TypeScript
function longestBalanced(s: string): number {
    const n = s.length;
    let res = 0;

    for (let i = 0; i < n; i++) {
        const cnt: number[] = new Array(26).fill(0);

        for (let j = i; j < n; j++) {
            let flag = true;
            const c = s.charCodeAt(j) - 97;
            cnt[c]++;

            for (const x of cnt) {
                if (x > 0 && x !== cnt[c]) {
                    flag = false;
                    break;
                }
            }

            if (flag) {
                res = Math.max(res, j - i + 1);
            }
        }
    }
    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(Cn^2)$，其中 $C$ 是字符集大小，本题中为 $26$，$n$ 为字符串 $s$ 的长度。枚举每个子串的时间复杂度为 $O(n^2)$，判断每个子串是否为平衡串的时间复杂度为 $O(C)$。
- 空间复杂度：$O(C)$。
