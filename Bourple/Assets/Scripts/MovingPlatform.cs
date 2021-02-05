using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private PlatformObj platform;
    [SerializeField] private Transform a, b;
    [SerializeField] private float speed;
    [SerializeField] private float delayTime;
    [SerializeField] public bool waitForPlayer;

    private bool goingA;
    private float lastDelay = Mathf.NegativeInfinity;


    private void Awake()
    {
        platform.transform.position = a.position;
        platform.movingPlatform = this;
    }

    private void FixedUpdate()
    {
        if (Time.time - lastDelay >= delayTime && !waitForPlayer)
        {
            if (goingA)
            {
                Move(a);

                if (Vector3.Distance(platform.transform.position, a.position) < .1f)
                {
                    goingA = false;
                    lastDelay = Time.time;
                }
            }
            else
            {
                Move(b);

                if (Vector3.Distance(platform.transform.position, b.position) < .1f)
                {
                    goingA = true;
                    lastDelay = Time.time;
                }
            }
        }
    }

    void Move(Transform target)
    {
        Vector3 direction = target.position - platform.transform.position;
        platform.transform.Translate((direction / direction.magnitude) * Time.fixedDeltaTime * speed);
    }


}
