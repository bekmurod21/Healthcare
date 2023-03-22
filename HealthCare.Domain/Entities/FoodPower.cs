using HealthCare.Domain.Commons;

namespace HealthCare.Domain.Entities
{
    public class FoodPower:Auditable
    {
        public string FoodName { get; set; }
        public ushort Gram { get; set; }
        public ushort Caloria { get; set; }
    }
}
