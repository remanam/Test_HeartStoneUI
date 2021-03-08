using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Singletone
    public static GameController instance;

    public RectTransform dropTable;

    public GameObject completeImage;

    public Canvas canvas;

    public CardHeap cardHeap;

    public PlayerHand playerHand;

    private void MakeSingleton()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;          
        }
    }

    private void Awake()
    {
        MakeSingleton();
        cardHeap = GetComponent<CardHeap>();

        completeImage.SetActive(false);

    }


    //Debug
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Draw DropTable
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Vector3[] corners = new Vector3[4];
        dropTable.GetWorldCorners(corners);

        Gizmos.DrawLine(corners[0], corners[1]);
        Gizmos.DrawLine(corners[1], corners[2]);
        Gizmos.DrawLine(corners[2], corners[3]);     
        Gizmos.DrawLine(corners[3], corners[0]);
    }
    //End Debug
}
