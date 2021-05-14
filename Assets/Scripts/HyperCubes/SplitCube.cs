using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    [CreateAssetMenu(menuName = "CubeLogic/SplitCube")]
    public class SplitCube : CubeLogic
    {
        //TODO Get this from the lemming class as it can change depending on the lemming (Could be done in factory)
        [SerializeField] private SplitType _splitType;

        private enum SplitType
        {
            T,
            V,
            X
        }

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;

            var lemmingId = lemming.GetLemmingId();
            var lemmingColor = lemming.GetLemmingColor();

            //Destroying it here doesn't make much sense. Maybe do it in the factory?
            Destroy(lemming.gameObject);

            if (_splitType == SplitType.T)
            {
                TSplit(hyperCube, lemmingId, lemmingColor);
            }
            else if (_splitType == SplitType.V)
            {
                VSplit(hyperCube, lemmingId, lemmingColor);
            }
            else if (_splitType == SplitType.X)
            {
                XSplit(hyperCube, lemmingId, lemmingColor);
            }
        }

        private void TSplit(HyperCube hyperCube, int lemmingId, Color lemmingColor)
        {
            var spawnPosition = hyperCube.transform.position;
            var degrees = 90;

            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees, lemmingColor);

            degrees = -90;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees, lemmingColor);

            spawnPosition += hyperCube.transform.forward / 2;
            degrees = 0;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition, degrees, lemmingColor);
        }

        private void XSplit(HyperCube hyperCube, int lemmingId, Color lemmingColor)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            var degrees = 45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees, lemmingColor);

            degrees = -45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees, lemmingColor);

            spawnPosition = hyperCube.transform.position - hyperCube.transform.forward / 2;
            degrees = 135;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees, lemmingColor);

            degrees = -135;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees, lemmingColor);
        }

        private void VSplit(HyperCube hyperCube, int lemmingId, Color lemmingColor)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            var eulerAngles = 45;

            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, eulerAngles, lemmingColor);

            eulerAngles = -45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, eulerAngles, lemmingColor);
        }

        private static void SpawnAndInitGameObject(HyperCube hyperCube, int lemmingId, Vector3 spawnPosition, float degrees, Color color)
        {
            // Dependency hiding might be bad later on. If this becomes a real problem we will need to think of another way to solve this.
            var instancedLemming = LemmingFactory.Instance.CreateLemming(lemmingId, spawnPosition, degrees, color);

            instancedLemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}