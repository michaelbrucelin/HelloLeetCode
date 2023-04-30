﻿#### [Trie + 枚举](https://leetcode.cn/problems/stream-of-characters/solutions/1789250/by-ac_oier-ihd4/)

先考虑最为简单的做法：将给定的所有 $words[i]$ 顺序插入字典树，根据数据范围可知这一步计算量为 $2000 \times 200$，其中最大的 $words[i]$ 长度只有 $200$。

然后利用$words[i]$ 长度只有 $200$ 这一条件，直接使用「枚举」的方式来实现 `query`。

具体的，我们可以先使用一个字符串 `s` 来记录 `query` 操作产生的数据流，然后实现一个 `boolean query(int start, int end)` 方法，该方法会检查字典树中是否存在 $s[i...j]$ 子串。

由于 $words[i]$ 长度只有 $200$（假设当前 `s` 的长度为 $n$），因此我们只需要枚举「$\max(0, n - 200)$ 作为子串左端点，$n - 1$ 作为子串右端点」是否存在字典树中（是否存在 $words[i]$ 中）即可，最坏情况下，单次 `query` 操作计算量为 $200 \times 200$。

> 一些细节：为了避免每个样例都 `new` 大数组，我们可以使用 `static` 优化。

代码：

```java
class StreamChecker {
    static int N = 2010 * 200, idx = 0;
    static int[][] tr = new int[N][26];
    static boolean[] isEnd = new boolean[N * 26];
    StringBuilder sb = new StringBuilder();
    void add(String s) {
        int p = 0;
        for (int i = 0; i < s.length(); i++) {
            int u = s.charAt(i) - 'a';
            if (tr[p][u] == 0) tr[p][u] = ++idx;
            p = tr[p][u];
        }
        isEnd[p] = true;
    }
    boolean query(int start, int end) {
        int p = 0;
        for (int i = start; i <= end; i++) {
            int u = sb.charAt(i) - 'a';
            if (tr[p][u] == 0) return false;
            p = tr[p][u];
        }
        return isEnd[p];
    }
    public StreamChecker(String[] words) {
        for (int i = 0; i <= idx; i++) {
            Arrays.fill(tr[i], 0);
            isEnd[i] = false;
        }
        idx = 0;
        for (String s : words) add(s);
    }
    public boolean query(char c) {
        sb.append(c);
        int n = sb.length(), min = Math.max(0, n - 200);
        for (int i = n - 1; i >= min; i--) {
            if (query(i, n - 1)) return true;
        }
        return false;
    }
}
```

-   时间复杂度：`StreamChecker` 初始化复杂度为 $O(n)$，其中 $n$ 为 `words` 字符总数；`query` 操作复杂度为 $O(m^2)$，其中 $m = 200$ 为最大 `words[i]` 长度
-   空间复杂度：$O(n \times C)$，其中 $n$ 为 `words` 字符总数，$C = 26$ 为字符集大小

___

#### [Trie（优化）](https://leetcode.cn/problems/stream-of-characters/solutions/1789250/by-ac_oier-ihd4/)

初始化将所有的 $words[i]$ 存入 `Trie` 是必然的，我们只能考虑如何优化 `query` 操作。

在解法一中，我们需要对新数据流对应的字符串的每个后缀进行搜索，同时每次搜索是相互独立的，即本次匹配不会对下一次匹配产生贡献。

**实际上，我们可以通过「倒序建 `Trie`」的方式，将「枚举检查多个后缀」的操作变为「匹配一次后缀」操作。**

具体的，我们可以在初始化 `StreamChecker` 时，将每个 $words[i]$ 翻转（倒序）加入 `Trie` 中；然后在 `query` 操作时（假设当前数据流对应的字符串为 `s`，长度为 $n$），从 `s` 的尾部开始在 `Trie` 中进行检索（即从 $s[n - 1]$ 开始往回找）。

若在某个位置 `idx` 时匹配成功，意味着 $s[idx ... (n-1)]$ 的翻转子串在字典树中，同时我们又是将每个 `words[i]` 进行倒序插入，即意味着 $s[idx ... (n - 1)]$ 的正向子串在 `words` 中，即满足 `s` 的某个后缀出现在 `words` 中。

同理，我们可以利用最大的 `words[i]` 长度为 $200$ 来控制从 $s[n - 1]$ 开始往回找的最远距离，同时利用当某个短后缀不在 `Trie` 中，则其余长度更大的后缀必然不在 `Trie` 中进行剪枝操作。

代码：

```java
class StreamChecker {
    static int N = 2010 * 200, idx = 0;
    static int[][] tr = new int[N][26];
    static boolean[] isEnd = new boolean[N * 26];
    StringBuilder sb = new StringBuilder();
    void add(String s) {
        int p = 0;
        for (int i = s.length() - 1; i >= 0; i--) {
            int u = s.charAt(i) - 'a';
            if (tr[p][u] == 0) tr[p][u] = ++idx;
            p = tr[p][u];
        }
        isEnd[p] = true;
    }
    public StreamChecker(String[] words) {
        for (int i = 0; i <= idx; i++) {
            Arrays.fill(tr[i], 0);
            isEnd[i] = false;
        }
        idx = 0;
        for (String s : words) add(s);
    }
    public boolean query(char c) {
        sb.append(c);
        int n = sb.length(), min = Math.max(0, n - 200), p = 0;
        for (int i = n - 1; i >= min; i--) {
            if (isEnd[p]) return true;
            int u = sb.charAt(i) - 'a';
            if (tr[p][u] == 0) return false;
            p = tr[p][u];
        }
        return isEnd[p];
    }
}
```

-   时间复杂度：`StreamChecker` 初始化复杂度为 $O(n)$，其中 $n$ 为 `words` 字符总数；`query` 操作复杂度为 $O(m)$，其中 $m = 200$ 为最大 `words[i]` 长度
-   空间复杂度：$O(n \times C)$，其中 $n$ 为 `words` 字符总数，$C = 26$ 为字符集大小
