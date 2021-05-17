using UnityEngine;
namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class HyperCube : MonoBehaviour
    {
        [SerializeField] protected ICubeCommand CubeLogic;
    }
}