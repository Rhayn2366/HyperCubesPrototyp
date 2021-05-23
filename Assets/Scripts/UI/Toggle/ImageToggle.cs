using UnityEngine;

/// <summary>
/// Toggles the image of a toggle when its state changed
/// </summary>
public class ImageToggle : CustomToggle
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _inactiveSprite;

    public override void OnSwitch(bool state)
    {
        if (state)
        {
            CurrentToggle.image.sprite = _activeSprite;
        }
        else
        {
            CurrentToggle.image.sprite = _inactiveSprite;
        }
        CurrentToggle.image.preserveAspect = true;
    }
}