#### [����һ��AC �Զ���](https://leetcode.cn/problems/stream-of-characters/solutions/2186583/zi-fu-liu-by-leetcode-solution-b9yo/)

**˼·**

������Ҫ�õ� AC �Զ��������ݽṹ��������Բ��ա�[AC �Զ���](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fstring%2Fac-automaton%2F)����

������Ҫ���ַ������� $words$ �еĵ��ʹ���һ���ֵ������ֵ����Ľڵ� $TrieNode$ ������Ԫ�أ�

1.  $children$������Ϊ $26$ �����飬Ԫ�ؾ�Ϊ $TrieNode$��
2.  $isEnd$������ֵ����ʾ��ǰ�ڵ��Ƿ�Ϊһ�����ʵĽ�β��
3.  $fail$��ʧ��ָ�룬���Ļ�����ᵽ��

�����ֵ����Ĳ���Ƚϳ��棬�� $word$ һһ�����ֵ�����������β�ڵ�� $isEnd$ ��Ϊ $true$��������Ҫ��ס���ǣ���ʱ�ֵ����е�ÿһ���ǿսڵ㣬����ʾ�ַ������� $words$ ��ĳ��ǰ׺���ҽڵ����Ⱦ��Ǹ�ǰ׺�ĳ��ȡ�

��������Ҫ����ÿ���ǿսڵ��ʧ��ָ�롣ʧ��ָ��Ķ����ǣ����Ա�ʾ��ǰ�ڵ�����׺�Ľڵ㣬����������£���ǰ�ڵ��ܱ�ʾ�ַ������� $words$ ��ĳ��ǰ׺ $pre_1$��������Ҫ�ҵ��ֵ����е���һ���ڵ㣬�Ҹýڵ��ʾ��ǰ׺ $pre_2$���� $pre_1$ ��һ����׺�������������ֵ������ҵ�����ĺ�׺����ô��θ������нڵ��ʧ��ָ���أ����ȣ�����أ����ǽ����ڵ�����и��ڵ�ķǿ��ӽڵ��ʧ��ָ��ָ����ڵ㣬Ȼ��˼����μ��������ǿսڵ��ʧ��ָ�롣

������Ҫ����ĳ���ڵ� $u$ ��ʧ��ָ��ʱ���������б� $u$ ǳ�Ľڵ��ʧ��ָ���Ѿ�������ϣ��� $u$ �ĸ��ڵ�Ϊ $p$���ڵ� $p$ �����ַ� $c$ ָ��ڵ� $u$�����ڵ� $u$ �����ǰ׺ $pre_u$ �Ƚڵ� $p$ �����ǰ׺ $pre_p$ ��һ���ַ� $c$����������Ҫ���� $p.fail$ �����ַ� $c$ ָ��Ľڵ��Ƿ�ǿգ�����ǿգ����Ǿ��ҵ� $u$ ��ʧ��ڵ㣬���Ϊ�գ�������Ҫ�������� $p.fail.fail$��ֱ��������ʧ�������ҵ�һ���ڵ㣬�������ַ� $c$ ָ����ӽڵ�ǿգ�����������ʧ�����ϲ��Ͽ���Ĺ����У����տ��쵽�˸��ڵ㣬��ʱ���ǽ� $u$ ��ʧ��ڵ�ָ����ڵ㡣����һ�������ǿ��Ը��ݹ�����������Ĺ��̣���������зǿսڵ��ʧ��ڵ㡣

��ˣ����ǾͿ���������ֵ�����ƥ���׺�������ˡ���ʼ��ʱ������һ��ָ�� $temp$ ָ����ڵ㣬ÿ����һ���ַ� $c$��$temp$ ����ͼ�����ַ� $c$ �ƶ����ӽڵ㣬����ӽڵ�Ϊ�գ�����ʧ�����ϲ�ͣ�ƶ���ֱ���ҵ�һ���ڵ㣬�������ַ� $c$ ָ����ӽڵ�ǿգ���ʱ���ӽڵ��ʾ��ǰ׺���ǿ���ƥ�䵽��������������׺��ע���ʱ�����������̷��ؽ������Ҫ�������ӽڵ��ʧ�����ϵ����нڵ㣬����нڵ�� $isEnd$ ֵΪ $true$���򷵻� $true$�����򷵻� $false$��

ע�⵽��ʱ�Ѿ����Խ��������ˣ����Ǽ���ÿ���ڵ��ʧ��ڵ�͵��� $query$ ��ʱ�临�Ӷ���Ȼ�ϴ��������£���Ҫ��������ʧ����·���ܵõ��������ˣ������ڹ����������ʱ�������������Ż���

1.  ���ڵ� $p$ �������ַ� $c$ ָ����ӽڵ� $u$ Ϊ��ʱ������ָ�� $p.fail$ �����ַ� $c$ ָ����ӽڵ� vvv������������·��ѹ����˼·��ʹ��ÿ�����ӽڵ����ն���ָ��һ���ǿսڵ㣬�Ӷ�ʡȥ����ʧ����·�ϲ�ͣ����Ĺ��̡�
2.  ����������������У��ڵ� $u$ ������ʱ���� $u.isEnd$ ����Ϊ $u.isEnd ~ \| ~ u.fail.isEndu.isEnd$������ÿ���ڵ�� $isEnd$ �����Ķ���ͱ�Ϊ�����Լ������Լ���ĳһ��׺��ƥ���ַ��������ĳ���ַ���ʱΪ $true$������һ����$query$ ʱҲ����Ҫ����ʧ����·�ˡ�

**����**

```python
class StreamChecker:

    def __init__(self, words: List[str]):
        self.root = TrieNode()
        for word in words:
            cur = self.root
            for char in word:
                idx = ord(char) - ord('a')
                if not cur.children[idx]:
                    cur.children[idx] = TrieNode()
                cur = cur.children[idx]
            cur.isEnd = True
        
        self.root.fail = self.root
        q = deque()
        for i in range(26):
            if self.root.children[i]:
                self.root.children[i].fail = self.root
                q.append(self.root.children[i])
            else:
                self.root.children[i] = self.root
        while q:
            node = q.popleft()
            node.isEnd = node.isEnd or node.fail.isEnd
            for i in range(26):
                if node.children[i]:
                    node.children[i].fail = node.fail.children[i]
                    q.append(node.children[i])
                else:
                    node.children[i] = node.fail.children[i]

        self.temp = self.root
            
    def query(self, letter: str) -> bool:
        self.temp = self.temp.children[ord(letter) - ord('a')]
        return self.temp.isEnd

class TrieNode:
    def __init__(self):
        self.children = [None] * 26
        self.isEnd = False
        self.fail = None
```

```java
class StreamChecker {
    TrieNode root;
    TrieNode temp;

    public StreamChecker(String[] words) {
        root = new TrieNode();
        for (String word : words) {
            TrieNode cur = root;
            for (int i = 0; i < word.length(); i++) {
                int index = word.charAt(i) - 'a';
                if (cur.getChild(index) == null) {
                    cur.setChild(index, new TrieNode());
                }
                cur = cur.getChild(index);
            }
            cur.setIsEnd(true);
        }
        root.setFail(root);
        Queue<TrieNode> q = new LinkedList<>();
        for (int i = 0; i < 26; i++) {
            if(root.getChild(i) != null) {
                root.getChild(i).setFail(root);
                q.add(root.getChild(i));
            } else {
                root.setChild(i, root);
            }
        }
        while (!q.isEmpty()) {
            TrieNode node = q.poll();
            node.setIsEnd(node.getIsEnd() || node.getFail().getIsEnd());
            for (int i = 0; i < 26; i++) {
                if(node.getChild(i) != null) {
                    node.getChild(i).setFail(node.getFail().getChild(i));
                    q.offer(node.getChild(i));
                } else {
                    node.setChild(i, node.getFail().getChild(i));
                }
            }
        }

        temp = root;
    }

    public boolean query(char letter) {
        temp = temp.getChild(letter - 'a');
        return temp.getIsEnd();
    }
}

class TrieNode {
    TrieNode[] children;
    boolean isEnd;
    TrieNode fail;

    public TrieNode() {
        children = new TrieNode[26];
    }

    public TrieNode getChild(int index) {
        return children[index];
    }

    public void setChild(int index, TrieNode node) {
        children[index] = node;
    }

    public boolean getIsEnd() {
        return isEnd;
    }

    public void setIsEnd(boolean b) {
        isEnd = b;
    }

    public TrieNode getFail() {
        return fail;
    } 

    public void setFail(TrieNode node) {
        fail = node;
    } 
}
```

```csharp
public class StreamChecker {

    TrieNode root;
    TrieNode temp;

    public StreamChecker(String[] words) {
        root = new TrieNode();
        foreach (String word in words) {
            TrieNode cur = root;
            foreach (char ch in word) {
                int index = ch - 'a';
                if (cur.getChild(index) == null) {
                    cur.setChild(index, new TrieNode());
                }
                cur = cur.getChild(index);
            }
            cur.setIsEnd(true);
        }
        root.setFail(root);
        Queue<TrieNode> q = new Queue<TrieNode>();
        for (int i = 0; i < 26; i++) {
            if(root.getChild(i) != null) {
                root.getChild(i).setFail(root);
                q.Enqueue(root.getChild(i));
            } else {
                root.setChild(i, root);
            }
        }
        while (q.Count > 0) {
            TrieNode node = q.Dequeue();
            node.setIsEnd(node.getIsEnd() || node.getFail().getIsEnd());
            for (int i = 0; i<26; i++) {
                if(node.getChild(i) != null) {
                    node.getChild(i).setFail(node.getFail().getChild(i));
                    q.Enqueue(node.getChild(i));
                } else {
                    node.setChild(i, node.getFail().getChild(i));
                }
            }
        }

        temp = root;
    }

    public bool Query(char letter) {
        temp = temp.getChild(letter - 'a');
        return temp.getIsEnd();
    }
}

class TrieNode {
    TrieNode[] children;
    bool isEnd;
    TrieNode fail;

    public TrieNode() {
        children = new TrieNode[26];
    }

    public TrieNode getChild(int index) {
        return children[index];
    }

    public void setChild(int index, TrieNode node) {
        children[index] = node;
    }

    public bool getIsEnd() {
        return isEnd;
    }

    public void setIsEnd(bool b) {
        isEnd = b;
    }

    public TrieNode getFail() {
        return fail;
    } 

    public void setFail(TrieNode node) {
        fail = node;
    } 
}
```

```cpp
typedef struct TrieNode {
    vector<TrieNode *> children;
    bool isEnd;
    TrieNode *fail;
    TrieNode() {
        this->children = vector<TrieNode *>(26, nullptr);
        this->isEnd = false;
        this->fail = nullptr;
    }
};

class StreamChecker {
public:
    TrieNode *root;
    TrieNode *temp;
    StreamChecker(vector<string>& words) {
        root = new TrieNode();
        for (string &word : words) {
            TrieNode *cur = root;
            for (int i = 0; i < word.size(); i++) {
                int index = word[i] - 'a';
                if (cur->children[index] == nullptr) {
                    cur->children[index] = new TrieNode();
                }
                cur = cur->children[index];
            }
            cur->isEnd = true;
        }
        root->fail = root;
        queue<TrieNode *> q;
        for (int i = 0; i < 26; i++) {
            if(root->children[i] != nullptr) {
                root->children[i]->fail = root;
                q.emplace(root->children[i]);
            } else {
                root->children[i] = root;
            }
        }
        while (!q.empty()) {
            TrieNode *node = q.front();
            q.pop();
            node->isEnd = node->isEnd || node->fail->isEnd;
            for (int i = 0; i < 26; i++) {
                if(node->children[i] != nullptr) {
                    node->children[i]->fail = node->fail->children[i];
                    q.emplace(node->children[i]);
                } else {
                    node->children[i] = node->fail->children[i];
                }
            }
        }

        temp = root;
    }
    
    bool query(char letter) {
        temp = temp->children[letter - 'a'];
        return temp->isEnd;
    }
};
```

```c
#define MAX_QUEUE_SIZE 81920

typedef struct TrieNode {
    struct TrieNode *children[26];
    struct TrieNode *fail;
    bool isEnd;
} TrieNode;

typedef struct {
    TrieNode *root;
    TrieNode *temp;
} StreamChecker;

TrieNode* trieNodeCreate() {
    TrieNode *obj = (TrieNode *)malloc(sizeof(TrieNode));
    for (int i = 0; i < 26; i++) {
        obj->children[i] = NULL;
    }
    obj->isEnd = false;
    obj->fail = NULL;
    return obj;
}

void freeTrieNode(TrieNode* root) {
    for (int i = 0; i < 26; i++) {
        if (root->children[i]) {
            freeTrieNode(root->children[i]);
        }
    }
    free(root);
}

StreamChecker* streamCheckerCreate(char ** words, int wordsSize) {
    StreamChecker *obj = (StreamChecker *)malloc(sizeof(StreamChecker));
    obj->root = trieNodeCreate();
    obj->temp = obj->root;
    for (int i = 0; i < wordsSize; i++) {
        TrieNode *cur = obj->root;
        for (int j = 0; words[i][j] != '\0'; j++) {
            int index = words[i][j] - 'a';
            if (cur->children[index] == NULL) {
                cur->children[index] = trieNodeCreate();
            }
            cur = cur->children[index];
        }
        cur->isEnd = true;
    }
    obj->root->fail = obj->root;
    TrieNode *queue[MAX_QUEUE_SIZE];
    int head = 0;
    int tail = 0;
    for (int i = 0; i < 26; i++) {
        if(obj->root->children[i] != NULL) {
            obj->root->children[i]->fail = obj->root;
            queue[tail++] = obj->root->children[i];
        } else {
            obj->root->children[i] = obj->root;
        }
    }
    while (head != tail) {
        TrieNode *node = queue[head++];
        node->isEnd = node->isEnd || node->fail->isEnd;
        for (int i = 0; i < 26; i++) {
            if(node->children[i] != NULL) {
                node->children[i]->fail = node->fail->children[i];
                queue[tail++] = node->children[i];
            } else {
                node->children[i] = node->fail->children[i];
            }
        }
    }
    return obj;
}

bool streamCheckerQuery(StreamChecker* obj, char letter) {
    obj->temp = obj->temp->children[letter - 'a'];
    return obj->temp->isEnd;
}

void streamCheckerFree(StreamChecker* obj) {
    free(obj);
}
```

```javascript
var StreamChecker = function(words) {
    const root = new TrieNode();
    for (const word of words) {
        let cur = root;
        for (let i = 0; i < word.length; i++) {
            const index = word[i].charCodeAt() - 'a'.charCodeAt();
            if (cur.getChild(index) === 0) {
                cur.setChild(index, new TrieNode());
            }
            cur = cur.getChild(index);
        }
        cur.setIsEnd(true);
    }
    root.setFail(root);
    const q = [];
    for (let i = 0; i < 26; i++) {
        if(root.getChild(i) != 0) {
            root.getChild(i).setFail(root);
            q.push(root.getChild(i));
        } else {
            root.setChild(i, root);
        }
    }
    while (q.length) {
        const node = q.shift();
        node.setIsEnd(node.getIsEnd() || node.getFail().getIsEnd());
        for (let i = 0; i < 26; i++) {
            if(node.getChild(i) != 0) {
                node.getChild(i).setFail(node.getFail().getChild(i));
                q.push(node.getChild(i));
            } else {
                node.setChild(i, node.getFail().getChild(i));
            }
        }
    }

    this.temp = root;
};

StreamChecker.prototype.query = function(letter) {
    this.temp = this.temp.getChild(letter.charCodeAt() - 'a'.charCodeAt());
    return this.temp.getIsEnd();
};

class TrieNode {
    constructor() {
        this.children = new Array(26).fill(0);
        this.isEnd = false;
        this.fail;
    }

    getChild(index) {
        return this.children[index];
    }

    setChild(index, node) {
        this.children[index] = node;
    }

    getIsEnd() {
        return this.isEnd;
    }

    setIsEnd(b) {
        this.isEnd = b;
    }

    getFail() {
        return this.fail;
    }

    setFail(node) {
        this.fail = node;
    }
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(L+q)$������ $L$ ���ַ��������ܵ��ַ�����$q$ �ǲ�ѯ�����������ֵ�����Ҫ���� $O(L)$ ��ʱ�䣬���β�ѯ��ʱ�临�Ӷ�Ϊ $O(1)$��
-   �ռ临�Ӷȣ�$O(L)$�������ֵ�����Ҫ���� $O(L)$ �Ŀռ䡣
