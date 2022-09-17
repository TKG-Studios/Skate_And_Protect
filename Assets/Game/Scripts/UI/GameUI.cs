using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public Image[] healthIndicators;
    public Slider shieldSlider;
    public Text innocentsSaved;
    public Text innocentsLost;
    public Text gameOver;
    public Text ready;
    public GameObject gamePaused;
 

   

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (GameManager.instance.currentState == GameManager.GameStates.GameStart)
        {
            StartCoroutine(GetReady());



            gamePaused.SetActive(false);
            gameOver.gameObject.SetActive(false);
            innocentsSaved.text = "Saved: " + PlayerPoints.instance.innocentsSaved.ToString();
            shieldSlider.value = ShieldHealth.instance.shieldHealth;
            innocentsLost.text = "Lost: " + PlayerPoints.instance.innocentsLost.ToString();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.currentState == GameManager.GameStates.GameActive)
        {
            for (int i = 0; i < healthIndicators.Length; i++)
            {
                healthIndicators[i].gameObject.SetActive(i < PlayerHealth.instance.health);
            }

            shieldSlider.value = ShieldHealth.instance.shieldHealth;
            innocentsSaved.text = "Saved: " + PlayerPoints.instance.innocentsSaved.ToString();
            innocentsLost.text = "Lost: " + PlayerPoints.instance.innocentsLost.ToString();
        }

        if (GameManager.instance.currentState == GameManager.GameStates.GamePause)
        {
            gamePaused.SetActive(true);
        }

        else
        {
            gamePaused.SetActive(false);
        }
    }

    IEnumerator GetReady()
    {
        yield return new WaitForSeconds(3f);
        ready.text = "GO!";
        yield return new WaitForSeconds(1f);
        ready.gameObject.SetActive(false);
        GameManager.instance.changeState(GameManager.GameStates.GameActive);
    }
}