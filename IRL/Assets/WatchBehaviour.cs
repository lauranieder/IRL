using UnityEngine;
using System.Collections;
using System;

public class WatchBehaviour : MonoBehaviour {

	[Range(0.0f, 100.0f)]
	public float speed;

	public GameObject SecondHand;
	public GameObject MinuteHand;
	public GameObject HourHand;

	// Use this for initialization
	void Awake () {
		Debug.Log ("awake");
	}



	// Use this for initialization
	void Start () {
		Debug.Log ("start");
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.right * Time.deltaTime *speed);

		DateTime currentTime = DateTime.Now;
		float second = (float) currentTime.Second;
		float minute = (float) currentTime.Minute;
		float hour = (float) currentTime.Hour%12;

		float secondAngle = -360 * (second/60);
		float minuteAngle = - 360*(minute/60);
		float hourAngle = - 360*(hour/12);

		SecondHand.transform.localRotation = Quaternion.Euler(0,secondAngle, 0);
		MinuteHand.transform.localRotation = Quaternion.Euler(0,minuteAngle, 0);
		HourHand.transform.localRotation = Quaternion.Euler(0,hourAngle, 0);
	
	}
}
