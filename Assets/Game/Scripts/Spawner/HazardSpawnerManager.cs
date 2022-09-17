using UnityEngine;

public class HazardSpawnerManager : MonoBehaviour
{
    public GameObject[] HazardSpawnerArray;
    private int activateSpawnerNumber;
    private int currentSpawnerNumber;

    public float activateInterval;
    private float activateCountDown;

    private void Start()
    {
       
            activateCountDown = activateInterval;

            foreach (GameObject spawner in HazardSpawnerArray)
            {
                spawner.GetComponent<HazardSpawner>().enabled = false;
                spawner.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }

            activateSpawnerNumber = Random.Range(0, 4);
            currentSpawnerNumber = activateSpawnerNumber;
        
    }

    // Update is called once per frame
    private void Update()
    {

        if (GameManager.instance.currentState == GameManager.GameStates.GameActive)
        {

            HazardSpawnerArray[currentSpawnerNumber].GetComponent<HazardSpawner>().enabled = true;
        HazardSpawnerArray[currentSpawnerNumber].GetComponentInChildren<SpriteRenderer>().enabled = true;
        if (activateCountDown > 0)
        {
            activateCountDown -= Time.deltaTime;
        }

            if (activateCountDown <= 0)
            {
                activateCountDown = activateInterval;
                HazardSpawnerArray[currentSpawnerNumber].GetComponent<HazardSpawner>().enabled = false;
                HazardSpawnerArray[currentSpawnerNumber].GetComponentInChildren<SpriteRenderer>().enabled = false;
                activateSpawnerNumber = Random.Range(0, 4);
                currentSpawnerNumber = activateSpawnerNumber;
                HazardSpawnerArray[currentSpawnerNumber].GetComponent<HazardSpawner>().enabled = true;
                HazardSpawnerArray[currentSpawnerNumber].GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }
    }
}