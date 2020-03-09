using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateCard : MonoBehaviour
{
    public GameObject leftCard, rightCard, straightCard, backCard, attackCard, defendCard, cardHolder;
    GameObject GO;

    public void generateRandomCard()
    {
        int cardNumber = Random.Range(1, 7);

        if(cardNumber == 1)
        {
            GO = Instantiate(leftCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (cardNumber == 2)
        {
            GO = Instantiate(rightCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (cardNumber == 3)
        {
            GO = Instantiate(straightCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (cardNumber == 4)
        {
            GO = Instantiate(backCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (cardNumber == 5)
        {
            GO = Instantiate(attackCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (cardNumber == 6)
        {
            GO = Instantiate(defendCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
    }

    public void generateSpecificCard()
    {
        if (gameObject.name == "CardHolder (1)" || gameObject.name == "CardHolder (8)")
        {
            GO = Instantiate(leftCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (gameObject.name == "CardHolder (2)" || gameObject.name == "CardHolder (9)")
        {
            GO = Instantiate(rightCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (gameObject.name == "CardHolder (3)" || gameObject.name == "CardHolder (10)")
        {
            GO = Instantiate(straightCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (gameObject.name == "CardHolder (4)" || gameObject.name == "CardHolder (11)")
        {
            GO = Instantiate(backCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (gameObject.name == "CardHolder (6)" || gameObject.name == "CardHolder (13)")
        {
            GO = Instantiate(attackCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }
        else if (gameObject.name == "CardHolder (7)" || gameObject.name == "CardHolder (14)")
        {
            GO = Instantiate(defendCard) as GameObject;
            GO.transform.SetParent(cardHolder.transform, false);
        }      
    }

    public void destroyCard()
    {
        Destroy(GO);
    }
}
