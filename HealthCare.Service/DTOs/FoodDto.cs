using HealthCare.Domain.Entities;

namespace HealthCare.Service.DTOs;

public class FoodDto
{
    public string FoodName { get; set; }
    public ushort Gram { get; set;}  
    public ushort Caloria { get; set;}
    public static explicit operator FoodDto(FoodPower food)
    {
        return new FoodDto
        {
            FoodName = food.FoodName,
            Gram = food.Gram,
            Caloria = food.Caloria
        };
    }
}
