using UnityEngine;

[CreateAssetMenu(fileName = "ItemBasicInfo", menuName = "Scriptable Object/ItemBasicInfo", order = int.MinValue + 1)]
public class SO_ItemBasicInfo : ScriptableObject
{
    [Header("Item Info")]
    [SerializeField]
    private Sprite _uiSprite;
    public Sprite UiSprite {  get { return _uiSprite; } }
    [SerializeField]
    private ItemType _itemType;
    public ItemType ItemType { get { return _itemType; } }
    [SerializeField]
    private string _itemName;
    public string ItemName { get { return _itemName; } }
    [SerializeField]
    private string _itemDescription;
    public string ItemDescription { get { return _itemDescription; } }

    [Header("Item Stat")]
    [SerializeField]
    private int _attack;
    public int Attack { get { return _attack; } }
    [SerializeField]
    private int _defense;
    public int Defense { get { return _defense; } }
    [SerializeField]
    private int _maxHp;
    public int MaxHp { get { return _maxHp; } }
    [SerializeField]
    private float _critChance;
    public float CritChance { get { return _critChance; } }
}
