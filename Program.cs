using System;

namespace checkDigit2
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            string[] ok_tests = {
            "1",
            "10",
            "100",
            "1000",
            "10000",
            "100000",
            "100000.",
            "1000000",
            "1000000.",
            "0.1",
            "0.01",
            "0.001",
            "0.0001",
            "0.00001",
            ".9",
            ".99",
            ".999",
            ".9999",
            ".99999",
            ".999999",
            "9",
            "9.9",
            "9.99",
            "9.999",
            "9.9999",
            "9.99999",
            "99.",
            "99.9",
            "99.99",
            "99.999",
            "99.9999",
            "999.",
            "999.9",
            "999.99",
            "999.999",
            "9999.",
            "9999.9",
            "9999.99",
            "99999.9",
            "999999.",
            "9999999",
            "9999999.",
            };

            string[] err_tests = {
            "10000000.1111",
            "0.1234567890",
            "90.123456789",
            "890.123456789",
            "7890.123456789",
            "67890.123456789",
            "567890.123456789",
            "4567890.123456789",
            "34567890.123456789",
            "234567890.123456789",
            "1234567890.123456789",
            "0.0000001",
            "0.0000005",
            "0.00000015",
            "0.0000001",
            "999999.99",
            "99999.99",
            "9999.999",
            "999.9999",
            "99.99999",
            "9.999999",
            "12345678",
            "00.0012345",
            "99999999.99",
            "9999999.999",
            "999999.9999",
            "99999.99999",
            "999999999.99",
            "90000001.999",
            "90000001.9999",
            "90000001.99999",
            "90000001.999999",
            "90000001.9999999",
            };

            //Console.WriteLine("--- OK --");
            //foreach (var item in ok_tests)
            //{
            //    Console.WriteLine(Format7strKIRISUTE(item));
            //}
            Console.WriteLine("--- NG --");
            foreach (var item in err_tests)
            {
                Console.WriteLine(Format7strKIRISUTE(item));
            }
        }

        private static string Format7strKIRISUTE(string str)
        {
            // 前の０を吹き飛ばす
            double val = double.Parse(str);
            // 上位桁切り捨て
            if (val >= 1000000)
            {
                val %= 10000000;
            }
            else
            {
                val %= 1000000;
            }
            // ７文字化
            string str2 = Format7str2(val.ToString("0.#########"));
            val = double.Parse(str2);
            // 上位桁切り捨て 繰り上がりが発生した場合の対応
            if (val >= 1000000)
            {
                val %= 10000000;
            }
            else
            {
                val %= 1000000;
            }
            str2 = Format7str2(val.ToString("0.#########"));
            int pos = str2.IndexOf(".", 0);
            if (pos == -1 && str2.Length <= 6)
            {
                str2 += ".";
            }
            return str2;
        }

        private static string Format7str(string str)
        {
            int pos = str.IndexOf(".", 0);
            // 小数点でフォーマットを決めるので一の位の直後に点を置く
            if (pos == -1)
            {
                str += ".";
                pos = str.IndexOf(".", 0);
            }

            double val = double.Parse(str);
            // 小数点の位置でフォーマットを決定
            if (pos == 1) // 1.00000
            {
                val = Math.Round(val, 5, MidpointRounding.AwayFromZero);
                str = string.Format("{0:0.00000}", val);
            }
            else if (pos == 2) // 10.0000
            {
                val = Math.Round(val, 4, MidpointRounding.AwayFromZero);
                str = string.Format("{0:0.0000}", val);
            }
            else if (pos == 3) // 100.000
            {
                val = Math.Round(val, 3, MidpointRounding.AwayFromZero);
                str = string.Format("{0:0.000}", val);
            }
            else if (pos == 4) // 1000.00
            {
                val = Math.Round(val, 2, MidpointRounding.AwayFromZero);
                str = string.Format("{0:0.00}", val);
            }
            else if (pos == 5) // 100000.0
            {
                val = Math.Round(val, 1, MidpointRounding.AwayFromZero);
                str = string.Format("{0:0.0}", val);
            }
            //else if (pos == 6) // 100000. or 10000000...
            else
            {
                val = Math.Round(val, 0, MidpointRounding.AwayFromZero);
                str = string.Format("{0:0}", val);
            }
            return str;
        }

        private static string Format7str2(string str)
        {
            int pos = str.IndexOf(".", 0);
            // 小数点でフォーマットを決めるので一の位の直後に点を置く
            if (pos == -1)
            {
                str += ".";
                pos = str.IndexOf(".", 0);
            }

            double val = double.Parse(str);
            // 小数点の位置でフォーマットを決定
            if (pos == 1) // 1.00000
            {
                str = string.Format("{0:0.00000}", val);
            }
            else if (pos == 2) // 10.0000
            {
                str = string.Format("{0:0.0000}", val);
            }
            else if (pos == 3) // 100.000
            {
                str = string.Format("{0:0.000}", val);
            }
            else if (pos == 4) // 1000.00
            {
                str = string.Format("{0:0.00}", val);
            }
            else if (pos == 5) // 100000.0
            {
                str = string.Format("{0:0.0}", val);
            }
            //else if (pos == 6) // 100000. or 10000000...
            else
            {
                str = string.Format("{0:0}", val);
            }
            return str;
        }
    }
}