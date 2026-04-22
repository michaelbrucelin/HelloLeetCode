### [2526\. 找到数据流中的连续整数](https://leetcode.cn/problems/find-consecutive-integers-from-a-data-stream/)

难度：中等

给你一个整数数据流，请你实现一个数据结构，检查数据流中最后 `k` 个整数是否 **等于** 给定值 `value`。

请你实现 **DataStream** 类：

- `DataStream(int value, int k)` 用两个整数 `value` 和 `k` 初始化一个空的整数数据流。
- `boolean consec(int num)` 将 `num` 添加到整数数据流。如果后 `k` 个整数都等于 `value`，返回 `true`，否则返回 `false`。如果少于 `k` 个整数，条件不满足，所以也返回 `false`。

**示例 1：**

> **输入：**
> ["DataStream", "consec", "consec", "consec", "consec"]
> \[[4, 3], [4], [4], [4], [3]]
> **输出：**
> [null, false, false, true, false]
> **解释：**
>
> ```c
> DataStream dataStream = new DataStream(4, 3);  // value = 4, k = 3
> dataStream.consec(4);                          // 数据流中只有 1 个整数，所以返回 False。
> dataStream.consec(4);                          // 数据流中只有 2 个整数
>                                                // 由于 2 小于 k，返回 False。
> dataStream.consec(4);                          // 数据流最后 3 个整数都等于 value，所以返回 True。
> dataStream.consec(3);                          // 最后 k 个整数分别是 [4,4,3]。
>                                                // 由于 3 不等于 value，返回 False。
> ```

**提示：**

- <code>1 <= value, num <= 10<sup>9</sup></code>
- <code>1 <= k <= 10<sup>5</sup></code>
- 至多调用 `consec` 次数为 <code>10<sup>5</sup></code> 次。
