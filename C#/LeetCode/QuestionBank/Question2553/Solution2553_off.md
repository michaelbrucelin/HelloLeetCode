### [分割数组中数字的数位](https://leetcode.cn/problems/separate-the-digits-in-an-array/solutions/3963822/fen-ge-shu-zu-zhong-shu-zi-de-shu-wei-by-540c/)

#### 方法一：模拟

**思路与算法**

题目要求将数组中的每个数字按数位分割，然后将分割后的数字按顺序重组为新的数组。

对一个数字 $x$ 按数位分割时：

1. 将 $x$ 对 $10$ 取余，可得到个数位上的数字，将其放入临时数组中
2. 将 $x$ 对 $10$ 做除法，可消除个数位上的数字

不断循环以上过程，直到 $x$ 为 $0$，这样一来可以以逆序的方式拿到 $x$ 分割后的数字。由于题目数据中 $x$ 初始时为正整数，因此不需要考虑初始为 $0$ 的情况。

逆序遍历临时数组，将每个数字追加到存储答案的数组，结束后清空临时数组。最终返回存储答案的数组。

**代码**

```C++
class Solution {
public:
    vector<int> separateDigits(vector<int>& nums) {
        vector<int> res;
        for (auto x : nums) {
            vector<int> tmp;
            while (x > 0) {
                tmp.push_back(x % 10);
                x /= 10;
            }
            for (int i = tmp.size() - 1; i >= 0; i--) {
                res.push_back(tmp[i]);
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def separateDigits(self, nums: List[int]) -> List[int]:
        res = []
        for x in nums:
            tmp = []
            while x > 0:
                tmp.append(x % 10)
                x //= 10
            res.extend(tmp[::-1])
        return res
```

```Rust
impl Solution {
    pub fn separate_digits(nums: Vec<i32>) -> Vec<i32> {
        let mut res = Vec::new();
        for mut x in nums {
            let mut tmp = Vec::new();
            while x > 0 {
                tmp.push(x % 10);
                x /= 10;
            }
            for i in (0..tmp.len()).rev() {
                res.push(tmp[i]);
            }
        }
        res
    }
}
```

```Java
class Solution {
    public int[] separateDigits(int[] nums) {
        List<Integer> res = new ArrayList<>();
        for (int x : nums) {
            List<Integer> tmp = new ArrayList<>();
            while (x > 0) {
                tmp.add(x % 10);
                x /= 10;
            }
            for (int i = tmp.size() - 1; i >= 0; i--) {
                res.add(tmp.get(i));
            }
        }
        
        int[] result = new int[res.size()];
        for (int i = 0; i < res.size(); i++) {
            result[i] = res.get(i);
        }
        return result;
    }
}
```

```CSharp
public class Solution {
    public int[] SeparateDigits(int[] nums) {
        List<int> res = new List<int>();
        foreach (int num in nums) {
            int x = num;
            List<int> tmp = new List<int>();
            while (x > 0) {
                tmp.Add(x % 10);
                x /= 10;
            }
            for (int i = tmp.Count - 1; i >= 0; i--) {
                res.Add(tmp[i]);
            }
        }
        return res.ToArray();
    }
}
```

```Go
func separateDigits(nums []int) []int {
    res := []int{}
    for _, num := range nums {
        x := num
        tmp := []int{}
        for x > 0 {
            tmp = append(tmp, x % 10)
            x /= 10
        }
        for i := len(tmp) - 1; i >= 0; i-- {
            res = append(res, tmp[i])
        }
    }
    return res
}
```

```C
int* separateDigits(int* nums, int numsSize, int* returnSize) {
    int totalDigits = 0;
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        if (x == 0) {
            totalDigits++;
        } else {
            while (x > 0) {
                totalDigits++;
                x /= 10;
            }
        }
    }
    
    int* res = (int*)malloc(totalDigits * sizeof(int));
    int index = 0;
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        int* tmp = (int*)malloc(10 * sizeof(int));
        int tmpSize = 0;
        if (x == 0) {
            res[index++] = 0;
            continue;
        }
        while (x > 0) {
            tmp[tmpSize++] = x % 10;
            x /= 10;
        }
        for (int j = tmpSize - 1; j >= 0; j--) {
            res[index++] = tmp[j];
        }
        free(tmp);
    }
    
    *returnSize = totalDigits;
    return res;
}
```

```JavaScript
var separateDigits = function(nums) {
    const res = [];
    for (let num of nums) {
        let x = num;
        const tmp = [];
        while (x > 0) {
            tmp.push(x % 10);
            x = Math.floor(x / 10);
        }
        for (let i = tmp.length - 1; i >= 0; i--) {
            res.push(tmp[i]);
        }
    }
    return res;
};
```

```TypeScript
function separateDigits(nums: number[]): number[] {
    const res: number[] = [];
    for (const num of nums) {
        let x = num;
        const tmp: number[] = [];
        while (x > 0) {
            tmp.push(x % 10);
            x = Math.floor(x / 10);
        }
        for (let i = tmp.length - 1; i >= 0; i--) {
            res.push(tmp[i]);
        }
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n\log M)$，其中 $n$ 是 $nums$ 的长度，$M$ 是 $nums$ 中的最大值。
- 空间复杂度：$O(\log M)$。返回值不计入空间复杂度。

#### 方法二：倒序遍历

**思路与算法**

在方法一中，我们需要一个临时数组来存储分割后的数字，然后再将其逆序追加到答案数组中。我们也可以直接倒序遍历 $nums$ 中的每个数字 $x$，将 $x$ 切割后直接追加到答案数组中（不需要临时数组暂存），最后将答案数组逆序即可得到最终答案。

**代码**

```C++
class Solution {
public:
    vector<int> separateDigits(vector<int>& nums) {
        vector<int> res;
        for (int i = nums.size() - 1; i >= 0; i--) {
            int x = nums[i];
            while (x > 0) {
                res.push_back(x % 10);
                x /= 10;
            }
        }
        reverse(res.begin(), res.end());
        return res;
    }
};
```

```Python
class Solution:
    def separateDigits(self, nums: List[int]) -> List[int]:
        res = []
        for i in range(len(nums) - 1, -1, -1):
            x = nums[i]
            while x > 0:
                res.append(x % 10)
                x //= 10
        res.reverse()
        return res
```

```Rust
impl Solution {
    pub fn separate_digits(nums: Vec<i32>) -> Vec<i32> {
        let mut res = Vec::new();
        for i in (0..nums.len()).rev() {
            let mut x = nums[i];
            while x > 0 {
                res.push(x % 10);
                x /= 10;
            }
        }
        res.reverse();
        res
    }
}
```

```Java
class Solution {
    public int[] separateDigits(int[] nums) {
        List<Integer> res = new ArrayList<>();
        for (int i = nums.length - 1; i >= 0; i--) {
            int x = nums[i];
            while (x > 0) {
                res.add(x % 10);
                x /= 10;
            }
        }

        Collections.reverse(res);
        int[] result = new int[res.size()];
        for (int i = 0; i < res.size(); i++) {
            result[i] = res.get(i);
        }
        return result;
    }
}
```

```CSharp
class Solution {
    public int[] SeparateDigits(int[] nums) {
        List<int> res = new List<int>();
        for (int i = nums.Length - 1; i >= 0; i--) {
            int x = nums[i];
            while (x > 0) {
                res.Add(x % 10);
                x /= 10;
            }
        }
        res.Reverse();
        return res.ToArray();
    }
}
```

```Go
func separateDigits(nums []int) []int {
    res := []int{}
    for i := len(nums) - 1; i >= 0; i-- {
        x := nums[i]
        for x > 0 {
            res = append(res, x % 10)
            x /= 10
        }
    }
    
    for i, j := 0, len(res) - 1; i < j; i, j = i + 1, j - 1 {
        res[i], res[j] = res[j], res[i]
    }
    
    return res
}
```

```C
int* separateDigits(int* nums, int numsSize, int* returnSize) {
    int totalDigits = 0;
    for (int i = numsSize - 1; i >= 0; i--) {
        int x = nums[i];
        while (x > 0) {
            totalDigits++;
            x /= 10;
        }
    }
    
    int* temp = (int*)malloc(totalDigits * sizeof(int));
    int index = 0;
    for (int i = numsSize - 1; i >= 0; i--) {
        int x = nums[i];
        while (x > 0) {
            temp[index++] = x % 10;
            x /= 10;
        }
    }
    
    int* res = (int*)malloc(totalDigits * sizeof(int));
    for (int i = 0; i < totalDigits; i++) {
        res[i] = temp[totalDigits - 1 - i];
    }
    
    free(temp);
    *returnSize = totalDigits;
    return res;
}
```

```JavaScript
var separateDigits = function(nums) {
    const res = [];
    for (let i = nums.length - 1; i >= 0; i--) {
        let x = nums[i];
        while (x > 0) {
            res.push(x % 10);
            x = Math.floor(x / 10);
        }
    }
    res.reverse();
    return res;
};
```

```TypeScript
function separateDigits(nums: number[]): number[] {
    const res: number[] = [];
    for (let i = nums.length - 1; i >= 0; i--) {
        let x = nums[i];
        while (x > 0) {
            res.push(x % 10);
            x = Math.floor(x / 10);
        }
    }
    res.reverse();
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n\log M)$，其中 $n$ 是 $nums$ 的长度，$M$ 是 $nums$ 中的最大值。
- 空间复杂度：$O(1)$。
