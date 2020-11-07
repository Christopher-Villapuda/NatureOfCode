using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example2 : MonoBehaviour
   {
    private Vector2 location = new Vector2(0F, 0F);
    private Vector2 velocity = new Vector2(0.01F, 0.01F);
    private Vector2 minimumPos, maximumPos;
    private GameObject mover;

    void Start()
    {
        Camera.main.orthographic = true;
        minimumPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    void Update()
    {
        bool xHitBorder = location.x > maximumPos.x || location.x < minimumPos.x;
        bool yHitBorder = location.y > maximumPos.y || location.y < minimumPos.y;

        if (xHitBorder)
        {
            velocity.x = -velocity.x;
        }

        if (yHitBorder)
        {
            velocity.y = -velocity.y;
        }
        location += velocity;
        mover.transform.position = new Vector2(location.x, location.y);
    }
}
