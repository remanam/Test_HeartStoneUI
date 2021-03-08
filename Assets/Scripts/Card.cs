using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Card_Data card_Data;

    [SerializeField]
    private Image selectedCard;

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private TextMeshProUGUI manaPoints;

    [SerializeField]
    private TextMeshProUGUI damagePoints;

    [SerializeField]
    private TextMeshProUGUI healthPoints;

    private Animator anim;


    private void Start()
    {
        title.text = card_Data.GetTitle();
        manaPoints.text = card_Data.GetManaPoints();
        damagePoints.text = card_Data.GetDamagePoints();
        healthPoints.text = card_Data.GetHealhPoints();

        selectedCard.gameObject.SetActive(false);

        anim = GetComponent<Animator>();
      
    }

    public void setSelected(bool b)
    {
        selectedCard.gameObject.SetActive(b);
    }


    private void OnManaChanged(int amount)
    {
        int newAmount;       

        newAmount = System.Convert.ToInt32(manaPoints.text) + amount;
        manaPoints.text = newAmount.ToString();

        StartScaleAnimation(TagsHolder.scaleManaAnimation);
    }

    public void OnDamageChanged(int amount)
    {
        int newAmount;

        newAmount = System.Convert.ToInt32(damagePoints.text) + amount;
        damagePoints.text = newAmount.ToString();

        StartScaleAnimation(TagsHolder.scaleDamageAnimation);

    }

    public int GetHealth()
    {
        return Convert.ToInt32(healthPoints.text);
    }

    public void SetHealth(int value)
    {

        healthPoints.text = value.ToString();
       
    }


    //Animation Functions
    public void StartScaleAnimation(string animBool)
    {
        anim.SetBool(animBool, true);
    }

    public void StopScaleAnimation(string animBool)
    {
        anim.SetBool(animBool, false);
    }
    // End Animation Functions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagsHolder.changeDamageArea) == true) {
            Debug.Log("Entered " + TagsHolder.changeDamageArea +  " Area");
            OnDamageChanged(1);
        }

        if (collision.CompareTag(TagsHolder.changeManaArea) == true) {
            Debug.Log("Entered " + TagsHolder.changeManaArea + " Area");
            OnManaChanged(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopScaleAnimation(TagsHolder.scaleDamageAnimation);
        StopScaleAnimation(TagsHolder.scaleManaAnimation);
    }




}
