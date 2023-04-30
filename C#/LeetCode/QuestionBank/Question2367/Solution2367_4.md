#### [����������ϣ����](https://leetcode.cn/problems/number-of-arithmetic-triplets/solutions/2200026/suan-zhu-san-yuan-zu-de-shu-mu-by-leetco-ldq4/)

���ڸ��������� $nums$ ���ϸ�����ģ���������в������ظ�Ԫ�أ�������������ͬ��������Ԫ�顣

�������� $nums$ �е�Ԫ�� $x$����� $x + diff$ �� $x + 2 \times diff$ ���������У������һ��������Ԫ�飬���е�����Ԫ�طֱ��� $x$��$x + diff$ �� $x + 2 \times diff$���������ת���ɼ������� $nums$ ���ж��ٸ�Ԫ�ؿ�����Ϊ������Ԫ�����СԪ�ء�

Ϊ�˿����ж�һ��Ԫ���Ƿ��������У�����ʹ�ù�ϣ���ϴ洢�����е�����Ԫ�أ�Ȼ���ж�Ԫ���Ƿ��ڹ�ϣ�����С�

�������е�����Ԫ�ض������ϣ����֮�󣬱������鲢ͳ������ $x + diff$ �� $x + 2 \times diff$ ���ڹ�ϣ�����е�Ԫ�� $x$ �ĸ�������Ϊ������Ԫ�����Ŀ��

```java
class Solution {
    public int arithmeticTriplets(int[] nums, int diff) {
        Set<Integer> set = new HashSet<Integer>();
        for (int x : nums) {
            set.add(x);
        }
        int ans = 0;
        for (int x : nums) {
            if (set.contains(x + diff) && set.contains(x + 2 * diff)) {
                ans++;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int ArithmeticTriplets(int[] nums, int diff) {
        ISet<int> set = new HashSet<int>();
        foreach (int x in nums) {
            set.Add(x);
        }
        int ans = 0;
        foreach (int x in nums) {
            if (set.Contains(x + diff) && set.Contains(x + 2 * diff)) {
                ans++;
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int arithmeticTriplets(vector<int>& nums, int diff) {
        unordered_set<int> hashSet;
        for (int x : nums) {
            hashSet.emplace(x);
        }
        int ans = 0;
        for (int x : nums) {
            if (hashSet.count(x + diff) && hashSet.count(x + 2 * diff)) {
                ans++;
            }
        }
        return ans;
    }
};
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

int arithmeticTriplets(int* nums, int numsSize, int diff) {
    HashItem *hashSet = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&hashSet, nums[i]);
    }
    int ans = 0;
    for (int i = 0; i < numsSize; i++) {
        if (hashFindItem(&hashSet, nums[i] + diff) && hashFindItem(&hashSet, nums[i] + 2 * diff)) {
            ans++;
        }
    }
    hashFree(&hashSet);
    return ans;
}
```

```javascript
var arithmeticTriplets = function(nums, diff) {
    const set = new Set();
    for (const x of nums) {
        set.add(x);
    }
    let ans = 0;
    for (const x of nums) {
        if (set.has(x + diff) && set.has(x + 2 * diff)) {
            ans++;
        }
    }
    return ans;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ $nums$ �ĳ��ȡ���Ҫ�����������Σ�ÿ�ν�Ԫ�ؼ����ϣ�������ж�Ԫ���Ƿ��ڹ�ϣ�����е�ʱ�䶼�� $O(1)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ������ $nums$ �ĳ��ȡ���ϣ������Ҫ $O(n)$ �Ŀռ䡣
