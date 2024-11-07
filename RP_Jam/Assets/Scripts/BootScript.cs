using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootScript : MonoBehaviour
{
    [Header("Boot Movement")]
    [SerializeField] float dropTime = 2f;

    [SerializeField] Vector2 dropPos;
    Vector2 startPos;

    bool isStomping, isRising;

    float stompTimer = 0.5f, riseTimer = 0.5f;
    [SerializeField] float stompTime = 0.5f;

    BoxCollider2D bootCol;


    [Header("Player Info")]
    [SerializeField] float ideologyLevel = 0;

    private void Start()
    {
        bootCol = GetComponent<BoxCollider2D>();

        stompTimer = stompTime;

        startPos = transform.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isStomping && !isRising)
        {
            isStomping = true;

            
        }

        if(isStomping)
        {
            Stomp();
            
        }
        if (isRising)
        {
            Rise();
        }

        ideologyLevel = Mathf.Clamp(ideologyLevel, -100, 100);
        if(ideologyLevel <= -100)
        {
            Debug.Log("Lose");
        }
        if(ideologyLevel >= 100)
        {
            Debug.Log("Win");
        }
    }


    void Stomp()
    {
        transform.position = Vector2.Lerp(transform.position, dropPos, dropTime * Time.deltaTime);

        stompTimer -= Time.deltaTime;
        if(stompTimer <= 0)
        {
            isRising = true;
            Rise();
            stompTimer = stompTime;
        }

        bootCol.enabled = true;
    }

    void Rise()
    {
        transform.position = Vector2.Lerp(transform.position, startPos, (dropTime * Time.deltaTime)/2f);
        isStomping = false;

        bootCol.enabled = false;

        riseTimer -= Time.deltaTime;
        if (riseTimer <= 0)
        {
            isRising = false;
            riseTimer = 0.5f;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            ideologyLevel += enemy.GetIdeologyLevel();
            enemy.Stomped();

            Debug.Log(ideologyLevel);
        }

    }

    public float GetIdeologyVal()
    {
        return ideologyLevel;
    }

    public void AddIdeologyVal(float val)
    {
        ideologyLevel += val;
    }
    

}
