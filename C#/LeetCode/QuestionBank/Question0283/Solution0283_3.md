#### [动画演示 283.移动零](https://leetcode.cn/problems/move-zeroes/solutions/90229/dong-hua-yan-shi-283yi-dong-ling-by-wang_ni_ma/)

#### 两次遍历

我们创建两个指针`i`和`j`，第一次遍历的时候指针`j`用来记录当前有多少`非0`元素。即遍历的时候每遇到一个`非0`元素就将其往数组左边挪，第一次遍历完后，`j`指针的下标就指向了最后一个`非0`元素下标。
第二次遍历的时候，起始位置就从`j`开始到结束，将剩下的这段区域内的元素全部置为`0`。
动画演示：
![](./assets/img/Solution0283_3_01.gif)
时间复杂度: O(n)
空间复杂度: O(1)
代码实现:

```java
class Solution {
    public void moveZeroes(int[] nums) {
        if(nums==null) {
            return;
        }
        //第一次遍历的时候，j指针记录非0的个数，只要是非0的统统都赋给nums[j]
        int j = 0;
        for(int i=0;i<nums.length;++i) {
            if(nums[i]!=0) {
                nums[j++] = nums[i];
            }
        }
        //非0元素统计完了，剩下的都是0了
        //所以第二次遍历把末尾的元素都赋为0即可
        for(int i=j;i<nums.length;++i) {
            nums[i] = 0;
        }
    }
}
```

```python
class Solution(object):
    def moveZeroes(self, nums):
    """
    :type nums: List[int]
    :rtype: None Do not return anything, modify nums in-place instead.
    """
    if not nums:
        return 0
    # 第一次遍历的时候，j指针记录非0的个数，只要是非0的统统都赋给nums[j]
    j = 0
    for i in xrange(len(nums)):
        if nums[i]:
            nums[j] = nums[i]
            j += 1
    # 非0元素统计完了，剩下的都是0了
    # 所以第二次遍历把末尾的元素都赋为0即可
    for i in xrange(j,len(nums)):
        nums[i] = 0
```

#### 一次遍历

这里参考了快速排序的思想，快速排序首先要确定一个待分割的元素做中间点`x`，然后把所有小于等于`x`的元素放到x的左边，大于x的元素放到其右边。
这里我们可以用`0`当做这个中间点，把不等于0(注意题目没说不能有负数)的放到中间点的左边，等于0的放到其右边。 这的中间点就是`0`本身，所以实现起来比快速排序简单很多，我们使用两个指针`i`和`j`，只要`nums[i]!=0`，我们就交换`nums[i]`和`nums[j]`
请对照动态图来理解：
![](./assets/img/Solution0283_3_02.gif)
时间复杂度: O(n)
空间复杂度: O(1)
代码实现:

```java
class Solution {
    public void moveZeroes(int[] nums) {
        if(nums==null) {
            return;
        }
        //两个指针i和j
        int j = 0;
        for(int i=0;i<nums.length;i++) {
            //当前元素!=0，就把其交换到左边，等于0的交换到右边
            if(nums[i]!=0) {
                int tmp = nums[i];
                nums[i] = nums[j];
                nums[j++] = tmp;
            }
        }
    }
}
```

```python
class Solution(object):
    def moveZeroes(self, nums):
    """
    :type nums: List[int]
    :rtype: None Do not return anything, modify nums in-place instead.
    """
    if not nums:
        return 0
    # 两个指针i和j
    j = 0
    for i in xrange(len(nums)):
        # 当前元素!=0，就把其交换到左边，等于0的交换到右边
        if nums[i]:
            nums[j],nums[i] = nums[i],nums[j]
            j += 1
```

(全文完)
