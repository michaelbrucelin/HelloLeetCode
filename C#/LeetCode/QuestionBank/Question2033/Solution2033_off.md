### [获取单值网格的最小操作数](https://leetcode.cn/problems/minimum-operations-to-make-a-uni-value-grid/solutions/3957466/huo-qu-dan-zhi-wang-ge-de-zui-xiao-cao-z-g7l2/)

#### 方法一：找中位数

**思路与算法**

所有元素只能加减 $x$，因此任意两个元素之差必须是 $x$ 的倍数，否则无法使它们相等。我们遍历网格，将所有元素取出放入一维数组 $nums$，同时检查 $(grid[i][j]-grid[0][0])\bmod x$ 是否等于 $0$。如果存在不满足的元素，直接返回 $-1$。

接下来，我们将 $nums$ 排序。由于每次操作改变量为 $x$，将元素 $nums[i]$ 变为目标值 $t$ 的操作次数为 $\dfrac{\vert nums[i]-t\vert}{x}$，因此问题等价于最小化 $\sum_i\vert nums[i]-t\vert$。

根据中位数的性质，当 $t$ 取排序后数组的中位数时，绝对值之和最小。因此我们令 $choose=nums[\lfloor\dfrac{mn}{2}\rfloor ]$，遍历 $nums$，将每个元素 $num$ 到 $choose$ 的操作次数 $\dfrac{\vert num-choose\vert}{x}$ 累加到答案中即可。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<vector<int>>& grid, int x) {
        vector<int> nums;
        int m = grid.size(), n = grid[0].size();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if ((grid[i][j] - grid[0][0]) % x != 0) {
                    return -1;
                }
                nums.push_back(grid[i][j]);
            }
        }

        sort(nums.begin(), nums.end());
        int choose = nums[nums.size() / 2];
        int ans = 0;
        for (int num: nums) {
            ans += abs(num - choose) / x;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minOperations(self, grid: List[List[int]], x: int) -> int:
        m, n = len(grid), len(grid[0])
        nums = list()
        for i in range(m):
            for j in range(n):
                if (grid[i][j] - grid[0][0]) % x != 0:
                    return -1
                nums.append(grid[i][j])

        nums.sort()
        choose = nums[len(nums) // 2]
        ans = 0
        for num in nums:
            ans += abs(num - choose) // x
        return ans
```

```Java
class Solution {
    public int minOperations(int[][] grid, int x) {
        List<Integer> nums = new ArrayList<>();
        int m = grid.length, n = grid[0].length;
        int base = grid[0][0];

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if ((grid[i][j] - base) % x != 0) {
                    return -1;
                }
                nums.add(grid[i][j]);
            }
        }

        Collections.sort(nums);
        int choose = nums.get(nums.size() / 2);
        int ans = 0;
        for (int num : nums) {
            ans += Math.abs(num - choose) / x;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinOperations(int[][] grid, int x) {
        List<int> nums = new List<int>();
        int m = grid.Length, n = grid[0].Length;
        int baseVal = grid[0][0];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if ((grid[i][j] - baseVal) % x != 0) {
                    return -1;
                }
                nums.Add(grid[i][j]);
            }
        }

        nums.Sort();
        int choose = nums[nums.Count / 2];
        int ans = 0;
        foreach (int num in nums) {
            ans += Math.Abs(num - choose) / x;
        }
        return ans;
    }
}
```

```Go
func minOperations(grid [][]int, x int) int {
	nums := []int{}
	m, n := len(grid), len(grid[0])
	base := grid[0][0]

	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			if (grid[i][j]-base)%x != 0 {
				return -1
			}
			nums = append(nums, grid[i][j])
		}
	}

	sort.Ints(nums)
	choose := nums[len(nums)/2]
	ans := 0
	for _, num := range nums {
		diff := num - choose
		if diff < 0 {
			diff = -diff
		}
		ans += diff / x
	}
	return ans
}
```

```C
int cmp(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int minOperations(int** grid, int gridSize, int* gridColSize, int x) {
    int m = gridSize, n = gridColSize[0];
    int total = m * n;
    int* nums = (int*)malloc(total * sizeof(int));
    int base = grid[0][0];
    int idx = 0;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if ((grid[i][j] - base) % x != 0) {
                free(nums);
                return -1;
            }
            nums[idx++] = grid[i][j];
        }
    }

    qsort(nums, total, sizeof(int), cmp);
    int choose = nums[total / 2];
    int ans = 0;
    for (int i = 0; i < total; i++) {
        ans += abs(nums[i] - choose) / x;
    }

    free(nums);
    return ans;
}
```

```JavaScript
var minOperations = function(grid, x) {
    const nums = [];
    const m = grid.length, n = grid[0].length;
    const base = grid[0][0];

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if ((grid[i][j] - base) % x !== 0) {
                return -1;
            }
            nums.push(grid[i][j]);
        }
    }

    nums.sort((a, b) => a - b);
    const choose = nums[Math.floor(nums.length / 2)];
    let ans = 0;
    for (const num of nums) {
        ans += Math.abs(num - choose) / x;
    }
    return ans;
};
```

```TypeScript
function minOperations(grid: number[][], x: number): number {
    const nums: number[] = [];
    const m = grid.length, n = grid[0].length;
    const base = grid[0][0];

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if ((grid[i][j] - base) % x !== 0) {
                return -1;
            }
            nums.push(grid[i][j]);
        }
    }

    nums.sort((a, b) => a - b);
    const choose = nums[Math.floor(nums.length / 2)];
    let ans = 0;
    for (const num of nums) {
        ans += Math.abs(num - choose) / x;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn min_operations(grid: Vec<Vec<i32>>, x: i32) -> i32 {
        let mut nums = Vec::new();
        let m = grid.len();
        let n = grid[0].len();
        let base = grid[0][0];

        for i in 0..m {
            for j in 0..n {
                if (grid[i][j] - base) % x != 0 {
                    return -1;
                }
                nums.push(grid[i][j]);
            }
        }

        nums.sort();
        let choose = nums[nums.len() / 2];
        let mut ans = 0;
        for num in nums {
            ans += (num - choose).abs() / x;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn\log (mn))$，其中 $m$ 和 $n$ 分别是网格的行数和列数。将网格元素展平后排序需要 $O(mn\log (mn))$ 的时间，遍历数组计算答案需要 $O(mn)$ 的时间。
- 空间复杂度：$O(mn)$，即为一维数组 $nums$ 需要使用的空间。
