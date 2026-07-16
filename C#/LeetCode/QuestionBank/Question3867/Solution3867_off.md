### [数对的最大公约数之和](https://leetcode.cn/problems/sum-of-gcd-of-formed-pairs/solutions/3992717/shu-dui-de-zui-da-gong-yue-shu-zhi-he-by-lygl/)

#### 方法一：模拟

题目要求构造数组 $prefixGcd$。按照定义，我们需要首先得到数组 $mx$。

如果暴力计算每个 $mx_i$，时间复杂度将达到 $O(n^2)$，无法通过本题。注意到数组 $mx$ 实际上表示数组 $nums$ 的前缀最大值，因此可以借鉴前缀和的思想，在一次遍历中动态维护当前前缀最大值，从而在线性时间内构造出数组 $mx$。

随后，按照题目定义即可直接计算数组 $prefixGcd$。

对数组 $prefixGcd$ 排序后，我们需要不断将当前最小元素和最大元素配对，并将它们的最大公约数加入答案。这个过程可以使用双指针模拟实现。

需要注意的是，当数组长度为奇数时，最终会剩下一个未配对元素。根据题意，该元素应该被忽略。

```C++
class Solution {
public:
    long long gcdSum(vector<int>& nums) {
        int n = nums.size();

        vector<int> mx;
        int prefixMax = INT_MIN;

        for (int x : nums) {
            prefixMax = max(prefixMax, x);
            mx.push_back(prefixMax);
        }

        vector<int> prefixGcd;
        for (int i = 0; i < n; ++i) {
            prefixGcd.push_back(gcd(nums[i], mx[i]));
        }

        ranges::sort(prefixGcd);

        long long ans = 0;
        int left = 0, right = n - 1;
        while (left < right) {
            ans += gcd(prefixGcd[left], prefixGcd[right]);
            ++left;
            --right;
        }

        return ans;
    }
};
```

```Java
class Solution {
    public long gcdSum(int[] nums) {
        int n = nums.length;

        int[] mx = new int[n];
        int prefixMax = Integer.MIN_VALUE;

        for (int i = 0; i < n; ++i) {
            prefixMax = Math.max(prefixMax, nums[i]);
            mx[i] = prefixMax;
        }

        int[] prefixGcd = new int[n];
        for (int i = 0; i < n; ++i) {
            prefixGcd[i] = gcd(nums[i], mx[i]);
        }

        Arrays.sort(prefixGcd);

        long ans = 0;
        int left = 0, right = n - 1;
        while (left < right) {
            ans += gcd(prefixGcd[left], prefixGcd[right]);
            ++left;
            --right;
        }

        return ans;
    }

    public int gcd(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```CSharp
public class Solution {
    public long GcdSum(int[] nums) {
        int n = nums.Length;

        int[] mx = new int[n];
        int prefixMax = int.MinValue;

        for (int i = 0; i < n; ++i) {
            prefixMax = Math.Max(prefixMax, nums[i]);
            mx[i] = prefixMax;
        }

        int[] prefixGcd = new int[n];
        for (int i = 0; i < n; ++i) {
            prefixGcd[i] = GCD(nums[i], mx[i]);
        }

        Array.Sort(prefixGcd);

        long ans = 0;
        int left = 0, right = n - 1;
        while (left < right) {
            ans += GCD(prefixGcd[left], prefixGcd[right]);
            ++left;
            --right;
        }

        return ans;
    }

    public int GCD(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}
```

```Python
class Solution:
    def gcdSum(self, nums: list[int]) -> int:
        n = len(nums)
        mx = []
        prefixMax = -inf

        for x in nums:
            prefixMax = max(prefixMax, x)
            mx.append(prefixMax)

        prefixGcd = [gcd(x, y) for x, y in zip(nums, mx)]
        prefixGcd.sort()

        ans = 0
        left, right = 0, n - 1
        while left < right:
            ans += gcd(prefixGcd[left], prefixGcd[right])
            left += 1
            right -= 1
        return ans
```

```Go
func gcd(a, b int) int {
	for b != 0 {
		a, b = b, a % b
	}
	return a
}

func gcdSum(nums []int) int64 {
	n := len(nums)
	mx := make([]int, n)
	prefixMax := math.MinInt32

	for i, x := range nums {
		if x > prefixMax {
			prefixMax = x
		}
		mx[i] = prefixMax
	}

	prefixGcd := make([]int, n)
	for i := 0; i < n; i++ {
		prefixGcd[i] = gcd(nums[i], mx[i])
	}
	sort.Ints(prefixGcd)

	var ans int64 = 0
	left, right := 0, n - 1
	for left < right {
		ans += int64(gcd(prefixGcd[left], prefixGcd[right]))
		left++
		right--
	}

	return ans
}
```

```C
int gcd(int a, int b) {
    while (b != 0) {
        int t = b;
        b = a % b;
        a = t;
    }
    return a;
}

int cmp(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

long long gcdSum(int* nums, int numsSize) {
    int *mx = (int*)malloc(numsSize * sizeof(int));
    int prefixMax = INT_MIN;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] > prefixMax) prefixMax = nums[i];
        mx[i] = prefixMax;
    }

    int *prefixGcd = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; i++) {
        prefixGcd[i] = gcd(nums[i], mx[i]);
    }

    qsort(prefixGcd, numsSize, sizeof(int), cmp);
    long long ans = 0;
    int left = 0, right = numsSize - 1;
    while (left < right) {
        ans += gcd(prefixGcd[left], prefixGcd[right]);
        left++;
        right--;
    }

    free(mx);
    free(prefixGcd);
    return ans;
}
```

```JavaScript
var gcdSum = function(nums) {
    const gcd = (a, b) => {
        while (b !== 0) {
            [a, b] = [b, a % b];
        }
        return a;
    };

    const n = nums.length;
    const mx = new Array(n);
    let prefixMax = -Infinity;
    for (let i = 0; i < n; i++) {
        prefixMax = Math.max(prefixMax, nums[i]);
        mx[i] = prefixMax;
    }

    const prefixGcd = new Array(n);
    for (let i = 0; i < n; i++) {
        prefixGcd[i] = gcd(nums[i], mx[i]);
    }

    prefixGcd.sort((a, b) => a - b);
    let ans = 0;
    let left = 0, right = n - 1;
    while (left < right) {
        ans += gcd(prefixGcd[left], prefixGcd[right]);
        left++;
        right--;
    }
    return ans;
};
```

```TypeScript
function gcdSum(nums: number[]): number {
    const n: number = nums.length;
    const mx: number[] = new Array(n);
    let prefixMax: number = -Infinity;
    for (let i: number = 0; i < n; i++) {
        prefixMax = Math.max(prefixMax, nums[i]);
        mx[i] = prefixMax;
    }

    const prefixGcd: number[] = new Array(n);
    for (let i: number = 0; i < n; i++) {
        prefixGcd[i] = gcd(nums[i], mx[i]);
    }

    prefixGcd.sort((a, b) => a - b);
    let ans: number = 0;
    let left: number = 0, right: number = n - 1;
    while (left < right) {
        ans += gcd(prefixGcd[left], prefixGcd[right]);
        left++;
        right--;
    }
    return ans;
};

function gcd(a: number, b: number): number {
    while (b !== 0) {
        [a, b] = [b, a % b];
    }
    return a;
}

```

```Rust
impl Solution {
    fn gcd(a: i32, b: i32) -> i32 {
        if b == 0 {
            a
        } else {
            Self::gcd(b, a % b)
        }
    }

    pub fn gcd_sum(nums: Vec<i32>) -> i64 {
        let n = nums.len();
        let mut mx = vec![0; n];
        let mut prefixMax = i32::MIN;
        for (i, &x) in nums.iter().enumerate() {
            prefixMax = prefixMax.max(x);
            mx[i] = prefixMax;
        }

        let mut prefix_gcd: Vec<i32> = nums
            .iter()
            .zip(mx.iter())
            .map(|(&x, &m)| Self::gcd(x, m))
            .collect();

        prefix_gcd.sort();
        let mut ans: i64 = 0;
        let mut left = 0;
        let mut right = n - 1;
        while left < right {
            ans += Self::gcd(prefix_gcd[left], prefix_gcd[right]) as i64;
            left += 1;
            right -= 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+n\log U)$，其中 $n$ 为 $nums$ 的长度，$U$ 为数组 $nums$ 的最大值。$O(n\log n)$ 的时间复杂度来源于排序。此外，每次计算最大公约数的时间复杂度为 $O(\log U)$。
- 空间复杂度：$O(n)$，用于存储数组 $mx$ 和 $prefixGcd$。
