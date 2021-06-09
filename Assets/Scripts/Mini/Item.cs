using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody rb;
    Collider colliderObj;
    public bool isSelected;
    Transform droppedItems;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        colliderObj = GetComponent<Collider>();
        rb.isKinematic = true;
        colliderObj.isTrigger = true;
        droppedItems = GameObject.Find("DroppedItems").transform;
    }

    public bool Get(Transform parent, Vector3 pos, Quaternion rot)
    {
        if (!isSelected) return false;
        transform.SetParent(parent);
        transform.localPosition = pos;
        transform.localRotation = rot;
        return true;
    }

    public void Drop()
    {
        transform.SetParent(droppedItems);
        rb.isKinematic = false;
        colliderObj.isTrigger = false;
        StartCoroutine(Dropped());
    }

    IEnumerator Dropped()
    {
        yield return new WaitForSeconds(3);
        rb.isKinematic = true;
        colliderObj.isTrigger = true;
    }
}
