using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] float shakeVal = 2f, shakeTimer = 0.2f;

    Vector3 startPos = new(0, 0, -10);


    public IEnumerator Shake()
    {
        float timer = 0f;

        //uses while loop and yield return null to run along side delta time
        while (timer < shakeTimer)
        {
            timer += Time.deltaTime;
            /*Vector3 startPos = transform.position + offset;

            Vector2 shake = Random.insideUnitCircle;
            Vector3 shake3 = new Vector3(shake.x, shake.y, 0);

            transform.position = startPos + shake3 * shakeVal;*/

            Vector3 pos = transform.position/* + offset*/;
            Vector2 shake = Random.insideUnitCircle * shakeVal;

            transform.position = new(shake.x, shake.y, -10);
            yield return null;
        }

        transform.position = startPos;
    }
}
