using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{

    float walkspeed = 70f;
    Vector3 currentPos;
    bool startCreeping = false;

    private void OnEnable()
    {
        EventManager.spiderEvent += StartCreeping;
    }

    private void OnDisable()
    {
        EventManager.spiderEvent -= StartCreeping;
    }

    private void Start()
    {
        currentPos = transform.position;
    }
    private void Update()
    {
        if (startCreeping)
        {
            StartCreeping();
        }
    }

    void StartCreeping()
    {
        startCreeping = true;
        if(transform.position.y >= -121)
        {
            Vector3 newPos = transform.position;
            newPos.y += walkspeed * Time.deltaTime;
            transform.position = newPos;
        }
    }

    public void KilledSpider()
    {
        transform.position = currentPos;
        startCreeping = false;
    }
}
