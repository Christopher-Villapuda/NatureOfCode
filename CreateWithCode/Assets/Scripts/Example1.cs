using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example1 : MonoBehaviour
{
    private float x = 0F;
    private float y = 0F;
    // adjust speed of mover in case too fast or too slow. In this case it is way too fast.
    [SerializeField]
    private float xSpeed = 0.1F;
    [SerializeField]
    private float ySpeed = 0.1F;

    private float xMin, yMin, xMax, yMax;
    private GameObject mover;

    void Start()
    {
        //Generating a sphere via the camera script is not very efficient since any modifications will interfere with the camera.
        // Instead you can create the sphere then define a max x and y bound that would reverse velocity when the sphere hit the bounds.
        //Any edits on the sphere would be made through that and not accidentally ruin the camera and casue complier errors. It also allows you to change the bounds before or past the camera bounds
        //and not loock yourself to the camera width and height.
        Camera.main.orthographic = true;
        Vector2 minimumPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Vector2 maximumPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        xMin = minimumPosition.x;
        xMax = maximumPosition.x;
        yMin = minimumPosition.y;
        yMax = maximumPosition.y;
        mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    void Update()
    {
        bool xHitBoarder = x > xMax || x < xMin;
        bool yHitBoarder = y > yMax || y < yMin;
        if (xHitBoarder)
        {
            xSpeed = -xSpeed;
        }

        if (yHitBoarder)
        {
            ySpeed = -ySpeed;
        }
        x += xSpeed;
        y += ySpeed;
        mover.transform.position = new Vector2(x, y);
    }
}
