using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] BootScript player;
    [SerializeField] GameObject meterArrow;
    [SerializeField] TextMeshProUGUI ideologyValText;

    [SerializeField][Range(-100, 100)] float arrowPointAngle = 0;
    Vector3 arrowPoint;

    [SerializeField] GameObject scrollPanelParent, speechBubblePrefab;
    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] List<GameObject> speechBubbles = new List<GameObject>();

    //Transform enemySpeechArrow;

    void Start()
    {
        //SpawnSpeechBubble("Test");

        //enemySpeechArrow = GetComponentInChildren<Image>().transform;
    }


    void Update()
    {
        RotateArrow(player.GetIdeologyVal());
        ideologyValText.text = player.GetIdeologyVal().ToString();


        MoveBubbleArrow();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void RotateArrow(float angle)
    {
        arrowPoint = new(0, 0, -angle);

        meterArrow.transform.eulerAngles = arrowPoint;
    }


    public void SpawnSpeechBubble(string speech)
    {
        GameObject item = Instantiate(speechBubblePrefab, scrollPanelParent.transform);

        TextMeshProUGUI text = item.GetComponentInChildren<TextMeshProUGUI>();
        text.text = speech;

        speechBubbles.Add(item);

    }



    public void AddEnemyToList(Enemy enemy, string sentence)
    {
        enemies.Add(enemy);

        SpawnSpeechBubble(sentence);

    }

    public void PopEnemyFromList()
    {
        Destroy(speechBubbles[0], 0.1f);
        speechBubbles.RemoveAt(0);


        enemies.RemoveAt(0);

    }

    public void PopEnemyFromList(Enemy enemy)
    {
        Destroy(speechBubbles[enemies.IndexOf(enemy)], 0.1f);
        speechBubbles.RemoveAt(enemies.IndexOf(enemy));


        enemies.Remove(enemy);
    }

    void MoveBubbleArrow()
    {
        foreach (GameObject bubble in speechBubbles)
        {
            Image arrow = bubble.GetComponentsInChildren<Image>()[1];

            //arrow.transform.position = new(enemies[speechBubbles.IndexOf(bubble)].transform.position.x, arrow.rectTransform.position.y);

            arrow.transform.position = new(MapWorldToUISpace(enemies[speechBubbles.IndexOf(bubble)].transform.position.x, -8, 2, 100, 1150), arrow.rectTransform.position.y);
        }
    }



    float MapWorldToUISpace(float val, float world1, float world2, float ui1, float ui2)
    {
        // map world 12 -> -12 to UI -550 -> 550

        return ui1 + (val - world1)*(ui2 - ui1)/(world2 - world1);
    }



}
