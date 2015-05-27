using UnityEngine;
using System.Collections;
using Global;

public class ItrTerminal : InteractiveObject
{
    public ItrDoor[] DoorsArray;

    public void UnlockDoors()
    {
        foreach (var doorItr in DoorsArray)
        {
            doorItr.IsBlock = false;
        }
    }

}
