using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using static Session02Assignment.ListGenerator;
namespace Session02Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators
            // 1- Find all products that are out of stock.
            var OutOfStockProducts = ProductsList.Where(p => p.UnitsInStock == 0);
            foreach (var Product in OutOfStockProducts)
            {
                //Console.WriteLine(Product);
            }

            // 2- Find all products that are in stock and cost more than 3.00 per unit.
            var InStoackMoreThan3 = ProductsList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            foreach (var Product in InStoackMoreThan3)
            {
                //Console.WriteLine(Product);
            }

            // 3- Returns digits whose name is shorter than their value.
            String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = Arr.Where((name, index) => name.Length < index);
            foreach (var element in result)
            {
                //Console.WriteLine(element);
            }
            #endregion
            #region LINQ - Element Operators
            // 1. Get first Product out of Stock 
            var FirstProductOutOFStock = ProductsList.First(p => p.UnitsInStock == 0);
            //Console.WriteLine(FirstProductOutOFStock);

            // 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var FirstProdcutMorethan1000 = ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(FirstProdcutMorethan1000);

            // 3. Retrieve the second number greater than 5 
            int[] Arr03 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var SecondNumberGreaterThan5 = Arr03.Where(element => element > 5).ElementAtOrDefault(1);
            //Console.WriteLine(SecondNumberGreaterThan5);

            #endregion
            #region LINQ - Aggregate Operators
            // 1. Uses Count to get the number of odd numbers in the array
            int[] Arr02 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var OddNumber = Arr02.Count(element => element % 2 == 1);
            //Console.WriteLine(OddNumber);

            // 2. Return a list of customers and how many orders each has.
            var CustomersAndOrders = CustomersList.Select(orders => new {name = orders.CustomerName, NumberOfOrders = orders.Orders.Length });
            foreach (var c in CustomersAndOrders)
            {
                //Console.WriteLine(c);
            }

            // 3. Return a list of categories and how many products each has
            // TO DO

            // 4. Get the total of the numbers in an array.
            int[] Arr04 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var total = Arr04.Sum(element => element);
            //Console.WriteLine(total);

            // 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] dictionary_english = File.ReadAllLines("D:\\Programming\\Web\\backEnd\\Code\\LINQ\\Session02Solution\\Session02Assignment\\dictionary_english.txt");
            string[] dictionary_english2 = File.ReadAllLines("D:\\Programming\\Web\\backEnd\\Code\\LINQ\\Session02Solution\\Session02Assignment\\dictionary_english2.txt");
            var AllChars = dictionary_english.Select(word => word.Length).Sum();
            //Console.WriteLine(AllChars);

            // 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var shortestWord = dictionary_english.MinBy(word => word.Length)?.Length ?? 0;
            //Console.WriteLine(shortestWord);

            // 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var longestWord = dictionary_english.MaxBy(word => word.Length)?.Length ?? 0;
            //Console.WriteLine(longestWord);

            // 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var averageWord = dictionary_english.Average(word => word.Length);
            //Console.WriteLine(averageWord);

            

            #endregion
            #region LINQ - Ordering Operators
            // 1. Sort a list of products by name
            var SortedProducts = ProductsList.OrderBy(p => p.ProductName);
            foreach (var product in SortedProducts)
            {
                //Console.WriteLine(product);
            }

            // 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            String[] Arr05 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var SortedFruits = Arr05.OrderBy(fruit => fruit.ToLower());
            foreach (var fruit in SortedFruits)
            {
                //Console.WriteLine(fruit);
            }

            // 3. Sort a list of products by units in stock from highest to lowest.
            var SortedByUnitsInStock = ProductsList.OrderByDescending(p => p.UnitsInStock);
            foreach (var product in SortedByUnitsInStock)
            {
                //Console.WriteLine(product);
            }

            // 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            string[] Arr06 = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            ;
            var SortedByLengthThemAlphabetically = Arr06.OrderBy(e => e.Length).ThenBy(e => e);
            foreach (var e in SortedByLengthThemAlphabetically)
            {
                //Console.WriteLine(e);
            }

            // 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            String[] Arr07 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var SortedByLengthAndByCaseInsensitive = Arr07.OrderBy(fruit => fruit.Length).ThenBy(e => e.ToLower());
            foreach (var  fruit in SortedByLengthAndByCaseInsensitive)
            {
                //Console.WriteLine(fruit);
            }

            // 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var SortedProductsBycategoryAndUnitPrice = ProductsList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var p in SortedProductsBycategoryAndUnitPrice)
            {
                //Console.WriteLine(p);
            }

            // 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            String[] Arr08 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var SortedByLengthAndNames = Arr08.OrderBy(fruit => fruit.Length).ThenByDescending(fruit => fruit.ToLower());
            foreach (var fruit in SortedByLengthAndNames)
            {
                //Console.WriteLine(fruit);
            }

            // 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr09 = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            var SortedArr09 = Arr09.Where(element => element[1] == 'i' ).Reverse();

            foreach (var element in SortedArr09)
            {
                //Console.WriteLine(element);
            }

            #endregion
            #region LINQ – Transformation Operators
            // 1. Return a sequence of just the names of a list of products.
            var NamesOFTheProducts = ProductsList.Select(p => p.ProductName);
            foreach (var name in NamesOFTheProducts)
            {
                //Console.WriteLine(name);
            }

            // 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            String[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var UpperCase = words.Select(word => new {UpperCaseValue = $"{word.ToUpper()}", LowerCaseValue = $"{word.ToLower()}" });

            foreach (var word in UpperCase)
            {
                //Console.WriteLine(word);
            }

            // 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            var CustomizedProducts = ProductsList.Select(p => new { ProductName = p.ProductName, Price = p.UnitPrice });
            foreach (var product in CustomizedProducts)
            {
                //Console.WriteLine(product);
            }

            // 4. Determine if the value of int in an array matches their position in the array.
            int[] Arr10 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var NumberInPlace = Arr10.Select((number, index) => $"{number}: {number == index}");
            foreach (var number in NumberInPlace)
            {
                //Console.WriteLine(number);
            }

            // 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var Pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select $"{a}: is less than {b}";

            foreach (var p in Pairs)
            {
                //Console.WriteLine(p);
            }

            // 6. Select all orders where the order total is less than 500.00.
            var AllOrdersLess500 = CustomersList.SelectMany(p => p.Orders).Where(o => o.Total < 500);
            foreach (var order in AllOrdersLess500)
            {
                //Console.WriteLine(order);
            }

            // 7. Select all orders where the order was made in 1998 or later.
            var AllOrdersAfter1998 = CustomersList.SelectMany(p => p.Orders).Where(o => o.OrderDate >= new DateTime(1998, 1, 1));
            foreach (var order in AllOrdersAfter1998)
            {
                Console.WriteLine(order);
            }
            #endregion
        }
    }
}
