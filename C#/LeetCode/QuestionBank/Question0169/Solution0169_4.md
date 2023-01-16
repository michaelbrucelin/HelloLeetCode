#### [方法三：随机化](https://leetcode.cn/problems/majority-element/solution/duo-shu-yuan-su-by-leetcode-solution//#方法三：随机化)

**思路**

因为超过 $\lfloor \dfrac{n}{2} \rfloor$ 的数组下标被众数占据了，这样我们随机挑选一个下标对应的元素并验证，有很大的概率能找到众数。

**算法**

由于一个给定的下标对应的数字很有可能是众数，我们随机挑选一个下标，检查它是否是众数，如果是就返回，否则继续随机挑选。

```java
class Solution {
    private int randRange(Random rand, int min, int max) {
        return rand.nextInt(max - min) + min;
    }

    private int countOccurences(int[] nums, int num) {
        int count = 0;
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] == num) {
                count++;
            }
        }
        return count;
    }

    public int majorityElement(int[] nums) {
        Random rand = new Random();

        int majorityCount = nums.length / 2;

        while (true) {
            int candidate = nums[randRange(rand, 0, nums.length)];
            if (countOccurences(nums, candidate) > majorityCount) {
                return candidate;
            }
        }
    }
}
```

```python
class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        majority_count = len(nums) // 2
        while True:
            candidate = random.choice(nums)
            if sum(1 for elem in nums if elem == candidate) > majority_count:
                return candidate
```

```cpp
class Solution {
public:
    int majorityElement(vector<int>& nums) {
        while (true) {
            int candidate = nums[rand() % nums.size()];
            int count = 0;
            for (int num : nums)
                if (num == candidate)
                    ++count;
            if (count > nums.size() / 2)
                return candidate;
        }
        return -1;
    }
};
```

**复杂度分析**

-   时间复杂度：理论上最坏情况下的时间复杂度为 $O(\infty)$，因为如果我们的运气很差，这个算法会一直找不到众数，随机挑选无穷多次，所以最坏时间复杂度是没有上限的。然而，运行的期望时间是线性的。为了更简单地分析，先说服你自己：由于众数占据 **超过** 数组一半的位置，期望的随机次数会小于众数占据数组恰好一半的情况。因此，我们可以计算随机的期望次数（下标为 `prob` 为原问题，`mod` 为众数恰好占据数组一半数目的问题）：
    $\begin{aligned} E(iters_{prob}) & \leq E(iters_{mod}) \\ &= \lim_{n \to \infty} \sum_{i=1}^{n} i \cdot \frac{1}{2^i} \\ &= 2 \end{aligned}$
    计算方法为：当众数恰好占据数组的一半时，第一次随机我们有 $\frac{1}{2}$ 的概率找到众数，如果没有找到，则第二次随机时，包含上一次我们有 $\frac{1}{4}$ 的概率找到众数，以此类推。因此期望的次数为 $i \times \frac{1}{2^i}$ 的和，可以计算出这个和为 $2$，说明期望的随机次数是常数。每一次随机后，我们需要 $O(n)$ 的时间判断这个数是否为众数，因此期望的时间复杂度为 $O(n)$。
-   空间复杂度：$O(1)$。随机方法只需要常数级别的额外空间。
