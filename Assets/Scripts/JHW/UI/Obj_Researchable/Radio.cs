using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Researchable
{ 
    public override void Click_Text_Reset()
    {
        if (OverallManager.Instance.PublicVariable.Day == 1)
        {
            click_Text = 4;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 2)
        {
            click_Text = 8;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 3)
        {
            click_Text = 13;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 4)
        {
            click_Text = 16;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 5)
        {
            click_Text = 21;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 6)
        {
            click_Text = 25;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 7)
        {
            click_Text = 30;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 8)
        {
            click_Text = 36;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 9)
        {
            click_Text = 41;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 10)
        {
            click_Text = 43;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 11)
        {
            click_Text = 47;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 12)
        {
            click_Text = 50;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 13)
        {
            click_Text = 59;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 14)
        {
            click_Text = 64;
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
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "정보를 수집해 볼까?", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "정보를 수집합니다. 3시간 / 스태미나 20 사용", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        if (OverallManager.Instance.PublicVariable.IsDayRadio == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "오늘은 더 들어봤자 같은 내용일 것 같네.", 1);
                            click_Text = 3;
                            break;
                        }
                        if(OverallManager.Instance.PublicVariable.Stamina < 20)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "스태미나가 부족합니다.", 1);
                            click_Text = 3;
                            break;

                        }
                        else if(OverallManager.Instance.PublicVariable.CurrentHour >=22)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "밤이 너무 늦었어.", 1);
                        }
                        else
                        {

                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직.. 지지직..", 1);
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
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "오늘의 소식은...", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직- 지지직..!", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "전파가 잘 안잡히네...", 1);
                    click_Text = 1000;
                    break;
                case 8:
                    click_Text = 3;
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "오늘의 생존 캠프 라디오!", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직..! 먹을 것이 부족하다면,", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "근처의 마트, 편의점 등을 뒤져보자.", 1);
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "착한 생존자들이 먹을 것을 두고갔을 수도 있으니까! ", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..그럴리가.", 1);
                    click_Text = 1000;
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "[맛있는 민트초코맛 껌~ 부드럽고 상큼한 민트초코맛 껌~ ]", 1);
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "[민트초코맛 껌 비둘기 에디션..] 지직.. 지지직..!", 1);
                    break;
                case 16:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "민트초코맛 껌.. 의외로 맛있을지도? ", 1);
                    click_Text = 1000;
                    break;
                case 17:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "오늘의 소식입니다. ", 1);
                    break;
                case 18:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "정부는 좀비 사태를 외곽지에서부터 군대를 동원해 정리해 나가고 있습니다.", 1);
                    break;
                case 19:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "한편 전문가와 시민 단체들은 그 과정에서 발생하는 의도치 않은 민간인 학살을 비판하며..", 1);
                    break;
                case 20:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직.. 지지직..!", 1);
                    break;
                case 21:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..전파가 끊겼다. ", 1);
                    click_Text = 1000;
                    break;
                case 22:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "좀비 바이러스는 뇌를 천천히 잠식해나가는 무서운 바이러스입니다. ", 1);
                    break;
                case 23:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "의학계에서는 이 바이러스를 누군가가 인위적으로 만든게 분명하다는 주장을 펼치고 있지만..,", 1);
                    break;
                case 24:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직.. 지직..!", 1);
                    break;
                case 25:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "이런 고물 라디오같으니!!!", 1);
                    click_Text = 1000;
                    break;
                case 26:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직- 지지직..!", 1);
                    break;
                case 27:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "파인애플 피자에 복숭아와 김치를 얹은 신제품!!", 1);
                    break;
                case 28:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "피치-파인애플 김치 피자!!", 1);
                    break;
                case 29:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지금 바로 주문하세요! ", 1);
                    break;
                case 30:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...맛있겠는데?", 1);
                    click_Text = 1000;
                    break;
                case 31:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직.. 지지직..!!", 1);
                    break;
                case 32:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "정부는 새로운 방침으로, 감염된 시민은 전부 사살할 것을 선포했습니다.", 1);
                    break;
                case 33:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "하지만 이를 둘러싸고 논란이.. 계속.. 지직..!", 1);
                    break;
                case 34:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..좀비는 전부 죽이는게 맞지. 음.", 1);
                    break;
                case 35:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "괴물이나 다름 없는 놈들이니까.", 1);
                    break;
                case 36:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카..", 1);
                    click_Text = 1000;
                    break;
                case 37:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "오늘의 별미 소개 코너 - [귤-된장국]!!", 1);
                    break;
                case 38:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "상큼한 귤과 구수한 된장의 환상적인 만남!", 1);
                    break;
                case 39:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지금 근처 지점에서 만나보세요! ", 1);
                    break;
                case 40:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 41:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "배고프다.", 1);
                    click_Text = 1000;
                    break;
                case 42:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직- 지지직..!!!", 1);
                    break;
                case 43:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "오늘은 전파가 잡히지 않는 것 같다.", 1);
                    click_Text = 1000;
                    break;
                case 44:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "한편 XX시의 연구소를 지원하던 ◆◆회장은 자신과 바이러스는 아무 관련이 없다고 주장했지만..", 1);
                    break;
                case 45:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "지직.. 지지직-!!", 1);
                    break;
                case 46:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "배고프다.", 1);
                    break;
                case 47:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...세상이 이 꼴이니, 음모론만 떠도는 것 같군.", 1);
                    click_Text = 1000;
                    break;
                case 48:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "..정부가 편성한 구조대가 차례차례 시민들을 구조하고 있습니다. ", 1);
                    break;
                case 49:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "그들은 구조되어서 안도한 듯 하지만 한편으로는 가족을 잃은 슬픔에... ", 1);
                    break;
                case 50:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "우리도 조금만 더 버티면.. 희망을 갖자.", 1);
                    click_Text = 1000;
                    break;
                case 51:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "치피치피 차파차파\r\nChipi chipi chapa chapa", 1);
                    break;
                case 52:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "두비두비 다바다바\r\nDubi dubi daba daba", 1);
                    break;
                case 53:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "매지컬 마이 두비두비\r\nMagico mi dubi dubi", 1);
                    break;
                case 54:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "붐, 붐, 붐, 붐\r\nBum, bum, bum, bum", 1);
                    break;
                case 55:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "치피치피 차파차파\r\nChipi chipi chapa chapa", 1);
                    break;
                case 56:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "두비두비 다바다바\r\nDubi dubi daba daba", 1);
                    break;
                case 57:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "매지컬 마이 두비두비\r\nMagico mi dubi dubi", 1);
                    break;
                case 58:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "붐\r\nBum ", 1);
                    break;
                case 59:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..뭐야 이 쓸데없이 유치한 노래는? ", 1);
                    click_Text = 1000;
                    break;
                case 60:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "속보입니다.", 1);
                    break;
                case 61:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "◆◆회장이 자신의 인류 진화 계획을 공식석상에서 발표했습니다. ", 1);
                    break;
                case 62:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "그는 선택받은 자만이 더 빠르고 더 강하고 늙지도 썩지도 죽지도 않는", 1);
                    break;
                case 63:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "진화한 인류가 될 것이라고 선포했지만 현장에 좀비들을 급습하면서 아수라장이 되었습.. 지직-!! ", 1);
                    break;
                case 64:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...내가 지금 뭘 들은거지?", 1);
                    click_Text = 1000;
                    break;
                case 65:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "정부 방침 상 구조대가 완전히 감염되지 않은,", 1);
                    break;
                case 66:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "아직 의식이 남아있는 시민도 사살하는 것으로 알려지면서", 1);
                    break;
                case 67:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "생존자들 사이에서 혼란이 일고 있습니다.", 1);
                    break;
                case 68:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "그리고 ◆◆회장은 사형당하기 직전 사형장에서 한 발언이 논란을.. 지직..!", 1);
                    break;
                case 69:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "◆◆회장", "백신 말이냐? 원한다면 주도록 하지... 찾아라! 내 연구의 모든 것을 거기에 두고 왔으니!", 1);
                    break;
                case 70:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..뭐?", 1);
                    click_Text = 1000;
                    break;
                case 71:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 72:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 73:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 74:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 75:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 76:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 77:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 78:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 79:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 80:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 81:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 82:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 83:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 84:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 85:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 86:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 87:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 88:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 89:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 90:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 91:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 92:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 93:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 94:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                case 95:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "라디오", "...", 1);
                    break;
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 20;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    OverallManager.Instance.PublicVariable.IsDayRadio = true;
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}