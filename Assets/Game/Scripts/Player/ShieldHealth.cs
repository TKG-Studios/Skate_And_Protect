using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    public static ShieldHealth instance;

    [HideInInspector]
    public float shieldHealth;

    public float maxShieldHealth;
    public float repletionRate;
    public float depletionRate;

    private void Start()
    {
        instance = this;
        shieldHealth = maxShieldHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shieldHealth <= maxShieldHealth)
        {
            if (ShieldAnimator.instance.animator.GetBool("ShieldUp") == false)
            {
                ShieldReplete(repletionRate);
            }

            if (ShieldAnimator.instance.animator.GetBool("ShieldUp") && shieldHealth <= maxShieldHealth)
            {
                ShieldDamage(depletionRate);
            }
        }
   
    }

    public void ShieldDamage(float damage)
    {
        shieldHealth -= damage;
        if (shieldHealth <= 0)
        {
            GameManager.instance.changeState(GameManager.GameStates.GameOver);
            shieldHealth = 0;
        }
    }

    public void ShieldReplete(float repletion)
    {
        shieldHealth += repletion;
        if (shieldHealth > maxShieldHealth) shieldHealth = maxShieldHealth;
    }
}