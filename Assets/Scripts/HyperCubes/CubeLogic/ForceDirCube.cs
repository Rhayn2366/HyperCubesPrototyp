using HypercubesPrototyp.GameLogic;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class ForceDirCube : CubeLogic
    {
        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;
            lemming.SetRotationOnY(hyperCube.transform.eulerAngles.y);
            lemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}