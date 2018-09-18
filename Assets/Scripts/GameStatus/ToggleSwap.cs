using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwap : MonoBehaviour
{
    public Toggle TargeToggle;

    public Sprite SelectedSprite;

    private void Start()
    {
        TargeToggle.toggleTransition = Toggle.ToggleTransition.None;
        TargeToggle.onValueChanged.AddListener(OnTargetToggleValueChanged);
    }

    //switch Toggle since there arent any easy ways
    private void OnTargetToggleValueChanged(bool value)
    {
        Image targetImage = TargeToggle.targetGraphic as Image;
        if (TargeToggle != null)
        {
            if (value)
            {
                targetImage.overrideSprite = SelectedSprite;
            }
            else
            {
                targetImage.overrideSprite = null;
            }
        }
    }
}