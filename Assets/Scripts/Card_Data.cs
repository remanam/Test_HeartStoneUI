using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New CardData", menuName = "Card Data", order = 51)]
public class Card_Data : ScriptableObject
{
    [SerializeField]
    private string title;

    [SerializeField]
    private string mana_Cost;

    [SerializeField]
    private string damage_Points;

    [SerializeField]
    private string health_Points;


    public string GetTitle()
    {
        return title;
    }

    public string GetManaPoints()
    {
        return mana_Cost;
    }

    public string GetDamagePoints()
    {
        return damage_Points;
    }
    public string GetHealhPoints()
    {
        return health_Points;
    }
}
