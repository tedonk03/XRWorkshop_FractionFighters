using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [Range(0.2f, 1f)]
    public float speed = 0.5f;

    [Range(0.2f, 1f)]
    public float amplitude = 0.5f;

    private bool isFloating = true;

    private Vector3 tempVal;
    private Vector3 tempPos;
    void Start()
    {
        tempVal = transform.position;
        tempPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFloating)
            Hover();
    }

    public void EnableFloating()
    {
        //update to current position
        tempVal = transform.position;
        tempPos = transform.position;

        isFloating = true;
    }

    public void DisableFloating()
    {
        isFloating = false;
    }

    private void Hover()
    {
        //var randomSpeed = Random.Range(0.1f, speed);
        tempPos.y = tempVal.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = tempPos;
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, 2);
    }
}
