### [查询数组中元素出现的位置](https://leetcode.cn/problems/find-occurrences-of-an-element-in-an-array/solutions/3024315/cha-xun-shu-zu-zhong-yuan-su-chu-xian-de-qk6z/)

#### 方法一：统计下标

**思路与算法**

用数组 $indices$ 记录 $nums$ 中所有等于 $x$ 的下标 $i$，此时给定的查询 $queries[i]$，如果 $queries[i]$ 大于 $indices$ 的长度，则查询答案为 $-1$，否则答案为 $indices[queries[i]-1]$，返回查询结果即可。

**代码**

```C++
class Solution {
public:
    vector<int> occurrencesOfElement(vector<int>& nums, vector<int>& queries, int x) {
        vector<int> indices;
        for (int i = 0; i < nums.size(); i++) {
            if (nums[i] == x) {
                indices.emplace_back(i);
            }
        }
        vector<int> res;
        for (int q : queries) {
            if (indices.size() < q) {
                res.emplace_back(-1);
            } else {
                res.emplace_back(indices[q - 1]);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int[] occurrencesOfElement(int[] nums, int[] queries, int x) {
        List<Integer> indices = new ArrayList<>();
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] == x) {
                indices.add(i);
            }
        }
        
        int[] res = new int[queries.length];
        for (int i = 0; i < queries.length; i++) {
            if (indices.size() < queries[i]) {
                res[i] = -1;
            } else {
                res[i] = indices.get(queries[i] - 1);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int[] OccurrencesOfElement(int[] nums, int[] queries, int x) {
        List<int> indices = new List<int>();
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == x) {
                indices.Add(i);
            }
        }

        int[] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            if (indices.Count < queries[i]) {
                res[i] = -1;
            } else {
                res[i] = indices[queries[i] - 1];
            }
        }
        return res;
    }
}
```

```Go
func occurrencesOfElement(nums []int, queries []int, x int) []int {
    indices := []int{}
    for i, num := range nums {
        if num == x {
            indices = append(indices, i)
        }
    }
    res := []int{}
    for _, q := range queries {
        if len(indices) < q {
            res = append(res, -1)
        } else {
            res = append(res, indices[q-1])
        }
    }
    return res
}
```

```Python
class Solution:
    def occurrencesOfElement(self, nums: List[int], queries: List[int], x: int) -> List[int]:
        indices = [i for i, num in enumerate(nums) if num == x]
        return [-1 if len(indices) < q else indices[q - 1] for q in queries]
```

```C
int* occurrencesOfElement(int* nums, int numsSize, int* queries, int queriesSize, int x, int* returnSize) {
    int* indices = (int*)malloc(numsSize * sizeof(int));
    int indicesSize = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] == x) {
            indices[indicesSize++] = i;
        }
    }
    int* res = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;
    for (int i = 0; i < queriesSize; i++) {
        if (indicesSize < queries[i]) {
            res[i] = -1;
        } else {
            res[i] = indices[queries[i] - 1];
        }
    }
    free(indices);
    return res;
}
```

```JavaScript
var occurrencesOfElement = function(nums, queries, x) {
    const indices = [];
        for (let i = 0; i < nums.length; i++) {
            if (nums[i] === x) {
                indices.push(i);
            }
        }
        const res = [];
        for (const q of queries) {
            if (indices.length < q) {
                res.push(-1);
            } else {
                res.push(indices[q - 1]);
            }
        }
        return res;
};
```

```TypeScript
function occurrencesOfElement(nums: number[], queries: number[], x: number): number[] {
    const indices: number[] = [];
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] === x) {
            indices.push(i);
        }
    }
    const res: number[] = [];
    for (const q of queries) {
        if (indices.length < q) {
            res.push(-1);
        } else {
            res.push(indices[q - 1]);
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn occurrences_of_element(nums: Vec<i32>, queries: Vec<i32>, x: i32) -> Vec<i32> {
        let indices: Vec<usize> = nums.iter()
            .enumerate()
            .filter_map(|(i, &num)| if num == x { Some(i) } else { None })
            .collect();
            
        queries
            .iter()
            .map(|&q| {
                if (q as usize) > indices.len() {
                    -1
                } else {
                    indices[(q - 1) as usize] as i32
                }
            })
            .collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+q)$，其中 $n$ 表示给定数组 $nums$ 的长度，$q$ 表示给定的查询数组 $queries$ 的长度。只需遍历数组 $nums$ 与 $queries$ 一次即可。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。记录 $x$ 出现的小标，需要的空间最多为 $O(n)$。
