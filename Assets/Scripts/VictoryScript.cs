using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class VictoryScript : MonoBehaviour
{
    public GameObject healthBar1, healthBar2;
    public TextMeshProUGUI text;
    public GameObject panel, battleSystem;

    private void Update()
    {
        if (healthBar1.GetComponent<Slider>().value == 0)
        {
            battleSystem.SetActive(false);
            panel.SetActive(true);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -1), Time.deltaTime * 5);
            text.text = "Player 2 has won!";
        }
        else if (healthBar2.GetComponent<Slider>().value == 0)
        {
            battleSystem.SetActive(false);
            panel.SetActive(true);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -1), Time.deltaTime * 5);
            text.text = "Player 1 has won!";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
