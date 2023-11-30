using UnityEngine;
using TMPro; // TextMesh Pro 네임스페이스 추가
using UnityEngine.EventSystems; // 이벤트 시스템 네임스페이스 추가

public class TMPInputFieldManager : MonoBehaviour
{
    public TMP_InputField tmpInputField; // 인스펙터에서 설정할 TMP_InputField
    private PlayerController _playerController;

    void Start()
    {
        // TMP_InputField의 onEndEdit 이벤트에 메서드 연결
        tmpInputField.onEndEdit.AddListener(OnEndEdit);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // 엔터 키가 눌렸을 때 호출되는 메서드
    private void OnEndEdit(string text)
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))){
            // 엔터 키가 눌렸고, 입력된 텍스트 길이가 1글자보다 클 때 로직 실행
            Debug.Log("Entered Text: " + text);
            if (text.Length > 1)
            {
                GameObject word = GameObject.Find(text);
                if (word != null)
                {
                    Destroy(word);
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