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
        if (IsInFOV(playerVector, this.transform.right, visionAngle / 2, visionDistance))
        {
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
                    //killPlayer.Kill();
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
        Vector2 p1, p2;
        p1 = PointForAngle(halfVisionAngle, visionDistance);
        p2 = PointForAngle(-halfVisionAngle, visionDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, (Vector2)this.transform.position + p1);
        Gizmos.DrawLine(this.transform.position, (Vector2)this.transform.position + p2);
    }

    private Vector2 PointForAngle(float angle, float distance) => this.transform.TransformDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad))) * distance;

    private bool IsInFOV(Vector3 playerVec, Vector3 thisRight, float angle, float distance) => Vector3.Angle(playerVec.normalized, thisRight) <= angle && playerVec.magnitude <= distance;
}
