using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public static PlayerPoints instance;

    public InvincibilitySpawner InvincibilitySpawner;
    public int innocentsSaved = 0;
    public int innocentsLost = 0;

    //Private Variables
    private int divisor = 10;
    private int innocentsRemaining = 0;

    private void Start()
    {
        instance = this;
      
    }



    public void SavedInnocent(int innocent)
    {
        
    
        innocentsSaved += innocent;

        if (innocentsSaved / divisor == 1)
        {
            InvincibilitySpawner.SpawnItem(InvincibilitySpawner.invincibility);
            divisor += 10;
        }
        InnocentMath();
    }

    public void LostInnocent(int innocent)
    {
        innocentsLost += innocent;
        InnocentMath();
    }

    public int InnocentMath()
    {
        int innocentTotal = (innocentsSaved - innocentsLost) * 100;
        if (innocentTotal < 0)
        {
            innocentTotal = 0;
        }
        return innocentTotal;
    }
}