### [顺次数](https://leetcode.cn/problems/sequential-digits/solutions/101734/shun-ci-shu-by-leetcode-solution/)

#### 方法一：枚举

我们可以枚举所有的「顺次数」，并依次判断它们是否在 $[low,high]$ 的范围内。

具体地，我们首先枚举「顺次数」的最高位数字 $i$，随后递增地枚举「顺次数」的最低位数字 $j$，需要满足 $j>i$。对于每一组 $(i,j)$，我们可以得到其对应的「顺次数」num，如果 $num$ 在 $[low,high]$ 的范围内，就将其加入答案中。

在枚举完所有的「顺次数」后，我们将答案进行排序，就可以得到最终的结果。

```C++
class Solution {
public:
    vector<int> sequentialDigits(int low, int high) {
        vector<int> ans;
        for (int i = 1; i <= 9; ++i) {
            int num = i;
            for (int j = i + 1; j <= 9; ++j) {
                num = num * 10 + j;
                if (num >= low && num <= high) {
                    ans.push_back(num);
                }
            }
        }
        sort(ans.begin(), ans.end());
        return ans;
    }
};
```

```Python
class Solution:
    def sequentialDigits(self, low: int, high: int) -> List[int]:
        ans = list()
        for i in range(1, 10):
            num = i
            for j in range(i + 1, 10):
                num = num * 10 + j
                if low <= num <= high:
                    ans.append(num)
        return sorted(ans)
```

```Java
class Solution {
    public List<Integer> sequentialDigits(int low, int high) {
        List<Integer> ans = new ArrayList<>();
        for (int i = 1; i <= 9; i++) {
            int num = i;
            for (int j = i + 1; j <= 9; j++) {
                num = num * 10 + j;
                if (num >= low && num <= high) {
                    ans.add(num);
                }
            }
        }
        ans.sort((a, b) -> a - b);
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> ans = new List<int>();
        for (int i = 1; i <= 9; i++) {
            int num = i;
            for (int j = i + 1; j <= 9; j++) {
                num = num * 10 + j;
                if (num >= low && num <= high) {
                    ans.Add(num);
                }
            }
        }
        ans.Sort();
        return ans;
    }
}
```

```Go
func sequentialDigits(low int, high int) []int {
    ans := []int{}
    for i := 1; i <= 9; i++ {
        num := i
        for j := i + 1; j <= 9; j++ {
            num = num*10 + j
            if num >= low && num <= high {
                ans = append(ans, num)
            }
        }
    }
    sort.Ints(ans)

    return ans
}
```

```C
int cmp(const void* a, const void* b) {
    return *(int*)a - *(int*)b;
}

int* sequentialDigits(int low, int high, int* returnSize) {
    int* ans = (int*)malloc(36 * sizeof(int));
    int count = 0;
    for (int i = 1; i <= 9; i++) {
        int num = i;
        for (int j = i + 1; j <= 9; j++) {
            num = num * 10 + j;
            if (num >= low && num <= high) {
                ans[count++] = num;
            }
        }
    }
    qsort(ans, count, sizeof(int), cmp);
    *returnSize = count;
    return ans;
}
```

```JavaScript
var sequentialDigits = function(low, high) {
    const ans = [];
    for (let i = 1; i <= 9; i++) {
        let num = i;
        for (let j = i + 1; j <= 9; j++) {
            num = num * 10 + j;
            if (num >= low && num <= high) {
                ans.push(num);
            }
        }
    }
    return ans.sort((a, b) => a - b);
};
```

```TypeScript
function sequentialDigits(low: number, high: number): number[] {
    const ans: number[] = [];
    for (let i = 1; i <= 9; i++) {
        let num = i;
        for (let j = i + 1; j <= 9; j++) {
            num = num * 10 + j;
            if (num >= low && num <= high) {
                ans.push(num);
            }
        }
    }
    return ans.sort((a, b) => a - b);
}
```

```Rust
impl Solution {
    pub fn sequential_digits(low: i32, high: i32) -> Vec<i32> {
        let mut ans = Vec::new();
        for i in 1..=9 {
            let mut num = i;
            for j in (i + 1)..=9 {
                num = num * 10 + j;
                if num >= low && num <= high {
                    ans.push(num);
                }
            }
        }
        ans.sort();
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。根据定义，每一组满足 $1\le i<j\le 9$ 的 $(i,j)$ 就对应了一个「顺次数」，那么「顺次数」的数量为 $\binom{9}{2}=\frac{9\times 8}{2}=36$ 个，可以视作一个常数。因此时间复杂度为 $O(1)$。
- 空间复杂度：$O(1)$。
