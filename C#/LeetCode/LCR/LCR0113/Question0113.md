### [LCR 113. 课程表 II](https://leetcode.cn/problems/QA2IGt/)

难度：中等

现在总共有 `numCourses` 门课需要选，记为 `0` 到 `numCourses-1`。

给定一个数组 `prerequisites`，它的每一个元素 `prerequisites[i]` 表示两门课程之间的先修顺序。例如 <code>prerequisites[i] = [a<sub>i</sub>, b<sub>i</sub>]</code> 表示想要学习课程 <code>a<sub>i</sub></code>，需要先完成课程 <code>b<sub>i</sub></code>。

请根据给出的总课程数  `numCourses` 和表示先修顺序的 `prerequisites` 得出一个可行的修课序列。

可能会有多个正确的顺序，只要任意返回一种就可以了。如果不可能完成所有课程，返回一个空数组。

**示例 1：**

> **输入:** numCourses = 2, prerequisites = \[[1,0]] 
> **输出:** [0,1]
> **解释:** 总共有 2 门课程。要学习课程 1，你需要先完成课程 0。因此，正确的课程顺序为 [0,1]。

**示例 2：**

> **输入:** numCourses = 4, prerequisites = \[[1,0],[2,0],[3,1],[3,2]]
> **输出:** [0,1,2,3] or [0,2,1,3]
> **解释:** 总共有 4 门课程。要学习课程 3，你应该先完成课程 1 和课程 2。并且课程 1 和课程 2 都应该排在课程 0 之后。因此，一个正确的课程顺序是 [0,1,2,3]。另一个正确的排序是 [0,2,1,3]。

**示例 3：**

> **输入:** numCourses = 1, prerequisites = [] 
> **输出:** [0]
> **解释:** 总共 1 门课，直接修第一门课就可。

**提示：**

- `1 <= numCourses <= 2000`
- `0 <= prerequisites.length <= numCourses * (numCourses - 1)`
- `prerequisites[i].length == 2`
- <code>0 <= a<sub>i</sub>, b<sub>i</sub> < numCourses</code>
- <code>a<sub>i</sub> != b<sub>i</sub></code>
- `prerequisites` 中不存在重复元素

**注意：** 本题与主站 210 题相同：[https://leetcode.cn/problems/course-schedule-ii/](https://leetcode.cn/problems/course-schedule-ii/)
