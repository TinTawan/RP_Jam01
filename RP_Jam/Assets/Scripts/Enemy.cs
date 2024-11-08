using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform moveTarget;

    [SerializeField] Sprite goodSprite, badSprite;
    SpriteRenderer sr;

    [SerializeField] float value = 10;
    float ideologyVal;

    bool isGood;

    [SerializeField] List<string> goodSentences = new List<string>();
    [SerializeField] List<string> badSentences = new List<string>();

    string stringToSay;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        moveTarget = GameObject.FindGameObjectWithTag("EnemyTarget").transform;

        UI_Manager ui = GameObject.FindObjectOfType<UI_Manager>();

        if (Random.Range(0, 2) == 0)
        {
            isGood = true;
            sr.sprite = goodSprite;
            ideologyVal = -value;

            //stringToSay = goodSentences[Random.Range(0, goodSentences.Count)];

            ui.AddEnemyToList(GetComponent<Enemy>(), goodSentences[Random.Range(0, goodSentences.Count)]);
        }
        else
        {
            isGood = false;
            sr.sprite = badSprite;
            ideologyVal = value;

            //stringToSay = badSentences[Random.Range(0, badSentences.Count)];

            ui.AddEnemyToList(GetComponent<Enemy>(), badSentences[Random.Range(0, badSentences.Count)]);
        }

        

    }

    void Update()
    {
        Move();

        
    }

    void Move()
    {
        //move enemy to the left of the screen as soon as they spawn
        transform.position = Vector2.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);
    }

    public void ReachedTarget()
    {
        Destroy(gameObject, 0.1f);
    }

    public void Stomped()
    {
        Destroy(gameObject/*, 0.1f*/);
    }

    public float GetIdeologyLevel()
    {
        return ideologyVal;
    }

    /*void SetSentence(bool isGood)
    {
        int rand = Random.Range(0, goodSentences.Count);
        if(isGood )
        {
            stringToSay = goodSentences[rand];
        }
        else
        {
            stringToSay = badSentences[rand];
        }

        //Debug.Log(stringToSay);
    }*/

    public string GetSentence()
    {
        return stringToSay;
    }

    public bool GetGood()
    {
        return isGood;
    }
}
