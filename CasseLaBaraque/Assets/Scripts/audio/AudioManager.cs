﻿using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public abstract class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	protected void fillSounds(){
		foreach(Sound s in sounds){
			s.audioSource = gameObject.AddComponent<AudioSource>();

			//setting the audioSource with the information found in sound s
			s.audioSource.clip = s.clip;
			s.audioSource.volume = s.volume;
			s.audioSource.pitch = s.pitch;
			s.audioSource.loop = s.loop;
			s.audioSource.spatialBlend = s.spatialBlend;
		}
	}
	
	//playing the sound with the given name
	public void Play (string name){
		Sound s = findSound(name);
		if(s != null){
			s.audioSource.Play();
			Debug.Log("name : " + name + " found");
		}
	}

	public void Stop (string name){
		Sound s = findSound(name);
		if(s != null)
			s.audioSource.Stop();
	}

	public AudioSource GetAudioSource(string name){
		Sound s = findSound(name);
		if(s != null)
			return s.audioSource;
		else
			return null;
	}

	//name : name of the sound 
	//fadeDuration : the time the fade will take to reach the sound volume (begin to 0)
	//maxVolume : 
	public void FadeEnter(string name, float fadeDuration){
		if(fadeDuration < 0){
			Debug.LogError("fade duration must be higher than 0");
			return;
		}
		Sound s = findSound(name);
		if(s != null)
			StartCoroutine(FadeEnterCoroutine(s, fadeDuration));
	}

	//warning : the target sound must be played when this function is called.
	public void FadeExit(string name, float fadeDuration){
		if(fadeDuration < 0){
			Debug.LogError("fade duration must be higher than 0");
			return;
		}
		Sound s = findSound(name);
		if(s!=null && s.audioSource.isPlaying){
			StopCoroutine("FadeEnterCoroutine");
			StartCoroutine(FadeExitCoroutine(s, fadeDuration));
		}else{
			Debug.LogWarning("try to apply a fade on exit on a sound not played : " + name);
		}
	}


	private Sound findSound(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogError("the sound " + name + " not exist");
			return null;
		}else{
			return s;
		}
	}

	private IEnumerator FadeEnterCoroutine(Sound sound, float fadeDuration){

		float maxVolume = sound.audioSource.volume;
		float step = (maxVolume/fadeDuration) / (1/Time.deltaTime);

		sound.audioSource.volume = 0;

		sound.audioSource.Play();

		for(float i = 0; i <= maxVolume; i+=step){
			sound.audioSource.volume=i;
			yield return new WaitForSecondsRealtime(step);
		}

	}

	private IEnumerator FadeExitCoroutine(Sound sound, float fadeDuration){

		float step = (sound.audioSource.volume/fadeDuration) / (1/Time.deltaTime);

		for(float i = sound.audioSource.volume; i > 0; i-=step){
			sound.audioSource.volume=i;
			yield return new WaitForSecondsRealtime(step);
		}
		
		sound.audioSource.Stop();

	}



}
