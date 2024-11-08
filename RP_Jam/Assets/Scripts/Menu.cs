using System;
using System.Collections;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject boot;

    [SerializeField] float lerpTime = 20f, fadeTime = 2f;

    bool start, quit;

    [SerializeField] Transform button1, button2;
    [SerializeField] Button startButton, quitButton;

    [SerializeField] GameObject Panel, Text;

    [SerializeField] Color textColour;
   


    private void Start()
    {
        Panel.SetActive(false);

        //Panel.GetComponent<Image>().color = new(0, 0, 0, 0);
        //Text.GetComponent<TextMeshProUGUI>().color = new(255, 95, 95, 0);

        //Panel.GetComponent<Image>().color = Color.clear;
        //Text.GetComponent<TextMeshProUGUI>().color = Color.clear;
    }

    private void Update()
    {
        if (!start && !quit)
        {
            Vector2 mousePos = new(Input.mousePosition.x, boot.transform.position.y);

            boot.transform.position = Vector2.Lerp(boot.transform.position, new(Mathf.Clamp(mousePos.x, 400, 1500), mousePos.y), Time.deltaTime * lerpTime);
        }


        if (start)
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
        StartCoroutine(StartStomp());
        start = true;

        quitButton.enabled = false;
    }

    public void QuitGame()
    {
        StartCoroutine(QuitStomp());
        quit = true;

        startButton.enabled = false;
    }


    IEnumerator StartStomp()
    {
        yield return new WaitForSeconds(0.75f);

        Panel.SetActive(true);

        //Panel.GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, Time.deltaTime * fadeTime);
        //Text.GetComponent<TextMeshProUGUI>().color = Color.Lerp(Color.clear, textColour, Time.deltaTime * fadeTime);

        //StartCoroutine(Fade(Panel.GetComponent<Image>().color));
        //StartCoroutine(Fade(Text.GetComponent<TextMeshProUGUI>().color));


        yield return new WaitForSeconds(6f);
        //move scene
        Debug.Log("Start");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    IEnumerator QuitStomp()
    {
        yield return new WaitForSeconds(0.75f);

        Application.Quit();
        Debug.Log("Quit");
    }

    IEnumerator Fade(Color col)
    {
        float targetA = 1f;
        Color current = col;
        while(Mathf.Abs(current.a - targetA) > 0.001f)
        {
            current.a = Mathf.Lerp(current.a, targetA, Time.deltaTime * fadeTime);
            col = current;
            yield return null;
        }
    }


}
