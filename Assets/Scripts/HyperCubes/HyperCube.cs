using UnityEngine;
namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class HyperCube : MonoBehaviour
    {
        [SerializeField] protected CubeLogic CubeLogic;

        private void Awake()
        {
            CubeLogic = GetComponent<CubeLogic>();
        }
    }
}