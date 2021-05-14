using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    [CreateAssetMenu(menuName = "CubeLogic/SplitCube")]
    public class SplitCube : CubeLogic
    {
        //maybe get the offset from the prefab, could be done in the factory
        [SerializeField] private float _yOffset = .25f;
        [SerializeField] private SplitType _splitType;

        private enum SplitType
        {
            T,
            V,
            X
        }

        protected override void DoCommand(GameObject lemming, HyperCube hyperCube)
        {
            if (!lemming) return;

            var cache = lemming.GetComponent<Lemming>();
            var lemmingId = cache.GetLemmingId();

            Destroy(lemming);

            if (_splitType == SplitType.T)
            {
                TSplit(hyperCube, lemmingId);
            }
            else if (_splitType == SplitType.V)
            {
                VSplit(hyperCube, lemmingId);
            }
            else if (_splitType == SplitType.X)
            {
                XSplit(hyperCube, lemmingId);
            }
        }

        private void TSplit(HyperCube hyperCube, int lemmingId)
        {
            var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset;
            var degrees = 90;

            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees);

            degrees = -90;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees);

            spawnPosition += hyperCube.transform.forward / 2;
            degrees = 0;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition, degrees);
        }

        private void XSplit(HyperCube hyperCube, int lemmingId)
        {
            var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset + hyperCube.transform.forward / 2;
            var degrees = 45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees);

            degrees = -45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees);

            spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset - hyperCube.transform.forward / 2;
            degrees = 135;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees);

            degrees = -135;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees);
        }

        private void VSplit(HyperCube hyperCube, int lemmingId)
        {
            var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset + hyperCube.transform.forward / 2;
            var eulerAngles = 45;

            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, eulerAngles);

            eulerAngles = -45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, eulerAngles);
        }

        private static void SpawnAndInitGameObject(HyperCube hyperCube, int lemmingId, Vector3 spawnPosition, float degrees)
        {
            // Dependency hiding might be bad later on. If this becomes a real problem we will need to think of another way to solve this.
            var instancedLemming = LemmingFactory.Instance.CreateLemming(lemmingId, spawnPosition);

            instancedLemming.SetRotationOnY(degrees);
            instancedLemming.SetLastUsedGameObject(hyperCube.gameObject);
        }
    }
}