using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSize : MonoBehaviour
{
    [Tooltip("The number of seconds that the powerUP remains active")]
    [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PowerUp triggered by player");
            var SpeedChanger = other.GetComponent<InputMover>();
            var ScaleChanger = other.GetComponent<InputMover>();
            //if (SpeedChanger) {
            SpeedChanger.StartCoroutine(speedtemp(SpeedChanger));        // co-routines
            ScaleChanger.StartCoroutine(ScaleChangerTemp(ScaleChanger));
            // NOTE: If you just call "StartCoroutine", then it will not work, 
            //       since the present object is destroyed!
            // speedtemp(SpeedChanger);                                      // async-await
            Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            //}
            // } else {
            //    Debug.Log("Shield triggered by "+other.name);
            // }
        }
    }

    private IEnumerator speedtemp(InputMover move) // co-routines
    {
        // private async void speedtemp(DestroyOnTrigger2D SpeedChanger) {      // async-await
        move.speed_up();
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("speed: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
                                                        // await Task.Delay(1000);                // async-await
        }
        move.slow_down();
    }

    private IEnumerator ScaleChangerTemp(InputMover move)
    {
        move.shrink();
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("shrink: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
                                                        // await Task.Delay(1000);                // async-await
        }
        move.grow();
    }
}
