```java
class Solution {
    public boolean isPathCrossing(String path) {
        // 取巧的方法，由于path长度<= 10000, 所以随便取两个大于10000且互质的数来作为N、E的偏移量标记即可，这样的得到哈希值就不会冲突，出现相同的sum则路径交叉
        HashSet<Integer> set = new HashSet<>();
        set.add(0);
        int sum = 0;
        for(char c : path.toCharArray())
        {
            if(c == 'N') sum += 10003;
            else if(c == 'S') sum -= 10003;
            else if(c == 'E') sum += 10004;
            else sum -= 10004;
            if(!set.add(sum)) return true;
        }
        return false;
    }
}
```
