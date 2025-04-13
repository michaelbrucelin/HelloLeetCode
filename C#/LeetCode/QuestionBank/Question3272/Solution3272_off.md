### [统计好整数的数目](https://leetcode.cn/problems/find-the-count-of-good-integers/solutions/3637602/tong-ji-hao-zheng-shu-de-shu-mu-by-leetc-m5l4/)

#### 方法一：枚举 + 排列组合

**思路与算法**

根据题意可知，如果 $x$ 是一个**回文**整数且能被 $k$ 整除，则称 $x$ 是 $k$ **回文**整数，题目要求找到满足数位长度为 $n$ 的 $k$ **回文**整数的数目。根据**回文**整数的定义可知，**回文**整数的左半边顺序与右半边倒序相同，如果知道了左半边的数字，就可以确定右半边的数字，在数位长度为 $n$ 的情况下，我们分类讨论如下：

- 如果 $n$ 为偶数，则此时**回文**整数左半边的前 $\frac{n}{2}$ 位顺序与右半边的 $\frac{n}{2}$ 位倒序相同，整数左半边前 $\frac{n}{2}$ 位的取值范围为 $[0,10^{\frac{n}{2}})$，由于不能有前导 $0$，因此一共有 $10^{\frac{n}{2}}-10^{\frac{n-2}{2}}$ 个不同的**回文**整数；
- 如果 $n$ 为奇数，则此时**回文**整数左半边的前 $\frac{n-1}{2}$ 位顺序与右半边的 $\frac{n-1}{2}$ 位倒序相同，中间的第 $\frac{n+1}{2}$ 位取值范围为 $[0,9]$，直接枚举整数左半边前 $\frac{n+1}{2}$ 位的取值范围为 $[0,10^{\frac{n+1}{2}})$，由于不能有前导 $0$，因此一共有 $10^{\frac{n+1}{2}}-10^{\frac{n-1}{2}}$ 个不同的**回文**整数；

根据以上推论可知长度为 $n$ 时，一共存在 $10^{\lfloor \frac{n+1}{2} \rfloor}-10^{\lfloor \frac{n-1}{2} \rfloor}$ 个**回文**整数，题目给定的 $n$ 的取值范围为 $[1,10]$，最多存在不超过 $10^5$ 个不同的 $k$ 回文数，因此可以枚举找到所有的 $k$ **回文**整数。设 $m=\lfloor \frac{n-1}{2} \rfloor$，设 $base=10^m$，直接枚举**回文**整数的左半边，其取值范围在 $[base,10 \times base)$，即可生成长度为 $n$ 的**回文**整数，此时如果该**回文**整数能被 $k$ 整除，则该**回文**整数为 $k$ **回文**整数。

根据题意可知，如果一个整数的数位重新排列后能得到一个 $k$ **回文**整数，则该整数为**好整数**，即如果一个整数与 $k$ **回文**整数具有相同的数字构成且不含前导 $0$ 则该整数为**好整数**，题目要求找到所有长度为 $n$ 的**好整数**的数目。我们知道对于一个 $k$ **回文**整数来说，其数位构成的字符中任意一个不含前导 $0$ 的排列都可以称之为一个**好整数**。由于已经找到所有合法的 $k$ **回文**整数，此时问题转换为求给定字符串的不同排列组合数目。

在计算时由于不同的 $k$ **回文**整数可能由相同的数位字符组成，此时为了避免重复计算，可以将每个**回文**整数构成的字符串进行规则化，可将字符串按照**字典序**进行排序，这样即可保证相同的数位字符的唯一性，我们用哈希表 $dict$ 记录排序后的字符串，如果 $s$ 排序后在哈希表中出现过，此时则不再重复记录。接下来考虑排列组合的问题，由于相同的字符可能出现多次，即需要考虑「[多重组合数](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fcombinatorics%2Fcombination%2F%23%E5%A4%9A%E9%87%8D%E9%9B%86%E7%9A%84%E6%8E%92%E5%88%97%E6%95%B0--%E5%A4%9A%E9%87%8D%E7%BB%84%E5%90%88%E6%95%B0)」。假设给定的长度为 $n$ 的字符串中 $‘0’$ 到 $‘9’$ 出现的次数分别为 $c_0,c_1,\cdots,c_9$，如不考虑前导 $0$ 的前提下，此时可以组成的排列数为:

$$\frac{n!}{\prod_{i=0}^9c_i!}$$

在考虑不能有前导 $0$ 的情况下，此时首先需要从 $n$ 个字符中选择一个不为 $‘0’$ 的字符放在首位，一共有 $n-c_0$ 个不为 $‘0’$ 的字符，剩余的 $n-1$ 个字符可任意排列，一共有 $(n-1)!$ 种组合方案，此时在不考虑重复元素的情况下组合方案数为 $(n-c_0) \cdot (n-1)!$，由于部分元素存在重复，此时需要除以重复元素的排列组合，此时组合方案数即为:

$$\dfrac{(n-c_0) \cdot (n-1)!}{\prod_{i=0}^9c_i!}$$

枚举哈希表 $dict$ 中合法的字符串 $s$，并统计 $s$ 中字符 $‘0’$ 至 $‘9’$ 出现统计数目，并存储在数组 $cnt$ 中，根据 $cnt$ 按照排列组合计算出 $s$ 可以构成的不同组合的方案数目，即 $s$ 可以构成的**好整数**的数目，此时累加到结果 $ans$ 中，返回最终结果即可。

**排列组合证明**

由于有 $n$ 个位置需要放置 $n$ 个字符，首先考虑字符 $‘0’$，由于它不能放在首位因此只能从后 $n-1$ 位置中选择 $c_0$ 个，此时有 ${n-1 \choose c_0}$ 种方案，接下来考虑字符 $‘1’$，此时它可以从 $n-c_0$ 个位置中选择 $c_1$ 个，此时有 ${n-c_0 \choose c_1}$ 种方案，同理可以推导出 $‘2’,\cdots,‘9’$ 的方案数，因此总的方案数即为：

$$S={n-1 \choose c_0}{n-c_0 \choose c_1}\cdots{n-c_0-c_1\cdots-c_8 \choose c_9}$$

将上式进行展开即为如下：

$$S=\dfrac{(n-1)!}{c_0!(n-1-c_0)!} \cdot \dfrac{(n-c_0)!}{c_1!(n-c_0-c_1)!} \cdots \dfrac{(n-c_0-c_1-\cdots-c_8)!}{c_9!(n-c_0-c_1-\cdots-c_9)!}$$

将上式进行化解即可得到：

$$S=\dfrac{(n-c_0)\cdot (n-1)!}{c_0!c_1!\cdots c_9!0!}=\dfrac{(n-c_0) \cdot (n-1)!}{\prod_{i=0}^9c_i!}$$

**代码**

```C++
class Solution {
public:
    long long countGoodIntegers(int n, int k) {
        unordered_set<string> dict;
        int base = pow(10, (n - 1) / 2);
        int skip = n & 1;
        /* 枚举 n 个数位的回文数 */
        for (int i = base; i < base * 10; i++) {
            string s = to_string(i);
            s += string(s.rbegin() + skip, s.rend());
            long long palindromicInteger = stoll(s);
            /* 如果当前回文数是 k 回文数 */
            if (palindromicInteger % k == 0) {
                sort(s.begin(), s.end());
                dict.emplace(s);
            }
        }

        vector<long long> factorial(n + 1, 1);
        long long ans = 0;
        for (int i = 1; i <= n; i++) {
            factorial[i] = factorial[i - 1] * i;
        }
        for (const string &s : dict) {
            vector<int> cnt(10);
            for (char c : s) {
                cnt[c - '0']++;
            }
            /* 计算排列组合 */
            long long tot = (n - cnt[0]) * factorial[n - 1];
            for (int x : cnt) {
                tot /= factorial[x];
            }
            ans += tot;
        }

        return ans;
    }
};
```

```Java
class Solution {
    public long countGoodIntegers(int n, int k) {
        Set<String> dict = new HashSet<>();
        int base = (int) Math.pow(10, (n - 1) / 2);
        int skip = n & 1;
        /* 枚举 n 个数位的回文数 */
        for (int i = base; i < base * 10; i++) {
            String s = Integer.toString(i);
            s += new StringBuilder(s).reverse().substring(skip);
            long palindromicInteger = Long.parseLong(s);
            /* 如果当前回文数是 k 回文数 */
            if (palindromicInteger % k == 0) {
                char[] chars = s.toCharArray();
                Arrays.sort(chars);
                dict.add(new String(chars));
            }
        }

        long[] factorial = new long[n + 1];
        factorial[0] = 1;
        for (int i = 1; i <= n; i++) {
            factorial[i] = factorial[i - 1] * i;
        }
        long ans = 0;
        for (String s : dict) {
            int[] cnt = new int[10];
            for (char c : s.toCharArray()) {
                cnt[c - '0']++;
            }
            /* 计算排列组合 */
            long tot = (n - cnt[0]) * factorial[n - 1];
            for (int x : cnt) {
                tot /= factorial[x];
            }
            ans += tot;
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public long CountGoodIntegers(int n, int k) {
        var dict = new HashSet<string>();
        int baseVal = (int)Math.Pow(10, (n - 1) / 2);
        int skip = n & 1;
        /* 枚举 n 个数位的回文数 */
        for (int i = baseVal; i < baseVal * 10; i++) {
            string s = i.ToString();
            s += new string(s.Reverse().Skip(skip).ToArray());
            long palindromicInteger = long.Parse(s);
            /* 如果当前回文数是 k 回文数 */
            if (palindromicInteger % k == 0) {
                char[] chars = s.ToCharArray();
                Array.Sort(chars);
                dict.Add(new string(chars));
            }
        }

        long[] factorial = new long[n + 1];
        factorial[0] = 1;
        for (int i = 1; i <= n; i++) {
            factorial[i] = factorial[i - 1] * i;
        }

        long ans = 0;
        foreach (string s in dict) {
            int[] cnt = new int[10];
            foreach (char c in s) {
                cnt[c - '0']++;
            }
            /* 计算排列组合 */
            long tot = (n - cnt[0]) * factorial[n - 1];
            foreach (int x in cnt) {
                tot /= factorial[x];
            }
            ans += tot;
        }

        return ans;
    }
}
```

```Go
func countGoodIntegers(n int, k int) int64 {
    dict := make(map[string]bool)
    base := intPow(10, (n - 1) / 2)
    skip := n & 1
    /* 枚举 n 个数位的回文数 */
    for i := base; i < base * 10; i++ {
        s := strconv.Itoa(i)
        rev := reverseString(s)
        s += rev[skip:]
        palindromicInteger, _ := strconv.ParseInt(s, 10, 64)
        /* 如果当前回文数是 k 回文数 */
        if palindromicInteger % int64(k) == 0 {
            chars := strings.Split(s, "")
            sort.Strings(chars)
            dict[strings.Join(chars, "")] = true
        }
    }

    factorial := make([]int64, n + 1)
    factorial[0] = 1
    for i := 1; i <= n; i++ {
        factorial[i] = factorial[i - 1] * int64(i)
    }

    var ans int64 = 0
    for s := range dict {
        cnt := make([]int, 10)
        for _, c := range s {
            cnt[c - '0']++
        }
        /* 计算排列组合 */
        tot := int64(n - cnt[0]) * factorial[n - 1]
        for _, x := range cnt {
            tot /= factorial[x]
        }
        ans += tot
    }

    return ans
}

func intPow(a, b int) int {
    result := 1
    for i := 0; i < b; i++ {
        result *= a
    }
    return result
}

func reverseString(s string) string {
    runes := []rune(s)
    for i, j := 0, len(runes) - 1; i < j; i, j = i + 1, j - 1 {
        runes[i], runes[j] = runes[j], runes[i]
    }
    return string(runes)
}
```

```Python
class Solution:
    def countGoodIntegers(self, n: int, k: int) -> int:
        dictionary = set()
        base = 10 ** ((n - 1) // 2)
        skip = n & 1
        # 枚举 n 个数位的回文数
        for i in range(base, base * 10):
            s = str(i)
            s += s[::-1][skip:]
            palindromicInteger = int(s)
            # 如果当前回文数是 k 回文数 
            if palindromicInteger % k == 0:
                sorted_s = ''.join(sorted(s))
                dictionary.add(sorted_s)

        fac = [factorial(i) for i in range(n + 1)]
        ans = 0
        for s in dictionary:
            cnt = [0] * 10
            for c in s:
                cnt[int(c)] += 1
            # 计算排列组合
            tot = (n - cnt[0]) * fac[n - 1]
            for x in cnt:
                tot //= fac[x]
            ans += tot

        return ans
```

```C
typedef struct {
    char *key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, const char* key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, const char* key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = strdup(key);
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr->key);  
        free(curr);
    }
}

int compare(const void *a, const void *b) {
    return (*(char*)a - *(char*)b);
}

long long countGoodIntegers(int n, int k) {
    HashItem *dict = NULL;
    int base = (int)pow(10, (n - 1) / 2);
    int skip = n & 1;
    /* 枚举 n 个数位的回文数 */
    for (int i = base; i < base * 10; i++) {
        char s[16];
        sprintf(s, "%d", i);
        int len = strlen(s);
        for (int j = len - 1 - skip; j >= 0; j--) {
            s[len + (len - skip - 1 - j)] = s[j];
        }
        s[2 * len - skip] = '\0';
        long long palindromicInteger = atoll(s);
        /* 如果当前回文数是 k 回文数 */
        if (palindromicInteger % k == 0) {
            qsort(s, strlen(s), sizeof(char), compare);
            hashAddItem(&dict, s);
        }
    }

    long long *factorial = malloc((n + 1) * sizeof(long long));
    factorial[0] = 1;
    for (int i = 1; i <= n; i++) {
        factorial[i] = factorial[i - 1] * i;
    }

    long long ans = 0;
    for (HashItem *pEntry = dict; pEntry; pEntry = pEntry->hh.next) {
        int cnt[10] = {0};
        for (int j = 0; pEntry->key[j] != '\0'; j++) {
            cnt[pEntry->key[j] - '0']++;
        }
        /* 计算排列组合 */
        long long tot = (n - cnt[0]) * factorial[n - 1];
        for (int j = 0; j < 10; j++) {
            tot /= factorial[cnt[j]];
        }
        ans += tot;
    }

    free(factorial);
    hashFree(&dict);
    return ans;
}
```

```JavaScript
var countGoodIntegers = function(n, k) {
    const dict = new Set();
    const base = Math.pow(10, Math.floor((n - 1) / 2));
    const skip = n & 1;
    /* 枚举 n 个数位的回文数 */
    for (let i = base; i < base * 10; i++) {
        let s = i.toString();
        s += s.split('').reverse().slice(skip).join('');
        const palindromicInteger = parseInt(s);
        /* 如果当前回文数是 k 回文数 */
        if (palindromicInteger % k === 0) {
            const sortedS = s.split('').sort().join('');
            dict.add(sortedS);
        }
    }

    const factorial = Array(n + 1).fill(1n);
    for (let i = 1; i <= n; i++) {
        factorial[i] = factorial[i - 1] * BigInt(i);
    }

    let ans = 0n;
    for (const s of dict) {
        const cnt = Array(10).fill(0);
        for (const c of s) {
            cnt[parseInt(c)]++;
        }
        /* 计算排列组合 */
        let tot = BigInt(n - cnt[0]) * factorial[n - 1];
        for (const x of cnt) {
            tot /= factorial[x];
        }
        ans += tot;
    }
    return Number(ans);
};
```

```TypeScript
function countGoodIntegers(n: number, k: number): number {
    const dict = new Set<string>();
    const base = Math.pow(10, Math.floor((n - 1) / 2));
    const skip = n & 1;
    /* 枚举 n 个数位的回文数 */
    for (let i = base; i < base * 10; i++) {
        let s = i.toString();
        s += s.split('').reverse().slice(skip).join('');
        const palindromicInteger = parseInt(s);
        /* 如果当前回文数是 k 回文数 */
        if (palindromicInteger % k === 0) {
            const sortedS = s.split('').sort().join('');
            dict.add(sortedS);
        }
    }

    const factorial: bigint[] = Array(n + 1).fill(1n);
    for (let i = 1; i <= n; i++) {
        factorial[i] = factorial[i - 1] * BigInt(i);
    }

    let ans = 0n;
    for (const s of dict) {
        const cnt = Array(10).fill(0);
        for (const c of s) {
            cnt[parseInt(c)]++;
        }
        /* 计算排列组合 */
        let tot = BigInt(n - cnt[0]) * factorial[n - 1];
        for (const x of cnt) {
            tot /= factorial[x];
        }
        ans += tot;
    }

    return Number(ans);
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn count_good_integers(n: i32, k: i32) -> i64 {
        let mut dict: HashSet<String> = HashSet::new();
        let base = 10i32.pow(((n - 1) / 2) as u32);
        let skip = (n & 1) as usize;
        /* 枚举 n 个数位的回文数 */
        for i in base..base * 10 {
            let s = i.to_string();
            let rev: String = s.chars().rev().skip(skip).collect();
            let combined = format!("{}{}", s, rev);
            let palindromicInteger: i64 = combined.parse().unwrap();
            /* 如果当前回文数是 k 回文数 */
            if palindromicInteger % (k as i64) == 0 {
                let mut sorted_chars: Vec<char> = combined.chars().collect();
                sorted_chars.sort();
                dict.insert(sorted_chars.into_iter().collect());
            }
        }

        let mut factorial = vec![1i64; (n + 1) as usize];
        for i in 1..=n as usize {
            factorial[i] = factorial[i - 1] * (i as i64);
        }

        let mut ans = 0i64;
        for s in dict {
            let mut cnt = vec![0; 10];
            for c in s.chars() {
                cnt[c.to_digit(10).unwrap() as usize] += 1;
            }
            /* 计算排列组合 */
            let mut tot = (n as i64 - cnt[0] as i64) * factorial[(n - 1) as usize];
            for &x in cnt.iter() {
                tot /= factorial[x];
            }
            ans += tot;
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n \times 10^m)$，其中 $n$ 表示给定的数字，$m=\lfloor \frac{n+1}{2} \rfloor$。由于最多有 $10^m$ 个 $k$ 回文数，此时枚举所有的 $k$ 回文数需要的时间为 $O(10^m)$，每个 $k$ 回文数有 $n$ 个数位，需要对 $n$ 个数位进行排序，排序需要的时间为 $O(n \log n)$，计算 $n$ 个阶乘需要的时间为 $O(n)$，因此总的时间复杂度为 $O(n \log n \times 10^m)$。
- 空间复杂度：$O(n \times 10^m)$，其中 $n$ 表示给定的数字，$m=\lfloor \frac{n+1}{2} \rfloor$。需要枚举所有可能的 $k$ 回文数，最多有 $10^m$ 个 $k$ 回文数，每个回文数有 $n$ 个数位，在哈希表中存储需要的空间为 $O(n)$，因此需要的空间为 $O(n \times 10^m)$。
