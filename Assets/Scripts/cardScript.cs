using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cardScript : MonoBehaviour
{
    GameObject leftCard, rightCard, straightCard, backCard, attackCard, defendCard;
    public eventTriggerCard[] cards;

    private void Update()
    {
        cards = FindObjectsOfType<eventTriggerCard>();   
    }

    public void disableCards()
    {
        foreach (var item in cards)
        {
            if(item != null && !(item.gameObject.name == "Defend Card(Clone)" || item.gameObject.name == "Defend Card (1)(Clone)"))
            {
                item.gameObject.GetComponent<Image>().color = new Color32(147, 147, 147, 255);
                item.gameObject.GetComponent<eventTriggerCard>().enabled = false;
            }          
        }
    }

    public void enableCards()
    {
        foreach (var item in cards)
        {
            if(item != null)
            {
                item.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                item.gameObject.GetComponent<eventTriggerCard>().enabled = true;
            }          
        }
    }

    public void disableAllCards()
    {
        foreach (var item in cards)
        {
            if(item != null)
            {
                item.gameObject.GetComponent<Image>().color = new Color32(147, 147, 147, 255);
                item.gameObject.GetComponent<eventTriggerCard>().enabled = false;
            }
        }
    }
    
    public void enableDefense()
    {
        foreach (var item in cards)
        {
            if (item != null && (item.gameObject.name == "Defend Card(Clone)" || item.gameObject.name == "Defend Card (1)(Clone)"))
            {
                item.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                item.gameObject.GetComponent<eventTriggerCard>().enabled = true;
            }
        }
    }
}
