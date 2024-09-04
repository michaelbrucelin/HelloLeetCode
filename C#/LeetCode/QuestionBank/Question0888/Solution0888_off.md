### [公平的糖果交换](https://leetcode.cn/problems/fair-candy-swap/solutions/585529/gong-ping-de-tang-guo-jiao-huan-by-leetc-tlam/)

#### 方法一：哈希表

**思路及算法**

记爱丽丝的糖果棒的总大小为 $sumA$，鲍勃的糖果棒的总大小为 $sumB$。设答案为 $\{x,y\}$，即爱丽丝的大小为 $x$ 的糖果棒与鲍勃的大小为 $y$ 的糖果棒交换，则有如下等式：

$$sumA-x+y=sumB+x-y$$

化简，得：

$$x=y+\dfrac{sumA-sumB}{2}$$

即对于 $bobSizes$ 中的任意一个数 $y′$，只要 $aliceSizes$ 中存在一个数 $x′$，满足 $x′=y′+\dfrac{sumA-sumB}{2}$，那么 $\{x′,y′\}$ 即为一组可行解。

为了快速查询 $aliceSizes$ 中是否存在某个数，我们可以先将 $aliceSizes$ 中的数字存入哈希表中。然后遍历 $bobSizes$ 序列中的数 $y′$，在哈希表中查询是否有对应的 $x′$。

**代码**

```C++
class Solution {
public:
    vector<int> fairCandySwap(vector<int>& aliceSizes, vector<int>& bobSizes) {
        int sumA = accumulate(aliceSizes.begin(), aliceSizes.end(), 0);
        int sumB = accumulate(bobSizes.begin(), bobSizes.end(), 0);
        int delta = (sumA - sumB) / 2;
        unordered_set<int> rec(aliceSizes.begin(), aliceSizes.end());
        vector<int> ans;
        for (auto& y : bobSizes) {
            int x = y + delta;
            if (rec.count(x)) {
                ans = vector<int>{x, y};
                break;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int[] fairCandySwap(int[] aliceSizes, int[] bobSizes) {
        int sumA = Arrays.stream(aliceSizes).sum();
        int sumB = Arrays.stream(bobSizes).sum();
        int delta = (sumA - sumB) / 2;
        Set<Integer> rec = new HashSet<Integer>();
        for (int num : aliceSizes) {
            rec.add(num);
        }
        int[] ans = new int[2];
        for (int y : bobSizes) {
            int x = y + delta;
            if (rec.contains(x)) {
                ans[0] = x;
                ans[1] = y;
                break;
            }
        }
        return ans;
    }
}
```

```JavaScript
var fairCandySwap = function(aliceSizes, bobSizes) {
    const sumA = _.sum(aliceSizes), sumB = _.sum(bobSizes);
    const delta = Math.floor((sumA - sumB) / 2);
    const rec = new Set(aliceSizes);
    var ans;
    for (const y of bobSizes) {
        const x = y + delta;
        if (rec.has(x)) {
            ans = [x, y];
            break;
        }
    }
    return ans;
};
```

```Python
class Solution:
    def fairCandySwap(self, aliceSizes: List[int], bobSizes: List[int]) -> List[int]:
        sumA, sumB = sum(aliceSizes), sum(bobSizes)
        delta = (sumA - sumB) // 2
        rec = set(aliceSizes)
        ans = None
        for y in bobSizes:
            x = y + delta
            if x in rec:
                ans = [x, y]
                break
        return ans
```

```Go
func fairCandySwap(aliceSizes []int, bobSizes []int) []int {
    sumA := 0
    setA := map[int]struct{}{}
    for _, v := range aliceSizes {
        sumA += v
        setA[v] = struct{}{}
    }
    sumB := 0
    for _, v := range bobSizes {
        sumB += v
    }
    delta := (sumA - sumB) / 2
    for i := 0; ; i++ {
        y := bobSizes[i]
        x := y + delta
        if _, has := setA[x]; has {
            return []int{x, y}
        }
    }
}
```

```C
struct HashTable {
    int x;
    UT_hash_handle hh;
};

int* fairCandySwap(int* aliceSizes, int aliceSizesSize, int* bobSizes, int bobSizesSize, int* returnSize) {
    int sumA = 0, sumB = 0;
    for (int i = 0; i < aliceSizesSize; i++) {
        sumA += aliceSizes[i];
    }
    for (int i = 0; i < bobSizesSize; i++) {
        sumB += bobSizes[i];
    }
    int delta = (sumA - sumB) / 2;
    struct HashTable* hashTable = NULL;
    for (int i = 0; i < aliceSizesSize; i++) {
        struct HashTable* tmp;
        HASH_FIND_INT(hashTable, &aliceSizes[i], tmp);
        if (tmp == NULL) {
            tmp = malloc(sizeof(struct HashTable));
            tmp->x = aliceSizes[i];
            HASH_ADD_INT(hashTable, x, tmp);
        }
    }
    int* ans = malloc(sizeof(int) * 2);
    for (int i = 0; i < bobSizesSize; i++) {
        int x = bobSizes[i] + delta;
        struct HashTable* tmp;
        HASH_FIND_INT(hashTable, &x, tmp);
        if (tmp != NULL) {
            ans[0] = x, ans[1] = bobSizes[i];
            *returnSize = 2;
            break;
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是序列 $aliceSizes$ 的长度，$m$ 是序列 $bobSizes$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是序列 $aliceSizes$ 的长度。我们需要建立一个和序列 $aliceSizes$ 等大的哈希表。
