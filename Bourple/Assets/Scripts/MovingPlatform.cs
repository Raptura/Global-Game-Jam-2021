using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform, a, b;
    [SerializeField] private float speed;
    private bool goingA;

    private void Awake()
    {
        platform.position = a.position;
    }

    private void Update()
    {
        if (goingA)
        {
            Move(a);

            if (Vector3.Distance(platform.position, a.position) < .1f)
            {
                goingA = false;
            }
        } else
        {
            Move(b);

            if (Vector3.Distance(platform.position, b.position) < .1f)
            {
                goingA = true;
            }
        }
    }

    void Move(Transform target)
    {
        Vector3 direction = target.position - platform.position;
        platform.Translate((direction / direction.magnitude) * Time.deltaTime * speed);
    }

}
