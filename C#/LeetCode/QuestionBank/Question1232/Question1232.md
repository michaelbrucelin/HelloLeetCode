#### [1232\. 缀点成线](https://leetcode.cn/problems/check-if-it-is-a-straight-line/)

难度：简单

给定一个数组 `coordinates` ，其中 `coordinates[i] = [x, y]` ， `[x, y]` 表示横坐标为 `x`、纵坐标为 `y` 的点。请你来判断，这些点是否在该坐标系中属于同一条直线上。

**示例 1：**

![](./assets/img/Question1232_01.jpg)

```
输入：coordinates = [[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]
输出：true
```

**示例 2：**

![](./assets/img/Question1232_02.jpg)

```
输入：coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
输出：false
```

**提示：**

-   `2 <= coordinates.length <= 1000`
-   `coordinates[i].length == 2`
-   `-10^4 <= coordinates[i][0], coordinates[i][1] <= 10^4`
-   `coordinates` 中不含重复的点
