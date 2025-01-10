### [统计重新排列后包含另一个字符串的子字符串数目 II](https://leetcode.cn/problems/count-substrings-that-can-be-rearranged-to-contain-a-string-ii/solutions/3037272/tong-ji-zhong-xin-pai-lie-hou-bao-han-li-n09m/)

#### 方法一：滑动窗口

**思路与算法**

我们的目标是求解 $word1$ 中有多少子串经过重新排列后存在一个前缀是 $word2$，也就是说要求解有多少子串包含 $word2$ 中的全部字符。

对于每个 $l(0 \le l < n)$，找到最小的 $r(l \le r < n)$，使得 $word1$ 区间 $[l,r]$ 内包含 $word2$ 的全部字符，可以发现子串 $[l,r+1],[l,r+2], \dots ,[l,n]$ 都是满足要求的，计数 $n-r+1$。将所有的计数都加起来就是答案。

注意到每次找到 $l$ 匹配的 $r$ 后，将 $l$ 增加 $1$，区间内的字符减少，相应的 $r$ 势必会增加。因此得到结论：随着 $l$ 的增加，$r$ 也会增加，我们可以使用滑动窗口来求解。

具体来说，我们用哈希表维护当前窗口内每种字符的出现次数，初始时窗口长度为 $0$，每次我们向右移动 $r$，并将字符加入哈希表，直到每种字符的出现次数都大于 $word2$ 中的出现次数，此时将答案累加 $n-r+1$。接着我们要计算 $l+1$ 作为左边界的情况，将 $l$ 处的字符移除哈希表，并继续向右移动 $r$，重复前面的过程即可。

我们在上面采用了 $O(C)$ 的时间复杂度判断滑动窗口内每种字符的出现次数是否都大于 $word2$ 中的出现次数，其实还可以进一步优化。我们将维护的对象更改为滑动窗口内每种字符出现次数与 $word2$ 中每种字符出现次数的差值，当所有差值都大于等于 $0$ 则表示合法。但到这一步还没有与之前的方法拉开差距，需要再维护一个变量 $cnt$ 表示差值小于 $0$ 的字符种类数，当 $cnt$ 等于 $0$ 则表示合法。在滑动窗口移动时，可以仅消耗 $O(1)$ 的时间来维护 $cnt$，这样一来就降低了时间复杂度。

**代码**

```C++
class Solution {
public:
    long long validSubstringCount(string word1, string word2) {
        vector<int> diff(26, 0);
        for (auto c : word2) {
            diff[c - 'a']--;
        }

        long long res = 0;
        int cnt = count_if(diff.begin(), diff.end(), [](int c) { return c < 0; });
        auto update = [&](int c, int add) {
            diff[c] += add;
            if (add == 1 && diff[c] == 0) {
                // 表明 diff[c] 由 -1 变为 0
                cnt--;
            } else if (add == -1 && diff[c] == -1) {
                // 表明 diff[c] 由 0 变为 -1
                cnt++;
            }
        };

        for (int l = 0, r = 0; l < word1.size(); l++) {
            while (r < word1.size() && cnt > 0) {
                update(word1[r] - 'a', 1);
                r++;
            }
            if (cnt == 0) {
                res += word1.size() - r + 1;
            }
            update(word1[l] - 'a', -1);
        }
        return res;
    }
};
```

```Python
class Solution:
    def validSubstringCount(self, word1: str, word2: str) -> int:
        diff = [0] * 26
        for c in word2:
            diff[ord(c) - ord('a')] -= 1

        res = 0
        cnt = sum(1 for c in diff if c < 0)

        def update(c: int, add: int):
            nonlocal cnt
            diff[c] += add
            if add == 1 and diff[c] == 0:
                # 表明 diff[c] 由 -1 变为 0
                cnt -= 1
            elif add == -1 and diff[c] == -1:
                # 表明 diff[c] 由 0 变为 -1
                cnt += 1

        l, r = 0, 0
        while l < len(word1):
            while r < len(word1) and cnt > 0:
                update(ord(word1[r]) - ord('a'), 1)
                r += 1
            if cnt == 0:
                res += len(word1) - r + 1
            update(ord(word1[l]) - ord('a'), -1)
            l += 1

        return res
```

```Rust
impl Solution {
    pub fn valid_substring_count(word1: String, word2: String) -> i64 {
        let mut diff = vec![0; 26];
        for c in word2.chars() {
            diff[(c as u8 - b'a') as usize] -= 1;
        }

        let mut res = 0;
        let mut cnt = diff.iter().filter(|&&c| c < 0).count();

        let mut update = |c: usize, add: i32, cnt: &mut usize| {
            diff[c] += add;
            if add == 1 && diff[c] == 0 {
                // 表明 diff[c] 由 -1 变为 0
                *cnt -= 1;
            } else if add == -1 && diff[c] == -1 {
                // 表明 diff[c] 由 0 变为 -1
                *cnt += 1;
            }
        };

        let (mut l, mut r) = (0, 0);
        let n = word1.len();
        let bytes = word1.as_bytes();

        while l < n {
            while r < n && cnt > 0 {
                update((bytes[r] - b'a') as usize, 1, &mut cnt);
                r += 1;
            }
            if cnt == 0 {
                res += (n - r) as i64 + 1;
            }
            update((bytes[l] - b'a') as usize, -1, &mut cnt);
            l += 1;
        }

        res
    }
}
```

```Java
class Solution {
    public long validSubstringCount(String word1, String word2) {
        int[] diff = new int[26];
        for (char c : word2.toCharArray()) {
            diff[c - 'a']--;
        }

        long res = 0;
        int[] cnt = { (int) Arrays.stream(diff).filter(c -> c < 0).count() };
        int l = 0, r = 0;
        while (l < word1.length()) {
            while (r < word1.length() && cnt[0] > 0) {
                update(diff, word1.charAt(r) - 'a', 1, cnt);
                r++;
            }
            if (cnt[0] == 0) {
                res += word1.length() - r + 1;
            }
            update(diff, word1.charAt(l) - 'a', -1, cnt);
            l++;
        }
        return res;
    }

    private void update(int[] diff, int c, int add, int[] cnt) {
        diff[c] += add;
        if (add == 1 && diff[c] == 0) {
            // 表明 diff[c] 由 -1 变为 0
            cnt[0]--;
        } else if (add == -1 && diff[c] == -1) {
            // 表明 diff[c] 由 0 变为 -1
            cnt[0]++;
        }
    }
}
```

```CSharp
public class Solution {
    public long ValidSubstringCount(string word1, string word2) {
        int[] diff = new int[26];
        foreach (char c in word2) {
            diff[c - 'a']--;
        }
        long res = 0;
        int cnt = diff.Count(c => c < 0);
        int l = 0, r = 0;
        while (l < word1.Length) {
            while (r < word1.Length && cnt > 0) {
                Update(diff, word1[r] - 'a', 1, ref cnt);
                r++;
            }
            if (cnt == 0) {
                res += word1.Length - r + 1;
            }
            Update(diff, word1[l] - 'a', -1, ref cnt);
            l++;
        }
        return res;
    }

    private void Update(int[] diff, int c, int add, ref int cnt) {
        diff[c] += add;
        if (add == 1 && diff[c] == 0) {
            // 表明 diff[c] 由 -1 变为 0
            cnt--;
        } else if (add == -1 && diff[c] == -1) {
            // 表明 diff[c] 由 0 变为 -1
            cnt++;
        }
    }
}
```

```Go
func validSubstringCount(word1 string, word2 string) int64 {
    diff := make([]int, 26)
    for _, c := range word2 {
        diff[c - 'a']--
    }
    cnt := 0
    for _, c := range diff {
        if c < 0 {
            cnt++
        }
    }
    var res int64
    l, r := 0, 0
    for l < len(word1) {
        for r < len(word1) && cnt > 0 {
            update(diff, int(word1[r] - 'a'), 1, &cnt)
            r++
        }
        if cnt == 0 {
            res += int64(len(word1) - r + 1)
        }
        update(diff, int(word1[l]-'a'), -1, &cnt)
        l++
    }

    return res
}

func update(diff []int, c, add int, cnt *int) {
    diff[c] += add
    if add == 1 && diff[c] == 0 {
        // 表明 diff[c] 由 -1 变为 0
        *cnt--
    } else if add == -1 && diff[c] == -1 {
        // 表明 diff[c] 由 0 变为 -1
        *cnt++
    }
}
```

```C
void update(int *diff, int c, int add, int *cnt) {
    diff[c] += add;
    if (add == 1 && diff[c] == 0) {
        // 表明 diff[c] 由 -1 变为 0
        (*cnt)--;
    } else if (add == -1 && diff[c] == -1) {
        // 表明 diff[c] 由 0 变为 -1
        (*cnt)++;
    }
}

long long validSubstringCount(char* word1, char* word2) {
    int diff[26] = {0};
    for (const char *c = word2; *c; c++) {
        diff[*c - 'a']--;
    }

    int cnt = 0;
    for (int i = 0; i < 26; i++) {
        if (diff[i] < 0) {
            cnt++;
        }
    }
    long long res = 0;
    int l = 0, r = 0;
    int len1 = strlen(word1);
    while (l < len1) {
        while (r < len1 && cnt > 0) {
            update(diff, word1[r] - 'a', 1, &cnt);
            r++;
        }
        if (cnt == 0) {
            res += len1 - r + 1;
        }
        update(diff, word1[l] - 'a', -1, &cnt);
        l++;
    }

    return res;
}
```

```JavaScript
var validSubstringCount = function(word1, word2) {
    const diff = new Array(26).fill(0);
    for (const c of word2) {
        diff[c.charCodeAt(0) - 'a'.charCodeAt(0)]--;
    }

    let res = 0;
    let cnt = diff.filter(c => c < 0).length;
    const update = (c, add) => {
        diff[c] += add;
        if (add === 1 && diff[c] === 0) {
            // 表明 diff[c] 由 -1 变为 0
            cnt--;
        } else if (add === -1 && diff[c] === -1) {
            // 表明 diff[c] 由 0 变为 -1
            cnt++;
        }
    };

    let l = 0, r = 0;
    while (l < word1.length) {
        while (r < word1.length && cnt > 0) {
            update(word1.charCodeAt(r) - 'a'.charCodeAt(0), 1);
            r++;
        }
        if (cnt === 0) {
            res += word1.length - r + 1;
        }
        update(word1.charCodeAt(l) - 'a'.charCodeAt(0), -1);
        l++;
    }

    return res;
};
```

```TypeScript
function validSubstringCount(word1: string, word2: string): number {
    const diff: number[] = new Array(26).fill(0);
    for (const c of word2) {
        diff[c.charCodeAt(0) - 'a'.charCodeAt(0)]--;
    }

    let res = 0;
    let cnt = diff.filter(c => c < 0).length;
    const update = (c: number, add: number): void => {
        diff[c] += add;
        if (add === 1 && diff[c] === 0) {
            // 表明 diff[c] 由 -1 变为 0
            cnt--;
        } else if (add === -1 && diff[c] === -1) {
            // 表明 diff[c] 由 0 变为 -1
            cnt++;
        }
    };

    let l = 0, r = 0;
    while (l < word1.length) {
        while (r < word1.length && cnt > 0) {
            update(word1.charCodeAt(r) - 'a'.charCodeAt(0), 1);
            r++;
        }
        if (cnt === 0) {
            res += word1.length - r + 1;
        }
        update(word1.charCodeAt(l) - 'a'.charCodeAt(0), -1);
        l++;
    }

    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是 $word1$ 的长度，$m$ 是 $word2$ 的长度。
- 空间复杂度：$O(C)$，其中 C 是字符种类数，本题中等于 $26$。
