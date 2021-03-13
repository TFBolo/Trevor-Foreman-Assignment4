using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float baseSpeed = 100f;
    public float speed = 100f;

    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);

    }

    public void Slow()
    {
        speed = baseSpeed * IntroManager.speedMod;
    }

    public void Fast()
    {
        speed = baseSpeed * IntroManager.speedMod * 2;
    }
}
