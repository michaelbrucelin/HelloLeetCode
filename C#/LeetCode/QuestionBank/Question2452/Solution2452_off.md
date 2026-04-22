### [距离字典两次编辑以内的单词](https://leetcode.cn/problems/words-within-two-edits-of-dictionary/solutions/3950450/ju-chi-zi-dian-liang-ci-bian-ji-yi-nei-d-d2)

#### 方法一：暴力

**思路与算法**

注意到题目的数据范围很小，我们可以直接实施暴力算法。

对于 $queries$ 中的每个字符串 $queries[i]$，查找 $dictionary$ 中是否存在一个字符串，使得两个字符串中最多只有两个字符不同（即汉明距离小于等于 $2$），如果存在，就将其添加到答案中。由于添加的顺序与遍历 $queries$ 的顺序一致，我们不需要对答案的顺序进行特殊处理。

**代码**

```C++
class Solution {
public:
    vector<string> twoEditWords(vector<string>& queries,
                                vector<string>& dictionary) {
        vector<string> ans;
        for (string query : queries) {
            for (string s : dictionary) {
                int dis = 0;
                for (int i = 0; i < query.size(); i++) {
                    if (query[i] != s[i]) {
                        ++dis;
                    }
                }
                if (dis <= 2) {
                    ans.push_back(query);
                    break;
                }
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> twoEditWords(String[] queries, String[] dictionary) {
        List<String> ans = new ArrayList<>();
        for (String query : queries) {
            for (String s : dictionary) {
                int dis = 0;
                for (int i = 0; i < query.length(); i++) {
                    if (query.charAt(i) != s.charAt(i)) {
                        dis++;
                    }
                }
                if (dis <= 2) {
                    ans.add(query);
                    break;
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<string> TwoEditWords(string[] queries, string[] dictionary) {
        var ans = new List<string>();
        foreach (var query in queries) {
            foreach (var s in dictionary) {
                int dis = 0;
                for (int i = 0; i < query.Length; i++) {
                    if (query[i] != s[i]) {
                        dis++;
                    }
                }
                if (dis <= 2) {
                    ans.Add(query);
                    break;
                }
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def twoEditWords(self, queries, dictionary):
        ans = []
        for query in queries:
            for s in dictionary:
                dis = 0
                for i in range(len(query)):
                    if query[i] != s[i]:
                        dis += 1
                if dis <= 2:
                    ans.append(query)
                    break
        return ans
```

```C
char** twoEditWords(char** queries, int queriesSize,
                    char** dictionary, int dictionarySize,
                    int* returnSize) {
    char** ans = (char**)malloc(sizeof(char*) * queriesSize);
    int cnt = 0;

    for (int i = 0; i < queriesSize; i++) {
        char* query = queries[i];
        for (int j = 0; j < dictionarySize; j++) {
            char* s = dictionary[j];
            int dis = 0;
            for (int k = 0; query[k] != '\0'; k++) {
                if (query[k] != s[k]) {
                    dis++;
                }
            }
            if (dis <= 2) {
                ans[cnt++] = query;
                break;
            }
        }
    }

    *returnSize = cnt;
    return ans;
}
```

```Go
func twoEditWords(queries []string, dictionary []string) []string {
    var ans []string
    for _, query := range queries {
        for _, s := range dictionary {
            dis := 0
            for i := 0; i < len(query); i++ {
                if query[i] != s[i] {
                    dis++
                }
            }
            if dis <= 2 {
                ans = append(ans, query)
                break
            }
        }
    }
    return ans
}
```

```JavaScript
var twoEditWords = function(queries, dictionary) {
    const ans = [];
    for (const query of queries) {
        for (const s of dictionary) {
            let dis = 0;
            for (let i = 0; i < query.length; i++) {
                if (query[i] !== s[i]) {
                    dis++;
                }
            }
            if (dis <= 2) {
                ans.push(query);
                break;
            }
        }
    }
    return ans;
};
```

```TypeScript
function twoEditWords(queries: string[], dictionary: string[]): string[] {
    const ans: string[] = [];
    for (const query of queries) {
        for (const s of dictionary) {
            let dis = 0;
            for (let i = 0; i < query.length; i++) {
                if (query[i] !== s[i]) {
                    dis++;
                }
            }
            if (dis <= 2) {
                ans.push(query);
                break;
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn two_edit_words(queries: Vec<String>, dictionary: Vec<String>) -> Vec<String> {
        let mut ans = Vec::new();

        for query in &queries {
            for s in &dictionary {
                let mut dis = 0;
                for (c1, c2) in query.chars().zip(s.chars()) {
                    if c1 != c2 {
                        dis += 1;
                    }
                }
                if dis <= 2 {
                    ans.push(query.clone());
                    break;
                }
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(qkn)$，其中 $q$ 为 $queries$ 的长度，$k$ 为 $dictionary$ 的长度，$n$ 为 $queries[i]$ 的长度。我们需要对每一个 $queries[i]$ 遍历一次 $dictionary$，然后比较两个字符串。
- 空间复杂度：$O(1)$，仅使用常数个变量。返回数组不计入空间复杂度。

#### 方法二：字典树

**思路与算法**

我们可以将 $dictionary$ 中的所有单词插入字典树，对每个 $queries[i]$ 做深度优先搜索，在过程中维护修改次数 $cnt$，从而实现在字典树上进行「最多 $2$ 次修改」的匹配搜索。

定义状态 $dfs(i,node,cnt)$，其中 $i$ 表示当前匹配到第 $i$ 个字符，$node$ 表示当前所在字典树的节点，$cnt$ 表示已修改 $cnt$ 次。在字典树上进行查找，对于第 $i$ 个字符 $query[i]$：

1. 如果字典树中存在 $node.children[query[i]]$，不进行修改，下一步搜索状态 $dfs(i+1,node.children[query[i]],cnt)$。
2. 如果字典树中不存在 $node.children[query[i]]$，且 $cnt<2$，进行修改，即枚举所有 $c\ne query[i]$，下一步搜索状态 $dfs(i+1,node.children[c],cnt+1)$。

搜索过程中，我们可以进行一些剪枝，比如某条路径找到合法解就提前终止。

**代码**

```C++
struct TrieNode {
    TrieNode* child[26];
    bool isEnd;
    TrieNode() {
        memset(child, 0, sizeof(child));
        isEnd = false;
    }
};

class Solution {
public:
    TrieNode* root = new TrieNode();

    void insert(string& word) {
        TrieNode* node = root;
        for (char c : word) {
            int idx = c - 'a';
            if (!node->child[idx])
                node->child[idx] = new TrieNode();
            node = node->child[idx];
        }
        node->isEnd = true;
    }

    bool dfs(string& word, int i, TrieNode* node, int cnt) {
        if (cnt > 2)
            return false;
        if (!node)
            return false;

        if (i == word.size()) {
            return node->isEnd;
        }

        int idx = word[i] - 'a';

        // 不修改
        if (node->child[idx]) {
            if (dfs(word, i + 1, node->child[idx], cnt))
                return true;
        }

        // 修改
        if (cnt < 2) {
            for (int c = 0; c < 26; c++) {
                if (c == idx)
                    continue;
                if (node->child[c]) {
                    if (dfs(word, i + 1, node->child[c], cnt + 1))
                        return true;
                }
            }
        }

        return false;
    }

    vector<string> twoEditWords(vector<string>& queries,
                                vector<string>& dictionary) {
        for (auto& w : dictionary)
            insert(w);

        vector<string> res;
        for (auto& q : queries) {
            if (dfs(q, 0, root, 0)) {
                res.push_back(q);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    static class TrieNode {
        TrieNode[] child = new TrieNode[26];
        boolean isEnd = false;
    }

    TrieNode root = new TrieNode();

    void insert(String word) {
        TrieNode node = root;
        for (char c : word.toCharArray()) {
            int idx = c - 'a';
            if (node.child[idx] == null)
                node.child[idx] = new TrieNode();
            node = node.child[idx];
        }
        node.isEnd = true;
    }

    boolean dfs(String word, int i, TrieNode node, int cnt) {
        if (cnt > 2 || node == null)
            return false;

        if (i == word.length())
            return node.isEnd;

        int idx = word.charAt(i) - 'a';

        // 不修改
        if (node.child[idx] != null) {
            if (dfs(word, i + 1, node.child[idx], cnt))
                return true;
        }

        // 修改
        if (cnt < 2) {
            for (int c = 0; c < 26; c++) {
                if (c == idx)
                    continue;
                if (node.child[c] != null) {
                    if (dfs(word, i + 1, node.child[c], cnt + 1))
                        return true;
                }
            }
        }

        return false;
    }

    public List<String> twoEditWords(String[] queries, String[] dictionary) {
        for (String w : dictionary)
            insert(w);

        List<String> res = new ArrayList<>();
        for (String q : queries) {
            if (dfs(q, 0, root, 0)) {
                res.add(q);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    class TrieNode {
        public TrieNode[] child = new TrieNode[26];
        public bool isEnd = false;
    }

    TrieNode root = new TrieNode();

    void Insert(string word) {
        var node = root;
        foreach (char c in word) {
            int idx = c - 'a';
            if (node.child[idx] == null)
                node.child[idx] = new TrieNode();
            node = node.child[idx];
        }
        node.isEnd = true;
    }

    bool Dfs(string word, int i, TrieNode node, int cnt) {
        if (cnt > 2 || node == null)
            return false;

        if (i == word.Length)
            return node.isEnd;

        int idx = word[i] - 'a';

        // 不修改
        if (node.child[idx] != null) {
            if (Dfs(word, i + 1, node.child[idx], cnt))
                return true;
        }

        // 修改
        if (cnt < 2) {
            for (int c = 0; c < 26; c++) {
                if (c == idx) continue;
                if (node.child[c] != null) {
                    if (Dfs(word, i + 1, node.child[c], cnt + 1))
                        return true;
                }
            }
        }

        return false;
    }

    public IList<string> TwoEditWords(string[] queries, string[] dictionary) {
        foreach (var w in dictionary)
            Insert(w);

        var res = new List<string>();
        foreach (var q in queries) {
            if (Dfs(q, 0, root, 0)) {
                res.Add(q);
            }
        }
        return res;
    }
}
```

```Python
class TrieNode:
    def __init__(self):
        self.child = [None] * 26
        self.isEnd = False


class Solution:
    def __init__(self):
        self.root = TrieNode()

    def insert(self, word):
        node = self.root
        for c in word:
            idx = ord(c) - ord('a')
            if not node.child[idx]:
                node.child[idx] = TrieNode()
            node = node.child[idx]
        node.isEnd = True

    def dfs(self, word, i, node, cnt):
        if cnt > 2 or not node:
            return False

        if i == len(word):
            return node.isEnd

        idx = ord(word[i]) - ord('a')

        # 不修改
        if node.child[idx] and self.dfs(word, i + 1, node.child[idx], cnt):
            return True

        # 修改
        if cnt < 2:
            for c in range(26):
                if c == idx:
                    continue
                if node.child[c] and self.dfs(word, i + 1, node.child[c], cnt + 1):
                    return True

        return False

    def twoEditWords(self, queries, dictionary):
        for w in dictionary:
            self.insert(w)

        res = []
        for q in queries:
            if self.dfs(q, 0, self.root, 0):
                res.append(q)
        return res
```

```C
typedef struct TrieNode {
    struct TrieNode* child[26];
    bool isEnd;
} TrieNode;

TrieNode* newNode() {
    TrieNode* node = (TrieNode*)malloc(sizeof(TrieNode));
    memset(node->child, 0, sizeof(node->child));
    node->isEnd = false;
    return node;
}

void insert(TrieNode* root, char* word) {
    TrieNode* node = root;
    for (int i = 0; word[i]; i++) {
        int idx = word[i] - 'a';
        if (!node->child[idx])
            node->child[idx] = newNode();
        node = node->child[idx];
    }
    node->isEnd = true;
}

bool dfs(char* word, int i, TrieNode* node, int cnt) {
    if (cnt > 2 || !node)
        return false;

    if (word[i] == '\0')
        return node->isEnd;

    int idx = word[i] - 'a';

    // 不修改
    if (node->child[idx] && dfs(word, i + 1, node->child[idx], cnt))
        return true;

    // 修改
    if (cnt < 2) {
        for (int c = 0; c < 26; c++) {
            if (c == idx) continue;
            if (node->child[c] && dfs(word, i + 1, node->child[c], cnt + 1))
                return true;
        }
    }

    return false;
}

char** twoEditWords(char** queries, int queriesSize,
                    char** dictionary, int dictionarySize,
                    int* returnSize) {
    TrieNode* root = newNode();
    for (int i = 0; i < dictionarySize; i++)
        insert(root, dictionary[i]);

    char** res = (char**)malloc(sizeof(char*) * queriesSize);
    int cnt = 0;

    for (int i = 0; i < queriesSize; i++) {
        if (dfs(queries[i], 0, root, 0)) {
            res[cnt++] = queries[i];
        }
    }

    *returnSize = cnt;
    return res;
}
```

```Go
type TrieNode struct {
    child [26]*TrieNode
    isEnd bool
}

var root = &TrieNode{}

func insert(word string) {
    node := root
    for _, c := range word {
        idx := c - 'a'
        if node.child[idx] == nil {
            node.child[idx] = &TrieNode{}
        }
        node = node.child[idx]
    }
    node.isEnd = true
}

func dfs(word string, i int, node *TrieNode, cnt int) bool {
    if cnt > 2 || node == nil {
        return false
    }

    if i == len(word) {
        return node.isEnd
    }

    idx := word[i] - 'a'

    // 不修改
    if node.child[idx] != nil && dfs(word, i+1, node.child[idx], cnt) {
        return true
    }

    // 修改
    if cnt < 2 {
        for c := 0; c < 26; c++ {
            if byte(c) == idx {
                continue
            }
            if node.child[c] != nil && dfs(word, i+1, node.child[c], cnt+1) {
                return true
            }
        }
    }

    return false
}

func twoEditWords(queries []string, dictionary []string) []string {
    root = &TrieNode{}
    for _, w := range dictionary {
        insert(w)
    }

    var res []string
    for _, q := range queries {
        if dfs(q, 0, root, 0) {
            res = append(res, q)
        }
    }
    return res
}
```

```JavaScript
class TrieNode {
    constructor() {
        this.child = new Array(26).fill(null);
        this.isEnd = false;
    }
}

var twoEditWords = function(queries, dictionary) {
    const root = new TrieNode();

    function insert(word) {
        let node = root;
        for (let c of word) {
            let idx = c.charCodeAt(0) - 97;
            if (!node.child[idx]) node.child[idx] = new TrieNode();
            node = node.child[idx];
        }
        node.isEnd = true;
    }

    function dfs(word, i, node, cnt) {
        if (cnt > 2 || !node) return false;
        if (i === word.length) return node.isEnd;

        let idx = word.charCodeAt(i) - 97;

        // 修改
        if (node.child[idx] && dfs(word, i + 1, node.child[idx], cnt))
            return true;

        // 不修改
        if (cnt < 2) {
            for (let c = 0; c < 26; c++) {
                if (c === idx) continue;
                if (node.child[c] && dfs(word, i + 1, node.child[c], cnt + 1))
                    return true;
            }
        }

        return false;
    }

    for (let w of dictionary) insert(w);

    const res = [];
    for (let q of queries) {
        if (dfs(q, 0, root, 0)) res.push(q);
    }

    return res;
};
```

```TypeScript
class TrieNode {
    child: (TrieNode | null)[] = new Array(26).fill(null);
    isEnd: boolean = false;
}

function twoEditWords(queries: string[], dictionary: string[]): string[] {
    const root = new TrieNode();

    function insert(word: string) {
        let node = root;
        for (const c of word) {
            const idx = c.charCodeAt(0) - 97;
            if (!node.child[idx]) node.child[idx] = new TrieNode();
            node = node.child[idx]!;
        }
        node.isEnd = true;
    }

    function dfs(word: string, i: number, node: TrieNode | null, cnt: number): boolean {
        if (cnt > 2 || !node) return false;
        if (i === word.length) return node.isEnd;

        const idx = word.charCodeAt(i) - 97;

        // 不修改
        if (node.child[idx] && dfs(word, i + 1, node.child[idx], cnt))
            return true;

        // 修改
        if (cnt < 2) {
            for (let c = 0; c < 26; c++) {
                if (c === idx) continue;
                if (node.child[c] && dfs(word, i + 1, node.child[c], cnt + 1))
                    return true;
            }
        }

        return false;
    }

    for (const w of dictionary) insert(w);

    const res: string[] = [];
    for (const q of queries) {
        if (dfs(q, 0, root, 0)) res.push(q);
    }

    return res;
}
```

```Rust
struct TrieNode {
    child: Vec<Option<Box<TrieNode>>>,
    is_end: bool,
}

impl TrieNode {
    fn new() -> Self {
        let mut child = Vec::with_capacity(26);
        for _ in 0..26 {
            child.push(None);
        }

        Self {
            child,
            is_end: false,
        }
    }
}

impl Solution {
    fn insert(root: &mut TrieNode, word: &str) {
        let mut node = root;
        for c in word.chars() {
            let idx = (c as u8 - b'a') as usize;
            if node.child[idx].is_none() {
                node.child[idx] = Some(Box::new(TrieNode::new()));
            }
            node = node.child[idx].as_mut().unwrap();
        }
        node.is_end = true;
    }

    fn dfs(word: &[u8], i: usize, node: &TrieNode, cnt: i32) -> bool {
        if cnt > 2 {
            return false;
        }
        if i == word.len() {
            return node.is_end;
        }

        let idx = (word[i] - b'a') as usize;

        // 不修改
        if let Some(ref next) = node.child[idx] {
            if Self::dfs(word, i + 1, next, cnt) {
                return true;
            }
        }

        // 修改
        if cnt < 2 {
            for c in 0..26 {
                if c == idx {
                    continue;
                }
                if let Some(ref next) = node.child[c] {
                    if Self::dfs(word, i + 1, next, cnt + 1) {
                        return true;
                    }
                }
            }
        }

        false
    }

    pub fn two_edit_words(queries: Vec<String>, dictionary: Vec<String>) -> Vec<String> {
        let mut root = TrieNode::new();

        for w in &dictionary {
            Self::insert(&mut root, w);
        }

        let mut res = vec![];
        for q in &queries {
            if Self::dfs(q.as_bytes(), 0, &root, 0) {
                res.push(q.clone());
            }
        }

        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k\cdot n+q\cdot n^2\cdot 25^2)$，其中 $q$ 为 $queries$ 的长度，$k$ 为 $dictionary$ 的长度，$n$ 为 $queries[i]$ 的长度。建字典树需要 $O(kn)$，查询时对于每一个字母都有修改和不修改两种选择，选择修改位置有 $C_n^2=n^2$ 种选择，其中不修改有 $1$ 条分支，修改有 $25$ 条分支，最多修改两次，因此有 $25^2$ 种选择。
- 空间复杂度：$O(kn)$。即为字典树所占用的空间。
