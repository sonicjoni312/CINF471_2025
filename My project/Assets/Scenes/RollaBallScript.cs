using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollaBallScript : MonoBehaviour
{
    int score = 0;
    public GameObject cube;
    Transform t;
    float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(t.position.y > 10)
        {
            speed = speed * -1;
        }
        else if(t.position.y < -10)
        {
            speed = speed * -1;
        }
        t.Translate(0,speed,0);

    }
}
