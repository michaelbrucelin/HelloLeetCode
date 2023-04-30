#### [����һ��ǰ׺��](https://leetcode.cn/problems/stream-of-characters/solutions/2187670/python3javacgo-yi-ti-yi-jie-qian-zhui-sh-79kg/)

���ǿ��Ը��ݳ�ʼ��ʱ���ַ������� $words$ ����ǰ׺����ǰ׺����ÿ���ڵ�����������ԣ�

-   `children`��ָ�� $26$ ����ĸ��ָ�����飬���ڴ洢��ǰ�ڵ���ӽڵ㡣
-   `is_end`����ǵ�ǰ�ڵ��Ƿ�Ϊĳ���ַ����Ľ�β��

�ڹ��캯���У����Ǳ����ַ������� $words$������ÿ���ַ��� $w$�����ǽ��䷴ת������ַ����뵽ǰ׺���У���������󣬽���ǰ�ڵ�� `is_end` ���Ϊ `true`��

�� `query` �����У����ǽ���ǰ�ַ� $c$ ���뵽�ַ����У�Ȼ��Ӻ���ǰ�����ַ���������ÿ���ַ� $c$��������ǰ׺���в����Ƿ������ $c$ Ϊ��β���ַ�����������ڣ����� `true`�����򷵻� `false`��ע�⵽ $words$ �е��ַ������Ȳ����� $200$����˲�ѯʱ���ֻ��Ҫ���� $200$ ���ַ���

```python
class Trie:
    def __init__(self):
        self.children = [None] * 26
        self.is_end = False

    def insert(self, w: str):
        node = self
        for c in w[::-1]:
            idx = ord(c) - ord('a')
            if node.children[idx] is None:
                node.children[idx] = Trie()
            node = node.children[idx]
        node.is_end = True

    def search(self, w: List[str]) -> bool:
        node = self
        for c in w[::-1]:
            idx = ord(c) - ord('a')
            if node.children[idx] is None:
                return False
            node = node.children[idx]
            if node.is_end:
                return True
        return False


class StreamChecker:

    def __init__(self, words: List[str]):
        self.trie = Trie()
        self.cs = []
        self.limit = 201
        for w in words:
            self.trie.insert(w)

    def query(self, letter: str) -> bool:
        self.cs.append(letter)
        return self.trie.search(self.cs[-self.limit:])

# Your StreamChecker object will be instantiated and called as such:
# obj = StreamChecker(words)
# param_1 = obj.query(letter)
```

```java
class Trie {
    Trie[] children = new Trie[26];
    boolean isEnd = false;

    public void insert(String w) {
        Trie node = this;
        for (int i = w.length() - 1; i >= 0; --i) {
            int idx = w.charAt(i) - 'a';
            if (node.children[idx] == null) {
                node.children[idx] = new Trie();
            }
            node = node.children[idx];
        }
        node.isEnd = true;
    }

    public boolean query(StringBuilder s) {
        Trie node = this;
        for (int i = s.length() - 1, j = 0; i >= 0 && j < 201; --i, ++j) {
            int idx = s.charAt(i) - 'a';
            if (node.children[idx] == null) {
                return false;
            }
            node = node.children[idx];
            if (node.isEnd) {
                return true;
            }
        }
        return false;
    }
}

class StreamChecker {
    private StringBuilder sb = new StringBuilder();
    private Trie trie = new Trie();

    public StreamChecker(String[] words) {
        for (String w : words) {
            trie.insert(w);
        }
    }

    public boolean query(char letter) {
        sb.append(letter);
        return trie.query(sb);
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * boolean param_1 = obj.query(letter);
 */
```

```cpp
class Trie {
public:
    vector<Trie*> children;
    bool isEnd;

    Trie()
        : children(26)
        , isEnd(false) {}

    void insert(string& w) {
        Trie* node = this;
        reverse(w.begin(), w.end());
        for (char& c : w) {
            int idx = c - 'a';
            if (!node->children[idx]) {
                node->children[idx] = new Trie();
            }
            node = node->children[idx];
        }
        node->isEnd = true;
    }

    bool search(string& w) {
        Trie* node = this;
        for (int i = w.size() - 1, j = 0; ~i && j < 201; --i, ++j) {
            int idx = w[i] - 'a';
            if (!node->children[idx]) {
                return false;
            }
            node = node->children[idx];
            if (node->isEnd) {
                return true;
            }
        }
        return false;
    }
};

class StreamChecker {
public:
    Trie* trie = new Trie();
    string s;

    StreamChecker(vector<string>& words) {
        for (auto& w : words) {
            trie->insert(w);
        }
    }

    bool query(char letter) {
        s += letter;
        return trie->search(s);
    }
};

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker* obj = new StreamChecker(words);
 * bool param_1 = obj->query(letter);
 */
```

```go
type Trie struct {
    children [26]*Trie
    isEnd    bool
}

func newTrie() Trie {
    return Trie{}
}

func (this *Trie) Insert(word string) {
    node := this
    for i := len(word) - 1; i >= 0; i-- {
        idx := word[i] - 'a'
        if node.children[idx] == nil {
            node.children[idx] = &Trie{}
        }
        node = node.children[idx]
    }
    node.isEnd = true
}

func (this *Trie) Search(word []byte) bool {
    node := this
    for i, j := len(word)-1, 0; i >= 0 && j < 201; i, j = i-1, j+1 {
        idx := word[i] - 'a'
        if node.children[idx] == nil {
            return false
        }
        node = node.children[idx]
        if node.isEnd {
            return true
        }
    }
    return false
}

type StreamChecker struct {
    trie Trie
    s    []byte
}

func Constructor(words []string) StreamChecker {
    trie := newTrie()
    for _, w := range words {
        trie.Insert(w)
    }
    return StreamChecker{trie, []byte{}}
}

func (this *StreamChecker) Query(letter byte) bool {
    this.s = append(this.s, letter)
    return this.trie.Search(this.s)
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * obj := Constructor(words);
 * param_1 := obj.Query(letter);
 */
```

ʱ�临�Ӷȷ��棬���캯����ʱ�临�Ӷ�Ϊ $O(L)$���� `query` ������ʱ�临�Ӷ�Ϊ $O(M)$������ $L$ Ϊ�ַ������� $words$ �������ַ����ĳ���֮�ͣ��� $M$ Ϊ�ַ������� $words$ ���ַ�������󳤶ȡ��ռ临�Ӷ� $O(L)$��
