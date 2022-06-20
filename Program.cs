using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{

    public static class DeepCopyStatic
    {
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
    public class Program
    {
        static Dictionary<int,int> cacheFib = new Dictionary<int, int>();
        static Dictionary<(int,int),int> cacheGridTraversal = new Dictionary<(int,int), int>();
        static Dictionary<int,bool> cacheCanSum = new Dictionary<int, bool>();
        static Dictionary<int,List<int>> cacheHowSum = new Dictionary<int, List<int>>();
        static Dictionary<int,List<int>> cacheBestSum = new Dictionary<int, List<int>>();
        static Dictionary<int,int> cacheCountSum = new Dictionary<int, int>();
        static Dictionary<int,List<List<int>>> cacheAllSum = new Dictionary<int, List<List<int>>>();
        static Dictionary<string,bool> cacheCanConstruct = new Dictionary<string, bool>();
        static Dictionary<string,int> cacheCountConstruct = new Dictionary<string, int>();
        static Dictionary<string, List<List<string>>> cacheAllConstruct = new Dictionary<string, List<List<string>>>();

        static void Main(string[] args)
        {
            #region Recursion
            //Fib(40);
            //GridTraversal(20, 20);
            //CanSum(7, new List<int>() { 5,3,4,7});
            //CanSum(7, new List<int>() { 2,4});
            //CanSum(300, new List<int>() { 7,14});
            //HowSum(8, new List<int>() { 2,3,5});
            //HowSum(8, new List<int>() { 3, 5, 2 });
            //HowSum(7, new List<int>() { 2, 4});
            //HowSum(300, new List<int>() { 7, 14 });
            //BestSum(8, new List<int>() { 2, 3, 5 });
            //BestSum(8, new List<int>() { 3, 5, 2 });
            //BestSum(7, new List<int>() { 2, 4 });
            //BestSum(300, new List<int>() { 7, 14 });
            //CountSum(8, new List<int>() { 2, 3, 5 });
            //CountSum(8, new List<int>() { 3, 5, 2 });
            //CountSum(7, new List<int>() { 2, 4 });
            //CountSum(300, new List<int>() { 7, 14 });
            //AllSum(8, new List<int>() { 2, 3, 5 });
            AllSum(40, new List<int>() { 2,3,5 });
            //AllSum(7, new List<int>() { 2, 4 });
            //AllSum(300, new List<int>() { 7, 14 });
            //canConstruct("abcdef", new List<string>() { "ab","abc","cd","def","abcd"});
            //canConstruct("skateboard", new List<string>() { "bo","rd","ate","t","ska","sk","boar"});
            //canConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", 
            //    new List<string>() { "eeeee","eeeeeee","eeeeeeee","eeeeeeeeeee","eeeeeeeeeeee","eeeeeeeeeeeeee","eeeeeeeeeeeeee"});
            //CountConstruct("abcdef", new List<string>() { "ab", "abc", "cd", "def", "abcd" });
            //CountConstruct("enterapotentpot", new List<string>() { "a", "p", "ent", "enter", "ot","o","t" });
            //CountConstruct("skateboard", new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" });
            //CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //    new List<string>() { "eeeee", "eeeeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeee", "eeeeeeeeeeeeee", "eeeeeeeeeeeeee" });
            //AllConstruct("abcdef", new List<string>() { "ab", "abc", "cd", "def", "abcd" });
            //AllConstruct("enterapotentpot", new List<string>() { "a", "p", "ent", "enter", "ot","o","t" });
            //AllConstruct("skateboard", new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" });
            //AllConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //    new List<string>() { "eeeee", "eeeeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeee", "eeeeeeeeeeeeee", "eeeeeeeeeeeeee" });

            #endregion
            #region Tabulation
            ///Visualize thử trên dạng bảng
            ///Size của bảng dựa trên input
            ///Khởi tạo giá trị bảng với giá trị mặc định
            ///Seed câu trả lời tầm thường vào bảng
            ///Duyệt bảng
            //FibTab(50);
            //GridTraversalTab(3, 3);
            //CanSumTab(8, new List<int>() { 2, 3, 5 });
            //CanSumTab(7, new List<int>() { 5, 3, 4 });
            //CanSumTab(300, new List<int>() { 7,14});
            //HowSumTab(8, new List<int>() { 2, 3, 5 });
            //HowSumTab(7, new List<int>() { 5, 3, 4 });
            //HowSumTab(7, new List<int>() { 5, 3, 4 });
            //BestSumTab(7, new List<int>() { 5, 3, 4 });
            //AllSumTab(8, new List<int>() { 2, 3, 5 });
            //AllSumTab(40, new List<int>() { 2, 3, 5 });
            CountSumTab(40, new List<int>() { 2, 3, 5 });

            //canConstructTab("abcdef", new List<string>() { "ab","abc","cd","def","abcd"});
            //canConstructTab("skateboard", new List<string>() { "bo","rd","ate","t","ska","sk","boar"});
            //canConstructTab("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", 
            //    new List<string>() { "eeeee","eeeeeee","eeeeeeee","eeeeeeeeeee","eeeeeeeeeeee","eeeeeeeeeeeeee","eeeeeeeeeeeeee"});
            //CountConstructTab("abcdef", new List<string>() { "ab", "abc", "cd", "def", "abcd" });
            //CountConstructTab("skateboard", new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" });
            //CountConstructTab("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //    new List<string>() { "eeeee", "eeeeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeee", "eeeeeeeeeeeeee", "eeeeeeeeeeeeee" });
            //CountConstructTab("enterapotentpot", new List<string>() { "a", "p", "ent", "enter", "ot","o","t" });

            //AllConstructTab("abcdef", new List<string>() { "ab", "abc", "cd", "def", "abcd" });
            //AllConstructTab("skateboard", new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" });
            //AllConstructTab("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //    new List<string>() { "eeeee", "eeeeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeee", "eeeeeeeeeeeeee", "eeeeeeeeeeeeee" });
            //AllConstructTab("enterapotentpot", new List<string>() { "a", "p", "ent", "enter", "ot", "o", "t" });
            Console.WriteLine();
            #endregion
        }

        private static int CountSumTab(int value, List<int> list)
        {
            var table = new List<int>();
            for (int i = 0; i < value + 1; i++)
            {
                table.Add(0);
            }

            table[0] = 1;

            for (int i = 0; i < table.Count; i++)
            {
                foreach (var number in list)
                {
                    if (i + number < table.Count)
                    {
                        table[i + number] += table[i];
                    }
                }
            }
            return table[table.Count - 1];
        }

        private static List<List<int>> AllSumTab(int value, List<int> list)
        {
            var table = new List<List<List<int>>>();

            for (int i = 0; i < value + 1; i++)
            {
                table.Add(new List<List<int>>());
            }

            table[0].Add(new List<int>());

            for (int i = 0; i < table.Count; i++)
            {
                foreach (var number in list)
                {
                    var currentIndex = i + number;
                    if (currentIndex < table.Count)
                    {
                        var currentIndexListTable = table[i].DeepClone();
                        currentIndexListTable.ForEach(x =>
                        {
                            x.Add(number);
                        });
                        table[currentIndex].AddRange(currentIndexListTable);
                    }
                }
            }
            return table[table.Count - 1];
        }

        private static List<List<string>> AllConstructTab(string value, List<string> list)
        {
            var table = new List<List<List<string>>>();
            for (int i = 0; i < value.Length + 1; i++)
            {
                table.Add(new List<List<string>>());
            }

            table[0].Add(new List<string>());

            for (int i = 0; i < table.Count; i++)
            {
                foreach (var word in list)
                {
                    if (i + word.Length < table.Count)
                    {
                        var subString = value.Substring(i, word.Length);
                        if (subString == word)
                        {
                            var currentIndexList = table[i].DeepClone();
                            currentIndexList.ForEach(x =>
                            {
                                x.Add(word);
                            });
                            table[i + word.Length].AddRange(currentIndexList);
                        }
                    }
                }
            }
            return table[table.Count - 1];
        }

        private static int CountConstructTab(string value, List<string> list)
        {
            var table = new List<int>();

            for (int i = 0; i < value.Length + 1; i++)
            {
                table.Add(0);
            }

            table[0] = 1;

            for (int i = 0; i < table.Count; i++)
            {
                foreach (var word in list)
                {
                    if (i + word.Length < table.Count)
                    {
                        string subString = value.Substring(i, word.Length);
                        if (subString == word)
                        {
                            table[i + word.Length] += table[i];
                        }
                    }
                }
            }

            return table[table.Count - 1];
        }

        private static bool canConstructTab(string value, List<string> list)
        {
            var table = new List<bool>(value.Length + 1);
            for (int i = 0; i < value.Length + 1; i++)
            {
                table.Add(false);
            }

            table[0] = true;

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i] == true)
                {
                    foreach (var word in list)
                    {
                        if (i + word.Length < table.Count)
                        {
                            var subString = value.Substring(i, word.Length);
                            if (subString == word)
                            {
                                table[i + word.Length] = true;
                            }
                        }
                    }
                }
            }
            return table[table.Count - 1];
        }

        private static List<int> BestSumTab(int value, List<int> list)
        {
            //Initial table
            var table = new List<List<int>>();
            for (int i = 0; i < value + 1; i++)
            {
                table.Add(null);
            }

            //Initial Value
            table[0] = new List<int>();

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i] != null)
                {
                    foreach (var number in list)
                    {
                        var currentIndex = i + number;
                        //Chống OutOfRange
                        if (currentIndex < table.Count)
                        {
                            if (table[currentIndex] == null)
                            {
                                table[currentIndex] = table[i].DeepClone();
                                table[currentIndex].Add(number);
                            }
                            //Tất cả các mảng null sẽ được gán trước khi check
                            //Kiểm tra bằng nhau thì không gán --> gán ==> Dài hơn
                            else if (table[currentIndex].Count != table[i].Count)
                            {
                                table[currentIndex] = table[i].DeepClone();
                                table[currentIndex].Add(number);
                            }
                        }
                    }
                }
            }
            return table[table.Count - 1];
        }

        /// <summary>
        /// Dựa vào tính chất có thể tái tạo được index cuối cùng
        /// </summary>
        /// <param name="value"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<int> HowSumTab(int value, List<int> list)
        {
            //Initial table 
            var table = new List<List<int>>();
            for (int i = 0; i < value + 1; i++)
            {
                table.Add(null);
            }
            //Initial default value
            table[0] = new List<int>();

            for (int i = 0; i < table.Count; i++)
            {
                if (table[i] != null)
                {
                    foreach (var number in list) if (i + number < table.Count)
                    {
                        table[i + number] = table[i].DeepClone();
                        table[i + number].Add(number);
                    }
                }
            }
            return table[table.Count - 1];
        }

        /// <summary>
        /// Dựa vào tính chất của index mảng
        /// Vì index = 0 ban đầu luôn có thể phân chia hết cho các số 3,4,5 --> True
        /// Khi xét đến 3,4,5 thì nó có thể cấu tạo được số 6,7,8           --> True
        /// Lấy kết quả cuối cùng của array 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool CanSumTab(int value, List<int> list)
        {
            //Initial cache table 
            var table = new bool[value + 1];
            //Initial default value tab
            for (int i = 0; i < value + 1; i++)
            {
                table[i] = false;
            }
            //Initial value
            table[0] = true;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == true)
                {
                    foreach (var number in list) if (i + number < table.Length)
                    {
                        //Xét vị trí có thể cấu tạo thành số 7 hay không ?
                        table[i + number] = true;
                    }
                }
            }
            return table[value];
        }
        /// <summary>
        /// Vì nó là 2 tham số chạy giảm dần
        /// Cần mảng 2 chiều để biểu diễn
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int GridTraversalTab(int m, int n)
        {
            //Tạo matrix có m + 1 hàng, n + 1 cột
            var matrix = new int[m + 1,n + 1];
            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    matrix[i,j] = 0;
                }
            }

            //Setup initial value
            matrix[1,1] = 1;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    var currentVal = matrix[i,j];
                    //Chặn cột
                    if (j + 1 <= n)
                    {
                        matrix[i, j + 1] += currentVal;
                    }
                    //Chặn hàng
                    if (i + 1 <= m)
                    {
                        matrix[i + 1, j] += currentVal;
                    }
                }
            }

            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            return matrix[m, n];
        }
        /// <summary>
        /// Cần xem xét lại công thức Fibonacy 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int FibTab(int value)
        {
            //Xây dựng array full 0 gồm value.lenght phần tử
            //Để tiến hành cache phần tử phía trước cho current value
            //Tạo table gồm n + 1 phần tử
            var table = new List<int>(value + 1);
            //Seed 0 vào table
            for (int i = 0; i < value + 1; i++)
            {
                table.Add(0);
            }
            //Khởi tạo giá trị <==> điều kiện dừng trong Recursion
            table[1] = 1;
            for (int i = 0; i <value; i++)
            {
                //Tính chất của Fib
                //Số hiện tại bằng 2 số trước cộng lại
                table[i+1] += table[i];
                //Cẩn thận OutOfRange
                //Khi chưa đến cuối
                if (i + 2 != value + 1)
                {
                    table[i + 2] += table[i];
                }
            }
            return table[value];
        }

        private static List<List<string>> AllConstruct(string inputString, List<string> list)
        {
            if (cacheAllConstruct.ContainsKey(inputString))
            {
                return cacheAllConstruct[inputString];
            }
            if (string.IsNullOrEmpty(inputString))
            {
                return new List<List<string>>()
                {
                    new List<string>()
                };
            }
            
            var currentMatrix = new List<List<string>>();

            foreach (var word in list)
            {
                if (inputString.IndexOf(word) == 0)
                {
                    var subString = inputString.Substring(word.Length);
                    var subMatrix = AllConstruct(subString, list);

                    foreach (var subItem in subMatrix)
                    {
                        subItem.Insert(0,word);
                    }

                    currentMatrix.AddRange(subMatrix);
                }
            }

            cacheAllConstruct[inputString] = currentMatrix;
            return currentMatrix;
        }

        private static int CountConstruct(string inputString, List<string> list)
        {
            if (cacheCountConstruct.ContainsKey(inputString))
            {
                return cacheCountConstruct[inputString];
            }
            if (string.IsNullOrEmpty(inputString))
            {
                return 1;
            }
            var currentCount = 0;

            foreach (var word in list)
            {
                if (inputString.IndexOf(word) == 0)
                {
                    var subString = inputString.Substring(word.Length);
                    var subCount = CountConstruct(subString, list);
                    currentCount += subCount;
                }
            }

            cacheCountConstruct[inputString] = currentCount;
            return currentCount;
        }

        private static bool canConstruct(string inputString, List<string> list)
        {
            if (cacheCanConstruct.ContainsKey(inputString))
            {
                return cacheCanConstruct[inputString];
            }
            if (string.IsNullOrEmpty(inputString))
            {
                return true;
            }

            //Vét cạn đến khi nào thấy thì thôi --> while ???
            foreach (var word in list)
            {
                //Kiem tra co phai chuoi bat dau khong ?
                if (inputString.IndexOf(word) == 0)
                {
                    var subString = inputString.Substring(word.Length);
                    bool constructed = canConstruct(subString, list);
                    if (constructed)
                    {
                        cacheCanConstruct[inputString] = true;
                        return true;
                    }
                }
            }
            cacheCanConstruct[inputString] = false;
            return false;
        }

        private static List<List<int>> AllSum(int value, List<int> list)
        {
            if (cacheAllSum.ContainsKey(value))
            {
                return cacheAllSum[value].DeepClone();
            }
            //Nếu value đã được trừ hết
            if (value == 0)
            {
                //Trả về list 2 chiều có 1 list sẵn
                return new List<List<int>>()
                {
                    new List<int>()
                };
            }
            else if (value < 0)
            {
                //Trả về list không có gì
                return new List<List<int>>();
            }

            //Khai báo result hiện tại
            var currentMatrix = new List<List<int>>();

            foreach (var item in list)
            {
                var remainder = value - item;
                var subMatrix = AllSum(remainder,  list);

                //Với mỗi node con của current node hiện tại
                subMatrix.ForEach(subItem =>
                {
                    //Thêm vào node con để hoàn thành parent node
                    subItem.Insert(0, item);
                });

                //Mỗi lần chạy for sẽ có 1 cái mảng 2 chiều có 1 item
                //Mỗi mảng là 1 item, cho nên dễ nhầm
                currentMatrix.AddRange(subMatrix);
            }

            cacheAllSum[value] = currentMatrix;
            return currentMatrix;
        }

        private static int CountSum(int value, List<int> list)
        {
            if (cacheCountSum.ContainsKey(value))
            {
                return cacheCountSum[value];
            }
            if (value == 0)
            {
                return 1;
            }else if (value < 1)
            {
                return 0;
            }
            var currentCount = 0;
            foreach (var item in list)
            {
                var remainder = value - item;
                var subCount = CountSum(remainder, list);
                currentCount += subCount;
            }
            
            cacheCountSum[value] = currentCount;
            return currentCount;
        }

        private static List<int> BestSum(int value, List<int> list)
        {
            if (cacheBestSum.ContainsKey(value))
            {
                if (cacheBestSum[value] == null)
                {
                    return null;
                }
                return cacheBestSum[value].DeepClone();
            }
            if (value == 0)
            {
                cacheBestSum[value] = new List<int>();
                return new List<int>();
            }
            else if (value < 0)
            {
                cacheBestSum[value] = null;
                return null;
            }
            List<int> bestCurrentList = null;

            foreach (var item in list)
            {
                var remainder = value - item;
                var subList = BestSum(remainder, list);
                if (subList != null)
                {
                    subList.Insert(0, item);
                    if (bestCurrentList == null || subList.Count < bestCurrentList.Count)
                    {
                        bestCurrentList = subList;
                    }
                }
            }

            cacheBestSum[value] = bestCurrentList;
            return bestCurrentList;

        }

        private static List<int> HowSum(int value, List<int> list)
        {
            if (cacheHowSum.ContainsKey(value))
            {
                if (cacheHowSum[value] == null)
                {
                    return null;
                }
                else
                {
                    return cacheHowSum[value].DeepClone();
                }
            }
            if (value == 0)
            {
                cacheHowSum[value] = new List<int>();
                return new List<int>();
            }
            else if (value < 0)
            {
                cacheHowSum[value] = null;
                return null;
            }
            foreach (var item in list)
            {
                var remainder = value - item;
                var subResult = HowSum(remainder, list);
                if (subResult != null)
                {
                    subResult.Insert(0, item);
                    cacheHowSum[value] = subResult;
                    return subResult;
                }
            }

            cacheHowSum[value] = null;
            return null;
        }

        private static bool CanSum(int value, List<int> list)
        {
            if (cacheCanSum.ContainsKey(value))
            {
                return cacheCanSum[value];
            }
            if (value == 0)
            {
                cacheCanSum.Add(value, true);
                return true;
            }
            else if (value < 0)
            {
                cacheCanSum.Add(value, false);
                return false;
            }

            foreach (var item in list)
            {
                var remainder = value - item;
                var subResult = CanSum(remainder, list);
                if (subResult)
                {
                    cacheCanSum.Add(value, true);
                    return true;
                }
            }
            cacheCanSum.Add(value, false);
            return false;
        }

        private static int GridTraversal(int m, int n)
        {
            if (cacheGridTraversal.ContainsKey((m,n)))
            {
                return cacheGridTraversal[(m, n)];
            }
            if(m == 1 && n == 1)
            {
                cacheGridTraversal[(m, n)] = 1;
                return 1;
            }
            if (m == 0 || n == 0)
            {
                cacheGridTraversal[(m, n)] = 0;
                return 0;
            }

            int subGrid = GridTraversal(m - 1, n) + GridTraversal(m, n - 1);
            cacheGridTraversal[(m, n)] = subGrid;
            return subGrid;
        }

        private static int Fib(int value)
        {
            if (cacheFib.ContainsKey(value))
            {
                return cacheFib[value];
            }
            if (value <= 2)
            {
                cacheFib.Add(value, 1);
                return 1;
            }
            int subResult = Fib(value - 1) + Fib(value - 2);

            cacheFib.Add(value, subResult);
            
            return subResult;
        }
    }
}
