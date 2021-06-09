using UnityEngine;

public class WeaponsList
{
    public static WeaponModel Get(string name)
    {
        WeaponModel weapon = new WeaponModel();
        switch (name)
        {
            case "arms":
                weapon.name = "������";
                weapon.price = 0;
                weapon.damage = 1;
                weapon.zRotate = 0;
                weapon.type = "arms";
                break;
            case "smith_hammer":
                weapon.name = "������� �������";
                weapon.price = 500;
                weapon.damage = 2;
                weapon.zRotate = 0;
                weapon.type = "oneHanded";
                break;
            case "iron_sword":
                weapon.name = "�������� ���";
                weapon.price = 1500;
                weapon.damage = 5;
                weapon.zRotate = 90;
                weapon.type = "oneHanded";
                break;
            case "iron_axe":
                weapon.name = "�������� �����";
                weapon.price = 0500;
                weapon.damage = 4;
                weapon.zRotate = 180;
                weapon.type = "oneHanded";
                break;
        }
        return weapon;
    }
}
