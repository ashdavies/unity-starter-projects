using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour {
	public Material lightUpMaterial;
	public GameLogic gameLogic;

	private Material defaultMaterial;
	private ParticleSystem.EmissionModule emission;

	// Use this for initialization
	void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material; //Save our initial material as the default
		//emission = GetComponentInChildren<ParticleSystem>().emission;
		//emission.enabled = false; //Start without emitting particles
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void patternLightUp(float duration) { //The lightup behavior when displaying the pattern
		StartCoroutine(lightFor(duration));
	}

	public void gazeLightUp() {
		GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		//emission.enabled = true; //Turn on particle emmission

		//GetComponent<GvrAudioSource>().Play();
		//gameLogic.playerSelection(this.gameObject);
	}

	public void playerSelection() {
		gameLogic.playerSelection(gameObject);
		GetComponent<GvrAudioSource>().Play();
	}

	public void aestheticReset() {
		GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
		//emission.enabled = false; //Turn off particle emission
	}

	public void patternLightUp() { //Lightup behavior when the pattern shows.
		GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		//emission.enabled = true; //Turn on particle emmission
		GetComponent<GvrAudioSource> ().Play (); //Play the audio attached
	}
		
	IEnumerator lightFor(float duration) { //Light us up for a duration.  Used during the pattern display
		patternLightUp ();
		yield return new WaitForSeconds(duration-.1f);
		aestheticReset ();
	}
}
