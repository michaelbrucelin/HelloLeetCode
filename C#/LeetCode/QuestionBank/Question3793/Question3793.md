### [3793\. 查找高 tokens 使用量的用户](https://leetcode.cn/problems/find-users-with-high-token-usage/)

难度：简单

**SQL Schema**

```sql
CREATE TABLE if not exists prompts (
    user_id INT,
    prompt VARCHAR(255),
    tokens INT
)

Truncate table prompts
insert into prompts (user_id, prompt, tokens) values ('1', 'Write a blog outline', '120')
insert into prompts (user_id, prompt, tokens) values ('1', 'Generate SQL query', '80')
insert into prompts (user_id, prompt, tokens) values ('1', 'Summarize an article', '200')
insert into prompts (user_id, prompt, tokens) values ('2', 'Create resume bullet', '60')
insert into prompts (user_id, prompt, tokens) values ('2', 'Improve LinkedIn bio', '70')
insert into prompts (user_id, prompt, tokens) values ('3', 'Explain neural networks', '300')
insert into prompts (user_id, prompt, tokens) values ('3', 'Generate interview Q&A', '250')
insert into prompts (user_id, prompt, tokens) values ('3', 'Write cover letter', '180')
insert into prompts (user_id, prompt, tokens) values ('3', 'Optimize Python code', '220')
```

**Pandas Schema**

```python
data = [[1, 'Write a blog outline', 120], [1, 'Generate SQL query', 80], [1, 'Summarize an article', 200], [2, 'Create resume bullet', 60], [2, 'Improve LinkedIn bio', 70], [3, 'Explain neural networks', 300], [3, 'Generate interview Q&A', 250], [3, 'Write cover letter', 180], [3, 'Optimize Python code', 220]]
prompts = pd.DataFrame({
    "user_id": pd.Series(dtype="int"),
    "prompt": pd.Series(dtype="string"),
    "tokens": pd.Series(dtype="int")
})
```

> 表：`prompts`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | user_id     | int     |
> | prompt      | varchar |
> | tokens      | int     |
> +-------------+---------+
> ```
>
> (user_id, prompt) 是这张表的主键（值互不相同）。
> 每一行表示一个用户提交给 AI 系统的提示词以及所消耗的 token 数量。

根据下列要求编写一个解决方案来分析 **AI 提示词的使用模式**：

- 对每一个用户，计算他们提交的 **提示词的总数**。
- 对每个用户，计算 **每个提示词所使用的平均 token 数**（舍入到 `2` 位小数）。
- 仅包含 **至少提交了 `3` 个提示词** 的用户。
- 仅包含那些 **至少提交过一个提示词** 且该提示词的 `tokens` 数量 **超过** 自己平均 token 使用量的用户。

返回结果表按 **平均 token 数 降序** 排序，然后按 `user_id` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> prompts 表：
>
> ```c
> +---------+--------------------------+--------+
> | user_id | prompt                   | tokens |
> +---------+--------------------------+--------+
> | 1       | Write a blog outline     | 120    |
> | 1       | Generate SQL query       | 80     |
> | 1       | Summarize an article     | 200    |
> | 2       | Create resume bullet     | 60     |
> | 2       | Improve LinkedIn bio     | 70     |
> | 3       | Explain neural networks  | 300    |
> | 3       | Generate interview Q&A   | 250    |
> | 3       | Write cover letter       | 180    |
> | 3       | Optimize Python code     | 220    |
> +---------+--------------------------+--------+
> ```
>
> **输出：**
>
> ```c
> +---------+---------------+------------+
> | user_id | prompt_count  | avg_tokens |
> +---------+---------------+------------+
> | 3       | 4             | 237.5      |
> | 1       | 3             | 133.33     |
> +---------+---------------+------------+
> ```
>
> **解释：**
>
> - **用户 1：**
>   - 总提示词数 = 3
>   - 平均 token 数 = (120 + 80 + 200) / 3 = 133.33
>   - 有一个提示词为 200 个 token，这超过了平均值
>   - 包含在结果中
> - **用户 2**:
>   - 总提示词数 = 2（少于所需的最小值）
>   - 从结果中排除
> - **用户 3**:
>   - 总提示词数 = 4
>   - 平均 token 数 = (300 + 250 + 180 + 220) / 4 = 237.5
>   - 有包含 300 和 250 个 token 的提示词，都大于平均数
>   - 包含在结果中
>
> 结果表按 avg_tokens 降序排序，然后按 user_id 升序排序。
