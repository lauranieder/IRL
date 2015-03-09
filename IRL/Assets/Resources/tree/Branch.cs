using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Branch : MonoBehaviour {
	Vector3 dim;
	public float ratio = 30;
	public float life = 4;
	int nbr = 3;
	float angleMax = 60;
	float growing = 0;
	Vector3 endScale;
	Vector3 startScale;
	Vector3 scale;
	float delay;
	GameObject cube;
	List<GameObject> children = new List<GameObject>();
	//Material[] materials;
	// Use this for initialization
	void Update() {

	}
	public void CreateTree() {
		delay = Random.Range(0.001f, 0.04f);
		//
		startScale = transform.localScale;
		endScale = transform.localScale;
		scale = transform.localScale;
		//
		startScale.y = 0;
		StartCoroutine("grow");
	}
	void DestroyTree() {
		/*foreach(GameObject go in children) {
			go.BroadcastMessage();
		}*/
	}
	void DestroyMe() {
	
	}
	void Start() {


	}
	void AddNext() {
		if(life > 0) {
			nbr = Random.Range(1, nbr);
			life--; 
			for(int i=0; i<nbr+life; i++) { // nbr+life
				GameObject cube = GameObject.Instantiate(Resources.Load("branch")) as GameObject;
				children.Add(cube);
				Transform target = transform.Find("target");
				dim = new Vector3(0.1f*ratio, 2*ratio, 0.1f*ratio);
				cube.transform.localScale = dim;
				cube.transform.position = target.transform.position;
				cube.transform.rotation = transform.rotation;
				cube.transform.Rotate(0, Random.Range(-180, 180), 0);
				cube.transform.Rotate(Random.Range(-angleMax, angleMax), 0, 0);
				cube.transform.parent = this.transform.parent;
				//
				Branch br = cube.AddComponent<Branch>() as Branch;
				br.life = life;
				br.ratio = ratio*0.7f*Random.Range(0.9f, 1.1f);
				br.CreateTree();
			}
		} else {
			if(Random.Range(0f, 1f) < 0.5f) {
				cube = GameObject.Instantiate(Resources.Load("FRverso")) as GameObject;
			} else {
				cube = GameObject.Instantiate(Resources.Load("FRlogo")) as GameObject;
			}
			Transform target = transform.Find("target");
			cube.transform.position = target.transform.position;
			cube.transform.rotation = Random.rotationUniform;
			cube.BroadcastMessage("SetParent", target.gameObject);
			//cube.transform.parent = this.transform.parent;
			//cube.renderer.material = materials[Random.Range(0, materials.Length)];


		}
	}
	IEnumerator grow() {
		while(growing<=1) {
			scale.y = startScale.y+endScale.y*growing;
			transform.localScale = scale;
			growing+=0.1f;
			yield return new WaitForSeconds(delay);
		}
		AddNext();
	}
}