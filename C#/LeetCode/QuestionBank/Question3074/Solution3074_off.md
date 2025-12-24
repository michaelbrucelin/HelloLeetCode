### [重新分装苹果](https://leetcode.cn/problems/apple-redistribution-into-boxes/solutions/3858074/zhong-xin-fen-zhuang-ping-guo-by-leetcod-lvac/)

#### 方法一：贪心

**思路与算法**

此题的关键在于题目的最后一句话：

> **注意**，同一个包裹中的苹果可以分装到不同的箱子中。

由于这个条件的存在，我们只需要考虑苹果的总数，而无需考虑原先的包裹是怎么分装苹果的。

此时显然可以使用贪心策略：由于题目已经保证 $\sum_{i=0}^{n-1}apple[i]\le \sum_{n=0}^{m-1}capacity[i]$，只需要从大到小依次选择装苹果的箱子，直到所有苹果都被分装完毕。可以证明，如果在某步选择了较小的箱子，总是可以用更大的箱子替换它来得到更优的结果，故该贪心策略成立，此时选择的分装方案就是所用箱子最少的方案。

**代码**

```C++
class Solution {
public:
    int minimumBoxes(vector<int>& apple, vector<int>& capacity) {
        int sum = accumulate(apple.begin(), apple.end(), 0);
        sort(capacity.begin(), capacity.end(), greater<int>());

        int need = 0;
        while (sum > 0) {
            sum -= capacity[need];
            need += 1;
        }

        return need;
    }
};
```

```JavaScript
var minimumBoxes = function (apple, capacity) {
    let sum = apple.reduce((a, b) => a + b, 0);

    capacity.sort((a, b) => b - a);

    let need = 0;
    while (sum > 0) {
        sum -= capacity[need];
        need += 1;
    }

    return need;
};
```

```TypeScript
function minimumBoxes(apple: number[], capacity: number[]): number {
    let sum = apple.reduce((a, b) => a + b, 0);

    capacity.sort((a, b) => b - a);

    let need = 0;
    while (sum > 0) {
        sum -= capacity[need];
        need += 1;
    }

    return need;
};
```

```Java
class Solution {
    public int minimumBoxes(int[] apple, int[] capacity) {
        int sum = 0;
        for (int a : apple) {
            sum += a;
        }
        
        Integer[] capArray = new Integer[capacity.length];
        for (int i = 0; i < capacity.length; i++) {
            capArray[i] = capacity[i];
        }
        
        Arrays.sort(capArray, Collections.reverseOrder());
        
        int need = 0;
        while (sum > 0) {
            sum -= capArray[need];
            need += 1;
        }
        
        return need;
    }
}
```

```CSharp
public class Solution {
    public int MinimumBoxes(int[] apple, int[] capacity) {
        int sum = apple.Sum();
        Array.Sort(capacity);
        Array.Reverse(capacity);
        
        int need = 0;
        while (sum > 0) {
            sum -= capacity[need];
            need += 1;
        }
        
        return need;
    }
}
```

```Go
func minimumBoxes(apple []int, capacity []int) int {
    sum := 0
    for _, a := range apple {
        sum += a
    }
    
    sort.Sort(sort.Reverse(sort.IntSlice(capacity)))
    need := 0
    for sum > 0 {
        sum -= capacity[need]
        need++
    }
    
    return need
}
```

```Python
class Solution:
    def minimumBoxes(self, apple: List[int], capacity: List[int]) -> int:
        total_apples = sum(apple)
        capacity.sort(reverse=True)
        
        need = 0
        while total_apples > 0:
            total_apples -= capacity[need]
            need += 1
            
        return need
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)b - *(int*)a);
}

int minimumBoxes(int* apple, int appleSize, int* capacity, int capacitySize) {
    int sum = 0;
    for (int i = 0; i < appleSize; i++) {
        sum += apple[i];
    }
    
    qsort(capacity, capacitySize, sizeof(int), compare);
    int need = 0;
    while (sum > 0) {
        sum -= capacity[need];
        need += 1;
    }
    
    return need;
}
```

```Rust
impl Solution {
    pub fn minimum_boxes(apple: Vec<i32>, capacity: Vec<i32>) -> i32 {
        let mut sum: i32 = apple.iter().sum();
        let mut sorted_capacity = capacity.clone();
        sorted_capacity.sort_by(|a, b| b.cmp(a));
        
        let mut need = 0;
        while sum > 0 {
            sum -= sorted_capacity[need as usize];
            need += 1;
        }
        
        need
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m\log m)$，其中 $n$ 是 $apple$ 的长度，$m$ 是 $capacity$ 的长度，遍历 $apple$ 需要 $O(n)$，对 $capacity$ 排序需要 $O(m\log m)$，故总计需要 $O(n+m\log m)$。
- 空间复杂度：若排序是就地的为 $O(1)$，若排序需要额外空间则为 $O(m)$。
