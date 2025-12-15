### [优惠券校验器](https://leetcode.cn/problems/coupon-code-validator/solutions/3853498/you-hui-quan-xiao-yan-qi-by-leetcode-sol-6noh/)

#### 方法一：分类 $+$ 排序

**思路及解法**

我们可以通过一个判断函数 $check$ 来判断优惠券是否有效，判断依据是其 $code$ 是否符合标准以及 $isActive$ 是否为 $true$。

然后将优惠券按照业务类别进行分类，分类完成后将每个类别的优惠券按照 $code$ 的字典序从小到大排序，最后将所有类别的优惠券拼接起来返回即可。

**代码**

```C++
class Solution {
public:
    bool check(string code, bool isActive) {
        for (auto it : code) {
            if (it != '_' && !isalnum(it)) {
                return false;
            }
        }
        return isActive;
    }

    vector<string> validateCoupons(vector<string>& code,
                                   vector<string>& businessLine,
                                   vector<bool>& isActive) {
        vector<string> groups[4];
        vector<string> ans;
        for (int i = 0; i < code.size(); i++) {
            if (code[i].size() && check(code[i], isActive[i])) {
                if (businessLine[i] == "electronics") {
                    groups[0].push_back(code[i]);
                } else if (businessLine[i] == "grocery") {
                    groups[1].push_back(code[i]);
                } else if (businessLine[i] == "pharmacy") {
                    groups[2].push_back(code[i]);
                } else if (businessLine[i] == "restaurant") {
                    groups[3].push_back(code[i]);
                }
            }
        }
        for (auto& group : groups) {
            sort(group.begin(), group.end());
            ans.insert(ans.end(), group.begin(), group.end());
        }
        return ans;
    }
};
```

```Java
class Solution {
    public boolean check(String code, boolean isActive) {
        for (char it : code.toCharArray()) {
            if (it != '_' && !Character.isLetterOrDigit(it)) {
                return false;
            }
        }
        return isActive;
    }
    public List<String> validateCoupons(String[] code,
                                       String[] businessLine,
                                       boolean[] isActive) {
        List<String>[] groups = new ArrayList[4];
        for (int i = 0; i < 4; i++) {
            groups[i] = new ArrayList<>();
        }
        List<String> ans = new ArrayList<>();
        for (int i = 0; i < code.length; i++) {
            if (!code[i].isEmpty() && check(code[i], isActive[i])) {
                if (businessLine[i].equals("electronics")) {
                    groups[0].add(code[i]);
                } else if (businessLine[i].equals("grocery")) {
                    groups[1].add(code[i]);
                } else if (businessLine[i].equals("pharmacy")) {
                    groups[2].add(code[i]);
                } else if (businessLine[i].equals("restaurant")) {
                    groups[3].add(code[i]);
                }
            }
        }
        for (List<String> group : groups) {
            Collections.sort(group);
            ans.addAll(group);
        }
        return ans;
    }
}
```

```Python
class Solution:
    def check(self, code: str, isActive: bool) -> bool:
        if not code:
            return False
        for char in code:
            if char != '_' and not char.isalnum():
                return False
        return isActive
    
    def validateCoupons(self, code: List[str], businessLine: List[str], 
                       isActive: List[bool]) -> List[str]:
        groups = [[] for _ in range(4)]
        ans = []
        business_mapping = {
            "electronics": 0,
            "grocery": 1,
            "pharmacy": 2,
            "restaurant": 3
        }
        for i in range(len(code)):
            if code[i] and self.check(code[i], isActive[i]):
                biz_line = businessLine[i]
                if biz_line in business_mapping:
                    group_index = business_mapping[biz_line]
                    groups[group_index].append(code[i])
        for group in groups:
            group.sort()  
            ans.extend(group)
        return ans
```

```CSharp
public class Solution {
    private bool Check(string code, bool isActive) {
        foreach (char c in code) {
            if (c != '_' && !char.IsLetterOrDigit(c)) {
                return false;
            }
        }
        return isActive;
    }

    public string[] ValidateCoupons(string[] code, string[] businessLine, bool[] isActive) {
        List<string>[] groups = new List<string>[4];
        for (int i = 0; i < 4; i++) {
            groups[i] = new List<string>();
        }
        
        for (int i = 0; i < code.Length; i++) {
            if (!string.IsNullOrEmpty(code[i]) && Check(code[i], isActive[i])) {
                switch (businessLine[i]) {
                    case "electronics":
                        groups[0].Add(code[i]);
                        break;
                    case "grocery":
                        groups[1].Add(code[i]);
                        break;
                    case "pharmacy":
                        groups[2].Add(code[i]);
                        break;
                    case "restaurant":
                        groups[3].Add(code[i]);
                        break;
                }
            }
        }
        
        foreach (var group in groups) {
            group.Sort(StringComparer.Ordinal);
        }
        List<string> result = new List<string>();
        foreach (var group in groups) {
            result.AddRange(group);
        }
        
        return result.ToArray();
    }
}
```

```Go
func check(code string, isActive bool) bool {
    for _, c := range code {
        if c != '_' && !unicode.IsLetter(c) && !unicode.IsDigit(c) {
            return false
        }
    }
    return isActive
}

func validateCoupons(code []string, businessLine []string, isActive []bool) []string {
    groups := make([][]string, 4)
    for i := range groups {
        groups[i] = make([]string, 0)
    }
    
    ans := make([]string, 0)
    
    for i := 0; i < len(code); i++ {
        if code[i] != "" && check(code[i], isActive[i]) {
            switch businessLine[i] {
            case "electronics":
                groups[0] = append(groups[0], code[i])
            case "grocery":
                groups[1] = append(groups[1], code[i])
            case "pharmacy":
                groups[2] = append(groups[2], code[i])
            case "restaurant":
                groups[3] = append(groups[3], code[i])
            }
        }
    }
    
    for _, group := range groups {
        sort.Strings(group)
        ans = append(ans, group...)
    }
    
    return ans
}
```

```C
int compare(const void* a, const void* b) {
    return strcmp(*(const char**)a, *(const char**)b);
}

bool check(const char* code, bool isActive) {
    for (int i = 0; code[i] != '\0'; i++) {
        if (code[i] != '_' && !isalnum(code[i])) {
            return false;
        }
    }
    return isActive;
}

char** validateCoupons(char** code, int codeSize, char** businessLine, int businessLineSize, bool* isActive, int isActiveSize, int* returnSize) {
    char** groups[4];
    int groupsSize[4] = {0};
    for (int i = 0; i < 4; i++) {
        groups[i] = (char **)malloc(sizeof(char *) * codeSize);
    }
    
    for (int i = 0; i < codeSize; i++) {
        if (strlen(code[i]) > 0 && check(code[i], isActive[i])) {
            if (strcmp(businessLine[i], "electronics") == 0) {
                groups[0][groupsSize[0]++] = code[i];
            } else if (strcmp(businessLine[i], "grocery") == 0) {
                groups[1][groupsSize[1]++] = code[i];
            } else if (strcmp(businessLine[i], "pharmacy") == 0) {
                groups[2][groupsSize[2]++] = code[i];
            } else if (strcmp(businessLine[i], "restaurant") == 0) {
                groups[3][groupsSize[3]++] = code[i];
            }
        }
    }
    
    int totalSize = 0;
    for (int i = 0; i < 4; i++) {
        qsort(groups[i], groupsSize[i], sizeof(char*), compare);
        totalSize += groupsSize[i];
    }
    
    char** result = malloc(sizeof(char*) * totalSize);
    int pos = 0;
    for (int i = 0; i < 4; i++) {
        for (int j = 0; j < groupsSize[i]; j++) {
            result[pos] = malloc(strlen(groups[i][j]) + 1);
            strcpy(result[pos], groups[i][j]);
            pos++;
        }
        free(groups[i]);
    }
    
    *returnSize = totalSize;
    return result;
}
```

```JavaScript
var validateCoupons = function(code, businessLine, isActive) {
    const groups = [[], [], [], []];
    const ans = [];
    
    for (let i = 0; i < code.length; i++) {
        if (code[i] && check(code[i], isActive[i])) {
            switch (businessLine[i]) {
                case "electronics":
                    groups[0].push(code[i]);
                    break;
                case "grocery":
                    groups[1].push(code[i]);
                    break;
                case "pharmacy":
                    groups[2].push(code[i]);
                    break;
                case "restaurant":
                    groups[3].push(code[i]);
                    break;
            }
        }
    }
    
    for (let group of groups) {
        group.sort();
        ans.push(...group);
    }
    
    return ans;
};

const check = (code, isActive) => {
    for (let char of code) {
        if (char !== '_' && !(/[a-zA-Z0-9]/).test(char)) {
            return false;
        }
    }
    return isActive;
}
```

```TypeScript
function validateCoupons(code: string[], businessLine: string[], isActive: boolean[]): string[] {
    const groups: string[][] = [[], [], [], []];
    const ans: string[] = [];
    
    for (let i = 0; i < code.length; i++) {
        if (code[i] && check(code[i], isActive[i])) {
            switch (businessLine[i]) {
                case "electronics":
                    groups[0].push(code[i]);
                    break;
                case "grocery":
                    groups[1].push(code[i]);
                    break;
                case "pharmacy":
                    groups[2].push(code[i]);
                    break;
                case "restaurant":
                    groups[3].push(code[i]);
                    break;
            }
        }
    }
    
    for (let group of groups) {
        group.sort();
        ans.push(...group);
    }
    
    return ans;
}

function check(code: string, isActive: boolean): boolean {
    for (let char of code) {
        if (char !== '_' && !(/[a-zA-Z0-9]/).test(char)) {
            return false;
        }
    }
    return isActive;
}

```

```Rust
impl Solution {
    pub fn check(code: &str, is_active: bool) -> bool {
        for c in code.chars() {
            if c != '_' && !c.is_ascii_alphanumeric() {
                return false;
            }
        }
        is_active
    }

    pub fn validate_coupons(
        code: Vec<String>,
        business_line: Vec<String>,
        is_active: Vec<bool>,
    ) -> Vec<String> {
        let mut groups: Vec<Vec<String>> = vec![vec![], vec![], vec![], vec![]];
        let mut ans: Vec<String> = Vec::new();
        
        for i in 0..code.len() {
            if !code[i].is_empty() && Self::check(&code[i], is_active[i]) {
                match business_line[i].as_str() {
                    "electronics" => groups[0].push(code[i].clone()),
                    "grocery" => groups[1].push(code[i].clone()),
                    "pharmacy" => groups[2].push(code[i].clone()),
                    "restaurant" => groups[3].push(code[i].clone()),
                    _ => {}
                }
            }
        }
        
        for group in groups.iter_mut() {
            group.sort();
            ans.extend(group.clone());
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nL\log n)$，其中 $n$ 为 $code$ 的长度，$L$ 为 $code[i]$ 的平均长度，若 $L$ 较小，则化简为 $O(n\log n)$，复杂度主要在排序上。
- 空间复杂度：$O(nL)$，其中 $n$ 为 $code$ 的长度，$L$ 为 $code[i]$ 的平均长度。
