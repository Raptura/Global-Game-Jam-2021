using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableEntity : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
