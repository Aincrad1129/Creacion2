using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Threading.Tasks;

public class FieldOfViewDetec : MonoBehaviour
{
    //[SerializeField] private Transform player;
    [SerializeField] private GameManager gameManager;
    [Header("Condiguracion camara")]
    [Tooltip("Angulo de vision de la camara")]
    [SerializeField] [Range(0f, 180f)] private float visionAngle;
    [Tooltip("Distancia de vision de la camara")]
    [SerializeField] private float visionDistance;

    [Header("Object")]
    [Tooltip("Empy game Object")]
    [SerializeField] private GameObject cameraViewObject;
    [Tooltip("Cantidad de lados")]
    [SerializeField] [Range(0f, 24f)] private int sides;
    [Tooltip("Material base")]
    [SerializeField] private Material baseMat;
    [Tooltip("Material activo")]
    [SerializeField] private Material alertaMat;
    [Tooltip("Show UI guide")]
    [SerializeField] private bool showGuide;
    private Mesh mesh;
    private MeshRenderer meshRenderer;
    List<Vector3> verts = new List<Vector3>();
    private float angleAmount;
    private float angle;
    private Vector3 ConeCenter;
    private Vector3 ConeSpike;
    private List<int> triangles = new List<int>();

    [Header("IU de la camara")]
    [Tooltip("UI de alerta")]
    [SerializeField] private GameObject alertUI;
    [Tooltip("Barra de carga")]
    [SerializeField] private GameObject bar;
    [Tooltip("Tiempo para que la camara mate al jugador")]
    [SerializeField] private int cameraTime;




    private float timer;
    private float scaleX;
    private bool _isviewingPlayer;
    public bool isviewingPlayer { get => _isviewingPlayer; }

    private bool isOn;

    private KillPlayer killPlayer;

    private void Awake()
    {
        isOn = true;
        killPlayer = FindObjectOfType<KillPlayer>();
        GeterateMesh();
        showGuide = false;
        cameraViewObject.GetComponent<ObjectCollider>().CollideWithPlayerEnter += () => PlayerEnter();
        cameraViewObject.GetComponent<ObjectCollider>().CollideWithPlayerExit += () => PlayerExit();
        PlayerExit();
    }
    private void GeterateMesh()
    {
        cameraViewObject.AddComponent<MeshFilter>();
        meshRenderer = cameraViewObject.AddComponent<MeshRenderer>();
        meshRenderer.material = baseMat;
        mesh = cameraViewObject.GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        angleAmount = 2 * Mathf.PI / sides;
        angle = 0;
        ConeSpike = Vector3.zero + (Vector3.forward * visionDistance);
        verts.Add(ConeSpike);
        ConeCenter = Vector3.zero;
        verts.Add(ConeCenter);
        float halfVisionAngle = visionAngle / 2;
        float discRadius = visionDistance * Mathf.Tan(halfVisionAngle * Mathf.Deg2Rad);

        for (int i = 0; i < sides; i++)
        {
            verts.Add(new Vector3(discRadius * Mathf.Sin(angle), discRadius * Mathf.Cos(angle), visionDistance));

            angle -= angleAmount;
        }

        mesh.vertices = verts.ToArray();

        for (int i = 2; i < sides + 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i);
        }

        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(sides + 1);

        for (int i = 2; i < sides + 1; i++)
        {
            triangles.Add(1);
            triangles.Add(i);
            triangles.Add(i + 1);
        }

        triangles.Add(1);
        triangles.Add(sides + 1);
        triangles.Add(2);
        mesh.triangles = triangles.ToArray();
        cameraViewObject.AddComponent<MeshCollider>().sharedMesh = mesh;
        cameraViewObject.GetComponent<MeshCollider>().convex = true;
        cameraViewObject.GetComponent<MeshCollider>().isTrigger = true;
    }
    private async void PlayerEnter()
    {
        if (gameManager.pause) return;
        if (!isOn) return;
        _isviewingPlayer = true;
        meshRenderer.material = alertaMat;
        alertUI.SetActive(true);
        timer = Time.time + cameraTime;
        scaleX = 0;
        while (Time.time < timer)
        {
            if (!isviewingPlayer || !isOn) return;
            scaleX = (Time.time +cameraTime - timer) / cameraTime;
            bar.transform.localScale = new Vector3(scaleX, 1, 1);
            await Task.Yield();
        }
        scaleX = 1;
        bar.transform.localScale = new Vector3(scaleX, 1, 1);
        killPlayer.Kill();

    }
    private void PlayerExit()
    {
        _isviewingPlayer = false;
        meshRenderer.material = baseMat;
        alertUI.SetActive(false);
        scaleX = 0;
        bar.transform.localScale = new Vector3(scaleX, 1, 1);
    }

    public void SwitchOn_OFFCamera(bool state){
        isOn = state;
        cameraViewObject.SetActive(state);
    }

    private void OnDrawGizmos()
    {
        if (showGuide)
        {
            if (visionAngle <= 0) return;
            float halfVisionAngle = visionAngle / 2;
            Handles.color = baseMat.color;
            Vector3 discPostition = this.transform.position + (this.transform.forward * visionDistance);
            float discRadius = visionDistance * Mathf.Tan(halfVisionAngle * Mathf.Deg2Rad);
            Handles.DrawSolidDisc(discPostition, this.transform.forward, discRadius);
            Gizmos.DrawLine(this.transform.position, this.transform.position + (this.transform.forward * visionDistance));
            int linesAmount = sides / 4;
            for (int i = 0; i < linesAmount; i++)
            {
                Vector3[] verts = new Vector3[]
               {
                this.transform.position,
                this.transform.position,
                discPostition + ((Vector3.Slerp(this.transform.up, this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition + ((Vector3.Slerp(this.transform.up, this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
               };
                Handles.DrawSolidRectangleWithOutline(verts, baseMat.color, baseMat.color);
                verts = new Vector3[]
               {
                this.transform.position,
                this.transform.position,
                discPostition - ((Vector3.Slerp(this.transform.up, this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition - ((Vector3.Slerp(this.transform.up, this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
               };
                Handles.DrawSolidRectangleWithOutline(verts, baseMat.color, baseMat.color);
                verts = new Vector3[]
               {
                this.transform.position,
                this.transform.position,
                discPostition + ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition + ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
               };
                Handles.DrawSolidRectangleWithOutline(verts, baseMat.color, baseMat.color);
                verts = new Vector3[]
               {
                this.transform.position,
                this.transform.position,
                discPostition - ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)i / linesAmount)) * discRadius),
                discPostition - ((Vector3.Slerp(this.transform.up, -this.transform.right, (float)(i+1) / linesAmount)) * discRadius)
               };
                Handles.DrawSolidRectangleWithOutline(verts, baseMat.color, baseMat.color);
            }
        }

    }
}
