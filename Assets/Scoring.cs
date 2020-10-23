using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
	public CarController car;
    public Transform Player;
    public Text scoreTime;
    public float timeC;
	public PlayerCollision carCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(carCol.flag==0)
			scoreTime.text = "Game Over\nYour Score:"+timeC.ToString(".0");
		else
		{
			timeC = timeC + Time.deltaTime;
        scoreTime.text = timeC.ToString("Current Time: .0");
		}

    }
}