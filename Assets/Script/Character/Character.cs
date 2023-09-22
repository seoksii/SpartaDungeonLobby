using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Transform CharacterSprite;
    [HideInInspector]
    public CharacterStats CharacterStat;
    [HideInInspector]
    public CharacterEquipments CharacterEquipment;
    [HideInInspector]
    public Inventory CharacterInventory;

    private void Awake()
    {
        CharacterSprite = transform.GetChild(0);
        CharacterStat = transform.GetChild(1).GetComponent<CharacterStats>();
        CharacterEquipment = transform.GetChild(2).GetComponent<CharacterEquipments>();
        CharacterInventory = transform.GetChild(3).GetComponent<Inventory>();
    }

    public ItemInfo EquipItem(ItemInfo itemInfo)
    {
        ItemInfo prevItem = CharacterEquipment.GetItemInfo(itemInfo.BasicInfo.ItemType);

        if (prevItem != null)
        {
            CharacterStat.RemoveStats(prevItem);
            prevItem.isEquipped = false;
            CharacterEquipment.RemoveEquipment(prevItem);
        }
        if (prevItem == itemInfo)
            return itemInfo;
        CharacterStat.AddStats(itemInfo);
        CharacterEquipment.AddEquipment(itemInfo);
        itemInfo.isEquipped = true;

        return itemInfo;
    }
}
