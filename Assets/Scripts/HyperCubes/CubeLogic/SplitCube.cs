using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class SplitCube : CubeLogic
    {
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
            var lemmingTTL = lemming.GetTimeToLive();

            //Destroying it here doesn't make much sense. Maybe do it in the factory?
            Destroy(lemming.gameObject);

            if (_splitType == SplitType.T)
            {
                TSplit(hyperCube, lemmingId, lemmingColor, lemmingTTL);
            }
            else if (_splitType == SplitType.V)
            {
                VSplit(hyperCube, lemmingId, lemmingColor, lemmingTTL);
            }
            else if (_splitType == SplitType.X)
            {
                XSplit(hyperCube, lemmingId, lemmingColor, lemmingTTL);
            }
        }

        private void TSplit(HyperCube hyperCube, int lemmingId, Color lemmingColor, float timeToLive)
        {
            var spawnPosition = hyperCube.transform.position;
            var degrees = hyperCube.transform.eulerAngles.y + 90;

            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees, lemmingColor, timeToLive);

            degrees = hyperCube.transform.eulerAngles.y - 90;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees, lemmingColor, timeToLive);

            spawnPosition += hyperCube.transform.forward / 2;
            degrees = hyperCube.transform.eulerAngles.y;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition, degrees, lemmingColor, timeToLive);
        }

        private void XSplit(HyperCube hyperCube, int lemmingId, Color lemmingColor, float timeToLive)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            var degrees = hyperCube.transform.eulerAngles.y + 45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees, lemmingColor, timeToLive);

            degrees = hyperCube.transform.eulerAngles.y - 45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees, lemmingColor, timeToLive);

            spawnPosition = hyperCube.transform.position - hyperCube.transform.forward / 2;
            degrees = hyperCube.transform.eulerAngles.y + 135;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, degrees, lemmingColor, timeToLive);

            degrees = hyperCube.transform.eulerAngles.y - 135;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, degrees, lemmingColor, timeToLive);
        }

        private void VSplit(HyperCube hyperCube, int lemmingId, Color lemmingColor, float timeToLive)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            var eulerAngles = hyperCube.transform.eulerAngles.y + 45;

            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition + hyperCube.transform.right / 2, eulerAngles, lemmingColor, timeToLive);

            eulerAngles = hyperCube.transform.eulerAngles.y - 45;
            SpawnAndInitGameObject(hyperCube, lemmingId, spawnPosition - hyperCube.transform.right / 2, eulerAngles, lemmingColor, timeToLive);
        }

        private static void SpawnAndInitGameObject(HyperCube hyperCube, int lemmingId, Vector3 spawnPosition, float degrees, Color color, float timeToLive)
        {
            // Dependency hiding might be bad later on. If this becomes a real problem we will need to think of another way to solve this.
            var instancedLemming = LemmingFactory.Instance.CreateLemming(lemmingId, spawnPosition, color, timeToLive, degrees);

            instancedLemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}