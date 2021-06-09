using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float gamePosY = 5, gamePosZ = -1;
    private float startCamPosY = 1.6f, startCamPosZ = 1.8f;
    private float startCamLookX = 0.5f, startCamLookY = 1;
    private Vector3 startPosition, gamePosition;
    private UI ui;
    [SerializeField]
    private LayerMask walls;
    
    private void Start()
    {
        startPosition = new Vector3(target.position.x, target.position.y + startCamPosY, target.position.z + startCamPosZ);
        gamePosition = new Vector3(target.position.x, target.position.y + gamePosY, target.position.z + gamePosZ);
        ui = FindObjectOfType<UI>();
        InStart();
        
    }

    void LateUpdate()
    {
        if (GlobalVars.isGameStarted && !GlobalVars.isDownCharacter)
        {
            InGame();
        }
    }

    private void InStart()
    {

        gameObject.transform.position = startPosition;
        gameObject.transform.LookAt( new Vector3(target.position.x + startCamLookX, target.position.y + startCamLookY, target.position.z));
    }

    private void InGame()
    {
        gamePosition = new Vector3(target.position.x, target.position.y + gamePosY, target.position.z + gamePosZ);
        if (Physics.Raycast(target.position, transform.position - target.position, out RaycastHit ray, Vector3.Distance(transform.position, target.position), walls))
        {
            float height = Mathf.Clamp(ray.point.y, 3, 6);
            transform.position = new Vector3(ray.point.x, height, ray.point.z);
        } else
        {
            gameObject.transform.position = gamePosition;
        }
       
        gameObject.transform.LookAt(target);
    }


    public IEnumerator StartSpan()
    {
        ui.SwitchShopUI("", false);
        while (transform.position.y <= gamePosition.y - 0.01f)
        {
            transform.RotateAround(gamePosition, Vector3.up, 0.6f);
            transform.position = Vector3.MoveTowards(transform.position, gamePosition, Time.deltaTime * 3);
            gameObject.transform.LookAt(target);
            if (transform.position.y >= gamePosition.y - 0.02f)
            {
                GlobalVars.isGameStarted = true;
                GlobalVars.isDownCharacter = false;
                target.GetComponent<Animations>().SetCombatIdle();
                ui.SwitchGameUI(true);
               
            }
            yield return null;
        } 
    }


    public IEnumerator DownToCharacter(string who)
    {

        GlobalVars.isDownCharacter = true;
        while (transform.position.y >= startPosition.y - 0.01f)
        {
            //transform.RotateAround(gamePosition, Vector3.up, 0.6f);
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, 30f, 0), 0.1f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x + 1.6f, target.position.y + startCamPosY, target.position.z + startCamPosZ), Time.deltaTime * 3);
            gameObject.transform.LookAt(new Vector3(target.position.x + startCamLookX, target.position.y + startCamLookY, target.position.z));
            if (transform.position.y <= startPosition.y + 0.02f)
            {
                ui.SwitchShopUI(who, true);
                ui.SwitchGameUI(false);
                StopCoroutine("DownToCharacter");
            }
            yield return null;
        }


    }

}

