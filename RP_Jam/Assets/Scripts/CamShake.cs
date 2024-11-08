using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    Vector3 startPos = new(0, 0, -10);

    IEnumerator Shake(float value, float time)
    {
        float timer = 0f;

        //uses while loop and yield return null to run along side delta time
        while (timer < time)
        {
            timer += Time.deltaTime;
            /*Vector3 startPos = transform.position + offset;

            Vector2 shake = Random.insideUnitCircle;
            Vector3 shake3 = new Vector3(shake.x, shake.y, 0);

            transform.position = startPos + shake3 * shakeVal;*/

            Vector3 pos = transform.position/* + offset*/;
            Vector2 shake = Random.insideUnitCircle * value;

            transform.position = new(shake.x, shake.y, -10);
            yield return null;
        }

        transform.position = startPos;
    }

    public void CallShake(float val, float time)
    {
        StartCoroutine(Shake(val, time));
    }
}
