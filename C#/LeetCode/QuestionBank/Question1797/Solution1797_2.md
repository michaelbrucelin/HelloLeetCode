#### [����һ����ϣ��](https://leetcode.cn/problems/design-authentication-manager/solutions/2099432/she-ji-yi-ge-yan-zheng-xi-tong-by-leetco-kqqb/)

**˼·**

�������⣬��һ����ϣ�� $map$ ������֤��͹���ʱ�䡣���� $generate$ ʱ������֤��-����ʱ���ֱ�Ӳ��� $map$������ $renew$ ʱ�������֤����ڲ���δ���ڣ�����¹���ʱ�䡣���� $countUnexpiredTokens$ ʱ���������� $map$��ͳ��δ���ڵ���֤���������

**����**

```python
class AuthenticationManager:
    def __init__(self, timeToLive: int):
        self.ttl = timeToLive
        self.map = {}

    def generate(self, tokenId: str, currentTime: int) -> None:
        self.map[tokenId] = currentTime + self.ttl

    def renew(self, tokenId: str, currentTime: int) -> None:
        if tokenId in self.map and self.map[tokenId] > currentTime:
            self.map[tokenId] = self.ttl + currentTime

    def countUnexpiredTokens(self, currentTime: int) -> int:
        res = 0
        for time in self.map.values():
            if time > currentTime:
                res += 1
        return res
```

```java
class AuthenticationManager {
    int timeToLive;
    Map<String, Integer> map;

    public AuthenticationManager(int timeToLive) {
        this.timeToLive = timeToLive;
        this.map = new HashMap<String, Integer>();
    }

    public void generate(String tokenId, int currentTime) {
        map.put(tokenId, currentTime + timeToLive);
    }

    public void renew(String tokenId, int currentTime) {
        if (map.getOrDefault(tokenId, 0) > currentTime) {
            map.put(tokenId, currentTime + timeToLive);
        }
    }

    public int countUnexpiredTokens(int currentTime) {
        int res = 0;
        for (int time : map.values()) {
            if (time > currentTime) {
                res++;
            }
        }
        return res;
    }
}
```

```csharp
public class AuthenticationManager {
    int timeToLive;
    IDictionary<string, int> dictionary;

    public AuthenticationManager(int timeToLive) {
        this.timeToLive = timeToLive;
        this.dictionary = new Dictionary<string, int>();
    }

    public void Generate(string tokenId, int currentTime) {
        if (!dictionary.ContainsKey(tokenId)) {
            dictionary.Add(tokenId, currentTime + timeToLive);
        } else {
            dictionary[tokenId] = currentTime + timeToLive;
        }
    }

    public void Renew(string tokenId, int currentTime) {
        if (dictionary.ContainsKey(tokenId) && dictionary[tokenId] > currentTime) {
            dictionary[tokenId] = currentTime + timeToLive;
        }
    }

    public int CountUnexpiredTokens(int currentTime) {
        int res = 0;
        foreach (int time in dictionary.Values) {
            if (time > currentTime) {
                res++;
            }
        }
        return res;
    }
}
```

```javascript
var AuthenticationManager = function(timeToLive) {
    this.timeToLive = timeToLive;
    this.map = new Map();
};

AuthenticationManager.prototype.generate = function(tokenId, currentTime) {
    this.map.set(tokenId, currentTime + this.timeToLive);
};

AuthenticationManager.prototype.renew = function(tokenId, currentTime) {
    if ((this.map.get(tokenId) || 0) > currentTime) {
        this.map.set(tokenId, currentTime + this.timeToLive);
    }
};

AuthenticationManager.prototype.countUnexpiredTokens = function(currentTime) {
    let res = 0;
    for (const time of this.map.values()) {
        if (time > currentTime) {
            res++;
        }
    }
    return res;
};
```

```cpp
class AuthenticationManager {
private:
    int timeToLive;
    unordered_map<string, int> mp;
public:
    AuthenticationManager(int timeToLive) {
        this->timeToLive = timeToLive;
    }

    void generate(string tokenId, int currentTime) {
        mp[tokenId] = currentTime + timeToLive;
    }

    void renew(string tokenId, int currentTime) {
        if (mp.count(tokenId) && mp[tokenId] > currentTime) {
            mp[tokenId] = currentTime + timeToLive;
        }
    }

    int countUnexpiredTokens(int currentTime) {
        int res = 0;
        for (auto &[_, time] : mp) {
            if (time > currentTime) {
                res++;
            }
        }
        return res;
    }
};
```

```c
typedef struct {
    char *key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, char *key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, char *key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, char *key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

typedef struct {
    int timeToLive;
    HashItem *map;
} AuthenticationManager;

AuthenticationManager* authenticationManagerCreate(int timeToLive) {
    AuthenticationManager *obj = (AuthenticationManager *)malloc(sizeof(AuthenticationManager));
    obj->timeToLive = timeToLive;
    obj->map = NULL;
    return obj;
}

void authenticationManagerGenerate(AuthenticationManager* obj, char * tokenId, int currentTime) {
    hashAddItem(&obj->map, tokenId, obj->timeToLive + currentTime);
}

void authenticationManagerRenew(AuthenticationManager* obj, char * tokenId, int currentTime) {
    if (hashGetItem(&obj->map, tokenId, 0) > currentTime) {
        hashSetItem(&obj->map, tokenId, currentTime + obj->timeToLive);
    }
}

int authenticationManagerCountUnexpiredTokens(AuthenticationManager* obj, int currentTime) {
    int res = 0;
    HashItem *cur = NULL, *tmp = NULL;
    HASH_ITER(hh, obj->map, cur, tmp) {
        if (cur->val > currentTime) {
            res++;
        }
    }
    return res;
}

void authenticationManagerFree(AuthenticationManager* obj) {
    hashFree(&obj->map);
    free(obj);
}
```

```go
type AuthenticationManager struct {
    mp  map[string]int
    ttl int
}

func Constructor(timeToLive int) AuthenticationManager {
    return AuthenticationManager{map[string]int{}, timeToLive}
}

func (m *AuthenticationManager) Generate(tokenId string, currentTime int) {
    m.mp[tokenId] = currentTime
}

func (m *AuthenticationManager) Renew(tokenId string, currentTime int) {
    if v, ok := m.mp[tokenId]; ok && v+m.ttl > currentTime {
        m.mp[tokenId] = currentTime
    }
}

func (m *AuthenticationManager) CountUnexpiredTokens(currentTime int) (ans int) {
    for _, t := range m.mp {
        if t+m.ttl > currentTime {
            ans++
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ����캯����$O(1)$��$generate$��$O(1)$��$renew$��$O(1)$��$countUnexpiredTokens$��$O(n)$������ $n$ Ϊ $generate$ �ĵ��ô�����
-   �ռ临�Ӷȣ�$O(n)$������ $n$ Ϊ $generate$ �ĵ��ô�����$map$ ���� $n$ ��Ԫ�ء�
