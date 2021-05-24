using HypercubesPrototyp.GameLogic;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class GoalCube : AbsorberCube
    {
        protected override void OnEnableChild()
        {
            GameControlInstance.SubscribeGoal(this);
        }

        protected override void OnDisableChild()
        {
            GameControlInstance.UnsubscribeGoal(this);
        }

        protected override void DoAbsorbFunctionality()
        {
            GameControlInstance.OnGoalTriggered();
        }

        public bool IsFinished()
        {
            return Triggered;
        }
    }
}