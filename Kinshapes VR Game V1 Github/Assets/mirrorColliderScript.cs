using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorColliderScript : MonoBehaviour
{

    public bool stay = true;
    public bool exit = true;
    public bool canMoveMirror = false;
    private float stayCount = 0.0f;
    public GameObject mirrorFrame;
    // Start is called before the first frame update

    void Start()
    {
        mirrorFrame.name = "mirrorStand";
    }

    // Update is called once per frame
    void Update()
    {
        if(canMoveMirror)
        {
            if (Input.GetKey(KeyCode.J))
            {
                print("left arrow key is held down");
                mirrorFrame.transform.Rotate(0, 0, 0.5f, Space.Self);
            }

            if (Input.GetKey(KeyCode.L))
            {
                print("right arrow key is held down");
                mirrorFrame.transform.Rotate(0,0, -0.5f,Space.Self);

            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            if (stayCount > 0.25f)
            {
                canMoveMirror = true;
                Debug.Log("staying");
                stayCount = stayCount - 0.25f;


            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            canMoveMirror = false;
            Debug.Log("exit");
        }
    }

}
