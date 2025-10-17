### [执行操作后的最大分割数量](https://leetcode.cn/problems/maximize-the-number-of-partitions-after-operations/solutions/3799989/zhi-xing-cao-zuo-hou-de-zui-da-fen-ge-sh-fwni/)

#### 方法一：位运算 $+$ 预处理 $+$ 枚举

**思路及解法**

由题设可知，我们能够至多修改一处位置的字符，在不进行修改的情况下，我们能够很轻易地通过遍历字符串来计算出分割的数量以及每一个分割的具体区间。

假设我们修改了位置 $i$ 处的字符，易知这个字符一定处于不进行修改的情况下，通过遍历计算出的某一个分割内，这里我们设为第 $t$ 个分割。

由于题设中对字符串的分割是从头到尾进行的，因此在第 $t-1$ 及以前的分割都是确定的，我们修改第 $i$ 位的字符不影响 $t-1$ 及以前的分割。

并且容易知道，在**不进行修改的**情况下，从头到尾遍历字符串进行分割，与从尾到头遍历字符串进行分割，得到的分割数量是相同的。因此我们以从尾到头的视角来看，与以上推论相似的，修改第 $i$ 位的字符不影响 $t+1$ 及以后的分割。

那么对原字符串做出如下划分：以第 $i$ 位为分界，对于左半部分，即第 $0$ 位到第 $i-1$ 位，我们按照从头到尾的方式进行分割，得到的最后一个分割称为第 $i$ 位的**左相邻分割**，简称为**左分割**，**左分割**以前的部分称为**前缀分割**；而对于右半部分，即第 $i+1$ 位到第 $n-1$ 位，我们按照从尾到头的方式进行分割，得到的最后一个分割称为第 $i$ 位的**右相邻分割**，简称为**右分割**，**右分割**以后的部分称为**后缀分割**。

于是对于被修改的，位置为 $i$ 的字符，我们只需要考虑其对**左分割**和**右分割**的影响，分为以下三种情况：

1. 即使修改了位置为 $i$ 的字符，**左分割**、**右分割**内以及第 $i$ 位的不同字符数量仍然不超过 $k$，**左分割**、**右分割**以及第 $i$ 位合并为一个分割，对答案贡献为 $1$。
2. **左分割**的不同字符数量为 $k$，**右分割**中不同字符数量也为 $k$，并且**左分割**与**右分割**中不同字符的数量不超过 $25$，把第 $i$ 位修改为**左分割**、**右分割**中不包含的字符后，**左分割**、**右分割**以及第 $i$ 位能够重组为三个分割，对答案贡献为 $3$。
3. 其他情况对答案贡献为 $2$。

那么我们需要统计在位置 $i$ 处字符的**左分割**与**右分割**所包含的信息，包括：**前缀分割**与**后缀分割**中包含的分割数量，**左分割**与**右分割**的字符掩码以及**左分割**与**右分割**中不同字符数量。

这里使用位运算来表示字符掩码，使用数组 $left$ 和 $right$ 分别表示**左分割**和**右分割**的信息，其中 $left[i]$ 和 $right[i]$ 分别表示位置 $i$ 处字符的**左分割**与**右分割**所包含的信息，$left[i][0]$ 和 $right[i][0]$ 分别表示**前缀分割**与**后缀分割**中包含的分割数量，$left[i][1]$ 和 $right[i][1]$ 分别表示**左分割**与**右分割**的字符掩码，$left[i][2]$ 和 $right[i][2]$ 分别表示**左分割**与**右分割**中不同字符数量。

有了以上信息，我们只需要枚举修改的字符，然后取最大分割数即可。

**代码**

```C++
class Solution {
public:
    int maxPartitionsAfterOperations(string s, int k) {
        int n = s.length();
        vector<vector<int>> left(n, vector<int>(3)), right(n, vector<int>(3));
        int num = 0, mask = 0, count = 0;
        for (int i = 0; i < n - 1; i++) {
            int binary = 1 << (s[i] - 'a');
            if (!(mask & binary)) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            left[i + 1][0] = num;
            left[i + 1][1] = mask;
            left[i + 1][2] = count;
        }

        num = 0, mask = 0, count = 0;
        for (int i = n - 1; i > 0; i--) {
            int binary = 1 << (s[i] - 'a');
            if (!(mask & binary)) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            right[i - 1][0] = num;
            right[i - 1][1] = mask;
            right[i - 1][2] = count;
        }

        int Max = 0;
        for (int i = 0; i < n; i++) {
            int seg = left[i][0] + right[i][0] + 2;
            int totMask = left[i][1] | right[i][1];
            int totCount = 0;
            while (totMask) {
                totMask = totMask & (totMask - 1);
                totCount++;
            }
            if (left[i][2] == k && right[i][2] == k && totCount < 26) {
                seg++;
            } else if (min(totCount + 1, 26) <= k) {
                seg--;
            }
            Max = max(Max, seg);
        }
        return Max;
    }
};
```

```Java
public class Solution {
    public int maxPartitionsAfterOperations(String s, int k) {
        int n = s.length();
        int[][] left = new int[n][3];
        int[][] right = new int[n][3];

        int num = 0, mask = 0, count = 0;
        for (int i = 0; i < n - 1; i++) {
            int binary = 1 << (s.charAt(i) - 'a');
            if ((mask & binary) == 0) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            left[i + 1][0] = num;
            left[i + 1][1] = mask;
            left[i + 1][2] = count;
        }

        num = 0;
        mask = 0;
        count = 0;
        for (int i = n - 1; i > 0; i--) {
            int binary = 1 << (s.charAt(i) - 'a');
            if ((mask & binary) == 0) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            right[i - 1][0] = num;
            right[i - 1][1] = mask;
            right[i - 1][2] = count;
        }

        int maxVal = 0;
        for (int i = 0; i < n; i++) {
            int seg = left[i][0] + right[i][0] + 2;
            int totMask = left[i][1] | right[i][1];
            int totCount = Integer.bitCount(totMask);
            if (left[i][2] == k && right[i][2] == k && totCount < 26) {
                seg++;
            } else if (Math.min(totCount + 1, 26) <= k) {
                seg--;
            }
            maxVal = Math.max(maxVal, seg);
        }
        return maxVal;
    }
}
```

```Python
class Solution:
    def maxPartitionsAfterOperations(self, s: str, k: int) -> int:
        n = len(s)
        left = [[0] * 3 for _ in range(n)]
        right = [[0] * 3 for _ in range(n)]

        num, mask, count = 0, 0, 0
        for i in range(n - 1):
            binary = 1 << (ord(s[i]) - ord("a"))
            if not (mask & binary):
                count += 1
                if count <= k:
                    mask |= binary
                else:
                    num += 1
                    mask = binary
                    count = 1
            left[i + 1][0] = num
            left[i + 1][1] = mask
            left[i + 1][2] = count

        num, mask, count = 0, 0, 0
        for i in range(n - 1, 0, -1):
            binary = 1 << (ord(s[i]) - ord("a"))
            if not (mask & binary):
                count += 1
                if count <= k:
                    mask |= binary
                else:
                    num += 1
                    mask = binary
                    count = 1
            right[i - 1][0] = num
            right[i - 1][1] = mask
            right[i - 1][2] = count

        max_val = 0
        for i in range(n):
            seg = left[i][0] + right[i][0] + 2
            tot_mask = left[i][1] | right[i][1]
            tot_count = bin(tot_mask).count("1")
            if left[i][2] == k and right[i][2] == k and tot_count < 26:
                seg += 1
            elif min(tot_count + 1, 26) <= k:
                seg -= 1
            max_val = max(max_val, seg)
        return max_val
```

```CSharp
public class Solution {
    public int MaxPartitionsAfterOperations(string s, int k) {
        int n = s.Length;
        int[][] left = new int[n][];
        int[][] right = new int[n][];
        
        for (int i = 0; i < n; i++) {
            left[i] = new int[3];
            right[i] = new int[3];
        }
        
        int num = 0, mask = 0, count = 0;
        for (int i = 0; i < n - 1; i++) {
            int binary = 1 << (s[i] - 'a');
            if ((mask & binary) == 0) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            left[i + 1][0] = num;
            left[i + 1][1] = mask;
            left[i + 1][2] = count;
        }

        num = 0; mask = 0; count = 0;
        for (int i = n - 1; i > 0; i--) {
            int binary = 1 << (s[i] - 'a');
            if ((mask & binary) == 0) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            right[i - 1][0] = num;
            right[i - 1][1] = mask;
            right[i - 1][2] = count;
        }

        int max = 0;
        for (int i = 0; i < n; i++) {
            int seg = left[i][0] + right[i][0] + 2;
            int totMask = left[i][1] | right[i][1];
            int totCount = 0;
            while (totMask != 0) {
                totMask = totMask & (totMask - 1);
                totCount++;
            }
            if (left[i][2] == k && right[i][2] == k && totCount < 26) {
                seg++;
            } else if (Math.Min(totCount + 1, 26) <= k) {
                seg--;
            }
            max = Math.Max(max, seg);
        }
        return max;
    }
}
```

```Go
func maxPartitionsAfterOperations(s string, k int) int {
    n := len(s)
    left := make([][3]int, n)
    right := make([][3]int, n)
    
    num, mask, count := 0, 0, 0
    for i := 0; i < n-1; i++ {
        binary := 1 << (s[i] - 'a')
        if mask & binary == 0 {
            count++
            if count <= k {
                mask |= binary
            } else {
                num++
                mask = binary
                count = 1
            }
        }
        left[i+1][0] = num
        left[i+1][1] = mask
        left[i+1][2] = count
    }

    num, mask, count = 0, 0, 0
    for i := n-1; i > 0; i-- {
        binary := 1 << (s[i] - 'a')
        if mask & binary == 0 {
            count++
            if count <= k {
                mask |= binary
            } else {
                num++
                mask = binary
                count = 1
            }
        }
        right[i-1][0] = num
        right[i-1][1] = mask
        right[i-1][2] = count
    }

    maxVal := 0
    for i := 0; i < n; i++ {
        seg := left[i][0] + right[i][0] + 2
        totMask := left[i][1] | right[i][1]
        totCount := 0
        for totMask != 0 {
            totMask = totMask & (totMask - 1)
            totCount++
        }
        if left[i][2] == k && right[i][2] == k && totCount < 26 {
            seg++
        } else if min(totCount+1, 26) <= k {
            seg--
        }
        if seg > maxVal {
            maxVal = seg
        }
    }
    return maxVal
}
```

```C
int maxPartitionsAfterOperations(char* s, int k) {
    int n = strlen(s);
    int** left = (int**)malloc(n * sizeof(int*));
    int** right = (int**)malloc(n * sizeof(int*));
    
    for (int i = 0; i < n; i++) {
        left[i] = (int*)malloc(3 * sizeof(int));
        right[i] = (int*)malloc(3 * sizeof(int));
        memset(left[i], 0, sizeof(int) * 3);
        memset(right[i], 0, sizeof(int) * 3);
    }
    
    int num = 0, mask = 0, count = 0;
    for (int i = 0; i < n - 1; i++) {
        int binary = 1 << (s[i] - 'a');
        if (!(mask & binary)) {
            count++;
            if (count <= k) {
                mask |= binary;
            } else {
                num++;
                mask = binary;
                count = 1;
            }
        }
        left[i + 1][0] = num;
        left[i + 1][1] = mask;
        left[i + 1][2] = count;
    }

    num = 0; mask = 0; count = 0;
    for (int i = n - 1; i > 0; i--) {
        int binary = 1 << (s[i] - 'a');
        if (!(mask & binary)) {
            count++;
            if (count <= k) {
                mask |= binary;
            } else {
                num++;
                mask = binary;
                count = 1;
            }
        }
        right[i - 1][0] = num;
        right[i - 1][1] = mask;
        right[i - 1][2] = count;
    }

    int max = 0;
    for (int i = 0; i < n; i++) {
        int seg = left[i][0] + right[i][0] + 2;
        int totMask = left[i][1] | right[i][1];
        int totCount = 0;
        while (totMask) {
            totMask = totMask & (totMask - 1);
            totCount++;
        }
        if (left[i][2] == k && right[i][2] == k && totCount < 26) {
            seg++;
        } else {
            int minVal = fmin(totCount + 1, 26);
            if (minVal <= k) {
                seg--;
            }
        }
        max = fmax(max, seg);
    }
    
    for (int i = 0; i < n; i++) {
        free(left[i]);
        free(right[i]);
    }
    free(left);
    free(right);
    
    return max;
}
```

```JavaScript
var maxPartitionsAfterOperations = function(s, k) {
    const n = s.length;
    const left = Array(n).fill().map(() => Array(3).fill(0));
    const right = Array(n).fill().map(() => Array(3).fill(0));
    
    let num = 0, mask = 0, count = 0;
    for (let i = 0; i < n - 1; i++) {
        const binary = 1 << (s.charCodeAt(i) - 97);
        if (!(mask & binary)) {
            count++;
            if (count <= k) {
                mask |= binary;
            } else {
                num++;
                mask = binary;
                count = 1;
            }
        }
        left[i + 1][0] = num;
        left[i + 1][1] = mask;
        left[i + 1][2] = count;
    }

    num = 0; mask = 0; count = 0;
    for (let i = n - 1; i > 0; i--) {
        const binary = 1 << (s.charCodeAt(i) - 97);
        if (!(mask & binary)) {
            count++;
            if (count <= k) {
                mask |= binary;
            } else {
                num++;
                mask = binary;
                count = 1;
            }
        }
        right[i - 1][0] = num;
        right[i - 1][1] = mask;
        right[i - 1][2] = count;
    }

    let max = 0;
    for (let i = 0; i < n; i++) {
        let seg = left[i][0] + right[i][0] + 2;
        let totMask = left[i][1] | right[i][1];
        let totCount = 0;
        while (totMask) {
            totMask = totMask & (totMask - 1);
            totCount++;
        }
        if (left[i][2] === k && right[i][2] === k && totCount < 26) {
            seg++;
        } else if (Math.min(totCount + 1, 26) <= k) {
            seg--;
        }
        max = Math.max(max, seg);
    }
    return max;
};
```

```TypeScript
function maxPartitionsAfterOperations(s: string, k: number): number {
    const n: number = s.length;
    const left: number[][] = Array(n).fill(0).map(() => Array(3).fill(0));
    const right: number[][] = Array(n).fill(0).map(() => Array(3).fill(0));
    
    let num: number = 0, mask: number = 0, count: number = 0;
    for (let i = 0; i < n - 1; i++) {
        const binary: number = 1 << (s.charCodeAt(i) - 97);
        if (!(mask & binary)) {
            count++;
            if (count <= k) {
                mask |= binary;
            } else {
                num++;
                mask = binary;
                count = 1;
            }
        }
        left[i + 1][0] = num;
        left[i + 1][1] = mask;
        left[i + 1][2] = count;
    }

    num = 0; mask = 0; count = 0;
    for (let i = n - 1; i > 0; i--) {
        const binary: number = 1 << (s.charCodeAt(i) - 97);
        if (!(mask & binary)) {
            count++;
            if (count <= k) {
                mask |= binary;
            } else {
                num++;
                mask = binary;
                count = 1;
            }
        }
        right[i - 1][0] = num;
        right[i - 1][1] = mask;
        right[i - 1][2] = count;
    }

    let max: number = 0;
    for (let i = 0; i < n; i++) {
        let seg: number = left[i][0] + right[i][0] + 2;
        let totMask: number = left[i][1] | right[i][1];
        let totCount: number = 0;
        while (totMask) {
            totMask = totMask & (totMask - 1);
            totCount++;
        }
        if (left[i][2] === k && right[i][2] === k && totCount < 26) {
            seg++;
        } else if (Math.min(totCount + 1, 26) <= k) {
            seg--;
        }
        max = Math.max(max, seg);
    }
    return max;
}
```

```Rust
impl Solution {
    pub fn max_partitions_after_operations(s: String, k: i32) -> i32 {
        let n = s.len();
        let mut left = vec![[0; 3]; n];
        let mut right = vec![[0; 3]; n];
        let bytes = s.as_bytes();
        
        let (mut num, mut mask, mut count) = (0, 0, 0);
        for i in 0..n-1 {
            let binary = 1 << (bytes[i] - b'a');
            if mask & binary == 0 {
                count += 1;
                if count <= k {
                    mask |= binary;
                } else {
                    num += 1;
                    mask = binary;
                    count = 1;
                }
            }
            left[i + 1][0] = num;
            left[i + 1][1] = mask;
            left[i + 1][2] = count;
        }

        (num, mask, count) = (0, 0, 0);
        for i in (1..n).rev() {
            let binary = 1 << (bytes[i] - b'a');
            if mask & binary == 0 {
                count += 1;
                if count <= k {
                    mask |= binary;
                } else {
                    num += 1;
                    mask = binary;
                    count = 1;
                }
            }
            right[i - 1][0] = num;
            right[i - 1][1] = mask;
            right[i - 1][2] = count;
        }

        let mut max_val = 0;
        for i in 0..n {
            let mut seg = left[i][0] + right[i][0] + 2;
            let tot_mask = left[i][1] | right[i][1];
            let tot_count = tot_mask.count_ones() as i32;
            
            if left[i][2] == k && right[i][2] == k && tot_count < 26 {
                seg += 1;
            } else if (tot_count + 1).min(26) <= k {
                seg -= 1;
            }
            max_val = max_val.max(seg);
        }
        max_val
    }
}
```

**复杂度分析**

- 时间复杂度：$O(M\times n)$，其中 $n$ 为字符串 $s$ 的长度，$M$ 为 $26$。
- 空间复杂度：$O(n)$，使用了数组 $left$ 和 $right$ 分别表示**左分割**与**右分割**中的信息，两个数组大小正比于 $n$。
