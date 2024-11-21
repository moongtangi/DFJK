using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanjungChang : MonoBehaviour
{
    public Image rankImage;
    public Sprite PerfectSprite; // Perfect
    public Sprite GreatSprite; // Great
    public Sprite BadSprite; // Bad
    public Sprite MissSprite; // Miss
    public double accuracy = 0;
    public int perNum = 0;
    public int greNum = 0;
    public int badNum = 0;
    public int misNum = 0;
    public int combo = 0;
    public int noteNum = 0;

    private Coroutine currentCoroutine;

    private void Start()
    {
        accuracy = 0;
        perNum = 0;
        greNum = 0;
        badNum = 0;
        misNum = 0;
        combo = 0;
        noteNum = 0;
        rankImage.enabled = false;

        animatorSun0 = sun0.GetComponent<Animator>();
        animatorSun1 = sun1.GetComponent<Animator>();
        animatorSun2 = sun2.GetComponent<Animator>();
        animatorSun3 = sun3.GetComponent<Animator>();
        HideAllEffects();
    }

    public void Perfect(GameObject wyvernp)
    {
        Debug.Log($"PERFΞCT where {wyvernp.GetComponent<Notes>().panjung}, {wyvernp.GetComponent<Notes>().line}");
        perNum++;combo++;noteNum++;
        GoodAccuracy();
        ShowRank(PerfectSprite);
        switch (wyvernp.GetComponent<Notes>().line){
            case 0:
                PlayEffect(animatorSun0);break;
            case 1:
                PlayEffect(animatorSun1);break;
            case 2:
                PlayEffect(animatorSun2);break;
            case 3:
                PlayEffect(animatorSun3);break;}
        StartCoroutine(DisableAfterAnimation(wyvernp.GetComponent<Notes>().line));
    }
    public void Great(GameObject wyvernp)
    {
        Debug.Log($"GRΣAT where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        greNum++;combo++;noteNum++;
        GoodAccuracy();
        ShowRank(GreatSprite);
        switch (wyvernp.GetComponent<Notes>().line){
            case 0:
                PlayEffect(animatorSun0);break;
            case 1:
                PlayEffect(animatorSun1);break;
            case 2:
                PlayEffect(animatorSun2);break;
            case 3:
                PlayEffect(animatorSun3);break;}
        StartCoroutine(DisableAfterAnimation(wyvernp.GetComponent<Notes>().line));
    }
    public void Bad(GameObject wyvernp)
    {
        Debug.Log($"B∀D where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        badNum++;combo++;noteNum++;
        GoodAccuracy();
        ShowRank(BadSprite);
        switch (wyvernp.GetComponent<Notes>().line){
            case 0:
                PlayEffect(animatorSun0);break;
            case 1:
                PlayEffect(animatorSun1);break;
            case 2:
                PlayEffect(animatorSun2);break;
            case 3:
                PlayEffect(animatorSun3);break;}
        StartCoroutine(DisableAfterAnimation(wyvernp.GetComponent<Notes>().line));
    }
    public void Miss(GameObject wyvernp)
    {
        Debug.Log($"ΛΛISS where {wyvernp.GetComponent<Notes>().panjung}, line {wyvernp.GetComponent<Notes>().line}");
        misNum++;combo = 0;noteNum++;
        GoodAccuracy();
        ShowRank(MissSprite);
    }

    private void ShowRank(Sprite rankSprite)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        rankImage.sprite = rankSprite;
        rankImage.enabled = true;

        currentCoroutine = StartCoroutine(HideRankAfterDelay(2f));
    }
    private IEnumerator HideRankAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rankImage.enabled = false;
        currentCoroutine = null;
    }
    void GoodAccuracy()
    {
        accuracy = 100*(perNum + greNum * 0.75f + badNum * 0.05f)/noteNum;
        ComboChange(combo);
        Debug.Log($"저ㅏㅇ확{accuracy} 콤보{combo}");
    }
//>>>>>>>>>>>>>>>>>>>>>>>>>>
    public GameObject sun0;
    public GameObject sun1;
    public GameObject sun2;
    public GameObject sun3;
    private Animator animatorSun0;
    private Animator animatorSun1;
    private Animator animatorSun2;
    private Animator animatorSun3;

    private void HideAllEffects()
    {
        animatorSun0.gameObject.SetActive(false);
        animatorSun1.gameObject.SetActive(false);
        animatorSun2.gameObject.SetActive(false);
        animatorSun3.gameObject.SetActive(false);
    }

    private void PlayEffect(Animator animator)
    {
        animator.gameObject.SetActive(true);
        animator.SetTrigger("yoshitaka");
    }

    private System.Collections.IEnumerator DisableAfterAnimation(int line)
    {
        yield return new WaitForSeconds(1f); // 애니메이션의 길이로 조정
        switch (line)
        {
            case 0:
                animatorSun0.gameObject.SetActive(false);
                break;
            case 1:
                animatorSun1.gameObject.SetActive(false);
                break;
            case 2:
                animatorSun2.gameObject.SetActive(false);
                break;
            case 3:
                animatorSun3.gameObject.SetActive(false);
                break;
        }
    }
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public Sprite[] digitSprites; // 0~9 스프라이트 배열
    public GameObject digitPrefab; // 숫자 표시용 프리팹
    public RectTransform container; // 숫자들을 배치할 부모 컨테이너

    private GameObject[] digitObjects; // 현재 화면에 표시된 숫자 오브젝트 배열

    public void ComboChange(int combo)
    {
        // 기존에 표시된 숫자 오브젝트 제거
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        if (combo == 0){return;}

        // combo 값을 문자열로 변환 (숫자 한 자리씩 처리하기 위해)
        string comboStr = combo.ToString();
        int length = comboStr.Length;

        digitObjects = new GameObject[length];

        // 중앙 정렬을 위한 시작 X 좌표 계산
        float digitWidth = digitPrefab.GetComponent<RectTransform>().sizeDelta.x; // 프리팹의 가로 크기
        float totalWidth = length * digitWidth; // 전체 숫자의 가로 길이
        float startX = -totalWidth / 2; // 중앙에서 왼쪽으로 얼마나 이동할지 계산

        // 숫자 생성 및 배치
        for (int i = 0; i < length; i++)
        {
            // 숫자 오브젝트 생성
            digitObjects[i] = Instantiate(digitPrefab, container);

            // 숫자 스프라이트 설정
            int digit = int.Parse(comboStr[i].ToString()); // 문자열에서 숫자 추출
            digitObjects[i].GetComponent<Image>().sprite = digitSprites[digit];

            // 위치 설정
            RectTransform rectTransform = digitObjects[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(startX + (i+0.5f) * digitWidth - 0.14f, 0); // X 좌표를 순차적으로 설정
        }
    }
}
