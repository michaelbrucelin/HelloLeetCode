### [购买物品的最大开销](https://leetcode.cn/problems/sort-the-students-by-their-kth-score/solutions/3021455/gou-mai-wu-pin-de-zui-da-kai-xiao-by-lee-0ov5/)

#### 方法一：自定义排序

**思路与算法**

直接按照题目的要求，根据第 $k$ 列降序，实现自定义排序即可。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> sortTheStudents(vector<vector<int>>& score, int k) {
        sort(score.begin(), score.end(), [&](const vector<int>& u, const vector<int>& v) {
            return u[k] > v[k];
        });
        return score;
    }
};
```

```Python
class Solution:
    def sortTheStudents(self, score: List[List[int]], k: int) -> List[List[int]]:
        # 也可以写成 score.sort(key=lambda row: -row[k])
        score.sort(key=lambda row: row[k], reverse=True)
        return score
```

```Java
class Solution {
    public int[][] sortTheStudents(int[][] score, int k) {
        Arrays.sort(score, (u, v) -> v[k] - u[k]);
        return score;
    }
}
```

```CSharp
public class Solution {
    public int[][] SortTheStudents(int[][] score, int k) {
        Array.Sort(score, (u, v) => v[k] - u[k]);
        return score;
    }
}
```

```Go
func sortTheStudents(score [][]int, k int) [][]int {
    sort.Slice(score, func(i, j int) bool {
        return score[i][k] > score[j][k]
    })
    return score
}
```

```C
int gk = 0;

int compare(const void* a, const void* b) {
    int* ua = *(int**)a;
    int* ub = *(int**)b;
    return ub[gk] - ua[gk];
}

int** sortTheStudents(int** score, int scoreSize, int* scoreColSize, int k, int* returnSize, int** returnColumnSizes) {
    gk = k;
    qsort(score, scoreSize, sizeof(int*), compare);
    *returnSize = scoreSize;
    *returnColumnSizes = scoreColSize;
    return score;
}
```

```JavaScript
var sortTheStudents = function(score, k) {
    score.sort((u, v) => v[k] - u[k]);
    return score;
};
```

```TypeScript
function sortTheStudents(score: number[][], k: number): number[][] {
    score.sort((u, v) => v[k] - u[k]);
    return score;
};
```

```Rust
impl Solution {
    pub fn sort_the_students(score: Vec<Vec<i32>>, k: i32) -> Vec<Vec<i32>> {
        let mut score = score.clone();
        score.sort_by(|u, v| v[k as usize].cmp(&u[k as usize]));
        score
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mlogm)$。排序需要的比较次数和行数有关，即 $O(mlogm)$，每一次比较仅比较第 $k$ 列，时间为 $O(1)$。如果需要交换比较的两个行，在大部分现代语言中，都可以支持两个行进行无拷贝的交换（即在底层直接更换引用或指针），时间也为 $O(1)$。
- 空间复杂度：$O(logm)$，即为排序需要使用的栈空间。
