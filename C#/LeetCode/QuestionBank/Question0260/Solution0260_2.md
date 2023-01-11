#### [����һ����ϣ��](https://leetcode.cn/problems/single-number-iii/solutions/587516/zhi-chu-xian-yi-ci-de-shu-zi-iii-by-leet-4i8e/)

**˼·���㷨**

���ǿ���ʹ��һ����ϣӳ��ͳ��������ÿһ��Ԫ�س��ֵĴ�����

��ͳ����ɺ����ǶԹ�ϣӳ����б�����������ֻ������һ�ε���������С�

**����**

```cpp
class Solution {
public:
    vector<int> singleNumber(vector<int>& nums) {
        unordered_map<int, int> freq;
        for (int num: nums) {
            ++freq[num];
        }
        vector<int> ans;
        for (const auto& [num, occ]: freq) {
            if (occ == 1) {
                ans.push_back(num);
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int[] singleNumber(int[] nums) {
        Map<Integer, Integer> freq = new HashMap<Integer, Integer>();
        for (int num : nums) {
            freq.put(num, freq.getOrDefault(num, 0) + 1);
        }
        int[] ans = new int[2];
        int index = 0;
        for (Map.Entry<Integer, Integer> entry : freq.entrySet()) {
            if (entry.getValue() == 1) {
                ans[index++] = entry.getKey();
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int[] SingleNumber(int[] nums) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (freq.ContainsKey(num)) {
                ++freq[num];
            } else {
                freq.Add(num, 1);
            }
        }
        int[] ans = new int[2];
        int index = 0;
        foreach (KeyValuePair<int, int> pair in freq) {
            if (pair.Value == 1) {
                ans[index++] = pair.Key;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> List[int]:
        freq = Counter(nums)
        return [num for num, occ in freq.items() if occ == 1]
```

```javascript
var singleNumber = function(nums) {
    const freq = new Map();
    for (const num of nums) {
        freq.set(num, (freq.get(num) || 0) + 1);
    }
    const ans = [];
    for (const [num, occ] of freq.entries()) {
        if (occ === 1) {
            ans.push(num);
        }
    }
    return ans;
};
```

```typescript
function singleNumber(nums: number[]): number[] {
    const freq = new Map();
    for (const num of nums) {
        freq.set(num, (freq.get(num) || 0) + 1);
    }
    const ans: number[] = [];
    for (const [num, occ] of freq.entries()) {
        if (occ === 1) {
            ans.push(num);
        }
    }
    return ans;
};
```

```go
func singleNumber(nums []int) (ans []int) {
    freq := map[int]int{}
    for _, num := range nums {
        freq[num]++
    }
    for num, occ := range freq {
        if occ == 1 {
            ans = append(ans, num)
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ $nums$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n)$����Ϊ��ϣӳ����Ҫʹ�õĿռ䡣
