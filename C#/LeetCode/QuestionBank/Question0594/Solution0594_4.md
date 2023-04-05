#### [����������ϣ��](https://leetcode.cn/problems/longest-harmonious-subsequence/solutions/1110137/zui-chang-he-xie-zi-xu-lie-by-leetcode-s-8cyr/)

**˼·���㷨**

�ڷ���һ�У�����ö���� $x$ �󣬱��������ҳ����е� $x$ �� $x + 1$�ĳ��ֵĴ���������Ҳ������һ����ϣӳ�����洢ÿ�������ֵĴ��������������� $O(1)$ ��ʱ���ڵõ� $x$ �� $x + 1$ ���ֵĴ�����

�������ȱ���һ�����飬�õ���ϣӳ�䡣��������ϣӳ�䣬�赱ǰ�������ļ�ֵ��Ϊ $(x, value)$����ô���ǾͲ�ѯ $x + 1$ �ڹ�ϣӳ���ж�Ӧ��ͳ�ƴ������͵õ��� $x$ �� $x + 1$ ���ֵĴ�������г�����еĳ��ȵ��� $x$ �� $x + 1$ ���ֵĴ���֮�͡�

**����**

```java
class Solution {
    public int findLHS(int[] nums) {
        HashMap <Integer, Integer> cnt = new HashMap <>();
        int res = 0;
        for (int num : nums) {
            cnt.put(num, cnt.getOrDefault(num, 0) + 1);
        }
        for (int key : cnt.keySet()) {
            if (cnt.containsKey(key + 1)) {
                res = Math.max(res, cnt.get(key) + cnt.get(key + 1));
            }
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    int findLHS(vector<int>& nums) {
        unordered_map<int, int> cnt;
        int res = 0;
        for (int num : nums) {
            cnt[num]++;
        }
        for (auto [key, val] : cnt) {
            if (cnt.count(key + 1)) {
                res = max(res, val + cnt[key + 1]);
            }
        }
        return res;
    }
};
```

```csharp
public class Solution {
    public int FindLHS(int[] nums) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        int res = 0;
        foreach (int num in nums) {
            if (dictionary.ContainsKey(num)) {
                dictionary[num]++;
            } else {
                dictionary.Add(num, 1);
            }
        }
        foreach (int key in dictionary.Keys) {
            if (dictionary.ContainsKey(key + 1)) {
                res = Math.Max(res, dictionary[key] + dictionary[key + 1]);
            }
        }
        return res;
    }
}
```

```python
class Solution:
    def findLHS(self, nums: List[int]) -> int:
        cnt = Counter(nums)
        return max((val + cnt[key + 1] for key, val in cnt.items() if key + 1 in cnt), default=0)
```

```javascript
var findLHS = function(nums) {
    const cnt = new Map();
    let res = 0;
    for (const num of nums) {
        cnt.set(num, (cnt.get(num) || 0) + 1);
    }
    for (const key of cnt.keys()) {
        if (cnt.has(key + 1)) {
            res = Math.max(res, cnt.get(key) + cnt.get(key + 1));
        }
    }
    return res;
};
```

```go
func findLHS(nums []int) (ans int) {
    cnt := map[int]int{}
    for _, num := range nums {
        cnt[num]++
    }
    for num, c := range cnt {
        if c1 := cnt[num+1]; c1 > 0 && c+c1 > ans {
            ans = c + c1
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N)$������ $N$ Ϊ����ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(N)$������ $N$ Ϊ����ĳ��ȡ������������ $N$ ����ͬԪ�أ���˹�ϣ�����洢 $N$ �����ݡ�
