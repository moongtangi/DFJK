using UnityEngine;
using UnityEngine.UI;

public class ObjectClickHandler : MonoBehaviour
{
    public Text levelText;         // 레벨 텍스트
    public Text bpmText;           // BPM 텍스트
    public Text noteCountText;     // 노트 수 텍스트
    public Text longNoteCountText; // 롱노트 수 텍스트
    public Image infoImage;        // 오브젝트 이미지
    public GameObject infoPanel;   // 정보창 패널

    void Start()
    {
        // 시작 시 정보창을 숨김
        infoPanel.SetActive(true);
    }

   void Update()
{
    if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭 감지
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // 클릭된 오브젝트 감지
        {
            GameObject clickedObject = hit.collider.gameObject;

            // 클릭된 오브젝트 이름 출력
            Debug.Log("Clicked on object: " + clickedObject.name);

            // 오브젝트 정보 UI에 표시
            DisplayObjectInfo(clickedObject);
        }
    }
}

    void DisplayObjectInfo(GameObject obj)
    {

        // 오브젝트의 MyObjectInfo 컴포넌트에서 정보를 얻음
        MyObjectInfo objectInfo = obj.GetComponent<MyObjectInfo>();

        if (objectInfo != null)
        {
            // 레벨, BPM, 노트 수, 롱노트 수 정보 갱신
            levelText.text = "Level: " + objectInfo.level;
            bpmText.text = "BPM: " + objectInfo.bpm;
            noteCountText.text = "Note Count: " + objectInfo.noteCount;
            longNoteCountText.text = "Long Note Count: " + objectInfo.longNoteCount;

            // 이미지 설정
            infoImage.sprite = objectInfo.objectImage;
        }
        else
        {
            // 오브젝트 정보가 없을 경우 기본값 설정
            levelText.text = "Level: ???";
            bpmText.text = "BPM: ???";
            noteCountText.text = "Note Count: ???";
            longNoteCountText.text = "Long Note Count: ???";
            infoImage.sprite = null;
        }
    }
}
