using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{

    public Transform target;

    public LayerMask CharacterLayer;

    [SerializeField]
    private List<Transform> movePoints = new List<Transform>();

    private NavMeshAgent nvAgent;
    private Characteristics charact, targetCharact;
    private Animations anim;
    private Collider mainCollider;
    private FightController fightController;

    private int actualPoint;
    private float Acceleration = 0.02f;

   


    Rigidbody rb;

    private void Awake()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        charact = GetComponent<Characteristics>();
        anim = GetComponent<Animations>();
        mainCollider = GetComponent<Collider>();
        fightController = GetComponent<FightController>();
    }

    // Update is called once per frame
    void Update()
    {
        Logic();
    }

    public void FindCharacter(GameObject obj)
    {
        charact.state = "tense";
        target = obj.transform;
        targetCharact = target.GetComponent<Characteristics>();
    }

    public IEnumerator LostCharacter()
    {
        yield return new WaitForSeconds(3);
        anim.SetFindingCharacter();
        charact.state = "relaxed";
        target = null;
    }

    private void Logic()
    {
        if (!charact.isDied)
        {
            if (charact.HP <= 0) Died();

            if (charact.state == "tense" && !charact.friendly) {
                Chaseing();
            }
            else if (movePoints.Count > 0) Patrolling();
            else Idle();

        }
    }

    private void Died()
    {
        charact.isDied = true;
        rb.isKinematic = true;
        nvAgent.enabled = false;
        mainCollider.enabled = false;
        mainCollider.isTrigger = true;
        anim.Block(false);
        gameObject.GetComponent<AIControl>().enabled = false;
    }

    private void Idle()
    {
        charact.occupation = "idle";
        SetSpeed(0, 0);
    }

    private void Patrolling()
    {
        charact.occupation = "patrolling";
        if (movePoints[0] == null)
        {
            movePoints.Clear();
            return;
        }
        target = movePoints[actualPoint];
           
        float dist = MoveToTarget(target);
        if (dist <= 0.1f)
        {
            actualPoint++;
            if (actualPoint >= movePoints.Count) actualPoint = 0;
        }
        
    }

    private void Chaseing()
    {
        
        float dist = MoveToTarget(target);
        if (dist > 2)
        {
            charact.occupation = "chaseing";
            anim.SetCombatIdle();
            fightController.Block(false);
        }
        else
        {
            Fight();
        }
    }


    private void Fight()
    {
        charact.occupation = "fight";
        fightController.Block(true);
    }


    private float MoveToTarget(Transform target)
    {
       
        Vector3 relativePos = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Acceleration * 2);

        nvAgent.enabled = true;
        nvAgent.SetDestination(target.position);
        float dist = Vector3.Distance(transform.position, target.position);



        if (charact.state == "relaxed") SetSpeed(dist, 1);
        if (charact.state == "tense")
        {
            if (charact.isTired)
                SetSpeed(dist, 1);
            else
            {
                if (dist > 3) SetSpeed(dist, charact.maxSpeed);
                else SetSpeed(dist, 0);
            }
        }
       
        return dist;
    }

    private void SetSpeed(float dist, float speed)
    {
        charact.speed = Mathf.Lerp(charact.speed, speed, Acceleration);
        if ((charact.state == "tense" && dist < 1 )|| charact.occupation == "idle")
        {
            charact.speed = 0;
            rb.velocity = Vector3.zero;
        }
        nvAgent.speed = charact.speed;
    }




}
