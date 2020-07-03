using System;

namespace _6
{
    class AArray:Test
    {
        public int summaryLenght { get; set; }

        public static Array Combine(params Array[] arrays)
         {

            int summaryLength = 0, index = 0;
            Type checkType = null;
            Array result = null;
            try
            {
                checkType = arrays[0].GetType().GetElementType();
                foreach (var array in arrays)
                {
                    if (array.GetType().GetElementType() != checkType) return null;
                    summaryLength += array.Length;
                }

                result = Array.CreateInstance(checkType, summaryLength);

                for (var i = 0; i < arrays.Length; i++)
                {
                    Array.Copy(arrays[i], 0, result, index, arrays[i].Length);
                    index += arrays[i].Length;
                }
            }
            catch { }
            return result;
        }
        public void Print() { Console.WriteLine("  WOW  "); }
    }

    public interface Test 
    {
      int summaryLenght { get; set; }
      void Print();
    }

        class Program:AArray
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };
            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }
        public static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0}", array.GetValue(i));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
