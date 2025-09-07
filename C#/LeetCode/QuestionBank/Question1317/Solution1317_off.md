### [将整数转换为两个无零整数的和](https://leetcode.cn/problems/convert-integer-to-the-sum-of-two-no-zero-integers/solutions/101774/jiang-zheng-shu-zhuan-huan-wei-liang-ge-wu-ling-3/)

#### 方法一：枚举

由于题目中给出的 `n` 的范围 `[2, 10000]` 较小，因此我们可以直接在 `[1, n)` 的范围内枚举 `A`，并通过 `n - A` 得到 `B`，再判断 `A` 和 `B` 是否均不包含 `0` 即可。

```C++
class Solution {
public:
    vector<int> getNoZeroIntegers(int n) {
        for (int A = 1; A < n; ++A) {
            int B = n - A;
            if ((to_string(A) + to_string(B)).find('0') == string::npos) {
                return {A, B};
            }
        }
        return {};
    }
};
```

```Python
class Solution:
    def getNoZeroIntegers(self, n: int) -> List[int]:
        for A in range(1, n):
            B = n - A
            if '0' not in str(A) + str(B):
                return [A, B]
        return []
```

```Java
class Solution {
    public int[] getNoZeroIntegers(int n) {
        for (int A = 1; A < n; ++A) {
            int B = n - A;
            if (!String.valueOf(A).contains("0") && !String.valueOf(B).contains("0")) {
                return new int[]{A, B};
            }
        }
        return new int[0];
    }
}
```

```CSharp
public class Solution {
    public int[] GetNoZeroIntegers(int n) {
        for (int A = 1; A < n; ++A) {
            int B = n - A;
            if (!A.ToString().Contains("0") && !B.ToString().Contains("0")) {
                return new int[] { A, B };
            }
        }
        return new int[0];
    }
}
```

```Go
func getNoZeroIntegers(n int) []int {
    for A := 1; A < n; A++ {
        B := n - A
        if !strings.Contains(strconv.Itoa(A), "0") && !strings.Contains(strconv.Itoa(B), "0") {
            return []int{A, B}
        }
    }
    return []int{}
}
```

```C
int* getNoZeroIntegers(int n, int* returnSize) {
    char aStr[8], bStr[8];
    for (int A = 1; A < n; ++A) {
        int B = n - A;
        sprintf(aStr, "%d", A);
        sprintf(bStr, "%d", B);
        if (strchr(aStr, '0') == NULL && strchr(bStr, '0') == NULL) {
            int* result = malloc(2 * sizeof(int));
            *returnSize = 2;
            result[0] = A;
            result[1] = B;
            return result;
        }
    }
    *returnSize = 0;
    return NULL;
}
```

```JavaScript
var getNoZeroIntegers = function(n) {
    for (let A = 1; A < n; A++) {
        const B = n - A;
        if (!A.toString().includes('0') && !B.toString().includes('0')) {
            return [A, B];
        }
    }
    return [];
};
```

```TypeScript
function getNoZeroIntegers(n: number): number[] {
    for (let A = 1; A < n; A++) {
        const B = n - A;
        if (!A.toString().includes('0') && !B.toString().includes('0')) {
            return [A, B];
        }
    }
    return [];
}
```

```Rust
impl Solution {
    pub fn get_no_zero_integers(n: i32) -> Vec<i32> {
        for A in 1..n {
            let B = n - A;
            if !A.to_string().contains('0') && !B.to_string().contains('0') {
                return vec![A, B];
            }
        }
        vec![]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(NlogN)$，枚举 `A` 的时间复杂度为 $O(N)$，判断 `A` 和 `B` 是否均不包含 `0` 的时间复杂度为 $O(logN)$，即 `A` 与 `B` 的位数之和。
- 空间复杂度：$O(1)$。
