using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rbody;
	private static string switchAngle;
	public static float loseTrack;
	public static float questionCounter;
	public static float deathCounter;
	public static bool fallen;

	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody> ();
		speed = 2000f;
		loseTrack = 0f;
		questionCounter = 5f;
		deathCounter = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switchAngle = CameraController.angleChecker;
		float inputX = 0;
		float inputZ = 0;

		//INPUT "W"
		if(Input.GetKey ("w"))
		{
			if (switchAngle.Equals ("MAIN")) 
			{
				inputZ = 1;
			}
			if (switchAngle.Equals ("BACK")) 
			{
				inputZ = -1;
			}
			if (switchAngle.Equals ("LEFT")) 
			{
				inputX = -1;
			}
			if (switchAngle.Equals ("RIGHT")) 
			{
				inputX = 1;
			}
		}

		//INPUT "A"
		if(Input.GetKey ("a"))
		{
			if (switchAngle.Equals ("MAIN")) 
			{
				inputX = -1;
			}
			if (switchAngle.Equals ("BACK")) 
			{
				inputX = 1;
			}
			if (switchAngle.Equals ("LEFT")) 
			{
				inputZ = -1;
			}
			if (switchAngle.Equals ("RIGHT")) 
			{
				inputZ = 1;
			}
		}

		//INPUT "D"
		if(Input.GetKey ("d"))
		{
			if (switchAngle.Equals ("MAIN")) 
			{
				inputX = 1;
			}
			if (switchAngle.Equals ("BACK")) 
			{		
				
				inputX = -1;
			}
			if (switchAngle.Equals ("LEFT")) 
			{
				inputZ = 1;
			}
			if (switchAngle.Equals ("RIGHT")) 
			{
				inputZ = -1;
			}
		}

		//INPUT "S"
		if(Input.GetKey ("s"))
		{
			if (switchAngle.Equals ("MAIN")) 
			{
				inputZ = -1;
			}
			if (switchAngle.Equals ("BACK")) 
			{
				inputZ = 1;
			}
			if (switchAngle.Equals ("LEFT")) 
			{
				inputX = 1;
			}
			if (switchAngle.Equals ("RIGHT")) 
			{
				inputX = -1;
			}
		}
			





		//ACTIVATE THESE TO FIND X, Y, & Z OF PLAYER!!!!!!!!!!!!!
		//print("X" + transform.position.x);
		//print ("Y" + transform.position.y);
		//print ("Z" + transform.position.z);




		//Reset for Fall

		if(transform.position.y < 0)
		{
			//loseTrack = 1f;
			questionCounter = 0;
			rbody.velocity = new Vector3 (0, 0, 0);
			rbody.transform.position = new Vector3 (0, 4, 0);
			questionCounter = 5;
			deathCounter++;
			fallen = true;

		}



		//TRIGGER AREAS


		if (transform.position.z > 15 && transform.position.z < 20) 
		{
			loseTrack = 0f;
			questionCounter = 0f;
			//print ("get rid of it");
		}

		if (transform.position.z > -8 && transform.position.x < -8 && transform.position.x > 8 && transform.position.z < 10) 
		{
			questionCounter = 5;
		}

		if (transform.position.y < 3) 
		{
			fallen = false;
		}

		if (transform.position.z > 700 && transform.position.z < 850 && transform.position.x > -100 && transform.position.x < 145) 
		{
			questionCounter = 6;
		}

		if (transform.position.x > 145 && transform.position.x < 450)
		{
			questionCounter = 0;
		}

		if (transform.position.z > 650 && transform.position.x > 450 && transform.position.z < 910 && transform.position.x < 870 && transform.position.y > 0) 
		{
			questionCounter = 1;
			//print ("I'M ALIVE: Says 1");
		}

		if (transform.position.z > 910 && transform.position.x > 870 && transform.position.y > 0 && transform.position.z < 1245 && transform.position.x < 950) 
		{
			questionCounter = 2;
			//print ("NUMBER 2 AWAKE");
		}

		if (transform.position.z > 1245 && transform.position.y > 0 && transform.position.z < 2200 && transform.position.x < 950) 
		{
			questionCounter = 0;
			//print ("BLANK IS STILL ACTIVE!");
		}

		if (transform.position.z > 2200 && transform.position.x > 950 && transform.position.x < 1850 && transform.position.y > 0) 
		{
			questionCounter = 3;
			//print ("should be 3");
		}

		if (transform.position.x > 1850 && transform.position.x < 1900 && transform.position.y > 0) 
		{
			questionCounter = 0;
			//print ("I AM IN THE MIDST OF RESETING!!!");
		}

		if (transform.position.x > 2000 && transform.position.x < 2100 && transform.position.z > 2400 && transform.position.z < 2500 && transform.position.y > 0 && transform.position.y <= 52) 
		{
			questionCounter = 4;
			fallen = true;
			rbody.velocity = new Vector3 (0, 0, 0);
			rbody.transform.position = new Vector3 (0, 4, 0);
		}




		//2400-2500 is safe in z
		//2000-2100 is safe for x



		float moveX = inputX * Time.deltaTime * speed;
		float moveZ = inputZ * Time.deltaTime * speed;
		rbody.AddForce (moveX, 0f, moveZ);
	}





}
