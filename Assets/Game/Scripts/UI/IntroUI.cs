using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using SimpleAudioManager;
using UnityEngine.SceneManagement;
using UnityEditor;

public class IntroUI : MonoBehaviour
{
    [Header("Start Screen")]
    public Text[] startMenuOptions;
    public GameObject startScreen;
    public Text versionNumber;

    [Header("Option Screen")]
    public Text[] optionMenuOptions;
    public GameObject optionsScreen;
    public Text controllerSettingText;
    public Text warning;

    [Header("How To Player Screen")]
    public GameObject howToPlayScreen;


    //Private Variables
    private Color deselectedColor = Color.white;
    private Color selectedColor = Color.yellow;
    private int menuIndex = 0;
    private float flickerSpeed = 0.07f;

    //String Array To Hold Joystick Names
    string[] temp;
    bool controllerDisconnected;

    private void OnEnable()
    {
     
        InputManager.onActionInput += ActionInputEvent;
    }


    private void OnDisable()
    {
       
        InputManager.onActionInput -= ActionInputEvent;
    }

    private void Awake()
    {
        //Get Joystick Names
          temp = Input.GetJoystickNames();
    }
    private void Start()
    {
        versionNumber.text = "Version " + Application.version;
        startMenuOptions[menuIndex].color = selectedColor;
        optionMenuOptions[menuIndex].color = selectedColor;
        optionsScreen.gameObject.SetActive(false);
        howToPlayScreen.gameObject.SetActive(false);

    }

    private void Update()
    {
        //Check whether array contains anything
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    controllerDisconnected = false;

                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    controllerDisconnected = true;
                }
            }
        }

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
                }
                else
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
                if (!controllerDisconnected)
                {
                    InputManager.instance.controlSetting = InputManager.CONTROLS.Controller;
                    controllerSettingText.text = "Controller";
                    AudioManager.instance.StartSound();
                    warning.color = Color.yellow;
                    warning.text = "Controller Detected";
                }
                else if (controllerDisconnected)
                {
                    InputManager.instance.controlSetting = InputManager.CONTROLS.Keyboard;
                    controllerSettingText.text = "Keyboard";
                    AudioManager.instance.MenuErrorSound();
                    warning.color = Color.red;
                    warning.text = "No Controller Detected";
                }

            }
            else if (action == "Pause" && optionMenuOptions[menuIndex] == optionMenuOptions[0] && InputManager.instance.controlSetting == InputManager.CONTROLS.Controller)
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
                menuIndex = 0;
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
                AudioManager.instance.StartSound();

                startScreen.gameObject.SetActive(true);
                optionsScreen.gameObject.SetActive(false);

            }
        }


        if (howToPlayScreen.activeSelf)
        {
            if (action == "Pause")
            {
                menuIndex = 0;
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
              
                startScreen.gameObject.SetActive(true);
                howToPlayScreen.gameObject.SetActive(false);
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
            menuIndex = 0;
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

            optionsScreen.gameObject.SetActive(true);
            startScreen.gameObject.SetActive(false);

        }

        if (startMenuOptions[menuIndex] == startMenuOptions[2])
        {
            howToPlayScreen.gameObject.SetActive(true);
            startScreen.gameObject.SetActive(false);
        }
    }

}
