### [最长公共前缀的长度](https://leetcode.cn/problems/find-the-length-of-the-longest-common-prefix/solutions/3965476/zui-chang-gong-gong-qian-zhui-de-chang-d-w7go/)

#### 方法一：枚举前缀 + 哈希表

**思路与算法**

一个整数的前缀可以通过不断去掉末位数字得到，对应的操作是不断对 $10$ 做整数除法。例如整数 $1234$ 的所有前缀为 $1234,123,12,1$。

我们先遍历 $arr_1$，对其中每个元素不断除以 $10$，将得到的所有前缀存入哈希表 $seen$。

随后遍历 $arr_2$，对其中每个元素同样不断除以 $10$ 枚举前缀。若当前前缀在 $seen$ 中出现过，说明 $arr_1$ 和 $arr_2$ 中存在一对数拥有该公共前缀，用它更新最大公共前缀值 $best$。

最终 $best$ 的十进制位数即为答案。若 $best$ 为 $0$，说明不存在公共前缀，返回 $0$。

**代码**

```C++
class Solution {
public:
    int longestCommonPrefix(vector<int>& arr1, vector<int>& arr2) {
        unordered_set<int> seen;
        for (int num: arr1) {
            while (num > 0) {
                seen.insert(num);
                num /= 10;
            }
        }

        int best = 0;
        for (int num: arr2) {
            while (num > 0) {
                if (seen.count(num)) {
                    best = max(best, num);
                }
                num /= 10;
            }
        }

        return best == 0 ? 0 : to_string(best).size();
    }
};
```

```Python
class Solution:
    def longestCommonPrefix(self, arr1: List[int], arr2: List[int]) -> int:
        seen = set()
        for num in arr1:
            while num:
                seen.add(num)
                num //= 10

        best = 0
        for num in arr2:
            while num:
                if num in seen:
                    best = max(best, num)
                num //= 10

        return 0 if best == 0 else len(str(best))
```

```Java
class Solution {
    public int longestCommonPrefix(int[] arr1, int[] arr2) {
        Set<Integer> seen = new HashSet<>();

        for (int num : arr1) {
            while (num > 0) {
                seen.add(num);
                num /= 10;
            }
        }

        int best = 0;
        for (int num : arr2) {
            while (num > 0) {
                if (seen.contains(num)) {
                    best = Math.max(best, num);
                }
                num /= 10;
            }
        }

        return best == 0 ? 0 : String.valueOf(best).length();
    }
}
```

```CSharp
public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in arr1) {
            int current = num;
            while (current > 0) {
                seen.Add(current);
                current /= 10;
            }
        }

        int best = 0;
        foreach (int num in arr2) {
            int current = num;
            while (current > 0) {
                if (seen.Contains(current)) {
                    best = Math.Max(best, current);
                }
                current /= 10;
            }
        }

        return best == 0 ? 0 : best.ToString().Length;
    }
}
```

```Go
func longestCommonPrefix(arr1 []int, arr2 []int) int {
    seen := make(map[int]bool)

    for _, num := range arr1 {
        current := num
        for current > 0 {
            seen[current] = true
            current /= 10
        }
    }

    best := 0
    for _, num := range arr2 {
        current := num
        for current > 0 {
            if seen[current] {
                best = max(best, current)
            }
            current /= 10
        }
    }

    if best == 0 {
        return 0
    }
    return len(fmt.Sprintf("%d", best))
}
```

```C
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

void hashFreeAll(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

int getDigitCount(int num) {
    if (num == 0) return 1;
    int count = 0;
    while (num > 0) {
        count++;
        num /= 10;
    }
    return count;
}

int longestCommonPrefix(int* arr1, int arr1Size, int* arr2, int arr2Size) {
    HashItem *seen = NULL;
    for (int i = 0; i < arr1Size; i++) {
        int num = arr1[i];
        while (num > 0) {
            hashAddItem(&seen, num);
            num /= 10;
        }
    }

    int best = 0;
    for (int i = 0; i < arr2Size; i++) {
        int num = arr2[i];
        while (num > 0) {
            if (hashFindItem(&seen, num)) {
                best = fmax(best, num);
                break;
            }
            num /= 10;
        }
    }

    int result = 0;
    if (best != 0) {
        result = getDigitCount(best);
    }

    hashFreeAll(&seen);

    return result;
}
```

```JavaScript
var longestCommonPrefix = function(arr1, arr2) {
    const seen = new Set();

    for (let num of arr1) {
        while (num > 0) {
            seen.add(num);
            num = Math.floor(num / 10);
        }
    }

    let best = 0;
    for (let num of arr2) {
        while (num > 0) {
            if (seen.has(num)) {
                best = Math.max(best, num);
            }
            num = Math.floor(num / 10);
        }
    }

    return best === 0 ? 0 : String(best).length;
};
```

```TypeScript
function longestCommonPrefix(arr1: number[], arr2: number[]): number {
    const seen = new Set<number>();

    for (let num of arr1) {
        while (num > 0) {
            seen.add(num);
            num = Math.floor(num / 10);
        }
    }

    let best = 0;
    for (let num of arr2) {
        while (num > 0) {
            if (seen.has(num)) {
                best = Math.max(best, num);
            }
            num = Math.floor(num / 10);
        }
    }

    return best === 0 ? 0 : String(best).length;
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn longest_common_prefix(arr1: Vec<i32>, arr2: Vec<i32>) -> i32 {
        let mut seen = HashSet::new();

        for mut num in arr1 {
            while num > 0 {
                seen.insert(num);
                num /= 10;
            }
        }

        let mut best = 0;
        for mut num in arr2 {
            while num > 0 {
                if seen.contains(&num) {
                    best = best.max(num);
                }
                num /= 10;
            }
        }

        if best == 0 {
            0
        } else {
            best.to_string().len() as i32
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+m)\log C)$，其中 $n$ 和 $m$ 分别是数组 $arr_1$ 和 $arr_2$ 的长度，$C$ 是数组元素的范围。每个元素最多有 $O(\log C)$ 个前缀，哈希表单次操作的平均复杂度为 $O(1)$。
- 空间复杂度：$O(n\log C)$，即为哈希表 $seen$ 需要使用的空间。
