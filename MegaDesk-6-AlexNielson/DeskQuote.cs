using System;

public class DeskQuote
{
    /*************************
    * Create Class Variables * 
    *************************/
    public const int BASE_PRICE = 200;
    public int SurfaceAreaPrice;
    public int DrawerPrice;
    public int SurfaceMaterialPrice;
    public int RushOrderPrice;
    public int TotalPrice;

    public DeskQuote()
    {
        // No constructor method
    }

    /*************************
    * Create Class Methods   * 
    *************************/
    // Calculate the surface area price based off the Desk object's width and depth
    public void GetSurfaceAreaPrice(int Width, int Depth)
    {
        int SurfaceArea = Width * Depth;

        if (SurfaceArea > 1000)
        {
            SurfaceAreaPrice = BASE_PRICE + (SurfaceArea * 1);
        }
        else
        {
            SurfaceAreaPrice = BASE_PRICE;
        }
    }

    // Calculate the desk drawer price based off the Desk object's number of drawers
    public void GetDrawerPrice(int NoOfDrawers)
    {
        DrawerPrice = NoOfDrawers * 50;
    }

    // Calculate the surface material price based off the Desk object's surface material
    public void GetSurfaceMaterialPrice(Desk.SurfaceMaterial Material)
    {
        switch (Material)
        {
            case Desk.SurfaceMaterial.Oak:
                SurfaceMaterialPrice = 200;
                break;
            case Desk.SurfaceMaterial.Laminate:
                SurfaceMaterialPrice = 100;
                break;
            case Desk.SurfaceMaterial.Pine:
                SurfaceMaterialPrice = 50;
                break;
            case Desk.SurfaceMaterial.Rosewood:
                SurfaceMaterialPrice = 300;
                break;
            case Desk.SurfaceMaterial.Veneer:
                SurfaceMaterialPrice = 125;
                break;
            default:
                SurfaceMaterialPrice = 0;
                break;
        }
    }

    // Calculate the rush order price based off the Desk object's width, depth, and number of rush order days
    public void GetRushOrderPrice(Desk.RushOrderDays Days, int Width, int Depth)
    {
        int SurfaceArea = Width * Depth;
        switch (Days)
        {
            case Desk.RushOrderDays.None:
                RushOrderPrice = 0;
                break;
            case Desk.RushOrderDays.Three:
                if (SurfaceArea < 1000)
                {
                    RushOrderPrice = 60;
                }
                else if (SurfaceArea > 1000 && SurfaceArea < 2000)
                {
                    RushOrderPrice = 70;
                }
                else
                {
                    RushOrderPrice = 80;
                }
                break;
            case Desk.RushOrderDays.Five:
                if (SurfaceArea < 1000)
                {
                    RushOrderPrice = 40;
                }
                else if (SurfaceArea > 1000 && SurfaceArea < 2000)
                {
                    RushOrderPrice = 50;
                }
                else
                {
                    RushOrderPrice = 60;
                }
                break;
            case Desk.RushOrderDays.Seven:
                if (SurfaceArea < 1000)
                {
                    RushOrderPrice = 30;
                }
                else if (SurfaceArea > 1000 && SurfaceArea < 2000)
                {
                    RushOrderPrice = 35;
                }
                else
                {
                    RushOrderPrice = 40;
                }
                break;
            default:
                RushOrderPrice = 0;
                break;
        }
    }

    // Calculate the total price
    public int GetTotalPrice(int BasePrice, int SurfaceAreaPrice, int DrawerPrice, int SurfaceMaterialPrice, int RushOrderPrice)
    {
        return BasePrice + SurfaceAreaPrice + DrawerPrice + SurfaceMaterialPrice + RushOrderPrice;
    }
}
