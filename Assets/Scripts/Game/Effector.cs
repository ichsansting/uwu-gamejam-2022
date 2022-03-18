using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect {
    idle, jump, dash, reverse
}

public class Effector : MonoBehaviour
{
    public Effector(){
        Color = Color.white;
        Effect = Effect.idle;
    }

    public Color Color { get; set; }
    public Effect Effect { get; set; }
}
