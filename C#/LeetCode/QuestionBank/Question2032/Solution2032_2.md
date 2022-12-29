#### [����һ����ϣ��](https://leetcode.cn/problems/two-out-of-three/solutions/2034884/zhi-shao-zai-liang-ge-shu-zu-zhong-chu-x-5131/)

**˼·���㷨**

��Ŀ���������������� $nums_1$��$nums_2$ �� $nums_3$������������Ҫ��һ��**Ԫ�ظ�����ͬ**�����飬���е�Ԫ��Ϊ���������� $nums_1$��$nums_2$ �� $nums_3$ ������������ֵ�ȫ��Ԫ�ء�

���ǿ����á���ϣ����ʵ�֡�������ֻ���������飬��������һ���������������������λ�����ĳһ�������ļ��������У�$1$ ��ʾ�����ڶ�Ӧ�������еģ���֮ $0$ ��ʾ���ڡ��������ֻ��Ҫ�ж�ÿһ������Ӧ�ı�������ж�����λ�����Ƿ���� $1$ ���ɡ�

**����**

```python
class Solution:
    def twoOutOfThree(self, nums1: List[int], nums2: List[int], nums3: List[int]) -> List[int]:
        mask = defaultdict(int)
        for i, nums in enumerate((nums1, nums2, nums3)):
            for x in nums:
                mask[x] |= 1 << i
        return [x for x, m in mask.items() if m & (m - 1)]
```

```cpp
class Solution {
public:
    vector<int> twoOutOfThree(vector<int>& nums1, vector<int>& nums2, vector<int>& nums3) {
        unordered_map<int, int> mp;
        for (auto& i : nums1) {
            mp[i] = 1;
        }
        for (auto& i : nums2) {
            mp[i] |= 2;
        }
        for (auto& i : nums3) {
            mp[i] |= 4;
        }
        vector<int> res;
        for (auto& [k, v] : mp) {
            if (v & (v - 1)) {
                res.push_back(k);
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public List<Integer> twoOutOfThree(int[] nums1, int[] nums2, int[] nums3) {
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        for (int i : nums1) {
            map.put(i, 1);
        }
        for (int i : nums2) {
            map.put(i, map.getOrDefault(i, 0) | 2);
        }
        for (int i : nums3) {
            map.put(i, map.getOrDefault(i, 0) | 4);
        }
        List<Integer> res = new ArrayList<Integer>();
        for (Map.Entry<Integer, Integer> entry : map.entrySet()) {
            int k = entry.getKey(), v = entry.getValue();
            if ((v & (v - 1)) != 0) {
                res.add(k);
            }
        }
        return res;
    }
}
```

```c#
public class Solution {
    public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3) {
        IDictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (int i in nums1) {
            dictionary.TryAdd(i, 1);
        }
        foreach (int i in nums2) {
            dictionary.TryAdd(i, 0);
            dictionary[i] |= 2;
        }
        foreach (int i in nums3) {
            dictionary.TryAdd(i, 0);
            dictionary[i] |= 4;
        }
        IList<int> res = new List<int>();
        foreach (KeyValuePair<int, int> pair in dictionary) {
            int k = pair.Key, v = pair.Value;
            if ((v & (v - 1)) != 0) {
                res.Add(k);
            }
        }
        return res;
    }
}
```

```c
#define MAX_NUM 100

int* twoOutOfThree(int* nums1, int nums1Size, int* nums2, int nums2Size, int* nums3, int nums3Size, int* returnSize) {
    int mp[MAX_NUM + 1];
    memset(mp, 0, sizeof(mp));
    for (int i = 0; i < nums1Size; i++) {
        mp[nums1[i]] = 1;
    }
    for (int i = 0; i < nums2Size; i++) {
        mp[nums2[i]] |= 2;
    }
    for (int i = 0; i < nums3Size; i++) {
        mp[nums3[i]] |= 4;
    }
    int *res = (int *)malloc(sizeof(int) * MAX_NUM);
    int pos = 0;
    for (int i = 1; i <= MAX_NUM; i++) {
        if (mp[i] & (mp[i] - 1)) {
            res[pos++] = i;
        }
    }
    *returnSize = pos;
    return res;
}
```

```javascript
var twoOutOfThree = function(nums1, nums2, nums3) {
    const map = new Map();
    for (const i of nums1) {
        map.set(i, 1);
    }
    for (const i of nums2) {
        map.set(i, (map.get(i) || 0) | 2);
    }
    for (const i of nums3) {
        map.set(i, (map.get(i) || 0) | 4);
    }
    const res = [];
    for (const [k, v] of map.entries()) {
        if ((v & (v - 1)) !== 0) {
            res.push(k);
        }
    }
    return res;
};
```

```go
func twoOutOfThree(nums1, nums2, nums3 []int) (ans []int) {
    mask := map[int]int{}
    for i, nums := range [][]int{nums1, nums2, nums3} {
        for _, x := range nums {
            mask[x] |= 1 << i
        }
    }
    for x, m := range mask {
        if m&(m-1) > 0 {
            ans = append(ans, x)
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n_1 + n_2 + n_3)$������ $n_1$��$n_2$��$n_3$ �ֱ�Ϊ���� $nums_1$��$nums_2$��$nums_3$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n_1 + n_2 + n_3)$������ $n_1$��$n_2$��$n_3$ �ֱ�Ϊ���� $nums_1$��$nums_2$��$nums_3$ �ĳ��ȣ���ҪΪ��ϣ��Ŀռ俪����
