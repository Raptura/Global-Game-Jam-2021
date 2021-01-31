using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObj : MonoBehaviour
{
    public MovingPlatform movingPlatform { get; set; }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<CharacterController2D>();
            movingPlatform.waitForPlayer = false;
            collision.transform.SetParent(transform);
        }

        if (collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            collision.transform.SetParent(null);
        }

    }
}
