using UnityEngine;
using System.Collections;

public class ImageTargetHandlerPhotoGalleryAuto : MonoBehaviour, ITrackableEventHandler {

	#region PUBLIC_MEMBER_VARIABLES
	public bool isBeingTracked;
	//Each returned object is converted to a Texture and stored in this array
	public Texture[] textures;
	public string folderName = "PhotoArchive"; 
	public GameObject frame;
	public float delay = 0.5f;
	#endregion PUBLIC_MEMBER_VARIABLES
	
	#region PRIVATE_MEMBER_VARIABLES
	private TrackableBehaviour mTrackableBehaviour;
	private Object[] objects;
	int activePhoto = 0;
	#endregion // PRIVATE_MEMBER_VARIABLES
	
	#region PUBLIC_METODS
	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		//Load all textures found on the Sequence folder, that is placed inside the resources folder
		this.objects = Resources.LoadAll(folderName, typeof(Texture));
		
		//Initialize the array of textures with the same size as the objects array
		this.textures = new Texture[objects.Length];
		
		//Cast each Object to Texture and store the result inside the Textures array
		for(int i=0; i < objects.Length;i++)
		{
			this.textures[i] = (Texture)this.objects[i];
		}
		if (IsValid())
		{
			//Set the material's texture to the current value of the frameCounter variable
			frame.renderer.material.mainTexture = textures[activePhoto];
		}
		

	}
	
	
	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}
	
	#endregion // PUBLIC_METHODS
	
	
	
	#region PRIVATE_METHODS
	private void OnTrackingFound()
	{
		isBeingTracked = true;
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}
		
		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}

		StartCoroutine("PlayLoop",delay);




		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
	}
	
	
	private void OnTrackingLost()
	{
		isBeingTracked = false;
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}
		
		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}

		StopCoroutine("PlayLoop");
		
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}

	private bool IsValid()
	{
		//Check texture exist
		return  textures != null && frame!=null;
	}
	
	//The following methods return a IEnumerator so they can be yielded:
	//A method to play the animation in a loop
	IEnumerator PlayLoop(float _delay)
	{
		activePhoto = 0;

		while(true){


			//Debug.Log ("STARTED");
			yield return new WaitForSeconds(_delay);

			
			//Debug.Log ("WAITED");
			if (IsValid())
			{
				
				if(activePhoto<textures.Length-1){
					//Debug.Log ("CHANGED");
					activePhoto++;
				}else{
					activePhoto=0;
				}
				
				
				//Set the material's texture to the current value of the frameCounter variable
				frame.renderer.material.mainTexture = textures[activePhoto];
			}
			
		}
	} 
	
	#endregion // PRIVATE_METHODS
}
