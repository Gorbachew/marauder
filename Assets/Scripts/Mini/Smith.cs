using System.Collections;
using UnityEngine;

public class Smith : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    ParticleSystem sparks;
    void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Forging());
    }
        
    public void Sparks()
    {
        if (sparks)
            sparks.Play();
    }

    IEnumerator Forging()
    {
        yield return new WaitForSeconds(10);
        animator.SetTrigger("forging");
        yield return new WaitForSeconds(10);
        StartCoroutine(Forging());
    }
}
