### [套餐内商品的排列顺序](https://leetcode.cn/problems/zi-fu-chuan-de-pai-lie-lcof/solutions/838947/zi-fu-chuan-de-pai-lie-by-leetcode-solut-hhvs/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：回溯

**思路及解法**

我们将这个问题看作有 $n$ 个排列成一行的空位，我们需要从左往右依次填入题目给定的 $n$ 个商品，每个商品只能使用一次。首先可以想到穷举的算法，即从左往右每一个空位都依次尝试填入一个商品，看是否能填完这 $n$ 个空位，编程实现时，我们可以用「回溯法」来模拟这个过程。

定义递归函数 $backtrack(i,perm)$ 表示当前排列为 $perm$，下一个待填入的空位是第 $i$ 个空位（下标从 $0$ 开始）。那么该递归函数分为两个情况：

- 如果 $i=n$，说明我们已经填完了 $n$ 个空位，找到了一个可行的解，我们将 $perm$ 放入答案数组中，递归结束。
- 如果 $i<n$，此时需要考虑第 $i$ 个空位填哪个商品。根据题目要求我们肯定不能填已经填过的商品，因此很容易想到的一个处理手段是我们定义一个标记数组 $vis$ 来标记已经填过的商品，那么在填第 $i$ 个商品的时候我们遍历题目给定的 $n$ 个商品，如果这个商品没有被标记过，我们就尝试填入，并将其标记，继续尝试填下一个空位，即调用函数 $backtrack(i+1,perm)$。回溯时，我们需要要撤销该空位填的商品以及对该商品的标记，并继续向当前空位尝试填入其他没被标记过的商品。

但是该递归函数并没有满足「全排列不重复」的要求，在重复的商品较多的情况下，该递归函数会生成大量重复的排列。对于任意一个空位，如果存在重复的商品，该递归函数会将它们重复填上去并继续尝试导致最后答案的重复。

解决该问题的一种较为直观的思路是，我们首先生成所有的排列，然后进行去重。而另一种思路是我们通过修改递归函数，使得该递归函数只会生成不重复的序列。

具体地，我们只要在递归函数中设定一个规则，保证在填每一个空位的时候**重复商品只会被填入一次**。具体地，我们首先对原商品串排序，保证相同的商品都相邻，在递归函数中，我们限制每次填入的商品一定是这个商品所在重复商品集合中「从左往右第一个未被填入的商品」，即如下的判断条件：

```C++
if (vis[j] || (j > 0 && !vis[j - 1] && goods[j - 1] == goods[j])) {
    continue;
}
```

这个限制条件保证了对于重复的商品，我们一定是从左往右依次填入的空位中的。

**代码**

```C++
class Solution {
public:
    vector<string> rec;
    vector<int> vis;

    void backtrack(const string& goods, int i, int n, string& perm) {
        if (i == n) {
            rec.push_back(perm);
            return;
        }
        for (int j = 0; j < n; j++) {
            if (vis[j] || (j > 0 && !vis[j - 1] && goods[j - 1] == goods[j])) {
                continue;
            }
            vis[j] = true;
            perm.push_back(goods[j]);
            backtrack(goods, i + 1, n, perm);
            perm.pop_back();
            vis[j] = false;
        }
    }

    vector<string> goodsOrder(string goods) {
        int n = goods.size();
        vis.resize(n);
        sort(goods.begin(), goods.end());
        string perm;
        backtrack(goods, 0, n, perm);
        return rec;
    }
};
```

```Java
class Solution {
    List<String> rec;
    boolean[] vis;

    public String[] goodsOrder(String goods) {
        int n = goods.length();
        rec = new ArrayList<String>();
        vis = new boolean[n];
        char[] arr = goods.toCharArray();
        Arrays.sort(arr);
        StringBuffer perm = new StringBuffer();
        backtrack(arr, 0, n, perm);
        int size = rec.size();
        String[] recArr = new String[size];
        for (int i = 0; i < size; i++) {
            recArr[i] = rec.get(i);
        }
        return recArr;
    }

    public void backtrack(char[] arr, int i, int n, StringBuffer perm) {
        if (i == n) {
            rec.add(perm.toString());
            return;
        }
        for (int j = 0; j < n; j++) {
            if (vis[j] || (j > 0 && !vis[j - 1] && arr[j - 1] == arr[j])) {
                continue;
            }
            vis[j] = true;
            perm.append(arr[j]);
            backtrack(arr, i + 1, n, perm);
            perm.deleteCharAt(perm.length() - 1);
            vis[j] = false;
        }
    }
}
```

```CSharp
public class Solution {
    IList<string> rec;
    bool[] vis;

    public string[] goodsOrder(string goods) {
        int n = goods.Length;
        rec = new List<string>();
        vis = new bool[n];
        char[] arr = goods.ToCharArray();
        Array.Sort(arr);
        StringBuilder perm = new StringBuilder();
        Backtrack(arr, 0, n, perm);
        int size = rec.Count;
        string[] recArr = new string[size];
        for (int i = 0; i < size; i++) {
            recArr[i] = rec[i];
        }
        return recArr;
    }

    public void Backtrack(char[] arr, int i, int n, StringBuilder perm) {
        if (i == n) {
            rec.Add(perm.ToString());
            return;
        }
        for (int j = 0; j < n; j++) {
            if (vis[j] || (j > 0 && !vis[j - 1] && arr[j - 1] == arr[j])) {
                continue;
            }
            vis[j] = true;
            perm.Append(arr[j]);
            Backtrack(arr, i + 1, n, perm);
            perm.Length--;
            vis[j] = false;
        }
    }
}
```

```JavaScript
var goodsOrder = function(goods) {
    const rec = [], vis = [];
    const n = goods.length;
    const arr = Array.from(goods).sort();
    const perm = [];
    const backtrack = (arr, i, n, perm) => {
        if (i === n) {
            rec.push(perm.toString());
            return;
        }
        for (let j = 0; j < n; j++) {
            if (vis[j] || (j > 0 && !vis[j - 1] && arr[j - 1] === arr[j])) {
                continue;
            }
            vis[j] = true;
            perm.push(arr[j]);
            backtrack(arr, i + 1, n, perm);
            perm.pop();
            vis[j] = false;
        }
    }

    backtrack(arr, 0, n, perm);
    const size = rec.length;
    const recArr = new Array(size).fill(0);
    for (let i = 0; i < size; i++) {
        recArr[i] = rec[i].split(',').join('');
    }
    return recArr;
};
```

```Go
func goodsOrder(goods string) (ans []string) {
    t := []byte(goods)
    sort.Slice(t, func(i, j int) bool { return t[i] < t[j] })
    n := len(t)
    perm := make([]byte, 0, n)
    vis := make([]bool, n)
    var backtrack func(int)
    backtrack = func(i int) {
        if i == n {
            ans = append(ans, string(perm))
            return
        }
        for j, b := range vis {
            if b || j > 0 && !vis[j-1] && t[j-1] == t[j] {
                continue
            }
            vis[j] = true
            perm = append(perm, t[j])
            backtrack(i + 1)
            perm = perm[:len(perm)-1]
            vis[j] = false
        }
    }
    backtrack(0)
    return
}
```

```C
void backtrack(char** rec, int* recSize, int* vis, char* goods, int i, int n, char* perm) {
    if (i == n) {
        char* tmp = malloc(sizeof(char) * (n + 1));
        strcpy(tmp, perm);
        rec[(*recSize)++] = tmp;
        return;
    }
    for (int j = 0; j < n; j++) {
        if (vis[j] || (j > 0 && !vis[j - 1] && goods[j - 1] == goods[j])) {
            continue;
        }
        vis[j] = true;
        perm[i] = goods[j];
        backtrack(rec, recSize, vis, goods, i + 1, n, perm);
        vis[j] = false;
    }
}

int cmp(char* a, char* b) {
    return *a - *b;
}

char** goodsOrder(char* goods, int* returnSize) {
    int n = strlen(goods);
    int recMaxSize = 1;
    for (int i = 2; i <= n; i++) {
        recMaxSize *= i;
    }
    char** rec = malloc(sizeof(char*) * recMaxSize);
    *returnSize = 0;
    int vis[n];
    memset(vis, 0, sizeof(vis));
    char perm[n + 1];
    perm[n] = '\0';
    qsort(goods, n, sizeof(char), cmp);
    backtrack(rec, returnSize, vis, goods, 0, n, perm);
    return rec;
}
```

**复杂度分析**

- 时间复杂度：$O(n\times n!)$，其中 $n$ 为给定商品串的长度。这些商品的全部排列有 $O(n!)$ 个，每个排列平均需要 $O(n)$ 的时间来生成。
- 空间复杂度：$O(n)$。我们需要 $O(n)$ 的栈空间进行回溯，注意返回值不计入空间复杂度。

#### 方法二：下一个排列

**思路及解法**

我们可以这样思考：当我们已知了当前的一个排列，我们能不能快速得到**字典序**中**下一个更大**的排列呢？

答案是肯定的，参见「[31\. 下一个排列的官方题解](https://leetcode.cn/problems/next-permutation/solution/xia-yi-ge-pai-lie-by-leetcode-solution/)」，当我们已知了当前的一个排列，我们可以在 $O(n)$ 的时间内计算出字典序下一个中更大的排列。这与 $C++$ 中的 $next\_permutation$ 函数功能相同。

具体地，我们首先对给定的商品串中的商品进行排序，即可得到当前商品串的第一个排列，然后我们不断地计算当前商品串的字典序中下一个更大的排列，直到不存在更大的排列为止即可。

这个方案的优秀之处在于，我们得到的所有排列都不可能重复，这样我们就无需进行去重的操作。同时因为无需使用回溯法，没有栈的开销，算法时间复杂度的常数较小。

**代码**

```C++
class Solution {
public:
    bool nextPermutation(string& goods) {
        int i = goods.size() - 2;
        while (i >= 0 && goods[i] >= goods[i + 1]) {
            i--;
        }
        if (i < 0) {
            return false;
        }
        int j = goods.size() - 1;
        while (j >= 0 && goods[i] >= goods[j]) {
            j--;
        }
        swap(goods[i], goods[j]);
        reverse(goods.begin() + i + 1, goods.end());
        return true;
    }

    vector<string> goodsOrder(string goods) {
        vector<string> ret;
        sort(goods.begin(), goods.end());
        do {
            ret.push_back(goods);
        } while (nextPermutation(goods));
        return ret;
    }
};
```

```Java
class Solution {
    public String[] goodsOrder(String goods) {
        List<String> ret = new ArrayList<String>();
        char[] arr = goods.toCharArray();
        Arrays.sort(arr);
        do {
            ret.add(new String(arr));
        } while (nextPermutation(arr));
        int size = ret.size();
        String[] retArr = new String[size];
        for (int i = 0; i < size; i++) {
            retArr[i] = ret.get(i);
        }
        return retArr;
    }

    public boolean nextPermutation(char[] arr) {
        int i = arr.length - 2;
        while (i >= 0 && arr[i] >= arr[i + 1]) {
            i--;
        }
        if (i < 0) {
            return false;
        }
        int j = arr.length - 1;
        while (j >= 0 && arr[i] >= arr[j]) {
            j--;
        }
        swap(arr, i, j);
        reverse(arr, i + 1);
        return true;
    }

    public void swap(char[] arr, int i, int j) {
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public void reverse(char[] arr, int start) {
        int left = start, right = arr.length - 1;
        while (left < right) {
            swap(arr, left, right);
            left++;
            right--;
        }
    }
}
```

```CSharp
public class Solution {
    public string[] goodsOrder(string goods) {
        IList<string> ret = new List<string>();
        char[] arr = goods.ToCharArray();
        Array.Sort(arr);
        do {
            ret.Add(new string(arr));
        } while (NextPermutation(arr));
        int size = ret.Count;
        string[] retArr = new string[size];
        for (int i = 0; i < size; i++) {
            retArr[i] = ret[i];
        }
        return retArr;
    }

    public bool NextPermutation(char[] arr) {
        int i = arr.Length - 2;
        while (i >= 0 && arr[i] >= arr[i + 1]) {
            i--;
        }
        if (i < 0) {
            return false;
        }
        int j = arr.Length - 1;
        while (j >= 0 && arr[i] >= arr[j]) {
            j--;
        }
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        Array.Reverse(arr, i + 1, arr.Length - i - 1);
        return true;
    }

    public void swap(char[] arr, int i, int j) {
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
```

```JavaScript
var goodsOrder = function(goods) {
    const ret = [];
    const arr = Array.from(goods).sort();

    const nextPermutation = (arr) => {
        let i = arr.length - 2;
        while (i >= 0 && arr[i] >= arr[i + 1]) {
            i--;
        }
        if (i < 0) {
            return false;
        }
        let j = arr.length - 1;
        while (j >= 0 && arr[i] >= arr[j]) {
            j--;
        }
        swap(arr, i, j);
        reverse(arr, i + 1);
        return true;
    }

    const swap = (arr, i, j) => {
        const temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    const reverse = (arr, start) => {
        let left = start, right = arr.length - 1;
        while (left < right) {
            swap(arr, left, right);
            left++;
            right--;
        }
    }

    do {
        ret.push(arr.join(''));
    } while (nextPermutation(arr));
    const size = ret.length;
    const retArr = new Array(size).fill(0);
    for (let i = 0; i < size; i++) {
        retArr[i] = ret[i];
    }
    return retArr;
};
```

```Go
func reverse(a []byte) {
    for i, n := 0, len(a); i < n/2; i++ {
        a[i], a[n-1-i] = a[n-1-i], a[i]
    }
}

func nextPermutation(nums []byte) bool {
    n := len(nums)
    i := n - 2
    for i >= 0 && nums[i] >= nums[i+1] {
        i--
    }
    if i < 0 {
        return false
    }
    j := n - 1
    for j >= 0 && nums[i] >= nums[j] {
        j--
    }
    nums[i], nums[j] = nums[j], nums[i]
    reverse(nums[i+1:])
    return true
}

func goodsOrder(goods string) (ans []string) {
    t := []byte(goods)
    sort.Slice(t, func(i, j int) bool { return t[i] < t[j] })
    for {
        ans = append(ans, string(t))
        if !nextPermutation(t) {
            break
        }
    }
    return
}
```

```C
void swap(char* a, char* b) {
    char t = *a;
    *a = *b, *b = t;
}

void reverse(char* goods, int i, int j) {
    while (i < j) {
        swap(&goods[i], &goods[j]);
        i++, j--;
    }
}

int cmp(char* a, char* b) {
    return *a - *b;
}

bool nextPermutation(char* goods, int sSize) {
    int i = sSize - 2;
    while (i >= 0 && goods[i] >= goods[i + 1]) {
        i--;
    }
    if (i < 0) {
        return false;
    }
    int j = sSize - 1;
    while (j >= 0 && goods[i] >= goods[j]) {
        j--;
    }
    swap(&goods[i], &goods[j]);
    reverse(goods, i + 1, sSize - 1);
    return true;
}

char** goodsOrder(char* goods, int* returnSize) {
    int n = strlen(goods);
    int recMaxSize = 1;
    for (int i = 2; i <= n; i++) {
        recMaxSize *= i;
    }
    char** rec = malloc(sizeof(char*) * recMaxSize);
    *returnSize = 0;
    qsort(goods, n, sizeof(char), cmp);
    do {
        char* tmp = malloc(sizeof(char) * (n + 1));
        strcpy(tmp, goods);
        rec[(*returnSize)++] = tmp;
    } while (nextPermutation(goods, n));
    return rec;
}
```

**复杂度分析**

- 时间复杂度：$O(n\times n!)$，其中 $n$ 为给定商品串的长度。我们需要 $O(n\log n)$ 的时间得到第一个排列，$nextPermutation$ 函数的时间复杂度为 $O(n)$，我们至多执行该函数 $O(n!)$ 次，因此总时间复杂度为 $O(n\times n!+n\log n)=O(n\times n!)$。
- 空间复杂度：$O(1)$。注意返回值不计入空间复杂度。
