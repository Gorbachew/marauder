using System.Collections;
using UnityEngine;

public class FightController : MonoBehaviour
{

    private Animations anim;
    private Characteristics charact;
    private ParticleSystem blood;

    private Coroutine recoverySp;

    private void Awake()
    {
        anim = GetComponent<Animations>();
        charact = GetComponent<Characteristics>();
        blood = transform.Find("blood").GetComponent<ParticleSystem>();
    }

    public void Attack()
    {
        if (!charact.isAttack && charact.SP > 0)
        {
            SubstractSp(GlobalVars.attackPriceSp);
            anim.Attack();
            charact.isAttack = true;
        }
    }

    public void EndAttack()
    {
        charact.isAttack = false;
    }

    public void Block(bool value)
    {
        if (value && charact.SP > 0)
        {
            anim.Block(true);
        }
        else anim.Block(false);

    }

    public void GetDamage(int damage)
    {
        if (charact.AP > 0)
        {
            charact.AP -= damage;
        } else
        {
            blood.Play();
            SubstractSp(GlobalVars.damagePriceSp);
            anim.Hit();
            charact.HP -= damage;
        }
       
    }

    private void SubstractSp(int value)
    {
        if (charact.SP > 0)
            charact.SP -= value;

        if (recoverySp != null)
        {
            anim.Tired(false);
            StopCoroutine(recoverySp);
        }


        recoverySp = StartCoroutine(RecoverySp(false));

    }

    private void SetLimitForSP(bool state)
    {
        charact.isTired = state;
        anim.Tired(state);
    }


    private IEnumerator RecoverySp(bool recovering)
    {
        if (charact.SP <= (charact.maxSP / 2)) SetLimitForSP(true);
        if (!recovering) yield return new WaitForSeconds(5);

        yield return new WaitForSeconds(1);
        charact.SP += charact.recoverySP;

        if (charact.maxSP <= charact.SP)
        {
            SetLimitForSP(false);
            charact.SP = charact.maxSP;
        }
        if (charact.maxSP > charact.SP) recoverySp = StartCoroutine(RecoverySp(true));
    }


}
