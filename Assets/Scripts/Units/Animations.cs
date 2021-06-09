using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    Characteristics charact;
    Rigidbody rg;
    void Awake()
    {
        animator = GetComponent<Animator>();
        charact = GetComponent<Characteristics>();
        rg = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetIdleState();
    }

    void FixedUpdate()
    {

        animator.SetFloat("speed", charact.speed);
        if (charact.isDied)
        {
            animator.SetTrigger("died");
        }
        
    }

    public void Attack()
    {
        
        switch (charact.weaponType)
        {
            case "arm":
                animator.SetFloat("attackNum", 1);
                animator.SetFloat("weaponType", 0);
                break;
            case "oneHanded":
                animator.SetFloat("attackNum", Random.Range(0, 2));
                animator.SetFloat("weaponType", 1);       
                break;
        }
        animator.SetTrigger("attack");
    }


    public void Block(bool value)
    {

        switch (charact.weaponType)
        {
            case "arms":
                animator.SetFloat("weaponType", 1);
                break;
            case "oneHanded":
                animator.SetFloat("weaponType", 2);
                break;
            case "shield":
                animator.SetFloat("weaponType", 3);
                break;
        }
        animator.SetBool("block", value);
   
    }

    public void Hit()
    {
        if (!animator.GetBool("block"))
            animator.SetFloat("weaponType", 0);

        animator.SetTrigger("hit");
    }

    public void Tired(bool value)
    {
        animator.SetBool("tired", value);
    }

    public void Take()
    {
        animator.SetTrigger("take");
    }
    public void Died()
    {
        animator.SetFloat("diedState", Random.Range(1, 3));
        animator.enabled = false;
    }

    public void SetCombatIdle()
    {
        animator.SetFloat("idleState", Mathf.Lerp(animator.GetFloat("idleState"), 0, 3 * Time.deltaTime));
    }

    public void SetFindingCharacter()
    {
        if (!charact.isDied)
            animator.SetTrigger("findingCharacter");
    }


    private void SetIdleState()
    {
        animator.SetFloat("idleState", Random.Range(1, 3));
    }

   
}
