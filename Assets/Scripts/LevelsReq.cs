using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsReq
{
    public string Name;
    public int Points;

    public LevelsReq(string name, int points)
    {
        Name = name;
        Points = points;
    }
}
