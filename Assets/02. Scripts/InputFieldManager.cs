using UnityEngine;
using TMPro; // TextMesh Pro 네임스페이스 추가
using UnityEngine.EventSystems; // 이벤트 시스템 네임스페이스 추가

public class TMPInputFieldManager : MonoBehaviour
{
    public TMP_InputField tmpInputField; // 인스펙터에서 설정할 TMP_InputField
    private PlayerController _playerController;
    private Animator _animator;

    public Transform firePosition;
    public GameObject firePrefab;

    public AudioSource audioSource;
    public AudioClip laserSound; // Inspector에서 레이저 사운드 클립을 연결
    public AudioClip kickSound;


    void Start()
    {
        // TMP_InputField의 onEndEdit 이벤트에 메서드 연결
        tmpInputField.onEndEdit.AddListener(OnEndEdit);

        GameObject player = GameObject.Find("Player");
        _playerController = player.GetComponent<PlayerController>();
        _animator = player.GetComponent<Animator>();

        // 오디오 소스 설정
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = laserSound;
    }

    // 엔터 키가 눌렸을 때 호출되는 메서드
    private void OnEndEdit(string text)
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))){
            // 엔터 키가 눌렸고, 입력된 텍스트 길이가 1글자보다 클 때 로직 실행
            if (text.Length > 1)
            {
                GameObject word = GameObject.Find(text);
                float distance;
                if (word != null)
                {
                    distance = Vector3.Distance(GameObject.Find("Player").transform.position, word.transform.position);
                    if (distance <= 20)
                    {
                        int random = Random.Range(0, 2);
                        string kick = random == 0 ? "Kick1" : "Kick2";
                        _animator.SetTrigger(kick);
                        audioSource.PlayOneShot(kickSound);
                        Destroy(word, 0.3f);
                    }
                    else
                    {
                        _animator.SetTrigger("Laser");
                        // 오디오 재생
                        audioSource.Play();
                        GameObject prefab = Instantiate(firePrefab, firePosition.transform.position, Quaternion.identity);
                        prefab.GetComponent<FireMovement>().target = word;
                        prefab.transform.parent = firePosition;
                        prefab.transform.LookAt(word.transform.position);
                    }
                    Debug.Log("word 삭제");
                    GameManager.instance.score++;
                    _playerController.reduceShootInterval();
                }
            }

            // 텍스트 필드 초기화 (필요한 경우)
            tmpInputField.text = "";

            // 입력 필드에 다시 포커스 설정
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(tmpInputField.gameObject);
        }
    }


}