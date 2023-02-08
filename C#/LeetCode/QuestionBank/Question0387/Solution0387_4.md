#### [������������](https://leetcode.cn/problems/first-unique-character-in-a-string/solutions/531740/zi-fu-chuan-zhong-de-di-yi-ge-wei-yi-zi-x9rok/)

**˼·���㷨**

����Ҳ���Խ��������ҵ���һ�����ظ����ַ������о��С��Ƚ��ȳ��������ʣ���˺��ʺ������ҳ���һ������ĳ��������Ԫ�ء�

����أ�����ʹ���뷽������ͬ�Ĺ�ϣӳ�䣬����ʹ��һ������Ķ��У�����˳��洢ÿһ���ַ��Լ����ǵ�һ�γ��ֵ�λ�á������Ƕ��ַ������б���ʱ���赱ǰ���������ַ�Ϊ $c$����� $c$ ���ڹ�ϣӳ���У����Ǿͽ� $c$ ������������Ϊһ����Ԫ������β���������Ǿ���Ҫ�������е�Ԫ���Ƿ����㡸ֻ����һ�Ρ���Ҫ�󣬼����ǲ��ϵظ��ݹ�ϣӳ���д洢��ֵ���Ƿ�Ϊ $-1$��ѡ�񵯳����׵�Ԫ�أ�ֱ������Ԫ�ء���ġ�ֻ������һ�λ��߶���Ϊ�ա�

�ڱ�����ɺ��������Ϊ�գ�˵��û�в��ظ����ַ������� $-1$��������׵�Ԫ�ؼ�Ϊ��һ�����ظ����ַ��Լ��������Ķ�Ԫ�顣

**С��ʿ**

��ά������ʱ������ʹ���ˡ��ӳ�ɾ������һ���ɡ�Ҳ����˵����ʹ��������һЩ�ַ������˳���һ�Σ�����ֻҪ��λ�ڶ��ף���ô�Ͳ���Դ����Ӱ�죬����Ҳ�Ϳ��Բ���ȥɾ������ֻ�е���ǰ��������ַ����Ƴ����У�����Ϊ����ʱ�����ǲ���Ҫ�����Ƴ���

**����**

```cpp
class Solution {
public:
    int firstUniqChar(string s) {
        unordered_map<char, int> position;
        queue<pair<char, int>> q;
        int n = s.size();
        for (int i = 0; i < n; ++i) {
            if (!position.count(s[i])) {
                position[s[i]] = i;
                q.emplace(s[i], i);
            }
            else {
                position[s[i]] = -1;
                while (!q.empty() && position[q.front().first] == -1) {
                    q.pop();
                }
            }
        }
        return q.empty() ? -1 : q.front().second;
    }
};
```

```java
class Solution {
    public int firstUniqChar(String s) {
        Map<Character, Integer> position = new HashMap<Character, Integer>();
        Queue<Pair> queue = new LinkedList<Pair>();
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            char ch = s.charAt(i);
            if (!position.containsKey(ch)) {
                position.put(ch, i);
                queue.offer(new Pair(ch, i));
            } else {
                position.put(ch, -1);
                while (!queue.isEmpty() && position.get(queue.peek().ch) == -1) {
                    queue.poll();
                }
            }
        }
        return queue.isEmpty() ? -1 : queue.poll().pos;
    }

    class Pair {
        char ch;
        int pos;

        Pair(char ch, int pos) {
            this.ch = ch;
            this.pos = pos;
        }
    }
}
```

```python
class Solution:
    def firstUniqChar(self, s: str) -> int:
        position = dict()
        q = collections.deque()
        n = len(s)
        for i, ch in enumerate(s):
            if ch not in position:
                position[ch] = i
                q.append((s[i], i))
            else:
                position[ch] = -1
                while q and position[q[0][0]] == -1:
                    q.popleft()
        return -1 if not q else q[0][1]
```

```javascript
var firstUniqChar = function(s) {
    const position = new Map();
    const q = [];
    const n = s.length;
    for (let [i, ch] of Array.from(s).entries()) {
        if (!position.has(ch)) {
            position.set(ch, i);
            q.push([s[i], i]);
        } else {
            position.set(ch, -1);
            while (q.length && position.get(q[0][0]) === -1) {
                q.shift();
            }
        }
    }
    return q.length ? q[0][1] : -1;
};
```

```go
type pair struct {
    ch  byte
    pos int
}

func firstUniqChar(s string) int {
    n := len(s)
    pos := [26]int{}
    for i := range pos[:] {
        pos[i] = n
    }
    q := []pair{}
    for i := range s {
        ch := s[i] - 'a'
        if pos[ch] == n {
            pos[ch] = i
            q = append(q, pair{ch, i})
        } else {
            pos[ch] = n + 1
            for len(q) > 0 && pos[q[0].ch] == n+1 {
                q = q[1:]
            }
        }
    }
    if len(q) > 0 {
        return q[0].pos
    }
    return -1
}
```

```c
struct hashTable {
    int key;
    int val;
    UT_hash_handle hh;
};

int firstUniqChar(char* s) {
    struct hashTable* position = NULL;
    int que[26][2], left = 0, right = 0;
    int n = strlen(s);
    for (int i = 0; i < n; ++i) {
        int ikey = s[i];
        struct hashTable* tmp;
        HASH_FIND_INT(position, &ikey, tmp);
        if (tmp == NULL) {
            tmp = malloc(sizeof(struct hashTable));
            tmp->key = ikey;
            tmp->val = i;
            HASH_ADD_INT(position, key, tmp);
            que[right][0] = ikey;
            que[right++][1] = i;
        } else {
            tmp->val = -1;
            while (left < right) {
                int ikey = que[left][0];
                struct hashTable* tmp;
                HASH_FIND_INT(position, &ikey, tmp);
                if (tmp == NULL || tmp->val != -1) {
                    break;
                }
                left++;
            }
        }
    }
    return left < right ? que[left][1] : -1;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ���ַ��� $s$ �ĳ��ȡ������ַ�����ʱ�临�Ӷ�Ϊ $O(n)$�����ڱ����Ĺ��������ǻ�ά����һ�����У�����ÿһ���ַ����ֻ�ᱻ����͵�����������һ�Σ����ά�����е���ʱ�临�Ӷ�Ϊ $O(|\Sigma|)$������ $s$ �������ַ�������һ��С�� $s$ �ĳ��ȣ���� $O(|\Sigma|)$ �ڽ���������С�� $O(n)$�����Ժ��ԡ�
-   �ռ临�Ӷȣ�$O(|\Sigma|)$������ $\Sigma$ ���ַ������ڱ����� $s$ ֻ����Сд��ĸ����� $|\Sigma| \leq 26$��������Ҫ $O(|\Sigma|)$ �Ŀռ�洢��ϣӳ���Լ����С�
