using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	private Vector3 initialOffset;

	private Vector3 angle;

	private double n;

	private static bool reset;



	public static string angleChecker;

	void Start ()
	{
		initialOffset = transform.position - player.transform.position;
		offset = initialOffset;
		offset = new Vector3 (0, 3, 0);
		angle = new Vector3 (0, 0, 0);
		transform.localEulerAngles = angle;
		angleChecker = "MAIN";
		n = 0.0;
	}

	void Update ()
	{
		//LEFT CAMERA
		/*if (Input.GetKeyDown ("n")) //this is opposed to Input.GetKey()
									//becasue this only registers it once
		{
			angle = new Vector3(0, -90, 0); //saves the new angle of the camera in angle
			transform.localEulerAngles = angle; //uses that angle to be the new camera angle
			//offset = new Vector3 (0, 3, 0); //this switches the offset so that the camera is now part
											//of the ball
			angleChecker = "LEFT";
		}
		*/

		//RIGHT CAMERA
		/*if (Input.GetKeyDown ("."))
		{
			angle = new Vector3(0, 90, 0);
			transform.localEulerAngles = angle;
			offset = new Vector3 (0, 3, 0);
			angleChecker = "RIGHT";

		}
		*/

		//FRONT CAMERA (MAIN CAMERA)
		/*if (Input.GetKeyDown ("m")) 
		{
			angle = new Vector3 (0, 0, 0);
			//angle = new Vector3(30, 0, 0);
			transform.localEulerAngles = angle;
			offset = new Vector3 (0, 3, 0);
			//offset = initialOffset; 
			angleChecker = "MAIN";
		}
		*/

		//BACK CAMERA
		/*if (Input.GetKeyDown (","))
		{
			//angle = new Vector3(30, 180, 0);
			angle = new Vector3(0, 180, 0);
			transform.localEulerAngles = angle;
			offset = new Vector3 (0, 3, 0);
			angleChecker = "BACK";
		}
		*/

		reset = PlayerController.fallen;


		//Left/Right MOD Cam
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			angle.y -= 90;
			transform.localEulerAngles = angle;
			offset = new Vector3 (0, 3, 0);
			n -= .25;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			angle.y += 90;
			transform.localEulerAngles = angle;
			offset = new Vector3 (0, 3, 0);
			n += .25;
		}

		//DOWNISH CAMERA
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			angle.x = 50; //this is the reason why angle is saved because now all "j" does is move the
						  //camera downwards from its original spot (the previous angle)
			transform.localEulerAngles = angle;
		}

		//print ("n: " + n);

		int loops = (int)n;

		//print ("n after loops: " + n);

		//print ("loops: " + loops);

		int finalAngleOff = 360 * loops;

		//print ("finalAngleOff: " + finalAngleOff);

		//print ("angle.y: " + angle.y);

		if (angle.y == finalAngleOff) 
		{
			angleChecker = "MAIN";
		}

		if (angle.y == finalAngleOff + 270 || angle.y == finalAngleOff - 90) 
		{
			angleChecker = "LEFT";
		}

		if (angle.y == finalAngleOff + 90 || angle.y == finalAngleOff - 270) 
		{
			angleChecker = "RIGHT";
		}

		if (angle.y == finalAngleOff + 180 || angle.y == finalAngleOff - 180) 
		{
			angleChecker = "BACK";
		}
			

		//UP Camera
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			angle.x = 0;
			transform.localEulerAngles = angle;
		}

		if (reset == true) 
		{
			angle.y = 0;
			n = 0;
			transform.localEulerAngles = angle;
		}

		if (Input.GetKeyDown ("escape")) 
		{
			print ("working???");
			Application.Quit ();
		}






	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}