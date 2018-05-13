using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransferText : MonoBehaviour {

	public Text loseText;
	public Text prompt;
	public Text death;
	private static float checker;
	private static float qCount;
	private static float fallCount;

	// Use this for initialization
	void Start () 
	{
		loseText.text = "";
		prompt.text = "";
		checker = 0f;
		fallCount = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		checker = PlayerController.loseTrack;
		qCount = PlayerController.questionCounter;
		fallCount = PlayerController.deathCounter;

		if (checker == 1f) 
		{
			loseText.text = "YOU LOSE";
		}

		if (checker == 0f) 
		{
			//print ("did i get rid of it???");
			loseText.text = "";
		}

		if (qCount == 0f) 
		{
			prompt.text = "";
		}

		if (qCount == 1f) 
		{
			//red
			prompt.text = "What is the derivative of y = Bx + C?\n\nBlue: y = 0\nGreen: y = Cx + B\nRed: y = B";
		}

		if(qCount == 2f)
		{
			//green
			prompt.text = "What is the derivative of y = A cos(x)?\n\nBlue: y = sin(x)\nGreen: y = - A sin(x)\nRed: y = A sin(x)";
		}

		if (qCount == 3f) 
		{
			//blue
			prompt.text = "What is the derivative of e^x?\n\nBlue: e^x\nGreen: x^2\nRed: e";
		}

		if (qCount == 4f) 
		{
			prompt.text = "WOOHOO!\n\nYOU WIN!!!";
		}

		if (qCount == 5f) 
		{
			//green
			prompt.text = "What is the derivative of y = 5?\n\nBlue: y = 5\nGreen: y = 0\nRed: y = x^5";
		}

		if (qCount == 6f) 
		{
			//blue
			prompt.text = "What is the derivative of y = x^2?\n\nBlue: y = 2x\nGreen: y = 0\nRed: y = 2x^2";
		}

		death.text = "DEATHS: " + fallCount;


	}



}
