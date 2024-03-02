using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PrologueController : MonoBehaviour
{
    [SerializeField]
    private Text Prologue_Text;

    private int click_Text = 0;

    private void Start()
    {
        OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Cutscene;
        Prologue_Text.DOText("...", 1).SetUpdate(true);
    }

    void Update()
    {
        // 클릭이나 Z키 입력 시 click_Text 증가
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
        {
            click_Text++;
            HandleClickTextChange();
        }
    }

    void HandleClickTextChange()
    {
        // click_Text 값에 따라 다른 동작 수행
        switch (click_Text)
        {
            case 1:
                Prologue_Text.text = null;
                Prologue_Text.DOText(".....", 1).SetUpdate(true);
                break;
            case 2:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "좀비 아포칼립스가 시작된 지 17일..", 3);
                break;
            case 3:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "슬슬 식량이 다 떨어져 간다. " +
                    "이대로는 언제까지 버틸 수 있을지...", 3);
                break;
            case 4:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Prologue_Text.DOText("지직..! " + "지지직..", 3).SetUpdate(true);
                break;
            case 5:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "음..?", 1);
                break;
            case 6:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Prologue_Text.DOText("XX 생존자 캠프에서 안내 드립니다..", 3).SetUpdate(true);
                
                break;
            case 7:
                Prologue_Text.text = null;
                Prologue_Text.DOText("15일 뒤에 □□시에 구조대가 파견될 예정입니다.", 3).SetUpdate(true);
                
                break;
            case 8:
                Prologue_Text.text = null;
                Prologue_Text.DOText("그러므로 □□시의 생존자 여러분은 15일 뒤...", 3).SetUpdate(true);
                
                break;
            case 9:
                Prologue_Text.text = null;
                Prologue_Text.DOText("지직.. 지지직..!", 3).SetUpdate(true);
               
                break;
            case 10:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "달칵. ...", 2);

                break;
            case 11:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "오 우리 딸, 돌아 왔구나! 들었니? 곧 구조대가 온다고..!", 3);
                break;
            case 12:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아..빠..", 2);
                break;
            case 13:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Prologue_Text.DOText("쿵..    " +
                    "털썩!", 1).SetUpdate(true); ;
                break;
            case 14:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카..? 너 그 이빨 자국은..", 3);
                break;
            case 15:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카,  정신 차려!!" +
                    "  레베카, 레베카!!", 1);
                break;
            case 16:
                Prologue_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Playing;
                OverallManager.Instance.PublicVariable.Am_I_outside = false;
                OverallManager.Instance.PublicVariable.CurrentHour = 8;
                OverallManager.Instance.PublicVariable.Day = 1;
                OverallManager.Instance.UiManager.DayChangeTextOn(true);
                OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
                break;
            /*
            case 17:
                Prologue_Text.DOText("", 3);
                break;
            case 18:
                Prologue_Text.DOText("", 3);
                break;
            case 19:
                Prologue_Text.DOText("", 3);
                break;
            case 20:
                Prologue_Text.DOText("", 3);
                break;
            case 21:
                Prologue_Text.DOText("", 3);
                break;
            case 22:
                Prologue_Text.DOText("", 3);
                break;
            case 23:
                Prologue_Text.DOText("", 3);
                break;
            case 24:
                Prologue_Text.DOText("", 3);
                break;
            case 25:
                Prologue_Text.DOText("", 3);
                break;
            case 26:
                Prologue_Text.DOText("", 3);
                break;
            case 27:
                Prologue_Text.DOText("", 3);
                break;
            case 28:
                Prologue_Text.DOText("", 3);
                break;
            case 29:
                Prologue_Text.DOText("", 3);
                break;
            case 30:
                Prologue_Text.DOText("", 3);
                break;
            */
            // 추가적인 경우에 대한 처리도 이어서 작성
            default:
                // 기본적으로는 아무 동작도 하지 않음
                break;
        }
    }
}
