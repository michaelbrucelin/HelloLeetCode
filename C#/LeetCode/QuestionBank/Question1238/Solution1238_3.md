#### [ǰ��](https://leetcode.cn/problems/circular-permutation-in-binary-representation/solutions/2126240/xun-huan-ma-pai-lie-by-leetcode-solution-6e40/)

����͡�[89\. ���ױ���](https://leetcode.cn/problems/gray-code/)���ǳ����ƣ��������ڡ�[89\. ���ױ���](https://leetcode.cn/problems/gray-code/)��Ҫ���һ�������� $0$��������Ҫ���һ�������� $start$�����ֻ��Ҫ������Ľ����ÿһ��� $start$ ���а�λ������㼴�ɡ�

���������������֮ǰ�����Ķ���[89\. ���ױ���Ĺٷ����](https://leetcode.cn/problems/gray-code/solution/ge-lei-bian-ma-by-leetcode-solution-cqi7/)����

#### [����һ�����ɷ�](https://leetcode.cn/problems/circular-permutation-in-binary-representation/solutions/2126240/xun-huan-ma-pai-lie-by-leetcode-solution-6e40/)

**����**

```cpp
class Solution {
public:
    vector<int> circularPermutation(int n, int start) {
        vector<int> ret;
        ret.reserve(1 << n);
        ret.push_back(start);
        for (int i = 1; i <= n; i++) {
            int m = ret.size();
            for (int j = m - 1; j >= 0; j--) {
                ret.push_back(((ret[j] ^ start) | (1 << (i - 1))) ^ start);
            }
        }
        return ret;
    }
};
```

```java
class Solution {
    public List<Integer> circularPermutation(int n, int start) {
        List<Integer> ret = new ArrayList<Integer>();
        ret.add(start);
        for (int i = 1; i <= n; i++) {
            int m = ret.size();
            for (int j = m - 1; j >= 0; j--) {
                ret.add(((ret.get(j) ^ start) | (1 << (i - 1))) ^ start);
            }
        }
        return ret;
    }
}
```

```csharp
public class Solution {
    public IList<int> CircularPermutation(int n, int start) {
        IList<int> ret = new List<int>();
        ret.Add(start);
        for (int i = 1; i <= n; i++) {
            int m = ret.Count;
            for (int j = m - 1; j >= 0; j--) {
                ret.Add(((ret[j] ^ start) | (1 << (i - 1))) ^ start);
            }
        }
        return ret;
    }
}
```

```c
int* circularPermutation(int n, int start, int* returnSize){
    int *ret = (int *)malloc((1 << n) * sizeof(int));
    ret[0] = start;
    int ret_size = 1;
    for (int i = 1; i <= n; i++) {
        for (int j = ret_size - 1; j >= 0; j--) {
            ret[2 * ret_size - 1 - j] = ((ret[j] ^ start) | (1 << (i - 1))) ^ start;
        }
        ret_size <<= 1;
    }
    *returnSize = ret_size;
    return ret;
}
```

```go
func circularPermutation(n int, start int) []int {
ans := make([]int, 1, 1<<n)
ans[0] = start
for i := 1; i <= n; i++ {
for j := len(ans) - 1; j >= 0; j-- {
ans = append(ans, ((ans[j]^start)|(1<<(i-1)))^start)
}
}
return ans
}
```

```python
class Solution:
    def circularPermutation(self, n: int, start: int) -> List[int]:
        ans = [start]
        for i in range(1, n + 1):
            for j in range(len(ans) - 1, -1, -1):
                ans.append(((ans[j] ^ start) | (1 << (i - 1))) ^ start)
        return ans
```

```javascript
var circularPermutation = function(n, start) {
    const ret = [start];
    for (let i = 1; i <= n; i++) {
        const m = ret.length;
        for (let j = m - 1; j >= 0; j--) {
            ret.push(((ret[j] ^ start) | (1 << (i - 1))) ^ start);
        }
    }
    return ret;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(2^n)$��ÿһ�����������ɵ�ʱ��Ϊ $O(1)$����ʱ��Ϊ $O(2^n)$��
-   �ռ临�Ӷȣ�$O(1)$�����ﷵ��ֵ������ռ临�Ӷȡ�
