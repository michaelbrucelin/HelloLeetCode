### [可排序整数求和](https://leetcode.cn/problems/sum-of-sortable-integers/solutions/4039616/ke-pai-xu-zheng-shu-qiu-he-by-leetcode-s-k0y5/)

#### 前言

依据题目定义，可排序整数一定是数组 $nums$ 的长度 $n$ 的因数。因此，我们需要首先求出 $n$ 的所有因数。

我们有两种方法求出 $n$ 的所有因数。

1. 遍历所有在 $[1,n]$ 范围的整数 $k$，并判断 $n\bmod k$ 是否等于 $0$，时间复杂度为 $O(n)$。
2. 对任意一个在 $[\sqrt{n},n]$ 范围内的因数，一定有一个与其对称的在 $[1,\sqrt{n}]$ 范围内的因数。也就是说，如果整数 $k_1\in [\sqrt{n},n]$ 满足 $n\bmod k_1=0$，那么整数 $k_2=\dfrac{n}{k_1}\in [1,\sqrt{n}]$ 也一定满足 $n\bmod k_2=0$。

因此，我们可以将整数 $k$ 的遍历范围缩小至 $[1,\sqrt{n}]$，进而将时间复杂度降低为 $O(\sqrt{n})$。

上述的两种方法均可以通过本题。本文的示例代码中采用了第 $2$ 种方法求出 $n$ 的所有因数。

使用方法 $2$ 时需要额外注意，当我们枚举 $k$ 时，如果 $\dfrac{n}{k}=k$，则只需要将 $k$ 加入 $n$ 的因数列表，否则会出现重复。

另外，在方法 $2$ 中，我们最多遍历了 $n$ 个整数 $k$，每次遍历最多将 $2$ 个元素加入 $n$ 的因数列表，因此 $n$ 的因数个数有 $O(\sqrt{n})$ 个。

> 事实上，在 $[1,10^5]$ 的数据范围中，$n=83160$ 拥有最多的因子，为 $128$ 个。

此后，我们需要判断 $n$ 的某个因数 $k$ 是否是可排序整数。

依据题目定义，当判断 $k$ 是否是可排序整数时，我们需要将 $nums$ 划分为长度为 $k$ 的连续子数组（由于 $k$ 是 $n$ 的因数，因此这样的子数组恰好有 $\dfrac{n}{k}$ 个），并判断能否通过循环移动操作将 $nums$ 进行非递减排序。

记 $target$ 为数组 $nums$ 按**非递减顺序**排序后得到的数组。显然对于任意一个数组 $nums$，target 是唯一的。

现在，我们需要判断能否通过操作将 $nums$ 变为 $target$。

由于我们只能**独立地**对划分出来的子数组进行操作，因此不同子数组间的操作互不影响。要使得 $nums$ 变为 $target$，必须满足以下要求：

- 对于划分 $nums$ 得到的任意一个子数组 $nums[left..right]$，进行操作后必须严格等于 $target$ **对应位置**的子数组 $target[left..right]$。

下面介绍 2 种方法解决这个问题。

#### 方法一：KMP

上文中，我们需要解决的问题可以概括为：

- 给你 $2$ 个长度均为 $L$ 的数组 $nums_1$ 和 $nums_2$，能否通过对 $nums_1$ 进行若干次循环移动操作得到 $nums_2$？

这是一个非常经典的问题，类似题目可以参考「[796\. 旋转字符串](https://leetcode.cn/problems/rotate-string/)」。

暴力的做法是，我们枚举左移 $nums_1$ 的次数，并判断每次左移的结果是否与 $nums_2$ 一致。由于将 $nums_1$ 左移 $L$ 次后将重新得到原数组 $nums_1$，因此枚举的左移次数范围为 $[0,L-1]$。同时，右移 $k$ 次 与 左移 $L-k$ 次的结果一致，因此只需枚举左移的情况。这个做法的时间复杂度为 $O(L^2)$，无法通过本题。

注意到，数组 $nums_1+nums_1 (+$ 表示数组拼接操作) 包含了所有 $nums_1$ 进行循环移动操作得到的数组，因此，我们只需要判断 $nums_2$ 是否是 $nums_1+nums_1$ 的一个子数组即可。这个问题是「KMP」算法的模板问题，可以在 $O(L)$ 的时间复杂度下解决。不熟悉「KMP」算法的读者，可以参考「[28\. 找出字符串中第一个匹配项的下标](https://leetcode.cn/problems/find-the-index-of-the-first-occurrence-in-a-string/)」。

```Python
class Solution:
    def sortableIntegers(self, nums: List[int]) -> int:
        n = len(nums)

        fac = []
        for x in range(1, isqrt(n) + 1):
            if n % x == 0:
                fac.append(x)
                if n // x != x:
                    fac.append(n // x)

        target = sorted(nums)

        def kmp(nums1, nums2):
            n, m = len(nums1), len(nums2)

            pi = [0] * m
            j = 0

            for i in range(1, m):
                while j > 0 and nums2[i] != nums2[j]:
                    j = pi[j - 1]

                if nums2[i] == nums2[j]:
                    j += 1

                pi[i] = j

            j = 0
            for i in range(n):
                while j > 0 and nums1[i] != nums2[j]:
                    j = pi[j - 1]

                if nums1[i] == nums2[j]:
                    j += 1

                if j == m:
                    return True

            return False

        def check(nums1, nums2):
            # 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
            return kmp(nums1 + nums1, nums2)

        ans = 0

        for d in fac:
            for left in range(0, n, d):
                right = left + d - 1

                if not check(nums[left:right + 1], target[left:right + 1]):
                    break
            else:
                ans += d

        return ans
```

```C++
class Solution {
public:
    int sortableIntegers(vector<int>& nums) {
        int n = nums.size();
        vector<int> fac;

        for (int x = 1; x * x <= n; ++x) {
            if (n % x == 0) {
                fac.push_back(x);
                if (n / x != x) {
                    fac.push_back(n / x);
                }
            }
        }

        vector<int> target = nums;
        ranges::sort(target);

        auto kmp = [](const vector<int>& nums1, const vector<int>& nums2) {
            int n = nums1.size(), m = nums2.size();
            vector<int> pi(m, 0);
            int j = 0;

            for (int i = 1; i < m; ++i) {
                while (j > 0 && nums2[i] != nums2[j]) {
                    j = pi[j - 1];
                }
                if (nums2[i] == nums2[j]) {
                    ++j;
                }
                pi[i] = j;
            }

            j = 0;
            for (int i = 0; i < n; ++i) {
                while (j > 0 && nums1[i] != nums2[j]) {
                    j = pi[j - 1];
                }
                if (nums1[i] == nums2[j]) {
                    ++j;
                }
                if (j == m) {
                    return true;
                }
            }
            return false;
        };

        auto check = [&](const vector<int>& nums1, const vector<int>& nums2) {
            // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
            vector<int> doubled = nums1;
            doubled.insert(doubled.end(), nums1.begin(), nums1.end());
            return kmp(doubled, nums2);
        };

        int ans = 0;

        for (int d : fac) {
            bool allGood = true;
            for (int left = 0; left < n; left += d) {
                int right = left + d - 1;
                vector<int> sub1(nums.begin() + left, nums.begin() + right + 1);
                vector<int> sub2(target.begin() + left, target.begin() + right + 1);

                if (!check(sub1, sub2)) {
                    allGood = false;
                    break;
                }
            }
            if (allGood) {
                ans += d;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int sortableIntegers(int[] nums) {
        int n = nums.length;
        List<Integer> fac = new ArrayList<>();

        for (int x = 1; x * x <= n; x++) {
            if (n % x == 0) {
                fac.add(x);
                if (n / x != x) {
                    fac.add(n / x);
                }
            }
        }

        int[] target = nums.clone();
        Arrays.sort(target);

        int ans = 0;

        for (int d : fac) {
            boolean allGood = true;
            for (int left = 0; left < n; left += d) {
                int right = left + d - 1;
                int[] sub1 = Arrays.copyOfRange(nums, left, right + 1);
                int[] sub2 = Arrays.copyOfRange(target, left, right + 1);

                if (!check(sub1, sub2)) {
                    allGood = false;
                    break;
                }
            }
            if (allGood) {
                ans += d;
            }
        }

        return ans;
    }

    private boolean check(int[] nums1, int[] nums2) {
        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        int[] doubled = new int[nums1.length * 2];
        System.arraycopy(nums1, 0, doubled, 0, nums1.length);
        System.arraycopy(nums1, 0, doubled, nums1.length, nums1.length);

        return kmp(doubled, nums2);
    }

    private boolean kmp(int[] text, int[] pattern) {
        int n = text.length, m = pattern.length;
        int[] pi = new int[m];
        int j = 0;

        for (int i = 1; i < m; i++) {
            while (j > 0 && pattern[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (pattern[i] == pattern[j]) {
                j++;
            }
            pi[i] = j;
        }

        j = 0;
        for (int i = 0; i < n; i++) {
            while (j > 0 && text[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (text[i] == pattern[j]) {
                j++;
            }
            if (j == m) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public int SortableIntegers(int[] nums) {
        int n = nums.Length;
        List<int> fac = new List<int>();

        for (int x = 1; x * x <= n; x++) {
            if (n % x == 0) {
                fac.Add(x);
                if (n / x != x) {
                    fac.Add(n / x);
                }
            }
        }

        int[] target = (int[])nums.Clone();
        Array.Sort(target);

        int ans = 0;
        foreach (int d in fac) {
            bool allGood = true;
            for (int left = 0; left < n; left += d) {
                int right = left + d - 1;

                int[] sub1 = new int[d];
                int[] sub2 = new int[d];
                Array.Copy(nums, left, sub1, 0, d);
                Array.Copy(target, left, sub2, 0, d);

                if (!Check(sub1, sub2)) {
                    allGood = false;
                    break;
                }
            }
            if (allGood) {
                ans += d;
            }
        }

        return ans;
    }

    private bool Check(int[] nums1, int[] nums2) {
        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        int[] doubled = new int[nums1.Length * 2];
        Array.Copy(nums1, 0, doubled, 0, nums1.Length);
        Array.Copy(nums1, 0, doubled, nums1.Length, nums1.Length);

        return Kmp(doubled, nums2);
    }

    private bool Kmp(int[] text, int[] pattern) {
        int n = text.Length, m = pattern.Length;
        int[] pi = new int[m];
        int j = 0;

        for (int i = 1; i < m; i++) {
            while (j > 0 && pattern[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (pattern[i] == pattern[j]) {
                j++;
            }
            pi[i] = j;
        }

        j = 0;
        for (int i = 0; i < n; i++) {
            while (j > 0 && text[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (text[i] == pattern[j]) {
                j++;
            }
            if (j == m) {
                return true;
            }
        }
        return false;
    }
}
```

```Go
func sortableIntegers(nums []int) int {
    n := len(nums)
    var fac []int

    for x := 1; x*x <= n; x++ {
        if n%x == 0 {
            fac = append(fac, x)
            if n/x != x {
                fac = append(fac, n/x)
            }
        }
    }

    target := make([]int, n)
    copy(target, nums)
    sort.Ints(target)

    kmp := func(nums1, nums2 []int) bool {
        n, m := len(nums1), len(nums2)
        pi := make([]int, m)
        j := 0

        for i := 1; i < m; i++ {
            for j > 0 && nums2[i] != nums2[j] {
                j = pi[j-1]
            }
            if nums2[i] == nums2[j] {
                j++
            }
            pi[i] = j
        }

        j = 0
        for i := 0; i < n; i++ {
            for j > 0 && nums1[i] != nums2[j] {
                j = pi[j-1]
            }
            if nums1[i] == nums2[j] {
                j++
            }
            if j == m {
                return true
            }
        }
        return false
    }

    check := func(nums1, nums2 []int) bool {
        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        doubled := make([]int, len(nums1)*2)
        copy(doubled, nums1)
        copy(doubled[len(nums1):], nums1)
        return kmp(doubled, nums2)
    }

    ans := 0

    for _, d := range fac {
        allGood := true
        for left := 0; left < n; left += d {
            right := left + d - 1

            if !check(nums[left:right+1], target[left:right+1]) {
                allGood = false
                break
            }
        }
        if allGood {
            ans += d
        }
    }

    return ans
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int kmp(int* nums1, int n, int* nums2, int m) {
    int* pi = (int*)calloc(m, sizeof(int));
    int j = 0;

    for (int i = 1; i < m; i++) {
        while (j > 0 && nums2[i] != nums2[j]) {
            j = pi[j - 1];
        }
        if (nums2[i] == nums2[j]) {
            j++;
        }
        pi[i] = j;
    }

    j = 0;
    for (int i = 0; i < n; i++) {
        while (j > 0 && nums1[i] != nums2[j]) {
            j = pi[j - 1];
        }
        if (nums1[i] == nums2[j]) {
            j++;
        }
        if (j == m) {
            free(pi);
            return 1;
        }
    }
    free(pi);
    return 0;
}

int check(int* nums1, int len, int* nums2) {
    // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
    int* doubled = (int*)malloc(2 * len * sizeof(int));
    memcpy(doubled, nums1, len * sizeof(int));
    memcpy(doubled + len, nums1, len * sizeof(int));
    int result = kmp(doubled, 2 * len, nums2, len);
    free(doubled);
    return result;
}

int sortableIntegers(int* nums, int numsSize) {
    int n = numsSize;
    int* fac = (int*)malloc(n * sizeof(int));
    int facCount = 0;

    for (int x = 1; x * x <= n; x++) {
        if (n % x == 0) {
            fac[facCount++] = x;
            if (n / x != x) {
                fac[facCount++] = n / x;
            }
        }
    }

    int* target = (int*)malloc(n * sizeof(int));
    memcpy(target, nums, n * sizeof(int));
    qsort(target, n, sizeof(int), compare);

    int ans = 0;

    for (int i = 0; i < facCount; i++) {
        int d = fac[i];
        int allGood = 1;

        for (int left = 0; left < n; left += d) {
            int right = left + d - 1;

            if (!check(nums + left, d, target + left)) {
                allGood = 0;
                break;
            }
        }

        if (allGood) {
            ans += d;
        }
    }

    free(fac);
    free(target);
    return ans;
}
```

```JavaScript
var sortableIntegers = function(nums) {
    const n = nums.length;
    const fac = [];

    for (let x = 1; x * x <= n; x++) {
        if (n % x === 0) {
            fac.push(x);
            if (n / x !== x) {
                fac.push(n / x);
            }
        }
    }

    const target = [...nums].sort((a, b) => a - b);

    const kmp = (nums1, nums2) => {
        const n = nums1.length, m = nums2.length;
        const pi = new Array(m).fill(0);
        let j = 0;

        for (let i = 1; i < m; i++) {
            while (j > 0 && nums2[i] !== nums2[j]) {
                j = pi[j - 1];
            }
            if (nums2[i] === nums2[j]) {
                j++;
            }
            pi[i] = j;
        }

        j = 0;
        for (let i = 0; i < n; i++) {
            while (j > 0 && nums1[i] !== nums2[j]) {
                j = pi[j - 1];
            }
            if (nums1[i] === nums2[j]) {
                j++;
            }
            if (j === m) {
                return true;
            }
        }
        return false;
    };

    const check = (nums1, nums2) => {
        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        return kmp([...nums1, ...nums1], nums2);
    };

    let ans = 0;

    for (const d of fac) {
        let allGood = true;
        for (let left = 0; left < n; left += d) {
            const right = left + d - 1;

            if (!check(nums.slice(left, right + 1), target.slice(left, right + 1))) {
                allGood = false;
                break;
            }
        }
        if (allGood) {
            ans += d;
        }
    }

    return ans;
};
```

```TypeScript
function sortableIntegers(nums: number[]): number {
    const n = nums.length;
    const fac: number[] = [];

    for (let x = 1; x * x <= n; x++) {
        if (n % x === 0) {
            fac.push(x);
            if (n / x !== x) {
                fac.push(n / x);
            }
        }
    }

    const target = [...nums].sort((a, b) => a - b);

    const kmp = (nums1: number[], nums2: number[]): boolean => {
        const n = nums1.length, m = nums2.length;
        const pi: number[] = new Array(m).fill(0);
        let j = 0;

        for (let i = 1; i < m; i++) {
            while (j > 0 && nums2[i] !== nums2[j]) {
                j = pi[j - 1];
            }
            if (nums2[i] === nums2[j]) {
                j++;
            }
            pi[i] = j;
        }

        j = 0;
        for (let i = 0; i < n; i++) {
            while (j > 0 && nums1[i] !== nums2[j]) {
                j = pi[j - 1];
            }
            if (nums1[i] === nums2[j]) {
                j++;
            }
            if (j === m) {
                return true;
            }
        }
        return false;
    };

    const check = (nums1: number[], nums2: number[]): boolean => {
        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        return kmp([...nums1, ...nums1], nums2);
    };

    let ans = 0;

    for (const d of fac) {
        let allGood = true;
        for (let left = 0; left < n; left += d) {
            const right = left + d - 1;

            if (!check(nums.slice(left, right + 1), target.slice(left, right + 1))) {
                allGood = false;
                break;
            }
        }
        if (allGood) {
            ans += d;
        }
    }

    return ans;
};
```

```Rust
impl Solution {
    pub fn sortable_integers(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut fac = Vec::new();

        let mut x = 1;
        while x * x <= n {
            if n % x == 0 {
                fac.push(x);
                if n / x != x {
                    fac.push(n / x);
                }
            }
            x += 1;
        }

        let mut target = nums.clone();
        target.sort();

        fn kmp(nums1: &[i32], nums2: &[i32]) -> bool {
            let n = nums1.len();
            let m = nums2.len();
            let mut pi = vec![0; m];
            let mut j = 0;

            for i in 1..m {
                while j > 0 && nums2[i] != nums2[j] {
                    j = pi[j - 1];
                }
                if nums2[i] == nums2[j] {
                    j += 1;
                }
                pi[i] = j;
            }

            j = 0;
            for i in 0..n {
                while j > 0 && nums1[i] != nums2[j] {
                    j = pi[j - 1];
                }
                if nums1[i] == nums2[j] {
                    j += 1;
                }
                if j == m {
                    return true;
                }
            }
            false
        }

        fn check(nums1: &[i32], nums2: &[i32]) -> bool {
            // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
            let mut doubled = nums1.to_vec();
            doubled.extend_from_slice(nums1);
            kmp(&doubled, nums2)
        }

        let mut ans = 0;

        for d in fac {
            let mut all_good = true;
            let mut left = 0;
            while left < n {
                let right = left + d - 1;

                if !check(&nums[left..=right], &target[left..=right]) {
                    all_good = false;
                    break;
                }
                left += d;
            }
            if all_good {
                ans += d as i32;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\sqrt{n})$。
    $n$ 的因数个数有 $O(\sqrt{n})$ 个。对于每个因数 $k$，nums 会被划分为 $\dfrac{n}{k}$ 个长度为 $k$ 的子数组。如果忽略切片的时间复杂度，由于判断一个长度为 $k$ 的子数组是否能够通过循环移动变成目标子数组的时间复杂度为 $O(k)$，那么判断一个因数 $k$ 是否是可排序整数的时间复杂度为 $O(\dfrac{n}{k}\cdot k)=O(n)$，进而枚举所有因数的总体时间复杂度为 $O(n\sqrt{n})$。
    此外，对 $nums$ 排序需要 $O(n\log n)$ 的时间复杂度，求出 $n$ 的所有因数的时间复杂度为 $O(\sqrt{n})$，这些项都严格小于 $O(n\sqrt{n})$，因此在最终时间复杂度中被省略。
- 空间复杂度：$O(n)$。target 数组以及「KMP」算法需要 $O(n)$ 的空间，同时代码中的切片和数组拼接也需要 $O(n)$ 的临时空间。

#### 方法二：分类讨论

在方法一中，我们解决了以下问题：

- 给你 $2$ 个长度均为 $L$ 的数组 $nums_1$ 和 $nums_2$，能否通过对 $nums_1$ 进行若干次循环移动操作得到 nums_2？

方法一中的做法适用于任意给定的输入数组 $nums_1$ 和 $nums_2$。然而在本题中，输入数组还存在其他特殊性质。

现在我们采取以下方式对应有关变量：

- $nums_1=nums[left..right]$
- $nums_2=target[left..right]$

由于 $nums_2$ 是 $target$ 的一个子数组，因此 $nums_2$ 除了与 $nums_1$ 长度相同外，还具有一个额外性质：

- $nums_2$ 是非递减的

要想使得 $nums_1$ 在若干次循环移动后变成 $nums_2$，只能存在以下情况：

1. $nums_1$ 是非递减的。
    此时，一定有 $nums_1[0]\le nums_1[L-1]$。此时有以下两种情况。
    - $nums_1[0]=nums_1[L-1]$。由于 $nums_1$ 是非递减的，因此 $nums_1$ 中所有元素均相同，任何循环移动操作不会改变 $nums_1$。
    - $nums_1[0]<nums_1[L-1]$。如果循环移动操作后 $nums_1$ 发生了变化，那么 $nums_1[0]$ 将一定会在 $nums_1[L-1]$ 右侧。此时 $nums_1$ 不是非递减的，因此一定不会等于 $nums_2$。
    综上所述，我们不需要进行任何操作，直接判断 $nums_1$ 是否等于 $nums_2$ 即可。
2. $nums_1$ 不是非递减的。
    此时，一定存在至少一个下标 $i (0\le i<L-1)$ 满足 $nums_1[i]>nums_1[i+1]$。我们必须通过循环移动操作将 $nums_1[i]$ 和 $nums_1[i+1]$ 分开，否则 $nums_1$ 一定不是非递减的。在这种情况下，我们必须通过循环移动将 $nums_1[i+1]$ 变为数组的第一个元素（此时 $nums_1[i]$ 是最后一个元素），我们只需要检查该循环移动的结果即可。

基于以上讨论，我们对 $nums_1$ 的循环移动操作方式是完全确定的。我们只需要判断 $nums_1$ 是否非递减，并判断操作后的 $nums_1$ 是否等于 nums_2即可。时间复杂度为 $O(L)$。

```Python
class Solution:
    def sortableIntegers(self, nums: List[int]) -> int:
        n = len(nums)

        fac = []
        for x in range(1, isqrt(n) + 1):
            if n % x == 0:
                fac.append(x)
                if n // x != x:
                    fac.append(n // x)

        target = sorted(nums)

        def check(nums1, nums2):
            # 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
            L = len(nums1)

            for i in range(L - 1):
                if nums1[i] > nums1[i + 1]:
                    return nums1[i + 1:] + nums1[:i + 1] == nums2

            return nums1 == nums2

        ans = 0

        for d in fac:
            for left in range(0, n, d):
                right = left + d - 1

                if not check(nums[left:right + 1], target[left:right + 1]):
                    break
            else:
                ans += d

        return ans
```

```C++
class Solution {
public:
    int sortableIntegers(vector<int>& nums) {
        int n = nums.size();
        vector<int> fac;

        for (int x = 1; x * x <= n; ++x) {
            if (n % x == 0) {
                fac.push_back(x);
                if (n / x != x) {
                    fac.push_back(n / x);
                }
            }
        }

        vector<int> target = nums;
        ranges::sort(target);

        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        auto check = [](const vector<int>& nums1, const vector<int>& nums2) {
            int L = nums1.size();

            for (int i = 0; i < L - 1; ++i) {
                if (nums1[i] > nums1[i + 1]) {
                    vector<int> rotated;
                    rotated.insert(rotated.end(), nums1.begin() + i + 1, nums1.end());
                    rotated.insert(rotated.end(), nums1.begin(), nums1.begin() + i + 1);
                    return rotated == nums2;
                }
            }

            return nums1 == nums2;
        };

        int ans = 0;

        for (int d : fac) {
            bool allGood = true;
            for (int left = 0; left < n; left += d) {
                int right = left + d - 1;

                vector<int> sub1(nums.begin() + left, nums.begin() + right + 1);
                vector<int> sub2(target.begin() + left, target.begin() + right + 1);

                if (!check(sub1, sub2)) {
                    allGood = false;
                    break;
                }
            }
            if (allGood) {
                ans += d;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int sortableIntegers(int[] nums) {
        int n = nums.length;
        List<Integer> fac = new ArrayList<>();

        for (int x = 1; x * x <= n; x++) {
            if (n % x == 0) {
                fac.add(x);
                if (n / x != x) {
                    fac.add(n / x);
                }
            }
        }

        int[] target = nums.clone();
        Arrays.sort(target);

        int ans = 0;

        for (int d : fac) {
            boolean allGood = true;
            for (int left = 0; left < n; left += d) {
                int right = left + d - 1;

                int[] sub1 = Arrays.copyOfRange(nums, left, right + 1);
                int[] sub2 = Arrays.copyOfRange(target, left, right + 1);

                if (!check(sub1, sub2)) {
                    allGood = false;
                    break;
                }
            }
            if (allGood) {
                ans += d;
            }
        }

        return ans;
    }

    // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
    private boolean check(int[] nums1, int[] nums2) {
        int L = nums1.length;

        for (int i = 0; i < L - 1; i++) {
            if (nums1[i] > nums1[i + 1]) {
                int[] rotated = new int[L];
                System.arraycopy(nums1, i + 1, rotated, 0, L - i - 1);
                System.arraycopy(nums1, 0, rotated, L - i - 1, i + 1);
                return Arrays.equals(rotated, nums2);
            }
        }

        return Arrays.equals(nums1, nums2);
    }
}
```

```CSharp
public class Solution {
    public int SortableIntegers(int[] nums) {
        int n = nums.Length;
        List<int> fac = new List<int>();

        for (int x = 1; x * x <= n; x++) {
            if (n % x == 0) {
                fac.Add(x);
                if (n / x != x) {
                    fac.Add(n / x);
                }
            }
        }

        int[] target = (int[])nums.Clone();
        Array.Sort(target);

        int ans = 0;

        foreach (int d in fac) {
            bool allGood = true;
            for (int left = 0; left < n; left += d) {
                int right = left + d - 1;

                int[] sub1 = new int[d];
                int[] sub2 = new int[d];
                Array.Copy(nums, left, sub1, 0, d);
                Array.Copy(target, left, sub2, 0, d);

                if (!Check(sub1, sub2)) {
                    allGood = false;
                    break;
                }
            }
            if (allGood) {
                ans += d;
            }
        }

        return ans;
    }

    // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
    private bool Check(int[] nums1, int[] nums2) {
        int L = nums1.Length;

        for (int i = 0; i < L - 1; i++) {
            if (nums1[i] > nums1[i + 1]) {
                int[] rotated = new int[L];
                Array.Copy(nums1, i + 1, rotated, 0, L - i - 1);
                Array.Copy(nums1, 0, rotated, L - i - 1, i + 1);
                return rotated.SequenceEqual(nums2);
            }
        }

        return nums1.SequenceEqual(nums2);
    }
}
```

```Go
func sortableIntegers(nums []int) int {
    n := len(nums)
    var fac []int

    for x := 1; x*x <= n; x++ {
        if n % x == 0 {
            fac = append(fac, x)
            if n / x != x {
                fac = append(fac, n/x)
            }
        }
    }

    target := make([]int, n)
    copy(target, nums)
    sort.Ints(target)

    // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
    check := func(nums1, nums2 []int) bool {
        L := len(nums1)

        for i := 0; i < L-1; i++ {
            if nums1[i] > nums1[i+1] {
                rotated := make([]int, 0, L)
                rotated = append(rotated, nums1[i+1:]...)
                rotated = append(rotated, nums1[:i+1]...)

                if len(rotated) != len(nums2) {
                    return false
                }
                for j := range rotated {
                    if rotated[j] != nums2[j] {
                        return false
                    }
                }
                return true
            }
        }

        if len(nums1) != len(nums2) {
            return false
        }
        for i := range nums1 {
            if nums1[i] != nums2[i] {
                return false
            }
        }
        return true
    }

    ans := 0

    for _, d := range fac {
        allGood := true
        for left := 0; left < n; left += d {
            right := left + d - 1

            if !check(nums[left:right+1], target[left:right+1]) {
                allGood = false
                break
            }
        }
        if allGood {
            ans += d
        }
    }

    return ans
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

// 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
bool check(int* nums1, int len1, int* nums2, int len2) {
    if (len1 != len2) return false;

    int L = len1;

    for (int i = 0; i < L - 1; i++) {
        if (nums1[i] > nums1[i + 1]) {
            int* rotated = (int*)malloc(L * sizeof(int));
            memcpy(rotated, nums1 + i + 1, (L - i - 1) * sizeof(int));
            memcpy(rotated + L - i - 1, nums1, (i + 1) * sizeof(int));

            bool result = (memcmp(rotated, nums2, L * sizeof(int)) == 0);
            free(rotated);
            return result;
        }
    }

    return memcmp(nums1, nums2, L * sizeof(int)) == 0;
}

int sortableIntegers(int* nums, int numsSize) {
    int n = numsSize;
    int* fac = (int*)malloc(n * sizeof(int));
    int facCount = 0;

    for (int x = 1; x * x <= n; x++) {
        if (n % x == 0) {
            fac[facCount++] = x;
            if (n / x != x) {
                fac[facCount++] = n / x;
            }
        }
    }

    int* target = (int*)malloc(n * sizeof(int));
    memcpy(target, nums, n * sizeof(int));
    qsort(target, n, sizeof(int), compare);

    int ans = 0;

    for (int i = 0; i < facCount; i++) {
        int d = fac[i];
        bool allGood = true;

        for (int left = 0; left < n; left += d) {
            int right = left + d - 1;

            if (!check(nums + left, d, target + left, d)) {
                allGood = false;
                break;
            }
        }

        if (allGood) {
            ans += d;
        }
    }

    free(fac);
    free(target);
    return ans;
}
```

```JavaScript
var sortableIntegers = function(nums) {
    const n = nums.length;
    const fac = [];

    for (let x = 1; x * x <= n; x++) {
        if (n % x === 0) {
            fac.push(x);
            if (n / x !== x) {
                fac.push(n / x);
            }
        }
    }

    const target = [...nums].sort((a, b) => a - b);

    // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
    const check = (nums1, nums2) => {
        const L = nums1.length;

        for (let i = 0; i < L - 1; i++) {
            if (nums1[i] > nums1[i + 1]) {
                const rotated = [...nums1.slice(i + 1), ...nums1.slice(0, i + 1)];
                return rotated.every((val, idx) => val === nums2[idx]);
            }
        }

        return nums1.every((val, idx) => val === nums2[idx]);
    };

    let ans = 0;

    for (const d of fac) {
        let allGood = true;
        for (let left = 0; left < n; left += d) {
            const right = left + d - 1;

            if (!check(nums.slice(left, right + 1), target.slice(left, right + 1))) {
                allGood = false;
                break;
            }
        }
        if (allGood) {
            ans += d;
        }
    }

    return ans;
};
```

```TypeScript
function sortableIntegers(nums: number[]): number {
    const n = nums.length;
    const fac: number[] = [];

    for (let x = 1; x * x <= n; x++) {
        if (n % x === 0) {
            fac.push(x);
            if (n / x !== x) {
                fac.push(n / x);
            }
        }
    }

    const target = [...nums].sort((a, b) => a - b);

    // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
    const check = (nums1: number[], nums2: number[]): boolean => {
        const L = nums1.length;

        for (let i = 0; i < L - 1; i++) {
            if (nums1[i] > nums1[i + 1]) {
                const rotated = [...nums1.slice(i + 1), ...nums1.slice(0, i + 1)];
                return rotated.every((val, idx) => val === nums2[idx]);
            }
        }

        return nums1.every((val, idx) => val === nums2[idx]);
    };

    let ans = 0;

    for (const d of fac) {
        let allGood = true;
        for (let left = 0; left < n; left += d) {
            const right = left + d - 1;

            if (!check(nums.slice(left, right + 1), target.slice(left, right + 1))) {
                allGood = false;
                break;
            }
        }
        if (allGood) {
            ans += d;
        }
    }

    return ans;
};

```

```Rust
impl Solution {
    pub fn sortable_integers(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut fac = Vec::new();

        let mut x = 1;
        while x * x <= n {
            if n % x == 0 {
                fac.push(x);
                if n / x != x {
                    fac.push(n / x);
                }
            }
            x += 1;
        }

        let mut target = nums.clone();
        target.sort();

        // 检查能否通过对 nums1 进行若干次循环移动操作得到 nums2
        fn check(nums1: &[i32], nums2: &[i32]) -> bool {
            let l = nums1.len();

            for i in 0..l.saturating_sub(1) {
                if nums1[i] > nums1[i + 1] {
                    let mut rotated = Vec::with_capacity(l);
                    rotated.extend_from_slice(&nums1[i + 1..]);
                    rotated.extend_from_slice(&nums1[..i + 1]);
                    return rotated == nums2;
                }
            }

            nums1 == nums2
        }

        let mut ans = 0;

        for d in fac {
            let mut all_good = true;
            let mut left = 0;
            while left < n {
                let right = left + d - 1;

                if !check(&nums[left..=right], &target[left..=right]) {
                    all_good = false;
                    break;
                }
                left += d;
            }
            if all_good {
                ans += d as i32;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\sqrt{n})$。
- 空间复杂度：$O(n)$。target 数组以及代码中的切片和数组拼接需要 $O(n)$ 的临时空间。
