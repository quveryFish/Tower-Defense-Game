using UnityEngine;

public class TowerAnimations : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        if (gameObject.GetComponent<Animator>() != null)
        {
            animator = gameObject.GetComponent<Animator>();
        }

    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }
}
