using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleScript : MonoBehaviour
{
    public enum BattleState { player1Phase1, player2Phase1, player1Phase2, player2Phase2 }

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    GameObject player1;
    GameObject player2;

    public BattleState battleState;

    public float timer;
    public bool timerOn;
    public Text text;

    public generateCard[] cardHolders;
    public GameObject cardHolder1, cardHolder2, cardHolder3, cardHolder4, cardHolder5, cardHolder6, cardHolder7,
        cardHolder8, cardHolder9, cardHolder10, cardHolder11, cardHolder12, cardHolder13, cardHolder14;

    public GameObject extraCardHolder1, extraCardHolder2;

    public int countPlaysPlayer1 = 0;
    public int countPlaysPlayer2 = 0;
    public int totalCountPlaysPlayer1 = 3;
    public int totalCountPlaysPlayer2 = 3;

    void Start()
    {
        player1 = Instantiate(player1Prefab);
        player2 = Instantiate(player2Prefab);
        cardHolders = FindObjectsOfType<generateCard>();
        extraCardHolder1 = GameObject.FindGameObjectWithTag("ECH1");
        extraCardHolder2 = GameObject.FindGameObjectWithTag("ECH2");

        foreach (var item in cardHolders)
        {
            if (item.gameObject.name == "CardHolder (1)")
            {
                cardHolder1 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (2)")
            {
                cardHolder2 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (3)")
            {
                cardHolder3 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (4)")
            {
                cardHolder4 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (5)")
            {
                cardHolder5 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (6)")
            {
                cardHolder6 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (7)")
            {
                cardHolder7 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (8)")
            {
                cardHolder8 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (9)")
            {
                cardHolder9 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (10)")
            {
                cardHolder10 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (11)")
            {
                cardHolder11 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (12)")
            {
                cardHolder12 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (13)")
            {
                cardHolder13 = item.gameObject;
            }
            else if (item.gameObject.name == "CardHolder (14)")
            {
                cardHolder14 = item.gameObject;
            }            
        }

        CardHolderStatusPlayer1();
        CardHolderStatusPlayer2();

        cardHolder4.SetActive(false);
        cardHolder5.SetActive(false);
        cardHolder11.SetActive(false);
        cardHolder12.SetActive(false);
        extraCardHolder1.SetActive(false);
        extraCardHolder2.SetActive(false);

        StartCoroutine(Player1Phase1());
    }

    IEnumerator Player1Phase1()
    {
        battleState = BattleState.player1Phase1;

        CardHolderStatusPlayer1();
      
        yield return new WaitForSeconds(1f);

        if(totalCountPlaysPlayer1 != 5)
        {
            extraCardHolder1.SetActive(true);
        }

        if(totalCountPlaysPlayer1 == 3)
        {
            cardHolder4.SetActive(false);
            cardHolder5.SetActive(false);
        }
        else if(totalCountPlaysPlayer1 == 4)
        {
            cardHolder5.SetActive(false);
        }
       
        cardHolder6.SetActive(false);
        cardHolder7.SetActive(false);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player1Cards")
            {
                item.generateRandomCard();
            }
        }

        timer = 15;
        timerOn = true;     

        yield return new WaitForSeconds(15f);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player1Cards")
            {
                item.destroyCard();
            }
        }

        timerOn = false;

        StartCoroutine(Player2Phase1());
    }

    IEnumerator Player2Phase1()
    {
        battleState = BattleState.player2Phase1;

        CardHolderStatusPlayer2();

        yield return new WaitForSeconds(1f);

        if(totalCountPlaysPlayer2 != 5)
        {
            extraCardHolder2.SetActive(true);
        }

        if (totalCountPlaysPlayer2 == 3)
        {
            cardHolder11.SetActive(false);
            cardHolder12.SetActive(false);
        }
        else if (totalCountPlaysPlayer2 == 4)
        {
            cardHolder12.SetActive(false);
        }

        cardHolder13.SetActive(false);
        cardHolder14.SetActive(false);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player2Cards")
            {
                item.generateRandomCard();
            }
        }

        timer = 15;
        timerOn = true;

        yield return new WaitForSeconds(15f);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player2Cards")
            {
                item.destroyCard();
            }
        }

        timerOn = false;

        StartCoroutine(Player1Phase2());
    }

    IEnumerator Player1Phase2()
    {
        battleState = BattleState.player1Phase2;

        countPlaysPlayer1 = totalCountPlaysPlayer1;
        CardHolderStatusPlayer1();

        yield return new WaitForSeconds(1f);

        cardHolder6.SetActive(true);
        cardHolder7.SetActive(true);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player1Cards")
            {
                item.generateSpecificCard();
            }
        }

        timer = 15;
        timerOn = true;

        yield return new WaitForSeconds(15f);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player1Cards")
            {
                item.destroyCard();
            }
        }

        timerOn = false;

        StartCoroutine(Player2Phase2());
    }

    IEnumerator Player2Phase2()
    {
        battleState = BattleState.player2Phase2;

        countPlaysPlayer2 = totalCountPlaysPlayer2;
        CardHolderStatusPlayer2();

        yield return new WaitForSeconds(1f);

        cardHolder13.SetActive(true);
        cardHolder14.SetActive(true);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player2Cards")
            {
                item.generateSpecificCard();
            }
        }

        timer = 15;
        timerOn = true;        

        yield return new WaitForSeconds(15f);

        foreach (var item in cardHolders)
        {
            if (item.tag == "Player2Cards")
            {
                item.destroyCard();
            }
        }

        timerOn = false;

        StartCoroutine(Player1Phase1());
    }

    public void CardHolderStatusPlayer1()
    {
        if(battleState == BattleState.player1Phase1)
        {
            if(totalCountPlaysPlayer1 == 3)
            {
                cardHolder1.transform.localPosition = new Vector3(-470, 65, 0);
                cardHolder2.transform.localPosition = new Vector3(-470, 20, 0);
                cardHolder3.transform.localPosition = new Vector3(-470, -25, 0);
                extraCardHolder1.transform.localPosition = new Vector3(-470, -67, 0);
            }
            else if (totalCountPlaysPlayer1 == 4)
            {
                cardHolder1.transform.localPosition = new Vector3(-470, 100, 0);
                cardHolder2.transform.localPosition = new Vector3(-470, 55, 0);
                cardHolder3.transform.localPosition = new Vector3(-470, 10, 0);
                cardHolder4.transform.localPosition = new Vector3(-470, -35, 0);
                extraCardHolder1.transform.localPosition = new Vector3(-470, -77, 0);
                cardHolder4.SetActive(true);
            }
            else if (totalCountPlaysPlayer1 == 5)
            {
                cardHolder1.transform.localPosition = new Vector3(-470, 110, 0);
                cardHolder2.transform.localPosition = new Vector3(-470, 65, 0);
                cardHolder3.transform.localPosition = new Vector3(-470, 20, 0);
                cardHolder4.transform.localPosition = new Vector3(-470, -25, 0);
                cardHolder5.transform.localPosition = new Vector3(-470, -70, 0);
                cardHolder5.SetActive(true);
            }
        }
        else if (battleState == BattleState.player1Phase2)
        {
            cardHolder1.transform.localPosition = new Vector3(-470, 55, 0);
            cardHolder2.transform.localPosition = new Vector3(-470, -35, 0);
            cardHolder3.transform.localPosition = new Vector3(-385, 10, 0);
            cardHolder4.transform.localPosition = new Vector3(-470, 10, 0);
            cardHolder6.transform.localPosition = new Vector3(-385, 55, 0);
            cardHolder7.transform.localPosition = new Vector3(-385, -35, 0);
            cardHolder4.SetActive(true);           
        }
    }

    public void CardHolderStatusPlayer2()
    {
        if (battleState == BattleState.player2Phase1)
        {
            if(totalCountPlaysPlayer2 == 3)
            {
                cardHolder8.transform.localPosition = new Vector3(470, 65, 0);
                cardHolder9.transform.localPosition = new Vector3(470, 20, 0);
                cardHolder10.transform.localPosition = new Vector3(470, -25, 0);
                extraCardHolder2.transform.localPosition = new Vector3(470, -67, 0);
            }
            else if (totalCountPlaysPlayer2 == 4)
            {
                cardHolder8.transform.localPosition = new Vector3(470, 100, 0);
                cardHolder9.transform.localPosition = new Vector3(470, 55, 0);
                cardHolder10.transform.localPosition = new Vector3(470, 10, 0);
                cardHolder11.transform.localPosition = new Vector3(470, -35, 0);
                extraCardHolder2.transform.localPosition = new Vector3(470, -77, 0);
                cardHolder11.SetActive(true);
            }
            else if (totalCountPlaysPlayer2 == 5)
            {
                cardHolder8.transform.localPosition = new Vector3(470, 110, 0);
                cardHolder9.transform.localPosition = new Vector3(470, 65, 0);
                cardHolder10.transform.localPosition = new Vector3(470, 20, 0);
                cardHolder11.transform.localPosition = new Vector3(470, -25, 0);
                cardHolder12.transform.localPosition = new Vector3(470, -70, 0);
                cardHolder12.SetActive(true);
            }
        }
        else if(battleState == BattleState.player2Phase2)
        {
            cardHolder8.transform.localPosition = new Vector3(470, -35, 0);
            cardHolder9.transform.localPosition = new Vector3(470, 55, 0);
            cardHolder10.transform.localPosition = new Vector3(385, 10, 0);
            cardHolder11.transform.localPosition = new Vector3(470, 10, 0);
            cardHolder13.transform.localPosition = new Vector3(385, -35, 0);
            cardHolder14.transform.localPosition = new Vector3(385, 55, 0);
            cardHolder11.SetActive(true);
        }
    }

    public void EndTurn()
    {
        if (battleState == BattleState.player1Phase1)
        {
            foreach (var item in cardHolders)
            {
                if (item.tag == "Player1Cards")
                {
                    item.destroyCard();
                }
            }
            extraCardHolder1.SetActive(false);
            StopAllCoroutines();
            timerOn = false;
            StartCoroutine(Player2Phase1());
        }
        else if (battleState == BattleState.player2Phase1)
        {
            foreach (var item in cardHolders)
            {
                if (item.tag == "Player2Cards")
                {
                    item.destroyCard();
                }
            }
            extraCardHolder2.SetActive(false);
            StopAllCoroutines();
            timerOn = false;
            StartCoroutine(Player1Phase2());
        }
        else if (battleState == BattleState.player1Phase2)
        {
            foreach (var item in cardHolders)
            {
                if (item.tag == "Player1Cards")
                {
                    item.destroyCard();
                }
            }
            extraCardHolder1.SetActive(false);
            StopAllCoroutines();
            timerOn = false;
            StartCoroutine(Player2Phase2());
        }
        else if (battleState == BattleState.player2Phase2)
        {         
            foreach (var item in cardHolders)
            {
                if (item.tag == "Player2Cards")
                {
                    item.destroyCard();
                }
            }
            extraCardHolder2.SetActive(false);
            StopAllCoroutines();
            timerOn = false;
            StartCoroutine(Player1Phase1());           
        }
    }

    public void OnCardClick()
    {
        if (battleState == BattleState.player1Phase1)
        {
            foreach (var item in cardHolders)
            {
                if (item.tag == "Player1Cards")
                {
                    item.destroyCard();
                }
            }
            extraCardHolder1.SetActive(false);
            StopAllCoroutines();
            timerOn = false;
            StartCoroutine(Player2Phase1());
        }
        else if (battleState == BattleState.player2Phase1)
        {
            foreach (var item in cardHolders)
            {
                if (item.tag == "Player2Cards")
                {
                    item.destroyCard();
                }
            }
            extraCardHolder2.SetActive(false);
            StopAllCoroutines();
            timerOn = false;
            StartCoroutine(Player1Phase2());
        }
        else if (battleState == BattleState.player1Phase2)
        {
            if (countPlaysPlayer1 > 1)
            {
                countPlaysPlayer1--;
            }
            else
            {
                foreach (var item in cardHolders)
                {
                    if (item.tag == "Player1Cards")
                    {
                        item.destroyCard();
                    }
                }
                extraCardHolder1.SetActive(false);
                StopAllCoroutines();
                timerOn = false;
                StartCoroutine(Player2Phase2());
            }          
        }
        else if (battleState == BattleState.player2Phase2)
        {
            if (countPlaysPlayer2 > 1)
            {
                countPlaysPlayer2--;
            }
            else
            {
                foreach (var item in cardHolders)
                {
                    if (item.tag == "Player2Cards")
                    {
                        item.destroyCard();
                    }
                }
                extraCardHolder2.SetActive(false);
                StopAllCoroutines();
                timerOn = false;
                StartCoroutine(Player1Phase1());
            }           
        }
    }

    private void Update()
    {
        if (battleState == BattleState.player1Phase1 || battleState == BattleState.player1Phase2)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(-4, 0, -1), Time.deltaTime * 5);
        }
        else if (battleState == BattleState.player2Phase1 || battleState == BattleState.player2Phase2)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(4, 0, -1), Time.deltaTime * 5);
        }

        if (timerOn)
        {
            timer -= Time.deltaTime;
            text.text = Mathf.Ceil(timer).ToString();
        }
        else
        {
            text.text = "";
        }

        if (player1.GetComponent<moveScript>().onDefense && battleState == BattleState.player1Phase2)
        {
            player1.GetComponent<cardScript>().disableCards();
        }
        else if (battleState == BattleState.player1Phase2 || battleState == BattleState.player1Phase1)
        {
            player1.GetComponent<cardScript>().enableCards();
        }

        if (player2.GetComponent<moveScript>().onDefense && battleState == BattleState.player2Phase2)
        {
            player2.GetComponent<cardScript>().disableCards();
        }
        else if (battleState == BattleState.player2Phase2 || battleState == BattleState.player2Phase1)
        {
            player2.GetComponent<cardScript>().enableCards();
        }
    }
}
