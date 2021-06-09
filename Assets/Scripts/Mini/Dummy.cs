using UnityEngine;

public class Dummy : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void GetDamage(int damage)
    {
        anim.SetTrigger("attack");
    }
}
