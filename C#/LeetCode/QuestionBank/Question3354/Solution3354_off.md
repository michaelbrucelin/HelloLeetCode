### [使数组元素等于零](https://leetcode.cn/problems/make-array-elements-equal-to-zero/solutions/3810607/shi-shu-zu-yuan-su-deng-yu-ling-by-leetc-0cvo/)

#### 方法一：模拟

**思路与算法**

由于数据量较小，我们可以直接模拟每种方案并判断是否有效。

将数组 $nums$ 中每个为 $0$ 元素的位置作为初始位置，分别向两个方向进行模拟。模拟时，我们判断当前元素是否为 $0$，如果为 $0$ 继续朝原方向移动，否则将当前值减 $1$，并将方向反转，移动到下一个位置。当所有元素变为 $0$ 或移动到数组下标范围外时模拟结束时。如果此时所有元素都变为 $0$ 则是有效方案。

**代码**

```C++
class Solution {
public:
    int countValidSelections(vector<int>& nums) {
        int count = 0;
        int nonZeros = 0;
        int n = nums.size();

        for (int i = 0; i < n; i++) {
            if (nums[i] > 0) {
                nonZeros++;
            }
        }

        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (isValid(nums, nonZeros, i, -1)) {
                    count++;
                }
                if (isValid(nums, nonZeros, i, 1)) {
                    count++;
                }
            }
        }

        return count;
    }

private:
    bool isValid(const vector<int>& nums, int nonZeros, int start,
                 int direction) {
        int n = nums.size();
        vector<int> temp(nums);
        int curr = start;

        while (nonZeros > 0 && curr >= 0 && curr < n) {
            if (temp[curr] > 0) {
                temp[curr]--;
                direction *= -1;
                if (temp[curr] == 0) {
                    nonZeros--;
                }
            }
            curr += direction;
        }

        return nonZeros == 0;
    }
};

```

```Java
class Solution {
    public int countValidSelections(int[] nums) {
        int count = 0, nonZeros = 0, n = nums.length;
        for (int x : nums) if (x > 0) {
            nonZeros++;
        }
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (isValid(nums, nonZeros, i, -1)) {
                    count++;
                }
                if (isValid(nums, nonZeros, i, 1)) {
                    count++;
                }
            }
        }
        return count;
    }
    private boolean isValid(int[] nums, int nonZeros, int start, int direction) {
        int n = nums.length, curr = start;
        int[] temp = nums.clone();
        while (nonZeros > 0 && curr >= 0 && curr < n) {
            if (temp[curr] > 0) {
                temp[curr]--;
                direction *= -1;
                if (temp[curr] == 0) {
                    nonZeros--;
                }
            }
            curr += direction;
        }
        return nonZeros == 0;
    }
}
```

```Python
class Solution:
    def countValidSelections(self, nums):
        count = 0
        nonZeros = sum(1 for x in nums if x > 0)
        n = len(nums)
        for i in range(n):
            if nums[i] == 0:
                if self.isValid(nums, nonZeros, i, -1):
                    count += 1
                if self.isValid(nums, nonZeros, i, 1):
                    count += 1
        return count

    def isValid(self, nums, nonZeros, start, direction):
        temp = nums[:]
        curr = start
        while nonZeros > 0 and 0 <= curr < len(nums):
            if temp[curr] > 0:
                temp[curr] -= 1
                direction *= -1
                if temp[curr] == 0:
                    nonZeros -= 1
            curr += direction
        return nonZeros == 0

```

```Go
func countValidSelections(nums []int) int {
    count, nonZeros, n := 0, 0, len(nums)
    for _, x := range nums {
        if x > 0 {
            nonZeros++
        }
    }
    for i := 0; i < n; i++ {
        if nums[i] == 0 {
            if isValid(nums, nonZeros, i, -1) {
                count++
            }
            if isValid(nums, nonZeros, i, 1) {
                count++
            }
        }
    }
    return count
}

func isValid(nums []int, nonZeros, start, direction int) bool {
    temp := make([]int, len(nums))
    copy(temp, nums)
    curr := start
    for nonZeros > 0 && curr >= 0 && curr < len(nums) {
        if temp[curr] > 0 {
            temp[curr]--
            direction *= -1
            if temp[curr] == 0 {
                nonZeros--
            }
        }
        curr += direction
    }
    return nonZeros == 0
}

```

```CSharp
class Solution {
    public int CountValidSelections(int[] nums) {
        int count = 0, nonZeros = nums.Count(x => x > 0), n = nums.Length;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (IsValid(nums, nonZeros, i, -1)) {
                    count++;
                }
                if (IsValid(nums, nonZeros, i, 1)) count++;
            }
        }
        return count;
    }

    bool IsValid(int[] nums, int nonZeros, int start, int direction) {
        int n = nums.Length;
        int[] temp = (int[])nums.Clone();
        int curr = start;
        while (nonZeros > 0 && curr >= 0 && curr < n) {
            if (temp[curr] > 0) {
                temp[curr]--;
                direction *= -1;
                if (temp[curr] == 0) {
                    nonZeros--;
                }
            }
            curr += direction;
        }
        return nonZeros == 0;
    }
}
```

```C
int isValid(int* nums, int n, int nonZeros, int start, int direction) {
    int temp[1000];
    memcpy(temp, nums, n * sizeof(int));
    int curr = start;
    while (nonZeros > 0 && curr >= 0 && curr < n) {
        if (temp[curr] > 0) {
            temp[curr]--;
            direction *= -1;
            if (temp[curr] == 0) {
                nonZeros--;
            }
        }
        curr += direction;
    }
    return nonZeros == 0;
}

int countValidSelections(int* nums, int n) {
    int count = 0, nonZeros = 0;
    for (int i = 0; i < n; i++) {
        if (nums[i] > 0) {
            nonZeros++;
        }
    }
    for (int i = 0; i < n; i++) {
        if (nums[i] == 0) {
            if (isValid(nums, n, nonZeros, i, -1)) {
                count++;
            }
            if (isValid(nums, n, nonZeros, i, 1)) {
                count++;
            }
        }
    }
    return count;
}
```

```JavaScript
var countValidSelections = function (nums) {
    let count = 0, nonZeros = nums.filter(x => x > 0).length, n = nums.length;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 0) {
            if (isValid([...nums], nonZeros, i, -1)) {
                count++;
            }
            if (isValid([...nums], nonZeros, i, 1)) {
                count++;
            }
        }
    }
    return count;
};


function isValid(nums, nonZeros, start, direction) {
    let curr = start;
    while (nonZeros > 0 && curr >= 0 && curr < nums.length) {
        if (nums[curr] > 0) {
            nums[curr]--;
            direction *= -1;
            if (nums[curr] === 0) {
                nonZeros--;
            }
        }
        curr += direction;
    }
    return nonZeros === 0;
}
```

```TypeScript
function countValidSelections(nums: number[]): number {
    let count = 0, nonZeros = nums.filter(x => x > 0).length, n = nums.length;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 0) {
            if (isValid([...nums], nonZeros, i, -1)) {
                count++;
            }
            if (isValid([...nums], nonZeros, i, 1)) {
                count++;
            }
        }
    }
    return count;
};

function isValid(nums, nonZeros, start, direction) {
    let curr = start;
    while (nonZeros > 0 && curr >= 0 && curr < nums.length) {
        if (nums[curr] > 0) {
            nums[curr]--;
            direction *= -1;
            if (nums[curr] === 0) {
                nonZeros--;
            }
        }
        curr += direction;
    }
    return nonZeros === 0;
}
```

```Rust
impl Solution {
    pub fn count_valid_selections(nums: Vec<i32>) -> i32 {
        let mut count = 0;
        let nonzeros = nums.iter().filter(|&&x| x > 0).count() as i32;
        let n = nums.len();
        for i in 0..n {
            if nums[i] == 0 {
                if Self::is_valid(&nums, nonzeros, i as i32, -1) { count += 1; }
                if Self::is_valid(&nums, nonzeros, i as i32, 1) { count += 1; }
            }
        }
        count
    }

    fn is_valid(nums: &Vec<i32>, nonzeros: i32, start: i32, mut direction: i32) -> bool {
        let n = nums.len() as i32;
        let mut temp = nums.clone();
        let mut nz = nonzeros;
        let mut curr = start;
        while nz > 0 && curr >= 0 && curr < n {
            if temp[curr as usize] > 0 {
                temp[curr as usize] -= 1;
                direction *= -1;
                if temp[curr as usize] == 0 { nz -= 1; }
            }
            curr += direction;
        }
        nz == 0
    }
}

```

**复杂度分析**

- 时间复杂度：$O(n^2m)$，其中 $n$ 是数组 $nums$ 的长度，$m$ 是数组 $nums$ 中的最大元素。一共有 $O(n)$ 个可能的初始位置，每个初始位置分别向两个方向模拟，每次模拟需要 $O(nm)$，因此总时间复杂度为 $O(n^2m)$。
- 空间复杂度：$O(n)$。需要使用一个数组拷贝 $nums$ 数组以进行模拟。

#### 方法二：前缀和

**思路与算法**

我们可以把整个过程看成是“打砖块”游戏，对于每一个选取的初始位置，有一个小球在左右方向上来回弹跳，每次遇到正数就反弹，同时将正数减少 $1$。

为了消除所有的正数，假设初始方向向右，那么初始位置两边元素的和应该相等，或者右边元素和比左边元素和大 $1$，此时球会在右边完成最后一次反弹，并从左边离开。那么初始方向向左时，情况是类似的。

我们可以枚举每一个为 $0$ 的位置作为初始位置，并利用前缀和计算出左右两边的元素和，判断是否为有效选择方案。

**代码**

```C++
class Solution {
public:
    int countValidSelections(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        int sum = accumulate(nums.begin(), nums.end(), 0);
        int leftSum = 0;
        int rightSum = sum;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (leftSum - rightSum >= 0 && leftSum - rightSum <= 1){
                    ans++;
                }
                if (rightSum - leftSum >= 0 && rightSum - leftSum <= 1){
                    ans++;
                }
            } else {
                leftSum += nums[i];
                rightSum -= nums[i];
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int countValidSelections(int[] nums) {
        int n = nums.length, ans = 0, sum = 0;
        for (int x : nums) {
            sum += x;
        }
        int leftSum = 0, rightSum = sum;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (leftSum - rightSum >= 0 && leftSum - rightSum <= 1) {
                    ans++;
                }
                if (rightSum - leftSum >= 0 && rightSum - leftSum <= 1) {
                    ans++;
                }
            } else {
                leftSum += nums[i];
                rightSum -= nums[i];
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def countValidSelections(self, nums):
        n = len(nums)
        ans = 0
        s = sum(nums)
        left, right = 0, s
        for i in range(n):
            if nums[i] == 0:
                if 0 <= left - right <= 1:
                    ans += 1
                if 0 <= right - left <= 1:
                    ans += 1
            else:
                left += nums[i]
                right -= nums[i]
        return ans
```

```Go
func countValidSelections(nums []int) int {
    n := len(nums)
    sum := 0
    for _, x := range nums {
        sum += x
    }
    ans, leftSum, rightSum := 0, 0, sum
    for i := 0; i < n; i++ {
        if nums[i] == 0 {
            if leftSum-rightSum >= 0 && leftSum-rightSum <= 1 {
                ans++
            }
            if rightSum-leftSum >= 0 && rightSum-leftSum <= 1 {
                ans++
            }
        } else {
            leftSum += nums[i]
            rightSum -= nums[i]
        }
    }
    return ans
}
```

```CSharp
public class Solution {
    public int CountValidSelections(int[] nums) {
        int n = nums.Length, ans = 0;
        int sum = nums.Sum();
        int left = 0, right = sum;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (left - right >= 0 && left - right <= 1) {
                    ans++;
                }
                if (right - left >= 0 && right - left <= 1) {
                    ans++;
                }
            } else {
                left += nums[i];
                right -= nums[i];
            }
        }
        return ans;
    }
}
```

```C
int countValidSelections(int* nums, int n) {
    int ans = 0, sum = 0;
    for (int i = 0; i < n; i++) {
        sum += nums[i];
    }
    int left = 0, right = sum;
    for (int i = 0; i < n; i++) {
        if (nums[i] == 0) {
            if (left - right >= 0 && left - right <= 1) {
                ans++;
            }
            if (right - left >= 0 && right - left <= 1) {
                ans++;
            }
        } else {
            left += nums[i];
            right -= nums[i];
        }
    }
    return ans;
}
```

```JavaScript
var countValidSelections = function(nums) {
    let n = nums.length, ans = 0;
    let sum = nums.reduce((a,b)=>a+b,0);
    let left = 0, right = sum;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 0) {
            if (left - right >= 0 && left - right <= 1) {
                ans++;
            }
            if (right - left >= 0 && right - left <= 1) {
                ans++;
            }
        } else {
            left += nums[i];
            right -= nums[i];
        }
    }
    return ans;
};
```

```TypeScript
function countValidSelections(nums: number[]): number {
    let n = nums.length, ans = 0;
    let sum = nums.reduce((a, b) => a + b, 0);
    let left = 0, right = sum;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 0) {
            if (left - right >= 0 && left - right <= 1) {
                ans++;
            }
            if (right - left >= 0 && right - left <= 1) {
                ans++;
            }
        } else {
            left += nums[i];
            right -= nums[i];
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_valid_selections(nums: Vec<i32>) -> i32 {
        let mut ans = 0;
        let sum: i32 = nums.iter().sum();
        let mut left = 0;
        let mut right = sum;
        for &x in &nums {
            if x == 0 {
                if left - right >= 0 && left - right <= 1 { ans += 1; }
                if right - left >= 0 && right - left <= 1 { ans += 1; }
            } else {
                left += x;
                right -= x;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。需要遍历一次数组计算前缀和，然后遍历一次数组计算有效选择方案数量。
- 空间复杂度：$O(1)$。仅使用若干额外变量。
