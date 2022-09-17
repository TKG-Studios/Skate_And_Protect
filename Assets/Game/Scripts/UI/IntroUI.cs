using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using SimpleAudioManager;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    [Header("Start Screen")]
    public Text[] startMenuOptions;
    public GameObject startScreen;

    [Header("Option Screen")]
    public Text[] optionMenuOptions;
    public GameObject optionsScreen;
    public Text controllerSettingText;


    //Private Variables
    private Color deselectedColor = Color.white;
    private Color selectedColor = Color.yellow;
    private int menuIndex = 0;
    private float flickerSpeed = 0.07f;
    private void OnEnable()
    {
     
        InputManager.onActionInput += ActionInputEvent;
    }

    private void OnDisable()
    {
       
        InputManager.onActionInput -= ActionInputEvent;
    }
    private void Start()
    {
        startMenuOptions[menuIndex].color = selectedColor;
        optionMenuOptions[menuIndex].color = selectedColor;
        optionsScreen.gameObject.SetActive(false);
    }


    private void ActionInputEvent(string action)
    {
        if (startScreen.activeSelf)
        {
            if (action == "Select")
            {
                AudioManager.instance.SelectSound();
                if (menuIndex >= startMenuOptions.Length - 1)
                {
                    menuIndex = 0;
                }
                else
                {
                    menuIndex++;
                }

                startMenuOptions[menuIndex].color = selectedColor;

                for (int i = 0; i < startMenuOptions.Length; i++)
                {
                    if (menuIndex == i)
                    {
                        startMenuOptions[i].color = selectedColor;

                    }
                    else
                    {
                        startMenuOptions[i].color = deselectedColor;
                    }
                }

            }


            if (action == "Pause")
            {
                AudioManager.instance.StartSound();
                StartCoroutine(FlickerText());
            }

        }

        if (optionsScreen.activeSelf)
        {
         
            if (action == "Select")
            {
                
                AudioManager.instance.SelectSound();
                if (menuIndex >= optionMenuOptions.Length - 1)
                {
                    menuIndex = 0;
                } else
                {
                    menuIndex++;
                }

                optionMenuOptions[menuIndex].color = selectedColor;

                for (int i = 0; i < optionMenuOptions.Length; i++)
                {
                    if (menuIndex == i)
                    {
                        optionMenuOptions[i].color = selectedColor;

                    }
                    else
                    {
                      optionMenuOptions[i].color = deselectedColor;
                    }
                }
            }

            if (action == "Pause" && optionMenuOptions[menuIndex] == optionMenuOptions[0] && InputManager.instance.controlSetting == InputManager.CONTROLS.Keyboard)
            {
                InputManager.instance.controlSetting = InputManager.CONTROLS.Controller;
                controllerSettingText.text = "Controller";
                AudioManager.instance.SelectSound();
                
            } else if (action == "Pause" && optionMenuOptions[menuIndex] == optionMenuOptions[0] && InputManager.instance.controlSetting == InputManager.CONTROLS.Controller)
            {
                InputManager.instance.controlSetting = InputManager.CONTROLS.Keyboard;
                controllerSettingText.text = "Keyboard";
                AudioManager.instance.SelectSound();

            }

            if (action == "Pause" && optionMenuOptions[menuIndex] == optionMenuOptions[1])
            {
                AudioManager.instance.MenuErrorSound();
            }

            if (action == "Pause" && optionMenuOptions[menuIndex] == optionMenuOptions[2])
            {

                AudioManager.instance.StartSound();
                optionsScreen.gameObject.SetActive(false);
                startScreen.gameObject.SetActive(true);
            }
        }

    }

    IEnumerator FlickerText()
    {

        startMenuOptions[menuIndex].enabled = false;
            yield return new WaitForSeconds(flickerSpeed);
        startMenuOptions[menuIndex].enabled = true;
            yield return new WaitForSeconds(flickerSpeed);
        startMenuOptions[menuIndex].enabled = false;
            yield return new WaitForSeconds(flickerSpeed);
        startMenuOptions[menuIndex].enabled = true;
            yield return new WaitForSeconds(flickerSpeed);
        startMenuOptions[menuIndex].enabled = false;
            yield return new WaitForSeconds(flickerSpeed);
        startMenuOptions[menuIndex].enabled = true;
        yield return new WaitForSeconds(flickerSpeed);
        
    

        if (startMenuOptions[menuIndex] == startMenuOptions[0])
        {
                foreach (Text startMenuOption in startMenuOptions)
        {
            startMenuOption.gameObject.SetActive(false);
        }
            GameManager.instance.changeState(GameManager.GameStates.GameStart);
            LevelMusic.instance.playTrack1();
            SceneManager.LoadScene(1);
        }

        if (startMenuOptions[menuIndex] == startMenuOptions[1])
        {
          
            startScreen.gameObject.SetActive(false);
            optionsScreen.gameObject.SetActive(true);
        }
    }

}
