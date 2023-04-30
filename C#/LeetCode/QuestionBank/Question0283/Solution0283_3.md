#### [������ʾ 283.�ƶ���](https://leetcode.cn/problems/move-zeroes/solutions/90229/dong-hua-yan-shi-283yi-dong-ling-by-wang_ni_ma/)

#### ���α���

���Ǵ�������ָ��`i`��`j`����һ�α�����ʱ��ָ��`j`������¼��ǰ�ж���`��0`Ԫ�ء���������ʱ��ÿ����һ��`��0`Ԫ�ؾͽ������������Ų����һ�α������`j`ָ����±��ָ�������һ��`��0`Ԫ���±ꡣ
�ڶ��α�����ʱ����ʼλ�þʹ�`j`��ʼ����������ʣ�µ���������ڵ�Ԫ��ȫ����Ϊ`0`��
������ʾ��
![](./assets/img/Solution0283_3_01.gif)
ʱ�临�Ӷ�: O(n)
�ռ临�Ӷ�: O(1)
����ʵ��:

```java
class Solution {
    public void moveZeroes(int[] nums) {
        if(nums==null) {
            return;
        }
        //��һ�α�����ʱ��jָ���¼��0�ĸ�����ֻҪ�Ƿ�0��ͳͳ������nums[j]
        int j = 0;
        for(int i=0;i<nums.length;++i) {
            if(nums[i]!=0) {
                nums[j++] = nums[i];
            }
        }
        //��0Ԫ��ͳ�����ˣ�ʣ�µĶ���0��
        //���Եڶ��α�����ĩβ��Ԫ�ض���Ϊ0����
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
    # ��һ�α�����ʱ��jָ���¼��0�ĸ�����ֻҪ�Ƿ�0��ͳͳ������nums[j]
    j = 0
    for i in xrange(len(nums)):
        if nums[i]:
            nums[j] = nums[i]
            j += 1
    # ��0Ԫ��ͳ�����ˣ�ʣ�µĶ���0��
    # ���Եڶ��α�����ĩβ��Ԫ�ض���Ϊ0����
    for i in xrange(j,len(nums)):
        nums[i] = 0
```

#### һ�α���

����ο��˿��������˼�룬������������Ҫȷ��һ�����ָ��Ԫ�����м��`x`��Ȼ�������С�ڵ���`x`��Ԫ�طŵ�x����ߣ�����x��Ԫ�طŵ����ұߡ�
�������ǿ�����`0`��������м�㣬�Ѳ�����0(ע����Ŀû˵�����и���)�ķŵ��м�����ߣ�����0�ķŵ����ұߡ� ����м�����`0`��������ʵ�������ȿ�������򵥺ܶ࣬����ʹ������ָ��`i`��`j`��ֻҪ`nums[i]!=0`�����Ǿͽ���`nums[i]`��`nums[j]`
����ն�̬ͼ����⣺
![](./assets/img/Solution0283_3_02.gif)
ʱ�临�Ӷ�: O(n)
�ռ临�Ӷ�: O(1)
����ʵ��:

```java
class Solution {
    public void moveZeroes(int[] nums) {
        if(nums==null) {
            return;
        }
        //����ָ��i��j
        int j = 0;
        for(int i=0;i<nums.length;i++) {
            //��ǰԪ��!=0���Ͱ��佻������ߣ�����0�Ľ������ұ�
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
    # ����ָ��i��j
    j = 0
    for i in xrange(len(nums)):
        # ��ǰԪ��!=0���Ͱ��佻������ߣ�����0�Ľ������ұ�
        if nums[i]:
            nums[j],nums[i] = nums[i],nums[j]
            j += 1
```

(ȫ����)
