using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {
    public void OnMouseDown(){
        GameManager.activeControllable = this;
    }
}

public class GameManager : MonoBehaviour
{
    public static Controllable activeControllable;

    void Start()
    {
        
    }

    void Update()
    {
    }
}
