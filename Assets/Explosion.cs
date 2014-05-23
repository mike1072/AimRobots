using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Explosion : MonoBehaviour
{
    public Bullet Creator = null;

    // Use this for initialization
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Creator.Remove();
    }
}
