### [由单个字符重复的最长子字符串](https://leetcode.cn/problems/longest-substring-of-one-repeating-character/solutions/4005916/you-dan-ge-zi-fu-zhong-fu-de-zui-chang-z-wi5q/)

#### 方法一：线段树

**思路与算法**

我们可以用线段树来维护字符串 $s$ 的信息。线段树的每个节点维护其对应区间的以下信息：

- $pre$：区间前缀最长连续相同字符的长度。
- $suf$：区间后缀最长连续相同字符的长度。
- $maxLen$：区间内最长连续相同字符的长度。
- $leftChar$：区间最左侧的字符。
- $rightChar$：区间最右侧的字符。

对于叶子节点（区间长度为 $1$），$pre=suf=maxLen=1$，leftChar=rightChar=s[i]。

对于非叶子节点，设其左右子节点分别为 $left$ 和 $right$，合并规则如下：

- $leftChar$ 继承左子节点的 $leftChar$。
- $rightChar$ 继承右子节点的 $rightChar$。
- $pre$ 初始为左子节点的 $pre$。如果左子节点的 $pre$ 等于左子区间的长度，且左子节点的 $rightChar$ 等于右子节点的 $leftChar$，则 $pre$ 可以延伸到右子节点：$pre=pre_{left}+pre_{right}$。
- $suf$ 初始为右子节点的 $suf$。如果右子节点的 $suf$ 等于右子区间的长度，且左子节点的 $rightChar$ 等于右子节点的 $leftChar$，则 $suf$ 可以延伸到左子节点：$suf=suf_{right}+suf_{left}$。
- $maxLen$ 取左子节点和右子节点 $maxLen$ 的最大值。如果左子节点的 $rightChar$ 等于右子节点的 $leftChar$，则中间可以拼接：$maxLen=max(maxLen,suf_{left}+pre_{right})$。

对于每个查询，我们执行单点更新：将对应位置的字符修改为新字符。每次更新后，根节点的 $maxLen$ 就是当前字符串的最长单字符重复子串长度。

初始建立线段树的时间复杂度为 $O(n)$，每次更新和查询的时间复杂度为 $O(\log n)$，总时间复杂度为 $O((n+k)\log n)$。

**代码**

```C++
class Solution {
public:
    vector<int> longestRepeating(string s, string queryCharacters, vector<int>& queryIndices) {
        int n = s.size();
        vector<int> pre(4 * n), suf(4 * n), maxLen(4 * n);
        vector<char> leftChar(4 * n), rightChar(4 * n);

        auto pushUp = [&](int u, int l, int r) {
            int mid = (l + r) >> 1;
            int leftLen = mid - l + 1, rightLen = r - mid;
            int left = u << 1, right = u << 1 | 1;
            leftChar[u] = leftChar[left];
            rightChar[u] = rightChar[right];
            pre[u] = pre[left];
            if (pre[left] == leftLen && rightChar[left] == leftChar[right]) {
                pre[u] = pre[left] + pre[right];
            }
            suf[u] = suf[right];
            if (suf[right] == rightLen && rightChar[left] == leftChar[right]) {
                suf[u] = suf[right] + suf[left];
            }
            maxLen[u] = max(maxLen[left], maxLen[right]);
            if (rightChar[left] == leftChar[right]) {
                maxLen[u] = max(maxLen[u], suf[left] + pre[right]);
            }
        };

        function<void(int, int, int)> build = [&](int u, int l, int r) {
            if (l == r) {
                pre[u] = 1;
                suf[u] = 1;
                maxLen[u] = 1;
                leftChar[u] = s[l];
                rightChar[u] = s[l];
                return;
            }
            int mid = (l + r) >> 1;
            build(u << 1, l, mid);
            build(u << 1 | 1, mid + 1, r);
            pushUp(u, l, r);
        };

        function<void(int, int, int, int, char)> update = [&](int u, int l, int r, int pos, char ch) {
            if (l == r) {
                leftChar[u] = ch;
                rightChar[u] = ch;
                return;
            }
            int mid = (l + r) >> 1;
            if (pos <= mid) {
                update(u << 1, l, mid, pos, ch);
            } else {
                update(u << 1 | 1, mid + 1, r, pos, ch);
            }
            pushUp(u, l, r);
        };

        build(1, 0, n - 1);
        int k = queryIndices.size();
        vector<int> ans(k);
        for (int i = 0; i < k; i++) {
            update(1, 0, n - 1, queryIndices[i], queryCharacters[i]);
            ans[i] = maxLen[1];
        }
        return ans;
    }
};
```

```Java
class Solution {
    private char[] sArr;
    private int[] pre, suf, maxLen;
    private char[] leftChar, rightChar;

    public int[] longestRepeating(String s, String queryCharacters, int[] queryIndices) {
        int n = s.length();
        sArr = s.toCharArray();
        pre = new int[4 * n];
        suf = new int[4 * n];
        maxLen = new int[4 * n];
        leftChar = new char[4 * n];
        rightChar = new char[4 * n];

        build(1, 0, n - 1);
        int k = queryIndices.length;
        int[] ans = new int[k];
        for (int i = 0; i < k; i++) {
            update(1, 0, n - 1, queryIndices[i], queryCharacters.charAt(i));
            ans[i] = maxLen[1];
        }
        return ans;
    }

    private void pushUp(int u, int l, int r) {
        int mid = (l + r) >> 1;
        int leftLen = mid - l + 1, rightLen = r - mid;
        int left = u << 1, right = u << 1 | 1;
        leftChar[u] = leftChar[left];
        rightChar[u] = rightChar[right];
        pre[u] = pre[left];
        if (pre[left] == leftLen && rightChar[left] == leftChar[right]) {
            pre[u] = pre[left] + pre[right];
        }
        suf[u] = suf[right];
        if (suf[right] == rightLen && rightChar[left] == leftChar[right]) {
            suf[u] = suf[right] + suf[left];
        }
        maxLen[u] = Math.max(maxLen[left], maxLen[right]);
        if (rightChar[left] == leftChar[right]) {
            maxLen[u] = Math.max(maxLen[u], suf[left] + pre[right]);
        }
    }

    private void build(int u, int l, int r) {
        if (l == r) {
            pre[u] = 1;
            suf[u] = 1;
            maxLen[u] = 1;
            leftChar[u] = sArr[l];
            rightChar[u] = sArr[l];
            return;
        }
        int mid = (l + r) >> 1;
        build(u << 1, l, mid);
        build(u << 1 | 1, mid + 1, r);
        pushUp(u, l, r);
    }

    private void update(int u, int l, int r, int pos, char ch) {
        if (l == r) {
            leftChar[u] = ch;
            rightChar[u] = ch;
            return;
        }
        int mid = (l + r) >> 1;
        if (pos <= mid) {
            update(u << 1, l, mid, pos, ch);
        } else {
            update(u << 1 | 1, mid + 1, r, pos, ch);
        }
        pushUp(u, l, r);
    }
}
```

```CSharp
public class Solution {
    private char[] sArr;
    private int[] pre, suf, maxLen;
    private char[] leftChar, rightChar;

    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices) {
        int n = s.Length;
        sArr = s.ToCharArray();
        pre = new int[4 * n];
        suf = new int[4 * n];
        maxLen = new int[4 * n];
        leftChar = new char[4 * n];
        rightChar = new char[4 * n];

        Build(1, 0, n - 1);
        int k = queryIndices.Length;
        int[] ans = new int[k];
        for (int i = 0; i < k; i++) {
            Update(1, 0, n - 1, queryIndices[i], queryCharacters[i]);
            ans[i] = maxLen[1];
        }
        return ans;
    }

    private void PushUp(int u, int l, int r) {
        int mid = (l + r) >> 1;
        int leftLen = mid - l + 1, rightLen = r - mid;
        int left = u << 1, right = u << 1 | 1;
        leftChar[u] = leftChar[left];
        rightChar[u] = rightChar[right];
        pre[u] = pre[left];
        if (pre[left] == leftLen && rightChar[left] == leftChar[right]) {
            pre[u] = pre[left] + pre[right];
        }
        suf[u] = suf[right];
        if (suf[right] == rightLen && rightChar[left] == leftChar[right]) {
            suf[u] = suf[right] + suf[left];
        }
        maxLen[u] = Math.Max(maxLen[left], maxLen[right]);
        if (rightChar[left] == leftChar[right]) {
            maxLen[u] = Math.Max(maxLen[u], suf[left] + pre[right]);
        }
    }

    private void Build(int u, int l, int r) {
        if (l == r) {
            pre[u] = 1;
            suf[u] = 1;
            maxLen[u] = 1;
            leftChar[u] = sArr[l];
            rightChar[u] = sArr[l];
            return;
        }
        int mid = (l + r) >> 1;
        Build(u << 1, l, mid);
        Build(u << 1 | 1, mid + 1, r);
        PushUp(u, l, r);
    }

    private void Update(int u, int l, int r, int pos, char ch) {
        if (l == r) {
            leftChar[u] = ch;
            rightChar[u] = ch;
            return;
        }
        int mid = (l + r) >> 1;
        if (pos <= mid) {
            Update(u << 1, l, mid, pos, ch);
        } else {
            Update(u << 1 | 1, mid + 1, r, pos, ch);
        }
        PushUp(u, l, r);
    }
}
```

```Go
func longestRepeating(s string, queryCharacters string, queryIndices []int) []int {
    n := len(s)
    pre := make([]int, 4*n)
    suf := make([]int, 4*n)
    maxLen := make([]int, 4*n)
    leftChar := make([]byte, 4*n)
    rightChar := make([]byte, 4*n)

    var pushUp func(u, l, r int)
    pushUp = func(u, l, r int) {
        mid := (l + r) >> 1
        leftLen, rightLen := mid - l + 1, r - mid
        left, right := u<<1, u<<1|1
        leftChar[u], rightChar[u] = leftChar[left], rightChar[right]

        pre[u] = pre[left]
        if pre[left] == leftLen && rightChar[left] == leftChar[right] {
            pre[u] = pre[left] + pre[right]
        }
        suf[u] = suf[right]
        if suf[right] == rightLen && rightChar[left] == leftChar[right] {
            suf[u] = suf[right] + suf[left]
        }
        maxLen[u] = max(maxLen[left], maxLen[right])
        if rightChar[left] == leftChar[right] {
            maxLen[u] = max(maxLen[u], suf[left]+pre[right])
        }
    }

    var build func(u, l, r int)
    build = func(u, l, r int) {
        if l == r {
            pre[u], suf[u], maxLen[u] = 1, 1, 1
            leftChar[u], rightChar[u] = s[l], s[l]
            return
        }
        mid := (l + r) >> 1
        build(u<<1, l, mid)
        build(u<<1|1, mid+1, r)
        pushUp(u, l, r)
    }

    var update func(u, l, r, pos int, ch byte)
    update = func(u, l, r, pos int, ch byte) {
        if l == r {
            leftChar[u], rightChar[u] = ch, ch
            return
        }
        mid := (l + r) >> 1
        if pos <= mid {
            update(u<<1, l, mid, pos, ch)
        } else {
            update(u<<1|1, mid+1, r, pos, ch)
        }
        pushUp(u, l, r)
    }

    build(1, 0, n-1)
    k := len(queryIndices)
    ans := make([]int, k)
    for i := 0; i < k; i++ {
        update(1, 0, n-1, queryIndices[i], queryCharacters[i])
        ans[i] = maxLen[1]
    }
    return ans
}
```

```Python
class Solution:
    def longestRepeating(self, s: str, queryCharacters: str, queryIndices: List[int]) -> List[int]:
        n = len(s)
        pre = [0] * (4 * n)
        suf = [0] * (4 * n)
        maxLen = [0] * (4 * n)
        leftChar = [''] * (4 * n)
        rightChar = [''] * (4 * n)

        def build(u: int, l: int, r: int) -> None:
            if l == r:
                pre[u] = 1
                suf[u] = 1
                maxLen[u] = 1
                leftChar[u] = s[l]
                rightChar[u] = s[l]
                return
            mid = (l + r) >> 1
            build(u << 1, l, mid)
            build(u << 1 | 1, mid + 1, r)
            pushUp(u, l, r)

        def pushUp(u: int, l: int, r: int) -> None:
            mid = (l + r) >> 1
            leftLen = mid - l + 1
            rightLen = r - mid
            left = u << 1
            right = u << 1 | 1
            leftChar[u] = leftChar[left]
            rightChar[u] = rightChar[right]
            pre[u] = pre[left]
            if pre[left] == leftLen and rightChar[left] == leftChar[right]:
                pre[u] = pre[left] + pre[right]
            suf[u] = suf[right]
            if suf[right] == rightLen and rightChar[left] == leftChar[right]:
                suf[u] = suf[right] + suf[left]
            maxLen[u] = max(maxLen[left], maxLen[right])
            if rightChar[left] == leftChar[right]:
                maxLen[u] = max(maxLen[u], suf[left] + pre[right])

        def update(u: int, l: int, r: int, pos: int, ch: str) -> None:
            if l == r:
                leftChar[u] = ch
                rightChar[u] = ch
                return
            mid = (l + r) >> 1
            if pos <= mid:
                update(u << 1, l, mid, pos, ch)
            else:
                update(u << 1 | 1, mid + 1, r, pos, ch)
            pushUp(u, l, r)

        build(1, 0, n - 1)
        k = len(queryIndices)
        ans = []
        for i in range(k):
            update(1, 0, n - 1, queryIndices[i], queryCharacters[i])
            ans.append(maxLen[1])
        return ans
```

```TypeScript
function longestRepeating(s: string, queryCharacters: string, queryIndices: number[]): number[] {
    const n = s.length;
    const pre: number[] = new Array(4 * n).fill(0);
    const suf: number[] = new Array(4 * n).fill(0);
    const maxLen: number[] = new Array(4 * n).fill(0);
    const leftChar: string[] = new Array(4 * n).fill('');
    const rightChar: string[] = new Array(4 * n).fill('');

    const pushUp = (u: number, l: number, r: number): void => {
        const mid = (l + r) >> 1;
        const leftLen = mid - l + 1, rightLen = r - mid;
        const left = u << 1, right = u << 1 | 1;
        leftChar[u] = leftChar[left];
        rightChar[u] = rightChar[right];
        pre[u] = pre[left];
        if (pre[left] === leftLen && rightChar[left] === leftChar[right]) {
            pre[u] = pre[left] + pre[right];
        }
        suf[u] = suf[right];
        if (suf[right] === rightLen && rightChar[left] === leftChar[right]) {
            suf[u] = suf[right] + suf[left];
        }
        maxLen[u] = Math.max(maxLen[left], maxLen[right]);
        if (rightChar[left] === leftChar[right]) {
            maxLen[u] = Math.max(maxLen[u], suf[left] + pre[right]);
        }
    };

    const build = (u: number, l: number, r: number): void => {
        if (l === r) {
            pre[u] = 1;
            suf[u] = 1;
            maxLen[u] = 1;
            leftChar[u] = s[l];
            rightChar[u] = s[l];
            return;
        }
        const mid = (l + r) >> 1;
        build(u << 1, l, mid);
        build(u << 1 | 1, mid + 1, r);
        pushUp(u, l, r);
    };

    const update = (u: number, l: number, r: number, pos: number, ch: string): void => {
        if (l === r) {
            leftChar[u] = ch;
            rightChar[u] = ch;
            return;
        }
        const mid = (l + r) >> 1;
        if (pos <= mid) {
            update(u << 1, l, mid, pos, ch);
        } else {
            update(u << 1 | 1, mid + 1, r, pos, ch);
        }
        pushUp(u, l, r);
    };

    build(1, 0, n - 1);
    const k = queryIndices.length;
    const ans: number[] = new Array(k);
    for (let i = 0; i < k; i++) {
        update(1, 0, n - 1, queryIndices[i], queryCharacters[i]);
        ans[i] = maxLen[1];
    }
    return ans;
}
```

```JavaScript
var longestRepeating = function(s, queryCharacters, queryIndices) {
    const n = s.length;
    const pre = new Array(4 * n).fill(0);
    const suf = new Array(4 * n).fill(0);
    const maxLen = new Array(4 * n).fill(0);
    const leftChar = new Array(4 * n).fill('');
    const rightChar = new Array(4 * n).fill('');

    const pushUp = (u, l, r) => {
        const mid = (l + r) >> 1;
        const leftLen = mid - l + 1, rightLen = r - mid;
        const left = u << 1, right = u << 1 | 1;
        leftChar[u] = leftChar[left];
        rightChar[u] = rightChar[right];
        pre[u] = pre[left];
        if (pre[left] === leftLen && rightChar[left] === leftChar[right]) {
            pre[u] = pre[left] + pre[right];
        }
        suf[u] = suf[right];
        if (suf[right] === rightLen && rightChar[left] === leftChar[right]) {
            suf[u] = suf[right] + suf[left];
        }
        maxLen[u] = Math.max(maxLen[left], maxLen[right]);
        if (rightChar[left] === leftChar[right]) {
            maxLen[u] = Math.max(maxLen[u], suf[left] + pre[right]);
        }
    };

    const build = (u, l, r) => {
        if (l === r) {
            pre[u] = 1;
            suf[u] = 1;
            maxLen[u] = 1;
            leftChar[u] = s[l];
            rightChar[u] = s[l];
            return;
        }
        const mid = (l + r) >> 1;
        build(u << 1, l, mid);
        build(u << 1 | 1, mid + 1, r);
        pushUp(u, l, r);
    };

    const update = (u, l, r, pos, ch) => {
        if (l === r) {
            leftChar[u] = ch;
            rightChar[u] = ch;
            return;
        }
        const mid = (l + r) >> 1;
        if (pos <= mid) {
            update(u << 1, l, mid, pos, ch);
        } else {
            update(u << 1 | 1, mid + 1, r, pos, ch);
        }
        pushUp(u, l, r);
    };

    build(1, 0, n - 1);
    const k = queryIndices.length;
    const ans = new Array(k);
    for (let i = 0; i < k; i++) {
        update(1, 0, n - 1, queryIndices[i], queryCharacters[i]);
        ans[i] = maxLen[1];
    }
    return ans;
};
```

```C
typedef struct {
    int pre, suf, maxLen;
    char leftChar, rightChar;
} Node;

void pushUp(Node* tree, int u, int l, int r) {
    int mid = (l + r) >> 1;
    int leftLen = mid - l + 1, rightLen = r - mid;
    int left = u << 1, right = u << 1 | 1;
    tree[u].leftChar = tree[left].leftChar;
    tree[u].rightChar = tree[right].rightChar;
    tree[u].pre = tree[left].pre;
    if (tree[left].pre == leftLen && tree[left].rightChar == tree[right].leftChar) {
        tree[u].pre = tree[left].pre + tree[right].pre;
    }
    tree[u].suf = tree[right].suf;
    if (tree[right].suf == rightLen && tree[left].rightChar == tree[right].leftChar) {
        tree[u].suf = tree[right].suf + tree[left].suf;
    }
    tree[u].maxLen = (int)fmax(tree[left].maxLen, tree[right].maxLen);
    if (tree[left].rightChar == tree[right].leftChar) {
        tree[u].maxLen = (int)fmax(tree[u].maxLen, tree[left].suf + tree[right].pre);
    }
}

void build(Node* tree, char* str, int u, int l, int r) {
    if (l == r) {
        tree[u].pre = 1;
        tree[u].suf = 1;
        tree[u].maxLen = 1;
        tree[u].leftChar = str[l];
        tree[u].rightChar = str[l];
        return;
    }
    int mid = (l + r) >> 1;
    build(tree, str, u << 1, l, mid);
    build(tree, str, u << 1 | 1, mid + 1, r);
    pushUp(tree, u, l, r);
}

void update(Node* tree, int u, int l, int r, int pos, char ch) {
    if (l == r) {
        tree[u].leftChar = ch;
        tree[u].rightChar = ch;
        return;
    }
    int mid = (l + r) >> 1;
    if (pos <= mid) {
        update(tree, u << 1, l, mid, pos, ch);
    } else {
        update(tree, u << 1 | 1, mid + 1, r, pos, ch);
    }
    pushUp(tree, u, l, r);
}

int* longestRepeating(char* s, char* queryCharacters, int* queryIndices, int queryIndicesSize, int* returnSize) {
    int n = strlen(s);
    Node* tree = (Node*)malloc(4 * n * sizeof(Node));
    memset(tree, 0, 4 * n * sizeof(Node));
    build(tree, s, 1, 0, n - 1);
    int* ans = (int*)malloc(queryIndicesSize * sizeof(int));
    *returnSize = queryIndicesSize;
    for (int i = 0; i < queryIndicesSize; i++) {
        update(tree, 1, 0, n - 1, queryIndices[i], queryCharacters[i]);
        ans[i] = tree[1].maxLen;
    }
    free(tree);
    return ans;
}
```

```Rust
impl Solution {
    pub fn longest_repeating(s: String, query_characters: String, query_indices: Vec<i32>) -> Vec<i32> {
        let n = s.len();
        let s = s.as_bytes();
        let qc = query_characters.as_bytes();
        let mut pre = vec![0; 4 * n];
        let mut suf = vec![0; 4 * n];
        let mut max_len = vec![0; 4 * n];
        let mut left_char = vec![0u8; 4 * n];
        let mut right_char = vec![0u8; 4 * n];

        fn push_up(pre: &mut [i32], suf: &mut [i32], max_len: &mut [i32], left_char: &mut [u8], right_char: &mut [u8], u: usize, l: usize, r: usize) {
            let mid = (l + r) >> 1;
            let left_len = (mid - l + 1) as i32;
            let right_len = (r - mid) as i32;
            let left = u << 1;
            let right = u << 1 | 1;
            left_char[u] = left_char[left];
            right_char[u] = right_char[right];
            pre[u] = pre[left];
            if pre[left] == left_len && right_char[left] == left_char[right] {
                pre[u] = pre[left] + pre[right];
            }
            suf[u] = suf[right];
            if suf[right] == right_len && right_char[left] == left_char[right] {
                suf[u] = suf[right] + suf[left];
            }
            max_len[u] = max_len[left].max(max_len[right]);
            if right_char[left] == left_char[right] {
                max_len[u] = max_len[u].max(suf[left] + pre[right]);
            }
        }

        fn build(pre: &mut [i32], suf: &mut [i32], max_len: &mut [i32], left_char: &mut [u8], right_char: &mut [u8], s: &[u8], u: usize, l: usize, r: usize) {
            if l == r {
                pre[u] = 1;
                suf[u] = 1;
                max_len[u] = 1;
                left_char[u] = s[l];
                right_char[u] = s[l];
                return;
            }
            let mid = (l + r) >> 1;
            build(pre, suf, max_len, left_char, right_char, s, u << 1, l, mid);
            build(pre, suf, max_len, left_char, right_char, s, u << 1 | 1, mid + 1, r);
            push_up(pre, suf, max_len, left_char, right_char, u, l, r);
        }

        fn update(pre: &mut [i32], suf: &mut [i32], max_len: &mut [i32], left_char: &mut [u8], right_char: &mut [u8], u: usize, l: usize, r: usize, pos: usize, ch: u8) {
            if l == r {
                left_char[u] = ch;
                right_char[u] = ch;
                return;
            }
            let mid = (l + r) >> 1;
            if pos <= mid {
                update(pre, suf, max_len, left_char, right_char, u << 1, l, mid, pos, ch);
            } else {
                update(pre, suf, max_len, left_char, right_char, u << 1 | 1, mid + 1, r, pos, ch);
            }
            push_up(pre, suf, max_len, left_char, right_char, u, l, r);
        }

        build(&mut pre, &mut suf, &mut max_len, &mut left_char, &mut right_char, s, 1, 0, n - 1);

        let k = query_indices.len();
        let mut ans = vec![0; k];
        for i in 0..k {
            update(&mut pre, &mut suf, &mut max_len, &mut left_char, &mut right_char, 1, 0, n - 1, query_indices[i] as usize, qc[i]);
            ans[i] = max_len[1];
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+k)\log n)$，其中 $n$ 是字符串 $s$ 的长度，$k$ 是查询的数量。初始建树需要 $O(n)$ 时间，每个查询（单点更新 $+$ 查询全局最大值）需要 $O(\log n)$ 时间。
- 空间复杂度：$O(n)$，线段树数组需要 $4n$ 的空间。

#### 方法二：有序集合模拟区间合并

**思路与算法**

我们可以用有序集合（如 $C++$ 中的 `set`、Java 中的 `TreeMap`、Python 中的 `SortedList` 等）来维护字符串 $s$ 中所有由相同字符组成的极大连续区间。同时用另一个有序集合来维护所有区间的长度，以便快速获取最大值。

初始时，遍历字符串 $s$，将每个极大连续区间记录下来（包括其左右端点和长度）。记录格式为 $(L,R)$，表示区间 $[L,R]$ 内的字符全部相同。

对于每个查询 $(pos,ch)$：

1. 如果 $s[pos]$ 已经等于 $ch$，则当前字符串不变，直接取最大长度即可。
2. 否则，先找到包含位置 $pos$ 的区间 $[L,R]$，将其从集合中删除，并从长度集合中删除对应的长度。
3. 如果 $L<pos$，则左侧剩余部分 $[L,pos-1]$ 作为一个新区间加入集合。
4. 如果 $pos<R$，则右侧剩余部分 $[pos+1,R]$ 作为一个新区间加入集合。
5. 现在位置 $pos$ 处是新字符 $ch$，我们将其初始化为一个长度为 $1$ 的区间 $[pos,pos]$。然后检查左侧相邻区间（如果存在且以 $pos-1$ 结尾，且该区间的字符等于 $ch$），以及右侧相邻区间（如果存在且以 $pos+1$ 开始，且该区间的字符等于 $ch$）。如果相邻区间与新区间字符相同，则进行合并。
6. 最后更新 $s[pos]=ch$，并将当前所有区间长度的最大值加入答案。

**代码**

```C++
class Solution {
public:
    vector<int> longestRepeating(string s, string queryCharacters, vector<int>& queryIndices) {
        int n = s.size();
        set<pair<int, int>> segs;
        multiset<int> lens;

        for (int i = 0; i < n; ) {
            int j = i;
            while (j < n && s[j] == s[i]) {
                j++;
            }
            segs.insert({i, j - 1});
            lens.insert(j - i);
            i = j;
        }

        int k = queryIndices.size();
        vector<int> ans(k);

        for (int q = 0; q < k; q++) {
            int pos = queryIndices[q];
            char ch = queryCharacters[q];

            if (s[pos] != ch) {
                auto it = segs.upper_bound({pos, INT_MAX});
                --it;
                int L = it->first, R = it->second;
                segs.erase(it);
                lens.erase(lens.find(R - L + 1));

                if (L <= pos - 1) {
                    segs.insert({L, pos - 1});
                    lens.insert(pos - L);
                }
                if (pos + 1 <= R) {
                    segs.insert({pos + 1, R});
                    lens.insert(R - pos);
                }

                int newL = pos, newR = pos;

                auto rightIt = segs.lower_bound({pos + 1, 0});
                if (rightIt != segs.end() && rightIt->first == pos + 1 && s[pos + 1] == ch) {
                    lens.erase(lens.find(rightIt->second - rightIt->first + 1));
                    newR = rightIt->second;
                    segs.erase(rightIt);
                }

                auto leftIt = segs.lower_bound({pos, 0});
                if (leftIt != segs.begin()) {
                    --leftIt;
                    if (leftIt->second == pos - 1 && s[pos - 1] == ch) {
                        lens.erase(lens.find(leftIt->second - leftIt->first + 1));
                        newL = leftIt->first;
                        segs.erase(leftIt);
                    }
                }

                segs.insert({newL, newR});
                lens.insert(newR - newL + 1);
                s[pos] = ch;
            }

            ans[q] = *lens.rbegin();
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int[] longestRepeating(String s, String queryCharacters, int[] queryIndices) {
        int n = s.length();
        char[] arr = s.toCharArray();
        TreeMap<Integer, Integer> segs = new TreeMap<>();
        TreeMap<Integer, Integer> lens = new TreeMap<>();

        for (int i = 0; i < n; ) {
            int j = i;
            while (j < n && arr[j] == arr[i]) {
                j++;
            }
            segs.put(i, j - 1);
            lens.put(j - i, lens.getOrDefault(j - i, 0) + 1);
            i = j;
        }

        int k = queryIndices.length;
        int[] ans = new int[k];

        for (int q = 0; q < k; q++) {
            int pos = queryIndices[q];
            char ch = queryCharacters.charAt(q);

            if (arr[pos] != ch) {
                int L = segs.floorKey(pos);
                int R = segs.get(L);
                segs.remove(L);
                int oldLen = R - L + 1;
                lens.put(oldLen, lens.get(oldLen) - 1);
                if (lens.get(oldLen) == 0) {
                    lens.remove(oldLen);
                }

                if (L <= pos - 1) {
                    segs.put(L, pos - 1);
                    int len1 = pos - L;
                    lens.put(len1, lens.getOrDefault(len1, 0) + 1);
                }
                if (pos + 1 <= R) {
                    segs.put(pos + 1, R);
                    int len2 = R - pos;
                    lens.put(len2, lens.getOrDefault(len2, 0) + 1);
                }

                int newL = pos, newR = pos;

                Integer rightKey = segs.ceilingKey(pos + 1);
                if (rightKey != null && rightKey == pos + 1 && arr[pos + 1] == ch) {
                    int rightR = segs.get(rightKey);
                    int rightLen = rightR - rightKey + 1;
                    lens.put(rightLen, lens.get(rightLen) - 1);
                    if (lens.get(rightLen) == 0) {
                        lens.remove(rightLen);
                    }
                    newR = rightR;
                    segs.remove(rightKey);
                }

                Integer leftKey = segs.floorKey(pos - 1);
                if (leftKey != null) {
                    int leftR = segs.get(leftKey);
                    if (leftR == pos - 1 && arr[pos - 1] == ch) {
                        int leftLen = leftR - leftKey + 1;
                        lens.put(leftLen, lens.get(leftLen) - 1);
                        if (lens.get(leftLen) == 0) {
                            lens.remove(leftLen);
                        }
                        newL = leftKey;
                        segs.remove(leftKey);
                    }
                }

                segs.put(newL, newR);
                int newLen = newR - newL + 1;
                lens.put(newLen, lens.getOrDefault(newLen, 0) + 1);
                arr[pos] = ch;
            }

            ans[q] = lens.lastKey();
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices) {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        SortedSet<int> keys = new SortedSet<int>();
        Dictionary<int, int> segs = new Dictionary<int, int>();
        int[] lenCnt = new int[n + 1];
        SortedSet<int> activeLens = new SortedSet<int>();

        for (int i = 0; i < n; ) {
            int j = i;
            while (j < n && arr[j] == arr[i]) {
                j++;
            }
            keys.Add(i);
            segs[i] = j - 1;
            int len = j - i;
            if (lenCnt[len] == 0) {
                activeLens.Add(len);
            }
            lenCnt[len]++;
            i = j;
        }

        int k = queryIndices.Length;
        int[] ans = new int[k];

        for (int q = 0; q < k; q++) {
            int pos = queryIndices[q];
            char ch = queryCharacters[q];

            if (arr[pos] != ch) {
                int L = keys.GetViewBetween(0, pos).Max;
                int R = segs[L];
                keys.Remove(L);
                segs.Remove(L);
                int oldLen = R - L + 1;
                lenCnt[oldLen]--;
                if (lenCnt[oldLen] == 0) {
                    activeLens.Remove(oldLen);
                }

                int newL = pos, newR = pos;

                if (L < pos) {
                    if (arr[pos - 1] == ch) {
                        newL = L;
                    } else {
                        keys.Add(L);
                        segs[L] = pos - 1;
                        int lLen = pos - L;
                        if (lenCnt[lLen] == 0) {
                            activeLens.Add(lLen);
                        }
                        lenCnt[lLen]++;
                    }
                }

                if (pos < R) {
                    if (arr[pos + 1] == ch) {
                        newR = R;
                    } else {
                        keys.Add(pos + 1);
                        segs[pos + 1] = R;
                        int rLen = R - pos;
                        if (lenCnt[rLen] == 0) {
                            activeLens.Add(rLen);
                        }
                        lenCnt[rLen]++;
                    }
                }

                if (L == pos && pos > 0 && arr[pos - 1] == ch) {
                    int lk = keys.GetViewBetween(0, pos - 1).Max;
                    if (segs.ContainsKey(lk) && segs[lk] == pos - 1) {
                        keys.Remove(lk);
                        int ll = segs[lk] - lk + 1;
                        lenCnt[ll]--;
                        if (lenCnt[ll] == 0) {
                            activeLens.Remove(ll);
                        }
                        segs.Remove(lk);
                        newL = lk;
                    }
                }

                if (R == pos && pos + 1 < n && arr[pos + 1] == ch) {
                    int rk = keys.GetViewBetween(pos + 1, n).Min;
                    if (segs.ContainsKey(rk)) {
                        keys.Remove(rk);
                        int rl = segs[rk] - rk + 1;
                        lenCnt[rl]--;
                        if (lenCnt[rl] == 0) {
                            activeLens.Remove(rl);
                        }
                        int rR = segs[rk];
                        segs.Remove(rk);
                        newR = rR;
                    }
                }

                keys.Add(newL);
                segs[newL] = newR;
                int newLen = newR - newL + 1;
                if (lenCnt[newLen] == 0) {
                    activeLens.Add(newLen);
                }
                lenCnt[newLen]++;
                arr[pos] = ch;
            }

            ans[q] = activeLens.Max;
        }

        return ans;
    }
}
```

```Go
func longestRepeating(s string, queryCharacters string, queryIndices []int) []int {
    n := len(s)
    arr := []byte(s)
    segs := treemap.New[int, int]()
    lens := treemap.New[int, int]()

    for i := 0; i < n; {
        j := i
        for j < n && arr[j] == arr[i] {
            j++
        }
        segs.Put(i, j-1)
        cnt, _ := lens.Get(j - i)
        lens.Put(j-i, cnt+1)
        i = j
    }

    k := len(queryIndices)
    ans := make([]int, k)

    for q := 0; q < k; q++ {
        pos := queryIndices[q]
        ch := queryCharacters[q]

        if arr[pos] != ch {
            L, _, _ := segs.Floor(pos)
            R, _ := segs.Get(L)
            segs.Remove(L)
            oldLen := R - L + 1
            cnt, _ := lens.Get(oldLen)
            if cnt == 1 {
                lens.Remove(oldLen)
            } else {
                lens.Put(oldLen, cnt-1)
            }

            if L <= pos-1 {
                segs.Put(L, pos-1)
                c, _ := lens.Get(pos - L)
                lens.Put(pos-L, c+1)
            }
            if pos+1 <= R {
                segs.Put(pos+1, R)
                c, _ := lens.Get(R - pos)
                lens.Put(R-pos, c+1)
            }

            newL, newR := pos, pos

            rightKey, _, rightFound := segs.Ceiling(pos + 1)
            if rightFound && rightKey == pos+1 && pos+1 < n && arr[pos+1] == ch {
                rightR, _ := segs.Get(rightKey)
                rightLen := rightR - rightKey + 1
                c, _ := lens.Get(rightLen)
                if c == 1 {
                    lens.Remove(rightLen)
                } else {
                    lens.Put(rightLen, c-1)
                }
                newR = rightR
                segs.Remove(rightKey)
            }

            leftKey, _, leftFound := segs.Floor(pos - 1)
            if leftFound {
                leftR, _ := segs.Get(leftKey)
                if leftR == pos-1 && arr[pos-1] == ch {
                    leftLen := leftR - leftKey + 1
                    c, _ := lens.Get(leftLen)
                    if c == 1 {
                        lens.Remove(leftLen)
                    } else {
                        lens.Put(leftLen, c-1)
                    }
                    newL = leftKey
                    segs.Remove(leftKey)
                }
            }

            segs.Put(newL, newR)
            c, _ := lens.Get(newR - newL + 1)
            lens.Put(newR-newL+1, c+1)
            arr[pos] = ch
        }

        maxKey, _, _ := lens.Max()
        ans[q] = maxKey
    }

    return ans
}
```

```Python
class Solution:
    def longestRepeating(self, s: str, queryCharacters: str, queryIndices: List[int]) -> List[int]:
        n = len(s)
        s = list(s)
        segs = SortedList()
        lens = SortedList()

        i = 0
        while i < n:
            j = i
            while j < n and s[j] == s[i]:
                j += 1
            segs.add((i, j - 1))
            lens.add(j - i)
            i = j

        k = len(queryIndices)
        ans = []

        for q in range(k):
            pos = queryIndices[q]
            ch = queryCharacters[q]

            if s[pos] != ch:
                idx = segs.bisect_right((pos, n)) - 1
                L, R = segs[idx]
                segs.pop(idx)
                lens.remove(R - L + 1)

                if L <= pos - 1:
                    segs.add((L, pos - 1))
                    lens.add(pos - L)
                if pos + 1 <= R:
                    segs.add((pos + 1, R))
                    lens.add(R - pos)

                newL, newR = pos, pos

                if pos + 1 < n and s[pos + 1] == ch:
                    idx2 = segs.bisect_left((pos + 1, -1))
                    if idx2 < len(segs) and segs[idx2][0] == pos + 1:
                        rightL, rightR = segs[idx2]
                        lens.remove(rightR - rightL + 1)
                        newR = rightR
                        segs.pop(idx2)

                if pos > 0 and s[pos - 1] == ch:
                    idx3 = segs.bisect_right((pos - 1, n)) - 1
                    if idx3 >= 0 and segs[idx3][1] == pos - 1:
                        leftL, leftR = segs[idx3]
                        lens.remove(leftR - leftL + 1)
                        newL = leftL
                        segs.pop(idx3)

                segs.add((newL, newR))
                lens.add(newR - newL + 1)
                s[pos] = ch

            ans.append(lens[-1])

        return ans
```

```TypeScript
import { AvlTree } from '@datastructures-js/binary-search-tree';

interface SegEntry {
    left: number;
    right: number;
}

interface LenEntry {
    len: number;
    count: number;
}

function longestRepeating(s: string, queryCharacters: string, queryIndices: number[]): number[] {
    const n = s.length;
    const arr = s.split('');
    const segs = new AvlTree<SegEntry>((a, b) => a.left - b.left);
    const lens = new AvlTree<LenEntry>((a, b) => a.len - b.len);

    for (let i = 0; i < n; ) {
        let j = i;
        while (j < n && arr[j] === arr[i]) {
            j++;
        }
        segs.insert({ left: i, right: j - 1 });
        const length = j - i;
        const lenNode = lens.find({ len: length, count: 0 });
        if (lenNode) {
            lenNode.getValue().count++;
        } else {
            lens.insert({ len: length, count: 1 });
        }
        i = j;
    }

    const addLen = (len: number): void => {
        const node = lens.find({ len, count: 0 });
        if (node) {
            node.getValue().count++;
        } else {
            lens.insert({ len, count: 1 });
        }
    };

    const removeLen = (len: number): void => {
        const node = lens.find({ len, count: 0 });
        if (node && --node.getValue().count === 0) {
            lens.remove({ len, count: 0 });
        }
    };

    const k = queryIndices.length;
    const ans: number[] = new Array(k);

    for (let q = 0; q < k; q++) {
        const pos = queryIndices[q];
        const ch = queryCharacters[q];

        if (arr[pos] !== ch) {
            const floorNode = segs.lowerBound({ left: pos, right: 0 });
            const L = floorNode!.getValue().left;
            const R = floorNode!.getValue().right;
            segs.remove({ left: L, right: 0 });
            removeLen(R - L + 1);

            if (L <= pos - 1) {
                segs.insert({ left: L, right: pos - 1 });
                addLen(pos - L);
            }
            if (pos + 1 <= R) {
                segs.insert({ left: pos + 1, right: R });
                addLen(R - pos);
            }

            let newL = pos, newR = pos;

            const rightNode = segs.find({ left: pos + 1, right: 0 });
            if (rightNode && pos + 1 < n && arr[pos + 1] === ch) {
                const rightR = rightNode.getValue().right;
                segs.remove({ left: pos + 1, right: 0 });
                removeLen(rightR - (pos + 1) + 1);
                newR = rightR;
            }

            const leftFloorNode = segs.lowerBound({ left: pos - 1, right: 0 });
            if (leftFloorNode) {
                const lv = leftFloorNode.getValue();
                if (lv.right === pos - 1 && arr[pos - 1] === ch) {
                    segs.remove({ left: lv.left, right: 0 });
                    removeLen(lv.right - lv.left + 1);
                    newL = lv.left;
                }
            }

            segs.insert({ left: newL, right: newR });
            addLen(newR - newL + 1);
            arr[pos] = ch;
        }

        ans[q] = lens.max()!.getValue().len;
    }

    return ans;
}
```

```JavaScript
const { AvlTree } = require('@datastructures-js/binary-search-tree');

var longestRepeating = function(s, queryCharacters, queryIndices) {
    const n = s.length;
    const arr = s.split('');
    const segs = new AvlTree((a, b) => a.left - b.left);
    const lens = new AvlTree((a, b) => a.len - b.len);

    for (let i = 0; i < n; ) {
        let j = i;
        while (j < n && arr[j] === arr[i]) {
            j++;
        }
        segs.insert({ left: i, right: j - 1 });
        const length = j - i;
        const lenNode = lens.find({ len: length, count: 0 });
        if (lenNode) {
            lenNode.getValue().count++;
        } else {
            lens.insert({ len: length, count: 1 });
        }
        i = j;
    }

    const addLen = (len) => {
        const node = lens.find({ len, count: 0 });
        if (node) {
            node.getValue().count++;
        } else {
            lens.insert({ len, count: 1 });
        }
    };

    const removeLen = (len) => {
        const node = lens.find({ len, count: 0 });
        if (node && --node.getValue().count === 0) {
            lens.remove({ len, count: 0 });
        }
    };

    const k = queryIndices.length;
    const ans = new Array(k);

    for (let q = 0; q < k; q++) {
        const pos = queryIndices[q];
        const ch = queryCharacters[q];

        if (arr[pos] !== ch) {
            const floorNode = segs.lowerBound({ left: pos, right: 0 });
            const L = floorNode.getValue().left;
            const R = floorNode.getValue().right;
            segs.remove({ left: L, right: 0 });
            removeLen(R - L + 1);

            if (L <= pos - 1) {
                segs.insert({ left: L, right: pos - 1 });
                addLen(pos - L);
            }
            if (pos + 1 <= R) {
                segs.insert({ left: pos + 1, right: R });
                addLen(R - pos);
            }

            let newL = pos, newR = pos;

            const rightNode = segs.find({ left: pos + 1, right: 0 });
            if (rightNode && pos + 1 < n && arr[pos + 1] === ch) {
                const rightR = rightNode.getValue().right;
                segs.remove({ left: pos + 1, right: 0 });
                removeLen(rightR - (pos + 1) + 1);
                newR = rightR;
            }

            const leftFloorNode = segs.lowerBound({ left: pos - 1, right: 0 });
            if (leftFloorNode) {
                const lv = leftFloorNode.getValue();
                if (lv.right === pos - 1 && arr[pos - 1] === ch) {
                    segs.remove({ left: lv.left, right: 0 });
                    removeLen(lv.right - lv.left + 1);
                    newL = lv.left;
                }
            }

            segs.insert({ left: newL, right: newR });
            addLen(newR - newL + 1);
            arr[pos] = ch;
        }

        ans[q] = lens.max().getValue().len;
    }

    return ans;
};
```

```C
gint cmp(gconstpointer a, gconstpointer b, gpointer d) {
    return *(int*)a - *(int*)b;
}

int* longestRepeating(char* s, char* qc, int* qi, int qsz, int* rs) {
    int n = strlen(s);
    int* ans = malloc(qsz * sizeof(int));
    *rs = qsz;
    GTree* segs = g_tree_new_full(cmp, NULL, free, free);
    GTree* lens = g_tree_new_full(cmp, NULL, free, free);

    for (int i = 0; i < n; ) {
        int j = i;
        while (j < n && s[j] == s[i]) {
            j++;
        }
        int* L = malloc(sizeof(int));
        *L = i;
        int* R = malloc(sizeof(int));
        *R = j - 1;
        g_tree_insert(segs, L, R);
        int ln = j - i;
        int* cnt = g_tree_lookup(lens, &ln);
        if (cnt) {
            (*cnt)++;
        } else {
            int* k = malloc(sizeof(int));
            *k = ln;
            int* v = malloc(sizeof(int));
            *v = 1;
            g_tree_insert(lens, k, v);
        }
        i = j;
    }

    for (int q = 0; q < qsz; q++) {
        int pos = qi[q];
        char ch = qc[q];
        if (s[pos] == ch) {
            ans[q] = *(int*)g_tree_node_key(g_tree_node_last(lens));
            continue;
        }

        GTreeNode* nd = g_tree_upper_bound(segs, &pos);
        if (nd) {
            nd = g_tree_node_previous(nd);
        } else {
            nd = g_tree_node_last(segs);
        }
        int L = *(int*)g_tree_node_key(nd);
        int R = *(int*)g_tree_node_value(nd);

        int oLen = R - L + 1;
        int* cnt = g_tree_lookup(lens, &oLen);
        if (--(*cnt) == 0) {
            g_tree_remove(lens, &oLen);
        }
        g_tree_remove(segs, &L);
        int nL = pos, nR = pos;

        if (L < pos) {
            if (s[pos - 1] == ch) {
                nL = L;
            } else {
                int* Lp = malloc(sizeof(int));
                *Lp = L;
                int* Rp = malloc(sizeof(int));
                *Rp = pos - 1;
                g_tree_insert(segs, Lp, Rp);
                int l1 = pos - L;
                cnt = g_tree_lookup(lens, &l1);
                if (cnt) {
                    (*cnt)++;
                } else {
                    int* k = malloc(sizeof(int));
                    *k = l1;
                    int* v = malloc(sizeof(int));
                    *v = 1;
                    g_tree_insert(lens, k, v);
                }
            }
        }
        if (pos < R) {
            if (s[pos + 1] == ch) {
                nR = R;
            } else {
                int* Lp = malloc(sizeof(int));
                *Lp = pos + 1;
                int* Rp = malloc(sizeof(int));
                *Rp = R;
                g_tree_insert(segs, Lp, Rp);
                int l2 = R - pos;
                cnt = g_tree_lookup(lens, &l2);
                if (cnt) {
                    (*cnt)++;
                } else {
                    int* k = malloc(sizeof(int));
                    *k = l2;
                    int* v = malloc(sizeof(int));
                    *v = 1;
                    g_tree_insert(lens, k, v);
                }
            }
        }

        if (L == pos && pos > 0 && s[pos - 1] == ch) {
            GTreeNode* lo = g_tree_lower_bound(segs, &pos);
            GTreeNode* pv = lo ? g_tree_node_previous(lo) : g_tree_node_last(segs);
            if (pv) {
                int lk = *(int*)g_tree_node_key(pv);
                int lr = *(int*)g_tree_node_value(pv);
                if (lr == pos - 1) {
                    int ll = lr - lk + 1;
                    cnt = g_tree_lookup(lens, &ll);
                    if (--(*cnt) == 0) {
                        g_tree_remove(lens, &ll);
                    }
                    g_tree_remove(segs, &lk);
                    nL = lk;
                }
            }
        }
        if (R == pos && pos + 1 < n && s[pos + 1] == ch) {
            int pk = pos + 1;
            GTreeNode* rn = g_tree_lookup_node(segs, &pk);
            if (rn && *(int*)g_tree_node_key(rn) == pk) {
                int rr = *(int*)g_tree_node_value(rn);
                int rl = rr - pk + 1;
                cnt = g_tree_lookup(lens, &rl);
                if (--(*cnt) == 0) {
                    g_tree_remove(lens, &rl);
                }
                g_tree_remove(segs, &pk);
                nR = rr;
            }
        }

        int* Lp = malloc(sizeof(int));
        *Lp = nL;
        int* Rp = malloc(sizeof(int));
        *Rp = nR;
        g_tree_insert(segs, Lp, Rp);
        int nLen = nR - nL + 1;
        cnt = g_tree_lookup(lens, &nLen);
        if (cnt) {
            (*cnt)++;
        } else {
            int* k = malloc(sizeof(int));
            *k = nLen;
            int* v = malloc(sizeof(int));
            *v = 1;
            g_tree_insert(lens, k, v);
        }
        s[pos] = ch;
        ans[q] = *(int*)g_tree_node_key(g_tree_node_last(lens));
    }

    g_tree_destroy(segs);
    g_tree_destroy(lens);
    return ans;
}
```

```Rust
use std::collections::BTreeMap;

impl Solution {
    pub fn longest_repeating(s: String, query_characters: String, query_indices: Vec<i32>) -> Vec<i32> {
        let n = s.len();
        let mut s = s.into_bytes();
        let qc = query_characters.as_bytes();
        let mut segs: BTreeMap<usize, usize> = BTreeMap::new();
        let mut lens: BTreeMap<i32, i32> = BTreeMap::new();

        let mut i = 0;
        while i < n {
            let mut j = i;
            while j < n && s[j] == s[i] {
                j += 1;
            }
            segs.insert(i, j - 1);
            *lens.entry((j - i) as i32).or_insert(0) += 1;
            i = j;
        }

        let k = query_indices.len();
        let mut ans = vec![0; k];

        for q in 0..k {
            let pos = query_indices[q] as usize;
            let ch = qc[q];

            if s[pos] != ch {
                let (&L, &R) = segs.range(..=pos).next_back().unwrap();
                segs.remove(&L);
                let old_len = (R - L + 1) as i32;
                *lens.get_mut(&old_len).unwrap() -= 1;
                if lens[&old_len] == 0 {
                    lens.remove(&old_len);
                }

                if L <= pos - 1 {
                    segs.insert(L, pos - 1);
                    *lens.entry((pos - L) as i32).or_insert(0) += 1;
                }
                if pos + 1 <= R {
                    segs.insert(pos + 1, R);
                    *lens.entry((R - pos) as i32).or_insert(0) += 1;
                }

                let mut new_l = pos;
                let mut new_r = pos;

                if pos + 1 < n && s[pos + 1] == ch {
                    if let Some(&right_r) = segs.get(&(pos + 1)) {
                        let right_len = (right_r - (pos + 1) + 1) as i32;
                        *lens.get_mut(&right_len).unwrap() -= 1;
                        if lens[&right_len] == 0 {
                            lens.remove(&right_len);
                        }
                        new_r = right_r;
                        segs.remove(&(pos + 1));
                    }
                }

                if pos > 0 && s[pos - 1] == ch {
                    if let Some((&left_l, &left_r)) = segs.range(..pos).next_back() {
                        if left_r == pos - 1 {
                            let left_len = (left_r - left_l + 1) as i32;
                            *lens.get_mut(&left_len).unwrap() -= 1;
                            if lens[&left_len] == 0 {
                                lens.remove(&left_len);
                            }
                            new_l = left_l;
                            segs.remove(&left_l);
                        }
                    }
                }

                segs.insert(new_l, new_r);
                *lens.entry((new_r - new_l + 1) as i32).or_insert(0) += 1;
                s[pos] = ch;
            }

            ans[q] = *lens.keys().next_back().unwrap();
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+k)\log n)$，其中 $n$ 是字符串 $s$ 的长度，$k$ 是查询的数量。初始建立区间需要 $O(n\log n)$，每个查询中查找、删除和插入区间的操作均在有序集合中完成，每次 $O(\log n)$。
- 空间复杂度：$O(n)$，有序集合存储的区间数量不会超过 $n$。
