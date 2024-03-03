using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morning_Monologue : Researchable
{
    public override void Click_Text_Reset()
    {
        if(OverallManager.Instance.PublicVariable.Day == 1)
        {

        }
        else if (OverallManager.Instance.PublicVariable.Day == 2)
        {
            click_Text = 2;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 3)
        {
            click_Text = 5; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 4)
        {
            click_Text = 8 ; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 5)
        {
            click_Text = 11 ; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 6)
        {
            click_Text = 15; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 7)
        {
            click_Text = 18; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 8)
        {
            click_Text = 22; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 9)
        {
            click_Text = 24; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 10)
        {
            click_Text = 27; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 11)
        {
            click_Text = 29; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 12)
        {
            click_Text = 31; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 13)
        {
            click_Text = 34; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 14)
        {
            click_Text = 37; 
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
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "우선 레베카의 방에서 레베카의 상태를 확인해보자. ", 1);
                    click_Text = 100;
                    break;
                case 3:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "....", 1);
                    break;
                case 4:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "집에 식량은 충분히 있나?", 1);
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "배고프면 기운이 없어서 아무것도 할 수 없게 되어버려. ", 1);
                    click_Text = 100;
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "오늘로 3일차.", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카는 아직 버텨주고 있지만, 이런 나날을 언제까지 계속할 수 있을지.. ", 1);
                    click_Text = 100;
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "4일 째인가.", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "구조대가 오기까지 11일 남았나..", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "항생제와 식량을 부지런히 모아두는게 좋겠어. ", 1);
                    click_Text = 100;
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "5일차로군.", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "어떻게든 레베카의 감염을 늦춰보려고 하고있지만..", 1);
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "상태가 점점 안 좋아지고 있어.", 1);
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "이대로는.. 뭔가 대책을 찾아야 해.. ", 1);
                    click_Text = 100;
                    break;
                case 16:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..토요일이구나.", 1);
                    break;
                case 17:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...수상한 건물..연구소..", 1);
                    break;
                case 18:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "거기에 뭔가 있을지도..", 1);
                    click_Text = 100;
                    break;
                case 19:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "일주일이 지났다.", 1);
                    break;
                case 20:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 21:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "힘들지만, 힘내자.", 1);
                    break;
                case 22:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "살아 남는 거야.", 1);
                    click_Text = 100;
                    break;
                case 23:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "힘내자 존, 움직일 수 있는 건 너밖에 없어.", 1);
                    break;
                case 24:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "세상이 이 모양이여도, 살아있다는 게 중요해.", 1);
                    click_Text = 100;
                    break;
                case 25:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "내가 잘하고 있는 걸까..", 1);
                    break;
                case 26:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 27:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "최선을 다하자.", 1);
                    click_Text = 100;
                    break;
                case 28:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "구조대가 오기까지 5일 남았어.", 1);
                    break;
                case 29:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "조금만 더 버티자..! ", 1);
                    click_Text = 100;
                    break;
                case 30:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "안돼.. 안돼.. 레베카!!", 1);
                    break;
                case 31:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "헉.. 헉.. 악몽을 꿨어.. ", 1);
                    click_Text = 100;
                    break;
                case 32:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "그러고보면.. 부모님은 잘 계실까,", 1);
                    break;
                case 33:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "연락이 안 되는데.. 지금쯤 시골은...", 1);
                    break;
                case 34:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...하아.", 1);
                    click_Text = 100;
                    break;
                case 35:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 36:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "이틀..", 1);
                    break;
                case 37:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "....레베카는.. 괜찮겠지?", 1);
                    click_Text = 100;
                    break;
                case 38:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "....", 1);
                    break;
                case 39:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "내일이구나.", 1);
                    break;
                case 40:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "오늘 하루만 더 버티면..!!", 1);
                    click_Text = 100;
                    break;
                case 41:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 42:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 43:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 44:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 45:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 46:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 47:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 48:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 49:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 50:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...", 1);
                    break;
                case 51:
                    break;
                case 52:
                    break;
                case 53:
                    break;
                case 54:
                    break;
                case 55:
                    break;
                case 56:
                    break;
                case 57:
                    break;
                case 58:
                    break;
                case 59:
                    break;
                case 60:
                    break;
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}

