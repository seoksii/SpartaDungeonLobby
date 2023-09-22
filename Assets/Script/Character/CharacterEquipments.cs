using UnityEngine;

public class CharacterEquipments : MonoBehaviour
{
    [SerializeField]
    ItemInfo[] items;

    private void Awake()
    {
        items = new ItemInfo[System.Enum.GetValues(typeof(ItemType)).Length];
    }

    public ItemInfo GetItemInfo(ItemType type)
    {
        return items[(int)type];
    }

    public void AddEquipment(ItemInfo itemInfo)
    {
        items[(int)itemInfo.BasicInfo.ItemType] = itemInfo;
    }

    public void RemoveEquipment(ItemInfo itemInfo)
    {
        items[(int)itemInfo.BasicInfo.ItemType] = null;
    }
}
