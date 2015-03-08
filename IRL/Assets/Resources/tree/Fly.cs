using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {
	float f;
	float growing = 0;
	Vector3 scaling = new Vector3(10, 10, 10);
	public bool shaked = false;
	Vector3 nextPoint = new Vector3();
	Vector3 currentPoint;
	Vector3 diff;
	Vector3 vel;
	float delayPi;
	float speed;
	float speedTemp;
	float mag;
	float parentSpeed = 0;
	float parentDist = 0;
	Vector3 parentOldPos;
	Vector3 parentPos;
	GameObject arbreBase;
	AudioSource ac;
	float quot;
	GameObject p;
	bool afraid = false;
	// Use this for initialization
	void Start () {
		delayPi = Random.Range(5f, 10f);
		ac = GetComponent<AudioSource>();
		ac.pitch = Random.Range(2, 5);
		//
		speed = Random.Range(1.5f, 3.5f);
		f = Random.Range(0.1f, 1f);
		arbreBase = GameObject.Find("ARBRE");


	}
	
	// Update is called once per frame
	void Update () {
		speedTemp += (speed-speedTemp)/2f;
		parentOldPos = parentPos;
		parentPos = p.transform.position;
		parentDist += Vector3.Distance(parentOldPos, parentPos);
		parentDist *= 0.95f;
		//
		if(parentDist > 100) {
			parentDist = 0;
			StartCoroutine("fear");
		}
		if(afraid) {
			// nothing
		} else {
			nextPoint = parentPos;
		}
	}
	IEnumerator fear() {
		afraid = true;
		//speedTemp *=5;
		genNextPoint();
		yield return new WaitForSeconds(Random.Range(1f, 3f));
		nextPoint = parentPos;
		afraid = false;
	}
	void SetParent(GameObject _p) {
		p = _p;
		parentOldPos = p.transform.position;
		parentPos = p.transform.position;
		StartCoroutine("move");
		StartCoroutine("grow");
	}
	void genNextPoint() {
		Vector3 diff = parentPos-arbreBase.transform.position;
		nextPoint = arbreBase.transform.position+diff*1.5f+Random.insideUnitSphere*100;
	}
	IEnumerator pi() {
		while(true) {
			yield return new WaitForSeconds(delayPi);
			ac.Play();
		}
	}
	IEnumerator move() {
		while(true) {
			currentPoint = transform.position;
			if(Vector3.Distance(nextPoint, currentPoint) < 25f) {
				genNextPoint();
			}
			diff = nextPoint-currentPoint;

			if(diff.magnitude < 100) {
				quot = diff.magnitude/100f;
			}
			quot+=0.01f;
			//mag = diff.magnitude;
			vel += diff*0.01f;
			if(vel.magnitude > speedTemp*quot) {
				vel.Normalize();
				vel*=speedTemp*quot;
			}
			currentPoint += vel*speedTemp*quot;
			transform.position = currentPoint;
			yield return new WaitForSeconds(0.025f);
		}
	}
	IEnumerator grow() {
		while(growing < 1) {
			this.transform.localScale = scaling*growing;
			growing+=0.05f;
			yield return new WaitForSeconds(0.001f);
		}
		//yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));

		//StartCoroutine("pi");
	}
}
