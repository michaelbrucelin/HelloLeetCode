### [元音拼写检查器](https://leetcode.cn/problems/vowel-spellchecker/solutions/3768705/yuan-yin-pin-xie-jian-cha-qi-by-leetcode-wnfb/)

#### 方法：哈希映射（HashMap）

**思路与算法**

我们分析了算法需要考虑的 $3$ 种情况: 当查询完全匹配时，当查询存在大小写不同的单词匹配时，当查询与出现元音错误的单词匹配时。

在所有 $3$ 种情况下，我们都可以使用哈希表来查询答案。

- 对于第一种情况（完全匹配），我们使用集合存放单词以有效地测试查询单词是否在该组中。
- 对于第二种情况（大小写不同），我们使用一个哈希表，该哈希表将单词从其小写形式转换为原始单词（大小写正确的形式）。
- 对于第三种情况（元音错误），我们使用一个哈希表，将单词从其小写形式（忽略元音的情况下）转换为原始单词。

该算法仅剩的要求是认真规划和仔细阅读问题。

```Java
class Solution {
    Set<String> words_perfect;
    Map<String, String> words_cap;
    Map<String, String> words_vow;

    public String[] spellchecker(String[] wordlist, String[] queries) {
        words_perfect = new HashSet();
        words_cap = new HashMap();
        words_vow = new HashMap();

        for (String word: wordlist) {
            words_perfect.add(word);

            String wordlow = word.toLowerCase();
            words_cap.putIfAbsent(wordlow, word);

            String wordlowDV = devowel(wordlow);
            words_vow.putIfAbsent(wordlowDV, word);
        }

        String[] ans = new String[queries.length];
        int t = 0;
        for (String query: queries)
            ans[t++] = solve(query);
        return ans;
    }

    public String solve(String query) {
        if (words_perfect.contains(query))
            return query;

        String queryL = query.toLowerCase();
        if (words_cap.containsKey(queryL))
            return words_cap.get(queryL);

        String queryLV = devowel(queryL);
        if (words_vow.containsKey(queryLV))
            return words_vow.get(queryLV);

        return "";
    }

    public String devowel(String word) {
        StringBuilder ans = new StringBuilder();
        for (char c: word.toCharArray())
            ans.append(isVowel(c) ? '*' : c);
        return ans.toString();
    }

    public boolean isVowel(char c) {
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }
}
```

```Python
class Solution(object):
    def spellchecker(self, wordlist, queries):
        def devowel(word):
            return "".join('*' if c in 'aeiou' else c
                           for c in word)

        words_perfect = set(wordlist)
        words_cap = {}
        words_vow = {}

        for word in wordlist:
            wordlow = word.lower()
            words_cap.setdefault(wordlow, word)
            words_vow.setdefault(devowel(wordlow), word)

        def solve(query):
            if query in words_perfect:
                return query

            queryL = query.lower()
            if queryL in words_cap:
                return words_cap[queryL]

            queryLV = devowel(queryL)
            if queryLV in words_vow:
                return words_vow[queryLV]
            return ""

        return map(solve, queries)
```

```C++
class Solution {
public:
    vector<string> spellchecker(vector<string>& wordlist, vector<string>& queries) {
        for (string word : wordlist) {
            words_perfect.insert(word);
            string wordlow;
            for (char c : word) {
                wordlow += tolower(c);
            }
            if (!words_cap.count(wordlow)) {
                words_cap[wordlow] = word;
            }
            string wordlowDV = devowel(wordlow);
            if (!words_vow.count(wordlowDV)) {
                words_vow[wordlowDV] = word;
            }
        }

        vector<string> ans;
        for (string query : queries) {
            ans.push_back(solve(query));
        }
        return ans;
    }

private:
    unordered_set<string> words_perfect;
    unordered_map<string, string> words_cap;
    unordered_map<string, string> words_vow;

    string devowel(string word) {
        string ans;
        for (char c : word) {
            ans += isVowel(c) ? '*' : c;
        }
        return ans;
    }

    bool isVowel(char c) {
        c = tolower(c);
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }

    string solve(string query) {
        if (words_perfect.count(query)) {
            return query;
        }

        string queryL;
        for (char c : query) {
            queryL += tolower(c);
        }
        if (words_cap.count(queryL)) {
            return words_cap[queryL];
        }

        string queryLV = devowel(queryL);
        if (words_vow.count(queryLV)) {
            return words_vow[queryLV];
        }

        return "";
    }
};
```

```CSharp
public class Solution {
    private HashSet<string> words_perfect = new HashSet<string>();
    private Dictionary<string, string> words_cap = new Dictionary<string, string>();
    private Dictionary<string, string> words_vow = new Dictionary<string, string>();

    public string[] Spellchecker(string[] wordlist, string[] queries) {
        foreach (string word in wordlist) {
            words_perfect.Add(word);

            string wordlow = word.ToLower();
            if (!words_cap.ContainsKey(wordlow)) {
                words_cap.Add(wordlow, word);
            }

            string wordlowDV = Devowel(wordlow);
            if (!words_vow.ContainsKey(wordlowDV)) {
                words_vow.Add(wordlowDV, word);
            }
        }

        string[] ans = new string[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            ans[i] = Solve(queries[i]);
        }
        return ans;
    }

    private string Solve(string query) {
        if (words_perfect.Contains(query)) {
            return query;
        }

        string queryL = query.ToLower();
        if (words_cap.ContainsKey(queryL)) {
            return words_cap[queryL];
        }

        string queryLV = Devowel(queryL);
        if (words_vow.ContainsKey(queryLV)) {
            return words_vow[queryLV];
        }

        return "";
    }

    private string Devowel(string word) {
        System.Text.StringBuilder ans = new System.Text.StringBuilder();
        foreach (char c in word) {
            ans.Append(IsVowel(c) ? '*' : c);
        }
        return ans.ToString();
    }

    private bool IsVowel(char c) {
        c = char.ToLower(c);
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }
}
```

```Go
func spellchecker(wordlist []string, queries []string) []string {
    wordsPerfect := make(map[string]bool)
    wordsCap := make(map[string]string)
    wordsVow := make(map[string]string)

    for _, word := range wordlist {
        wordsPerfect[word] = true
        wordLow := strings.ToLower(word)
        if _, exists := wordsCap[wordLow]; !exists {
            wordsCap[wordLow] = word
        }
        wordLowDV := devowel(wordLow)
        if _, exists := wordsVow[wordLowDV]; !exists {
            wordsVow[wordLowDV] = word
        }
    }

    result := make([]string, len(queries))
    for i, query := range queries {
        result[i] = solve(query, wordsPerfect, wordsCap, wordsVow)
    }
    return result
}

func solve(query string, wordsPerfect map[string]bool, wordsCap, wordsVow map[string]string) string {
    if wordsPerfect[query] {
        return query
    }
    queryLow := strings.ToLower(query)
    if word, exists := wordsCap[queryLow]; exists {
        return word
    }
    queryLowDV := devowel(queryLow)
    if word, exists := wordsVow[queryLowDV]; exists {
        return word
    }

    return ""
}

func devowel(word string) string {
    var sb strings.Builder
    for _, c := range word {
        if isVowel(c) {
            sb.WriteRune('*')
        } else {
            sb.WriteRune(c)
        }
    }
    return sb.String()
}

func isVowel(c rune) bool {
    switch c {
    case 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U':
        return true
    }
    return false
}
```

```C
typedef struct {
    char *key;
    char *val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, const char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, const char *key, const char *val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = strdup(key);
    pEntry->val = strdup(val);
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

char* hashGetItem(HashItem **obj, char *key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr->key);
        free(curr->val);  
        free(curr);             
    }
}

bool isVowel(char c) {
    c = tolower(c);
    return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
}

char* devowel(const char* word) {
    char* ans = (char*)malloc(strlen(word) + 1);
    int i = 0;
    for (; word[i]; i++) {
        ans[i] = isVowel(word[i]) ? '*' : word[i];
    }
    ans[i] = '\0';
    return ans;
}

char* solve(HashItem* words_perfect, HashItem* words_cap, HashItem* words_vow, const char* query) {
    if (hashFindItem(&words_perfect, query)) {
        return strdup(query);
    }

    char* queryL = (char*)malloc(strlen(query) + 1);
    for (int i = 0; query[i]; i++) {
        queryL[i] = tolower(query[i]);
    }
    queryL[strlen(query)] = '\0';
    if (hashFindItem(&words_cap, queryL)) {
        char* result = hashGetItem(&words_cap, queryL);
        free(queryL);
        return strdup(result);
    }

    char* queryLV = devowel(queryL);
    free(queryL);
    if (hashFindItem(&words_vow, queryLV)) {
        char* result = hashGetItem(&words_vow, queryLV);
        free(queryLV);
        return strdup(result);
    }
    free(queryLV);
    return strdup("");
}

char** spellchecker(char** wordlist, int wordlistSize, char** queries, int queriesSize, int* returnSize) {
    HashItem* words_perfect = NULL;
    HashItem* words_cap = NULL;
    HashItem* words_vow = NULL;

    for (int i = 0; i < wordlistSize; i++) {
        char* wordlow = (char*)malloc(strlen(wordlist[i]) + 1);
        for (int j = 0; wordlist[i][j]; j++) {
            wordlow[j] = tolower(wordlist[i][j]);
        }
        wordlow[strlen(wordlist[i])] = '\0';
        char* wordlowDV = devowel(wordlow);
        hashAddItem(&words_perfect, wordlist[i], "");
        hashAddItem(&words_cap, wordlow, wordlist[i]);
        hashAddItem(&words_vow, wordlowDV, wordlist[i]);
        free(wordlow);
        free(wordlowDV);
    }

    char** ans = (char**)malloc(queriesSize * sizeof(char*));
    for (int i = 0; i < queriesSize; i++) {
        ans[i] = solve(words_perfect, words_cap, words_vow, queries[i]);
        printf("s = %s\n", ans[i]);
    }
    *returnSize = queriesSize;
    hashFree(&words_perfect);
    hashFree(&words_cap);
    hashFree(&words_vow);
    return ans;
}
```

```JavaScript
var spellchecker = function(wordlist, queries) {
    const words_perfect = new Set();
    const words_cap = new Map();
    const words_vow = new Map();

    function devowel(word) {
        let ans = '';
        for (const c of word) {
            ans += isVowel(c) ? '*' : c;
        }
        return ans;
    }

    function isVowel(c) {
        return ['a', 'e', 'i', 'o', 'u'].includes(c.toLowerCase());
    }

    function solve(query) {
        if (words_perfect.has(query)) {
            return query;
        }

        const queryL = query.toLowerCase();
        if (words_cap.has(queryL)) {
            return words_cap.get(queryL);
        }

        const queryLV = devowel(queryL);
        if (words_vow.has(queryLV)) {
            return words_vow.get(queryLV);
        }

        return "";
    }

    for (const word of wordlist) {
        words_perfect.add(word);

        const wordlow = word.toLowerCase();
        if (!words_cap.has(wordlow)) {
            words_cap.set(wordlow, word);
        }

        const wordlowDV = devowel(wordlow);
        if (!words_vow.has(wordlowDV)) {
            words_vow.set(wordlowDV, word);
        }
    }

    return queries.map(query => solve(query));
};
```

```TypeScript
function spellchecker(wordlist: string[], queries: string[]): string[] {
    const words_perfect = new Set<string>();
    const words_cap = new Map<string, string>();
    const words_vow = new Map<string, string>();

    function devowel(word: string): string {
        let ans = '';
        for (const c of word) {
            ans += isVowel(c) ? '*' : c;
        }
        return ans;
    }

    function isVowel(c: string): boolean {
        return ['a', 'e', 'i', 'o', 'u'].includes(c.toLowerCase());
    }

    function solve(query: string): string {
        if (words_perfect.has(query)) {
            return query;
        }

        const queryL = query.toLowerCase();
        if (words_cap.has(queryL)) {
            return words_cap.get(queryL)!;
        }

        const queryLV = devowel(queryL);
        if (words_vow.has(queryLV)) {
            return words_vow.get(queryLV)!;
        }

        return "";
    }

    for (const word of wordlist) {
        words_perfect.add(word);

        const wordlow = word.toLowerCase();
        if (!words_cap.has(wordlow)) {
            words_cap.set(wordlow, word);
        }

        const wordlowDV = devowel(wordlow);
        if (!words_vow.has(wordlowDV)) {
            words_vow.set(wordlowDV, word);
        }
    }

    return queries.map(query => solve(query));
}
```

```Rust
use std::collections::{HashMap, HashSet};

impl Solution {
    pub fn spellchecker(wordlist: Vec<String>, queries: Vec<String>) -> Vec<String> {
        let mut words_perfect = HashSet::new();
        let mut words_cap = HashMap::new();
        let mut words_vow = HashMap::new();

        fn devowel(word: &str) -> String {
            word.chars()
                .map(|c| if is_vowel(c) { '*' } else { c })
                .collect()
        }

        fn is_vowel(c: char) -> bool {
            match c.to_ascii_lowercase() {
                'a' | 'e' | 'i' | 'o' | 'u' => true,
                _ => false,
            }
        }

        for word in &wordlist {
            words_perfect.insert(word.clone());
            let wordlow = word.to_ascii_lowercase();
            words_cap.entry(wordlow.clone()).or_insert(word.clone());
            let wordlow_dv = devowel(&wordlow);
            words_vow.entry(wordlow_dv).or_insert(word.clone());
        }

        let mut res = Vec::with_capacity(queries.len());
        for query in queries {
            if words_perfect.contains(&query) {
                res.push(query);
                continue;
            }
            let query_l = query.to_ascii_lowercase();
            if let Some(word) = words_cap.get(&query_l) {
                res.push(word.clone());
                continue;
            }
            let query_lv = devowel(&query_l);
            if let Some(word) = words_vow.get(&query_lv) {
                res.push(word.clone());
                continue;
            }
            res.push(String::new());
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(C)$，其中 $C$ 是 `wordlist` 和 `queries` 中内容的总数。
- 空间复杂度：$O(C)$。
