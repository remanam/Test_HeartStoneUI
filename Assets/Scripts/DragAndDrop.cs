using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IDropHandler
{

    // need to multiply drag value on canvas scale
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private RectTransform card_RectTransform; // need to get corners of whole card

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private bool isOnTable = false;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();

        defaultPosition = rectTransform.localPosition;
        defaultRotation = rectTransform.localRotation;

        

    }

    private void Start()
    {

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        GetComponent<Card>().setSelected(true);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;

        rectTransform.localPosition += new Vector3(eventData.delta.x / canvas.scaleFactor, eventData.delta.y / canvas.scaleFactor, 0);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GetComponent<Card>().setSelected(false);

        if ( isOnTable == true) {
            Debug.Log("Dropped card on table");
        }
        else {
            rectTransform.localRotation = defaultRotation;
            rectTransform.localPosition = defaultPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Card>().setSelected(false);

        if (isOnTable == false)
            rectTransform.localRotation = defaultRotation;
    }

    
    //Debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = UnityEngine.Color.red;

        Vector3[] corners = new Vector3[4];
        //card_RectTransform.GetWorldCorners(corners);

        Gizmos.DrawLine(corners[0], corners[1]);
        Gizmos.DrawLine(corners[1], corners[2]);
        Gizmos.DrawLine(corners[2], corners[3]);
        Gizmos.DrawLine(corners[3], corners[0]);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagsHolder.dropTable) == true) {

            Debug.Log("Entered " + TagsHolder.dropTable);

            isOnTable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagsHolder.dropTable) == true) {

            isOnTable = false;
        }
        
    }


}
