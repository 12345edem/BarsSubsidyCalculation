using System;

namespace SubsidyCalculation
{
    ///<summary>
    ///Тестовый прогон начисления тарифа
    ///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод данных тарифа
            var tariff1 = new Tariff();
            tariff1.ServiceId = 1;
            tariff1.HouseId = 1;
            tariff1.PeriodBegin = new DateTime(2021, 3, 29);
            tariff1.PeriodEnd = new DateTime(2021, 5, 29);
            tariff1.Value = 500;

            //Ввод данных по использованному объему
            var volume1 = new Volume();
            volume1.ServiceId = 1;
            volume1.HouseId = 1;
            volume1.Month = new DateTime(2021, 5, 29);
            volume1.Value = 100;

            //Расчет субсидии
            var subCalcs = new SubsidyCalculation();
            subCalcs.OnNotify += DisplayMessage;
            subCalcs.OnException += DisplayMessage;
            
            var chargeResult = subCalcs.CalculateSubsidy(volume1, tariff1);
            Console.WriteLine(chargeResult.Value);
        }
        ///<summary>
        ///Метод для вывода события OnNotify в консоль
        ///</summary>
        public static void DisplayMessage(object sender, string notify)
        {
            Console.WriteLine(notify);
        }
        ///<summary>
        ///Метод для вывода события OnExeption в консоль
        ///</summary>
        public static void DisplayMessage(object sender, Tuple<string, Exception> error)
        {
            Console.WriteLine(error);
        }
    }
}
