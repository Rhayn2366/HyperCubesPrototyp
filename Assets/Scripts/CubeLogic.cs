using UnityEngine;
using System.Collections;

public abstract class CubeLogic : ScriptableObject
{
    public abstract IEnumerator DoCommand(GameObject lemming, HyperCube hyperCube);
}