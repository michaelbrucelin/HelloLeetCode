### [3475\. DNA 模式识别](https://leetcode.cn/problems/dna-pattern-recognition/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE if not exists Samples (
    sample_id INT,
    dna_sequence VARCHAR(255),
    species VARCHAR(100)
)
Truncate table Samples
insert into Samples (sample_id, dna_sequence, species) values ('1', 'ATGCTAGCTAGCTAA', 'Human')
insert into Samples (sample_id, dna_sequence, species) values ('2', 'GGGTCAATCATC', 'Human')
insert into Samples (sample_id, dna_sequence, species) values ('3', 'ATATATCGTAGCTA', 'Human')
insert into Samples (sample_id, dna_sequence, species) values ('4', 'ATGGGGTCATCATAA', 'Mouse')
insert into Samples (sample_id, dna_sequence, species) values ('5', 'TCAGTCAGTCAG', 'Mouse')
insert into Samples (sample_id, dna_sequence, species) values ('6', 'ATATCGCGCTAG', 'Zebrafish')
insert into Samples (sample_id, dna_sequence, species) values ('7', 'CGTATGCGTCGTA', 'Zebrafish')
```

**Pandas Schema**

```python
data = [[1, 'ATGCTAGCTAGCTAA', 'Human'], [2, 'GGGTCAATCATC', 'Human'], [3, 'ATATATCGTAGCTA', 'Human'], [4, 'ATGGGGTCATCATAA', 'Mouse'], [5, 'TCAGTCAGTCAG', 'Mouse'], [6, 'ATATCGCGCTAG', 'Zebrafish'], [7, 'CGTATGCGTCGTA', 'Zebrafish']]
samples = pd.DataFrame({
    'sample_id': pd.Series(dtype='int'),        # Equivalent to SERIAL/INTEGER
    'dna_sequence': pd.Series(dtype='string'),  # Equivalent to TEXT/VARCHAR
    'species': pd.Series(dtype='string')        # Equivalent to VARCHAR(100)
})
```

> 表：`Samples`
>
> ```c
> +----------------+---------+
> | Column Name    | Type    |
> +----------------+---------+
> | sample_id      | int     |
> | dna_sequence   | varchar |
> | species        | varchar |
> +----------------+---------+
> ```
>
> sample_id 是这张表的唯一主键。
> 每一行包含一个 DNA 序列以一个字符（A，T，G，C）组成的字符串表示以及它所采集自的物种。

生物学家正在研究 DNA 序列中的基本模式。编写一个解决方案以识别具有以下模式的 `sample_id`：

- 以 **ATG** **开头** 的序列（一个常见的 **起始密码子**）
- 以 **TAA**，**TAG** 或 **TGA** **结尾** 的序列（终止密码子）
- 包含基序 **ATAT** 的序列（一个简单重复模式）
- 有 **至少** `3` **个连续** **G** 的序列（如 **GGG** 或 **GGGG**）

返回结果表以 sample_id **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> Samples 表：
>
> ```c
> +-----------+------------------+-----------+
> | sample_id | dna_sequence     | species   |
> +-----------+------------------+-----------+
> | 1         | ATGCTAGCTAGCTAA  | Human     |
> | 2         | GGGTCAATCATC     | Human     |
> | 3         | ATATATCGTAGCTA   | Human     |
> | 4         | ATGGGGTCATCATAA  | Mouse     |
> | 5         | TCAGTCAGTCAG     | Mouse     |
> | 6         | ATATCGCGCTAG     | Zebrafish |
> | 7         | CGTATGCGTCGTA    | Zebrafish |
> +-----------+------------------+-----------+
> ```
>
> **输出：**
>
> ```c
> +-----------+------------------+-------------+-------------+------------+------------+------------+
> | sample_id | dna_sequence     | species     | has_start   | has_stop   | has_atat   | has_ggg    |
> +-----------+------------------+-------------+-------------+------------+------------+------------+
> | 1         | ATGCTAGCTAGCTAA  | Human       | 1           | 1          | 0          | 0          |
> | 2         | GGGTCAATCATC     | Human       | 0           | 0          | 0          | 1          |
> | 3         | ATATATCGTAGCTA   | Human       | 0           | 0          | 1          | 0          |
> | 4         | ATGGGGTCATCATAA  | Mouse       | 1           | 1          | 0          | 1          |
> | 5         | TCAGTCAGTCAG     | Mouse       | 0           | 0          | 0          | 0          |
> | 6         | ATATCGCGCTAG     | Zebrafish   | 0           | 1          | 1          | 0          |
> | 7         | CGTATGCGTCGTA    | Zebrafish   | 0           | 0          | 0          | 0          |
> +-----------+------------------+-------------+-------------+------------+------------+------------+
> ```
>
> **解释：**
>
> - 样本 1（ATGCTAGCTAGCTAA）：
>   - 以 ATG 开头（has_start = 1）
>   - 以 TAA 结尾（has_stop = 1）
>   - 不包含 ATAT（has_atat = 0）
>   - 不包含至少 3 个连续 ‘G’（has_ggg = 0）
> - 样本 2（GGGTCAATCATC）：
>   - 不以 ATG 开头（has_start = 0）
>   - 不以 TAA，TAG 或 TGA 结尾（has_stop = 0）
>   - 不包含 ATAT（has_atat = 0）
>   - 包含 GGG（has_ggg = 1）
> - 样本 3（ATATATCGTAGCTA）：
>   - 不以 ATG 开头（has_start = 0）
>   - 不以 TAA，TAG 或 TGA 结尾（has_stop = 0）
>   - 包含 ATAT（has_atat = 1）
>   - 不包含至少 3 个连续 ‘G’（has_ggg = 0）
> - 样本 4（ATGGGGTCATCATAA）：
>   - 以 ATG 开头（has_start = 1）
>   - 以 TAA 结尾（has_stop = 1）
>   - 不包含 ATAT（has_atat = 0）
>   - 包含 GGGG（has_ggg = 1）
> - 样本 5（TCAGTCAGTCAG）：
>   - 不匹配任何模式（所有字段 = 0）
> - 样本 6（ATATCGCGCTAG）：
>   - 不以 ATG 开头（has_start = 0）
>   - 以 TAG 结尾（has_stop = 1）
>   - 包含 ATAT（has_atat = 1）
>   - 不包含至少 3 个连续 ‘G’（has_ggg = 0）
> - 样本 7（CGTATGCGTCGTA）：
>   - 不以 ATG 开头（has_start = 0）
>   - 不以 TAA，TAG 或 TGA 结尾（has_stop = 0）
>   - 不包含 ATAT（has_atat = 0）
>   - 不包含至少 3 个连续 ‘G’（has_ggg = 0）
>
> **注意：**
>
> - 结果以 sample_id 升序排序
> - 对于每个模式，1 表示该模式存在，0 表示不存在
