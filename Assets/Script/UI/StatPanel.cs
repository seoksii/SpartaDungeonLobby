using UnityEngine;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    [SerializeField] private Text _attack;
    [SerializeField] private Text _defense;
    [SerializeField] private Text _maxHp;
    [SerializeField] private Text _critChance;

    private void Update()
    {
        Character character = CharacterManager.CurrentCharacter;
        if (character == null) return;

        CharacterStats stats = character.CharacterStat.GetComponent<CharacterStats>();

        _attack.text = stats.TotalStat_attack.ToString();
        _defense.text = stats.TotalStat_Defense.ToString();
        _maxHp.text = stats.TotalStat_MaxHp.ToString();
        _critChance.text = stats.TotalStat_CritChance.ToString("F0");
    }
}
