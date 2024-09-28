using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance; // 싱글톤 패턴을 사용하여 단일 인스턴스 유지
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("AudioManager").AddComponent<AudioManager>();
            }
            return instance;
        }
    }

    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // 폭발 사운드 재생 메서드
    public void PlayExplosionSound(AudioClip explosionSound)
    {
        audioSource.PlayOneShot(explosionSound);
    }
}
