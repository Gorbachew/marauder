using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    ItemController itemController;
    CitizenEvents citizenEvents;

    private void Awake()
    {
        itemController = GameObject.FindGameObjectWithTag("character").GetComponent<ItemController>();
        citizenEvents = GetComponent<CitizenEvents>();
    }

    void FixedUpdate()
    {
        if (GlobalVars.isGameStarted)
        {
            if (Application.platform == RuntimePlatform.Android && Input.touchCount > 0)
            {
                CheckTouch(Input.GetTouch(0).position);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                CheckTouch(Input.mousePosition);
            }
        }
    }

    private void CheckTouch(Vector3 pos)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.layer == 6 && !hit.collider.isTrigger)
            {
                citizenEvents.Meet(hit.collider.gameObject.name);
                
            }
            else if (hit.collider.gameObject.layer == 7)
            {
                if (hit.collider.tag == "weapon")
                {
                    itemController.PickUpItem(hit.collider, "r");
                } else
                {
                    itemController.PickUpItem(hit.collider, "l");
                }
                break;
            }  
        } 
        
    }




    
}
