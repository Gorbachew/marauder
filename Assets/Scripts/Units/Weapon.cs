using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Characteristics charact;
    private bool isRaised;
    private int penetration;
    private GameObject parent;

    public void Set(Characteristics charact)
    {
        this.charact = charact;
        isRaised = true;
        parent = charact.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isRaised && other.gameObject != parent && charact.isAttack)
        {
            FightController fc = other.GetComponent<FightController>();
            if (fc)
            {
                fc.GetDamage(charact.damage);
                penetration++;
                EndAttack();
                return;
            }
            Dummy dummy = other.GetComponent<Dummy>();
            if (dummy)
            {
                dummy.GetDamage(charact.damage);
                EndAttack();
                return;
            } 
        }
    }

    private void EndAttack()
    {
        if (penetration >= charact.penetration)
        {
            penetration = 0;
            charact.isAttack = false;
        }
    }

}
