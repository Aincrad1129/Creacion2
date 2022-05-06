using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewDetec : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    [SerializeField] [Range(0f, 180f)] private float visionAngle;
    [SerializeField] private float visionDistance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         Vector3 playerVector = player.position - this.transform.position;
         if (IsInFOV(playerVector, this.transform.right, visionAngle / 2, visionDistance))
         {
             print("dead");
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
        Gizmos.DrawLine(this.transform.position, player.position);
    }

    private Vector2 PointForAngle(float angle, float distance) => this.transform.TransformDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad))) * distance;

    private bool IsInFOV(Vector3 playerVec, Vector3 thisRight, float angle, float distance)=> Vector3.Angle(playerVec.normalized, thisRight) <= angle && playerVec.magnitude <= distance;
    
}
