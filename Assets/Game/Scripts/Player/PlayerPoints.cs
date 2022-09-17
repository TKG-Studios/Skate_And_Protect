using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public static PlayerPoints instance;
    public int innocentsSaved = 0;
    public int innocentsLost = 0;

    private void Start()
    {
        instance = this;
      
    }

    // Update is called once per frame
    private void Update()
    {
     
    }

    public void SavedInnocent(int innocent)
    {
        innocentsSaved += innocent;
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
        return innocentTotal;
    }
}