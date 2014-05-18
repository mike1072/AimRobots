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
        set { angle = value; textMesh.text = DisplayedAngle.ToString() + "°"; }
    }

    protected int DisplayedAngle
    {
        get
        {
            return Mathf.RoundToInt(
                Angle <= 90 ? Angle
                : Angle <= 270 ? 180 - Angle
                : Angle - 360);
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
        //guiText.text = DisplayedAngle.ToString();
    }
}
