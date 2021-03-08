using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private int minCardCount;

    [SerializeField]
    private int maxCardCount;

    public Transform[] cardPositions;

    [SerializeField]
    private List<GameObject> cardsInHand = new List<GameObject>();

    private int cardIndex = 0;

    private int startCardCount = 0;


    private void Start()
    {
        startCardCount = GetStartCardCount();

        InitCardsInHand();
    }

    private void Update()
    {
        if (cardsInHand.Count == 0) {
            StartCoroutine(FinishGame(1f));
            
        }
    }

    // LateUpdate need if i press "Change Card"  my CheckIfCardDEad() doesn't execute because after destroy Health = 0 in current frame
    private void LateUpdate()
    {

        CheckForSort();
    }

    private IEnumerator FinishGame(float delay)
    {
        GameController.instance.completeImage.SetActive(true);

        yield return new WaitForSeconds(delay);

        GameController.instance.RestartScene();
    }


    private void CheckForSort()
    {
        for (int i = 0; i < cardsInHand.Count; i++) {

            //Health  <= 0
            if (cardsInHand[i].GetComponent<Card>().GetHealth() <= 0 && cardsInHand[i] != null) {

                var elemToDestroy = cardsInHand[i];

                cardsInHand.Remove(cardsInHand[i]);
                Destroy(elemToDestroy);
                

            }

        }
    }

    private void SortCards(int from, float sortSpeed)
    {
        for (int i = from; i < cardsInHand.Count; i++) {

            cardsInHand[i].transform.DOMove(cardPositions[i].position, sortSpeed);
            cardsInHand[i].transform.rotation = cardPositions[i].rotation;
        }
    }

    // Change card from left to right
    public void changeCard()
    {

        Destroy(cardsInHand[cardIndex]);

        cardsInHand[cardIndex] = InitRandomCard(cardIndex);

        if (cardIndex + 1 > cardsInHand.Count - 1) {
            cardIndex = 0;
        }
        else {
            cardIndex++;
        }
    }

    public void killRandomCard()
    {
        int index = Random.Range(0, cardsInHand.Count);

        cardsInHand[index].GetComponent<Card>().SetHealth(0);
    }

    // Initialize Player cards
    private void InitCardsInHand()
    {
        for (int i = 0; i < startCardCount; i++) {


            cardsInHand.Add(InitRandomCard(i));
        }
    }

    // Return 1 random card from CardHeap
    private GameObject InitRandomCard(int cardPosIndex)
    {
        // Get random cardPrefab 
        GameObject obj = GameController.instance.cardHeap.GetRandomCard();
        obj.transform.position = cardPositions[cardPosIndex].position; //set transform to our cardInHandPositions
        obj.transform.rotation = cardPositions[cardPosIndex].rotation;

        // instantiate object, parent is canvas
        var newCard = Instantiate(obj, obj.transform.position = cardPositions[cardPosIndex].position, obj.transform.rotation = cardPositions[cardPosIndex].rotation,
                                                  GameController.instance.canvas.transform);
        return newCard;
    }

    
    public int GetStartCardCount()
    {
        int i = Random.Range(minCardCount, maxCardCount + 1); // +1 doesn't include

        return i;
    }


}
