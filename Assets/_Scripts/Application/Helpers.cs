using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
    private static readonly Dictionary<float, WaitForSeconds> _waitDictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWait(float time)
    {
        if (_waitDictionary.TryGetValue(time, out WaitForSeconds wait))
            return wait;

        _waitDictionary[time] = new WaitForSeconds(time);
        return _waitDictionary[time];
    }
}
