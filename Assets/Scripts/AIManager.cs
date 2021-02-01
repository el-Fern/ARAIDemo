using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public GameObject Intersector;
    public MeshCollider walls;
    //public bool[] mazeArray = new bool[80, 80]();

    void Start()
    {
        GenerateArray();
    }

    void GenerateArray()
    {
        var x = (float)-50;
        var z = (float)-50;

        while (x <= (float)50)
        {
            //Debug.Log(Intersector.position);
            Intersector.transform.Translate(new Vector3((float)1.25, 0, 0));
            x += (float)1.25;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(contact.point);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
