#### [说明](https://leetcode.cn/problems/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-ban-de-shu-zi-lcof/solutions/832356/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-pvh8/)

最简单的暴力方法是，枚举数组中的每个元素，再遍历一遍数组统计其出现次数。该方法的时间复杂度是 $O(n^2)$，会超出时间限制，因此我们需要找出时间复杂度小于 $O(n^2)$ 的优秀做法。

#### [方法一：哈希表](https://leetcode.cn/problems/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-ban-de-shu-zi-lcof/solutions/832356/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-pvh8/)

**思路**

我们知道出现次数最多的元素大于 $\lfloor \dfrac{n}{2} \rfloor$ 次，所以可以用哈希表来快速统计每个元素出现的次数。

**算法**

我们使用哈希映射（HashMap）来存储每个元素以及出现的次数。对于哈希映射中的每个键值对，键表示一个元素，值表示该元素出现的次数。

我们用一个循环遍历数组 `nums` 并将数组中的每个元素加入哈希映射中。在这之后，我们遍历哈希映射中的所有键值对，返回值最大的键。我们同样也可以在遍历数组 `nums` 时候使用打擂台的方法，维护最大的值，这样省去了最后对哈希映射的遍历。

```java
class Solution {
    private Map<Integer, Integer> countNums(int[] nums) {
        Map<Integer, Integer> counts = new HashMap<Integer, Integer>();
        for (int num : nums) {
            if (!counts.containsKey(num)) {
                counts.put(num, 1);
            } else {
                counts.put(num, counts.get(num) + 1);
            }
        }
        return counts;
    }

    public int majorityElement(int[] nums) {
        Map<Integer, Integer> counts = countNums(nums);

        Map.Entry<Integer, Integer> majorityEntry = null;
        for (Map.Entry<Integer, Integer> entry : counts.entrySet()) {
            if (majorityEntry == null || entry.getValue() > majorityEntry.getValue()) {
                majorityEntry = entry;
            }
        }

        return majorityEntry.getKey();
    }
}
```

```python
class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        counts = collections.Counter(nums)
        return max(counts.keys(), key=counts.get)
```

```cpp
class Solution {
public:
    int majorityElement(vector<int>& nums) {
        unordered_map<int, int> counts;
        int majority = 0, cnt = 0;
        for (int num: nums) {
            ++counts[num];
            if (counts[num] > cnt) {
                majority = num;
                cnt = counts[num];
            }
        }
        return majority;
    }
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 `nums` 的长度。我们遍历数组 `nums` 一次，对于 `nums` 中的每一个元素，将其插入哈希表都只需要常数时间。如果在遍历时没有维护最大值，在遍历结束后还需要对哈希表进行遍历，因为哈希表中占用的空间为 $O(n)$（可参考下文的空间复杂度分析），那么遍历的时间不会超过 $O(n)$。因此总时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$。哈希表最多包含 $n - \lfloor \dfrac{n}{2} \rfloor$ 个键值对，所以占用的空间为 $O(n)$。这是因为任意一个长度为 $n$ 的数组最多只能包含 $n$ 个不同的值，但题中保证 `nums` 一定有一个众数，会占用（最少） $\lfloor \dfrac{n}{2} \rfloor + 1$ 个数字。因此最多有 $n - (\lfloor \dfrac{n}{2} \rfloor + 1)$ 个不同的其他数字，所以最多有 $n - \lfloor \dfrac{n}{2} \rfloor$ 个不同的元素。
