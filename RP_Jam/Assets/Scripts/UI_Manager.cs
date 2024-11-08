using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] BootScript player;
    [SerializeField] GameObject arrow;
    [SerializeField] TextMeshProUGUI ideologyValText;

    [SerializeField][Range(-100 ,100)] float arrowPointAngle = 0;
    Vector3 arrowPoint;

    [SerializeField] GameObject scrollPanelParent, speechBubblePrefab;
    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] List<GameObject> speechBubbles = new List<GameObject>();

    

    void Start()
    {
        //SpawnSpeechBubble("Test");
    }


    void Update()
    {
        RotateArrow(player.GetIdeologyVal());
        ideologyValText.text = player.GetIdeologyVal().ToString();

        //enemies.Add(GameObject.FindGameObjectWithTag("Enemy").TryGetComponent<Enemy>());

        /*if (GameObject.FindGameObjectWithTag("Enemy").TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemies.Add(enemy);
        }*/
        
    }

    void RotateArrow(float angle)
    {
        arrowPoint = new(0, 0, -angle);

        arrow.transform.eulerAngles = arrowPoint;
    }

    /*float IdeologyLevelToAngle(float value, float min1, float max1, float min2, float max2)
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);

    }*/

    public void SpawnSpeechBubble(string speech)
    {
        GameObject item = Instantiate(speechBubblePrefab, scrollPanelParent.transform);

        TextMeshProUGUI text = item.GetComponentInChildren<TextMeshProUGUI>();
        text.text = speech;

        speechBubbles.Add(item);
        
    }

    void RemoveSpeechBubble(GameObject obejct)
    {

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
        Destroy(speechBubbles[enemies.IndexOf(enemy)],0.1f);
        speechBubbles.RemoveAt(enemies.IndexOf(enemy));


        enemies.Remove(enemy);
    }
}
