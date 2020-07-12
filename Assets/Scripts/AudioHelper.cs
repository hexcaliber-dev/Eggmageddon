using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Facilitates all sound effects and music. Only one is allowed per scene.
public class AudioHelper : MonoBehaviour {

    public static Dictionary<string, AudioClip> staticClips;
    public List<AudioClip> audioClips;
    public static float masterVolume = 1f;

    private static AudioSource[] audioSources;

    public static void PlaySound (string soundName, bool isLoop, float volume) {
        if (audioSources == null) return;
        foreach (AudioSource src in audioSources) {
            if (src == null) return;
            if (!src.isPlaying) {
                src.loop = isLoop;
                src.volume = volume * masterVolume;
                src.clip = staticClips[soundName];
                if (!isLoop)
                    src.PlayOneShot(src.clip, src.volume);
                else
                    src.Play ();
                return;
            }
        }
    }

    public static void PlaySound (string soundName) {
        PlaySound(soundName, false, 1f);
    }
    public static void PlaySound (string soundName, float volume) {
        PlaySound(soundName, false, volume);
    }

    public static void Stop () {
        foreach (AudioSource src in audioSources) {
            src.Stop ();
            src.loop = false;
        }
    }

    // Start is called before the first frame update
    void Start () {
        audioSources = GetComponentsInChildren<AudioSource> ();
        staticClips = new Dictionary<string, AudioClip> ();
        foreach (AudioClip clip in audioClips) {
            staticClips.Add (clip.name, clip);
        }

    }

    IEnumerator StopPlaying(AudioSource source) {
        if (source.clip != null) {
            yield return new WaitForSeconds(source.clip.length);
            source.Stop();
        }
    }
}