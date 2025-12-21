### [删列造序 II](https://leetcode.cn/problems/delete-columns-to-make-sorted-ii/solutions/3848648/shan-lie-zao-xu-ii-by-leetcode-solution-ufts/)

#### 方法一：贪心

**想法**

针对该问题，我们考虑保留哪些列去获得最终的有序结果，而不是删除哪些列。

如果第一列不是字典序排列的，我们就必须删除它。

否则，我们需要讨论是否保留第一列。会出现以下两种情况：

- 如果我们不保留第一列，则最后答案的行需要保证有序；
- 如果我们保留了第一列，那么最终答案的行（除去第一列）只需要在第一个字母相同的情况下需要保证有序。
    这个描述很难理解，看下面的例子：
    假设我们有 `A = ["axx", "ayy", "baa", "bbb", "bcc"]`，当我们保留第一列之后，最终行变成 `R = ["xx", "yy", "aa", "bb", "cc"]`，对于这些行，并不要求所有有序（`R[0] <= R[1] <= R[2] <= R[3] <= R[4]`），只需要达到一个较弱的要求：对于第一个字母相同的行保证有序（`R[0] <= R[1]` 和 `R[2] <= R[3] <= R[4]`）。

现在，我们只将结论应用到第一列，但实际上这个结论对每列都合适。如果我们不能取用第一列，就删除它。否则，我们就取用第一列，因为无论如何都可以使要求更简单。

**算法**

首先没有任意列保留，对于每一列：如果保留后结果保持有序，就保留这一列；否则删除它。

```Java
class Solution {
    public int minDeletionSize(String[] A) {
        int N = A.length;
        int W = A[0].length();
        int ans = 0;

        // cur : all rows we have written
        // For example, with A = ["abc","def","ghi"] we might have
        // cur = ["ab", "de", "gh"].
        String[] cur = new String[N];
        for (int j = 0; j < W; ++j) {
            // cur2 : What we potentially can write, including the
            //        newest column col = [A[i][j] for i]
            // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
            // then cur2 = ["abc","def","ghi"].
            String[] cur2 = Arrays.copyOf(cur, N);
            for (int i = 0; i < N; ++i) {
                cur2[i] += A[i].charAt(j);
            }
            if (isSorted(cur2)) {
                cur = cur2;
            } else {
                ans++;
            }
        }

        return ans;
    }

    public boolean isSorted(String[] A) {
        for (int i = 0; i < A.length - 1; ++i) {
            if (A[i].compareTo(A[i+1]) > 0) {
                return false;
            }
        }

        return true;
    }
}
```

```Python
class Solution:
    def minDeletionSize(self, A):
        def is_sorted(A):
            return all(A[i] <= A[i + 1] for i in range(len(A) - 1))

        ans = 0
        # cur : all rows we have written
        # For example, with A = ["abc","def","ghi"] we might have
        # cur = ["ab", "de", "gh"].
        cur = [""] * len(A)

        for col in zip(*A):
            # cur2 : What we potentially can write, including the
            #        newest column 'col'.
            # Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
            # then cur2 = ["abc","def","ghi"].
            cur2 = cur[:]
            for i, letter in enumerate(col):
                cur2[i] = cur2[i] + letter

            if is_sorted(cur2):
                cur = cur2
            else:
                ans += 1

        return ans
```

```C++
class Solution {
public:
    int minDeletionSize(vector<string>& A) {
        int N = A.size();
        int W = A[0].size();
        int ans = 0;
        // cur : all rows we have written
        // For example, with A = ["abc","def","ghi"] we might have
        // cur = ["ab", "de", "gh"].
        vector<string> cur(N);
        for (int j = 0; j < W; ++j) {
            // cur2 : What we potentially can write, including the
            //        newest column col = [A[i][j] for i]
            // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
            // then cur2 = ["abc","def","ghi"].
            vector<string> cur2 = cur;
            for (int i = 0; i < N; ++i) {
                cur2[i] += A[i][j];
            }
            if (isSorted(cur2)) {
                cur = cur2;
            } else {
                ans++;
            }
        }

        return ans;
    }

    bool isSorted(vector<string>& A) {
        for (int i = 0; i < A.size() - 1; ++i) {
            if (A[i] > A[i + 1]) {
                return false;
            }
        }
        return true;
    }
};
```

```CSharp
public class Solution {
    public int MinDeletionSize(string[] A) {
        int N = A.Length;
        int W = A[0].Length;
        int ans = 0;

        // cur : all rows we have written
        // For example, with A = ["abc","def","ghi"] we might have
        // cur = ["ab", "de", "gh"].
        string[] cur = new string[N];
        for (int j = 0; j < W; ++j) {
            // cur2 : What we potentially can write, including the
            //        newest column col = [A[i][j] for i]
            // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
            // then cur2 = ["abc","def","ghi"].
            string[] cur2 = (string[])cur.Clone();
            for (int i = 0; i < N; ++i) {
                cur2[i] += A[i][j];
            }
            if (IsSorted(cur2)) {
                cur = cur2;
            } else {
                ans++;
            }
        }

        return ans;
    }

    public bool IsSorted(string[] A) {
        for (int i = 0; i < A.Length - 1; ++i) {
            if (string.Compare(A[i], A[i+1]) > 0) {
                return false;
            }
        }
        return true;
    }
}
```

```Go
func minDeletionSize(A []string) int {
    N := len(A)
    W := len(A[0])
    ans := 0
    // cur : all rows we have written
    // For example, with A = ["abc","def","ghi"] we might have
    // cur = ["ab", "de", "gh"].
    cur := make([]string, N)
    for j := 0; j < W; j++ {
        // cur2 : What we potentially can write, including the
        //        newest column col = [A[i][j] for i]
        // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
        // then cur2 = ["abc","def","ghi"].
        cur2 := make([]string, N)
        copy(cur2, cur)
        for i := 0; i < N; i++ {
            cur2[i] += string(A[i][j])
        }
        if isSorted(cur2) {
            cur = cur2
        } else {
            ans++
        }
    }

    return ans
}

func isSorted(A []string) bool {
    for i := 0; i < len(A) - 1; i++ {
        if A[i] > A[i + 1] {
            return false
        }
    }
    return true
}
```

```C
int isSorted(char** A, int N) {
    for (int i = 0; i < N - 1; ++i) {
        if (strcmp(A[i], A[i + 1]) > 0) {
            return 0;
        }
    }
    return 1;
}

int minDeletionSize(char** A, int ASize) {
    int N = ASize;
    int W = strlen(A[0]);
    int ans = 0;
    // cur : all rows we have written
    // For example, with A = ["abc","def","ghi"] we might have
    // cur = ["ab", "de", "gh"].
    char** cur = (char**)malloc(N * sizeof(char*));
    for (int i = 0; i < N; i++) {
        cur[i] = (char*)malloc((W + 1) * sizeof(char));
        cur[i][0] = '\0';
    }

    for (int j = 0; j < W; ++j) {
        // cur2 : What we potentially can write, including the
        //        newest column col = [A[i][j] for i]
        // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
        // then cur2 = ["abc","def","ghi"].
        char** cur2 = (char**)malloc(N * sizeof(char*));
        for (int i = 0; i < N; i++) {
            cur2[i] = (char*)malloc((W + 1) * sizeof(char));
            strcpy(cur2[i], cur[i]);
            int len = strlen(cur2[i]);
            cur2[i][len] = A[i][j];
            cur2[i][len + 1] = '\0';
        }

        if (isSorted(cur2, N)) {
            for (int i = 0; i < N; i++) {
                free(cur[i]);
                cur[i] = cur2[i];
            }
            free(cur2);
        } else {
            ans++;
            for (int i = 0; i < N; i++) {
                free(cur2[i]);
            }
            free(cur2);
        }
    }

    // Free memory
    for (int i = 0; i < N; i++) {
        free(cur[i]);
    }
    free(cur);

    return ans;
}
```

```JavaScript
var minDeletionSize = function(A) {
    const N = A.length;
    const W = A[0].length;
    let ans = 0;
    // cur : all rows we have written
    // For example, with A = ["abc","def","ghi"] we might have
    // cur = ["ab", "de", "gh"].
    let cur = new Array(N).fill("");
    for (let j = 0; j < W; ++j) {
        // cur2 : What we potentially can write, including the
        //        newest column col = [A[i][j] for i]
        // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
        // then cur2 = ["abc","def","ghi"].
        let cur2 = [...cur];
        for (let i = 0; i < N; ++i) {
            cur2[i] += A[i][j];
        }
        if (isSorted(cur2)) {
            cur = cur2;
        } else {
            ans++;
        }
    }

    return ans;
};

const isSorted = (A) => {
    for (let i = 0; i < A.length - 1; ++i) {
        if (A[i] > A[i + 1]) {
            return false;
        }
    }
    return true;
}
```

```TypeScript
function minDeletionSize(A: string[]): number {
    const N = A.length;
    const W = A[0].length;
    let ans = 0;

    // cur : all rows we have written
    // For example, with A = ["abc","def","ghi"] we might have
    // cur = ["ab", "de", "gh"].
    let cur: string[] = new Array(N).fill("");
    for (let j = 0; j < W; ++j) {
        // cur2 : What we potentially can write, including the
        //        newest column col = [A[i][j] for i]
        // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
        // then cur2 = ["abc","def","ghi"].
        let cur2 = [...cur];
        for (let i = 0; i < N; ++i) {
            cur2[i] += A[i][j];
        }
        if (isSorted(cur2)) {
            cur = cur2;
        } else {
            ans++;
        }
    }

    return ans;
};

function isSorted(A: string[]): boolean {
    for (let i = 0; i < A.length - 1; ++i) {
        if (A[i] > A[i + 1]) {
            return false;
        }
    }
    return true;
}
```

```Rust
impl Solution {
    pub fn min_deletion_size(a: Vec<String>) -> i32 {
        let n = a.len();
        let w = a[0].len();
        let mut ans = 0;

        // cur : all rows we have written
        // For example, with A = ["abc","def","ghi"] we might have
        // cur = ["ab", "de", "gh"].
        let mut cur: Vec<String> = vec![String::new(); n];
        for j in 0..w {
            // cur2 : What we potentially can write, including the
            //        newest column col = [A[i][j] for i]
            // Eg. if cur = ["ab","de","gh"] and col = ("c","f","i"),
            // then cur2 = ["abc","def","ghi"].
            let mut cur2 = cur.clone();
            for i in 0..n {
                cur2[i].push(a[i].chars().nth(j).unwrap());
            }
            if Self::is_sorted(&cur2) {
                cur = cur2;
            } else {
                ans += 1;
            }
        }

        ans
    }

    fn is_sorted(a: &[String]) -> bool {
        for i in 0..a.len() - 1 {
            if a[i] > a[i + 1] {
                return false;
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(NW^2)$，其中 $N$ 是 `A` 的长度，$W$ 是 `A[i]` 的长度。
- 空间复杂度：$O(NW)$。

#### 方法二：优化贪心

**解释**

_方法 1_ 可以用更少的空间和时间。

核心思路是记录每一列的”割“信息。在第一个例子中，`A = ["axx","ayy","baa","bbb","bcc"]`（`R` 也是相同的定义），第一列将条件 `R[0] <= R[1] <= R[2] <= R[3] <= R[4]` 切成了 `R[0] <= R[1]` 和 `R[2] <= R[3] <= R[4]`。也就是说，`"a" == column[1] != column[2] == "b"` ”切割“了 `R` 中的一个条件。

从更高层面上说，我们的算法只需要考虑新加进的列是否保证有序。通过维护”割“的信息，只需要比较新列的字符。

```Java
class Solution {
    public int minDeletionSize(String[] A) {
        int N = A.length;
        int W = A[0].length();
        // cuts[j] is true : we don't need to check any new A[i][j] <= A[i][j+1]
        boolean[] cuts = new boolean[N-1];

        int ans = 0;
        search: for (int j = 0; j < W; ++j) {
            // Evaluate whether we can keep this column
            for (int i = 0; i < N-1; ++i)
                if (!cuts[i] && A[i].charAt(j) > A[i+1].charAt(j)) {
                    // Can't keep the column - delete and continue
                    ans++;
                    continue search;
                }

            // Update 'cuts' information
            for (int i = 0; i < N-1; ++i) {
                if (A[i].charAt(j) < A[i + 1].charAt(j)) {
                    cuts[i] = true;
                }
            }
        }

        return ans;
    }
}
```

```Python
class Solution:
    def minDeletionSize(self, A):
        # cuts[i] is True : we don't need to check col[i] <= col[i+1]
        cuts = [False] * (len(A) - 1)
        ans = 0
        for col in zip(*A):
            if all(cuts[i] or col[i] <= col[i + 1] for i in range(len(col) - 1)):
                for i in range(len(col) - 1):
                    if col[i] < col[i + 1]:
                        cuts[i] = True
            else:
                ans += 1
        return ans
```

```C++
class Solution {
public:
    int minDeletionSize(vector<string>& A) {
        // cuts[i] is True : we don't need to check col[i] <= col[i+1]
        vector<bool> cuts(A.size() - 1, false);
        int ans = 0;
        for (int j = 0; j < A[0].size(); j++) {
            bool canKeep = true;
            for (int i = 0; i < A.size() - 1; i++) {
                if (!cuts[i] && A[i][j] > A[i + 1][j]) {
                    canKeep = false;
                    break;
                }
            }
            if (canKeep) {
                for (int i = 0; i < A.size() - 1; i++) {
                    if (A[i][j] < A[i + 1][j]) {
                        cuts[i] = true;
                    }
                }
            } else {
                ans++;
            }
        }
        return ans;
    }
};
```

```CSharp
public class Solution {
    public int MinDeletionSize(string[] A) {
        // cuts[i] is True : we don't need to check col[i] <= col[i+1]
        bool[] cuts = new bool[A.Length - 1];
        int ans = 0;
        for (int j = 0; j < A[0].Length; j++) {
            bool canKeep = true;
            for (int i = 0; i < A.Length - 1; i++) {
                if (!cuts[i] && A[i][j] > A[i + 1][j]) {
                    canKeep = false;
                    break;
                }
            }
            if (canKeep) {
                for (int i = 0; i < A.Length - 1; i++) {
                    if (A[i][j] < A[i + 1][j]) {
                        cuts[i] = true;
                    }
                }
            } else {
                ans++;
            }
        }

        return ans;
    }
}
```

```Go
func minDeletionSize(A []string) int {
    // cuts[i] is True : we don't need to check col[i] <= col[i+1]
    cuts := make([]bool, len(A) - 1)
    ans := 0
    for j := 0; j < len(A[0]); j++ {
        canKeep := true
        for i := 0; i < len(A) - 1; i++ {
            if !cuts[i] && A[i][j] > A[i + 1][j] {
                canKeep = false
                break
            }
        }
        if canKeep {
            for i := 0; i < len(A) - 1; i++ {
                if A[i][j] < A[i + 1][j] {
                    cuts[i] = true
                }
            }
        } else {
            ans++
        }
    }

    return ans
}
```

```C
int minDeletionSize(char** A, int ASize) {
    // cuts[i] is True : we don't need to check col[i] <= col[i+1]
    bool* cuts = (bool*)malloc((ASize - 1) * sizeof(bool));
    for (int i = 0; i < ASize - 1; i++) {
        cuts[i] = false;
    }
    int ans = 0;
    int W = strlen(A[0]);
    for (int j = 0; j < W; j++) {
        bool canKeep = true;
        for (int i = 0; i < ASize - 1; i++) {
            if (!cuts[i] && A[i][j] > A[i + 1][j]) {
                canKeep = false;
                break;
            }
        }

        if (canKeep) {
            for (int i = 0; i < ASize - 1; i++) {
                if (A[i][j] < A[i + 1][j]) {
                    cuts[i] = true;
                }
            }
        } else {
            ans++;
        }
    }

    free(cuts);
    return ans;
}
```

```JavaScript
var minDeletionSize = function(A) {
    // cuts[i] is True : we don't need to check col[i] <= col[i+1]
    const cuts = new Array(A.length - 1).fill(false);
    let ans = 0;

    for (let j = 0; j < A[0].length; j++) {
        let canKeep = true;
        for (let i = 0; i < A.length - 1; i++) {
            if (!cuts[i] && A[i][j] > A[i + 1][j]) {
                canKeep = false;
                break;
            }
        }
        if (canKeep) {
            for (let i = 0; i < A.length - 1; i++) {
                if (A[i][j] < A[i + 1][j]) {
                    cuts[i] = true;
                }
            }
        } else {
            ans++;
        }
    }

    return ans;
};
```

```TypeScript
function minDeletionSize(A: string[]): number {
    // cuts[i] is True : we don't need to check col[i] <= col[i+1]
    const cuts: boolean[] = new Array(A.length - 1).fill(false);
    let ans = 0;

    for (let j = 0; j < A[0].length; j++) {
        let canKeep = true;
        for (let i = 0; i < A.length - 1; i++) {
            if (!cuts[i] && A[i][j] > A[i + 1][j]) {
                canKeep = false;
                break;
            }
        }
        if (canKeep) {
            for (let i = 0; i < A.length - 1; i++) {
                if (A[i][j] < A[i + 1][j]) {
                    cuts[i] = true;
                }
            }
        } else {
            ans++;
        }
    }

    return ans;
};

```

```Rust
impl Solution {
    pub fn min_deletion_size(a: Vec<String>) -> i32 {
        // cuts[i] is True : we don't need to check col[i] <= col[i+1]
        let mut cuts = vec![false; a.len() - 1];
        let mut ans = 0;

        for j in 0..a[0].len() {
            let mut can_keep = true;
            for i in 0..a.len() - 1 {
                if !cuts[i] {
                    let char_i = a[i].chars().nth(j).unwrap();
                    let char_i1 = a[i+1].chars().nth(j).unwrap();
                    if char_i > char_i1 {
                        can_keep = false;
                        break;
                    }
                }
            }
            if can_keep {
                for i in 0..a.len() - 1 {
                    let char_i = a[i].chars().nth(j).unwrap();
                    let char_i1 = a[i+1].chars().nth(j).unwrap();
                    if char_i < char_i1 {
                        cuts[i] = true;
                    }
                }
            } else {
                ans += 1;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(NW)$，其中 $N$ 是 `A` 的长度，$W$ 是 `A[i]` 的长度。
- 空间复杂度：额外空间开销 $O(N)$（在 $Python$ 中，`zip(*A)` 需要 $O(NW)$ 的空间）。
