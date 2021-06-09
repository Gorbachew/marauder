using UnityEngine;

public class Characteristics : MonoBehaviour
{   
    public bool isAttack;
    public float maxSpeed = 3;
    public float speed;
    public int HP = 3;
    public int maxHP = 3;
    public int SP = 100;
    public int recoverySP = 10;
    public int maxSP = 100;
    public int AP;
    public bool isDied;
    public bool isTired;

    public bool friendly;
    public bool isItemInArm;

    public string weaponType;
    public int damage;
    public int penetration = 2;

    public string state;
    public string occupation;
    public string unit;
    public int level;

    public string rItem;
    public string lItem;
    public string head;
    public string body;
    public string shirt;
    public string pants;
    public string boots;
    public string gloves;
    public string shoulderPads;
}
