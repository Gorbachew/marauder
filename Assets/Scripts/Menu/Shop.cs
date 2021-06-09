using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private string category;
    ItemController itemController;
    UI ui;
    [SerializeField]
    private int itemIndex;

    private void Awake()
    {
        ui = GetComponent<UI>();
        itemController = GameObject.FindGameObjectWithTag("character").GetComponent<ItemController>();
    }

    public void SetCategory(string category)
    {
        this.category = category;
        SetItemInfo();
    }

    public void SetNextItem()
    {
        itemIndex++;
        SetItems();
        itemController.EquipItems();
    }

    public void SetPrevItem()
    {
        itemIndex--;
        SetItems();
        SaveState.head = ShopList.head_armors[itemIndex];
        itemController.EquipItems();
    }


    private void SetItems()
    {
        if (itemIndex < 0) itemIndex = 0;
        switch (category)
        {
            case "Helm":
                if (itemIndex > ShopList.head_armors.Count - 1) itemIndex--;
                SaveState.head = ShopList.head_armors[itemIndex];
                break;
            case "Body":
                if (itemIndex > ShopList.body_armors.Count - 1) itemIndex--;
                SaveState.body = ShopList.body_armors[itemIndex];
                break;
            case "Pants":
                if (itemIndex > ShopList.pants_armors.Count - 1) itemIndex--;
                SaveState.pants = ShopList.pants_armors[itemIndex];
                break;
            case "Boots":
                if (itemIndex > ShopList.boots_armors.Count - 1) itemIndex--;
                SaveState.boots = ShopList.boots_armors[itemIndex];
                break;
            case "ShoulderPads":
                if (itemIndex > ShopList.shoulderPads_armors.Count - 1) itemIndex--;
                SaveState.shoulderPads = ShopList.shoulderPads_armors[itemIndex];
                break;
            case "Gloves":
                if (itemIndex > ShopList.gloves_armors.Count - 1) itemIndex--;
                SaveState.gloves = ShopList.gloves_armors[itemIndex];
                break;
            case "Shield":
                if (itemIndex > ShopList.shields.Count - 1) itemIndex--;
                SaveState.lItem = ShopList.shields[itemIndex];
                break;
            case "Weapon":
                if (itemIndex > ShopList.weapons.Count - 1) itemIndex--;
                SaveState.rItem = ShopList.weapons[itemIndex];
                break;
        }
    }

    private void SetItemInfo()
    {
        if (category != "Weapon")
        {
            ArmorModel am;
            switch (category)
            {
                case "Helm":
                    itemIndex = ShopList.head_armors.IndexOf(SaveState.head);
                    am = ArmorsList.Get(SaveState.head);
                    break;
                case "Body":
                    itemIndex = ShopList.body_armors.IndexOf(SaveState.body);
                    am = ArmorsList.Get(SaveState.body);
                    break;
                case "Pants":
                    itemIndex = ShopList.pants_armors.IndexOf(SaveState.pants);
                    am = ArmorsList.Get(SaveState.pants);
                    break;
                case "Boots":
                    itemIndex = ShopList.boots_armors.IndexOf(SaveState.boots);
                    am = ArmorsList.Get(SaveState.boots);
                    break;
                case "ShoulderPads":
                    itemIndex = ShopList.shoulderPads_armors.IndexOf(SaveState.shoulderPads);
                    am = ArmorsList.Get(SaveState.shoulderPads);
                    break;
                case "Gloves":
                    itemIndex = ShopList.gloves_armors.IndexOf(SaveState.gloves);
                    am = ArmorsList.Get(SaveState.gloves);
                    break;
                case "Shield":
                    itemIndex = ShopList.shields.IndexOf(SaveState.lItem);
                    am = ArmorsList.Get(SaveState.lItem);
                    break;
                default:
                    am = ArmorsList.Get(SaveState.head);
                    break;
            }
            ui.SetShopItem(am.name, am.price);

        } else
        {
            WeaponModel wm;
            switch (category)
            {
                case "Weapon":
                    itemIndex = ShopList.weapons.IndexOf(SaveState.rItem);
                    wm = WeaponsList.Get(SaveState.rItem);
                    break;
                default:
                    wm = WeaponsList.Get(SaveState.head);
                    break;
            }
            ui.SetShopItem(wm.name, wm.price);
        }

        
        
    }
}
