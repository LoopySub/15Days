using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingController : MonoBehaviour
{
    [SerializeField]
    private Text Ending_Text;

    [SerializeField]
    private int click_Text = 0;

    bool End;

    private void Start()
    {
        OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Cutscene;
        Ending_Text.DOText("...", 1).SetUpdate(true);

        if(OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.OverNight)
            click_Text = 0;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.GameOver)
            click_Text = 8;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.Infection)
            click_Text = 16;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.Starvation)
            click_Text = 50;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.Normal)
            click_Text = 26;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.True)
            click_Text = 57;

    }

    void Update()
    {
        // 클릭이나 Z키 입력 시 click_Text 증가
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
        {
            if (End == false)
            {
                click_Text++;
                HandleClickTextChange();
            }
        }
    }

    void HandleClickTextChange()
    {
        // click_Text 값에 따라 다른 동작 수행
        switch (click_Text)
        {
            case 1:
                Ending_Text.text = null;
                Ending_Text.DOText("좀비 바이러스의 특징은..", 1).SetUpdate(true);
                break;
            case 2:
                Ending_Text.text = null;
                Ending_Text.DOText("자정을 기점으로 폭발적으로 활성화 된다는 것이다.", 1).SetUpdate(true);
                break;
            case 3:
                Ending_Text.text = null;
                Ending_Text.DOText("무장한 군인도 이겨낼 수 없을 정도로 빠르고, 사납고, 단단해진다.", 1).SetUpdate(true);
                break;
            case 4:
                Ending_Text.text = null;
                Ending_Text.DOText("뿐만 아니라, 곳곳에 방치되어 있는 무수한 시체들도 움직이기 시작한다.", 1).SetUpdate(true);
                break;
            case 5:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "크아아아아악-!!", 3);
                break;
            case 6:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("그리고 한낱 민간인인 존이 그 가장 위험한 시간에 싸돌아 다닌 결과는 당연했다.", 3).SetUpdate(true);
                break;
            case 7:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레.. 베카....", 1);
                break;
            case 8:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("ENDING 1: OVER NIGHT", 3).SetUpdate(true);
                End = true;
                break;
            case 9:
                Ending_Text.text = null;
                Ending_Text.DOText("존은 좀비들에게 둘러쌓여 죽어가고 있다.", 3).SetUpdate(true);
                break;
            case 10:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "좀비들", "그르르르르.. 아그작, 콰직, 그오오..!", 1);
                break;
            case 11:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "....", 3);
                break;
            case 12:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("살을 씹고 피를 마시는 소리만 들릴 뿐,", 3).SetUpdate(true);
                break;
            case 13:
                Ending_Text.text = null;
                Ending_Text.DOText("기적은 일어나지 않는다.", 3).SetUpdate(true);
                break;
            case 14:
                Ending_Text.text = null;
                Ending_Text.DOText("딸아이를 구하고 싶었던 아버지의 삶은, 그렇게 거기서 끝이 났다.", 3).SetUpdate(true);
                break;
            case 15:
                Ending_Text.text = null;
                Ending_Text.DOText("ENDING 2: GAME OVER", 3).SetUpdate(true);
                break;
            case 16:
                End = true;
                Application.Quit();
                break;
            case 17:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "그르르르...", 2);
                break;
            case 18:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카..?", 1);
                break;
            case 19:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "캬아아아악-!!", 2);
                break;
            case 20:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("너무 늦어버린 탓일까, 아니면 잘 돌보지 않았기 때문일까.", 3);
                break;
            case 21:
                Ending_Text.text = null;
                Ending_Text.DOText("그곳에 있는 건 더 이상 존의 딸 레베카가 아니었다.", 3);
                break;
            case 22:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 멈춰! 안돼!", 1);
                break;
            case 23:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "끄아아아아악-!", 1);
                break;
            case 24:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("구조대가 도착했을 때, 그 집에 있는 건 반쯤 썩은 남자의 시신을 뜯어먹고 있는 소녀 좀비 한 마리 뿐이었다.", 3);
                break;
            case 25:
                Ending_Text.text = null;
                Ending_Text.DOText("ENDING 3: INFECTION", 3).SetUpdate(true);
                break;
            case 26:
                End = true;
                Application.Quit();
                break;
            case 27:
                Ending_Text.text = null;
                Ending_Text.DOText("Day-15", 1);
                break;
            case 28:
                Ending_Text.text = null;
                Ending_Text.DOText("똑똑,", 1);
                break;
            case 29:
                Ending_Text.text = null;
                Ending_Text.DOText("군인들이 존의 집 현관문을 두드린다.", 1);
                break;
            case 30:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인들", "거기 생존자 계십니까?", 1);
                break;
            case 31:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 들었니? 구조대가 왔어!", 1);
                break;
            case 32:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "지금 나갑니다!", 1);
                break;
            case 33:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("달칵,", 3);
                break;
            case 34:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "무사한 생존자가 있었군요. 다행입니다.", 1);
                break;
            case 35:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아..빠.. 콜록콜록, 무슨 일이야..?", 1);
                break;
            case 36:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "음..?", 1);
                break;
            case 37:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "아, 이 아이는 제 딸입니다.. 괜찮아요!", 1);
                break;
            case 38:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "철컥,", 1);
                break;
            case 39:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("탕 -      !!!,", 3);
                break;
            case 40:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아.. 끄륵.. ...", 1);
                break;
            case 41:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("털썩.", 3);
                break;
            case 42:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 레베카아아아!!!! 당신들, 무슨 짓을..!!", 1);
                break;
            case 43:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "정부 방침 상, 감염자는 전부 발견 즉시 사살입니다.", 1);
                break;
            case 44:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아.. 빠....", 1);
                break;
            case 45:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 안돼, 정신 차려, 이럴 수는.. 안돼, 안돼!!!", 1);
                break;
            case 46:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "어쩔 수 없습니다. 당신은 감염되지 않으신 것 같은데, 저희와 함께 가시죠.", 1);
                break;
            case 47:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 레베카.. 안돼.. 아아.. 아아아아아아아아아-!!!", 1);
                break;
            case 48:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("차갑게 식은 시신과, 딸을 잃은 아버지의 절규만이 그 자리에 남아 있었다.", 3);
                break;
            case 49:
                Ending_Text.text = null;

                Ending_Text.DOText("ENDING 5: TRAGEDY", 3).SetUpdate(true);
                break;
            case 50:
                End = true;
                Application.Quit();
                break;
            case 51:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "배고파서.. 손 하나 까딱할 힘도 없다..", 1);
                break;
            case 52:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "미리미리 식량을 비축해뒀어야 했는데...", 1);
                break;
            case 53:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "... ...", 1);
                break;
            case 54:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                break;
            case 55:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("좀비 아포칼립스 세계에서, 아사는 흔한 사인이다.", 3);
                break;
            case 56:
                Ending_Text.text = null;
                Ending_Text.DOText("ENDING 4: STARVATION", 3).SetUpdate(true);
                break;
            case 57:
                End = true;
                Application.Quit();
                break;
            case 58:
                Ending_Text.DOText("Day-15", 3);
                break;
            case 59:
                Ending_Text.text = null;
                Ending_Text.DOText("똑똑,", 1);
                break;
            case 60:
                Ending_Text.text = null;
                Ending_Text.DOText("군인들이 존의 집 현관문을 두드린다.", 3);
                break;
            case 61:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인들", "거기 생존자 계십니까?", 1);
                break;
            case 62:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 들었니? 구조대가 왔어!", 1);
                break;
            case 63:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "지금 나갑니다!", 1);
                break;
            case 64:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "무사한 생존자가 있었군요. 다행입니다.", 1);
                break;
            case 65:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "드디어..!", 1);
                break;
            case 66:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "두 분, 맞으십니까? 음.. 두 분 다 건강에 문제는 없는 것 같군요.", 1);
                break;
            case 67:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "군인", "그럼 저희와 함께 가시죠. 생존자 캠프는 여러분을 환영합니다.", 1);
                break;
            case 68:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("존과 완치된 레베카는 구조대의 보호를 받아 무사히 생존자 캠프에 합류할 수 있었다.", 1);
                break;
            case 69:
                Ending_Text.DOText("아직 미래는 불안하지만, 그래도 그들의 앞날에는 행복이 기다리고 있을 것이다.", 1);
                break;
            case 70:
                Ending_Text.text = null;
                Ending_Text.color = Color.yellow;
                Ending_Text.DOText("ENDING 6: HAPPY END", 3).SetUpdate(true);
                break;
            case 71:
                End = true;
                Application.Quit();
                break;
            case 72:
                Ending_Text.DOText("Text for case 72", 3);
                break;
            case 73:
                Ending_Text.DOText("Text for case 73", 3);
                break;
            case 74:
                Ending_Text.DOText("Text for case 74", 3);
                break;
            case 75:
                Ending_Text.DOText("Text for case 75", 3);
                break;
            case 76:
                Ending_Text.DOText("Text for case 76", 3);
                break;
            case 77:
                Ending_Text.DOText("Text for case 77", 3);
                break;
            case 78:
                Ending_Text.DOText("Text for case 78", 3);
                break;
            case 79:
                Ending_Text.DOText("Text for case 79", 3);
                break;
            case 80:
                Ending_Text.DOText("Text for case 80", 3);
                break;
            default:
                // 기본 처리
                break;
        }
    }
}

