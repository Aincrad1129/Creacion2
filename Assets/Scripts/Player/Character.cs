
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{

    // Start is called before the first frame update
    [Tooltip ("Dejar Activido")]
    public bool isAlive;
    public bool isActive = false;
    public int index;
    [Header ("Atributos básicos del personaje")]
    [Tooltip ("Velocidad del personaje")]
    public float Velocity;
    [Tooltip("Velocidad de salto del  personaje")]
    public float JumpVelocity;
   
}
