### [设计电子表格](https://leetcode.cn/problems/design-spreadsheet/solutions/3772881/she-ji-dian-zi-biao-ge-by-leetcode-solut-pz39/)

#### 方法一：模拟

**思路与算法**

根据题意可知，我们可以直接使用行数为 $rows$，列数为 $26$ 的二维数组 $grid$ 来保存每个单元格的值，此时查询和更新单元格时，直接查询和更新二维数组中的元素即可，$Spreadsheet$ 类实现如下：

- 初始化：调用 $Spreadsheet(int rows)$，创建行数为 $rows$，列数为 $26$ 的二维数组 $grid$，并将数组元素初始化为 $0$；
- $void setCell(String cell, int value)$：设置指定单元格的值为 $value$，按照规则从 字符串 $cell$ 中解析出单元格对应的行数与列数，并将对应的二维数组 $grid$ 对应元素的值设置为 $value$；
- $void resetCell(String cell)$：重置指定单元格的值为 $0$。按照规则从字符串 $cell$ 中解析出单元格对应的行数与列数，并将对应的二维数组 $grid$ 对应元素的值设置为 $0$；
- $int getValue(String formula)$：计算一个公式的值。根据题目为可知公式格式为：`"=X+Y"`，从 $formula$ 按照给定格式解析出 $X$ 与 $Y$。如果 $X$ 或 $Y$ 的首字母为字母，则其为单元格，此时从二维数组中 $grid$ 读取对应的值；如果其首字母为数字，则其为整数，分别求出 $X$ 与 $Y$ 对应的值，并返回二者相加的和即为答案。

**代码**

```C++
class Spreadsheet {
public:
    Spreadsheet(int rows) {
        this->grid = vector<vector<int>>(rows + 1, vector<int>(26));
    }

    void setCell(string cell, int value) {
        auto [x, y] = getPos(cell);
        grid[x][y] = value;
    }

    void resetCell(string cell) {
        auto [x, y] = getPos(cell);
        grid[x][y] = 0;
    }

    int getValue(string formula) {
        int i = formula.find('+');
        string cell1 = formula.substr(1, i - 1);
        string cell2 = formula.substr(i + 1);
        return getCellVal(cell1) + getCellVal(cell2);
    }

private:
    vector<vector<int>> grid;

    pair<int, int> getPos(const string &cell) {
        int x = stoi(cell.substr(1));
        int y = cell[0] - 'A';
        return {x, y};
    }

    int getCellVal(string &cell) {
        if (isalpha(cell[0])) {
            auto [x, y] = getPos(cell);
            return grid[x][y];
        } else {
            return stoi(cell);
        }
    }
};
```

```Java
public class Spreadsheet {
    private int[][] grid;

    public Spreadsheet(int rows) {
        this.grid = new int[rows + 1][26];
    }

    public void setCell(String cell, int value) {
        int[] pos = getPos(cell);
        grid[pos[0]][pos[1]] = value;
    }

    public void resetCell(String cell) {
        int[] pos = getPos(cell);
        grid[pos[0]][pos[1]] = 0;
    }

    public int getValue(String formula) {
        int i = formula.indexOf('+');
        String cell1 = formula.substring(1, i);
        String cell2 = formula.substring(i + 1);
        return getCellVal(cell1) + getCellVal(cell2);
    }

    private int[] getPos(String cell) {
        int x = Integer.parseInt(cell.substring(1));
        int y = cell.charAt(0) - 'A';
        return new int[]{x, y};
    }

    private int getCellVal(String cell) {
        if (Character.isLetter(cell.charAt(0))) {
            int[] pos = getPos(cell);
            return grid[pos[0]][pos[1]];
        } else {
            return Integer.parseInt(cell);
        }
    }
}
```

```CSharp
public class Spreadsheet {
    private int[,] grid;

    public Spreadsheet(int rows) {
        this.grid = new int[rows + 1, 26];
    }

    public void SetCell(string cell, int value) {
        var pos = GetPos(cell);
        grid[pos.Item1, pos.Item2] = value;
    }

    public void ResetCell(string cell) {
        var pos = GetPos(cell);
        grid[pos.Item1, pos.Item2] = 0;
    }

    public int GetValue(string formula) {
        int i = formula.IndexOf('+');
        string cell1 = formula.Substring(1, i - 1);
        string cell2 = formula.Substring(i + 1);
        return GetCellVal(cell1) + GetCellVal(cell2);
    }

    private Tuple<int, int> GetPos(string cell) {
        int x = int.Parse(cell.Substring(1));
        int y = cell[0] - 'A';
        return Tuple.Create(x, y);
    }

    private int GetCellVal(string cell) {
        if (char.IsLetter(cell[0])) {
            var pos = GetPos(cell);
            return grid[pos.Item1, pos.Item2];
        } else {
            return int.Parse(cell);
        }
    }
}
```

```Python
class Spreadsheet:

    def __init__(self, rows: int):
        self.grid = [[0] * 27 for _ in range(rows + 1)]

    def setCell(self, cell: str, value: int) -> None:
        x, y = self.getPos(cell)
        self.grid[x][y] = value

    def resetCell(self, cell: str) -> None:
        x, y = self.getPos(cell)
        self.grid[x][y] = 0

    def getValue(self, formula: str) -> int:
        i = formula.find('+')
        cell1 = formula[1:i]
        cell2 = formula[i + 1:]
        return self.getCellVal(cell1) + self.getCellVal(cell2)

    def getPos(self, cell):
        x = int(cell[1:])
        y = ord(cell[0]) - ord('A')
        return (x, y)

    def getCellVal(self, cell):
        if cell[0].isalpha():
            x, y = self.getPos(cell)
            return self.grid[x][y]
        else:
            return int(cell)
```

```Go
type Spreadsheet struct {
    grid [][]int
}

func Constructor(rows int) Spreadsheet {
    grid := make([][]int, rows+1)
    for i := range grid {
        grid[i] = make([]int, 27)
    }
    return Spreadsheet{grid: grid}
}

func (this *Spreadsheet) SetCell(cell string, value int)  {
    x, y := this.getPos(cell)
    this.grid[x][y] = value
}

func (this *Spreadsheet) ResetCell(cell string)  {
    x, y := this.getPos(cell)
    this.grid[x][y] = 0
}

func (this *Spreadsheet) GetValue(formula string) int {
    i := strings.Index(formula, "+")
    cell1 := formula[1:i]
    cell2 := formula[i+1:]
    return this.getCellVal(cell1) + this.getCellVal(cell2)
}

func (this *Spreadsheet) getPos(cell string) (int, int) {
    x, _ := strconv.Atoi(cell[1:])
    y := int(cell[0] - 'A')
    return x, y
}

func (this *Spreadsheet) getCellVal(cell string) int {
    if cell[0] >= 'A' && cell[0] <= 'Z' {
        x, y := this.getPos(cell)
        return this.grid[x][y]
    } else {
        val, _ := strconv.Atoi(cell)
        return val
    }
}
```

```C
#define COLUMNS 26

typedef struct {
    int** grid;
    int rows;
} Spreadsheet;

void getPos(const char* cell, int* x, int* y) {
    *x = atoi(cell + 1);
    *y = toupper(cell[0]) - 'A';
}

Spreadsheet* spreadsheetCreate(int rows) {
    Spreadsheet* obj = (Spreadsheet*)malloc(sizeof(Spreadsheet));
    obj->rows = rows + 1;
    obj->grid = (int**)malloc(obj->rows * sizeof(int*));
    for (int i = 0; i < obj->rows; i++) {
        obj->grid[i] = (int*)calloc(COLUMNS, sizeof(int));
    }
    return obj;
}

void spreadsheetSetCell(Spreadsheet* obj, char* cell, int value) {
    int x, y;
    getPos(cell, &x, &y);
    obj->grid[x][y] = value;
}

void spreadsheetResetCell(Spreadsheet* obj, char* cell) {
    int x, y;
    getPos(cell, &x, &y);
    obj->grid[x][y] = 0;
}

int getCellVal(Spreadsheet* obj, const char* cell) {
    if (isalpha(cell[0])) {
        int x, y;
        getPos(cell, &x, &y);
        return obj->grid[x][y];
    } else {
        return atoi(cell);
    }
}

int spreadsheetGetValue(Spreadsheet* obj, char* formula) {
    char* plus = strchr(formula, '+');
    char* cell1 = (char*)malloc(plus - formula);
    strncpy(cell1, formula + 1, plus - formula - 1);
    cell1[plus - formula - 1] = '\0';
    char* cell2 = strdup(plus + 1);
    int val1 = getCellVal(obj, cell1);
    int val2 = getCellVal(obj, cell2);
    free(cell1);
    free(cell2);
    return val1 + val2;
}

void spreadsheetFree(Spreadsheet* obj) {
    for (int i = 0; i < obj->rows; i++) {
        free(obj->grid[i]);
    }
    free(obj->grid);
    free(obj);
}
```

```JavaScript
var Spreadsheet = function(rows) {
    this.grid = Array.from({length: rows + 1}, () => new Array(27).fill(0));
};

Spreadsheet.prototype.setCell = function(cell, value) {
    const [x, y] = this.getPos(cell);
    this.grid[x][y] = value;
};

Spreadsheet.prototype.resetCell = function(cell) {
    const [x, y] = this.getPos(cell);
    this.grid[x][y] = 0;
};

Spreadsheet.prototype.getValue = function(formula) {
    const i = formula.indexOf('+');
    const cell1 = formula.substring(1, i);
    const cell2 = formula.substring(i + 1);
    return this.getCellVal(cell1) + this.getCellVal(cell2);
};

Spreadsheet.prototype.getPos = function(cell) {
    const x = parseInt(cell.substring(1));
    const y = cell.charCodeAt(0) - 'A'.charCodeAt(0);
    return [x, y];
}

Spreadsheet.prototype.getCellVal = function(cell) {
    if (/[A-Z]/.test(cell[0])) {
        const [x, y] = this.getPos(cell);
        return this.grid[x][y];
    } else {
        return parseInt(cell);
    }
}
```

```TypeScript
class Spreadsheet {
    private grid: number[][];

    constructor(rows: number) {
        this.grid = Array.from({length: rows + 1}, () => new Array(27).fill(0));
    }

    setCell(cell: string, value: number): void {
        const [x, y] = this.getPos(cell);
        this.grid[x][y] = value;
    }

    resetCell(cell: string): void {
        const [x, y] = this.getPos(cell);
        this.grid[x][y] = 0;
    }

    getValue(formula: string): number {
        const i = formula.indexOf('+');
        const cell1 = formula.substring(1, i);
        const cell2 = formula.substring(i + 1);
        return this.getCellVal(cell1) + this.getCellVal(cell2);
    }

    private getPos(cell: string): [number, number] {
        const x = parseInt(cell.substring(1));
        const y = cell.charCodeAt(0) - 'A'.charCodeAt(0);
        return [x, y];
    }

    private getCellVal(cell: string): number {
        if (/[A-Z]/.test(cell[0])) {
            const [x, y] = this.getPos(cell);
            return this.grid[x][y];
        } else {
            return parseInt(cell);
        }
    }
}
```

```Rust
pub struct Spreadsheet {
    grid: Vec<Vec<i32>>,
}

impl Spreadsheet {
    pub fn new(rows: i32) -> Self {
        Spreadsheet {
            grid: vec![vec![0; 27]; (rows + 1) as usize],
        }
    }

    pub fn set_cell(&mut self, cell: String, value: i32) {
        let (x, y) = self.get_pos(&cell);
        self.grid[x][y] = value;
    }

    pub fn reset_cell(&mut self, cell: String) {
        let (x, y) = self.get_pos(&cell);
        self.grid[x][y] = 0;
    }

    pub fn get_value(&self, formula: String) -> i32 {
        let i = formula.find('+').unwrap();
        let cell1 = &formula[1..i];
        let cell2 = &formula[i+1..];
        self.get_cell_val(cell1) + self.get_cell_val(cell2)
    }

    fn get_pos(&self, cell: &str) -> (usize, usize) {
        let x = cell[1..].parse::<usize>().unwrap();
        let y = cell.chars().next().unwrap() as usize - 'A' as usize;
        (x, y)
    }

    fn get_cell_val(&self, cell: &str) -> i32 {
        if cell.chars().next().unwrap().is_ascii_alphabetic() {
            let (x, y) = self.get_pos(cell);
            self.grid[x][y]
        } else {
            cell.parse().unwrap()
        }
    }
}
```

**复杂度分析**

- 时间复杂度：初始化表格时对应的时间复杂度为 $O(C\times rows)$，其余操作对应的时间复杂度为 $O(1)$，其中 $rows$ 表示给定的电子表格的行数，$C$ 表示给定的二维表格的列数，在本题中 $C=26$。初始化时需要创建一个行数为 $rows$，列数为 $26$ 的二维数组，此时需要的时间为 $O(C\times rows)$，其余操作仅涉及到解析字符串，并定位到单元格需要的时间为 $O(1)$。
- 空间复杂度：$O(C\times rows)$，其中 $rows$ 表示给定的电子表格的行数，$C$ 表示给定的二维表格的列数，在本题中 $C=26$。创建一个行数为 $rows$，列数为 $26$ 的二维数组，需要的空间为 $O(C\times rows)$。

#### 方法二：哈希表

**思路与算法**

根据题意可知，由于每个单元格的标识均不同，我们直接使用哈希表来保存单元格的值，此时更新和充值单元格时，直接更新哈希表即可，$Spreadsheet$ 类实现如下：

- 初始化：调用 $Spreadsheet(int rows)$：初始化单元格。此时直接初始化哈希表 $cellValues$。
- $void setCell(String cell, int value)$：设置指定单元格的值为 $value$，将哈希表中索引 $cell$ 对应的元素值设置为 $value$；
- $void resetCell(String cell)$：重置指定单元格的值为 $0$。从哈希表中删除索引为 $cell$ 的元素；
- $int getValue(String formula)$：计算一个公式的值。根据题目为可知公式格式为：`"=X+Y"`，从 $formula$ 按照给定格式解析出 $X$ 与 $Y$。如果 $X$ 或 $Y$ 的首字母为字母，则其为单元格，此时从哈希表 $cellValues$ 读取对应的值；如果其首字母为数字则将其转换为整数，分别求出 $X$ 与 $Y$ 对应的值，并返回二者相加的和即为答案。

**代码**

```C++
class Spreadsheet {
public:
    Spreadsheet(int) {}

    void setCell(string cell, int value) {
        cellValues[cell] = value;
    }

    void resetCell(string cell) {
        cellValues.erase(cell);
    }

    int getValue(string formula) {
        int i = formula.find('+');
        string cell1 = formula.substr(1, i - 1);
        string cell2 = formula.substr(i + 1);
        return (isalpha(cell1[0]) ? cellValues[cell1] : stoi(cell1)) +
               (isalpha(cell2[0]) ? cellValues[cell2] : stoi(cell2));
    }

private:
    unordered_map<string, int> cellValues;
};
```

```Java
public class Spreadsheet {
    private Map<String, Integer> cellValues = new HashMap<>();

    public Spreadsheet(int size) {

    }

    public void setCell(String cell, int value) {
        cellValues.put(cell, value);
    }

    public void resetCell(String cell) {
        cellValues.remove(cell);
    }

    public int getValue(String formula) {
        int i = formula.indexOf('+');
        String cell1 = formula.substring(1, i);
        String cell2 = formula.substring(i + 1);
        int val1 = Character.isLetter(cell1.charAt(0)) ? cellValues.getOrDefault(cell1, 0) : Integer.parseInt(cell1);
        int val2 = Character.isLetter(cell2.charAt(0)) ? cellValues.getOrDefault(cell2, 0) : Integer.parseInt(cell2);
        return val1 + val2;
    }
}
```

```CSharp
public class Spreadsheet {
    private Dictionary<string, int> cellValues = new Dictionary<string, int>();

    public Spreadsheet(int size) {}

    public void SetCell(string cell, int value) {
        cellValues[cell] = value;
    }

    public void ResetCell(string cell) {
        cellValues.Remove(cell);
    }

    public int GetValue(string formula) {
        int i = formula.IndexOf('+');
        string cell1 = formula.Substring(1, i - 1);
        string cell2 = formula.Substring(i + 1);
        int val1 = char.IsLetter(cell1[0]) ? cellValues.GetValueOrDefault(cell1) : int.Parse(cell1);
        int val2 = char.IsLetter(cell2[0]) ? cellValues.GetValueOrDefault(cell2) : int.Parse(cell2);
        return val1 + val2;
    }
}
```

```Go
type Spreadsheet struct {
    cellValues map[string]int
}

func Constructor(rows int) Spreadsheet {
    return Spreadsheet{
        cellValues: make(map[string]int),
    }
}

func (this *Spreadsheet) SetCell(cell string, value int)  {
    this.cellValues[cell] = value
}

func (this *Spreadsheet) ResetCell(cell string)  {
    delete(this.cellValues, cell)
}

func (this *Spreadsheet) GetValue(formula string) int {
    i := strings.Index(formula, "+")
    cell1 := formula[1:i]
    cell2 := formula[i + 1:]

    var val1, val2 int
    if unicode.IsLetter(rune(cell1[0])) {
        val1 = this.cellValues[cell1]
    } else {
        val1, _ = strconv.Atoi(cell1)
    }
    if unicode.IsLetter(rune(cell2[0])) {
        val2 = this.cellValues[cell2]
    } else {
        val2, _ = strconv.Atoi(cell2)
    }

    return val1 + val2
}
```

```Python
class Spreadsheet:

    def __init__(self, rows: int):
        self.cell_values = {}

    def setCell(self, cell: str, value: int) -> None:
        self.cell_values[cell] = value

    def resetCell(self, cell: str) -> None:
        if cell in self.cell_values:
            del self.cell_values[cell]

    def getValue(self, formula: str) -> int:
        i = formula.find('+')
        cell1 = formula[1:i]
        cell2 = formula[i + 1:]
        val1 = self.cell_values.get(cell1, 0) if cell1[0].isalpha() else int(cell1)
        val2 = self.cell_values.get(cell2, 0) if cell2[0].isalpha() else int(cell2)
        return val1 + val2
```

```C
typedef struct {
    char *key;
    int val;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, const char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, char *key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = strdup(key);
    pEntry->val = val;
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, char *key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, const char *key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

bool hashErase(HashItem **obj, char *key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return false;
    }
    HASH_DEL(*obj, pEntry);
    free(pEntry->key);
    free(pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr->key);
        free(curr);
    }
}

typedef struct {
    HashItem *cellValues;
} Spreadsheet;


Spreadsheet* spreadsheetCreate(int rows) {
    Spreadsheet *obj = (Spreadsheet *)malloc(sizeof(Spreadsheet));
    obj->cellValues = NULL;
    return obj;
}

void spreadsheetSetCell(Spreadsheet* obj, char* cell, int value) {
    hashSetItem(&obj->cellValues, cell, value);
}

void spreadsheetResetCell(Spreadsheet* obj, char* cell) {
    hashErase(&obj->cellValues, cell);
}

int getCellVal(Spreadsheet* obj, const char* cell) {
    if (isalpha(cell[0])) {
        return hashGetItem(&obj->cellValues, cell, 0);
    } else {
        return atoi(cell);
    }
}

int spreadsheetGetValue(Spreadsheet* obj, char* formula) {
    char* plus = strchr(formula, '+');
    char* cell1 = (char*)malloc(plus - formula);
    strncpy(cell1, formula + 1, plus - formula - 1);
    cell1[plus - formula - 1] = '\0';
    char* cell2 = strdup(plus + 1);
    int val1 = getCellVal(obj, cell1);
    int val2 = getCellVal(obj, cell2);
    free(cell1);
    free(cell2);
    return val1 + val2;
}

void spreadsheetFree(Spreadsheet* obj) {
    hashFree(&obj->cellValues);
    free(obj);
}
```

```JavaScript
var Spreadsheet = function(rows) {
    this.cellValues = {};
};

Spreadsheet.prototype.setCell = function(cell, value) {
    this.cellValues[cell] = value;
};

Spreadsheet.prototype.resetCell = function(cell) {
    delete this.cellValues[cell];
};

Spreadsheet.prototype.getValue = function(formula) {
    const i = formula.indexOf('+');
    const cell1 = formula.substring(1, i);
    const cell2 = formula.substring(i + 1);
    const val1 = /[a-z]/i.test(cell1[0]) ? (this.cellValues[cell1] || 0) : parseInt(cell1);
    const val2 = /[a-z]/i.test(cell2[0]) ? (this.cellValues[cell2] || 0) : parseInt(cell2);
    return val1 + val2;
};
```

```TypeScript
class Spreadsheet {
    private cellValues: {[key: string]: number} = {};

    constructor(size: number) {}

    setCell(cell: string, value: number): void {
        this.cellValues[cell] = value;
    }

    resetCell(cell: string): void {
        delete this.cellValues[cell];
    }

    getValue(formula: string): number {
        const i = formula.indexOf('+');
        const cell1 = formula.substring(1, i);
        const cell2 = formula.substring(i + 1);
        const val1 = /[a-z]/i.test(cell1[0]) ? (this.cellValues[cell1] || 0) : parseInt(cell1);
        const val2 = /[a-z]/i.test(cell2[0]) ? (this.cellValues[cell2] || 0) : parseInt(cell2);
        return val1 + val2;
    }
}
```

```Rust
use std::collections::HashMap;

struct Spreadsheet {
    cell_values: HashMap<String, i32>,
}

impl Spreadsheet {
    fn new(rows: i32) -> Self {
        Spreadsheet {
            cell_values: HashMap::new(),
        }
    }

    fn set_cell(&mut self, cell: String, value: i32) {
        self.cell_values.insert(cell, value);
    }

    fn reset_cell(&mut self, cell: String) {
        self.cell_values.remove(&cell);
    }

    fn get_value(&self, formula: String) -> i32 {
        let i = formula.find('+').expect("Formula must contain '+'");
        let (cell1, cell2) = formula.split_at(i);
        let cell1 = cell1[1..].to_string();
        let cell2 = cell2[1..].to_string();

        let val1 = if cell1.chars().next().unwrap().is_alphabetic() {
            *self.cell_values.get(&cell1).unwrap_or(&0)
        } else {
            cell1.parse().unwrap_or(0)
        };
        let val2 = if cell2.chars().next().unwrap().is_alphabetic() {
            *self.cell_values.get(&cell2).unwrap_or(&0)
        } else {
            cell2.parse().unwrap_or(0)
        };

        val1 + val2
    }
}
```

**复杂度分析**

- 时间复杂度：所有操作的时间复杂度为 $O(1)$。每次操作时仅需查询和更新哈希表即可，其余操作仅涉及到解析字符串，需要的时间为 $O(1)$。
- 空间复杂度：$O(cellsCount)$，其中 $cellsCount$ 表示电子表格中的非 $0$ 元素个数，取决于方法 $setCell$ 的调用次数。哈希表中最多有 $O(cellsCount)$ 个元素。
