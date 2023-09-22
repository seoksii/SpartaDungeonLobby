using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentScrollView : MonoBehaviour
{
    private List<GameObject> itemPanels;
    [SerializeField]
    private RectTransform Content;

    [SerializeField]
    private GameObject itemPanelPrefab;
    private Inventory inventory;

    private void Awake()
    {
        itemPanels = new List<GameObject>();
    }

    private IEnumerator Start()
    {
        yield return null;
        inventory = CharacterManager.CurrentCharacter.CharacterInventory;
        foreach (ItemInfo item in inventory.Items)
            AddNewPanel(item); 
    }

    private void Update()
    {
        UpdateIsEquipped();
    }

    public void AddNewPanel(ItemInfo item)
    {
        GameObject newPanel = Instantiate(itemPanelPrefab, Content);

        newPanel.transform.GetChild(0).GetComponent<Image>().sprite = item.BasicInfo.UiSprite;
        newPanel.transform.GetChild(1).GetComponent<Text>().text = item.BasicInfo.ItemName;
        newPanel.transform.GetChild(2).GetComponent<Text>().text = item.GetStatText();
        newPanel.GetComponent<Button>().onClick.AddListener(() => CharacterManager.CurrentCharacter.EquipItem(item));

        itemPanels.Add(newPanel);
    }

    public void UpdateIsEquipped()
    {
        for (int i = 0; i < itemPanels.Count; ++i)
        {
            itemPanels[i].transform.GetChild(3).gameObject.SetActive(inventory.Items[i].isEquipped);
        }
    }
}
