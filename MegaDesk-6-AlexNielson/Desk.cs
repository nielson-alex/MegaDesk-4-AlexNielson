using System;

public class Desk
{
    /*************************
    * Create Class Variables * 
    *************************/
    // Requirement 2
    public enum SurfaceMaterial
    {
        Laminate = 0,
        Oak = 1,
        Rosewood = 2,
        Veneer = 3,
        Pine = 4
    }

    public enum RushOrderDays
    {
        None = 14,
        Three = 3,
        Five = 5,
        Seven = 7
    }

    public const int MIN_WIDTH = 24;
    public const int MAX_WIDTH = 96;
    public const int MIN_DEPTH = 12;
    public const int MAX_DEPTH = 48;
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public int Width { get; set; }
    public int Depth { get; set; }
    public int NoOfDrawers { get; set; }
    public SurfaceMaterial Material { get; set; }
    public RushOrderDays Days { get; set; }

    public Desk()
    {
        // No constructor method
    }
}
