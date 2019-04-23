using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript
{
    public List<int[]> Neightboors;
    public int x;
    public int y;


    public RoomScript()
    {
        Neightboors = new List<int[]>();
    }

    public bool IsTop()
    {
        foreach(int[] a in Neightboors)
        {
            if (a[1] > y)
                return true;
        }
        return false;
    }

    public bool IsBot()
    {
        foreach (int[] a in Neightboors)
        {
            if (a[1] < y)
                return true;
        }
        return false;
    }

    public bool IsLeft()
    {
        foreach (int[] a in Neightboors)
        {
            if (a[0] < x)
                return true;
        }
        return false;
    }

    public bool IsRight()
    {
        foreach (int[] a in Neightboors)
        {
            if (a[0] > x)
                return true;
        }
        return false;
    }
}

