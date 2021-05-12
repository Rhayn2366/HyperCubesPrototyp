public class TriggerLogicHyperCube : HyperCube
{
    private int _triggerLogic;

    public void TriggerLogic()
    {
        if (_triggerLogic <= 0) //Maybe we want a case where trigger logic can be less than zero to use it as an objectiv (Like activate something)
        {
            _triggerLogic = 1;
        }
        else
        {
            _triggerLogic++;
        }
    }

    private void Update()
    {
        if (_triggerLogic > 0)
        {
            StartCoroutine(CubeLogic.DoCommand(null, this));
            _triggerLogic--;
        }
    }
}