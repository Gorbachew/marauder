using UnityEngine;

public class Bush : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
            animator.SetTrigger("trembling");
    }
}
