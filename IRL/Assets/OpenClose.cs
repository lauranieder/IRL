using UnityEngine;
using System.Collections;

public class OpenClose : MonoBehaviour {
	// Use this for initialization
	Vector3 positionStart;
	Quaternion rotationStart;
	Vector3 positionGo;
	Quaternion rotationGo;
	//
	public Vector3 rotationAdd;
	public Vector3 positionAdd;
	//
	float steps = 10f;
	float delay = 0.01f;
	//
	void Start () {
		positionStart = transform.localPosition;
		rotationStart = transform.localRotation;
		positionGo = transform.localPosition+positionAdd;
		Debug.Log("POS GO: "+positionGo);
		rotationGo = Quaternion.Euler(transform.localRotation.eulerAngles+rotationAdd);
		//StartCoroutine("Open");
	}
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Open() {
		Debug.Log("OPEN");
		StopCoroutine("Close");
		for(int i = 0; i<=steps; i++) {
			//Quaternion go, start;
			//go = Quaternion.Euler(rotationGo);
			//start = Quaternion.Euler(rotationStart);
			transform.localPosition = Vector3.Lerp(positionStart, positionGo, i/steps);
			transform.localRotation = Quaternion.Lerp(rotationStart, rotationGo, i/steps);
			yield return new WaitForSeconds(delay);
		}
		//StartCoroutine("Close");
	}
	IEnumerator Close() {
		Debug.Log("CLOSE");
		StopCoroutine("Open");
		for(int i = 0; i<=steps; i++) {
			//Quaternion go, start;
			//go = Quaternion.Euler(rotationGo);
			//start = Quaternion.Euler(rotationStart);
			transform.localPosition = Vector3.Lerp(positionGo, positionStart, i/steps);
			transform.localRotation = Quaternion.Lerp(rotationGo, rotationStart, i/steps);
			yield return new WaitForSeconds(delay);
		}
		//StartCoroutine("Open");
	}
}
