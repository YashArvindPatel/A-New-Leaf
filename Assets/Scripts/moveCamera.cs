using System.Collections;
using UnityEngine;

class moveCamera : MonoBehaviour
{
    public float lerpTime = 0.3f;
    public float currentLerpTime = 0;
    public bool keyHitLeft = false;
    public bool keyHitRight = false;
    private Vector3 start, end, left, middle, right;
    public int counter = 0;
    private bool moving = false;

    private void Start()
    {
        left = new Vector3(-4, 0, -1);
        middle = new Vector3(0, 0, -1);
        right = new Vector3(4, 0, -1);
    }

    void Update()
    {
        float x = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)).x;
        float y = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)).y;

        if (Input.GetMouseButtonDown(0) && x>=-9 && x<=-8 && y>=-4.5 && y<=-3.5 && (counter == -1 || counter == 0) && !moving) { keyHitLeft = true; moving = true; }
        if (Input.GetMouseButtonDown(0) && x<=9 && x>=8 && y>=-4.5 && y<=-3.5 && (counter == 1 || counter == 0) && !moving) { keyHitRight = true; moving = true; }

        if (keyHitLeft)
        {
            if (counter == 0)
            {
                start = middle;
                end = left;
            }
            if (counter == -1)
            {
                start = left;
                end = middle;
            }          

            currentLerpTime += Time.deltaTime;

            if (currentLerpTime >= lerpTime) { currentLerpTime = lerpTime; }

            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(start, end, perc);
        }

        if (keyHitRight)
        {
            if (counter == 0)
            {
                start = middle;
                end = right;
            }
            if (counter == 1)
            {
                start = right;
                end = middle;
            }

            currentLerpTime += Time.deltaTime;

            if (currentLerpTime >= lerpTime) { currentLerpTime = lerpTime; }

            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(start, end, perc);
        }

        if (currentLerpTime == 0.3f)
        {
            if (keyHitLeft && counter == 0)
            {
                counter = -1;
                keyHitLeft = false;
                currentLerpTime = 0;
            }

            if (keyHitLeft && counter == -1)
            {
                counter = 0;
                keyHitLeft = false;
                currentLerpTime = 0;
            }

            if (keyHitRight && counter == 0)
            {
                counter = 1;
                keyHitRight = false;
                currentLerpTime = 0;
            }

            if (keyHitRight && counter == 1)
            {
                counter = 0;
                keyHitRight = false;
                currentLerpTime = 0;
            }

            moving = false;
        }
    }
}