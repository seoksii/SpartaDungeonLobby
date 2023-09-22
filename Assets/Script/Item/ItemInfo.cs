using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public SO_ItemBasicInfo BasicInfo;
    public bool isEquipped;

    public string GetStatText()
    {
        return (BasicInfo.Attack != 0 ? $" 공격력 +{BasicInfo.Attack.ToString()}" : "")
            + (BasicInfo.Defense != 0 ? $" 방어력 +{BasicInfo.Defense.ToString()}" : "")
            + (BasicInfo.MaxHp != 0 ? $" 최대체력 +{BasicInfo.MaxHp.ToString()}" : "")
            + (BasicInfo.CritChance != 0f ? $" 크리티컬 +{BasicInfo.CritChance.ToString("F1")}" : "");
    }
}
