using UnityEngine;
using UnityEngine.SceneManagement;

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


    [Header("UI")]
    [SerializeField] UI_Manager ui;

    [Header("Effects")]
    [SerializeField] AudioSource squash;
    [SerializeField] CamShake cam;

    bool win, lose;

    private void Start()
    {
        bootCol = GetComponent<BoxCollider2D>();

        stompTimer = stompTime;

        startPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStomping && !isRising)
        {
            isStomping = true;


        }

        if (isStomping)
        {
            Stomp();

        }
        if (isRising)
        {
            Rise();
        }

        if (ideologyLevel <= -100)
        {
            Debug.Log("Lose");
            lose = true;

            SceneManager.LoadScene(2);
        }
        if (ideologyLevel >= 100)
        {
            Debug.Log("Win");
            win = true;

            SceneManager.LoadScene(3);
        }
    }


    void Stomp()
    {
        transform.position = Vector2.Lerp(transform.position, dropPos, dropTime * Time.deltaTime);

        stompTimer -= Time.deltaTime;
        if (stompTimer <= 0)
        {
            isRising = true;
            Rise();
            stompTimer = stompTime;

            FindObjectOfType<CamShake>().CallShake(0.2f, 0.1f);
        }

        bootCol.enabled = true;
    }

    void Rise()
    {
        transform.position = Vector2.Lerp(transform.position, startPos, (dropTime * Time.deltaTime) / 2f);
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

            ui.PopEnemyFromList(enemy);

            squash.Play();


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


    public bool GetOutcome(bool hasWon)
    {
        if (hasWon)
        {
            return true;
        }
        return false;
    }

}
