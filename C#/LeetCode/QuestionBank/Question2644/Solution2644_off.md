### [找出可整除性得分最大的整数](https://leetcode.cn/problems/find-the-maximum-divisibility-score/solutions/2776973/zhao-chu-ke-zheng-chu-xing-de-fen-zui-da-nqc7/)

#### 方法一：两次遍历

##### 思路

对于所有的 $\textit{divisor}$，遍历 $\textit{nums}$ 计算有多少数可以被其整除，然后更新答案。注意当可被整除的数相等时，选择更小的 $\textit{divisor}$。

代码

```c++
class Solution {
public:
    int maxDivScore(vector<int>& nums, vector<int>& divisors) {
        int cnt = -1, ans = 0;

        for (int i = 0; i < divisors.size(); i++) {
            int tmp = 0;
            for (int j = 0; j < nums.size(); j++) {
                if (nums[j] % divisors[i] == 0) {
                    tmp++;
                }
            }

            if (tmp > cnt || (tmp == cnt && divisors[i] < ans)) {
                ans = divisors[i];
                cnt = tmp;
            } 
        }
        return ans;
    }
};
```

```java
class Solution {
    public int maxDivScore(int[] nums, int[] divisors) {
        int cnt = -1, ans = 0;

        for (int i = 0; i < divisors.length; i++) {
            int tmp = 0;
            for(int j = 0; j < nums.length; j++) {
                if (nums[j] % divisors[i] == 0) {
                    tmp++;
                }
            }

            if (tmp > cnt || (tmp == cnt && divisors[i] < ans)) {
                cnt = tmp;
                ans = divisors[i];
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MaxDivScore(int[] nums, int[] divisors) {
        int cnt = -1, ans = 0;

        for (int i = 0; i < divisors.Length; i++) {
            int tmp = 0;
            for (int j = 0; j < nums.Length; j++) {
                if (nums[j] % divisors[i] == 0) {
                    tmp++;
                }
            }

            if (tmp > cnt || (tmp == cnt && divisors[i] < ans)) {
                cnt = tmp;
                ans = divisors[i];
            }
        }
        return ans;
    }
}
```

```go
func maxDivScore(nums []int, divisors []int) int {
    cnt := -1
    ans := 0

    for _, divisor := range divisors {
        tmp := 0
        for _, num := range nums {
            if num % divisor == 0 {
                tmp++
            }
        }

        if tmp > cnt || (tmp == cnt && divisor < ans) {
            cnt = tmp
            ans = divisor
        }
    }
    return ans
}
```

```c
int maxDivScore(int* nums, int numsSize, int* divisors, int divisorsSize){
    int cnt = -1, ans = 0;

    for (int i = 0; i < divisorsSize; i++) {
        int tmp = 0;
        for (int j = 0; j < numsSize; j++) {
            if (nums[j] % divisors[i] == 0) {
                tmp++;
            }
        }

        if (tmp > cnt || (tmp == cnt && divisors[i] < ans)) {
            cnt = tmp;
            ans = divisors[i];
        } 
    }
    return ans;
}
```

```python
class Solution(object):
    def maxDivScore(self, nums, divisors):
        cnt, ans = -1, 0

        for i in range (0, len(divisors)):
            tmp = sum(1 for num in nums if num % divisors[i] == 0)
            if tmp > cnt or tmp == cnt and divisors[i] < ans:
                cnt = tmp
                ans = divisors[i]
        return ans;
```

```javascript
var maxDivScore = function(nums, divisors) {
    cnt = -1
    ans = 0

    for (let i = 0; i < divisors.length; i++) {
        tmp = 0
        for (let j = 0; j < nums.length; j++) {
            if (nums[j] % divisors[i] == 0) {
                tmp++
            }
        }

        if (tmp > cnt || (tmp == cnt && divisors[i] < ans)) {
            cnt = tmp
            ans = divisors[i]
        }
    }
    return ans
};
```

```typescript
function maxDivScore(nums: number[], divisors: number[]): number {
    let cnt = -1, ans = 0

    for (let i = 0; i < divisors.length; i++) {
        let tmp = 0
        for (let j = 0; j < nums.length; j++) {
            if (nums[j] % divisors[i] == 0) {
                tmp++
            }
        }

        if (tmp > cnt || (tmp == cnt && divisors[i] < ans)) {
            cnt = tmp
            ans = divisors[i]
        }
    }
    return ans
};
```

```rust
impl Solution {
    pub fn max_div_score(nums: Vec<i32>, divisors: Vec<i32>) -> i32 {
        let mut cnt = -1;
        let mut ans = 0;

        for i in 0..divisors.len() {
            let mut tmp = 0;
            for j in 0..nums.len() {
                if nums[j] % divisors[i] == 0 {
                    tmp += 1;
                }
            }

            if tmp > cnt || tmp == cnt && divisors[i] < ans {
                cnt = tmp;
                ans = divisors[i];
            }
        }
        return ans;
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n \times m)$，其中 $n$ 为 $\textit{divisors}$ 数组的长度，$m$ 为 $\textit{nums}$ 数组的长度。
- 空间复杂度：$O(1)$。
