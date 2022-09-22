using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Boundary horBound;
    public Boundary vertBound;
    public Boundary horSpeedRange;
    public float horSpeed;

    // Start is called before the first frame update
    void Start()
    {
        var RandXPos = Random.Range(horBound.min, horBound.max);
        var RandYPos = Random.Range(vertBound.min, vertBound.max);
        horSpeedRange.min = Random.Range(0.5f, 2);
        horSpeedRange.max = Random.Range(2.0f, 6);
        horSpeed = Random.Range(horSpeedRange.min, horSpeedRange.max);
        transform.position = new Vector3(RandXPos, RandYPos, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var verticalLength = vertBound.min - horBound.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horSpeed, verticalLength) - horBound.max, 
            transform.position.y, transform.position.z);
    }
}
