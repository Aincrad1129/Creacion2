using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class FieldOfViewDetec : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameManager gameManager;
    [Header("Condiguracion camara")]
    [Tooltip("Angulo de vision de la camara")]
    // Start is called before the first frame update
    [SerializeField] [Range(0f, 180f)] private float visionAngle;
    [Tooltip("Distancia de vision de la camara")]
    [SerializeField] private float visionDistance;

    [Header("Mostrar vision")]
    [Tooltip("Cantidad de lados")]
    // Start is called before the first frame update
    [SerializeField] [Range(0f, 24f)] private int sides;
    [SerializeField] private Color color;

    [Header("IU de la camara")]
    [Tooltip("UI de alerta")]
    [SerializeField] private GameObject alertUI;
    [Tooltip("Barra de carga")]
    [SerializeField] private GameObject bar;
    [Tooltip("Tiempo para que la camara mate al jugador")]
    [SerializeField] private int cameraTime;
    private bool isKilling = false;
    private float timer;
    private float scaleX;
    private bool isUpdate = false;

    private KillPlayer killPlayer;

    // Start is called before the first frame update
    void Start()
    {
        killPlayer = FindObjectOfType<KillPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerVector = player.position - this.transform.position;
        if (IsInFOV(playerVector, this.transform.forward, visionAngle / 2, visionDistance))
        {
            print("player");
            if (!isKilling)
            {
                isUpdate = false;
                timer += Time.deltaTime;
                alertUI.SetActive(true);
                scaleX = timer/cameraTime;
                bar.transform.localScale = new Vector3(scaleX, 1, 1);
                if (timer >= cameraTime) {
                    scaleX = 1;
                    bar.transform.localScale = new Vector3(scaleX, 1, 1);
                    isKilling = true;
                    killPlayer.Kill();
                }
            }
        }
        else {
            if (!isUpdate)
            {
                isUpdate = true;
                isKilling = false;
                alertUI.SetActive(false);
                timer = 0;
                scaleX = 0;
                bar.transform.localScale = new Vector3(scaleX, 1, 1);
            }
        }

    }
    private void OnDrawGizmos()
    {
        if (visionAngle <= 0) return;
        float halfVisionAngle = visionAngle / 2;
        UnityEditor.Handles.color = color;
        Vector3 discPostition = this.transform.position + (this.transform.forward * visionDistance);
        float discRadius = visionDistance * Mathf.Tan(halfVisionAngle * Mathf.Deg2Rad);
        UnityEditor.Handles.DrawSolidDisc(discPostition, this.transform.forward, discRadius);
        Gizmos.DrawLine(this.transform.position, this.transform.position +(this.transform.forward * visionDistance));
        int linesAmount = sides / 4;
        for (int i = 0; i < linesAmount ; i++) {
            Vector3[] verts = new Vector3[]
           {
                this.transform.position,
                this.transform.position,
                discPostition + ((Vector3.Slerp(this.transform.up, this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition + ((Vector3.Slerp(this.transform.up, this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
           };
            UnityEditor.Handles.DrawSolidRectangleWithOutline(verts, color, color);
            verts = new Vector3[]
           {
                this.transform.position,
                this.transform.position,
                discPostition - ((Vector3.Slerp(this.transform.up, this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition - ((Vector3.Slerp(this.transform.up, this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
           };
            UnityEditor.Handles.DrawSolidRectangleWithOutline(verts, color, color);
            verts = new Vector3[]
           {
                this.transform.position,
                this.transform.position,
                discPostition + ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition + ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
           };
            UnityEditor.Handles.DrawSolidRectangleWithOutline(verts, color, color);
            verts = new Vector3[]
           {
                this.transform.position,
                this.transform.position,
                discPostition - ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition - ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
           };
            UnityEditor.Handles.DrawSolidRectangleWithOutline(verts, color, color);
        }
        
    }

    private bool IsInFOV(Vector3 playerVec, Vector3 thisRight, float maxAngle, float distance) {
        float angle = Vector3.Angle(playerVec.normalized, thisRight);
        float maxDistance = distance / Mathf.Cos(angle * Mathf.Deg2Rad);

        return angle <= maxAngle && playerVec.magnitude <= maxDistance;
    
    }
}
