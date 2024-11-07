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

    float ideologyVal;

    bool isGood;

    [SerializeField] List<string> goodSentences = new List<string>();
    [SerializeField] List<string> badSentences = new List<string>();

    string stringToSay;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        moveTarget = GameObject.FindGameObjectWithTag("EnemyTarget").transform;

        if(Random.Range(0,2) == 0)
        {
            isGood = true;
            sr.sprite = goodSprite;
            ideologyVal = -10;
        }
        else
        {
            isGood = false;
            sr.sprite = badSprite;
            ideologyVal = 10;
        }

        SetSentence(isGood);

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

    void SetSentence(bool isGood)
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

        Debug.Log(stringToSay);
    }
}
