using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate(int angle)
    {
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        transform.RotateAround(transform.parent.position, Vector3.forward, angle);
    }

    public void Shoot()
    {

    }
}
