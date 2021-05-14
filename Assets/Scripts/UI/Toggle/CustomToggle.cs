using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class CustomToggle : MonoBehaviour
{
    protected Toggle CurrentToggle;

    private void Awake()
    {
        CurrentToggle = GetComponent<Toggle>();
        OnSwitch(CurrentToggle.isOn);
        CurrentToggle.onValueChanged.AddListener(OnSwitch);
    }

    public abstract void OnSwitch(bool state);
}