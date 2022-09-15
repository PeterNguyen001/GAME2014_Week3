using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 10;
    public Boundary boundary;
    public float verticalPosition;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);
        float clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, verticalPosition);
    }

    
}
