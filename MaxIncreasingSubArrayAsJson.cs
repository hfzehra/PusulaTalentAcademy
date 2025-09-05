using System.Text.Json;

namespace MaxIncreasingSubarray
{
    internal class MaxIncreasingSubArrayAsJson
    {
        public static string MaxIncreasingSubArrayAsJsonFunc(List<int> numbers)
        {
           if (numbers == null || numbers.Count == 0)
               return "[]";
        
           List<int> maxSub = new List<int>();
           int maxSum = int.MinValue;
            
           List<int> currentSub = new List<int> { numbers[0] };
           int currentSum = numbers[0];
            
           for (int i = 1; i < numbers.Count; i++)
           {
               if (numbers[i] > numbers[i - 1])
               {
                   currentSub.Add(numbers[i]);
                   currentSum += numbers[i];
               }
               else
               {
                   if (currentSum > maxSum)
                   {
                       maxSum = currentSum;
                       maxSub = new List<int>(currentSub);
                   }
                   currentSub = new List<int> { numbers[i] };
                   currentSum = numbers[i];
               }
           }
            
           if (currentSum> maxSum)
               maxSub = currentSub;
           
           return JsonSerializer.Serialize(maxSub);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MaxIncreasingSubArrayAsJsonFunc(new List<int> { 1, 2, 3, 1, 2 }));
            Console.WriteLine("-----------");
            Console.WriteLine(MaxIncreasingSubArrayAsJsonFunc(new List<int> { 2, 5, 4, 3, 2, 1 }));
            Console.WriteLine("-----------");
            Console.WriteLine(MaxIncreasingSubArrayAsJsonFunc(new List<int> { 1, 2, 2, 3 }));
            Console.WriteLine("-----------");
            Console.WriteLine(MaxIncreasingSubArrayAsJsonFunc(new List<int> { 1, 3, 5, 4, 7, 8, 2 }));
            Console.WriteLine("-----------");
            Console.WriteLine(MaxIncreasingSubArrayAsJsonFunc(new List<int> { })); 

        }
    }
}

