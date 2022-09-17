using UnityEngine;

public class ShieldAnimator : MonoBehaviour
{
    public static ShieldAnimator instance;
    [SerializeField] private PlayerScript playerScript;
    internal Animator animator;

    private void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerScript.isShieldUp == true)
        {
            animator.SetBool("ShieldUp", true);
        }
        else
        {
            animator.SetBool("ShieldUp", false);
        }
    }
}