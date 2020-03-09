using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class cardSlotGenerationScript : MonoBehaviour,IPointerClickHandler
{
    public battleScript battleSystem;

    private void Start()
    {
        battleSystem = FindObjectOfType<battleScript>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tag == "ECH1")
        {
            battleSystem.totalCountPlaysPlayer1++;
            battleSystem.OnCardClick();
        }
        else if (tag == "ECH2")
        {
            battleSystem.totalCountPlaysPlayer2++;
            battleSystem.OnCardClick();
        }
    }
}
