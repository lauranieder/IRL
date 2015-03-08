using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {
	float f;
	float growing = 0;
	Vector3 s = new Vector3(10f, 10f, 10f);
	public bool shaked = false;
	Vector3 nextPoint;
	Vector3 basePoint;
	Vector3 currentPoint;
	Vector3 diff;
	Vector3 vel;
	float delayPi;
	float speed;
	float mag;
	AudioSource ac;
	// Use this for initialization
	void Start () {
		delayPi = Random.Range(5f, 10f);
		ac = GetComponent<AudioSource>();
		ac.pitch = Random.Range(2, 5);
		//
		speed = Random.Range(0.6f, 0.8f);
		basePoint = transform.position;
		f = Random.Range(0.1f, 1f);
		this.transform.localScale = s;
		StartCoroutine("grow");
	}
	
	// Update is called once per frame
	void Update () {
		/*this.rigidbody.AddTorque(f, 0, f);
		if(shaked) {
			this.rigidbody.AddForce(f/2, f, 0);

		}*/
	}
	void genNextPoint() {
		nextPoint = Random.insideUnitSphere*10+basePoint;
		if(nextPoint.y<0) {
			nextPoint.y*=-1;
		}
		nextPoint.y+=1;
	}
	IEnumerator pi() {
		while(true) {
			yield return new WaitForSeconds(delayPi);
			ac.Play();
		}
	}
	IEnumerator move() {
		genNextPoint();
		while(true) {
			currentPoint = transform.position;
			if(Vector3.Distance(nextPoint, currentPoint) < 25f) {
				genNextPoint();
			}
			diff = nextPoint-currentPoint;
			//mag = diff.magnitude;
			vel += diff.normalized*0.1f;
			if(vel.magnitude > speed) {
				vel.Normalize();
				vel*=speed;
			}
			currentPoint += vel*speed;
			transform.position = currentPoint;
			yield return new WaitForSeconds(0.025f);
		}
	}
	IEnumerator grow() {
		while(growing < 1) {
			s.x = growing;
			s.y = growing;
			s.z = growing;
			this.transform.localScale = s*0.05f;
			growing+=0.05f;
			yield return new WaitForSeconds(0.001f);
		}
		yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
		//StartCoroutine("move");
		//StartCoroutine("pi");
	}
}
