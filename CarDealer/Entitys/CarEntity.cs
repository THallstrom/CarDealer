using Microsoft.Identity.Client;
using System.Diagnostics;

namespace CarDealer.Entitys;

public class CarEntity
{
    public int Id { get; set; }

    public string RegNumber { get; set; } = null!;
    public bool IsSold { get; set; } = false;
    public string Milage { get; set; } = null!;
    public int ConditionId { get; set; }
    public ConditionEntity Condition { get; set; } = null!;
    public int MakerId { get; set; }
    public MakerEntity Maker { get; set; } = null!;
    public int ColorId { get; set; }
    public ColorEntity Color { get; set; } = null!;
    public int FuelId {  get; set; }
    public FuelEntity Fuel { get; set; } = null!;
    public int GearBoxId {  get; set; }
    public GearBoxEntity GearBox { get; set; } = null!;
    public int YearId { get; set; }
    public YearEntity Year { get; set; } = null!;
    public int ModelId { get; set; }
    public ModelEntity Model { get; set; } = null!;
}
