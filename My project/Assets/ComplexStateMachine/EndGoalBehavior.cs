using UnityEngine;

public class EndGoalBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("You won the maze!");
        //Debug.Log(collision.gameObject.name + " starts colliding with us")
    }

}


