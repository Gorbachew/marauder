using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject character;

    private GameObject bodyObj, rarmObj, larmObj, llegObj, rlegObj, headObj;
    public SkinnedMeshRenderer playerSkin;
    private Characteristics charact;
    private Animations anim;

    Transform lHand, rHand;
    [SerializeField]
    //GameObject item;
   
    private void Awake()
    {
        if (gameObject.tag == "character")
            character = gameObject;
        charact = GetComponent<Characteristics>();
        anim = GetComponent<Animations>();
        bodyObj = gameObject.transform.Find("Body").gameObject;
        rarmObj = gameObject.transform.Find("Rarm").gameObject;
        larmObj = gameObject.transform.Find("Larm").gameObject;
        llegObj = gameObject.transform.Find("Lleg").gameObject;
        rlegObj = gameObject.transform.Find("Rleg").gameObject;
        headObj = gameObject.transform.Find("Head").gameObject;

       
        lHand = transform.Find("Default/Root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l/hand_l");
        rHand = transform.Find("Default/Root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r");
    }
    void Start()
    {
        EquipItems();
    }

    public void PickUpItem(Collider obj, string arm)
    {
        float dist = Vector3.Distance(character.transform.position, obj.transform.position);
        if (dist <= 3)
        {
            GameObject item = obj.gameObject;
            obj.isTrigger = true;
            anim.Take();
            switch (arm)
            {
                case "r":
                    EquipWeapon(item);
                    break;
                case "l":
                     EquipItem(item);
                    break;
            }
        }
    }

    public void EquipItems()
    {
        UnitModel model = UnitsList.Get(charact.unit, charact.level);

        if(model.rItem != null && charact.rItem != model.rItem)
        {
            Object res = Resources.Load("Objects/Static/Items/Prefabs/" + model.rItem);
            if (res)
            {
                GameObject obj = Instantiate(res) as GameObject;
                obj.GetComponent<Item>().isSelected = true;
                obj.name = model.rItem;
                RemoveOldItem(charact.rItem);
                EquipWeapon(obj);
            }
            charact.rItem = model.rItem;
        }

        if (model.lItem != null && charact.lItem != model.lItem)
        {
            Object res = Resources.Load("Objects/Static/Items/Prefabs/" + model.lItem);
            if (res)
            {
                GameObject obj = Instantiate(res) as GameObject;
                obj.GetComponent<Item>().isSelected = true;
                obj.name = model.rItem;
                RemoveOldItem(charact.rItem);
                EquipItem(obj);
            }
            charact.lItem = model.lItem;
        }


        if (model.head != null && charact.head != model.head)
        {
            headObj.GetComponent<SkinnedMeshRenderer>().enabled = false;
            RemoveOldItem(charact.head);
            EquipArmor(model.head);
            charact.head = model.head;
        }
        if (model.body != null && charact.body != model.body)
        {
            bodyObj.GetComponent<SkinnedMeshRenderer>().enabled = false;
            RemoveOldItem(charact.body);
            EquipArmor(model.body);
            charact.body = model.body;
        }
        if (model.pants != null && charact.pants != model.pants)
        {
            rlegObj.GetComponent<SkinnedMeshRenderer>().enabled = false;
            llegObj.GetComponent<SkinnedMeshRenderer>().enabled = false;
            RemoveOldItem(charact.pants);
            EquipArmor(model.pants);
            charact.pants = model.pants;
        }
        if (model.shirt != null && charact.shirt != model.shirt)
        {
            rarmObj.GetComponent<SkinnedMeshRenderer>().enabled = false;
            larmObj.GetComponent<SkinnedMeshRenderer>().enabled = false;
            RemoveOldItem(charact.shirt);
            EquipArmor(model.shirt);
            charact.shirt = model.shirt;
        }
        if (model.boots != null && charact.boots != model.boots)
        {
            RemoveOldItem(charact.boots);
            EquipArmor(model.boots);
            charact.boots = model.boots;
        }
        if (model.gloves != null && charact.gloves != model.gloves)
        {
            RemoveOldItem(charact.gloves);
            EquipArmor(model.gloves);
            charact.gloves = model.gloves;
        }
        if (model.shoulderPads != null && charact.shoulderPads != model.shoulderPads)
        {
            RemoveOldItem(charact.shoulderPads);
            EquipArmor(model.shoulderPads);
            charact.shoulderPads = model.shoulderPads;
        }

        SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(SkinnedMeshRenderer mesh in meshes)
        {
            mesh.updateWhenOffscreen = true;
        }

    }


    private void RemoveOldItem(string item)
    {
        Transform go = gameObject.transform.Find(item + "(Clone)");
        if (go) Destroy(go.gameObject);
    }

    private void EquipWeapon(GameObject item)
    {
        Item oldItem = rHand.GetComponentInChildren<Item>();
        if (oldItem) oldItem.Drop();

        WeaponModel model = WeaponsList.Get(item.name);
        charact.weaponType = model.type;
        charact.damage = model.damage;
        item.GetComponent<Item>().Get(rHand, new Vector3(-0.002f, 0.007f, 0.003f), Quaternion.Euler(-12f, -200f, model.zRotate));
        item.GetComponent<Weapon>().Set(charact);
    }
    private void EquipArmor(string item)
    {
        ArmorModel model = ArmorsList.Get(item);
        RenderMeshes(model.meshes);
    }

    private void EquipItem(GameObject item)
    {
        Item oldItem = lHand.GetComponentInChildren<Item>();
        if (oldItem)
        {
            charact.weaponType = "shield";
            oldItem.Drop();
        }
        

        Vector3 pos = new Vector3(0.004f, 0.0068f, 0.0078f);
        Quaternion rot = Quaternion.Euler(175, 58, 75);
        if (item.tag == "shield")
        {
            pos = new Vector3(-0.0022f, 0.0063f, 0.005f);
            rot = Quaternion.Euler(-7.7f, -1.816f, -8.574f);
            ArmorModel model = ArmorsList.Get(item.name);
            charact.AP = model.AP;
            charact.weaponType = "shield";
        }
        item.GetComponent<Item>().Get(lHand, pos, rot);
    }

    private void RenderMeshes(List<GameObject> meshes)
    {
        
        foreach (GameObject mesh in meshes)
        {
            if (mesh != null)
            {
                GameObject obj = Instantiate(mesh);
                obj.transform.SetParent(playerSkin.transform.parent);
                SkinnedMeshRenderer[] renderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>();
                if (renderers.Length > 0)
                {
                    foreach (SkinnedMeshRenderer skinMesh in renderers)
                    {
                        skinMesh.bones = playerSkin.bones;
                        skinMesh.rootBone = playerSkin.rootBone;
                    }
                }
            }
        }
        
    }
}
