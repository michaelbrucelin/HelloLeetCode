### [替换数组中的非互质数](https://leetcode.cn/problems/replace-non-coprime-numbers-in-array/solutions/1328577/ti-huan-shu-zu-zhong-de-fei-hu-zhi-shu-b-mnml/)

#### 方法一：栈

**思路与算法**

由于题目不加证明地给出了「任意顺序替换相邻的非互质数都可以得到相同的结果」，因此我们可以从前往后进行替换。

我们可以使用一个栈来进行替换操作。具体地，我们对数组 $nums$ 进行一次遍历。当遍历到 $nums[i]$ 时。在其被放入栈顶前，我们重复进行替换操作，直到 $nums[i]$ 和栈顶的元素互质，或者栈为空为止。此时，我们再将替换完成的 $nums[i]$ 放入栈顶。

最终栈底到栈顶的元素序列即为答案。

**代码**

```C++
class Solution {
public:
    vector<int> replaceNonCoprimes(vector<int>& nums) {
        vector<int> ans;
        for (int num: nums) {
            while (!ans.empty()) {
                int g = gcd(ans.back(), num);
                if (g > 1) {
                    num = ans.back() / g * num;
                    ans.pop_back();
                }
                else {
                    break;
                }
            }
            ans.push_back(num);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def replaceNonCoprimes(self, nums: List[int]) -> List[int]:
        ans = list()
        for num in nums:
            while ans:
                g = math.gcd(ans[-1], num)
                if g > 1:
                    num = ans[-1] // g * num
                    ans.pop()
                else:
                    break
            ans.append(num)
        
        return ans
```

```Java
class Solution {
    public List<Integer> replaceNonCoprimes(int[] nums) {
        List<Integer> ans = new ArrayList<>();
        for (int num : nums) {
            while (!ans.isEmpty()) {
                int last = ans.get(ans.size() - 1);
                int g = gcd(last, num);
                if (g > 1) {
                    num = last / g * num;
                    ans.remove(ans.size() - 1);
                } else {
                    break;
                }
            }
            ans.add(num);
        }
        return ans;
    }

    private int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }
}
```

```CSharp
public class Solution {
    public IList<int> ReplaceNonCoprimes(int[] nums) {
        List<int> ans = new List<int>();
        for(int i = 0; i < nums.Length; i++) {
            int num = nums[i];
            while (ans.Count > 0) {
                int last = ans[ans.Count - 1];
                int g = GCD(last, num);
                if (g > 1) {
                    num = last / g * num;
                    ans.RemoveAt(ans.Count - 1);
                } else {
                    break;
                }
            }
            ans.Add(num);
        }
        return ans;
    }

    private int GCD(int a, int b) {
        return b == 0 ? a : GCD(b, a % b);
    }
}
```

```Go
func replaceNonCoprimes(nums []int) []int {
    ans := []int{}
    for _, num := range nums {
        for len(ans) > 0 {
            last := ans[len(ans) - 1]
            g := gcd(last, num)
            if g > 1 {
                num = last / g * num
                ans = ans[:len(ans) - 1]
            } else {
                break
            }
        }
        ans = append(ans, num)
    }
    return ans
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a % b
    }
    return a
}
```

```C
int gcd(int a, int b) {
    return b == 0 ? a : gcd(b, a % b);
}

int* replaceNonCoprimes(int* nums, int numsSize, int* returnSize) {
    int* ans = (int*)malloc(numsSize * sizeof(int));
    int pos = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        while (pos > 0) {
            int last = ans[pos - 1];
            int g = gcd(last, num);
            if (g > 1) {
                num = last / g * num;
                pos--;
            } else {
                break;
            }
        }
        ans[pos++] = num;
    }
    *returnSize = pos;
    return ans;
}
```

```JavaScript
var replaceNonCoprimes = function(nums) {
    const ans = [];
    for (let num of nums) {
        while (ans.length > 0) {
            const last = ans[ans.length - 1];
            const g = gcd(last, num);
            if (g > 1) {
                num = Math.floor(last / g) * num;
                ans.pop();
            } else {
                break;
            }
        }
        ans.push(num);
    }
    return ans;
};

const gcd = (a, b) => {
    return b === 0 ? a : gcd(b, a % b);
}
```

```TypeScript
function replaceNonCoprimes(nums: number[]): number[] {
    const ans: number[] = [];
    for (let num of nums) {
        while (ans.length > 0) {
            const last = ans[ans.length - 1];
            const g = gcd(last, num);
            if (g > 1) {
                num = Math.floor(last / g) * num;
                ans.pop();
            } else {
                break;
            }
        }
        ans.push(num);
    }
    return ans;
};

function gcd(a: number, b: number): number {
    return b === 0 ? a : gcd(b, a % b);
}
```

```Rust
impl Solution {
    pub fn replace_non_coprimes(nums: Vec<i32>) -> Vec<i32> {
        let mut ans = Vec::new();
        for mut num in nums {
            while let Some(&last) = ans.last() {
                let g = Self::gcd(last, num);
                if g > 1 {
                    num = last / g * num;
                    ans.pop();
                } else {
                    break;
                }
            }
            ans.push(num);
        }
        ans
    }

    fn gcd(a: i32, b: i32) -> i32 {
        if b == 0 { a } else { Self::gcd(b, a % b) }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log C)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 中的数据范围，$O(logC)$ 即为单次计算最大公约数需要的时间。
- 空间复杂度：$O(1)$。这里不计入返回值需要使用的空间。
