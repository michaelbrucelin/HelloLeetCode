### [一次遍历 + 三个并行DP状态](https://leetcode.cn/problems/trionic-array-ii/solutions/3895647/yi-ci-bian-li-san-ge-bing-xing-dpzhuang-ubyn4/)

#### 思路

#### 1\. 一次遍历，三个并行DP状态

##### 对于每个位置 i，用三个变量维护：

- `f1`: 以当前元素结尾的**递增段最大和** `（至少2个元素）`
- `f2`: 以当前元素结尾的**先增后减段最大和** `（至少3个元素）`
- `f3`: 以当前元素结尾的**三段式** `（增-减-增）` **最大和** `（至少4个元素）`

#### 2\. 状态转移（别搞错顺序）

##### 对于每个 `i（x = nums[i-1], y = nums[i]）`：

- **先更新 `f3（三段式）`：**
    - 需要最后是递增：`x < y`
    - 可以从 `f2` 或 `f3` **转移过来**
    - `f3 = max(f3, f2) + y`
- **再更新 `f2（先增后减）`：**
    - 需要**中间是递减**：`x > y`
    - 可以从 `f1` 或 `f2` 转移过来
    - `f2 = max(f2, f1) + y`
- **最后更新 `f1（递增段）`：**
    - 需要**开头是递增**：`x < y`
    - 可以从 `f1` 或`直接以 x 开始`
    - `f1 = max(f1, x) + y`

#### 3\. 注意事项

- **更新顺序**：必须从 `f3 → f2 → f1（后到前）`，因为 **`f3` 要用到旧的 `f2`，`f2` 要用到旧的 `f1`**
- **严格单调**：用 `x < y` 和 `x > y` 判断，**等于的情况全部重置**
- **初始化**：所有状态初始化为**负无穷**，**表示不可达**
- -**答案更新**：**每次更新后记录 `f3` 的最大值**

#### 复杂度

- 时间复杂度: $O(n)$，只遍历数组一次，每个元素只处理常数次
- 空间复杂度: $O(1)$，只使用了常数个额外变量`（f1, f2, f3, ans等）`

#### Code

```C++
class Solution {
public:
    long long maxSumTrionic(vector<int>& nums) {
        const long long NEG_INF = LLONG_MIN / 2; // 除 2 防止下面加法（和负数相加）溢出
        long long ans = NEG_INF, f1 = NEG_INF, f2 = NEG_INF, f3 = NEG_INF;
        for (int i = 1; i < nums.size(); i++) {
            long long x = nums[i - 1], y = nums[i];
            f3 = x < y ? max(f3, f2) + y : NEG_INF;
            f2 = x > y ? max(f2, f1) + y : NEG_INF;
            f1 = x < y ? max(f1, x) + y : NEG_INF;
            ans = max(ans, f3);
        }
        return ans;
    }
};
```

```JavaScript
var maxSumTrionic = function(nums) {
    const NEG_INF = Number.MIN_SAFE_INTEGER / 2;
    let ans = NEG_INF, f1 = NEG_INF, f2 = NEG_INF, f3 = NEG_INF;
    for (let i = 1; i < nums.length; i++) {
        const x = nums[i - 1], y = nums[i];
        f3 = x < y ? Math.max(f3, f2) + y : NEG_INF;
        f2 = x > y ? Math.max(f2, f1) + y : NEG_INF;
        f1 = x < y ? Math.max(f1, x) + y : NEG_INF;
        ans = Math.max(ans, f3);
    }
    return ans;
};
```

```Java
class Solution {
    public long maxSumTrionic(int[] nums) {
        final long NEG_INF = Long.MIN_VALUE / 2;
        long ans = NEG_INF, f1 = NEG_INF, f2 = NEG_INF, f3 = NEG_INF;
        for (int i = 1; i < nums.length; i++) {
            long x = nums[i - 1], y = nums[i];
            f3 = x < y ? Math.max(f3, f2) + y : NEG_INF;
            f2 = x > y ? Math.max(f2, f1) + y : NEG_INF;
            f1 = x < y ? Math.max(f1, x) + y : NEG_INF;
            ans = Math.max(ans, f3);
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maxSumTrionic(self, nums: List[int]) -> int:
        NEG_INF = -10**18
        ans = f1 = f2 = f3 = NEG_INF
        for i in range(1, len(nums)):
            x, y = nums[i-1], nums[i]

            # 注意顺序：f3 → f2 → f1
            f3 = f3 if x >= y else max(f3, f2) + y
            f2 = f2 if x <= y else max(f2, f1) + y
            f1 = f1 if x >= y else max(f1, x) + y

            # 重置不可达状态（用 if 判断替代三目运算的 else）
            if x >= y:
                f3 = NEG_INF
            if x <= y:
                f2 = NEG_INF
            if x >= y:
                f1 = NEG_INF
            ans = max(ans, f3)
        return ans
```

```Go
func maxSumTrionic(nums []int) int64 {
    const NEG_INF = int64(-1 << 62)
    var ans, f1, f2, f3 int64 = NEG_INF, NEG_INF, NEG_INF, NEG_INF
    for i := 1; i < len(nums); i++ {
        x, y := int64(nums[i-1]), int64(nums[i])
        if x < y {
            if f3 > f2 {
                f3 = f3 + y
            } else {
                f3 = f2 + y
            }
        } else {
            f3 = NEG_INF
        }

        if x > y {
            if f2 > f1 {
                f2 = f2 + y
            } else {
                f2 = f1 + y
            }
        } else {
            f2 = NEG_INF
        }

        if x < y {
            if f1 > x {
                f1 = f1 + y
            } else {
                f1 = x + y
            }
        } else {
            f1 = NEG_INF
        }

        if f3 > ans {
            ans = f3
        }
    }
    return ans
}
```

```Rust
impl Solution {
    pub fn max_sum_trionic(nums: Vec<i32>) -> i64 {
        const NEG_INF: i64 = i64::MIN / 2;
        let mut ans = NEG_INF;
        let mut f1 = NEG_INF;
        let mut f2 = NEG_INF;
        let mut f3 = NEG_INF;
        for i in 1..nums.len() {
            let x = nums[i - 1] as i64;
            let y = nums[i] as i64;
            f3 = if x < y { f3.max(f2) + y } else { NEG_INF };
            f2 = if x > y { f2.max(f1) + y } else { NEG_INF };
            f1 = if x < y { f1.max(x) + y } else { NEG_INF };
            ans = ans.max(f3);
        }
        ans
    }
}
```
