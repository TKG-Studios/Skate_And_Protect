using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public Text buttonPrompt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (InputManager.instance.controlSetting == InputManager.CONTROLS.Keyboard)
        {
            buttonPrompt.text = "Press Enter to Return To Title Screen";
        }

        if (InputManager.instance.controlSetting == InputManager.CONTROLS.Controller)
        {
            buttonPrompt.text = "Press Start to Return To Title Screen";
        }
    }

 
}
