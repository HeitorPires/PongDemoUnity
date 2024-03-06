using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public AudioSource audioSource;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //Procura a instancia na cena
                _instance = FindObjectOfType<AudioManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(AudioManager).Name);
                    _instance = singletonObject.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        if (audioSource.isPlaying)
            audioSource.Stop();
        audioSource.Play();
    }

}
