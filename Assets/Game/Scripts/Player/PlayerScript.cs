using UnityEngine.SceneManagement;
using UnityEngine;
using SimpleAudioManager;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
  

    [Header("Player")]
    public Animator playerAnimator;
    public float movementSpeed;

    [HideInInspector]
    public Vector2 inputDirection;

    private SpriteRenderer playerSprite;

    [Header("Shield")]
    public GameObject shield;

    [Header("Shield Positions")]
    public Transform shieldUpPosition;

    public Transform shieldDownPosition;
    public Transform shieldDownLeft;
    public Transform shieldDownRight;

    internal bool isShieldUp;
    internal GameManager.GameStates currentState;
  

    private void OnEnable()
    {
        InputManager.onInputEvent += InputEvent;
        InputManager.onActionInput += ActionInputEvent;
    }

    private void OnDisable()
    {
        InputManager.onInputEvent -= InputEvent;
        InputManager.onActionInput -= ActionInputEvent;
    }

    private void Start()
    {
        
        isShieldUp = false;
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        playerAnimator = GetComponentInChildren<Animator>();
   
    }

    private void Update()
    {
        currentState = GameManager.instance.currentState;
    }

    private void InputEvent(Vector2 direction)
    {
        inputDirection = direction;

        if (currentState == GameManager.GameStates.GameActive && playerSprite != null)
        {
            direction = new Vector2(direction.x, 0);
            transform.Translate(direction * movementSpeed * Time.deltaTime);
            if (inputDirection.x > 0)
            {
                playerSprite.flipX = false;
            }
            if (inputDirection.x < 0)
            {
                playerSprite.flipX = true;
            }

            if (inputDirection.x > 0 && !isShieldUp)
            {
                if (shield != null)
                {
                    shield.transform.position = shieldDownRight.position;
                    shield.GetComponent<SpriteRenderer>().flipX = false;
                    shieldDownPosition = shieldDownRight;
                }
            }

            if (inputDirection.x < 0 && !isShieldUp)
            {
                if (shield != null)
                {
                    shield.transform.position = shieldDownLeft.position;
                    shield.GetComponent<SpriteRenderer>().flipX = true;
                    shieldDownPosition = shieldDownLeft;
                }
            }
        }
    }

    private void ActionInputEvent(string action)
    {
        if (currentState == GameManager.GameStates.GameActive)
        {
            if (action == "Shield" && !isShieldUp)
            {
                isShieldUp = !isShieldUp;
                playerAnimator.SetBool("ShieldIsUp", true);

                if (shield != null)
                {
                    shield.transform.position = shieldUpPosition.position;
                }
            }
            else if (action == "Shield" && isShieldUp)
            {
                isShieldUp = !isShieldUp;
                playerAnimator.SetBool("ShieldIsUp", false);
                if (shield != null)
                {
                    shield.transform.position = shieldDownPosition.position;
                }
            }
            if (action == "Pause" && Time.timeScale > 0)
            {
                GameManager.instance.changeState(GameManager.GameStates.GamePause);
                Time.timeScale = 0;
                LevelMusic.instance.trackList[0].volume = .1f;
            }
        }

        if (currentState == GameManager.GameStates.GamePause)
        {
            if (action == "Pause" && Time.timeScale == 0)
            {
                GameManager.instance.changeState(GameManager.GameStates.GameActive);
                Time.timeScale = 1;
                LevelMusic.instance.trackList[0].volume = .4f;
            }
        }
        if (currentState == GameManager.GameStates.GameOver)
        {
            
            if (action == "Pause")
            {
                GameManager.instance.changeState(GameManager.GameStates.GameStart);
                LevelMusic.instance.playTrack1();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }
}