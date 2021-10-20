using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BezierCurve : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    // Adjust Bar between 0 and 1 for Bez Curve
    [Range (0.0f,1.0f)]
    public float t=0;

    //bool for moving forward or back for curve
    public bool Forward;
    public bool Backward;
    
    //vectors for points
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Vector3 d;
    public Vector3 e;
    public Vector3 point;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Forward)
        {
            Mathf.Lerp(0.0f, 1.0f, Time.deltaTime);
        }

        if (Backward)
        {
            Mathf.Lerp(0, 1, Time.time);
        }
    }

    // Update is called once per frame
    void Update()
    {
         
        a = Vector3.Lerp( p0.position, p1.position, t );
        b = Vector3.Lerp( p1.position, p2.position, t );
        c = Vector3.Lerp( p2.position, p3.position, t );
        d = Vector3.Lerp( a, b, t );
        e = Vector3.Lerp( b, c, t );
        point = Vector3.Lerp( d, e, t );
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(point, 0.7f);
    }
}
