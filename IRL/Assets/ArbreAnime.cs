using UnityEngine;
using System.Collections;

public class ArbreAnime : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void On() {
		StartCoroutine("launch");
	}
	void Off() {
		StopCoroutine("launch");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
