using System;

namespace tests_date_sae01
{
    class Program
    {
        static void Main(string[] args)
        {
            //'2022-06-10'
            DateTime test = new DateTime(2022,06,10);
            string ladate = "";
            Console.WriteLine(test.Year) ;
            Console.WriteLine(test.Month) ;
            Console.WriteLine(test.Day) ;
            ladate += test.Year.ToString()+'-';
            ladate += test.Month.ToString()+'-';
            ladate += test.Day.ToString();
            Console.WriteLine(ladate);
        }
    }
}
