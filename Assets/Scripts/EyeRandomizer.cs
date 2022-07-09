using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRandomizer : MonoBehaviour
{
    [SerializeField] private float minSize = 0.5f;
    [SerializeField] private float maxSize = 1.5f;
    [SerializeField] private float zRotationMin;
    [SerializeField] private float zRotationMax;
    [SerializeField] private float minHeight = 1f;
    [SerializeField] private float maxHeight = 3f;
    [SerializeField] bool checkHeight = false;

    private void Start()
    {
        if (checkHeight)
        {
            RandomizePlacement();
            return;
        }
        RandomizeRotation();
        RandomizeSize();
    }

    void RandomizeSize()
    {
        float randomsize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomsize, randomsize, randomsize);
    }

    void RandomizeRotation()
    {
        float randomRotation = Random.Range(zRotationMin, zRotationMax);
        Vector3 eulerAngles = new Vector3(0, 0, randomRotation);
        transform.Rotate(eulerAngles);
    }

    void RandomizePlacement()
    {
        Vector2 currentPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
        currentPos.x = Random.Range(minHeight, maxHeight);
        transform.localPosition = currentPos;
    }
}




