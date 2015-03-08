using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour {
	//bool activate = false;
	bool created = false;
	// Use this for initialization
	void Start () {
		//activate = renderer.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(renderer.enabled != activate && !created) {
			created = true;
			activate = renderer.enabled;
			this.BroadcastMessage("CreateTree");
		}*/
	}
	void On() {
		if(!created) {
			created = true;
			this.BroadcastMessage("CreateTree");
		}
	}
	void Off() {

	}
}
