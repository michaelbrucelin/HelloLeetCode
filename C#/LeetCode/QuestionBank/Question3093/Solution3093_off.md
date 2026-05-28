### [最长公共后缀查询](https://leetcode.cn/problems/longest-common-suffix-queries/solutions/3971813/zui-chang-gong-gong-hou-zhui-cha-xun-by-vdo0f/)

#### 方法一：字典树

**思路与算法**

关于字典树 $Trie$，可以阅读题目 [「实现 $Trie$ (前缀树)」](https://leetcode.cn/problems/implement-trie-prefix-tree/solutions/717239/shi-xian-trie-qian-zhui-shu-by-leetcode-ti500/) 的题解。做本题之前需要对字典树有基本的了解。

在本题中，对于每个待查询的字符串，我们需要找到 $wordsContainer$ 中和它拥有最长公共后缀并且最短、最先出现的那个字符串。我们从头遍历 $wordsContainer$，将其中的每个字符串倒序插入字典树。后面处理每个查询时，在字典树上倒序遍历待查询的字符串，直到无法再继续遍历时，最后停留的节点所表示的后缀就是最长的公共后缀。

但这样还不够，我们需要知道这个后缀在哪个最短的字符串中出现，因此在节点上记录一下当时所有插入的字符串中，经过该节点的、长度最小的那个字符串的下标。由于我们是从前往后遍历的，所以天然满足「最先出现」这一要求。这样一来，在 $Trie$ 树上遍历查询字符串结束时停留的那个节点上记录的下标即为答案。

**代码**

```C++
class Trie {
public:
    Trie(): tot_(0) {
        for (int i = 0; i < N; i++) {
            memset(tr_[i], 0, sizeof(tr_[i]));
            min_len_[i] = INT_MAX;
            idx_[i] = INT_MAX;
        }
    }
    void clear() {
        for (int i = 0; i <= tot_; i++) {
            memset(tr_[i], 0, sizeof(tr_[i]));
            min_len_[i] = INT_MAX;
            idx_[i] = INT_MAX;
        }
        tot_ = 0;
    }
    void insert(const string &s, int idx) {
        int p = 0;
        if (min_len_[p] > s.length()) {
            min_len_[p] = s.length();
            idx_[p] = idx;
        }
        for (auto &ch : s) {
            int c = ch - 'a';
            if (tr_[p][c] == 0) {
                tr_[p][c] = ++tot_;
            }
            p = tr_[p][c];
            if (min_len_[p] > s.length()) {
                min_len_[p] = s.length();
                idx_[p] = idx;
            }
        }
    }
    int query(const string &s) {
        int p = 0;
        for (auto &ch : s) {
            int c = ch - 'a';
            if (tr_[p][c] != 0) {
                p = tr_[p][c];
            } else {
                break;
            }
        }
        return idx_[p];
    }
private:
    static constexpr int N = 500010, M = 26;
    int tot_;
    int tr_[N][M];
    int min_len_[N];
    int idx_[N];
};

Trie tr;

class Solution {
public:
    vector<int> stringIndices(vector<string>& wordsContainer, vector<string>& wordsQuery) {
        tr.clear();
        int n = wordsContainer.size();
        int m = wordsQuery.size();
        for (int i = 0; i < n; i++) {
            string s = wordsContainer[i];
            reverse(s.begin(), s.end());
            tr.insert(s, i);
        }

        vector<int> res(m);
        for (int i = 0; i < m; i++) {
            string s = wordsQuery[i];
            reverse(s.begin(), s.end());
            res[i] = tr.query(s);
        }
        return res;
    }
};
```

```Python
class TrieNode:
    def __init__(self):
        self.children = {}
        self.min_len = float('inf')
        self.idx = float('inf')


class Trie:
    def __init__(self):
        self.root = TrieNode()

    def insert(self, s: str, idx: int):
        node = self.root
        if len(s) < node.min_len:
            node.min_len = len(s)
            node.idx = idx

        for ch in s:
            c = ch
            if c not in node.children:
                node.children[c] = TrieNode()
            node = node.children[c]

            if len(s) < node.min_len:
                node.min_len = len(s)
                node.idx = idx

    def query(self, s: str) -> int:
        node = self.root

        for ch in s:
            if ch in node.children:
                node = node.children[ch]
            else:
                break

        return node.idx


class Solution:
    def stringIndices(self, wordsContainer: List[str], wordsQuery: List[str]) -> List[int]:
        trie = Trie()

        for i, word in enumerate(wordsContainer):
            reversed_word = word[::-1]
            trie.insert(reversed_word, i)

        res = []
        for query in wordsQuery:
            reversed_query = query[::-1]
            res.append(trie.query(reversed_query))

        return res
```

```Rust
struct TrieNode {
    children: [Option<Box<TrieNode>>; 26],
    min_len: usize,
    idx: usize,
}

impl TrieNode {
    fn new() -> Self {
        TrieNode {
            children: Default::default(),
            min_len: usize::MAX,
            idx: usize::MAX,
        }
    }
}

struct Trie {
    root: TrieNode,
}

impl Trie {
    fn new() -> Self {
        Trie {
            root: TrieNode::new(),
        }
    }

    fn insert(&mut self, s: &str, idx: usize) {
        let len = s.len();
        let mut node = &mut self.root;

        if len < node.min_len {
            node.min_len = len;
            node.idx = idx;
        }

        for ch in s.chars() {
            let c = (ch as usize) - ('a' as usize);
            if node.children[c].is_none() {
                node.children[c] = Some(Box::new(TrieNode::new()));
            }
            node = node.children[c].as_mut().unwrap();

            if len < node.min_len {
                node.min_len = len;
                node.idx = idx;
            }
        }
    }

    fn query(&self, s: &str) -> usize {
        let mut node = &self.root;

        for ch in s.chars() {
            let c = (ch as usize) - ('a' as usize);
            match &node.children[c] {
                Some(next) => node = &**next,
                None => break,
            }
        }

        node.idx
    }
}
impl Solution {
    pub fn string_indices(words_container: Vec<String>, words_query: Vec<String>) -> Vec<i32> {
        let mut trie = Trie::new();

        for (i, word) in words_container.iter().enumerate() {
            let reversed: String = word.chars().rev().collect();
            trie.insert(&reversed, i);
        }

        let mut res = Vec::with_capacity(words_query.len());
        for query in words_query.iter() {
            let reversed: String = query.chars().rev().collect();
            res.push(trie.query(&reversed) as i32);
        }

        res
    }
}
```

```Java
class TrieNode {
    TrieNode[] children = new TrieNode[26];
    int minLen = Integer.MAX_VALUE;
    int idx = Integer.MAX_VALUE;

    TrieNode() {
        for (int i = 0; i < 26; i++) {
            children[i] = null;
        }
    }
}

class Trie {
    TrieNode root = new TrieNode();

    void insert(String s, int idx) {
        int len = s.length();
        TrieNode node = root;

        if (len < node.minLen) {
            node.minLen = len;
            node.idx = idx;
        }

        for (char ch : s.toCharArray()) {
            int c = ch - 'a';
            if (node.children[c] == null) {
                node.children[c] = new TrieNode();
            }
            node = node.children[c];

            if (len < node.minLen) {
                node.minLen = len;
                node.idx = idx;
            }
        }
    }

    int query(String s) {
        TrieNode node = root;

        for (char ch : s.toCharArray()) {
            int c = ch - 'a';
            if (node.children[c] != null) {
                node = node.children[c];
            } else {
                break;
            }
        }

        return node.idx;
    }
}

class Solution {
    public int[] stringIndices(String[] wordsContainer, String[] wordsQuery) {
        Trie trie = new Trie();

        for (int i = 0; i < wordsContainer.length; i++) {
            String reversed = new StringBuilder(wordsContainer[i]).reverse().toString();
            trie.insert(reversed, i);
        }

        int[] res = new int[wordsQuery.length];
        for (int i = 0; i < wordsQuery.length; i++) {
            String query = wordsQuery[i];
            String reversed = new StringBuilder(query).reverse().toString();
            res[i] = trie.query(reversed);
        }

        return res;
    }
}
```

```CSharp
public class TrieNode {
    public TrieNode[] Children = new TrieNode[26];
    public int MinLen = int.MaxValue;
    public int Idx = int.MaxValue;

    public TrieNode() {
        for (int i = 0; i < 26; i++) {
            Children[i] = null;
        }
    }
}

public class Trie {
    public TrieNode Root = new TrieNode();

    public void Insert(string s, int idx) {
        int len = s.Length;
        TrieNode node = Root;
        if (len < node.MinLen) {
            node.MinLen = len;
            node.Idx = idx;
        }
        foreach (char ch in s) {
            int c = ch - 'a';
            if (node.Children[c] == null) {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];

            if (len < node.MinLen) {
                node.MinLen = len;
                node.Idx = idx;
            }
        }
    }

    public int Query(string s) {
        TrieNode node = Root;

        foreach (char ch in s) {
            int c = ch - 'a';
            if (node.Children[c] != null) {
                node = node.Children[c];
            } else {
                break;
            }
        }

        return node.Idx;
    }
}

public class Solution {
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery) {
        Trie trie = new Trie();

        for (int i = 0; i < wordsContainer.Length; i++) {
            char[] chars = wordsContainer[i].ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);
            trie.Insert(reversed, i);
        }

        int[] res = new int[wordsQuery.Length];
        for (int i = 0; i < wordsQuery.Length; i++) {
            char[] chars = wordsQuery[i].ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);
            res[i] = trie.Query(reversed);
        }

        return res;
    }
}
```

```Go
func stringIndices(wordsContainer []string, wordsQuery []string) []int {
    trie := NewTrie()
    for i, word := range wordsContainer {
        reversed := reverseString(word)
        trie.Insert(reversed, i)
    }

    res := make([]int, len(wordsQuery))
    for i, query := range wordsQuery {
        reversed := reverseString(query)
        res[i] = trie.Query(reversed)
    }

    return res
}

func reverseString(s string) string {
    runes := []rune(s)
    for i, j := 0, len(runes)-1; i < j; i, j = i+1, j-1 {
        runes[i], runes[j] = runes[j], runes[i]
    }
    return string(runes)
}

type TrieNode struct {
    children [26]*TrieNode
    minLen   int
    idx      int
}

func NewTrieNode() *TrieNode {
    return &TrieNode{
        children: [26]*TrieNode{},
        minLen:   math.MaxInt32,
        idx:      math.MaxInt32,
    }
}

type Trie struct {
    root *TrieNode
}

func NewTrie() *Trie {
    return &Trie{root: NewTrieNode()}
}

func (t *Trie) Insert(s string, idx int) {
    length := len(s)
    node := t.root

    if length < node.minLen {
        node.minLen = length
        node.idx = idx
    }

    for i := 0; i < length; i++ {
        c := s[i] - 'a'
        if node.children[c] == nil {
            node.children[c] = NewTrieNode()
        }
        node = node.children[c]

        if length < node.minLen {
            node.minLen = length
            node.idx = idx
        }
    }
}

func (t *Trie) Query(s string) int {
    node := t.root

    for i := 0; i < len(s); i++ {
        c := s[i] - 'a'
        if node.children[c] != nil {
            node = node.children[c]
        } else {
            break
        }
    }

    return node.idx
}
```

```C
#define ALPHABET_SIZE 26

typedef struct TrieNode {
    struct TrieNode* children[ALPHABET_SIZE];
    int minLen;
    int idx;
} TrieNode;

TrieNode* createTrieNode() {
    TrieNode* node = (TrieNode*)malloc(sizeof(TrieNode));
    for (int i = 0; i < ALPHABET_SIZE; i++) {
        node->children[i] = NULL;
    }
    node->minLen = INT_MAX;
    node->idx = INT_MAX;
    return node;
}

void insert(TrieNode* root, const char* s, int idx) {
    int len = strlen(s);
    TrieNode* node = root;

    if (len < node->minLen) {
        node->minLen = len;
        node->idx = idx;
    }

    for (int i = 0; i < len; i++) {
        int c = s[i] - 'a';
        if (node->children[c] == NULL) {
            node->children[c] = createTrieNode();
        }
        node = node->children[c];
        if (len < node->minLen) {
            node->minLen = len;
            node->idx = idx;
        }
    }
}

int query(TrieNode* root, const char* s) {
    TrieNode* node = root;
    int len = strlen(s);
    for (int i = 0; i < len; i++) {
        int c = s[i] - 'a';
        if (node->children[c] != NULL) {
            node = node->children[c];
        } else {
            break;
        }
    }

    return node->idx;
}

void freeTrie(TrieNode *root) {
    for (int i = 0; i < ALPHABET_SIZE; i++) {
        if (root->children[i]) {
            freeTrie(root->children[i]);
        }
    }
    free(root);
}

void reverseString(char* str) {
    int len = strlen(str);
    for (int i = 0, j = len - 1; i < j; i++, j--) {
        char ch = str[i];
        str[i] = str[j];
        str[j] = ch;
    }
}

int* stringIndices(char** wordsContainer, int containerSize, char** wordsQuery, int querySize, int* returnSize) {
    TrieNode* root = createTrieNode();
    for (int i = 0; i < containerSize; i++) {
        reverseString(wordsContainer[i]);
        insert(root, wordsContainer[i], i);
    }

    int* res = (int*)malloc(querySize * sizeof(int));
    for (int i = 0; i < querySize; i++) {
        reverseString(wordsQuery[i]);
        res[i] = query(root, wordsQuery[i]);
    }

    *returnSize = querySize;
    freeTrie(root);

    return res;
}
```

```JavaScript
class TrieNode {
    constructor() {
        this.children = new Array(26);
        for (let i = 0; i < 26; i++) {
            this.children[i] = null;
        }
        this.minLen = Infinity;
        this.idx = Infinity;
    }
}

class Trie {
    constructor() {
        this.root = new TrieNode();
    }

    insert(s, idx) {
        const len = s.length;
        let node = this.root;

        if (len < node.minLen) {
            node.minLen = len;
            node.idx = idx;
        }

        for (let i = 0; i < len; i++) {
            const c = s.charCodeAt(i) - 97;
            if (node.children[c] === null) {
                node.children[c] = new TrieNode();
            }
            node = node.children[c];

            if (len < node.minLen) {
                node.minLen = len;
                node.idx = idx;
            }
        }
    }

    query(s) {
        let node = this.root;
        const len = s.length;

        for (let i = 0; i < len; i++) {
            const c = s.charCodeAt(i) - 97;
            if (node.children[c] !== null) {
                node = node.children[c];
            } else {
                break;
            }
        }

        return node.idx;
    }
}

function stringIndices(wordsContainer, wordsQuery) {
    const trie = new Trie();

    for (let i = 0; i < wordsContainer.length; i++) {
        const reversed = wordsContainer[i].split('').reverse().join('');
        trie.insert(reversed, i);
    }

    const res = [];
    for (const query of wordsQuery) {
        const reversed = query.split('').reverse().join('');
        res.push(trie.query(reversed));
    }

    return res;
}
```

```TypeScript
class TrieNode {
    children: (TrieNode | null)[] = new Array(26);
    minLen: number = Infinity;
    idx: number = Infinity;

    constructor() {
        for (let i = 0; i < 26; i++) {
            this.children[i] = null;
        }
    }
}

class Trie {
    root: TrieNode = new TrieNode();

    insert(s: string, idx: number): void {
        const len = s.length;
        let node = this.root;

        if (len < node.minLen) {
            node.minLen = len;
            node.idx = idx;
        }

        for (let i = 0; i < len; i++) {
            const c = s.charCodeAt(i) - 97;
            if (node.children[c] === null) {
                node.children[c] = new TrieNode();
            }
            node = node.children[c]!;

            if (len < node.minLen) {
                node.minLen = len;
                node.idx = idx;
            }
        }
    }

    query(s: string): number {
        let node = this.root;
        const len = s.length;

        for (let i = 0; i < len; i++) {
            const c = s.charCodeAt(i) - 97;
            if (node.children[c] !== null) {
                node = node.children[c]!;
            } else {
                break;
            }
        }

        return node.idx;
    }
}

function stringIndices(wordsContainer: string[], wordsQuery: string[]): number[] {
    const trie = new Trie();

    for (let i = 0; i < wordsContainer.length; i++) {
        const reversed = wordsContainer[i].split('').reverse().join('');
        trie.insert(reversed, i);
    }

    const res: number[] = [];
    for (const query of wordsQuery) {
        const reversed = query.split('').reverse().join('');
        res.push(trie.query(reversed));
    }

    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(N+M)$，其中 $N$ 是 $wordsContainer$ 中所有字符串的长度之和，$M$ 是 $wordsQuery$ 中所有字符串的长度之和。
- 空间复杂度：$O(N)$，其中 $N$ 是 $wordsContainer$ 中所有字符串的长度之和。实际上每个节点有 $26$ 个指向子节点的指针，在计算实际占用的内存时，需要考虑这一因素，但由于属于常数项，不计入渐进复杂度。
