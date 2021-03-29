using System;

namespace SubsidyCalculation
{
    ///<summary>
    ///Класс, реализующий расчет субсидии
    ///</summary>
    class SubsidyCalculation : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;
        ///<summary>
        ///Метод расчета субсидии
        ///</summary>
        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            OnNotify?.Invoke(this, "Расчет начат в " + DateTime.Now);

            if(volumes.HouseId != tariff.HouseId)
                InvalidInput(new Exception("House ID's does't match, code: 1"),
                                    "Идентификаторы домов не совпадают");

            if(volumes.ServiceId != tariff.ServiceId)
                InvalidInput(new Exception("Service ID's does't match, code: 2"),
                                    "Идентификаторы сервисов не совпадают");

            if(!(tariff.PeriodBegin.Month <= volumes.Month.Month && volumes.Month.Month <= tariff.PeriodEnd.Month))
            {
                InvalidInput(new Exception("discrepancy between the terms of using the volume and the tariff, code: 3"),
                                    "месяц объёма должен входить в период действия тарифа");
            }

            if(tariff.Value <= 0)
                InvalidInput(new Exception("Zero or negative tariff values ​​are not allowed, code: 4"),
                                    "Не допускается нулевых или отрицательных значений тарифа");

            if(volumes.Value < 0)
                InvalidInput(new Exception("Negative volume values ​​are not allowed, code: 5"),
                                    "Не допускается отрицательных значений объема");

            var charge = new Charge();
            try
            {
                charge.Value = volumes.Value * tariff.Value;
            }
            catch(Exception)
            {
                throw;
            }
            
            OnNotify?.Invoke(this, "Расчет успешно закончен в " + DateTime.Now);
            return charge;
        }
        ///<summary>
        ///Метод, вызываемый при передаче недопустимых данных в расчет, предусмторенных системой
        ///</summary>
        ///<remarks>
        ///Данный метод содержит вызов события OnExeption и проброс ошибки
        ///</remarks>
        public void InvalidInput(Exception e, string errorText)
        {
            OnException?.Invoke(this, Tuple.Create(errorText, e));
            throw e;
        }
    }
}