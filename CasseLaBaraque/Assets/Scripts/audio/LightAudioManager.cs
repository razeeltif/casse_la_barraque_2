using UnityEngine.Audio;
using UnityEngine;
using System;

public class LightAudioManager : AudioManager {

    public String name;

	// Use this for initialization
	void Awake () {

		fillSounds();

	}

}
