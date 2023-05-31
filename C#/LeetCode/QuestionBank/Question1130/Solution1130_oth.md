#### [为什么单调递减栈的算法可行](https://leetcode.cn/problems/minimum-cost-tree-from-leaf-values/solutions/377595/wei-shi-yao-dan-diao-di-jian-zhan-de-suan-fa-ke-xi/)

#### 解题思路

首先，想让 mct 值最小，那么值较小的叶子节点就要尽量放到底部，值较大的叶子节点要尽量放到靠上的部分。因为越是底部的叶子节点，被用来做乘法的次数越多。这就决定了我们有必要去寻找一个极小值。通过维护一个单调递减栈就可以找到一个极小值，因为既然是单调递减栈，左侧节点一定大于栈顶节点，而当前节点（右侧）也大于栈顶节点（因为当前节点小于栈顶的话，就被直接入栈了）。

然后找到这个极小值后，就需要左右看看，左边和右边哪个值更小，因为我们的目的是把较小的值尽量放到底部。还有一点，构造出来的二叉树一定是形如下面图一的样子，比如 `[6,2,3,4]` 构成的二叉树：

图一 (最小 mct 一定形如以下的样子)： mct: 24 + 12 + 6 = 42

```
  24
 /  \
6    12
    /  \
   6    4
  / \
 2   3
```

图二 (这个容易想到，但是一定不是最小 mct)： mct: 24 + 12 + 12 = 48

```
     24
    /  \
  12    12
 / \    / \
6   2  3   4
```

---

在栈 `st` 的栈底，我们可以放一个 `Integer.MAX_VALUE`，方便做比较，分析一遍 `[6,2,3,4]` 的运行过程：

1.  `[Integer.MAX_VALUE], 6` => 入栈
    
2.  `[Integer.MAX_VALUE, 6], 2` => 入栈
    
3.  `[Integer.MAX_VALUE, 6, 2], 3` => 先取出 2，与 3 组合(左 6 右 3 中取较小的一个)，然后把 3 入栈(3 会作为一侧最大值，参与后续乘法): `mct += st.pop() * Math.min(st.peek(), arr[i]);`
    
    ```
      6
     / \
    2   3
    ```
    
4.  `[Integer.MAX_VALUE, 6, 3], 4` => 3，出栈，4 入栈，最终结果 mct 会加上 3 \* 4 的值: `mct += st.pop() * Math.min(st.peek(), arr[i]);`
    
    ```
        12
       /  \
      6    4
     / \
    2   3
    ```
    
5.  `[Integer.MAX_VALUE, 6, 4]` => 源数组已遍历完，栈中还有较多数据，那么依次出栈做计算： `while (st.size() > 2) mct += st.pop() * st.peek();`
    
    ```
      24
     /  \
    6    12
        /  \
       6    4
      / \
     2   3
    ```

可见，栈顶存的一直是当时能找到的最小值，也是二叉树某侧的叶子节点最大值，可以直接参与乘法运算。

---

再随便看一下全部递增和全部递减的数据的构造过程： **\[1,2,3,4\]**:

`[Integer.MAX_VALUE, 1], 2` => `while (arr[i] >= st.peek()) mct += st.pop() * Math.min(st.peek(), arr[i]);`

```
  2
 / \
1   2
```

`[Integer.MAX_VALUE, 2], 3` => `while (arr[i] >= st.peek()) mct += st.pop() * Math.min(st.peek(), arr[i]);`

```
    6
   / \
  2   3
 / \
1   2
```

`[Integer.MAX_VALUE, 3], 4` => `while (arr[i] >= st.peek()) mct += st.pop() * Math.min(st.peek(), arr[i]);`

```
      12
     /  \
    6    4
   / \
  2   3
 / \
1   2
```

---

**\[4,3,2,1\]**:

`[Integer.MAX_VALUE, 4, 3, 2, 1]` => `while (st.size() > 2) mct += st.pop() * st.peek();`

```
  2
 / \
2   1
```

`[Integer.MAX_VALUE, 4, 3, 2]` => `while (st.size() > 2) mct += st.pop() * st.peek();`

```
  6
 / \
3   2
   / \
  2   1
```

`[Integer.MAX_VALUE, 4, 3]` => `while (st.size() > 2) mct += st.pop() * st.peek();`

```
  12
 /  \
4    6
    / \
   3   2
      / \
     2   1
```

都能正确构造出正确的最小 mct 树。 其余情况其实最终都可以归并到这些情况之中。

#### 代码

```cpp
class Solution {
    public int mctFromLeafValues(int[] arr) {
        Stack<Integer> st = new Stack();
        st.push(Integer.MAX_VALUE);
        int mct = 0;
        for (int i = 0; i < arr.length; i++) {
            while (arr[i] >= st.peek()) {
                mct += st.pop() * Math.min(st.peek(), arr[i]);
            }
            st.push(arr[i]);
        }
        while (st.size() > 2) {
            mct += st.pop() * st.peek();
        }
        return mct;
    }
}
```
