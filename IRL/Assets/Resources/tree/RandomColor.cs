using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {
	Material[] materials;
	// Use this for initialization
	void Start () {
		materials = new Material[4];
		materials[0] = Resources.Load("matC") as Material;
		materials[1] = Resources.Load("matM") as Material;
		materials[2] = Resources.Load("matJ") as Material;
		materials[3] = Resources.Load("matN") as Material;
		//foreach (Transform child in this.transform) {
			renderer.material = materials[Random.Range(0, materials.Length)];
		//}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
