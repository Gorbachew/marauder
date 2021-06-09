
public class UnitsList
{

    public static UnitModel Get(string unit, int level)
    {
        UnitModel item = new UnitModel();
        switch (unit)
        {

            case "character":
                switch (level)
                {
                    case 1:
                        item.rItem = SaveState.rItem;
                        item.lItem = SaveState.lItem;
                        item.head = SaveState.head;
                        item.body = SaveState.body;
                        item.shirt = SaveState.shirt;
                        item.pants = SaveState.pants;
                        item.boots = SaveState.boots;
                        item.gloves = SaveState.gloves;
                        item.shoulderPads = SaveState.shoulderPads;
                        break;

                }
                break;

            case "thief":
                switch (level)
                {
                    case 1:
                        item.rItem = "arms";
                        item.pants = "thief_pants";
                        item.body = "thief_body";
                        item.boots = "barman_boots";
                        break;
                    case 2:
                        item.rItem = "iron_sword";
                        item.body = "thief_body";
                        item.shirt = "thief_shirt";
                        item.pants = "thief_pants";
                        item.boots = "thief_boots";
                        break;
                    case 3:
                        item.rItem = "iron_sword";
                        item.head = "thief_head";
                        item.body = "thief_body";
                        item.shirt = "thief_shirt";
                        item.pants = "thief_pants";
                        item.boots = "thief_boots";
                        break;
                }
                break;

            case "barman":
                item.rItem = "arms";
                item.head = "barman_head";
                item.body = "barman_body";
                item.shirt = "barman_shirt";
                item.pants = "barman_pants";
                item.boots = "barman_boots";
                break;

            case "smith":
                item.rItem = "smith_hammer";
                item.head = "smith_head";
                item.body = "smith_body";
                item.shirt = "smith_shirt";
                item.pants = "smith_pants";
                item.boots = "smith_boots";
                item.gloves = "smith_gloves";
                break;

            case "armorer":
                item.rItem = "arms";
                item.head = "armorer_head";
                item.body = "armorer_body";
                item.shirt = "armorer_shirt";
                item.pants = "armorer_pants";
                item.boots = "armorer_boots";
                break;

            case "peasant":
                switch (level)
                {
                    case 1:
                        item.rItem = "arms";
                        item.pants = "peasant_pants";
                        break;
                    case 2:
                        item.rItem = "arms";
                        item.head = "peasant_head";
                        item.pants = "peasant_pants";
                        item.boots = "peasant_boots";
                        break;
                    case 3:
                        item.rItem = "arms";
                        item.head = "peasant_head";
                        item.body = "peasant_body";
                        item.shirt = "peasant_shirt";
                        item.pants = "peasant_pants";
                        item.boots = "peasant_boots";
                        break;
                }
                break;

            case "citizen":
                switch (level)
                {
                    case 1:
                        item.rItem = "arms";
                        item.head = "smith_head";
                        item.body = "characterInitial_body";
                        item.pants = "barman_pants";
                        item.boots = "smith_boots";
                        break;
                    case 2:
                        item.rItem = "arms";
                        item.body = "peasant_body";
                        item.shirt = "barman_shirt";
                        item.pants = "smith_pants";
                        item.boots = "barman_boots";
                        break;
                    case 3:
                        item.rItem = "arms";
                        item.head = "characterInitial_head";
                        item.body = "armorer_body";
                        item.shirt = "armorer_shirt";
                        item.pants = "thief_pants";
                        item.boots = "peasant_boots";
                        break;
                    case 4:
                        item.rItem = "arms";
                        item.head = "barman_head";
                        item.body = "thief_body";
                        item.shirt = "armorer_shirt";
                        item.pants = "armorer_pants";
                        item.boots = "armorer_boots";
                        break;
                }
                break;

            case "coachman":
                switch (level)
                {
                    case 1:
                        item.rItem = "arms";
                        item.head = "thief_head";
                        item.body = "thief_body";
                        item.shirt = "thief_shirt";
                        item.pants = "thief_pants";
                        item.boots = "thief_boots";
                        break;

                }
                break;

            case "footman":
                switch (level)
                {
                    case 1:
                        item.rItem = "iron_axe";
                        item.head = "leather_head";
                        item.body = "leather_body";
                        item.shirt = "leather_shirt";
                        item.pants = "leather_pants";
                        item.boots = "leather_boots";
                        item.gloves = "leather_gloves";
                        item.shoulderPads = "leather_shoulderPads";
                        item.lItem = "round_shield";
                        break;

                }
                break;

            case "trainer":
                switch (level)
                {
                    case 1:
                        item.rItem = "iron_sword";
                        item.lItem = "round_shield";
                        item.head = "smith_head";
                        item.body = "leather_body";
                        item.shirt = "leather_shirt";
                        item.pants = "leather_pants";
                        item.boots = "leather_boots";
                        item.gloves = "leather_gloves";
                        item.shoulderPads = "leather_shoulderPads";
                        break;

                }
                break;

        }
        return item;
    }
}
