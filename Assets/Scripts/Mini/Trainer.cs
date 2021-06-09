using System.Collections;
using UnityEngine;

public class Trainer : MonoBehaviour
{

    Animator anim;
    [SerializeField]
    GameObject dummyObj;
    Dummy dummy;

    void Awake()
    {
        anim = GetComponent<Animator>();
        if (dummyObj)
            dummy = dummyObj.GetComponent<Dummy>();
    }


    private void Start()
    {
        StartCoroutine(SwitchAnim());
    }

    public void Attack()
    {
        if (dummy)
            dummy.GetDamage(0);
    }

    IEnumerator SwitchAnim()
    {
        anim.SetInteger("training", Random.Range(0, 2));
        anim.SetTrigger("start");
        yield return new WaitForSeconds(5);
        StartCoroutine(SwitchAnim());
    }

}
