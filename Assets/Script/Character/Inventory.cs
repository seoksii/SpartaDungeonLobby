using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemInfo> Items;
    [SerializeField]
    private SO_ItemBasicInfo[] defaultItems;

    private void Start()
    {
        Items = new List<ItemInfo>();
        foreach (SO_ItemBasicInfo itemBasicInfo in defaultItems)
        {
            ItemInfo newItem = Instantiate(GameManager.Instance.ItemPrefab).GetComponent<ItemInfo>();
            newItem.BasicInfo = itemBasicInfo;
            newItem.isEquipped = false;
            Items.Add(newItem);
        }
    }
}
