using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject boot;

    [SerializeField] float lerpTime = 20f;

    bool start, quit;

    [SerializeField] Transform button1, button2;

    private void Update()
    {
        if(!start && !quit)
        {
            Vector2 mousePos = new(Input.mousePosition.x, boot.transform.position.y);

            boot.transform.position = Vector2.Lerp(boot.transform.position, new(Mathf.Clamp(mousePos.x, 400, 1500), mousePos.y), Time.deltaTime * lerpTime);
        }
        

        if(start)
        {
            boot.transform.position = Vector2.Lerp(boot.transform.position, button1.position, Time.deltaTime * lerpTime);
        }

        if (quit)
        {
            boot.transform.position = Vector2.Lerp(boot.transform.position, button2.position, Time.deltaTime * lerpTime);
        }

    }


    public void StartGame()
    {

        start = true;
    }

    public void QuitGame()
    {

        quit = true;
    }


}
