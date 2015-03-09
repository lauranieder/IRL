using UnityEngine;
using System.Collections;

public class Reactions : MonoBehaviour {
	bool active;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//	if(this.transform.rotation) {
	//	}
		Vector3 posDir = transform.rotation*Vector3.forward;
		if(posDir.x<0) {
			if(active) {
				active = false;
				BroadcastMessage("Open");
			}
		} else {
			if(!active) {
				active = true;
				BroadcastMessage("Close", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
