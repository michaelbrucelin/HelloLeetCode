### [大于目标字符串的最小字典序回文排列](https://leetcode.cn/problems/lexicographically-smallest-palindromic-permutation-greater-than-target/solutions/4014407/da-yu-mu-biao-zi-fu-chuan-de-zui-xiao-zi-r5bj/)

#### 方法一：顺序枚举

**思路与算法**

题目要求对字符串 $s$ 重新排列后，找到**字典序最小**且**大于** $target$ 的**回文串**，因此首先我们需要分析 $s$ 经过重排列后是否可以构成**回文串**：

- 一个字符串能构成**回文串**，当且仅当其中出现奇数次的字符数量不超过 $1$ 个，否则无法构成**回文串**，因此我们首先统计 $s$ 中每个字符的频率，若奇数字符超过 $1$ 个，直接返回空串。

我们尝试构造**字典序最小**且**大于** $target$ 的**回文串**，我们知道回文串由**左半部分 $+$ 中间字符（可选）$ +$ 右半部分**组成，因此只需要构造左半部分（长度为 $\lfloor\dfrac{n}{2}\rfloor $），右半部分自动确定。为了方便计算，我们在构造时，将每个字符的频率除以 $2$，作为左半部分可用的字符数量。实际构造时分为以下步骤：

- **贪心构造左半部分**：根据题意，我们要找到字典序最小的回文串，但要大于 $target$，我们尝试从左到右逐位构造左半部分；
  - 每一位尝试放置当前可用的最小字符（从 ‘a’ 到 ‘z’），放置后，**检查**当前已构造的前缀能否最终形成一个大于 $target$ 的**回文串**。
  - 检查方法：用当前前缀 $+$ 剩余字符按降序填充（使后续部分尽量大），构造出当前前缀下的**最大回文串**，看是否大于 $target$。
  - 如果满足条件，则确定该位，继续下一位；否则恢复计数，尝试下一个字符。如果当前位中，所有的字符均尝试完，仍然无法形成一个大于 $target$ 的**回文串**，此时直接返回空串。
  - 剪枝技巧：如果当前构造的前缀在字典序上已经大于 $target$ 的前缀，此时后续的字符无论如何填充均不会影响字典序的大小，我们用当前前缀 $+$ 剩余字符按升序填充（使后续部分尽量小）构造出当前前缀下的**最小回文串**，并返回。
- **最终回文串生成**：左半部分构造完成后，拼接上中间字符（若 $n$ 为奇数）和左半部分的逆序，得到最终回文串。

**细节**：

- **贪心正确性**：逐位选择当前最小可行字符，由于检查函数保证后续能构造出大于 $target$ 的回文串，因此局部最优选择不会导致全局无解，且最终得到的字典序最小。
- **最大回文串检查**：用当前前缀 $+$ 剩余最大字符填充，得到该前缀下字典序最大的回文串，若它仍不大于 $target$，则任何以该前缀开头的回文串都不可能大于 $target$，因此该前缀不可行。

**代码**

```C++
class Solution {
public:
    string lexPalindromicPermutation(string s, string target) {
        int n = s.length();
        // 特殊情况：长度为1
        if (n == 1) {
            return s > target ? s : "";
        }

        // 统计每个字符的出现次数
        vector<int> cnt(26, 0);
        for (char c : s) {
            cnt[c - 'a']++;
        }

        // 检查是否能构成回文串，并记录奇数个的字符
        string oddChar = "";
        for (int i = 0; i < 26; i++) {
            if (cnt[i] % 2 == 1) {
                // 超过一个字符出现奇数次，无法构成回文
                if (oddChar != "") {
                    return "";
                }
                oddChar = string(1, 'a' + i);
            }
            cnt[i] /= 2;  // 只需要一半的字符来构造左半部分
        }

        string prefix = "";

        auto check = [&](char c) -> bool {
            string left = prefix;
            left.push_back(c);
            for (int i = 25; i >= 0; i--) {
                left.append(cnt[i], 'a' + i);
            }

            string palindrome = left + oddChar;
            string reversed_left = left;
            reverse(reversed_left.begin(), reversed_left.end());
            palindrome += reversed_left;

            return palindrome > target;
        };

        // 贪心构造左半部分的每一位
        for (int i = 0; i < n / 2; i++) {
            bool found = false;
            // 尝试放置字典序最小的字符
            for (int j = 0; j < 26; j++) {
                if (cnt[j] == 0) {
                    continue;
                }

                cnt[j]--;
                if (check('a' + j)) {
                    // 如果构造的回文串大于target，则选择该字符
                    prefix.push_back('a' + j);
                    found = true;
                    break;
                } else {
                    cnt[j]++;  // 不满足条件，恢复计数
                }
            }
            if (!found) {
                return "";  // 无法构造出大于target的回文串
            }

            if (prefix[i] > target[i]) {  // prefix已经大于target
                string left = prefix;
                for (int j = 0; j < 26; j++) {
                    left.append(cnt[j], 'a' + j);
                }
                string palindrome = left + oddChar;
                string reversed_left = left;
                reverse(reversed_left.begin(), reversed_left.end());
                palindrome += reversed_left;
                return palindrome;
            }
        }

        // 构造最终的回文串
        string ans = prefix + oddChar;
        string reversed_prefix = prefix;
        reverse(reversed_prefix.begin(), reversed_prefix.end());
        ans += reversed_prefix;
        return ans;
    }
};
```

```Java
class Solution {
    public String lexPalindromicPermutation(String s, String target) {
        int n = s.length();
        // 特殊情况：长度为1
        if (n == 1) {
            return s.compareTo(target) > 0 ? s : "";
        }

        // 统计每个字符的出现次数
        int[] cnt = new int[26];
        for (char c : s.toCharArray()) {
            cnt[c - 'a']++;
        }

        // 检查是否能构成回文串，并记录奇数个的字符
        String oddChar = "";
        for (int i = 0; i < 26; i++) {
            if (cnt[i] % 2 == 1) {
                // 超过一个字符出现奇数次，无法构成回文
                if (oddChar != "") {
                    return "";
                }
                oddChar = String.valueOf((char)('a' + i));
            }
            cnt[i] /= 2;  // 只需要一半的字符来构造左半部分
        }

        StringBuilder prefix = new StringBuilder();

        // 贪心构造左半部分的每一位
        for (int i = 0; i < n / 2; i++) {
            boolean found = false;
            // 尝试放置字典序最小的字符
            for (int j = 0; j < 26; j++) {
                if (cnt[j] == 0) {
                    continue;
                }

                cnt[j]--;
                if (check(prefix.toString(), (char)('a' + j), cnt, oddChar, target)) {
                    // 如果构造的回文串大于target，则选择该字符
                    prefix.append((char)('a' + j));
                    found = true;
                    break;
                } else {
                    cnt[j]++;  // 不满足条件，恢复计数
                }
            }
            if (!found) {
                return "";  // 无法构造出大于target的回文串
            }

            if (prefix.charAt(i) > target.charAt(i)) {  // prefix已经大于target
                StringBuilder left = new StringBuilder(prefix);
                for (int j = 0; j < 26; j++) {
                    for (int k = 0; k < cnt[j]; k++) {
                        left.append((char)('a' + j));
                    }
                }
                String palindrome = left.toString() + oddChar + new StringBuilder(left).reverse().toString();
                return palindrome;
            }
        }

        // 构造最终的回文串
        String ans = prefix.toString() + oddChar + new StringBuilder(prefix).reverse().toString();
        return ans;
    }

    private boolean check(String prefix, char c, int[] cnt, String oddChar, String target) {
        StringBuilder left = new StringBuilder(prefix);
        left.append(c);
        for (int i = 25; i >= 0; i--) {
            for (int k = 0; k < cnt[i]; k++) {
                left.append((char)('a' + i));
            }
        }

        String palindrome = left.toString() + oddChar + new StringBuilder(left).reverse().toString();

        return palindrome.compareTo(target) > 0;
    }
}
```

```CSharp
public class Solution {
    public string LexPalindromicPermutation(string s, string target) {
        int n = s.Length;
        // 特殊情况：长度为1
        if (n == 1) {
            return string.Compare(s, target) > 0 ? s : "";
        }

        // 统计每个字符的出现次数
        int[] cnt = new int[26];
        foreach (char c in s) {
            cnt[c - 'a']++;
        }

        // 检查是否能构成回文串，并记录奇数个的字符
        string oddChar = "";
        for (int i = 0; i < 26; i++) {
            if (cnt[i] % 2 == 1) {
                // 超过一个字符出现奇数次，无法构成回文
                if (oddChar != "") {
                    return "";
                }
                oddChar = ((char)('a' + i)).ToString();
            }
            cnt[i] /= 2;  // 只需要一半的字符来构造左半部分
        }

        StringBuilder prefix = new StringBuilder();

        // 贪心构造左半部分的每一位
        for (int i = 0; i < n / 2; i++) {
            bool found = false;
            // 尝试放置字典序最小的字符
            for (int j = 0; j < 26; j++) {
                if (cnt[j] == 0) {
                    continue;
                }

                cnt[j]--;
                if (Check(prefix.ToString(), (char)('a' + j), cnt, oddChar, target)) {
                    // 如果构造的回文串大于target，则选择该字符
                    prefix.Append((char)('a' + j));
                    found = true;
                    break;
                } else {
                    cnt[j]++;  // 不满足条件，恢复计数
                }
            }
            if (!found) {
                return "";  // 无法构造出大于target的回文串
            }

            if (prefix[i] > target[i]) {  // prefix已经大于target
                StringBuilder left = new StringBuilder(prefix.ToString());
                for (int j = 0; j < 26; j++) {
                    left.Append(new string((char)('a' + j), cnt[j]));
                }
                char[] leftArr = left.ToString().ToCharArray();
                Array.Reverse(leftArr);
                string palindrome = left.ToString() + oddChar + new string(leftArr);
                return palindrome;
            }
        }

        // 构造最终的回文串
        char[] prefixArr = prefix.ToString().ToCharArray();
        Array.Reverse(prefixArr);
        string ans = prefix.ToString() + oddChar + new string(prefixArr);
        return ans;
    }

    private bool Check(string prefix, char c, int[] cnt, string oddChar, string target) {
        StringBuilder left = new StringBuilder(prefix);
        left.Append(c);
        for (int i = 25; i >= 0; i--) {
            left.Append(new string((char)('a' + i), cnt[i]));
        }

        char[] leftArr = left.ToString().ToCharArray();
        Array.Reverse(leftArr);
        string palindrome = left.ToString() + oddChar + new string(leftArr);

        return string.Compare(palindrome, target) > 0;
    }
}
```

```Go
func lexPalindromicPermutation(s string, target string) string {
    n := len(s)
    // 特殊情况：长度为1
    if n == 1 {
        if s > target {
            return s
        }
        return ""
    }

    // 统计每个字符的出现次数
    cnt := make([]int, 26)
    for _, c := range s {
        cnt[c-'a']++
    }

    // 检查是否能构成回文串，并记录奇数个的字符
    oddChar := ""
    for i := 0; i < 26; i++ {
        if cnt[i]%2 == 1 {
            // 超过一个字符出现奇数次，无法构成回文
            if oddChar != "" {
                return ""
            }
            oddChar = string(rune('a' + i))
        }
        cnt[i] /= 2  // 只需要一半的字符来构造左半部分
    }

    prefix := ""

    check := func(c byte) bool {
        left := prefix + string(c)
        for i := 25; i >= 0; i-- {
            left += strings.Repeat(string(rune('a'+i)), cnt[i])
        }

        // 反转left
        reversedLeft := reverseString(left)
        palindrome := left + oddChar + reversedLeft

        return palindrome > target
    }

    // 贪心构造左半部分的每一位
    for i := 0; i < n/2; i++ {
        found := false
        // 尝试放置字典序最小的字符
        for j := 0; j < 26; j++ {
            if cnt[j] == 0 {
                continue
            }

            cnt[j]--
            if check(byte('a' + j)) {
                // 如果构造的回文串大于target，则选择该字符
                prefix += string(byte('a' + j))
                found = true
                break
            } else {
                cnt[j]++  // 不满足条件，恢复计数
            }
        }
        if !found {
            return ""  // 无法构造出大于target的回文串
        }

        if prefix[i] > target[i] {  // prefix已经大于target
            left := prefix
            for j := 0; j < 26; j++ {
                left += strings.Repeat(string(rune('a'+j)), cnt[j])
            }
            palindrome := left + oddChar + reverseString(left)
            return palindrome
        }
    }

    // 构造最终的回文串
    ans := prefix + oddChar + reverseString(prefix)
    return ans
}

func reverseString(s string) string {
    runes := []rune(s)
    for i, j := 0, len(runes)-1; i < j; i, j = i+1, j-1 {
        runes[i], runes[j] = runes[j], runes[i]
    }
    return string(runes)
}
```

```Python
class Solution:
    def lexPalindromicPermutation(self, s: str, target: str) -> str:
        n = len(s)
        # 特殊情况：长度为1
        if n == 1:
            return s if s > target else ""

        # 统计每个字符的出现次数
        cnt = [0] * 26
        for c in s:
            cnt[ord(c) - ord('a')] += 1

        # 检查是否能构成回文串，并记录奇数个的字符
        odd_char = ''
        for i in range(26):
            if cnt[i] % 2 == 1:
                # 超过一个字符出现奇数次，无法构成回文
                if odd_char != '':
                    return ""
                odd_char = chr(ord('a') + i)
            cnt[i] //= 2  # 只需要一半的字符来构造左半部分

        prefix = []

        def check(c):
            left = prefix.copy()
            left.append(c)
            for i in range(25, -1, -1):
                left.extend([chr(ord('a') + i)] * cnt[i])

            palindrome = left + [odd_char] + left[::-1]

            return ''.join(palindrome) > target

        # 贪心构造左半部分的每一位
        for i in range(n // 2):
            found = False
            # 尝试放置字典序最小的字符
            for j in range(26):
                if cnt[j] == 0:
                    continue

                cnt[j] -= 1
                if check(chr(ord('a') + j)):
                    # 如果构造的回文串大于target，则选择该字符
                    prefix.append(chr(ord('a') + j))
                    found = True
                    break
                else:
                    cnt[j] += 1  # 不满足条件，恢复计数
            if not found:
                return ""  # 无法构造出大于target的回文串

            if prefix[i] > target[i]:  # prefix已经大于target
                left = prefix[:]
                for j in range(26):
                    left.extend([chr(ord('a') + j)] * cnt[j])
                palindrome = left + [odd_char] + left[::-1]
                return ''.join(palindrome)

        # 构造最终的回文串
        ans = prefix + [odd_char] + prefix[::-1]
        return ''.join(ans)
```

```C
char* lexPalindromicPermutation(char* s, char* target) {
    int n = strlen(s);
    // 特殊情况：长度为1
    if (n == 1) {
        if (strcmp(s, target) > 0) {
            char* result = (char*)malloc(2);
            strcpy(result, s);
            return result;
        }
        return "";
    }

    // 统计每个字符的出现次数
    int cnt[26] = {0};
    for (int i = 0; i < n; i++) {
        cnt[s[i] - 'a']++;
    }

    // 检查是否能构成回文串，并记录奇数个的字符
    char oddChar = '\0';
    for (int i = 0; i < 26; i++) {
        if (cnt[i] % 2 == 1) {
            // 超过一个字符出现奇数次，无法构成回文
            if (oddChar != '\0') {
                return "";
            }
            oddChar = 'a' + i;
        }
        cnt[i] /= 2;  // 只需要一半的字符来构造左半部分
    }

    char* prefix = (char*)malloc(n / 2 + 1);
    int prefix_len = 0;
    prefix[0] = '\0';

    // 贪心构造左半部分的每一位
    for (int i = 0; i < n / 2; i++) {
        bool found = false;
        // 尝试放置字典序最小的字符
        for (int j = 0; j < 26; j++) {
            if (cnt[j] == 0) {
                continue;
            }

            cnt[j]--;

            // 构造left
            char* left = (char*)malloc(n / 2 + 2);
            int left_len = 0;
            strcpy(left, prefix);
            left_len = prefix_len;
            left[left_len++] = 'a' + j;

            for (int k = 25; k >= 0; k--) {
                for (int m = 0; m < cnt[k]; m++) {
                    left[left_len++] = 'a' + k;
                }
            }
            left[left_len] = '\0';

            // 构造palindrome
            int palindrome_len = left_len * 2 + 1;
            char* palindrome = (char*)malloc(palindrome_len + 1);
            strcpy(palindrome, left);
            int pos = left_len;
            if (oddChar != '\0') {
                palindrome[pos++] = oddChar;
            }
            for (int k = left_len - 1; k >= 0; k--) {
                palindrome[pos++] = left[k];
            }
            palindrome[pos] = '\0';

            if (strcmp(palindrome, target) > 0) {
                // 如果构造的回文串大于target，则选择该字符
                prefix[prefix_len++] = 'a' + j;
                prefix[prefix_len] = '\0';
                found = true;
                free(left);
                free(palindrome);
                break;
            } else {
                cnt[j]++;  // 不满足条件，恢复计数
                free(left);
                free(palindrome);
            }
        }
        if (!found) {
            free(prefix);
            return "";  // 无法构造出大于target的回文串
        }

        if (prefix[i] > target[i]) {  // prefix已经大于target
            char* left = (char*)malloc(n / 2 + 1);
            strcpy(left, prefix);
            int left_len = prefix_len;
            for (int j = 0; j < 26; j++) {
                for (int k = 0; k < cnt[j]; k++) {
                    left[left_len++] = 'a' + j;
                }
            }
            left[left_len] = '\0';

            int palindrome_len = left_len * 2 + 1;
            char* palindrome = (char*)malloc(palindrome_len + 1);
            strcpy(palindrome, left);
            int pos = left_len;
            if (oddChar != '\0') {
                palindrome[pos++] = oddChar;
            }
            for (int k = left_len - 1; k >= 0; k--) {
                palindrome[pos++] = left[k];
            }
            palindrome[pos] = '\0';

            free(prefix);
            free(left);
            return palindrome;
        }
    }

    // 构造最终的回文串
    int ans_len = prefix_len * 2 + 1;
    char* ans = (char*)malloc(ans_len + 1);
    strcpy(ans, prefix);
    int pos = prefix_len;
    if (oddChar != '\0') {
        ans[pos++] = oddChar;
    }
    for (int k = prefix_len - 1; k >= 0; k--) {
        ans[pos++] = prefix[k];
    }
    ans[pos] = '\0';

    free(prefix);
    return ans;
}
```

```JavaScript
var lexPalindromicPermutation = function(s, target) {
    const n = s.length;
    // 特殊情况：长度为1
    if (n === 1) {
        return s > target ? s : "";
    }

    // 统计每个字符的出现次数
    const cnt = new Array(26).fill(0);
    for (const c of s) {
        cnt[c.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }

    // 检查是否能构成回文串，并记录奇数个的字符
    let oddChar = '';
    for (let i = 0; i < 26; i++) {
        if (cnt[i] % 2 === 1) {
            // 超过一个字符出现奇数次，无法构成回文
            if (oddChar !== '') {
                return "";
            }
            oddChar = String.fromCharCode('a'.charCodeAt(0) + i);
        }
        cnt[i] = Math.floor(cnt[i] / 2);  // 只需要一半的字符来构造左半部分
    }

    let prefix = [];

    const check = (c) => {
        const left = [...prefix, c];
        for (let i = 25; i >= 0; i--) {
            for (let k = 0; k < cnt[i]; k++) {
                left.push(String.fromCharCode('a'.charCodeAt(0) + i));
            }
        }

        const palindrome = [...left, oddChar, ...left.slice().reverse()].join('');

        return palindrome > target;
    };

    // 贪心构造左半部分的每一位
    for (let i = 0; i < Math.floor(n / 2); i++) {
        let found = false;
        // 尝试放置字典序最小的字符
        for (let j = 0; j < 26; j++) {
            if (cnt[j] === 0) {
                continue;
            }

            cnt[j]--;
            if (check(String.fromCharCode('a'.charCodeAt(0) + j))) {
                // 如果构造的回文串大于target，则选择该字符
                prefix.push(String.fromCharCode('a'.charCodeAt(0) + j));
                found = true;
                break;
            } else {
                cnt[j]++;  // 不满足条件，恢复计数
            }
        }
        if (!found) {
            return "";  // 无法构造出大于target的回文串
        }

        if (prefix[i] > target[i]) {  // prefix已经大于target
            const left = [...prefix];
            for (let j = 0; j < 26; j++) {
                for (let k = 0; k < cnt[j]; k++) {
                    left.push(String.fromCharCode('a'.charCodeAt(0) + j));
                }
            }
            const palindrome = [...left, oddChar, ...left.slice().reverse()].join('');
            return palindrome;
        }
    }

    // 构造最终的回文串
    const ans = [...prefix, oddChar, ...prefix.slice().reverse()].join('');
    return ans;
};
```

```TypeScript
function lexPalindromicPermutation(s: string, target: string): string {
    const n = s.length;
    // 特殊情况：长度为1
    if (n === 1) {
        return s > target ? s : "";
    }

    // 统计每个字符的出现次数
    const cnt: number[] = new Array(26).fill(0);
    for (const c of s) {
        cnt[c.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }

    // 检查是否能构成回文串，并记录奇数个的字符
    let oddChar: string = '';
    for (let i = 0; i < 26; i++) {
        if (cnt[i] % 2 === 1) {
            // 超过一个字符出现奇数次，无法构成回文
            if (oddChar !== '') {
                return "";
            }
            oddChar = String.fromCharCode('a'.charCodeAt(0) + i);
        }
        cnt[i] = Math.floor(cnt[i] / 2);  // 只需要一半的字符来构造左半部分
    }

    const prefix: string[] = [];

    const check = (c: string): boolean => {
        const left: string[] = [...prefix, c];
        for (let i = 25; i >= 0; i--) {
            for (let k = 0; k < cnt[i]; k++) {
                left.push(String.fromCharCode('a'.charCodeAt(0) + i));
            }
        }

        const palindrome: string = [...left, oddChar, ...left.slice().reverse()].join('');

        return palindrome > target;
    };

    // 贪心构造左半部分的每一位
    for (let i = 0; i < Math.floor(n / 2); i++) {
        let found: boolean = false;
        // 尝试放置字典序最小的字符
        for (let j = 0; j < 26; j++) {
            if (cnt[j] === 0) {
                continue;
            }

            cnt[j]--;
            if (check(String.fromCharCode('a'.charCodeAt(0) + j))) {
                // 如果构造的回文串大于target，则选择该字符
                prefix.push(String.fromCharCode('a'.charCodeAt(0) + j));
                found = true;
                break;
            } else {
                cnt[j]++;  // 不满足条件，恢复计数
            }
        }
        if (!found) {
            return "";  // 无法构造出大于target的回文串
        }

        if (prefix[i] > target[i]) {  // prefix已经大于target
            const left: string[] = [...prefix];
            for (let j = 0; j < 26; j++) {
                for (let k = 0; k < cnt[j]; k++) {
                    left.push(String.fromCharCode('a'.charCodeAt(0) + j));
                }
            }
            const palindrome: string = [...left, oddChar, ...left.slice().reverse()].join('');
            return palindrome;
        }
    }

    // 构造最终的回文串
    const ans: string = [...prefix, oddChar, ...prefix.slice().reverse()].join('');
    return ans;
};
```

```Rust
impl Solution {
    pub fn lex_palindromic_permutation(s: String, target: String) -> String {
        let n = s.len();
        // 特殊情况：长度为1
        if n == 1 {
            return if s > target { s } else { String::new() };
        }

        // 统计每个字符的出现次数
        let mut cnt = vec![0; 26];
        for c in s.chars() {
            cnt[(c as u8 - b'a') as usize] += 1;
        }

        // 检查是否能构成回文串，并记录奇数个的字符
        let mut odd_char = String::new();
        for i in 0..26 {
            if cnt[i] % 2 == 1 {
                // 超过一个字符出现奇数次，无法构成回文
                if !odd_char.is_empty() {
                    return String::new();
                }
                odd_char = ((b'a' + i as u8) as char).to_string();
            }
            cnt[i] /= 2;  // 只需要一半的字符来构造左半部分
        }

        let mut prefix = String::new();

        // 贪心构造左半部分的每一位
        for i in 0..n / 2 {
            let mut found = false;
            // 尝试放置字典序最小的字符
            for j in 0..26 {
                if cnt[j] == 0 {
                    continue;
                }

                cnt[j] -= 1;

                // 检查函数
                let mut left = prefix.clone();
                left.push((b'a' + j as u8) as char);
                for k in (0..26).rev() {
                    for _ in 0..cnt[k] {
                        left.push((b'a' + k as u8) as char);
                    }
                }

                let mut palindrome = left.clone();
                palindrome.push_str(&odd_char);
                let reversed_left: String = left.chars().rev().collect();
                palindrome.push_str(&reversed_left);

                if palindrome > target {
                    // 如果构造的回文串大于target，则选择该字符
                    prefix.push((b'a' + j as u8) as char);
                    found = true;
                    break;
                } else {
                    cnt[j] += 1;  // 不满足条件，恢复计数
                }
            }
            if !found {
                return String::new();  // 无法构造出大于target的回文串
            }

            if prefix.as_bytes()[i] > target.as_bytes()[i] {  // prefix已经大于target
                let mut left = prefix.clone();
                for j in 0..26 {
                    for _ in 0..cnt[j] {
                        left.push((b'a' + j as u8) as char);
                    }
                }
                let mut palindrome = left.clone();
                palindrome.push_str(&odd_char);
                let reversed_left: String = left.chars().rev().collect();
                palindrome.push_str(&reversed_left);
                return palindrome;
            }
        }

        // 构造最终的回文串
        let mut ans = prefix.clone();
        ans.push_str(&odd_char);
        let reversed_prefix: String = prefix.chars().rev().collect();
        ans.push_str(&reversed_prefix);
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\vert \sum \vert \times (n+\vert \sum \vert))$，其中 $n$ 表示给定字符串 $s$ 的长度，$\vert \sum \vert =26$ 是字符集大小。我们遍历字符串 $s$ 并统计字符数目并判定是否构成回文串，需要的时间为 $O(n+\vert \sum \vert)$。我们从左到右枚构造文串的左半部分，并尝试每种可能的字符，一共需要尝试 $O(n\times \vert \sum \vert)$ 次，每次检查字符是否可行，需要的时间为 $O(n+\vert \sum \vert)$，因此总的时间复杂度为 $O(n\vert \sum \vert \times (n+\vert \sum \vert))$。
- 空间复杂度：$O(n+\vert \sum \vert)$，其中 $n$ 表示给定字符串 $s$ 的长度，$\vert \sum \vert =26$ 是字符集大小。存储每个字符的数目需要 $O(\vert \sum \vert)$ 的空间，构造中间字符串需要的空间为 $O(n)$。
