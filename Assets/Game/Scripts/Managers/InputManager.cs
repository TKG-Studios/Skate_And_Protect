using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; set; }
   
    public enum CONTROLS
    { Controller, Keyboard }

    public CONTROLS controlSetting = CONTROLS.Keyboard;

    public delegate void InputEventHandler(Vector2 direction);

    public static event InputEventHandler onInputEvent;

    public delegate void InputActionHandler(string action);

    public static event InputActionHandler onActionInput;



    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
       
    }

    [Header("Keycoard Controls")]
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public KeyCode shield = KeyCode.Q;
    public KeyCode pause = KeyCode.Escape;
    public KeyCode select = KeyCode.S;


    [Header("Xbox Controller")]
    public KeyCode xboxShield = KeyCode.Joystick1Button0;
    public KeyCode xboxPause = KeyCode.Joystick1Button7;
    public KeyCode xboxSelect = KeyCode.Joystick1Button6;

    private void Update()
    {
        if (controlSetting == CONTROLS.Keyboard) KeyboardControls();
        if (controlSetting == CONTROLS.Controller) XboxControls();
    }

    public static void InputEvent(Vector2 direction)
    {
        if (onInputEvent != null) onInputEvent(direction);
    }

    public static void InputActionEvent(string action)
    {
        if (onActionInput != null) onActionInput(action);
    }

    private void KeyboardControls()
    {
        //movement input
        float x = 0f;
        if (Input.GetKey(left)) x = -1f;
        if (Input.GetKey(right)) x = 1f;

        Vector2 direction = new Vector2(x, 0);
        InputEvent(direction);

        //Action Inputs
        if (Input.GetKeyDown(shield)) onActionInput("Shield");
        if (Input.GetKeyDown(pause)) onActionInput("Pause");
        if (Input.GetKeyDown(select)) onActionInput("Select");
    }

    private void XboxControls()
    {
        //movement input
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(x, 0);
        InputEvent(direction.normalized);

        //Action Inputs
        if (Input.GetKeyDown(xboxShield)) onActionInput("Shield");
        if (Input.GetKeyDown(xboxPause)) onActionInput("Pause");
        if (Input.GetKeyDown(xboxSelect)) onActionInput("Select");
    }
}