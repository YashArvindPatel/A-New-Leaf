using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skillIncrementScript : MonoBehaviour
{
    public Text text;
    public int skillPoints = 0;

    private void Start()
    {
        text = gameObject.GetComponentInChildren<Text>();
    }

    public void Increase()
    {
        skillPoints += 1;
        text.text = "x" + skillPoints.ToString();
    }

    public void Decrease()
    {
        skillPoints -= 1;
        text.text = "x" + skillPoints.ToString();
    }
}
