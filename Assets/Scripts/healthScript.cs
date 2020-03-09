using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    Slider[] slider;
    Slider player1Slider;
    Slider player2Slider;

    // Use this for initialization
    void Start()
    {
        slider = FindObjectsOfType<Slider>();
        if(slider[0].gameObject.name == "Health Bar")
        {
            player1Slider = slider[0];
            player2Slider = slider[1];
        }
        else
        {
            player1Slider = slider[1];
            player2Slider = slider[2];
        }
        currentHealth = maxHealth;

        player1Slider.maxValue = maxHealth;
        player1Slider.maxValue = maxHealth;
    }
    
    public void Damage(int damage, bool turn)
    {
        if(turn)
        {
            currentHealth -= damage;
            player2Slider.value = currentHealth;
        }
        else
        {
            currentHealth -= damage;
            player1Slider.value = currentHealth;
        }       
    }
}
