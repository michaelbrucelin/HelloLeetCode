### [3586\. 寻找 COVID 康复患者](https://leetcode.cn/problems/find-covid-recovery-patients/)

难度：中等

**SQL Schema**

```sql
CREATE TABLE patients (
    patient_id INT,
    patient_name VARCHAR(255),
    age INT
)
CREATE TABLE covid_tests (
    test_id INT,
    patient_id INT,
    test_date DATE,
    result VARCHAR(50)
)
Truncate table patients
insert into patients (patient_id, patient_name, age) values ('1', 'Alice Smith', '28')
insert into patients (patient_id, patient_name, age) values ('2', 'Bob Johnson', '35')
insert into patients (patient_id, patient_name, age) values ('3', 'Carol Davis', '42')
insert into patients (patient_id, patient_name, age) values ('4', 'David Wilson', '31')
insert into patients (patient_id, patient_name, age) values ('5', 'Emma Brown', '29')
Truncate table covid_tests
insert into covid_tests (test_id, patient_id, test_date, result) values ('1', '1', '2023-01-15', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('2', '1', '2023-01-25', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('3', '2', '2023-02-01', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('4', '2', '2023-02-05', 'Inconclusive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('5', '2', '2023-02-12', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('6', '3', '2023-01-20', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('7', '3', '2023-02-10', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('8', '3', '2023-02-20', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('9', '4', '2023-01-10', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('10', '4', '2023-01-18', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('11', '5', '2023-02-15', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('12', '5', '2023-02-20', 'Negative')
```

**Pandas Schema**

```python
data = [[1, 'Alice Smith', 28], [2, 'Bob Johnson', 35], [3, 'Carol Davis', 42], [4, 'David Wilson', 31], [5, 'Emma Brown', 29]]
patients = pd.DataFrame({
    'patient_id': pd.Series(dtype='int'),
    'patient_name': pd.Series(dtype='str'),
    'age': pd.Series(dtype='int')
})
data = [[1, 1, '2023-01-15', 'Positive'], [2, 1, '2023-01-25', 'Negative'], [3, 2, '2023-02-01', 'Positive'], [4, 2, '2023-02-05', 'Inconclusive'], [5, 2, '2023-02-12', 'Negative'], [6, 3, '2023-01-20', 'Negative'], [7, 3, '2023-02-10', 'Positive'], [8, 3, '2023-02-20', 'Negative'], [9, 4, '2023-01-10', 'Positive'], [10, 4, '2023-01-18', 'Positive'], [11, 5, '2023-02-15', 'Negative'], [12, 5, '2023-02-20', 'Negative']]
covid_tests = pd.DataFrame({
    'test_id': pd.Series(dtype='int'),
    'patient_id': pd.Series(dtype='int'),
    'test_date': pd.Series(dtype='datetime64[ns]'),
    'result': pd.Series(dtype='str')
})
```

> 表：`patients`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | patient_id  | int     |
> | patient_name| varchar |
> | age         | int     |
> +-------------+---------+
> ```
>
> patient_id 是这张表的唯一主键。
> 每一行表示一个患者的信息。
>
> 表：`covid_tests`
>
> ```c
> +-------------+---------+
> | Column Name | Type    |
> +-------------+---------+
> | test_id     | int     |
> | patient_id  | int     |
> | test_date   | date    |
> | result      | varchar |
> +-------------+---------+
> ```
>
> test_id 是这张表的唯一主键。
> 每一行代表一个 COVID 检测结果。结果可以是阳性、阴性或不确定。

编写一个解决方案以找到从 COVID 中康复的患者——那些曾经检测呈阳性但后来检测呈阴性的患者。

- 患者如果 **至少有一次阳性** 检测结果后，在 **之后的日期** 至少有一次 **阴性** 检测结果，则被认为已康复。
- 计算从 **首次阳性检测** 结果到 **该阳性检测** 后的 **首次阴性检测结果** 之间的 **康复时间**（以天为单位）
- **仅包括** 同时具有阳性及阴性检测结果的患者

返回结果表以 `recovery_time` **升序** 排序，然后以 `patient_name` **升序** 排序。

结果格式如下所示。

**示例：**

> **输入：**
>
> patients 表：
>
> ```c
> +------------+--------------+-----+
> | patient_id | patient_name | age |
> +------------+--------------+-----+
> | 1          | Alice Smith  | 28  |
> | 2          | Bob Johnson  | 35  |
> | 3          | Carol Davis  | 42  |
> | 4          | David Wilson | 31  |
> | 5          | Emma Brown   | 29  |
> +------------+--------------+-----+
> ```
>
> covid_tests 表：
>
> ```c
> +---------+------------+------------+--------------+
> | test_id | patient_id | test_date  | result       |
> +---------+------------+------------+--------------+
> | 1       | 1          | 2023-01-15 | Positive     |
> | 2       | 1          | 2023-01-25 | Negative     |
> | 3       | 2          | 2023-02-01 | Positive     |
> | 4       | 2          | 2023-02-05 | Inconclusive |
> | 5       | 2          | 2023-02-12 | Negative     |
> | 6       | 3          | 2023-01-20 | Negative     |
> | 7       | 3          | 2023-02-10 | Positive     |
> | 8       | 3          | 2023-02-20 | Negative     |
> | 9       | 4          | 2023-01-10 | Positive     |
> | 10      | 4          | 2023-01-18 | Positive     |
> | 11      | 5          | 2023-02-15 | Negative     |
> | 12      | 5          | 2023-02-20 | Negative     |
> +---------+------------+------------+--------------+
> ```
>
> **输出：**
>
> ```c
> +------------+--------------+-----+---------------+
> | patient_id | patient_name | age | recovery_time |
> +------------+--------------+-----+---------------+
> | 1          | Alice Smith  | 28  | 10            |
> | 3          | Carol Davis  | 42  | 10            |
> | 2          | Bob Johnson  | 35  | 11            |
> +------------+--------------+-----+---------------+
> ```
>
> **解释：**
>
> - **Alice Smith (patient_id = 1):**
>   - 首次阳性检测：2023-01-15
>   - 阳性检测后的首次阴性检测：2023-01-25
>   - 康复时间：25 - 15 = 10 天
> - **Bob Johnson (patient_id = 2):**
>   - 首次阳性检测：2023-02-01
>   - 测试结果不明确：2023-02-05（忽略计算康复时间）
>   - 阳性检测后的首次阴性检测：2023-02-12
>   - 康复时间：12 - 1 = 11 天
> - **Carol Davis (patient_id = 3):**
>   - 检测呈阴性：2023-01-20（在阳性检测前）
>   - 首次阳性检测：2023-02-10
>   - 阳性检测后的首次阴性检测：2023-02-20
>   - 康复时间：20 - 10 = 10 天
> - **没有包含的患者：**
>   - David Wilson（patient_id = 4）：只有阳性检测，之后没有阴性检测。
>   - Emma Brown（patient_id = 5）：只有阴性检测，从未有阳性检测。
>
> 输出表以 recovery_time 升序排序，然后以 patient_name 升序排序。
