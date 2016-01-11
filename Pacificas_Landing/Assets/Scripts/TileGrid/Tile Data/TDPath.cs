using UnityEngine;
using System.Collections;

public class TDPath
{
    public ArrayList path;
    public int staminaUsed;

    public TDPath(TDTile tile, int staminaCost)
    {
        path = new ArrayList();
        path.Add(tile);
        staminaUsed = staminaCost;
    }

    public TDPath(ArrayList path, int staminaUsed)
    {
        this.path = new ArrayList();
        for (int i = 0; i < path.Count; i++)
        {
            this.path.Add(path[i]);
        }
        this.staminaUsed = staminaUsed;
    }

    public void add(TDTile tile, int staminaCost)
    {
        path.Add(tile);
        staminaUsed += staminaCost;

    }


    public int getStaminaUsed()
    {
        return staminaUsed;
    }

    public ArrayList getPath()
    {
        return path;
    }

    override
    public string ToString()
    {
        string statement = "";
        for (int i = 0; i < path.Count; i++)
        {
            statement += path[i] + " ";
        }
        return statement + ": " + staminaUsed;
    }
}

