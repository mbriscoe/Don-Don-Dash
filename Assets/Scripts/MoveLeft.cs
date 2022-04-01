using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float leftBound = -15;

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * (GameManager.instance.speed + 11));
        }

        // check for obstacle off left of screen
        if (!(transform.position.x < leftBound) || !gameObject.CompareTag("Obstacle")) return;

        // kill current
        Destroy(gameObject);

        // update score
        GameManager.instance.UpdateScore();
    }
}
