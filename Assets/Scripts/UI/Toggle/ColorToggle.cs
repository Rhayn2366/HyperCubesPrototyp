using UnityEngine;

public class ColorToggle : CustomToggle
{
    [SerializeField] private Color32 _activeColor;
    [SerializeField] private Color32 _inactiveColor;

    public override void OnSwitch(bool state)
    {
        if (state)
        {
            CurrentToggle.image.color = _activeColor;
        }
        else
        {
            CurrentToggle.image.color = _inactiveColor;
        }
    }
}