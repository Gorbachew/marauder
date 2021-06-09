using UnityEngine;

public class ArmorsList
{
    public static ArmorModel Get(string name)
    {
        ArmorModel item = new ArmorModel();
        switch (name)
        {

            case "peasant_head":
                item.name = "Крестьянская шляпа";
                item.price = 10;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/peasant/peasant_head") as GameObject);
                break;
            case "peasant_body":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/peasant/peasant_body") as GameObject);
                break;
            case "peasant_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/peasant/peasant_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/peasant/peasant_larm") as GameObject);
                break;
            case "peasant_pants":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/peasant/peasant_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/peasant/peasant_rleg") as GameObject);
                break;
            case "peasant_boots":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/peasant/peasant_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/peasant/peasant_rboot") as GameObject);
                break;

            case "thief_head":
                item.name = "Воровской капюшон";
                item.price = 100;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/Thief/thief_head") as GameObject);
                break;
            case "thief_body":
                item.name = "Воровской жилет";
                item.price = 100;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/Thief/thief_body") as GameObject);
                break;
            case "thief_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/Thief/thief_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/Thief/thief_larm") as GameObject);
                break;
            case "thief_pants":
                item.name = "Воровские штаны";
                item.price = 100;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/Thief/thief_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/Thief/thief_rleg") as GameObject);
                break;
            case "thief_boots":
                item.name = "Воровские ботинки";
                item.price = 100;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/Thief/thief_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/Thief/thief_rboot") as GameObject);
                break;  

            case "characterInitial_head":
                item.name = "Без головного убора";
                item.price = 0;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_head") as GameObject);
                break;
            case "characterInitial_body":
                item.name = "Без верхней одежды";
                item.price = 0;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_body") as GameObject);
                break;
            case "characterInitial_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_larm") as GameObject);
                break;
            case "characterInitial_pants":
                item.name = "Без штанов";
                item.price = 0;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_rleg") as GameObject);
                break;
            case "characterInitial_boots":
                item.name = "Без ботинок";
                item.price = 0;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/characterInitial/characterInitial_rboot") as GameObject);
                break;
            case "characterInitial_gloves":
                item.name = "Без перчаток";
                item.price = 0;
                item.defence = 0;
                item.fineSpeed = 0;
                break;
            case "characterInitial_shoulderPads":
                item.name = "Без наплечников";
                item.price = 0;
                item.defence = 0;
                item.fineSpeed = 0;
                break;
            case "characterInitial_lItem":
                item.name = "Без щита";
                item.price = 0;
                item.defence = 0;
                item.fineSpeed = 0;
                break;

            case "leather_head":
                item.name = "Кожаная шапка";
                item.price = 500;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_head") as GameObject);
                break;
            case "leather_body":
                item.name = "Кожаная куртка";
                item.price = 500;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_body") as GameObject);
                break;
            case "leather_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/leather/leather_larm") as GameObject);
                break;
            case "leather_pants":
                item.name = "Кожаные штаны";
                item.price = 500;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/leather/leather_rleg") as GameObject);
                break;
            case "leather_boots":
                item.name = "Кожаная ботинки";
                item.price = 500;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/leather/leather_rboot") as GameObject);
                break;
            case "leather_gloves":
                item.name = "Кожаные перчатки";
                item.price = 500;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_lglove") as GameObject);
                item.meshes.Add(Resources.Load("Items/leather/leather_rglove") as GameObject);
                break;
            case "leather_shoulderPads":
                item.name = "Кожаная наплечники";
                item.price = 500;
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/leather_lshoulderpad") as GameObject);
                item.meshes.Add(Resources.Load("Items/leather/leather_rshoulderpad") as GameObject);
                break;


            case "round_shield":
                item.defence = 1;
                item.AP = 20;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/leather/round_shield") as GameObject);
                break;


            case "smith_head":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/smith/smith_head") as GameObject);
                break;
            case "smith_body":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/smith/smith_body") as GameObject);
                break;
            case "smith_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/smith/smith_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/smith/smith_larm") as GameObject);
                break;
            case "smith_pants":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/smith/smith_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/smith/smith_rleg") as GameObject);
                break;
            case "smith_boots":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/smith/smith_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/smith/smith_rboot") as GameObject);
                break;
            case "smith_gloves":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/smith/smith_lglove") as GameObject);
                item.meshes.Add(Resources.Load("Items/smith/smith_rglove") as GameObject);
                break;

            case "armorer_head":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/armorer/armorer_head") as GameObject);
                break;
            case "armorer_body":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/armorer/armorer_body") as GameObject);
                break;
            case "armorer_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/armorer/armorer_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/armorer/armorer_larm") as GameObject);
                break;
            case "armorer_pants":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/armorer/armorer_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/armorer/armorer_rleg") as GameObject);
                break;
            case "armorer_boots":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/armorer/armorer_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/armorer/armorer_rboot") as GameObject);
                break;

            case "barman_head":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/barman/barman_head") as GameObject);
                break;
            case "barman_body":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/barman/barman_body") as GameObject);
                break;
            case "barman_shirt":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/barman/barman_rarm") as GameObject);
                item.meshes.Add(Resources.Load("Items/barman/barman_larm") as GameObject);
                break;
            case "barman_pants":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/barman/barman_lleg") as GameObject);
                item.meshes.Add(Resources.Load("Items/barman/barman_rleg") as GameObject);
                break;
            case "barman_boots":
                item.defence = 1;
                item.fineSpeed = 0;
                item.meshes.Add(Resources.Load("Items/barman/barman_lboot") as GameObject);
                item.meshes.Add(Resources.Load("Items/barman/barman_rboot") as GameObject);
                break;

        }
        return item;
    }
}
