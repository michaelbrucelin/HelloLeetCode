### [统计特殊整数](https://leetcode.cn/problems/count-special-integers/solutions/2916434/tong-ji-te-shu-zheng-shu-by-leetcode-sol-7qai/)

#### 方法一：动态规划 + 组合数学

**思路**

要返回区间 $[1, n]$ 之间的特殊整数的数目，即小于等于 $n$ 的特殊整数的数目。记 $n$ 十进制表示下位数为 $k$，我们考虑两种情况：

- 位数小于 $k$ 的特殊整数。
- 位数等于 $k$ 的特殊整数。

对于位数小于 $k$ 的情况，分别计算位数为 $1$ 到 $k-1$ 的情况下特殊整数的数量。考虑位数为 $k_0​ (k_0​<k)$ 的情况。因为 $k_0​<k$，所以任意放置数位上的数字，都能满足小于等于 $n$ 的条件。只需保证每一数位都互不相同。用组合数学的思路求解特殊整数的数量，从最高位开始考虑，可以有 $9$ 种选择（除 $0$ 外的任何整数），次高位也有 $9$ 种选择（除最高位外的任何整数），接下来的数位的选择则依次减少 $1$。把这些选择的可能性全部相乘则是位数为 k_0​ 的特殊整数的数量。

接下来考虑位数等于 $k$ 的特殊整数。相同位数的数字比较大小，是从最高位开始比较，若不同，则最高位大的数字大；若相同，则比较次高位。次高位的比较原则和最高位一样。因此，我们在计算小于等于 $n$ 的特殊整数时，也需要按照这个原则。函数 $dp(mask,prefixSmaller)$ 用来计算以某些数字组合为前缀的特殊整数的数量。整数 $mask$ 即表示了前缀中使用过的数字，二进制表示下，从最低位开始，第 $i$ 为如果为 $1$ 则表示数字 $i$ 已经被使用过，在接下来的后缀中不能使用。布尔值 $prefixSmaller$ 表示当前的前缀是否小于 $n$ 的前缀，如果是，则接下来的数字可以任意选择。如果不是，即当前的前缀等于 $n$ 的前缀，则接下来的数字只能小于或者等于 $n$ 同数位的数字。最后调用 $dp(0,false)$ 则为位数等于 $k$ 的特殊整数的数量。

最后把这两部分相加即可。

**代码**

```Python
class Solution:
    def countSpecialNumbers(self, n: int) -> int:

        @cache
        def dp(mask: int, prefixSmaller: bool) -> int:
            if mask.bit_count() == len(nStr):
                return 1
            res = 0
            lowerBound = 1 if mask == 0 else 0
            upperBound = 9 if prefixSmaller else int(nStr[mask.bit_count()])
            for i in range(lowerBound, upperBound + 1):
                if mask >> i & 1 == 0:
                    res += dp(mask | 1 << i, prefixSmaller or i < upperBound)
            return res

        nStr = str(n)
        res = 0
        prod = 9
        for i in range(len(nStr) - 1):
            res += prod
            prod *= 9 - i
        res += dp(0, False)
        dp.cache_clear()
        return res
```

```Java
class Solution {
    Map<Integer, Integer> memo = new HashMap<Integer, Integer>();

    public int countSpecialNumbers(int n) {
        String nStr = String.valueOf(n);
        int res = 0;
        int prod = 9;
        for (int i = 0; i < nStr.length() - 1; i++) {
            res += prod;
            prod *= 9 - i;
        }
        res += dp(0, false, nStr);
        return res;
    }

    public int dp(int mask, boolean prefixSmaller, String nStr) {
        if (Integer.bitCount(mask) == nStr.length()) {
            return 1;
        }
        int key = mask * 2 + (prefixSmaller ? 1 : 0);
        if (!memo.containsKey(key)) {
            int res = 0;
            int lowerBound = mask == 0 ? 1 : 0;
            int upperBound = prefixSmaller ? 9 : nStr.charAt(Integer.bitCount(mask)) - '0';
            for (int i = lowerBound; i <= upperBound; i++) {
                if (((mask >> i) & 1) == 0) {
                    res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo.put(key, res);
        }
        return memo.get(key);
    }
}
```

```CSharp
public class Solution {
    Dictionary<int, int> memo = new Dictionary<int, int>();

    public int CountSpecialNumbers(int n) {
        string nStr = n.ToString();
        int res = 0;
        int prod = 9;
        for (int i = 0; i < nStr.Length - 1; i++) {
            res += prod;
            prod *= 9 - i;
        }
        res += Dp(0, false, nStr);
        return res;
    }

    public int Dp(int mask, bool prefixSmaller, string nStr) {
        if (CountOnes(mask) == nStr.Length) {
            return 1;
        }
        int key = mask * 2 + (prefixSmaller ? 1 : 0);
        if (!memo.ContainsKey(key)) {
            int res = 0;
            int lowerBound = mask == 0 ? 1 : 0;
            int upperBound = prefixSmaller ? 9 : nStr[CountOnes(mask)] - '0';
            for (int i = lowerBound; i <= upperBound; i++) {
                if (((mask >> i) & 1) == 0) {
                    res += Dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo[key] = res;
        }
        return memo[key];
    }

    public static int CountOnes(int number) {
        int count = 0;
        while (number > 0) {
            count++;
            number &= number - 1;
        }
        return count;
    }
}
```

```C++
class Solution {
public:
    unordered_map<int, int> memo;
    int countSpecialNumbers(int n) {
        string nStr = to_string(n);
        int res = 0;
        int prod = 9;
        for (int i = 0; i < nStr.size() - 1; i++) {
            res += prod;
            prod *= 9 - i;
        }
        res += dp(0, false, nStr);
        return res;
    }

    int dp(int mask, bool prefixSmaller, const string &nStr) {
        if (__builtin_popcount(mask) == nStr.size()) {
            return 1;
        }
        int key = mask * 2 + (prefixSmaller ? 1 : 0);
        if (!memo.count(key)) {
            int res = 0;
            int lowerBound = mask == 0 ? 1 : 0;
            int upperBound = prefixSmaller ? 9 : nStr[__builtin_popcount(mask)] - '0';
            for (int i = lowerBound; i <= upperBound; i++) {
                if (((mask >> i) & 1) == 0) {
                    res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo[key] = res;
        }
        return memo[key];
    }
};
```

```Go
func countSpecialNumbers(n int) int {
    nStr := strconv.Itoa(n)
    memo := make(map[int]int)

    var dp func(int, bool, string) int
    dp = func(mask int, prefixSmaller bool, nStr string) int {
        if countOnes(mask) == len(nStr) {
            return 1
        }
        key := mask * 2
        if prefixSmaller {
            key++
        }
        if _, exists := memo[key]; !exists {
            res, lowerBound := 0, 0
            if mask == 0 {
                lowerBound = 1
            }
            upperBound := 9
            if !prefixSmaller {
                upperBound = int(nStr[countOnes(mask)] - '0')
            }
            for i := lowerBound; i <= upperBound; i++ {
                if (mask>>i) & 1 == 0 {
                    res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr)
                }
            }
            memo[key] = res
        }
        return memo[key]
    }

    res, prod := 0, 9
    for i := 0; i < len(nStr)-1; i++ {
        res += prod
        prod *= 9 - i
    }
    res += dp(0, false, nStr)
    return res
}

func countOnes(x int) int {
    count := 0
    for x > 0 {
        count++
        x &= x - 1
    }
    return count
}

func btoi(b bool) int {
    if b {
        return 1
    }
    return 0
}
```

```C
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

int dp(int mask, bool prefixSmaller, const char *nStr, HashItem **memo) {
    if (__builtin_popcount(mask) == strlen(nStr)) {
        return 1;
    }
    int key = mask * 2 + (prefixSmaller ? 1 : 0);
    if (!hashFindItem(memo, key)) {
        int res = 0;
        int lowerBound = mask == 0 ? 1 : 0;
        int upperBound = prefixSmaller ? 9 : nStr[__builtin_popcount(mask)] - '0';
        for (int i = lowerBound; i <= upperBound; i++) {
            if (((mask >> i) & 1) == 0) {
                res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr, memo);
            }
        }
        hashAddItem(memo, key, res);
    }
    return hashGetItem(memo, key, 0);
}

int countSpecialNumbers(int n) {
    char nStr[64];
    sprintf(nStr, "%d", n);
    int res = 0;
    int prod = 9;
    int len = strlen(nStr);
    HashItem *memo = NULL;
    for (int i = 0; i < len - 1; i++) {
        res += prod;
        prod *= 9 - i;
    }
    res += dp(0, false, nStr, &memo);
    hashFree(&memo);
    return res;
}
```

```JavaScript
var countSpecialNumbers = function(n) {
    const nStr = n.toString();
    const memo = new Map();

    const dp = (mask, prefixSmaller, nStr) => {
        if (countOnes(mask) === nStr.length) {
            return 1;
        }
        const key = mask * 2 + (prefixSmaller ? 1 : 0);
        if (!memo.has(key)) {
            let res = 0;
            let lowerBound = mask === 0 ? 1 : 0;
            let upperBound = prefixSmaller ? 9 : nStr[countOnes(mask)] - '0';
            for (let i = lowerBound; i <= upperBound; i++) {
                if (((mask >> i) & 1) === 0) {
                    res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo.set(key, res);
        }
        return memo.get(key);
    };

    let res = 0;
    let prod = 9;
    for (let i = 0; i < nStr.length - 1; i++) {
        res += prod;
        prod *= 9 - i;
    }
    res += dp(0, false, nStr);
    return res;
};

const countOnes = (x) => {
  let count = 0;
  while (x) {
    count++;
    x &= x - 1;
  }
  return count;
}
```

```TypeScript
function countSpecialNumbers(n: number): number {
    const nStr = n.toString();
    const memo: Map<number, number> = new Map();

    const dp = (mask: number, prefixSmaller: boolean, nStr: string): number => {
        if (countOnes(mask) === nStr.length) {
            return 1;
        }
        const key = mask * 2 + (prefixSmaller ? 1 : 0);
        if (!memo.has(key)) {
            let res = 0;
            let lowerBound = mask === 0 ? 1 : 0;
            let upperBound = prefixSmaller ? 9 : +nStr[countOnes(mask)];
            for (let i = lowerBound; i <= upperBound; i++) {
                if (((mask >> i) & 1) === 0) {
                    res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo.set(key, res);
        }
        return memo.get(key)!;
    };

    let res = 0;
    let prod = 9;
    for (let i = 0; i < nStr.length - 1; i++) {
        res += prod;
        prod *= 9 - i;
    }
    res += dp(0, false, nStr);
    return res;
};

const countOnes = (x) => {
  let count = 0;
  while (x) {
    count++;
    x &= x - 1;
  }
  return count;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn count_special_numbers(n: i32) -> i32 {
        let n_str = n.to_string();
        let mut memo: HashMap<i32, i32> = HashMap::new();

        fn dp(mask: i32, prefix_smaller: bool, n_str: &str, memo: &mut HashMap<i32, i32>) -> i32 {
            if mask.count_ones() as usize == n_str.len() {
                return 1;
            }
            let key = mask * 2 + if prefix_smaller { 1 } else { 0 };
            if !memo.contains_key(&key) {
                let mut res = 0;
                let lower_bound = if mask == 0 { 1 } else { 0 };
                let upper_bound = if prefix_smaller {
                    9
                } else {
                    (n_str.chars().nth(mask.count_ones() as usize).unwrap() as i32) - ('0' as i32)
                };
                for i in lower_bound..=upper_bound {
                    if (mask >> i) & 1 == 0 {
                        res += dp(mask | (1 << i), prefix_smaller || i < upper_bound, n_str, memo);
                    }
                }
                memo.insert(key, res);
            }
            *memo.get(&key).unwrap()
        }

        let mut res = 0;
        let mut prod = 9;
        for i in 0..(n_str.len() - 1) {
            res += prod;
            prod *= 9 - i as i32;
        }
        res += dp(0, false, &n_str, &mut memo);
        res
    }
}
```

```Cangjie
class Solution {
    let memo:HashMap<Int64, Int64> = HashMap<Int64, Int64>()

    func countSpecialNumbers(n: Int64): Int64 {
        let nStr = "${n}"
        var res = 0
        var prod = 9
        for(i in 0..nStr.size - 1){
            res += prod
            prod *= 9 - i
        }
        res += dp(0, false, nStr)
        return res
    }

    func bitCount(num: Int64): Int64 {
        var cnt = 0
        var res = 0
        while (num >> cnt > 0) {
            if((num >> cnt & 1) == 1){
                res++
            }
            cnt++
        }
        return res
    }

    func dp(mask:Int64, prefixSmaller:Bool, nStr:String): Int64 {
        if (bitCount(mask) == nStr.size) {
            return 1;
        }
        let key = mask * 2 + if (prefixSmaller) {1} else {0}
        if(!memo.contains(key)) {
            var res = 0
            let lowerBound:UInt8 = if (mask == 0) {1} else {0};
            let zero:Byte = '0'
            let upperBound:UInt8 = if (prefixSmaller) {9} else {nStr[bitCount(mask)]-zero}
            for(i in lowerBound..=upperBound){
                if (((mask >> i) & 1) == 0) {
                    res += dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo.put(key, res)
        }
        return memo.get(key).getOrThrow()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(D \times 2^D)$，其中 $D=10$。$mask$ 最多有 $2^D$ 个状态，每个状态消耗 $O(D)$ 时间计算。
- 空间复杂度：$O(2^D)$。
