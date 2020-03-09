using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class eventTriggerCard : MonoBehaviour,IPointerClickHandler
{
    moveScript[] players;
    GameObject player1;
    GameObject player2;
    battleScript battleSystem;
    Button[] buttons;
    GameObject button, button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12;

    void Start()
    {
        battleSystem = FindObjectOfType<battleScript>();
        buttons = FindObjectsOfType<Button>();
        players = FindObjectsOfType<moveScript>();

        foreach (var item in players)
        {
            if (item.gameObject.tag == "Player1")
            {
                player1 = item.gameObject;
            }
            else if (item.gameObject.tag == "Player2")
            {
                player2 = item.gameObject;
            }
        }

        foreach (var item in buttons)
        {
            if (item.gameObject.name == "Button")
            {
                button = item.gameObject;
            }
            else if (item.gameObject.name == "Button (1)")
            {
                button1 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (2)")
            {
                button2 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (3)")
            {
                button3 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (4)")
            {
                button4 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (5)")
            {
                button5 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (6)")
            {
                button6 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (7)")
            {
                button7 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (8)")
            {
                button8 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (9)")
            {
                button9 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (10)")
            {
                button10 = item.gameObject;
            }
            else if (item.gameObject.name == "Button (11)")
            {
                button11 = item.gameObject;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (name == "Left Card(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player1Phase1)
            {
                button3.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player1Phase2 && button3.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player1.GetComponent<moveScript>().moveStraight();
                button3.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Right Card(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player1Phase1)
            {
                button5.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player1Phase2 && button5.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player1.GetComponent<moveScript>().moveBack();
                button5.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }          
        }
        else if (name == "Straight Card(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player1Phase1)
            {
                button1.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player1Phase2 && button1.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player1.GetComponent<moveScript>().moveRight();
                button1.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Back Card(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player1Phase1)
            {
                button4.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player1Phase2 && button4.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player1.GetComponent<moveScript>().moveLeft();
                button4.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Attack Card(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player1Phase1)
            {
                button.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player1Phase2 && button.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player1.GetComponent<moveScript>().attack();
                button.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Defend Card(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player1Phase1)
            {
                button2.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player1Phase2 && button2.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player1.GetComponent<moveScript>().defend();
                button2.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Left Card (1)(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player2Phase1)
            {
                button9.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player2Phase2 && button9.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player2.GetComponent<moveScript>().moveBack();
                button9.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }  
        }
        else if (name == "Right Card (1)(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player2Phase1)
            {
                button11.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player2Phase2 && button11.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player2.GetComponent<moveScript>().moveStraight();
                button11.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Straight Card (1)(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player2Phase1)
            {
                button7.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player2Phase2 && button7.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player2.GetComponent<moveScript>().moveLeft();
                button7.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Back Card (1)(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player2Phase1)
            {
                button10.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player2Phase2 && button10.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player2.GetComponent<moveScript>().moveRight();
                button10.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Attack Card (1)(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player2Phase1)
            {
                button6.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player2Phase2 && button6.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player2.GetComponent<moveScript>().attack();
                button6.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
        else if (name == "Defend Card (1)(Clone)")
        {
            if (battleSystem.battleState == battleScript.BattleState.player2Phase1)
            {
                button8.GetComponent<skillIncrementScript>().Increase();
                battleSystem.OnCardClick();
            }
            else if (battleSystem.battleState == battleScript.BattleState.player2Phase2 && button8.GetComponent<skillIncrementScript>().skillPoints > 0)
            {
                player2.GetComponent<moveScript>().defend();
                button8.GetComponent<skillIncrementScript>().Decrease();
                battleSystem.OnCardClick();
            }
        }
    }
}
