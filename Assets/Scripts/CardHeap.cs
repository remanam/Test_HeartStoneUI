using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHeap : MonoBehaviour
{
    // array of possible cards
    [SerializeField]
    private GameObject[] cardPrefabs;

    public GameObject GetRandomCard()
    {
        int i = Random.Range(0, cardPrefabs.Length);
        return cardPrefabs[i];
    }


}
