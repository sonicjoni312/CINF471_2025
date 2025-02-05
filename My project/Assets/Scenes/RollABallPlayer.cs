using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RollABallPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 m;
    Rigidbody rb;
    void Start()
    {
        m = new Vector2 (0,0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_dir = m.x;
        float z_dir = m.y;
        Vector3 actual_movement = new Vector3(x_dir,0,z_dir);
        print(actual_movement);

        rb.AddForce(actual_movement);
    }
    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }
}
