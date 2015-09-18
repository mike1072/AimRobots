using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float BulletPower = 20f;
    public GameObject bullet;
    public bool CanShoot = true;

    Vector3 initialPosition;
    Quaternion initialRotation;

    Transform exitPoint;
    CameraFollow cameraFollow;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;

        exitPoint = transform.FindChild("ExitPoint");
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot") && CanShoot)
            Shoot();
    }

    public void Rotate(int angle)
    {
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        transform.RotateAround(transform.parent.position, Vector3.forward, angle);
    }

    public void Shoot()
    {
        var bulletInstance = Instantiate(bullet, exitPoint.position, exitPoint.rotation) as GameObject;

        bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * BulletPower);
        cameraFollow.target = bulletInstance.transform;

        var bulletTime = 3;
        CanShoot = false;
        StartCoroutine(ResetShootCapability(bulletTime, bulletInstance));
    }

    IEnumerator ResetShootCapability(float seconds, GameObject bulletObj)
    {
        // wait
        yield return new WaitForSeconds(seconds);

        // explode bullet if it hasn't already
        if (bulletObj.activeInHierarchy)
            bulletObj.GetComponent<Bullet>().Explode();

        // reset camera
        CanShoot = true;
        cameraFollow.target = transform;
    }
}
