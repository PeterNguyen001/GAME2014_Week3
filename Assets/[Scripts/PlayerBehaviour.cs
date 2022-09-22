using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 10;
    public Boundary boundary;
    public float verticalPosition = -4;
    private Camera camera;
    public float verticalSpeed = 10.0f;
    public bool usingMobileInput = false;

    void Start()
    {
        camera =Camera.main;
        usingMobileInput = Application.platform != RuntimePlatform.Android ||
                      Application.platform != RuntimePlatform.IPhonePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
        {
            MobileInput();
        }
        else
        {
            ConventionalInout();
        }

        Move();
    }

    public void Move()
    {
        float clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, verticalPosition);
    }

    

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * verticalSpeed);
        }
    }

    public void ConventionalInout()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.position += new Vector3(x, 0.0f, 0.0f);
    }
}
