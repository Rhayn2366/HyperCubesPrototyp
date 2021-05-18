using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class ActivatorCube : CubeLogic
    {
        [SerializeField] private float _radius = 1f;

        private const string ColliderTag = "TriggerHyperCube";

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;

            Destroy(lemming.gameObject);

            Collider[] hitColliders = Physics.OverlapSphere(hyperCube.transform.position, _radius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag(ColliderTag))
                {
                    hitCollider.gameObject.GetComponent<TriggerLogicHyperCube>().TriggerLogic();
                }
            }
        }
    }
}