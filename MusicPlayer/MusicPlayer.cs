using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer instance;
    public AudioSource Sound;
    void Awake() {
        instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play(string str) {
        Sound.clip = (AudioClip)Resources.Load("Music/" + str, typeof(AudioClip));//调用Resources方法加载AudioClip资源
        Sound.Play();
    }
}
