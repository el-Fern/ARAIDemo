using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class AIManager : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public GameObject Intersector;
    public MeshCollider walls;
    private int[,] mazeArray = new int[81, 81];
    private float x = (float)0;
    private float z = (float)1.25;
    private bool otherFrame = true;
    int counter = 0;

    void Start()
    {
        for (int i = 0; i < 81; i++)
        {
            for (int g = 0; g < 81; g++)
            {
                mazeArray[i, g] = 0;
            }
        }

    }
    void Update()
    {
        if (otherFrame)
        {
            Intersector.transform.position = new Vector3(200, 1, 200);
            if (counter % 30 == 0)
            {
                otherFrame = !otherFrame;
            }
            counter++;
        }
        else if (x < (float)100)
        {
            Intersector.transform.position = new Vector3(x, 1, z);
            Intersector.transform.rotation = Quaternion.identity;
            if (counter % 30 == 0)
            {
                otherFrame = !otherFrame;
                x += (float)1.25;
            }
            if(x == 100 && z== 100)
            {
                PrintArray();
                Application.Quit();
            }
            counter++;
        }
        else if(z <= (float)100)
        {
            x = (float)0;
            z += (float)1.25;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        var collisionPoint = collision.contacts[collision.contacts.Length - 1].point;
        var arrayXEl = Convert.ToInt32(Math.Round(x / 1.25));
        var arrayYEl = Convert.ToInt32(Math.Round(z / 1.25));

        Debug.Log("Adding to X: " + arrayXEl.ToString() + ", Y: " + arrayYEl.ToString());
        mazeArray[arrayXEl, arrayYEl] = 1;
        //Debug.Log(collision.contacts[collision.contacts.Length - 1].point);
    }
    void PrintArray()
    {
        var lines = new List<string>();
        for (int i = 0; i < 81; i++)
        {
            var line = "";
            for (int g = 0; g < 81; g++)
            {
                line += mazeArray[i, g];
            }
            lines.Add(line);
            Debug.Log(line);
        }
        System.IO.File.WriteAllLines(@"C:\Users\brack\Documents\WriteLines.txt", lines);
    }
    //void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("EXIT");

    //    Debug.Log(collision.contacts[collision.contacts.Length - 1].point);
    //}
    //void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("STAY");


    //    Debug.Log(collision.contacts[collision.contacts.Length - 1].point);
    //}
}
