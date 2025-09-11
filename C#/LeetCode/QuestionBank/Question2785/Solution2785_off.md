### [将字符串中的元音字母排序](https://leetcode.cn/problems/sort-vowels-in-a-string/solutions/3766881/jiang-zi-fu-chuan-zhong-de-yuan-yin-zi-m-qllf/)

#### 方法一：模拟 + 排序

**思路与算法**

题目要求我们将给定的字符串 $s$ 中所有的元音字母进行排序。我们可以先将 $s$ 中的所有元音字母取出进行排序，然后按顺序填回原字符串中。由于排序只影响元音字母，所以我们只需要对字符串 $s$ 中的元音字母进行操作，其余字母留在原地即可。

**代码**

```C++
class Solution {
    unordered_set<char> vowels = {'a', 'e', 'i', 'o', 'u',
                                  'A', 'E', 'I', 'O', 'U'};

public:
    string sortVowels(string s) {
        string tmp;
        for (char ch : s) {
            if (vowels.contains(ch)) {
                tmp.push_back(ch);
            }
        }
        sort(tmp.begin(), tmp.end());
        int idx = 0;
        for (char& ch : s) {
            if (vowels.contains(ch)) {
                ch = tmp[idx++];
            }
        }
        return s;
    }
};
```

```Java
class Solution {
    private static final Set<Character> vowels = new HashSet<>(Arrays.asList(
        'a', 'e', 'i', 'o', 'u',
        'A', 'E', 'I', 'O', 'U'
    ));

    public String sortVowels(String s) {
        List<Character> tmp = new ArrayList<>();
        for (char ch : s.toCharArray()) {
            if (vowels.contains(ch)) {
                tmp.add(ch);
            }
        }
        
        Collections.sort(tmp);
        
        char[] arr = s.toCharArray();
        int idx = 0;
        for (int i = 0; i < arr.length; i++) {
            if (vowels.contains(arr[i])) {
                arr[i] = tmp.get(idx++);
            }
        }
        
        return new String(arr);
    }
}
```

```Python
class Solution:
    def sortVowels(self, s: str) -> str:
        vowels = {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}

        tmp = [ch for ch in s if ch in vowels]

        tmp.sort()

        s_list = list(s)
        idx = 0
        for i in range(len(s_list)):
            if s_list[i] in vowels:
                s_list[i] = tmp[idx]
                idx += 1

        return "".join(s_list)
```

```Go
var vowels = map[rune]bool{
    'a': true, 'e': true, 'i': true, 'o': true, 'u': true,
    'A': true, 'E': true, 'I': true, 'O': true, 'U': true,
}

func sortVowels(s string) string {
    var tmp []rune
    for _, ch := range s {
        if vowels[ch] {
            tmp = append(tmp, ch)
        }
    }

    sort.Slice(tmp, func(i, j int) bool {
        return tmp[i] < tmp[j]
    })

    var result strings.Builder
    idx := 0
    for _, ch := range s {
        if vowels[ch] {
            result.WriteRune(tmp[idx])
            idx++
        } else {
            result.WriteRune(ch)
        }
    }

    return result.String()
}
```

```CSharp
public class Solution {
    private static readonly HashSet<char> vowels = new HashSet<char> {
        'a', 'e', 'i', 'o', 'u',
        'A', 'E', 'I', 'O', 'U'
    };

    public string SortVowels(string s) {
        List<char> tmp = new List<char>();
        foreach (char ch in s) {
            if (vowels.Contains(ch)) {
                tmp.Add(ch);
            }
        }
        
        tmp.Sort();
        
        char[] arr = s.ToCharArray();
        int idx = 0;
        for (int i = 0; i < arr.Length; i++) {
            if (vowels.Contains(arr[i])) {
                arr[i] = tmp[idx++];
            }
        }
        
        return new string(arr);
    }
}
```

```C
bool isVowel(char c) {
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
           c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
}

int compare(const void *a, const void *b) {
    return *(char *)a - *(char *)b;
}

char *sortVowels(char *s) {
    int len = strlen(s);
    char *tmp = (char *)malloc(len + 1);
    int count = 0;

    for (int i = 0; i < len; i++) {
        if (isVowel(s[i])) {
            tmp[count++] = s[i];
        }
    }
    tmp[count] = '\0';

    qsort(tmp, count, sizeof(char), compare);

    int idx = 0;
    for (int i = 0; i < len; i++) {
        if (isVowel(s[i])) {
            s[i] = tmp[idx++];
        }
    }

    free(tmp);
    return s;
}
```

```JavaScript
var sortVowels = function (s) {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']);

    const tmp = [];
    for (const ch of s) {
        if (vowels.has(ch)) {
            tmp.push(ch);
        }
    }

    tmp.sort();

    let idx = 0;
    let result = '';
    for (const ch of s) {
        if (vowels.has(ch)) {
            result += tmp[idx++];
        } else {
            result += ch;
        }
    }

    return result;
};
```

```TypeScript
function sortVowels(s: string): string {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']);

    const tmp = [];
    for (const ch of s) {
        if (vowels.has(ch)) {
            tmp.push(ch);
        }
    }

    tmp.sort();

    let idx = 0;
    let result = '';
    for (const ch of s) {
        if (vowels.has(ch)) {
            result += tmp[idx++];
        } else {
            result += ch;
        }
    }

    return result;
};
```

```Rust
impl Solution {
    pub fn sort_vowels(s: String) -> String {
        let vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        let vowel_set: std::collections::HashSet<_> = vowels.iter().cloned().collect();

        let mut tmp: Vec<char> = s.chars().filter(|c| vowel_set.contains(c)).collect();

        tmp.sort();

        let mut result = String::with_capacity(s.len());
        let mut idx = 0;

        for c in s.chars() {
            if vowel_set.contains(&c) {
                result.push(tmp[idx]);
                idx += 1;
            } else {
                result.push(c);
            }
        }

        result
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是字符串 $s$ 的长度。将所有元音字母排序需要 $O(n\log n)$，遍历字符串需要 $O(n)$。
- 空间复杂度：$O(n)$。需要保存所有的元音字母用于排序。

#### 方法二：计数 $+$ 排序

**思路与算法**

由于我们排序的内容数值范围很小（只有大小写英语字母），可以使用计数排序进一步优化到 $O(n)$。具体来说，我们先对每个元音字母进行计数，在排序过程中直接按顺序取用即可。

**代码**

```C++
class Solution {
    unordered_set<char> vowels = {'a', 'e', 'i', 'o', 'u',
                                  'A', 'E', 'I', 'O', 'U'};

public:
    string sortVowels(string s) {
        vector<int> cnt(58, -1);
        for (char ch : vowels) {
            cnt[ch - 'A'] = 0;
        }

        for (char ch : s) {
            int i = ch - 'A';
            if (cnt[i] != -1) {
                cnt[i]++;
            }
        }

        int idx = 0;
        for (char &ch : s) {
            int i = ch - 'A';
            if (cnt[i] != -1) {
                while (cnt[idx] <= 0) {
                    idx++;
                }
                ch = (char)(idx + 'A');
                cnt[idx]--;
            }
        }

        return s;
    }
};
```

```Java
class Solution {
    public String sortVowels(String s) {
        Set<Character> vowels = new HashSet<>(Arrays.asList(
            'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'
        ));
        int[] cnt = new int[58];
        Arrays.fill(cnt, -1);
        for (char ch : vowels) {
            cnt[ch - 'A'] = 0;
        }
        
        for (char ch : s.toCharArray()) {
            int i = ch - 'A';
            if (cnt[i] != -1) {
                cnt[i]++;
            }
        }
        
        char[] arr = s.toCharArray();
        int idx = 0;
        for (int i = 0; i < arr.length; i++) {
            int pos = arr[i] - 'A';
            if (cnt[pos] != -1) {
                while (cnt[idx] <= 0) {
                    idx++;
                }
                arr[i] = (char)(idx + 'A');
                cnt[idx]--;
            }
        }
        
        return new String(arr);
    }
}
```

```Python
class Solution:
    def sortVowels(self, s: str) -> str:
        vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'}
        cnt = [-1] * 58
        for ch in vowels:
            cnt[ord(ch) - ord('A')] = 0
        
        for ch in s:
            i = ord(ch) - ord('A')
            if cnt[i] != -1:
                cnt[i] += 1
        
        s_list = list(s)
        idx = 0
        for i in range(len(s_list)):
            ch = s_list[i]
            pos = ord(ch) - ord('A')
            if cnt[pos] != -1:
                while cnt[idx] <= 0:
                    idx += 1
                s_list[i] = chr(idx + ord('A'))
                cnt[idx] -= 1
        
        return ''.join(s_list)
```

```Go
func sortVowels(s string) string {
    vowels := map[rune]bool{
        'a': true, 'e': true, 'i': true, 'o': true, 'u': true,
        'A': true, 'E': true, 'I': true, 'O': true, 'U': true,
    }
    cnt := make([]int, 58)
    for i := range cnt {
        cnt[i] = -1
    }
    for ch := range vowels {
        cnt[ch-'A'] = 0
    }

    for _, ch := range s {
        i := ch - 'A'
        if cnt[i] != -1 {
            cnt[i]++
        }
    }

    res := []rune(s)
    idx := 0
    for i, ch := range res {
        pos := ch - 'A'
        if cnt[pos] != -1 {
            for cnt[idx] <= 0 {
                idx++
            }
            res[i] = rune(idx + 'A')
            cnt[idx]--
        }
    }

    return string(res)
}
```

```CSharp
public class Solution {
    public string SortVowels(string s) {
        HashSet<char> vowels = new HashSet<char> {
            'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'
        };
        int[] cnt = new int[58];
        Array.Fill(cnt, -1);
        foreach (char ch in vowels) {
            cnt[ch - 'A'] = 0;
        }
        
        foreach (char ch in s) {
            int i = ch - 'A';
            if (cnt[i] != -1) {
                cnt[i]++;
            }
        }
        
        char[] arr = s.ToCharArray();
        int idx = 0;
        for (int i = 0; i < arr.Length; i++) {
            int pos = arr[i] - 'A';
            if (cnt[pos] != -1) {
                while (cnt[idx] <= 0) {
                    idx++;
                }
                arr[i] = (char)(idx + 'A');
                cnt[idx]--;
            }
        }
        
        return new string(arr);
    }
}
```

```C
char * sortVowels(char * s){
    const char vowels[] = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
    int cnt[58];
    for (int i = 0; i < 58; i++) {
        cnt[i] = -1;
    }
    for (int i = 0; i < 10; i++) {
        int idx = vowels[i] - 'A';
        cnt[idx] = 0;
    }

    int len = strlen(s);
    for (int i = 0; i < len; i++) {
        int idx = s[i] - 'A';
        if (cnt[idx] != -1) {
            cnt[idx]++;
        }
    }

    char *res = (char*)malloc(len + 1);
    strcpy(res, s);
    int idx = 0;
    for (int i = 0; i < len; i++) {
        int pos = res[i] - 'A';
        if (cnt[pos] != -1) {
            while (cnt[idx] <= 0) {
                idx++;
            }
            res[i] = idx + 'A';
            cnt[idx]--;
        }
    }

    return res;
}
```

```JavaScript
var sortVowels = function(s) {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']);
    const cnt = new Array(58).fill(-1);
    for (const ch of vowels) {
        const idx = ch.charCodeAt(0) - 'A'.charCodeAt(0);
        cnt[idx] = 0;
    }

    for (const ch of s) {
        const idx = ch.charCodeAt(0) - 'A'.charCodeAt(0);
        if (cnt[idx] !== -1) {
            cnt[idx]++;
        }
    }

    const arr = s.split('');
    let idx = 0;
    for (let i = 0; i < arr.length; i++) {
        const pos = arr[i].charCodeAt(0) - 'A'.charCodeAt(0);
        if (cnt[pos] !== -1) {
            while (cnt[idx] <= 0) {
                idx++;
            }
            arr[i] = String.fromCharCode(idx + 'A'.charCodeAt(0));
            cnt[idx]--;
        }
    }

    return arr.join('');
};
```

```TypeScript
function sortVowels(s: string): string {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']);
    const cnt: number[] = new Array(58).fill(-1);
    for (const ch of vowels) {
        const idx = ch.charCodeAt(0) - 'A'.charCodeAt(0);
        cnt[idx] = 0;
    }

    for (const ch of s) {
        const idx = ch.charCodeAt(0) - 'A'.charCodeAt(0);
        if (cnt[idx] !== -1) {
            cnt[idx]++;
        }
    }

    const arr = s.split('');
    let idx = 0;
    for (let i = 0; i < arr.length; i++) {
        const pos = arr[i].charCodeAt(0) - 'A'.charCodeAt(0);
        if (cnt[pos] !== -1) {
            while (cnt[idx] <= 0) {
                idx++;
            }
            arr[i] = String.fromCharCode(idx + 'A'.charCodeAt(0));
            cnt[idx]--;
        }
    }

    return arr.join('');
}
```

```Rust
impl Solution {
    pub fn sort_vowels(s: String) -> String {
        let vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        let mut cnt = vec![-1; 58];
        for &ch in &vowels {
            let idx = (ch as u8 - b'A') as usize;
            cnt[idx] = 0;
        }
        
        for ch in s.chars() {
            let idx = (ch as u8 - b'A') as usize;
            if cnt[idx] != -1 {
                cnt[idx] += 1;
            }
        }
        
        let mut res: Vec<char> = s.chars().collect();
        let mut idx = 0;
        for ch in res.iter_mut() {
            let pos = (*ch as u8 - b'A') as usize;
            if cnt[pos] != -1 {
                while cnt[idx] <= 0 {
                    idx += 1;
                }
                *ch = (idx as u8 + b'A') as char;
                cnt[idx] -= 1;
            }
        }
        
        res.into_iter().collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。只需要遍历两次字符串。
- 空间复杂度：$O(1)$。只需要若干额外变量。
