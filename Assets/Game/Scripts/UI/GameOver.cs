using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text saved;
    public Text lost;
    public Text final;
    public Text restartInstruction;
    

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.currentState == GameManager.GameStates.GameOver)
        {
            if (InputManager.instance.controlSetting == InputManager.CONTROLS.Controller) restartInstruction.text = "Press Start To Try Again";

            if (InputManager.instance.controlSetting == InputManager.CONTROLS.Keyboard) restartInstruction.text = "Press Enter To Try Again";
        }

        if (GameManager.instance.currentState == GameManager.GameStates.GameOver)
        {
            saved.text = GameUI.instance.innocentsSaved.text;
            lost.text = GameUI.instance.innocentsLost.text;
            final.text = "Total Points: " + (PlayerPoints.instance.InnocentMath()).ToString();
        }
       
    }


}
