using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTop : Researchable
{
    public override void Click_Text_Reset()
    {
        if (OverallManager.Instance.PublicVariable.Day == 1)
        {
            click_Text = 4;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 2)
        {
            click_Text = 9;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 3)
        {
            click_Text = 14;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 4)
        {
            click_Text = 18;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 5)
        {
            click_Text = 23;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 6)
        {
            click_Text = 25;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 7)
        {
            click_Text = 28;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 8)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 9)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 10)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 11)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 12)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 13)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 14)
        {
            click_Text = 3;
        }
    }

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text 값에 따라 다른 동작 수행
            switch (click_Text)
            {
                case 1:
                    if(OverallManager.Instance.PublicVariable.IsPCBrocken == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "이런, 전원이 안 켜져. 워낙 오래된 물건이라..\r\n수리하기 전까지는 작동하지 않을 것 같아. ", 1);
                        click_Text = 3;
                        break;
                    }
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "뭔가 검색해볼까?.", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "정보를 수집합니다. 3시간 / 스태미나 20 사용", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        if (OverallManager.Instance.PublicVariable.IsDayPC == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "오늘은 더 이상 최신 게시물이 안 올라오는 것 같아.", 1);
                            click_Text = 3;
                            break;
                        }
                        if (OverallManager.Instance.PublicVariable.Stamina < 20)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "스태미나가 부족합니다.", 1);
                            click_Text = 3;
                            break;

                        }
                        else if (OverallManager.Instance.PublicVariable.CurrentHour >= 22)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "밤이 너무 늦었어.", 1);
                        }
                        else
                        {

                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[생존자 캠프 커뮤니티에 오신 것을 환영합니다.]", 1);
                            Click_Text_Reset();
                        }
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..다음에 하자.", 1);
                        click_Text = 3;
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[생존자 정보 공유 게시판]", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "항생제를 사용해 바이러스의 감염 속도를 늦출 수 있어.", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "당신의 집이나 집 근처에 항생제를 구할 수 있다면 말이지만.", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "흠.. 항생제.. 항생제를 어디서 구한담.. ", 1);
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "집 근처에 약국이 있었나?.. ", 1);
                    click_Text = 1000;
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[생존자 소식 게시판]", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "영화처럼 어딘가에 백신이 존재하지 않을까?", 1);
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "연구소라던가.", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[댓글]", "ㄴ그런게 있겠냐, 바보야.", 1);
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..백신. 존재하기만 한다면, 레베카도..", 1);
                    click_Text = 1000;
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[생존자 꿀팁 공유 게시판]", 1);
                    break;
                case 16:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "오늘의 꿀팁: 좀비는 밤에 특히 강해지고, 자정이 되면 마하 20의 속도로 뛸 수 있습니다!", 1);
                    break;
                case 17:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "밤늦게 돌아다니지 마시고, 자정 너머에는 문을 꼭 잠구고, 모든 활동을 멈추고 잠이나 자세요!", 1);
                    break;
                case 18:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..마하 20이라니, 뭔 제트기냐고.. ", 1);
                    click_Text = 1000;
                    break;
                case 19:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[생존자 정보 공유 게시판]", 1);
                    break;
                case 20:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "XX시의 수상한 건물 뒷문으로 통하는 길은 잠겨있어.", 1);
                    break;
                case 21:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "그런데 어쩌면 특별한 열쇠로 열 수 있을지도 몰라.", 1);
                    break;
                case 22:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "카드키는...", 1);
                    break;
                case 23:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..왜 글을 쓰다가 만 거야? ", 1);
                    click_Text = 1000;
                    break;
                case 24:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[생존자 소식 게시판]", 1);
                    break;
                case 25:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "어제 올라왔던 게시글말야, 글쓴이 계정이 삭제되어 있더라. ", 1);
                    click_Text = 1000;
                    break;
                case 26:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[작성자]", "그 건물에 뭐라도 숨겨져있는 걸까?", 1);
                    break;
                case 27:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "음.. 그러고 보니 그 건물은 무슨 건물이었더라?", 1);
                    break;
                case 28:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "연구소였던 것 같은데.. ", 1);
                    break ;
                case 29:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "PC", "푸쉬익-!!", 1);
                    break;
                case 30:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "PC", "(다운됨)", 1);
                    break;
                case 31:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "이런, 화면이 나가버렸다! 더 못 쓸 것 같네.", 1);
                    click_Text = 1000;
                    break;
                case 32:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 33:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 34:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 35:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 36:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 37:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 38:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 39:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 40:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 41:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 42:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 43:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 44:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 45:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 46:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 47:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 48:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 49:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 50:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 51:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 52:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 53:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 54:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 55:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 56:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 57:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 58:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 59:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 60:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 61:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 62:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 63:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 64:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 65:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 66:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 67:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 68:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 69:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 70:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 71:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 72:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 73:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 74:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 75:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 76:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 77:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 78:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 79:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 80:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 81:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 82:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 83:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 84:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 85:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 86:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 87:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 88:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 89:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 90:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 91:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 92:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 93:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 94:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 95:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 20;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    OverallManager.Instance.PublicVariable.IsDayPC = true;
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}
