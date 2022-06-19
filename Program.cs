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
            //AllSum(8, new List<int>() { 3, 5, 2 });
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
            
            Console.WriteLine("OK");
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
