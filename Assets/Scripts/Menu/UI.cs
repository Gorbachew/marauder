using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    Button btnStart, btnAttack, btnShopExit, btnPrev, btnNext;
    Button btnHelm, btnBody, btnPants, btnBoots, btnShoulderPads, btnGloves, btnWeapon, btnShield;
    Text textItemName, textItemPrice;
    CameraController cameraController;
    [SerializeField]
    GameObject character;
    FightController fightController;
    GameObject menuUI, gameUI, shopUI;
    GameObject smithUI, armorerUI;
    Shop shop;

    private void Awake()
    {
        shop = GetComponent<Shop>();
        cameraController = Camera.main.GetComponent<CameraController>();
        btnStart.onClick.AddListener(BtnStartOnClick);
        btnAttack.onClick.AddListener(BtnAttackOnClick);
        shopUI = transform.Find("Shop").gameObject;
        menuUI = transform.Find("Menu").gameObject;
        gameUI = transform.Find("Game").gameObject;
        smithUI = shopUI.transform.Find("Smith").gameObject;
        armorerUI = shopUI.transform.Find("Armorer").gameObject;

        btnShopExit = shopUI.transform.Find("btnExit").GetComponent<Button>();

        textItemName = shopUI.transform.Find("textItemName").GetComponent<Text>();
        textItemPrice = shopUI.transform.Find("textItemPrice").GetComponent<Text>();

        btnPrev = shopUI.transform.Find("btnPrev").GetComponent<Button>();
        btnNext = shopUI.transform.Find("btnNext").GetComponent<Button>();

        btnHelm = armorerUI.transform.Find("btnHelm").GetComponent<Button>();
        btnBody = armorerUI.transform.Find("btnBody").GetComponent<Button>();
        btnPants = armorerUI.transform.Find("btnPants").GetComponent<Button>();
        btnBoots = armorerUI.transform.Find("btnBoots").GetComponent<Button>();
        btnShoulderPads = armorerUI.transform.Find("btnShoulderPads").GetComponent<Button>();
        btnGloves = armorerUI.transform.Find("btnGloves").GetComponent<Button>();

        btnWeapon = smithUI.transform.Find("btnWeapon").GetComponent<Button>();
        btnShield = smithUI.transform.Find("btnShield").GetComponent<Button>();

        btnPrev.onClick.AddListener(BtnPrevOnClick);
        btnNext.onClick.AddListener(BtnNextOnClick);

        btnHelm.onClick.AddListener(BtnHelmOnClick);
        btnBody.onClick.AddListener(BtnBodyOnClick);
        btnPants.onClick.AddListener(BtnPantsOnClick);
        btnBoots.onClick.AddListener(BtnBootstOnClick);
        btnShoulderPads.onClick.AddListener(BtnShoulderOnClick);
        btnGloves.onClick.AddListener(BtnGlovesOnClick);

        btnWeapon.onClick.AddListener(BtnWeaponOnClick);
        btnShield.onClick.AddListener(BtnShieldOnClick);

        btnShopExit.onClick.AddListener(BtnShopExitOnClick);
        fightController = character.GetComponent<FightController>();
    }

    void Start()
    {
        SwitchGameUI(false);
        SwitchShopUI("", false);
    }

    public void SwitchGameUI(bool value)
    {
        gameUI.SetActive(value);
    }

    public void SwitchShopUI(string who, bool value)
    {
        switch (who)
        {
            case "smith":
                shop.SetCategory("Weapon");
                SwitchSmithUI(true);
                SwitchArmorerUI(false);
                break;
            case "armorer":
                shop.SetCategory("Helm");
                SwitchSmithUI(false);
                SwitchArmorerUI(true);
                break;
            default:
                SwitchSmithUI(false);
                SwitchArmorerUI(false);
                break;

        }
        shopUI.SetActive(value);
    }

    public void SetShopItem(string name, int price)
    {
        textItemName.text = name;
        textItemPrice.text = price.ToString();
    }

    private void SwitchSmithUI(bool value)
    {
        
        smithUI.SetActive(value);
    }
    private void SwitchArmorerUI(bool value)
    {
        armorerUI.SetActive(value);
    }

    public void BtnBlockOnClick(bool value)
    {
        fightController.Block(value);
    }

    private void BtnStartOnClick()
    {
        StartCoroutine(cameraController.StartSpan());
        menuUI.SetActive(false);
    }

    private void BtnAttackOnClick()
    {
        fightController.Attack();
    }

    private void BtnShopExitOnClick()
    {
        StartCoroutine(cameraController.StartSpan());
    }


    private void BtnNextOnClick()
    {
        shop.SetNextItem();
    }

    private void BtnPrevOnClick()
    {
        shop.SetPrevItem();
    }

    private void BtnHelmOnClick()
    {
        shop.SetCategory("Helm");
    }

    private void BtnBodyOnClick()
    {
        shop.SetCategory("Body");
    }

    private void BtnPantsOnClick()
    {
        shop.SetCategory("Pants");
    }

    private void BtnBootstOnClick()
    {
        shop.SetCategory("Boots");
    }
    private void BtnShoulderOnClick()
    {
        shop.SetCategory("ShoulderPads");
    }

    private void BtnGlovesOnClick()
    {
        shop.SetCategory("Gloves");
    }


    private void BtnShieldOnClick()
    {
        shop.SetCategory("Shield");
    }

    private void BtnWeaponOnClick()
    {
        shop.SetCategory("Weapon");
    }




}
