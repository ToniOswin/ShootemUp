using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoving : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float offset;

    Vector3 startPosition;
    float newXPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newXPosition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPosition + Vector3.right * newXPosition;
    }
}
