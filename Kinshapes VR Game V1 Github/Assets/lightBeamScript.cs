using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class lightBeamScript : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;

    public Vector3 origin;
    public Vector3 direction;

    private RaycastHit rayInfo;
    private lightBeamScript reflection;
    // Start is called before the first frame update
    void Start()
    {


       // origin = gameObject.GetComponent<Transform>().position;
       // direction= new Vector3(-90,0,0);
        rayInfo = new RaycastHit();

        //laser
        Vector3[] initLaserPositions = new Vector3[2] { origin, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
        laserLineRenderer.enabled = true;
        ///

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(origin, direction);
        if (Physics.Raycast(ray, out rayInfo))
        {
            if (rayInfo.transform.gameObject.tag == "mirror") // use whatever logic here to test for hitting a mirror
            {
                Debug.Log("Hit mirror!");
                if (reflection == null)
                {
                    reflection = new lightBeamScript();
                }
                reflection.origin = rayInfo.point;
                reflection.direction = Vector3.Reflect(direction, rayInfo.normal);

                //laser
                Vector3[] nextLaserPositions = new Vector3[2] { rayInfo.point, Vector3.zero };
                laserLineRenderer.SetPositions(nextLaserPositions);
                //
            }
            Debug.DrawLine(origin, rayInfo.point, Color.red);
        }
        else
        {
            Destroy(reflection);
            Debug.DrawRay(origin, direction, Color.blue);
        }
    }
}
*/

public class lightBeamScript : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 direction;

    private RaycastHit rayInfo;
    private lightBeamScript reflection;

    private void Start()
    {

        origin = gameObject.GetComponent<Transform>().position;
        // direction= new Vector3(-90,0,0);
        rayInfo = new RaycastHit();
    }
    void Update()
    {
        Ray ray = new Ray(origin, direction);
        
        if (Physics.Raycast(ray, out rayInfo))

        {
            if (rayInfo.transform.tag == "mirror") // use whatever logic here to test for hitting a mirror
            {
                if (reflection == null)
                {
                    reflection = new lightBeamScript();
                }

                Vector3 incomingVec = rayInfo.point - origin;
               // reflection.direction = Vector3.Reflect(rayInfo.point, rayInfo.transform.forward);
               // reflection.direction = Vector3.Reflect(direction, rayInfo.transform.forward);
                reflection.direction = Vector3.Reflect(direction, rayInfo.normal);

                Debug.Log("hitting mirror");

                reflection.origin = rayInfo.point;
               // reflection.direction = Vector3.Reflect(direction, rayInfo.normal);
                Debug.DrawLine(rayInfo.point, reflection.direction, Color.red);

            }
            Debug.Log("outside hit mirror");
            Debug.DrawLine(rayInfo.point, reflection.direction, Color.blue);

            //Debug.DrawLine(origin, rayInfo.point, Color.blue);
        }
        else
        {
            Destroy(reflection);
            Debug.DrawRay(origin, direction, Color.white);
        }
    }
}