### [魔术索引](https://leetcode.cn/problems/magic-index-lcci/solutions/354141/mo-zhu-suo-yin-by-leetcode-solution/)

#### 写在前面

这题是《程序员面试金典》里面的一道题。在原书里此题是有两个小问的，它们的描述很相似。本题即为第二个小问的描述，而第一个小问保证了题目给定的数组是「严格单调递增」的，就是不会有重复的数字。

因此第一个小问是经典的二分查找问题，时间复杂度为 $O(\log n)$。而第二个小问相当于是第一个小问的进阶：面试官在看到你解决了问题之后，会问你如果数组中可以出现重复的元素应该怎么做，就变成了本题。

#### 方法一：二分剪枝

##### 思路与算法

此问题如果用暴力的方法来解决，我们只需要对原数组从前往后进行一次遍历，找到第一个可行的位置返回即可，这里不再赘述。而本方法会进行一定程度的剪枝，在一些情况下会达到较优的时间复杂度，在最差情况下仍会退化成线性的时间复杂度，这里我们分两种情况讨论。

第一种情况是**数组中只有一个满足条件的答案**。我们假设这个答案为 $i$，那么意味着 $[0 \ldots i-1]$ 的值均小于自身的下标，$[i+1 \ldots n-1]$ 的值均大于自身的下标。我们将整个数组每个元素减去其自身所在的下标，那么最后的答案即为 $0$ 所在的下标，且在 $0$ 之前的元素均为负数，$0$ 之后的元素均为正数。以 $[-1,0,2,4,5]$ 为例，减去自身下标以后以后得到 $[-1,-1,0,1,1]$，整个数组以 $0$ 为分界点，前半部分均为负数，后半部分均为负数，因此我们可以使用二分查找在 $O(\log n)$ 的时间内找到答案 $0$ 所在的下标，具体做法就是碰到负数舍弃左半边，碰到正数舍弃右半边即可。

第二种情况是**数组中存在多个满足条件的答案**，此时我们发现整个数组不具有任何性质。以 $[0,0,2,2,5]$ 为例，我们仍进行一次将每个元素减去其自身下标的操作，得到 $[0,-1,0,-1,1]$。目标是要找到第一个出现的 $0$，而由于数组中出现 $0$ 的位置不确定，因此无法使用二分查找，但是我们可以依据此来进行一定程度的剪枝，我们剪枝的策略为：

- 每次我们选择数组的中间元素，如果当前中间元素是满足条件的答案，那么这个位置往后的元素我们都不再考虑，只要寻找左半部分是否有满足条件的答案即可。
- 否则我们需要查看左半部分是否有满足条件的答案，如果没有的话我们仍然需要在右半边寻找，使用的策略同上。

我们可以依靠此策略定义一个递归函数：`getAnswer(nums, left, right)` 返回数组 $\textit{nums}$ 的下标范围 $[\textit{left},\textit{right}]$ 中第一个满足条件的答案，如果没有返回 $-1$。每次选择中间的位置 $\textit{mid}$，此时直接先递归调用数组左半部分 `getAnswer(nums, left, mid - 1)` 得到返回值 $\textit{leftAnswer}$，如果存在则直接返回，如果不存在则比较 $\textit{nums}[\textit{mid}]$ 和 $\textit{mid}$ 是否相等，如果相等则返回 $\textit{mid}$，否则需要递归调用 `getAnswer(nums, mid + 1, right)`。

显然，此剪枝策略在 $[-1,0,1,2,4]$ 这种答案为数组的最后一个元素的情况下会退化成线性的时间复杂度，但是在一些情况下会有不错的表现。

##### 代码

```c++
class Solution {
public:
    int getAnswer(vector<int>& nums, int left, int right) {
        if (left > right) {
            return -1;
        }
        int mid = (right - left) / 2 + left;
        int leftAnswer = getAnswer(nums, left, mid - 1);
        if (leftAnswer != -1) {
            return leftAnswer;
        } else if (nums[mid] == mid) {
            return mid;
        }
        return getAnswer(nums, mid + 1, right);
    }

    int findMagicIndex(vector<int>& nums) {
        return getAnswer(nums, 0, (int) nums.size() - 1);
    }
};
```

```java
class Solution {
    public int findMagicIndex(int[] nums) {
        return getAnswer(nums, 0, nums.length - 1);
    }

    public int getAnswer(int[] nums, int left, int right) {
        if (left > right) {
            return -1;
        }
        int mid = (right - left) / 2 + left;
        int leftAnswer = getAnswer(nums, left, mid - 1);
        if (leftAnswer != -1) {
            return leftAnswer;
        } else if (nums[mid] == mid) {
            return mid;
        }
        return getAnswer(nums, mid + 1, right);
    }
}
```

```c
int getAnswer(int* nums, int left, int right) {
    if (left > right) {
        return -1;
    }
    int mid = (right - left) / 2 + left;
    int leftAnswer = getAnswer(nums, left, mid - 1);
    if (leftAnswer != -1) {
        return leftAnswer;
    } else if (nums[mid] == mid) {
        return mid;
    }
    return getAnswer(nums, mid + 1, right);
}

int findMagicIndex(int* nums, int numsSize) {
    return getAnswer(nums, 0, numsSize - 1);
}
```

```go
func findMagicIndex(nums []int) int {
    return getAnswer(nums, 0, len(nums) - 1)
}

func getAnswer(nums []int, left, right int) int {
    if left > right {
        return -1
    }
    mid := (right - left) / 2 + left
    leftAnswer := getAnswer(nums, left, mid - 1)
    if leftAnswer != -1 {
        return leftAnswer
    } else if nums[mid] == mid {
        return mid
    }
    return getAnswer(nums, mid + 1, right)
}
```

##### 复杂度分析

- 时间复杂度：最坏情况下会达到 $O(n)$ 的时间复杂度，其中 $n$ 为数组的长度。具体分析已经在上文中讲述，这里不再赘述。
- 空间复杂度：递归函数的空间取决于调用的栈深度，而最坏情况下我们会递归 $n$ 层，即栈深度为 $O(n)$，因此空间复杂度最坏情况下为 $O(n)$。
