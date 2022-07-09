using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : BasicProjectile
{
    private float degreesPerSecond = 20;

    private void Start()
    {
        degreesPerSecond = Random.Range(20, 50);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }
}