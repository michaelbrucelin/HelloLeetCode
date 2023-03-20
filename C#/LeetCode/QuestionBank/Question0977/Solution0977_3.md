#### [��������˫ָ��](https://leetcode.cn/problems/squares-of-a-sorted-array/solutions/447736/you-xu-shu-zu-de-ping-fang-by-leetcode-solution/)

**˼·���㷨**

����һû�����á����� $nums$ �Ѿ������������������������Ȼ��������� $nums$ �е����������ǷǸ�������ô��ÿ����ƽ����������Ȼ��������������� $nums$ �е����������Ǹ�������ô��ÿ����ƽ��������ᱣ�ֽ���

����һ������������ܹ��ҵ����� $nums$ �и�����Ǹ����ķֽ��ߣ���ô�Ϳ��������ơ��鲢���򡹵ķ����ˡ�����أ������� $neg$ Ϊ���� $nums$ �и�����Ǹ����ķֽ��ߣ�Ҳ����˵��$nums[0]$ �� $nums[neg]$ ��Ϊ�������� $nums[neg+1]$ �� $nums[n-1]$ ��Ϊ�Ǹ����������ǽ����� $nums$ �е���ƽ������ô $nums[0]$ �� $nums[neg]$ �����ݼ���$nums[neg+1]$ �� $nums[n-1]$ ����������

�������ǵõ��������Ѿ�����������飬��˾Ϳ���ʹ�ù鲢�ķ������������ˡ�����أ�ʹ������ָ��ֱ�ָ��λ�� $neg$ �� $neg+1$��ÿ�αȽ�����ָ���Ӧ������ѡ���С���Ǹ�����𰸲��ƶ�ָ�롣��ĳһָ�������߽�ʱ������һָ�뻹δ�������������η���𰸡�

**����**

```cpp
class Solution {
public:
    vector<int> sortedSquares(vector<int>& nums) {
        int n = nums.size();
        int negative = -1;
        for (int i = 0; i < n; ++i) {
            if (nums[i] < 0) {
                negative = i;
            } else {
                break;
            }
        }

        vector<int> ans;
        int i = negative, j = negative + 1;
        while (i >= 0 || j < n) {
            if (i < 0) {
                ans.push_back(nums[j] * nums[j]);
                ++j;
            }
            else if (j == n) {
                ans.push_back(nums[i] * nums[i]);
                --i;
            }
            else if (nums[i] * nums[i] < nums[j] * nums[j]) {
                ans.push_back(nums[i] * nums[i]);
                --i;
            }
            else {
                ans.push_back(nums[j] * nums[j]);
                ++j;
            }
        }

        return ans;
    }
};
```

```java
class Solution {
    public int[] sortedSquares(int[] nums) {
        int n = nums.length;
        int negative = -1;
        for (int i = 0; i < n; ++i) {
            if (nums[i] < 0) {
                negative = i;
            } else {
                break;
            }
        }

        int[] ans = new int[n];
        int index = 0, i = negative, j = negative + 1;
        while (i >= 0 || j < n) {
            if (i < 0) {
                ans[index] = nums[j] * nums[j];
                ++j;
            } else if (j == n) {
                ans[index] = nums[i] * nums[i];
                --i;
            } else if (nums[i] * nums[i] < nums[j] * nums[j]) {
                ans[index] = nums[i] * nums[i];
                --i;
            } else {
                ans[index] = nums[j] * nums[j];
                ++j;
            }
            ++index;
        }

        return ans;
    }
}
```

```python
class Solution:
    def sortedSquares(self, nums: List[int]) -> List[int]:
        n = len(nums)
        negative = -1
        for i, num in enumerate(nums):
            if num < 0:
                negative = i
            else:
                break

        ans = list()
        i, j = negative, negative + 1
        while i >= 0 or j < n:
            if i < 0:
                ans.append(nums[j] * nums[j])
                j += 1
            elif j == n:
                ans.append(nums[i] * nums[i])
                i -= 1
            elif nums[i] * nums[i] < nums[j] * nums[j]:
                ans.append(nums[i] * nums[i])
                i -= 1
            else:
                ans.append(nums[j] * nums[j])
                j += 1

        return ans
```

```go
func sortedSquares(nums []int) []int {
    n := len(nums)
    lastNegIndex := -1
    for i := 0; i < n && nums[i] < 0; i++ {
        lastNegIndex = i
    }

    ans := make([]int, 0, n)
    for i, j := lastNegIndex, lastNegIndex+1; i >= 0 || j < n; {
        if i < 0 {
            ans = append(ans, nums[j]*nums[j])
            j++
        } else if j == n {
            ans = append(ans, nums[i]*nums[i])
            i--
        } else if nums[i]*nums[i] < nums[j]*nums[j] {
            ans = append(ans, nums[i]*nums[i])
            i--
        } else {
            ans = append(ans, nums[j]*nums[j])
            j++
        }
    }

    return ans
}
```

```c
int* sortedSquares(int* nums, int numsSize, int* returnSize) {
    int negative = -1;
    for (int i = 0; i < numsSize; ++i) {
        if (nums[i] < 0) {
            negative = i;
        } else {
            break;
        }
    }

    int* ans = malloc(sizeof(int) * numsSize);
    *returnSize = 0;
    int i = negative, j = negative + 1;
    while (i >= 0 || j < numsSize) {
        if (i < 0) {
            ans[(*returnSize)++] = nums[j] * nums[j];
            ++j;
        } else if (j == numsSize) {
            ans[(*returnSize)++] = nums[i] * nums[i];
            --i;
        } else if (nums[i] * nums[i] < nums[j] * nums[j]) {
            ans[(*returnSize)++] = nums[i] * nums[i];
            --i;
        } else {
            ans[(*returnSize)++] = nums[j] * nums[j];
            ++j;
        }
    }

    return ans;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ $nums$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(1)$�����˴洢�𰸵��������⣬����ֻ��Ҫά�������ռ䡣
