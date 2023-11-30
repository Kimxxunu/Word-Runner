using UnityEngine;
using TMPro; // TextMesh Pro 네임스페이스 추가
using UnityEngine.EventSystems; // 이벤트 시스템 네임스페이스 추가

public class TMPInputFieldManager : MonoBehaviour
{
    public TMP_InputField tmpInputField; // 인스펙터에서 설정할 TMP_InputField

    void Start()
    {
        // TMP_InputField의 onEndEdit 이벤트에 메서드 연결
        tmpInputField.onEndEdit.AddListener(OnEndEdit);
    }

    // 엔터 키가 눌렸을 때 호출되는 메서드
    private void OnEndEdit(string text)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // 엔터 키가 눌렸을 때 현재 입력된 텍스트를 디버그 로그로 출력
            Debug.Log("Entered Text: " + tmpInputField.text);
            GameObject word = GameObject.Find(tmpInputField.text);
            Destroy(word);
            Debug.Log("word 삭제");

            GameManager.instance.score++;
            
            // 텍스트 필드 초기화 (필요한 경우)
            tmpInputField.text = "";

            // 입력 필드에 다시 포커스 설정
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(tmpInputField.gameObject);
        }
    }
}
