using UnityEngine;
namespace HypercubesPrototyp.HyperCubeLogic
{
    /// <summary>
    /// Abstract class for all types of a hypercube.
    /// 
    /// Need a cube logic that will can be accessed in its
    /// implementing children and be triggered through a from them defined
    /// method (<see cref="CollisionHyperCube"/> <seealso cref="TriggerLogicHyperCube"/>).
    /// </summary>
    public abstract class HyperCube : MonoBehaviour
    {
        [SerializeField] protected CubeLogic CubeLogic;

        #region
        private void Awake()
        {
            CubeLogic = GetComponent<CubeLogic>();
        }
        #endregion Unity_callbacks
    }
}