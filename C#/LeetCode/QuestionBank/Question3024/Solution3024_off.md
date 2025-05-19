### [三角形类型](https://leetcode.cn/problems/type-of-triangle/solutions/3670439/san-jiao-xing-lei-xing-by-leetcode-solut-we7x/)

#### 方法一：数学

首先将 $nums$ 按照从小到大的顺序进行排序，然后依次进行以下判断：

- 如果 $nums[0]+nums[1] \le nums[2]$，那么返回 $"none"$。
- 如果 $nums[0]=nums[2]$，那么返回 $"equilateral"$。
- 如果 $nums[0]=nums[1]$ 或 $nums[1]=nums[2]$，那么返回 $"isosceles"$。
- 以上条件都不满足，返回 $"scalene"$。

```C++
class Solution {
public:
    string triangleType(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        if (nums[0] + nums[1] <= nums[2]) {
            return "none";
        } else if (nums[0] == nums[2]) {
            return "equilateral";
        } else if (nums[0] == nums[1] || nums[1] == nums[2]) {
            return "isosceles";
        } else {
            return "scalene";
        }
    }
};
```

```Go
func triangleType(nums []int) string {
    sort.Ints(nums)
    if nums[0] + nums[1] <= nums[2] {
        return "none"
    } else if nums[0] == nums[2] {
        return "equilateral"
    } else if nums[0] == nums[1] || nums[1] == nums[2] {
        return "isosceles"
    } else {
        return "scalene"
    }
}
```

```Python
class Solution:
    def triangleType(self, nums: List[int]) -> str:
        nums.sort()
        if nums[0] + nums[1] <= nums[2]:
            return "none"
        elif nums[0] == nums[2]:
            return "equilateral"
        elif nums[0] == nums[1] or nums[1] == nums[2]:
            return "isosceles"
        else:
            return "scalene"
```

```Java
class Solution {
    public String triangleType(int[] nums) {
        Arrays.sort(nums);
        if (nums[0] + nums[1] <= nums[2]) {
            return "none";
        } else if (nums[0] == nums[2]) {
            return "equilateral";
        } else if (nums[0] == nums[1] || nums[1] == nums[2]) {
            return "isosceles";
        } else {
            return "scalene";
        }
    }
}
```

```JavaScript
var triangleType = function(nums) {
    nums.sort((a, b) => a - b);
    if (nums[0] + nums[1] <= nums[2]) {
        return "none";
    } else if (nums[0] === nums[2]) {
        return "equilateral";
    } else if (nums[0] === nums[1] || nums[1] === nums[2]) {
        return "isosceles";
    } else {
        return "scalene";
    }
};
```

```TypeScript
function triangleType(nums: number[]): string {
    nums.sort((a, b) => a - b);
    if (nums[0] + nums[1] <= nums[2]) {
        return "none";
    } else if (nums[0] === nums[2]) {
        return "equilateral";
    } else if (nums[0] === nums[1] || nums[1] === nums[2]) {
        return "isosceles";
    } else {
        return "scalene";
    }
}
```

```C
int cmp(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

char* triangleType(int* nums, int numsSize) {
    qsort(nums, numsSize, sizeof(int), cmp);
    if (nums[0] + nums[1] <= nums[2]) {
        return "none";
    } else if (nums[0] == nums[2]) {
        return "equilateral";
    } else if (nums[0] == nums[1] || nums[1] == nums[2]) {
        return "isosceles";
    } else {
        return "scalene";
    }
}
```

```CSharp
public class Solution {
    public string TriangleType(int[] nums) {
        Array.Sort(nums);
        if (nums[0] + nums[1] <= nums[2]) {
            return "none";
        } else if (nums[0] == nums[2]) {
            return "equilateral";
        } else if (nums[0] == nums[1] || nums[1] == nums[2]) {
            return "isosceles";
        } else {
            return "scalene";
        }
    }
}
```

```Rust
impl Solution {
    pub fn triangle_type(mut nums: Vec<i32>) -> String {
        nums.sort();
        if nums[0] + nums[1] <= nums[2] {
            "none".to_string()
        } else if nums[0] == nums[2] {
            "equilateral".to_string()
        } else if nums[0] == nums[1] || nums[1] == nums[2] {
            "isosceles".to_string()
        } else {
            "scalene".to_string()
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
