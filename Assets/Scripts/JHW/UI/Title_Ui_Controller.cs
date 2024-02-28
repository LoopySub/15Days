using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Ui_Controller : BaseMonoBehaviour
{
    public Image select_1;
    public Image select_2;
    public Image select_3;

    //이벤트와 델리게이트 선언
    public delegate void IsTargetedChanged();
    public static event IsTargetedChanged OnIsTargetedChanged;

    private int isTargeted;
    public int _isTargeted
    {
        get { return isTargeted; }
        set
        {
            if (isTargeted != value)
            {
                isTargeted = value;
                OnIsTargetedChanged?.Invoke(); // isTargeted가 변경되면 인보크
            }
        }
    }

    void Start()
    {
        // 이벤트 구독
        OnIsTargetedChanged += HandleIsTargetedChanged;
        _isTargeted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 움직임 탐색
        if (IsMouseOver(select_1)) _isTargeted = 0;
        else if (IsMouseOver(select_2)) _isTargeted = 1;
        else if (IsMouseOver(select_3)) _isTargeted = 2;

        //엔터키나 왼쪽클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            //마우스가 이미지 위에 있을 경우
            if (IsMouseOverAnyImage())
            {
                HandleSelection();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            HandleSelection();
        }

        //키보드 방향키 입력 감지
        HandleKeyboardInput();



    }

    //마우스가 어떤 이미지 위에 올라가 있는지 탐색
    bool IsMouseOverAnyImage()
    {
        return IsMouseOver(select_1) || IsMouseOver(select_2) || IsMouseOver(select_3);
    }



    // 타겟 변경시 이미지 투명도 변경
    void HandleIsTargetedChanged()
    {
        // Change image transparency based on isTargeted value
        switch (isTargeted)
        {
            case 0:
                SetImageTransparency(select_1, 30);
                SetImageTransparency(select_2, 0);
                SetImageTransparency(select_3, 0);
                break;
            case 1:
                SetImageTransparency(select_2, 30);
                SetImageTransparency(select_1, 0);
                SetImageTransparency(select_3, 0);
                break;
            case 2:
                SetImageTransparency(select_3, 30);
                SetImageTransparency(select_1, 0);
                SetImageTransparency(select_2, 0);
                break;
        }
    }

    //이미지 투명도를 직접 변경하는 메서드
    void SetImageTransparency(Image image, byte alpha)
    {
        Color color = image.color;
        color.a = alpha / 255f;
        image.color = color;
    }

    // 마우스가 이미지 위에 올라가 있는지 감지한다
    bool IsMouseOver(Image image)
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(localMousePosition);
    }

    //키보드 방향키 입력시 선택 이미지 변경
    void HandleKeyboardInput()
    {
        // Handle arrow key input
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            _isTargeted = (isTargeted + 1) % 3;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            _isTargeted = (isTargeted + 2) % 3;
    }

    // 이미지 선택하고 좌클릭이나 엔터 시 호출되는 메서드. 1=게임 시작 2=도움말(미구현) 3=게임종료
    void HandleSelection()
    {
        switch (isTargeted)
        {
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadScene("");
                break;
            case 2:
                // Quit the game
                Application.Quit();
                break;
            // case 1: // isTargeted = 1은 미구현
            default:
                break;
        }
    }
}