using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	public CarController movement;
    public GameObject car;
	public 	float flag=1f;
    void Update()
    {
    }


    void OnCollisionEnter(Collision hit)
    {
        
        if (hit.collider.tag == "tree")
        {
			flag=0;
            movement.enabled=false;
			Destroy(car);
        }
		
    }
}
