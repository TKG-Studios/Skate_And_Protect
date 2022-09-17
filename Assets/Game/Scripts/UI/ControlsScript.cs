using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsScript : MonoBehaviour
{
    public Text controllerSetting;
    public Text movementControls;
    public Text shieldControls;
    public Text navigateMenu;
    public Text selectOption;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.controlSetting == InputManager.CONTROLS.Keyboard)
        {
            controllerSetting.text = "Keyboard Controls";
            movementControls.text = "A / D - Left /  Right";
            shieldControls.text = "W - Lift Shield";
            navigateMenu.text = "S - Navigate Menu";
            selectOption.text = "Enter - Select Option";
        }

        if (InputManager.instance.controlSetting == InputManager.CONTROLS.Controller)
        {
            controllerSetting.text = "Gamepad Controls";
            movementControls.text = "Dpad - Left /  Right";
            shieldControls.text = "A - Lift Shield";
            navigateMenu.text = "Select - Navigate Menu";
            selectOption.text = "Start - Select Option";
        }
    }
}
