using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AngleText : MonoBehaviour
{
    private int angle;
    public int Angle
    {
        get { return angle; }
        set { angle = value; textMesh.text = DisplayedAngle; }
    }

    // formats angle to restrict results to [-90, 90] left or right
    protected string DisplayedAngle
    {
        get
        {
            var degrees = Angle <= 90 ? Angle
                : Angle < 270 ? 180 - Angle
                : Angle - 360;

            string direction = "";
            if (Angle > 90 && Angle < 270)
                direction = "B";

            return string.Format("{0}° {1}", degrees, direction);
        }
    }

    TextMesh textMesh;

    // Use this for initialization
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
