using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int rotationY;

    private void Start()
    {
        rotationY = 0;
        StartCoroutine(Rotator());
    }

    IEnumerator Rotator()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            rotationY += 1;
            transform.Rotate(0, rotationY, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
