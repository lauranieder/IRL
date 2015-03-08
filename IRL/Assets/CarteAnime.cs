using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarteAnime : MonoBehaviour {
	//public GameObject carteBase;
	int nbr = 15;
	List<GameObject> pages;
	GameObject current;
	GameObject attachTo;
	public GameObject low;
	public GameObject up;
	// Use this for initialization
	void Start () {
		pages = new List<GameObject>();
		StartCoroutine(launch());
	}
	IEnumerator launch() {
		while(true) {
			// A
			for(int i=0; i<nbr; i++) {
				createOne("bcF", false);
				yield return new WaitForSeconds(0.1f);
			}
			createOne("bcA", true);
			yield return new WaitForSeconds(5f);
			// B
			for(int i=0; i<nbr; i++) {
				createOne("bcF", false);
				yield return new WaitForSeconds(0.1f);
			}
			createOne("bcB", true);
			yield return new WaitForSeconds(5f);
			// C
			for(int i=0; i<nbr; i++) {
				createOne("bcF", false);
				yield return new WaitForSeconds(0.1f);
			}
			createOne("bcC", true);
			yield return new WaitForSeconds(5f);
			// D
			for(int i=0; i<nbr; i++) {
				createOne("bcF", false);
				yield return new WaitForSeconds(0.1f);
			}
			createOne("bcD", true);
			yield return new WaitForSeconds(5f);
			// E
			for(int i=0; i<nbr; i++) {
				createOne("bcF", false);
				yield return new WaitForSeconds(0.1f);
			}
			createOne("bcE", true);
			yield return new WaitForSeconds(5f);
		}
	}
	void createOne(string n, bool add) {
		if(add) {
			attachTo = up;
		} else {
			attachTo = low;
		}
		current = GameObject.Instantiate(Resources.Load("bcard/"+n), attachTo.transform.position, this.transform.rotation) as GameObject;
		current.transform.parent = attachTo.transform;
		current.transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);
		current.transform.Translate(0, 100, 0);
		current.animation.Play();
		//
		if(pages.Count > 3) {
			Debug.Log(pages.Count);
			GameObject toDestroy = pages[0].gameObject;
			Destroy(toDestroy);
		}
		pages.Add(current);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
