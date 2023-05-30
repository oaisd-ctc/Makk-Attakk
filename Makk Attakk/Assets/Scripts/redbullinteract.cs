using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redbullinteract : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement.runSpeed = 12f;
            Debug.Log(PlayerMovement.runSpeed);


            Invoke("DelayedFunction", 3);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Finished if statement");
        }
    }

    private void DelayedFunction()
    {
        Debug.Log("Started coroutine");
        PlayerMovement.runSpeed = 8f;
        Debug.Log(PlayerMovement.runSpeed);
        Debug.Log("Delay executed properly");
        Destroy(gameObject);

    }
}
