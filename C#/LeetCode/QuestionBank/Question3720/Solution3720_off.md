### [大于目标字符串的最小字典序排列](https://leetcode.cn/problems/lexicographically-smallest-permutation-greater-than-target/solutions/4013844/da-yu-mu-biao-zi-fu-chuan-de-zui-xiao-zi-knhx/)

#### 方法一：顺序枚举

**思路与算法**

我们从左向右顺序枚举 $target$ 的每一位，尝试构造字典序大于 $target$ 的最小排列。由于我们要找一个排列使其字典序大于 $target$，那么一定存在某个位置 $i$，使得：

- 前 $i$ 个字符与 $target$ 完全相同
- 第 $i$ 个字符大于 $target[i]$
- 第 $i$ 个位置之后的所有字符按最小字典序排列

因此，我们从左到右遍历每一位，在每一位上先尝试保持与 $target$ 相同（贪心选择最小的可行字符），如果后续无法构成大于 $target$ 的结果，则尝试放一个更大的字符，然后将剩余字符升序排列即可。

**详细步骤：**

1. **统计字符频率**：遍历 $s$，用计数数组 $cnt$ 记录每个字符的出现次数，作为可用字符池。
2. **从左到右处理每一位 i**：
   - **情况1 $-$ 保持相同**：如果 $target[i]$ 在字符池中还有剩余，则尝试放置 $target[i]$。放置后，检查用剩余字符能否构成大于 $target[i+1:]$ 的字符串。
      - 判断方法：用剩余字符构造**最大字典序字符串**（降序排列），与 $target$ 的后缀 $target[i+1:]$ 比较。如果最大字符串大于后缀，说明可以继续构造，将该字符加入结果并继续处理下一位。
      - 如果最大字符串不大于后缀，说明即使把剩余字符排成最大也无法超过 $target$，需要回溯（将该字符放回池中），转而执行情况 $2$。
   - **情况2 $-$ 放置更大字符**：在字符池中找一个大于 $target[i]$ 的最小可用字符，放入当前位置。此时无论后缀如何排列，结果都已大于 $target$。为了得到**最小**的大于 $target$ 的排列，将剩余字符按**最小字典序**（升序）全部追加到结果末尾，直接返回。
   - **无法找到可行方案**：如果情况 $1$ 不可行且情况 $2$ 也找不到更大的字符，说明从前缀相同的路径无法构造合法结果，直接返回空字符串。
3. **边界情况**：如果遍历完所有位置后仍未返回，说明 $target$ 本身就是字符池能构成的最大排列，返回空字符串。

**代码**

```C++
class Solution {
public:
    string lexGreaterPermutation(string s, string target) {
        vector<int> cnt(26, 0);
        for (char c : s) {
            cnt[c - 'a']++;
        }

        string res;
        int n = target.size();
        for (int i = 0; i < n; i++) {
            int targetChar = target[i] - 'a';

            // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
            if (cnt[targetChar] > 0) {
                cnt[targetChar]--;
                // 检查剩余字符能否构成大于 target[i+1:] 的字符串
                if (canFormGreater(cnt, target, i + 1)) {
                    res.push_back(target[i]);
                    continue;
                }
                // 不能构成更大的字符串，回溯
                cnt[targetChar]++;
            }

            // 情况2：在当前位置放置一个大于 target[i] 的字符
            for (int j = targetChar + 1; j < 26; j++) {
                if (cnt[j] > 0) {
                    cnt[j]--;
                    res.push_back('a' + j);
                    // 剩余位置按最小字典序填充
                    res += getMinString(cnt);
                    return res;
                }
            }

            // 无法找到可行方案, 直接返回
            return "";
        }

        return "";
    }

private:
    // 检查剩余字符是否能构成大于 suffix 的字符串
    bool canFormGreater(const vector<int>& cnt, const string& target, int start) {
        string maxStr = getMaxString(cnt);
        string suffix = target.substr(start);
        return maxStr > suffix;
    }

    // 获取最大字典序字符串（降序排列）
    string getMaxString(const vector<int>& cnt) {
        string res;
        for (int i = 25; i >= 0; i--) {
            res.append(cnt[i], 'a' + i);
        }
        return res;
    }

    // 获取最小字典序字符串（升序排列）
    string getMinString(const vector<int>& cnt) {
        string res;
        for (int i = 0; i < 26; i++) {
            res.append(cnt[i], 'a' + i);
        }
        return res;
    }
};
```

```Java
class Solution {
    public String lexGreaterPermutation(String s, String target) {
        int[] cnt = new int[26];
        for (char c : s.toCharArray()) {
            cnt[c - 'a']++;
        }

        StringBuilder res = new StringBuilder();
        int n = target.length();
        for (int i = 0; i < n; i++) {
            int targetChar = target.charAt(i) - 'a';

            // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
            if (cnt[targetChar] > 0) {
                cnt[targetChar]--;
                // 检查剩余字符能否构成大于 target[i+1:] 的字符串
                if (canFormGreater(cnt, target, i + 1)) {
                    res.append(target.charAt(i));
                    continue;
                }
                // 不能构成更大的字符串，回溯
                cnt[targetChar]++;
            }

            // 情况2：在当前位置放置一个大于 target[i] 的字符
            for (int j = targetChar + 1; j < 26; j++) {
                if (cnt[j] > 0) {
                    cnt[j]--;
                    res.append((char)('a' + j));
                    // 剩余位置按最小字典序填充
                    res.append(getMinString(cnt));
                    return res.toString();
                }
            }

            // 无法找到可行方案, 直接返回
            return "";
        }

        return "";
    }

    // 检查剩余字符是否能构成大于 suffix 的字符串
    private boolean canFormGreater(int[] cnt, String target, int start) {
        String maxStr = getMaxString(cnt);
        String suffix = target.substring(start);
        return maxStr.compareTo(suffix) > 0;
    }

    // 获取最大字典序字符串（降序排列）
    private String getMaxString(int[] cnt) {
        StringBuilder res = new StringBuilder();
        for (int i = 25; i >= 0; i--) {
            if (cnt[i] > 0) {
                res.append(String.valueOf((char)('a' + i)).repeat(cnt[i]));
            }
        }
        return res.toString();
    }

    // 获取最小字典序字符串（升序排列）
    private String getMinString(int[] cnt) {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            if (cnt[i] > 0) {
                res.append(String.valueOf((char)('a' + i)).repeat(cnt[i]));
            }
        }
        return res.toString();
    }
}
```

```CSharp
public class Solution {
    public string LexGreaterPermutation(string s, string target) {
        int[] cnt = new int[26];
        foreach (char c in s) {
            cnt[c - 'a']++;
        }

        StringBuilder res = new StringBuilder();
        int n = target.Length;

        for (int i = 0; i < n; i++) {
            int targetChar = target[i] - 'a';

            // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
            if (cnt[targetChar] > 0) {
                cnt[targetChar]--;
                // 检查剩余字符能否构成大于 target[i+1:] 的字符串
                if (CanFormGreater(cnt, target, i + 1)) {
                    res.Append(target[i]);
                    continue;
                }
                // 不能构成更大的字符串，回溯
                cnt[targetChar]++;
            }

            // 情况2：在当前位置放置一个大于 target[i] 的字符
            for (int j = targetChar + 1; j < 26; j++) {
                if (cnt[j] > 0) {
                    cnt[j]--;
                    res.Append((char)('a' + j));
                    // 剩余位置按最小字典序填充
                    res.Append(GetMinString(cnt));
                    return res.ToString();
                }
            }

            // 无法找到可行方案, 直接返回
            return "";
        }

        return "";
    }

    // 检查剩余字符是否能构成大于 suffix 的字符串
    private bool CanFormGreater(int[] cnt, string target, int start) {
        string maxStr = GetMaxString(cnt);
        string suffix = target.Substring(start);
        return string.Compare(maxStr, suffix) > 0;
    }

    // 获取最大字典序字符串（降序排列）
    private string GetMaxString(int[] cnt) {
        System.Text.StringBuilder res = new System.Text.StringBuilder();
        for (int i = 25; i >= 0; i--) {
            if (cnt[i] > 0) {
                res.Append(new string((char)('a' + i), cnt[i]));
            }
        }
        return res.ToString();
    }

    // 获取最小字典序字符串（升序排列）
    private string GetMinString(int[] cnt) {
        System.Text.StringBuilder res = new System.Text.StringBuilder();
        for (int i = 0; i < 26; i++) {
            if (cnt[i] > 0) {
                res.Append(new string((char)('a' + i), cnt[i]));
            }
        }
        return res.ToString();
    }
}
```

```Go
func lexGreaterPermutation(s string, target string) string {
    cnt := make([]int, 26)
    for _, c := range s {
        cnt[c-'a']++
    }

    var res []byte
    n := len(target)

    for i := 0; i < n; i++ {
        targetChar := int(target[i] - 'a')

        // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
        if cnt[targetChar] > 0 {
            cnt[targetChar]--
            // 检查剩余字符能否构成大于 target[i+1:] 的字符串
            if canFormGreater(cnt, target, i+1) {
                res = append(res, target[i])
                continue
            }
            // 不能构成更大的字符串，回溯
            cnt[targetChar]++
        }

        // 情况2：在当前位置放置一个大于 target[i] 的字符
        for j := targetChar + 1; j < 26; j++ {
            if cnt[j] > 0 {
                cnt[j]--
                res = append(res, byte('a'+j))
                // 剩余位置按最小字典序填充
                res = append(res, getMinString(cnt)...)
                return string(res)
            }
        }

        // 无法找到可行方案, 直接返回
        return ""
    }

    return ""
}

// 检查剩余字符是否能构成大于 suffix 的字符串
func canFormGreater(cnt []int, target string, start int) bool {
    maxStr := getMaxString(cnt)
    suffix := target[start:]
    return maxStr > suffix
}

// 获取最大字典序字符串（降序排列）
func getMaxString(cnt []int) string {
    var res []byte
    for i := 25; i >= 0; i-- {
        if cnt[i] > 0 {
            for k := 0; k < cnt[i]; k++ {
                res = append(res, byte('a'+i))
            }
        }
    }
    return string(res)
}

// 获取最小字典序字符串（升序排列）
func getMinString(cnt []int) string {
    var res []byte
    for i := 0; i < 26; i++ {
        if cnt[i] > 0 {
            for k := 0; k < cnt[i]; k++ {
                res = append(res, byte('a'+i))
            }
        }
    }
    return string(res)
}
```

```Python
class Solution:
    def lexGreaterPermutation(self, s: str, target: str) -> str:
        cnt = [0] * 26
        for c in s:
            cnt[ord(c) - ord('a')] += 1

        n = len(target)
        res = []

        for i in range(n):
            t = ord(target[i]) - ord('a')

            # 尝试放置和 target[i] 相同的字符
            if cnt[t] > 0:
                cnt[t] -= 1
                # 检查能否成功
                if self.can_greater(cnt, target[i + 1:]):
                    res.append(target[i])
                    continue
                cnt[t] += 1

            # 找一个更大的字符
            for c in range(t + 1, 26):
                if cnt[c] > 0:
                    cnt[c] -= 1
                    res.append(chr(c + ord('a')))
                    # 剩余字符最小排列
                    res.append(''.join(chr(j + ord('a')) * cnt[j] for j in range(26)))
                    return ''.join(res)

            # 找不到可行方案
            return ""

        return ""

    def can_greater(self, cnt: list[int], suffix: str) -> bool:
        # 从大到小构造最大字符串
        max_str = ''.join(chr(i + ord('a')) * cnt[i] for i in range(25, -1, -1) if cnt[i] > 0)
        return max_str > suffix
```

```C
// 获取最小字典序字符串（升序排列）
char* getMinString(const int* cnt) {
    int totalLen = 0;
    for (int i = 0; i < 26; i++) {
        totalLen += cnt[i];
    }

    char* res = (char*)malloc(totalLen + 1);
    int pos = 0;
    for (int i = 0; i < 26; i++) {
        if (cnt[i] > 0) {
            memset(res + pos, 'a' + i, cnt[i]);
            pos += cnt[i];
        }
    }
    res[pos] = '\0';
    return res;
}

// 获取最大字典序字符串（降序排列）
char* getMaxString(const int* cnt) {
    int totalLen = 0;
    for (int i = 0; i < 26; i++) {
        totalLen += cnt[i];
    }

    char* res = (char*)malloc(totalLen + 1);
    int pos = 0;
    for (int i = 25; i >= 0; i--) {
        if (cnt[i] > 0) {
            memset(res + pos, 'a' + i, cnt[i]);
            pos += cnt[i];
        }
    }
    res[pos] = '\0';
    return res;
}

// 检查剩余字符是否能构成大于 suffix 的字符串
bool canFormGreater(const int* cnt, const char* target, int start) {
    char* maxStr = getMaxString(cnt);
    bool result = strcmp(maxStr, target + start) > 0;
    free(maxStr);
    return result;
}

char* lexGreaterPermutation(char* s, char* target) {
    int cnt[26] = {0};
    for (int i = 0; s[i] != '\0'; i++) {
        cnt[s[i] - 'a']++;
    }

    int n = strlen(target);
    char* res = (char*)malloc(n + 27);
    int pos = 0;

    for (int i = 0; i < n; i++) {
        int targetChar = target[i] - 'a';

        // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
        if (cnt[targetChar] > 0) {
            cnt[targetChar]--;
            // 检查剩余字符能否构成大于 target[i+1:] 的字符串
            if (canFormGreater(cnt, target, i + 1)) {
                res[pos++] = target[i];
                continue;
            }
            // 不能构成更大的字符串，回溯
            cnt[targetChar]++;
        }

        // 情况2：在当前位置放置一个大于 target[i] 的字符
        for (int j = targetChar + 1; j < 26; j++) {
            if (cnt[j] > 0) {
                cnt[j]--;
                res[pos++] = 'a' + j;
                // 剩余位置按最小字典序填充
                char* str = getMinString(cnt);
                strcpy(res + pos, str);
                free(str);
                return res;
            }
        }

        // 无法找到可行方案，直接返回
        break;
    }

    free(res);
    return strdup("");
}
```

```JavaScript
var lexGreaterPermutation = function(s, target) {
    const cnt = new Array(26).fill(0);
    for (const c of s) {
        cnt[c.charCodeAt(0) - 97]++;
    }

    let res = '';
    const n = target.length;

    for (let i = 0; i < n; i++) {
        const targetChar = target.charCodeAt(i) - 97;

        // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
        if (cnt[targetChar] > 0) {
            cnt[targetChar]--;
            // 检查剩余字符能否构成大于 target[i+1:] 的字符串
            if (canFormGreater(cnt, target, i + 1)) {
                res += target[i];
                continue;
            }
            // 不能构成更大的字符串，回溯
            cnt[targetChar]++;
        }

        // 情况2：在当前位置放置一个大于 target[i] 的字符
        for (let j = targetChar + 1; j < 26; j++) {
            if (cnt[j] > 0) {
                cnt[j]--;
                res += String.fromCharCode(97 + j);
                // 剩余位置按最小字典序填充
                res += getMinString(cnt);
                return res;
            }
        }

        // 无法找到可行方案, 直接返回
        return '';
    }

    return '';
};

// 检查剩余字符是否能构成大于 suffix 的字符串
function canFormGreater(cnt, target, start) {
    const maxStr = getMaxString(cnt);
    const suffix = target.substring(start);
    return maxStr > suffix;
}

// 获取最大字典序字符串（降序排列）
function getMaxString(cnt) {
    let res = '';
    for (let i = 25; i >= 0; i--) {
        res += String.fromCharCode(97 + i).repeat(cnt[i]);
    }
    return res;
}

// 获取最小字典序字符串（升序排列）
function getMinString(cnt) {
    let res = '';
    for (let i = 0; i < 26; i++) {
        res += String.fromCharCode(97 + i).repeat(cnt[i]);
    }
    return res;
}
```

```TypeScript
function lexGreaterPermutation(s: string, target: string): string {
    const cnt: number[] = new Array(26).fill(0);
    for (const c of s) {
        cnt[c.charCodeAt(0) - 97]++;
    }

    let res: string = '';
    const n: number = target.length;

    for (let i = 0; i < n; i++) {
        const targetChar: number = target.charCodeAt(i) - 97;

        // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
        if (cnt[targetChar] > 0) {
            cnt[targetChar]--;
            // 检查剩余字符能否构成大于 target[i+1:] 的字符串
            if (canFormGreater(cnt, target, i + 1)) {
                res += target[i];
                continue;
            }
            // 不能构成更大的字符串，回溯
            cnt[targetChar]++;
        }

        // 情况2：在当前位置放置一个大于 target[i] 的字符
        for (let j = targetChar + 1; j < 26; j++) {
            if (cnt[j] > 0) {
                cnt[j]--;
                res += String.fromCharCode(97 + j);
                // 剩余位置按最小字典序填充
                res += getMinString(cnt);
                return res;
            }
        }

        // 无法找到可行方案, 直接返回
        return '';
    }

    return '';
}

// 检查剩余字符是否能构成大于 suffix 的字符串
function canFormGreater(cnt: number[], target: string, start: number): boolean {
    const maxStr: string = getMaxString(cnt);
    const suffix: string = target.substring(start);
    return maxStr > suffix;
}

// 获取最大字典序字符串（降序排列）
function getMaxString(cnt: number[]): string {
    let res: string = '';
    for (let i = 25; i >= 0; i--) {
        res += String.fromCharCode(97 + i).repeat(cnt[i]);
    }
    return res;
}

// 获取最小字典序字符串（升序排列）
function getMinString(cnt: number[]): string {
    let res: string = '';
    for (let i = 0; i < 26; i++) {
        res += String.fromCharCode(97 + i).repeat(cnt[i]);
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn lex_greater_permutation(s: String, target: String) -> String {
        let mut cnt = vec![0i32; 26];
        for c in s.chars() {
            cnt[(c as u8 - b'a') as usize] += 1;
        }

        let mut res = String::new();
        let n = target.len();

        for (i, c) in target.chars().enumerate() {
            let target_char = (c as u8 - b'a') as usize;

            // 情况1：先尝试在当前位置放置与 target[i] 相同的字符
            if cnt[target_char] > 0 {
                cnt[target_char] -= 1;
                // 检查剩余字符能否构成大于 target[i+1:] 的字符串
                if Self::can_form_greater(&cnt, &target[i+1..]) {
                    res.push(c);
                    continue;
                }
                // 不能构成更大的字符串，回溯
                cnt[target_char] += 1;
            }

            // 情况2：在当前位置放置一个大于 target[i] 的字符
            for j in (target_char + 1)..26 {
                if cnt[j] > 0 {
                    cnt[j] -= 1;
                    res.push((b'a' + j as u8) as char);
                    // 剩余位置按最小字典序填充
                    res.push_str(&Self::get_min_string(&cnt));
                    return res;
                }
            }

            // 无法找到可行方案, 直接返回
            return String::new();
        }

        String::new()
    }

    // 检查剩余字符是否能构成大于 suffix 的字符串
    fn can_form_greater(cnt: &[i32], suffix: &str) -> bool {
        let max_str = Self::get_max_string(cnt);
        max_str.as_str() > suffix
    }

    // 获取最小字典序字符串（升序排列）
    fn get_min_string(cnt: &[i32]) -> String {
        let total_len: usize = cnt.iter().map(|&c| c as usize).sum();
        let mut res = String::with_capacity(total_len);

        for i in 0..26 {
            res.push_str(&((b'a' + i as u8) as char).to_string().repeat(cnt[i] as usize));
        }
        res
    }

    // 获取最大字典序字符串（降序排列）
    fn get_max_string(cnt: &[i32]) -> String {
        let total_len: usize = cnt.iter().map(|&c| c as usize).sum();
        let mut res = String::with_capacity(total_len);

        for i in (0..26).rev() {
            res.push_str(&((b'a' + i as u8) as char).to_string().repeat(cnt[i] as usize));
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\times (n+\vert \sum \vert))$，其中 $n$ 是字符串长度，$\vert \sum \vert =26$ 是字符集大小。每位最多尝试 $\vert \sum \vert$ 个字符，每次检查需要 $O(\vert \sum \vert)$ 构造最大字符串并比较，比较字符串大小需要 $O(n)$。
- 空间复杂度：$O(\vert \sum \vert)$，其中 $\vert \sum \vert =26$ 是字符集大小。计数数组需要 $O(\vert \sum \vert)$ 的空间。

#### 方法二：倒序贪心

**思路与算法**

与方法一从左到右尝试不同，方法二从右到左枚举这个"分界点" $i$，避免了字符串比较操作，只需要 $O(\vert \sum \vert)$ 的数组检查，其中 $\vert \sum \vert =26$。

**详细步骤**

1. **初始化字符计数数组**：首先，我们需要知道 $s$ 中每个字符的"盈余"情况。我们用 $cnt[c]$ 统计字符 $c$ 的盈余情况。换句话说，我们从右到左枚举"分界点" $"i$，cnt[c] 表示结果的前缀与 $target[:i-1]$ 完全相同时，字符 $c$ 还剩余多少个可以用在后面的位置。如果 $cnt[c]<0$，说明字符 $c$ 的数量不足以匹配 $target$ 的前缀。由于我们从右向左遍历，$cnt$ 数组的初始状态应该为结果字符串与 $target$ 相同时各个字符的盈余情况，为此，我们遍历字符串 $s$ 和 $target$ 的每一位：
   - 遇到 $s$ 中的字符，计数加 $1$（表示该字符可用）$;$
   - 遇到 $target$ 中的字符，计数减 $1$（表示消耗掉该字符）$;$
2. **从右往左枚举分界点**：从最后一个位置开始向前遍历 $i=n-1,n-2,\dots ,0$：
   - **撤销当前位置的消耗**：将 $target[i]$ 对应的字符计数加 $1$。这一步相当于"反悔"——我们不再强制要求结果的前 $i$ 个字符与 $target$ 完全相同，而是允许在第 $i$ 个位置发生变化。
   - **检查前缀可行性**：撤销后，检查 $cnt$ 数组中是否有负数（即 $min(cnt)<0$）：
     - 如果有负数，说明即便撤销了位置 $i$，前面 $[0,i-1]$ 的字符匹配仍然无法完成（某些字符不够用），该位置无法作为分界点，此时我们应该继续向前找分界位置。
     - 如果没有负数，说明前 $i-1$ 个位置可以完全匹配 $target$，位置 $i$ 可以尝试放大。
   - **寻找更大的字符**：在位置 $i$，枚举比 $target[i]$ 大的字符：
     - 找到第一个 $cnt[j]>0$ 的字符（即字符池中有剩余的最小更大字符），将该字符放入位置 $i$，并从计数 $cnt$ 中扣除，此时 $[0,i-1]$ 的前缀保持不变；
     - **最小化后缀**：将计数数组中剩余的所有字符按升序（从 ’a’ 到 ’z’）依次追加到末尾，得到字典序最小的后缀，即可得到答案；
3. **无解情况**：如果遍历完所有位置都找不到可行的分界点，说明无法构造出大于 $target$ 的排列，返回空字符串。

**细节**

- **为什么需要从右往左？** 因为我们要找字典序**最小**的大于 $target$ 的排列，所以应该让分界点 $i$ 尽可能靠右（即尽可能长的前缀与 $target$ 相同），这样结果才最小。
- **为什么撤销后检查 min(cnt)<0？** 撤销位置 $i$ 的消耗后，$cnt$ 数组反映了前 $i-1$ 个位置完全匹配 $target$ 的前缀所需的字符余量。如果某个字符的计数为负，说明前 $i-1$ 个位置无法匹配，该分界点无效。
- **为什么将剩余字符升序排列？** 当我们把位置 $i$ 的字符变大后，无论后缀如何排列，整个字符串已经大于 $target$。为了让结果尽可能小，后缀应该按最小字典序（升序）排列。

**代码**

```C++
class Solution {
public:
    string lexGreaterPermutation(string s, string target) {
        vector<int> cnt(26);
        for (int i = 0; i < s.size(); i++) {
            cnt[s[i] - 'a']++;
            cnt[target[i] - 'a']--;
        }

        // 从右往左尝试
        for (int i = s.size() - 1; i >= 0; i--) {
            int b = target[i] - 'a';
            cnt[b]++; // 撤销消耗
             // 检查前缀能否完全匹配
            if (*min_element(cnt.begin(), cnt.end()) < 0) {
                continue;
            }
            // 找一个比 b 大的最小可用字符
            for (int j = b + 1; j < 26; j++) {
                if (cnt[j]) {
                    cnt[j]--;
                    target[i] = 'a' + j;
                    target.resize(i + 1);
                    return target + getMinString(cnt);
                }
            }
        }

        return "";
    }

    // 获取最小字典序字符串（升序排列）
    string getMinString(const vector<int>& cnt) {
        string res;
        for (int i = 0; i < 26; i++) {
            res.append(cnt[i], 'a' + i);
        }
        return res;
    }
};
```

```Java
class Solution {
    public String lexGreaterPermutation(String s, String target) {
        int[] cnt = new int[26];
        for (int i = 0; i < s.length(); i++) {
            cnt[s.charAt(i) - 'a']++;
            cnt[target.charAt(i) - 'a']--;
        }

        // 从右往左尝试
        char[] t = target.toCharArray();
        for (int i = s.length() - 1; i >= 0; i--) {
            int b = t[i] - 'a';
            cnt[b]++; // 撤销消耗
            // 检查前缀能否完全匹配
            if (Arrays.stream(cnt).min().getAsInt() < 0) {
                continue;
            }
            // 找一个比 b 大的最小可用字符
            for (int j = b + 1; j < 26; j++) {
                if (cnt[j] > 0) {
                    cnt[j]--;
                    t[i] = (char)('a' + j);
                    return new String(t, 0, i + 1) + getMinString(cnt);
                }
            }
        }

        return "";
    }

    // 获取最小字典序字符串（升序排列）
    private String getMinString(int[] cnt) {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            res.append(String.valueOf((char)('a' + i)).repeat(cnt[i]));
        }
        return res.toString();
    }
}
```

```CSharp
public class Solution {
    public string LexGreaterPermutation(string s, string target) {
        int[] cnt = new int[26];
        for (int i = 0; i < s.Length; i++) {
            cnt[s[i] - 'a']++;
            cnt[target[i] - 'a']--;
        }

        // 从右往左尝试
        char[] t = target.ToCharArray();
        for (int i = s.Length - 1; i >= 0; i--) {
            int b = t[i] - 'a';
            cnt[b]++; // 撤销消耗
            // 检查前缀能否完全匹配
            if (cnt.Min() < 0) {
                continue;
            }
            // 找一个比 b 大的最小可用字符
            for (int j = b + 1; j < 26; j++) {
                if (cnt[j] > 0) {
                    cnt[j]--;
                    t[i] = (char)('a' + j);
                    return new string(t, 0, i + 1) + GetMinString(cnt);
                }
            }
        }

        return "";
    }

    // 获取最小字典序字符串（升序排列）
    private string GetMinString(int[] cnt) {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            res.Append(new string((char)('a' + i), cnt[i]));
        }
        return res.ToString();
    }
}
```

```Go
func lexGreaterPermutation(s string, target string) string {
    cnt := make([]int, 26)
    for i := 0; i < len(s); i++ {
        cnt[s[i]-'a']++
        cnt[target[i]-'a']--
    }

    // 从右往左尝试
    t := []byte(target)
    for i := len(s) - 1; i >= 0; i-- {
        b := t[i] - 'a'
        cnt[b]++ // 撤销消耗
        // 检查前缀能否完全匹配
        if min(cnt) < 0 {
            continue
        }
        // 找一个比 b 大的最小可用字符
        for j := b + 1; j < 26; j++ {
            if cnt[j] > 0 {
                cnt[j]--
                t[i] = byte('a' + j)
                return string(t[:i+1]) + getMinString(cnt)
            }
        }
    }

    return ""
}

func min(arr []int) int {
    m := arr[0]
    for _, v := range arr {
        if v < m {
            m = v
        }
    }
    return m
}

// 获取最小字典序字符串（升序排列）
func getMinString(cnt []int) string {
    var res []byte
    for i := 0; i < 26; i++ {
        res = append(res, bytes.Repeat([]byte{byte('a' + i)}, cnt[i])...)
    }
    return string(res)
}func lexGreaterPermutation(s string, target string) string {
    cnt := make([]int, 26)
    for i := 0; i < len(s); i++ {
        cnt[s[i]-'a']++
        cnt[target[i]-'a']--
    }

    // 从右往左尝试
    t := []byte(target)
    for i := len(s) - 1; i >= 0; i-- {
        b := t[i] - 'a'
        cnt[b]++ // 撤销消耗
        // 检查前缀能否完全匹配
        if min(cnt) < 0 {
            continue
        }
        // 找一个比 b 大的最小可用字符
        for j := b + 1; j < 26; j++ {
            if cnt[j] > 0 {
                cnt[j]--
                t[i] = byte('a' + j)
                return string(t[:i+1]) + getMinString(cnt)
            }
        }
    }

    return ""
}

func min(arr []int) int {
    m := arr[0]
    for _, v := range arr {
        if v < m {
            m = v
        }
    }
    return m
}

// 获取最小字典序字符串（升序排列）
func getMinString(cnt []int) string {
    var res []byte
    for i := 0; i < 26; i++ {
        res = append(res, bytes.Repeat([]byte{byte('a' + i)}, cnt[i])...)
    }
    return string(res)
}
```

```Python
class Solution:
    def lexGreaterPermutation(self, s: str, target: str) -> str:
        cnt = [0] * 26
        for i in range(len(s)):
            cnt[ord(s[i]) - ord('a')] += 1
            cnt[ord(target[i]) - ord('a')] -= 1

        # 从右往左尝试
        t = list(target)
        for i in range(len(s) - 1, -1, -1):
            b = ord(t[i]) - ord('a')
            cnt[b] += 1  # 撤销消耗
            # 检查前缀能否完全匹配
            if min(cnt) < 0:
                continue
            # 找一个比 b 大的最小可用字符
            for j in range(b + 1, 26):
                if cnt[j] > 0:
                    cnt[j] -= 1
                    t[i] = chr(ord('a') + j)
                    return ''.join(t[:i+1]) + self.getMinString(cnt)

        return ""

    # 获取最小字典序字符串（升序排列）
    def getMinString(self, cnt: list[int]) -> str:
        res = []
        for i in range(26):
            res.append(chr(ord('a') + i) * cnt[i])
        return ''.join(res)
```

```C
// 获取最小字典序字符串（升序排列）
char* getMinString(int* cnt) {
    int total = 0;
    for (int i = 0; i < 26; i++) {
        total += cnt[i];
    }
    char* res = (char*)malloc(total + 1);
    int idx = 0;
    for (int i = 0; i < 26; i++) {
        for (int k = 0; k < cnt[i]; k++) {
            res[idx++] = 'a' + i;
        }
    }
    res[idx] = '\0';
    return res;
}

char* lexGreaterPermutation(char* s, char* target) {
    int n = strlen(s);
    int cnt[26] = {0};

    for (int i = 0; i < n; i++) {
        cnt[s[i] - 'a']++;
        cnt[target[i] - 'a']--;
    }

    // 从右往左尝试
    char* t = strdup(target);
    for (int i = n - 1; i >= 0; i--) {
        int b = t[i] - 'a';
        cnt[b]++; // 撤销消耗
        // 检查前缀能否完全匹配
        int min_val = cnt[0];
        for (int k = 1; k < 26; k++) {
            if (cnt[k] < min_val) min_val = cnt[k];
        }
        if (min_val < 0) {
            continue;
        }
        // 找一个比 b 大的最小可用字符
        for (int j = b + 1; j < 26; j++) {
            if (cnt[j] > 0) {
                cnt[j]--;
                t[i] = 'a' + j;
                t[i + 1] = '\0';

                char* suffix = getMinString(cnt);
                char* result = (char*)malloc(strlen(t) + strlen(suffix) + 1);
                strcpy(result, t);
                strcat(result, suffix);
                free(suffix);
                free(t);
                return result;
            }
        }
    }

    free(t);
    return strdup("");
}
```

```JavaScript
var lexGreaterPermutation = function(s, target) {
    const cnt = new Array(26).fill(0);
    for (let i = 0; i < s.length; i++) {
        cnt[s.charCodeAt(i) - 97]++;
        cnt[target.charCodeAt(i) - 97]--;
    }

    // 从右往左尝试
    const t = target.split('');
    for (let i = s.length - 1; i >= 0; i--) {
        const b = t[i].charCodeAt(0) - 97;
        cnt[b]++; // 撤销消耗
        // 检查前缀能否完全匹配
        if (Math.min(...cnt) < 0) {
            continue;
        }
        // 找一个比 b 大的最小可用字符
        for (let j = b + 1; j < 26; j++) {
            if (cnt[j] > 0) {
                cnt[j]--;
                t[i] = String.fromCharCode(97 + j);
                return t.slice(0, i + 1).join('') + getMinString(cnt);
            }
        }
    }

    return "";
};

// 获取最小字典序字符串（升序排列）
function getMinString(cnt) {
    let res = '';
    for (let i = 0; i < 26; i++) {
        res += String.fromCharCode(97 + i).repeat(cnt[i]);
    }
    return res;
}
```

```TypeScript
function lexGreaterPermutation(s: string, target: string): string {
    const cnt: number[] = new Array(26).fill(0);
    for (let i = 0; i < s.length; i++) {
        cnt[s.charCodeAt(i) - 97]++;
        cnt[target.charCodeAt(i) - 97]--;
    }

    // 从右往左尝试
    const t: string[] = target.split('');
    for (let i = s.length - 1; i >= 0; i--) {
        const b: number = t[i].charCodeAt(0) - 97;
        cnt[b]++; // 撤销消耗
        // 检查前缀能否完全匹配
        if (Math.min(...cnt) < 0) {
            continue;
        }
        // 找一个比 b 大的最小可用字符
        for (let j = b + 1; j < 26; j++) {
            if (cnt[j] > 0) {
                cnt[j]--;
                t[i] = String.fromCharCode(97 + j);
                return t.slice(0, i + 1).join('') + getMinString(cnt);
            }
        }
    }

    return "";
}

// 获取最小字典序字符串（升序排列）
function getMinString(cnt: number[]): string {
    let res: string = '';
    for (let i = 0; i < 26; i++) {
        res += String.fromCharCode(97 + i).repeat(cnt[i]);
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn lex_greater_permutation(s: String, target: String) -> String {
        let mut cnt = vec![0i32; 26];
        let s_bytes = s.as_bytes();
        let t_bytes = target.as_bytes();

        for i in 0..s.len() {
            cnt[(s_bytes[i] - b'a') as usize] += 1;
            cnt[(t_bytes[i] - b'a') as usize] -= 1;
        }

        // 从右往左尝试
        let mut t: Vec<u8> = target.into_bytes();
        for i in (0..s.len()).rev() {
            let b = (t[i] - b'a') as usize;
            cnt[b] += 1; // 撤销消耗
            // 检查前缀能否完全匹配
            if cnt.iter().min().unwrap() < &0 {
                continue;
            }
            // 找一个比 b 大的最小可用字符
            for j in (b + 1)..26 {
                if cnt[j] > 0 {
                    cnt[j] -= 1;
                    t[i] = b'a' + j as u8;
                    let prefix = String::from_utf8(t[..=i].to_vec()).unwrap();
                    return prefix + &Self::get_min_string(&cnt);
                }
            }
        }

        String::new()
    }

    // 获取最小字典序字符串（升序排列）
    fn get_min_string(cnt: &[i32]) -> String {
        let mut res = String::new();
        for i in 0..26 {
            res.push_str(&String::from_utf8(vec![b'a' + i as u8; cnt[i] as usize]).unwrap());
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\vert \sum \vert)$，其中 $n$ 表示给定字符串的长度，$\vert \sum \vert =26$ 表示字符集大小。倒序枚举 $target$ 每个字符，每次枚举时需要检查是否满足前缀匹配，需要的时间复杂度为 $O(\vert \sum \vert)$，因此总的时间复杂度为 $O(n\vert \sum \vert)$。
- 空间复杂度：$O(\vert \sum \vert)$，\vert $\sum \vert =26$ 表示字符集大小。需要统计字符串中每种字符的数目。
