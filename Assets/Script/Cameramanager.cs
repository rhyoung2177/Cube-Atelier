using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour
{
    public Transform camera1;
    public Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GameObject.Find("Floor").GetComponent<Transform>();
        camera1 = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LBtDown()
    {
        camera1.transform.RotateAround(tr.position, Vector3.up, 30f);
    }

    public void RBtDown()
    {
        camera1.transform.RotateAround(tr.position, Vector3.up, -30f);
    }
}
