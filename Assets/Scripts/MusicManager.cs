using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public int audioTrackIndex = 0;
	private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		audioSources = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 3; i++){
			if(i == audioTrackIndex && !audioSources[i].isPlaying){
				audioSources[i].Play();
			
			} else if (i != audioTrackIndex) {
				audioSources[i].Stop();
			}
	}
	}
}
