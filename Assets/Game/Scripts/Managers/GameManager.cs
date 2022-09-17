using SimpleAudioManager;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Objects to Manipulate on State Change
    private GameObject[] spawnObjects;
    private List<GameObject> innocents = new List<GameObject>();
    public GameObject HUD;

 
    private void OnEnable()
    {
        instance = this;
    }

    

    private void Start()
    {
        spawnObjects = GameObject.FindGameObjectsWithTag("Spawner");
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        innocents.Add(GameObject.FindGameObjectWithTag("Innocent"));
    
    }

    [System.Serializable]
    public enum GameStates
    {
        StartMenu,
        GameStart,
        GameActive,
        GamePause,
        GameOver
    }

    public GameStates currentState;

    public GameStates changeState(GameStates gameState)
    {
        currentState = gameState;
        if (currentState == GameStates.GameOver) GameOver();
        return gameState;
    }

    private void GameOver()
    {
        GameUI.instance.gameOver.gameObject.SetActive(true);

        if (HUD != null) 
        {
            HUD.SetActive(false);
        }
       
        LevelMusic.instance.StopTrack1();
        AudioManager.instance.GameOver();
        if (PlayerHealth.instance != null)
        {
            Destroy(PlayerHealth.instance.gameObject.GetComponentInChildren<SpriteRenderer>());
        }
        if (ShieldHealth.instance != null)
        {
            Destroy(ShieldHealth.instance.gameObject);
            Destroy(PlayerHealth.instance.gameObject.GetComponentInChildren<SpriteRenderer>());
        }

        foreach (GameObject spawnObject in spawnObjects)
        {
            Destroy(spawnObject);
        }

        foreach (GameObject innocent in innocents)
        {
            Destroy(innocent);
        }
       
    }
}