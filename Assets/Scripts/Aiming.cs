using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
    private float angle = 0;
    public float Angle
    {
        get { return angle; }
        set
        {
            angle = value;
            while (angle >= 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;

            gun.Rotate(360 - Mathf.RoundToInt(angle));
        }
    }

    private Gun gun;
    private AngleText angleText;

    // Use this for initialization
    void Start()
    {
        gun = gameObject.GetComponentInChildren<Gun>();
        angleText = gameObject.GetComponentInChildren<AngleText>();
    }

    void OnGUI()
    {
        angleText.Angle = Mathf.RoundToInt(Angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < -0.5)
            Angle -= 20 * Time.deltaTime;
        else if (Input.GetAxis("Vertical") > 0.5)
            Angle += 20 * Time.deltaTime;
    }
}
