### [4008\. 击败所有怪物的最小初始强度](https://leetcode.cn/problems/minimum-initial-strength-to-defeat-all-monsters/)

难度：中等

给你一个整数数组 `monsters`，其中 `monsters[i]` 表示第 `i` 个怪物的强度。

同时给你一个二维整数数组 `boosts`，其中 <code>boosts[i] = [l<sub>i</sub>, r<sub>i</sub>, v<sub>i</sub>]</code> 表示与下标在 <code>[l<sub>i</sub>, r<sub>i</sub>]</code> 范围内的任意怪物战斗时，你的 **临时加成** 会增加 <code>v<sub>i</sub></code>。加成范围可能会重叠，所有适用的加成值将被相加。

你以一个 **非负** 初始强度开始，并从左到右依次与怪物战斗。

对于下标为 `i` 的每个怪物：

- 令 `bonus` 为适用于怪物 `i` 的所有加成值之 **和**。
- 只有你的当前强度加上 `bonus` **至少** 为 `monsters[i]` 时，你才能击败该怪物。
- 击败怪物后，你的当前强度会减少 `monsters[i]`。如果强度变为 **负数**，则将其设置为 0。

返回击败所有怪物所需的 **最小** 初始强度。

注意：临时加成仅用于确定是否可以击败当前怪物。它不会以其他方式改变你的当前强度。

**示例 1：**

> **输入：** monsters = [5,10,15], boosts = \[[1,1,10]]
> **输出：** 30
> **解释：**
> 让我们以 30 的初始强度开始。
>
> - `monsters[0] = 5`：在下标 0 处，加成为 0。由于 `30 + 0 >= 5`，该怪物可以被击败。强度变为 `30 - 5 = 25`。
> - `monsters[1] = 10`：在下标 1 处，加成为 10。由于 `25 + 10 >= 10`，该怪物可以被击败。强度变为 `25 - 10 = 15`。
> - `monsters[2] = 15`：在下标 2 处，加成为 0。由于 `15 + 0 >= 15`，该怪物可以被击败。强度变为 `15 - 15 = 0`。
>
> 因此，所需的最小初始强度是 30。

**示例 2：**

> **输入：** monsters = [5,10,15], boosts = \[[1,2,10],[1,2,5]]
> **输出：** 5
> **解释：**
> 让我们以 5 的初始强度开始。
>
> - `monsters[0] = 5`：加成为 0。由于 `5 + 0 >= 5`，该怪物可以被击败。强度变为 `5 - 5 = 0`。
> - `monsters[1] = 10`：两个重叠的加成提供 `bonus = 10 + 5 = 15`。由于 `0 + 15 >= 10`，该怪物可以被击败。强度保持为 0。
> - `monsters[2] = 15`：两个重叠的加成再次提供 `bonus = 15`。由于 `0 + 15 >= 15`，该怪物可以被击败。强度保持为 0。
>
> 因此，所需的最小初始强度是 5。

**提示：**

- <code>1 <= monsters.length <= 5 &times; 10<sup>4</sup></code>
- <code>1 <= monsters[i] <= 10<sup>9</sup></code>
- <code>0 <= boosts.length <= 5 &times; 10<sup>4</sup></code>
- <code>boosts[i] == [l<sub>i</sub>, r<sub>i</sub>, v<sub>i</sub>]</code>
- <code>0 <= l<sub>i</sub> <= r<sub>i</sub> < monsters.length</code>
- <code>1 <= v<sub>i</sub> <= 10<sup>9</sup></code>
