using UnityEngine;
using System.Collections;

public class MatchCamera : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    void Awake ()
    {
        camera.orthographicSize = Screen.height / 2;
    }
}
