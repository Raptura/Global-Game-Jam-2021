using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform, a, b;
    [SerializeField] private float speed;
    [SerializeField] private float delayTime;
    private bool goingA;
    private float lastDelay = Mathf.NegativeInfinity;
    private void Awake()
    {
        platform.position = a.position;
    }

    private void Update()
    {
        if (Time.time - lastDelay >= delayTime)
        {
            if (goingA)
            {
                Move(a);

                if (Vector3.Distance(platform.position, a.position) < .1f)
                {
                    goingA = false;
                    lastDelay = Time.time;
                }
            }
            else
            {
                Move(b);

                if (Vector3.Distance(platform.position, b.position) < .1f)
                {
                    goingA = true;
                    lastDelay = Time.time;
                }
            }
        }
    }

    void Move(Transform target)
    {
        Vector3 direction = target.position - platform.position;
        platform.Translate((direction / direction.magnitude) * Time.deltaTime * speed);
    }

}
