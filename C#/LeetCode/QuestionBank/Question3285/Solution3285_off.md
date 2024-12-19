### [找到稳定山的下标](https://leetcode.cn/problems/find-indices-of-stable-mountains/solutions/3014801/zhao-dao-wen-ding-shan-de-xia-biao-by-le-80vj/)

#### 方法一：模拟

**思路**

按照题意，从下标为 $1$ 的元素开始遍历，如果前一个下标的元素严格大于 $threshold$，则将这一个元素的下标加入结果数组中。遍历完成后，返回结果数组。

**代码**

```Python
class Solution:
    def stableMountains(self, height: List[int], threshold: int) -> List[int]:
        return [i for i in range(1, len(height)) if height[i - 1] > threshold]
```

```Java
class Solution {
    public List<Integer> stableMountains(int[] height, int threshold) {
        List<Integer> result = new ArrayList<>();
        for (int i = 1; i < height.length; i++) {
            if (height[i - 1] > threshold) {
                result.add(i);
            }
        }
        return result;
    }
}
```

```CSharp
public class Solution {
    public IList<int> StableMountains(int[] height, int threshold) {
        List<int> result = new List<int>();
        for (int i = 1; i < height.Length; i++) {
            if (height[i - 1] > threshold) {
                result.Add(i);
            }
        }
        return result;
    }
}
```

```C++
class Solution {
public:
    vector<int> stableMountains(vector<int>& height, int threshold) {
        vector<int> result;
        for (int i = 1; i < height.size(); i++) {
            if (height[i - 1] > threshold) {
                result.push_back(i);
            }
        }
        return result;
    }
};
```

```Go
func stableMountains(height []int, threshold int) []int {
    var result []int
    for i := 1; i < len(height); i++ {
        if height[i - 1] > threshold {
            result = append(result, i)
        }
    }
    return result
}
```

```C
int* stableMountains(int* height, int heightSize, int threshold, int* returnSize) {
    int* result = (int*)malloc((heightSize - 1) * sizeof(int));
    *returnSize = 0;
    for (int i = 1; i < heightSize; i++) {
        if (height[i - 1] > threshold) {
            result[*returnSize] = i;
            (*returnSize)++;
        }
    }
    return result;
}
```

```JavaScript
var stableMountains = function(height, threshold) {
    const result = [];
    for (let i = 1; i < height.length; i++) {
        if (height[i - 1] > threshold) {
            result.push(i);
        }
    }
    return result;
};
```

```TypeScript
function stableMountains(height: number[], threshold: number): number[] {
    const result: number[] = [];
    for (let i = 1; i < height.length; i++) {
        if (height[i - 1] > threshold) {
            result.push(i);
        }
    }
    return result;
};
```

```Rust
impl Solution {
    pub fn stable_mountains(height: Vec<i32>, threshold: i32) -> Vec<i32> {
        let mut result = Vec::new();
        for i in 1..height.len() {
            if height[i - 1] > threshold {
                result.push(i as i32);
            }
        }
        result
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$，结果不计入空间复杂度。
