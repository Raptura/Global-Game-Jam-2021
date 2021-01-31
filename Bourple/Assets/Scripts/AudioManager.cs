using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource run, jump, pickup, drop, swapA, swapB, push, finish;

    private void Awake()
    {
        instance = this;
    }


}
