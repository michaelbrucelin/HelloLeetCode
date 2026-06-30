### [包含所有三种字符的子字符串数目](https://leetcode.cn/problems/number-of-substrings-containing-all-three-characters/solutions/109170/bao-han-suo-you-san-chong-zi-fu-de-zi-zi-fu-chuan/)

#### 方法一：枚举 + 二分

我们定义 $a$，$b$，$c$ 都至少出现过一次的字符串为合法的字符串，否则为非法的字符串。

可以观察到一个性质：**从下标 $i$ 开始的所有子串，我们按顺序从前到后考虑，一定是前部分均非法，后部分均合法**，简单来说，假设 $[i,j]$ 的子串已经合法，那么 $[i,j+1]$ 必然合法，如果 $[i,j]$ 非法，那么 $[i,j-1]$ 必然非法，这是很显然的。

通过这个性质我们知道对于下标 $i$ 开始的所有子串，它的合法性是随下标具有单调性的（如果我们把非法字符串设为 $0$，合法字符串设为 $1$，那么从下标 $i$ 开始的所有子串一定是 $000011$ 这样的形式），所以我们就可以进行二分查找，找到第一个合法的子串的下标 $j$，那么下标 $i$ 开始的合法子串数就是 $len(s)-j+1$ 了，最后的答案就是

$$\sum\limits_{i=1}^{len(s)} len(s)-j+1$$

二分查找的时候需要判断子串是否合法，为了 $O(1)$ 判断，我们需要预处理三个字符出现次数的前缀和数组，判断的时候直接 $O(1)$ 差分查一下子串里 $a$，b，$c$ 的个数即可判断。

```C++
class Solution {
public:
    int numberOfSubstrings(string s) {
        int len = s.length();
        int ans = 0;
        vector<vector<int>> pre(3, vector<int>(len + 1));
        pre[0][0] = pre[1][0] = pre[2][0] = 0;

        for (int i = 0; i < len; ++i) {
            for (int j = 0; j < 3; ++j) {
                pre[j][i + 1] = pre[j][i];
            }
            pre[s[i] - 'a'][i + 1]++;
        }

        for (int i = 0; i < len; ++i) {
            int left = i + 1, right = len, pos = -1;
            while (left <= right) {
                int mid = left + ((right - left) >> 1);
                if (pre[0][mid] - pre[0][i] > 0 &&
                    pre[1][mid] - pre[1][i] > 0 &&
                    pre[2][mid] - pre[2][i] > 0) {
                    right = mid - 1;
                    pos = mid;
                } else {
                    left = mid + 1;
                }
            }

            if (pos != -1) {
                ans += len - pos + 1;
            }
        }

        return ans;
    }
};
```

```Python
class Solution:
    def numberOfSubstrings(self, s: str) -> int:
        n = len(s)
        ans = 0
        pre = [[0] * (n + 1) for _ in range(3)]

        for i in range(n):
            for j in range(3):
                pre[j][i + 1] = pre[j][i]
            pre[ord(s[i]) - ord('a')][i + 1] += 1

        for i in range(n):
            left, right = i + 1, n
            pos = -1

            while left <= right:
                mid = left + ((right - left) >> 1)
                if (pre[0][mid] - pre[0][i] > 0 and
                    pre[1][mid] - pre[1][i] > 0 and
                    pre[2][mid] - pre[2][i] > 0):
                    right = mid - 1
                    pos = mid
                else:
                    left = mid + 1

            if pos != -1:
                ans += n - pos + 1

        return ans
```

```Java
class Solution {
    public int numberOfSubstrings(String s) {
        int len = s.length();
        int ans = 0;
        int[][] pre = new int[3][len + 1];

        pre[0][0] = pre[1][0] = pre[2][0] = 0;
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < 3; j++) {
                pre[j][i + 1] = pre[j][i];
            }
            pre[s.charAt(i) - 'a'][i + 1]++;
        }

        for (int i = 0; i < len; i++) {
            int left = i + 1, right = len, pos = -1;
            while (left <= right) {
                int mid = left + ((right - left) >> 1);
                if (pre[0][mid] - pre[0][i] > 0 &&
                    pre[1][mid] - pre[1][i] > 0 &&
                    pre[2][mid] - pre[2][i] > 0) {
                    right = mid - 1;
                    pos = mid;
                } else {
                    left = mid + 1;
                }
            }

            if (pos != -1) {
                ans += len - pos + 1;
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfSubstrings(string s) {
        int len = s.Length;
        int ans = 0;
        int[,] pre = new int[3, len + 1];

        pre[0, 0] = pre[1, 0] = pre[2, 0] = 0;
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < 3; j++) {
                pre[j, i + 1] = pre[j, i];
            }
            pre[s[i] - 'a', i + 1]++;
        }

        for (int i = 0; i < len; i++) {
            int left = i + 1, right = len, pos = -1;

            while (left <= right) {
                int mid = left + ((right - left) >> 1);

                if (pre[0, mid] - pre[0, i] > 0 &&
                    pre[1, mid] - pre[1, i] > 0 &&
                    pre[2, mid] - pre[2, i] > 0) {
                    right = mid - 1;
                    pos = mid;
                } else {
                    left = mid + 1;
                }
            }

            if (pos != -1) {
                ans += len - pos + 1;
            }
        }

        return ans;
    }
}
```

```Go
func numberOfSubstrings(s string) int {
    n := len(s)
    ans := 0

    pre := make([][]int, 3)
    for i := 0; i < 3; i++ {
        pre[i] = make([]int, n+1)
    }
    for i := 0; i < n; i++ {
        for j := 0; j < 3; j++ {
            pre[j][i+1] = pre[j][i]
        }
        pre[s[i]-'a'][i+1]++
    }

    for i := 0; i < n; i++ {
        left, right := i+1, n
        pos := -1

        for left <= right {
            mid := left + (right-left)>>1

            if pre[0][mid]-pre[0][i] > 0 &&
               pre[1][mid]-pre[1][i] > 0 &&
               pre[2][mid]-pre[2][i] > 0 {
                right = mid - 1
                pos = mid
            } else {
                left = mid + 1
            }
        }

        if pos != -1 {
            ans += n - pos + 1
        }
    }

    return ans
}
```

```C
int numberOfSubstrings(char* s) {
    int len = strlen(s);
    int ans = 0;

    int** pre = (int**)malloc(3 * sizeof(int*));
    for (int i = 0; i < 3; i++) {
        pre[i] = (int*)malloc((len + 1) * sizeof(int));
    }
    pre[0][0] = pre[1][0] = pre[2][0] = 0;

    for (int i = 0; i < len; i++) {
        for (int j = 0; j < 3; j++) {
            pre[j][i + 1] = pre[j][i];
        }
        pre[s[i] - 'a'][i + 1]++;
    }

    for (int i = 0; i < len; i++) {
        int left = i + 1, right = len, pos = -1;
        while (left <= right) {
            int mid = left + ((right - left) >> 1);
            if (pre[0][mid] - pre[0][i] > 0 &&
                pre[1][mid] - pre[1][i] > 0 &&
                pre[2][mid] - pre[2][i] > 0) {
                right = mid - 1;
                pos = mid;
            } else {
                left = mid + 1;
            }
        }

        if (pos != -1) {
            ans += len - pos + 1;
        }
    }

    for (int i = 0; i < 3; i++) {
        free(pre[i]);
    }
    free(pre);

    return ans;
}
```

```JavaScript
var numberOfSubstrings = function(s) {
    const n = s.length;
    let ans = 0;

    const pre = Array.from({ length: 3 }, () => new Array(n + 1).fill(0));
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < 3; j++) {
            pre[j][i + 1] = pre[j][i];
        }
        pre[s.charCodeAt(i) - 97][i + 1]++;
    }

    for (let i = 0; i < n; i++) {
        let left = i + 1, right = n, pos = -1;
        while (left <= right) {
            const mid = left + ((right - left) >> 1);

            if (pre[0][mid] - pre[0][i] > 0 &&
                pre[1][mid] - pre[1][i] > 0 &&
                pre[2][mid] - pre[2][i] > 0) {
                right = mid - 1;
                pos = mid;
            } else {
                left = mid + 1;
            }
        }

        if (pos !== -1) {
            ans += n - pos + 1;
        }
    }

    return ans;
};
```

```TypeScript
function numberOfSubstrings(s: string): number {
    const n = s.length;
    let ans = 0;
    const pre: number[][] = Array.from({ length: 3 }, () => new Array(n + 1).fill(0));

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < 3; j++) {
            pre[j][i + 1] = pre[j][i];
        }
        pre[s.charCodeAt(i) - 97][i + 1]++;
    }

    for (let i = 0; i < n; i++) {
        let left = i + 1, right = n, pos = -1;
        while (left <= right) {
            const mid = left + ((right - left) >> 1);
            if (pre[0][mid] - pre[0][i] > 0 &&
                pre[1][mid] - pre[1][i] > 0 &&
                pre[2][mid] - pre[2][i] > 0) {
                right = mid - 1;
                pos = mid;
            } else {
                left = mid + 1;
            }
        }

        if (pos !== -1) {
            ans += n - pos + 1;
        }
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_substrings(s: String) -> i32 {
        let s = s.as_bytes();
        let n = s.len();
        let mut ans = 0;
        let mut pre = vec![vec![0; n + 1]; 3];

        for i in 0..n {
            for j in 0..3 {
                pre[j][i + 1] = pre[j][i];
            }
            pre[(s[i] - b'a') as usize][i + 1] += 1;
        }

        for i in 0..n {
            let mut left = i + 1;
            let mut right = n;
            let mut pos = -1;

            while left <= right {
                let mid = left + ((right - left) >> 1);
                if pre[0][mid] - pre[0][i] > 0 &&
                   pre[1][mid] - pre[1][i] > 0 &&
                   pre[2][mid] - pre[2][i] > 0 {
                    right = mid - 1;
                    pos = mid as i32;
                } else {
                    left = mid + 1;
                }
            }

            if pos != -1 {
                ans += (n - pos as usize + 1) as i32;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：枚举每个下标需要 $O(n)$ 的时间，$n=s.length$，统计每个下标为起点里面套了一个二分需要 $O(\log n)$ 的时间，所以总时间复杂度为 $O(n\log n)$。
- 空间复杂度：为了二分里面判断是不是合法子串，需要额外提供一个前缀和数组，所以空间复杂度为 $O(n)$。

#### 方法二：双指针

针对上面发现的性质还可以继续深挖，我们假设下标 $i$ 开始第一个合法的字符串的末尾下标为 $pos_i$，则可以知道：

$$pos_1\le pos_2\le \dots \le pos_{len(s)}$$

这说明了 $pos_i$ 是单调不降的，如果我们已经得出了下标 $i$ 开始的第一个合法字符串末尾的下标 $pos_i$，则计算下标 $i+1$ 的 $pos_{i+1}$ 的时候，我们就可以复用 $[i+1,pos_i]$ 里的信息，即当前字符串里a，$b$，c出现的次数，再从 $pos_i+1$ 开始往后延伸找到第一个符合条件的下标，这就是我们常说的双指针算法。

维护两个指针 $l$ 和 $r$，以及 $[l,r]$ 区间内 $a$，$b$，$c$ 出现的次数。针对 $l$ 找到第一个符合条件的 $r$ 以后把答案加上 $len(s)-r$，然后把 $l$ 加一，减去 $s[l]$ 字符的贡献，得出 $[l+1,r]$ 里 $a$，$b$，$c$ 出现的次数，然后再不断延伸 $r$ 找第一个符合条件的合法字符串即可，这样我们就可以针对每一个下标找到对应的 $pos_i$，最后的答案就是

$$\sum\limits_{i=0}^{len(s)-1} len(s)-pos_i$$

```C++
class Solution {
public:
    int numberOfSubstrings(string s) {
        int len = s.length();
        int ans = 0;
        vector<int> cnt(3);

        for (int l = 0, r = -1; l < len; ) {
            while (r < len && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1)) {
                r++;
                if (r == len) {
                    break;
                }
                cnt[s[r] - 'a']++;
            }
            if (r < len) {
                ans += len - r;
            }
            cnt[s[l] - 'a']--;
            l++;
        }

        return ans;
    }
};
```

```Python
class Solution:
    def numberOfSubstrings(self, s: str) -> int:
        n = len(s)
        ans = 0
        cnt = [0, 0, 0]

        l, r = 0, -1
        while l < n:
            while r < n and not (cnt[0] >= 1 and cnt[1] >= 1 and cnt[2] >= 1):
                r += 1
                if r == n:
                    break
                cnt[ord(s[r]) - ord('a')] += 1

            if r < n:
                ans += n - r

            cnt[ord(s[l]) - ord('a')] -= 1
            l += 1

        return ans
```

```Java
class Solution {
    public int numberOfSubstrings(String s) {
        int len = s.length();
        int ans = 0;
        int[] cnt = new int[3];

        for (int l = 0, r = -1; l < len; ) {
            while (r < len && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1)) {
                r++;
                if (r == len) {
                    break;
                }
                cnt[s.charAt(r) - 'a']++;
            }
            if (r < len) {
                ans += len - r;
            }
            cnt[s.charAt(l) - 'a']--;
            l++;
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfSubstrings(string s) {
        int len = s.Length;
        int ans = 0;
        int[] cnt = new int[3];

        for (int l = 0, r = -1; l < len; ) {
            while (r < len && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1)) {
                r++;
                if (r == len) {
                    break;
                }
                cnt[s[r] - 'a']++;
            }
            if (r < len) {
                ans += len - r;
            }
            cnt[s[l] - 'a']--;
            l++;
        }

        return ans;
    }
}
```

```Go
func numberOfSubstrings(s string) int {
    n := len(s)
    ans := 0
    cnt := make([]int, 3)

    l, r := 0, -1
    for l < n {
        for r < n && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1) {
            r++
            if r == n {
                break
            }
            cnt[s[r]-'a']++
        }
        if r < n {
            ans += n - r
        }
        cnt[s[l]-'a']--
        l++
    }

    return ans
}
```

```C
int numberOfSubstrings(char* s) {
    int len = strlen(s);
    int ans = 0;
    int cnt[3] = {0};

    int l = 0, r = -1;
    while (l < len) {
        while (r < len && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1)) {
            r++;
            if (r == len) {
                break;
            }
            cnt[s[r] - 'a']++;
        }
        if (r < len) {
            ans += len - r;
        }
        cnt[s[l] - 'a']--;
        l++;
    }

    return ans;
}
```

```JavaScript
var numberOfSubstrings = function(s) {
    const n = s.length;
    let ans = 0;
    const cnt = [0, 0, 0];

    for (let l = 0, r = -1; l < n; ) {
        while (r < n && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1)) {
            r++;
            if (r === n) {
                break;
            }
            cnt[s.charCodeAt(r) - 97]++;
        }
        if (r < n) {
            ans += n - r;
        }
        cnt[s.charCodeAt(l) - 97]--;
        l++;
    }

    return ans;
};
```

```TypeScript
function numberOfSubstrings(s: string): number {
    const n = s.length;
    let ans = 0;
    const cnt: number[] = [0, 0, 0];

    for (let l = 0, r = -1; l < n; ) {
        while (r < n && !(cnt[0] >= 1 && cnt[1] >= 1 && cnt[2] >= 1)) {
            r++;
            if (r === n) {
                break;
            }
            cnt[s.charCodeAt(r) - 97]++;
        }
        if (r < n) {
            ans += n - r;
        }
        cnt[s.charCodeAt(l) - 97]--;
        l++;
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_substrings(s: String) -> i32 {
        let s = s.as_bytes();
        let n = s.len();
        let mut ans = 0;
        let mut cnt = [0; 3];

        let mut l = 0;
        let mut r = 0;

        while l < n {
            while r < n && (cnt[0] == 0 || cnt[1] == 0 || cnt[2] == 0) {
                cnt[(s[r] - b'a') as usize] += 1;
                r += 1;
            }

            if cnt[0] > 0 && cnt[1] > 0 && cnt[2] > 0 {
                ans += (n - r + 1) as i32;
            }

            cnt[(s[l] - b'a') as usize] -= 1;
            l += 1;
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：两个指针各移动了 $n$ 次，所以时间复杂度为 $O(n)$，$n=s.length$。
- 空间复杂度：只需要常数的空间记录当前三个字符的出现次数，所以空间复杂度为 $O(1)$。
