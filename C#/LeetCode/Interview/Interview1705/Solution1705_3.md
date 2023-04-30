#### [方法一：转换 + 前缀和](https://leetcode.cn/problems/find-longest-subarray-lcci/solutions/2159214/zi-mu-yu-shu-zi-by-leetcode-solution-ezf4/)

一个子数组包含的字母和数字的个数相同，等价于该子数组包含的字母和数字的个数之差为 $0$。因此可以将原数组做转换，每个字母对应 $1$，每个数字对应 $-1$，则转换后的数组中，每个子数组的元素和为该子数组对应的原始子数组的字母和数字的个数之差，如果转换后数组中的一个子数组的元素和为 $0$，则该子数组对应的原始子数组包含的字母和数字的个数相同。问题等价于在转换后的数组中寻找元素和为 $0$ 的最长子数组。

为了在转换后的数组中寻找元素和为 $0$ 的子数组，可以计算转换后的数组的前缀和，如果两个下标对应的前缀和相等，则这两个下标之间的子数组的元素和为 $0$。

如果同一个前缀和出现多次，则该前缀和对应的最长子数组的长度为该前缀和的第一次出现的下标与最后一次出现的下标之间的子数组，因此为了在转换后的数组中寻找元素和为 $0$ 的最长子数组，需要记录每个前缀和第一次出现的下标。

使用哈希表记录每个前缀和第一次出现的下标。由于空前缀的前缀和是 $0$ 且对应下标 $-1$，因此首先将前缀和 $0$ 与下标 $-1$ 存入哈希表。

从左到右遍历数组，遍历过程中维护元素和为 $0$ 的最长子数组的长度 $maxLength$ 与开始下标 $startIndex$，初始时 $maxLength = 0$，$startIndex = -1$。当遍历到下标 $i$ 时，如果前缀和是 $sum$，则执行如下操作。

-   如果哈希表中已经存在前缀和 $sum$，则从哈希表中得到前缀和 $sum$ 第一次出现的下标 $firstIndex$，以下标 $i$ 结尾的元素和为 $0$ 的最长子数组的长度是 $i - firstIndex$，该最长子数组的下标范围是 $[firstIndex + 1, i]$。如果 $i - firstIndex > maxLength$，则将 $maxLength$ 更新为 $i - firstIndex$，将 $startIndex$ 更新为 $firstIndex + 1$；如果 $i - firstIndex \le maxLength$，则不更新 $maxLength$ 与 $startIndex$。
-   如果哈希表中不存在前缀和 $sum$，则下标 $i$ 为前缀和 $sum$ 第一次出现的下标，将前缀和 $sum$ 与下标 $i$ 存入哈希表。

遍历结束之后，根据 $maxLength$ 与 $startIndex$ 的值返回结果。

-   如果 $maxLength > 0$，则原数组中存在字母和数字的个数相同的子数组，根据 $maxLength$ 与 $startIndex$ 得到原数组中包含的字母和数字的个数相同的最长子数组，返回该最长子数组。
-   如果 $maxLength = 0$，则原数组中不存在字母和数字的个数相同的子数组，返回空数组。

从左到右遍历数组的过程中，只有当遇到的子数组长度大于已有的最大长度时才会更新最大子数组的长度与开始下标，因此每次更新最大子数组的长度与开始下标之后，不存在长度等于已有的最大长度且开始下标更小的子数组。如果有多个最长子数组，则 $startIndex$ 为这些最长子数组中的最小的左端点下标值。

实现方面，不需要创建并计算转换后的数组，只需要将原数组中的字母和数字分别对应 $1$ 和 $-1$，在遍历过程中计算前缀和即可。

```python
class Solution:
    def findLongestSubarray(self, array: List[str]) -> List[str]:
        indices = {0: -1}
        sum = 0
        maxLength = 0
        startIndex = -1
        for i, s in enumerate(array):
            if '0' <= s[0] <= '9':
                sum += 1
            else:
                sum -= 1
            if sum in indices:
                firstIndex = indices[sum]
                if i - firstIndex > maxLength:
                    maxLength = i - firstIndex
                    startIndex = firstIndex + 1
            else:
                indices[sum] = i
        if maxLength == 0:
            return []
        return array[startIndex: startIndex + maxLength]
```

```java
class Solution {
    public String[] findLongestSubarray(String[] array) {
        Map<Integer, Integer> indices = new HashMap<Integer, Integer>();
        indices.put(0, -1);
        int sum = 0;
        int maxLength = 0;
        int startIndex = -1;
        int n = array.length;
        for (int i = 0; i < n; i++) {
            if (Character.isLetter(array[i].charAt(0))) {
                sum++;
            } else {
                sum--;
            }
            if (indices.containsKey(sum)) {
                int firstIndex = indices.get(sum);
                if (i - firstIndex > maxLength) {
                    maxLength = i - firstIndex;
                    startIndex = firstIndex + 1;
                }
            } else {
                indices.put(sum, i);
            }
        }
        if (maxLength == 0) {
            return new String[0];
        }
        String[] ans = new String[maxLength];
        System.arraycopy(array, startIndex, ans, 0, maxLength);
        return ans;
    }
}
```

```csharp
public class Solution {
    public string[] FindLongestSubarray(string[] array) {
        IDictionary<int, int> indices = new Dictionary<int, int>();
        indices.Add(0, -1);
        int sum = 0;
        int maxLength = 0;
        int startIndex = -1;
        int n = array.Length;
        for (int i = 0; i < n; i++) {
            if (char.IsLetter(array[i][0])) {
                sum++;
            } else {
                sum--;
            }
            if (indices.ContainsKey(sum)) {
                int firstIndex = indices[sum];
                if (i - firstIndex > maxLength) {
                    maxLength = i - firstIndex;
                    startIndex = firstIndex + 1;
                }
            } else {
                indices.Add(sum, i);
            }
        }
        if (maxLength == 0) {
            return new string[0];
        }
        string[] ans = new string[maxLength];
        Array.Copy(array, startIndex, ans, 0, maxLength);
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<string> findLongestSubarray(vector<string>& array) {
        unordered_map<int, int> indices;
        indices[0] = -1;
        int sum = 0;
        int maxLength = 0;
        int startIndex = -1;
        int n = array.size();
        for (int i = 0; i < n; i++) {
            if (isalpha(array[i][0])) {
                sum++;
            } else {
                sum--;
            }
            if (indices.count(sum)) {
                int firstIndex = indices[sum];
                if (i - firstIndex > maxLength) {
                    maxLength = i - firstIndex;
                    startIndex = firstIndex + 1;
                }
            } else {
                indices[sum] = i;
            }
        }
        if (maxLength == 0) {
            return {};
        }
        return vector<string>(array.begin() + startIndex, array.begin() + startIndex + maxLength);
    }
};
```

```c
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
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

char** findLongestSubarray(char** array, int arraySize, int* returnSize) {
    HashItem *indices = NULL;
    hashAddItem(&indices, 0, -1);
    int sum = 0;
    int maxLength = 0;
    int startIndex = -1;
    int n = arraySize;
    for (int i = 0; i < n; i++) {
        if (isalpha(array[i][0])) {
            sum++;
        } else {
            sum--;
        }
        if (hashFindItem(&indices, sum)) {
            int firstIndex = hashGetItem(&indices, sum, 0);
            if (i - firstIndex > maxLength) {
                maxLength = i - firstIndex;
                startIndex = firstIndex + 1;
            }
        } else {
            hashAddItem(&indices, sum, i);
        }
    }
    hashFree(&indices);
    if (maxLength == 0) {
        *returnSize = 0;
        return NULL;
    }
    *returnSize = maxLength;
    char **ans = (char **)malloc(sizeof(char *) * maxLength);
    memcpy(ans, array + startIndex, sizeof(char *) * maxLength);
    return ans;
}
```

```javascript
var findLongestSubarray = function(array) {
    const indices = new Map();
    indices.set(0, -1);
    let sum = 0;
    let maxLength = 0;
    let startIndex = -1;
    const n = array.length;
    for (let i = 0; i < n; i++) {
        if (isLetter(array[i][0])) {
            sum++;
        } else {
            sum--;
        }
        if (indices.has(sum)) {
            const firstIndex = indices.get(sum);
            if (i - firstIndex > maxLength) {
                maxLength = i - firstIndex;
                startIndex = firstIndex + 1;
            }
        } else {
            indices.set(sum, i);
        }
    }
    if (maxLength === 0) {
        return [];
    }
    return [...array.slice(startIndex, startIndex + maxLength)];
};

const isLetter = (ch) => {
    return 'a' <= ch && ch <= 'z' || 'A' <= ch && ch <= 'Z';
}
```

```go
func findLongestSubarray(array []string) []string {
    indices := map[int]int{}
    sum := 0
    startIndex := -1
    maxLength := 0
    indices[0] = -1
    for i, s := range array {
        if s[0] >= '0' && s[0] <= '9' {
            sum++
        } else {
            sum--
        }
        if firstIndex, ok := indices[sum]; ok {
            if i-firstIndex > maxLength {
                maxLength = i - firstIndex
                startIndex = firstIndex + 1
            }
        } else {
            indices[sum] = i
        }
    }
    if maxLength == 0 {
        return []string{}
    }
    return array[startIndex : startIndex+maxLength]
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组的长度。需要遍历数组一次计算符合要求的最长子数组的长度与开始下标，对于数组中的每个元素的操作时间都是 $O(1)$，因此遍历时间是 $O(n)$，生成结果数组需要 $O(n)$ 的时间。
-   空间复杂度：$O(n)$，其中 $n$ 是数组的长度。哈希表需要 $O(n)$ 的空间。注意返回值不计入空间复杂度。
