### [和为奇数的子数组数目](https://leetcode.cn/problems/number-of-sub-arrays-with-odd-sum/solutions/357914/he-wei-qi-shu-de-zi-shu-zu-shu-mu-by-leetcode-solu/)

#### 方法一：前缀和 + 数学

这道题要求返回和为奇数的子数组数目。为了快速计算任意子数组的和，可以通过维护前缀和的方式。这道题只需要知道每个子数组的和的奇偶性，不需要知道子数组的和的具体值，因此不需要维护每一个前缀和，只需要维护奇数前缀和的数量与偶数前缀和的数量。

分别使用 $odd$ 和 $even$ 表示奇数前缀和的数量与偶数前缀和的数量。初始时，$odd=0$，even=1，因为空的前缀的和是 $0$，也是偶数前缀和。

遍历数组 $arr$ 并计算前缀和。对于下标 $i$ 的位置的前缀和（即 $arr[0]+arr[1]+\dots +arr[i]$），根据奇偶性进行如下操作：

- 当下标 $i$ 的位置的前缀和是偶数时，如果下标 $j$ 满足 $j<i$ 且下标 $j$ 的位置的前缀和是奇数，则从下标 $j+1$ 到下标 $i$ 的子数组的和是奇数，因此，以下标 $i$ 结尾的子数组中，和为奇数的子数组的数量即为奇数前缀和的数量 $odd$；
- 当下标 $i$ 的位置的前缀和是奇数时，如果下标 $j$ 满足 $j<i$ 且下标 $j$ 的位置的前缀和是偶数，则从下标 $j+1$ 到下标 $i$ 的子数组的和是奇数，因此，以下标 $i$ 结尾的子数组中，和为奇数的子数组的数量即为偶数前缀和的数量 $even$。

上述下标 $j$ 的最小可能取值为 $-1$，当 $j=-1$ 时表示下标 $j$ 的位置的前缀为空。

在更新和为奇数的子数组数量之后，需要根据下标 $i$ 的位置的前缀和的奇偶性更新 $odd$ 或 $even$ 的值。如果前缀和是奇数，则 $odd$ 的值加 $1$；如果前缀和是偶数，则 $even$ 的值加 $1$。

```Java
class Solution {
    public int numOfSubarrays(int[] arr) {
        final int MODULO = 1000000007;
        int odd = 0, even = 1;
        int subarrays = 0;
        int sum = 0;
        int length = arr.length;
        for (int i = 0; i < length; i++) {
            sum += arr[i];
            subarrays = (subarrays + (sum % 2 == 0 ? odd : even)) % MODULO;
            if (sum % 2 == 0) {
                even++;
            } else {
                odd++;
            }
        }
        return subarrays;
    }
}
```

```C++
class Solution {
public:
    int numOfSubarrays(vector<int>& arr) {
        const int MODULO = 1000000007;
        int odd = 0, even = 1;
        int subarrays = 0;
        int sum = 0;
        int length = arr.size();
        for (int i = 0; i < length; i++) {
            sum += arr[i];
            subarrays = (subarrays + (sum % 2 == 0 ? odd : even)) % MODULO;
            if (sum % 2 == 0) {
                even++;
            } else {
                odd++;
            }
        }
        return subarrays;
    }
};
```

```Python
class Solution:
    def numOfSubarrays(self, arr: List[int]) -> int:
        MODULO = 10**9 + 7
        odd, even = 0, 1
        subarrays = 0
        total = 0

        for x in arr:
            total += x
            subarrays += (odd if total % 2 == 0 else even)
            if total % 2 == 0:
                even += 1
            else:
                odd += 1

        return subarrays % MODULO
```

```Java
class Solution {
    public int numOfSubarrays(int[] arr) {
        final int MODULO = 1_000_000_007;
        int odd = 0, even = 1;
        int subarrays = 0;
        int total = 0;

        for (int x : arr) {
            total += x;
            if (total % 2 == 0) {
                subarrays = (subarrays + odd) % MODULO;
                even++;
            } else {
                subarrays = (subarrays + even) % MODULO;
                odd++;
            }
        }

        return subarrays % MODULO;
    }
}
```

```CSharp
public class Solution {
    public int NumOfSubarrays(int[] arr) {
        const int MODULO = 1_000_000_007;
        int odd = 0, even = 1;
        int subarrays = 0;
        int total = 0;

        foreach (int x in arr) {
            total += x;
            if (total % 2 == 0) {
                subarrays = (subarrays + odd) % MODULO;
                even++;
            } else {
                subarrays = (subarrays + even) % MODULO;
                odd++;
            }
        }

        return subarrays % MODULO;
    }
}
```

```Go
func numOfSubarrays(arr []int) int {
    const MODULO = 1000000007
    odd, even := 0, 1
    subarrays := 0
    total := 0

    for _, x := range arr {
        total += x
        if total % 2 == 0 {
            subarrays = (subarrays + odd) % MODULO
            even++
        } else {
            subarrays = (subarrays + even) % MODULO
            odd++
        }
    }

    return subarrays % MODULO
}
```

```C
int numOfSubarrays(int* arr, int arrSize) {
    const int MODULO = 1000000007;
    int odd = 0, even = 1;
    int subarrays = 0;
    int total = 0;

    for (int i = 0; i < arrSize; i++) {
        total += arr[i];
        if (total % 2 == 0) {
            subarrays = (subarrays + odd) % MODULO;
            even++;
        } else {
            subarrays = (subarrays + even) % MODULO;
            odd++;
        }
    }

    return subarrays % MODULO;
}
```

```JavaScript
var numOfSubarrays = function(arr) {
    const MODULO = 1000000007;
    let odd = 0, even = 1;
    let subarrays = 0;
    let total = 0;

    for (const x of arr) {
        total += x;
        if (total % 2 === 0) {
            subarrays = (subarrays + odd) % MODULO;
            even++;
        } else {
            subarrays = (subarrays + even) % MODULO;
            odd++;
        }
    }

    return subarrays % MODULO;
};
```

```TypeScript
function numOfSubarrays(arr: number[]): number {
    const MODULO = 1000000007;
    let odd = 0, even = 1;
    let subarrays = 0;
    let total = 0;

    for (const x of arr) {
        total += x;
        if (total % 2 === 0) {
            subarrays = (subarrays + odd) % MODULO;
            even++;
        } else {
            subarrays = (subarrays + even) % MODULO;
            odd++;
        }
    }

    return subarrays % MODULO;
}
```

```Rust
impl Solution {
    pub fn num_of_subarrays(arr: Vec<i32>) -> i32 {
        const MODULO: i32 = 1_000_000_007;
        let mut odd = 0;
        let mut even = 1;
        let mut subarrays = 0;
        let mut total = 0;

        for &x in arr.iter() {
            total += x;
            if total % 2 == 0 {
                subarrays = (subarrays + odd) % MODULO;
                even += 1;
            } else {
                subarrays = (subarrays + even) % MODULO;
                odd += 1;
            }
        }

        subarrays % MODULO
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。遍历数组一次，对于数组中的每个元素，更新前缀和、和为奇数的子数组数目以及 $odd$ 和 $even$ 的值的时间复杂度都是 $O(1)$，因此总时间复杂度是 $O(n)$。
- 空间复杂度：$O(1)$。只需要维护常量的额外空间。
