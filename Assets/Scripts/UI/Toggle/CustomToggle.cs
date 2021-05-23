using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Custom behaviour for a toggler when its state has changed.
/// 
/// Will automatically grab the toggle component from the game object
/// it is attached to and make it available for its children to use.
/// 
/// Will also automatically add itself to the on toggle switch event.
/// </summary>
[RequireComponent(typeof(Toggle))]
public abstract class CustomToggle : MonoBehaviour
{
    protected Toggle CurrentToggle;

    /// <summary>
    /// Defines what should happen if the togglers on switch event is called.
    /// </summary>
    /// <param name="state"> active state of the toggle </param>
    public abstract void OnSwitch(bool state);

    #region Unity_callbacks
    private void Awake()
    {
        CurrentToggle = GetComponent<Toggle>();
        OnSwitch(CurrentToggle.isOn);
        CurrentToggle.onValueChanged.AddListener(OnSwitch);
    }
    #endregion
}