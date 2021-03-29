using System;

namespace SubsidyCalculation
{
    /// <summary>
    /// Начисление
    /// </summary>
    public class Charge
    {
        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public int ServiceId { get; set; }
        
        /// <summary>
        /// Идентификатор дома
        /// </summary>
        public int HouseId { get; set; }
        
        /// <summary>
        /// Месяц начисления
        /// </summary>
        public DateTime Month { get; set; }
        
        /// <summary>
        /// Значение начисления
        /// </summary>
        public decimal Value { get; set; }
    }
}