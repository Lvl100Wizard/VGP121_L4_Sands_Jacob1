using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public bool loop;
        [Range(0f, 1f)] public float volume = 0.7f;
        [Range(0.5f, 1.5f)] public float pitch = 1f;

        [HideInInspector] public AudioSource source;
    }

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
