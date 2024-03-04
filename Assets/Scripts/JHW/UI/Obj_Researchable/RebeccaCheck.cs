using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Public_Enum;

public class RebeccaCheck : Researchable
{
    private int _random;

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text 값에 따라 다른 동작 수행
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "커튼", "일단은 레베카를 격리해 두었다.", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "커튼", "레베카의 상태를 확인할까?", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ContainRenewal();
                        OverallManager.Instance.UiManager.ShowRebeccaUI(true);
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "커튼", "커튼을 들추고 안을 살펴본다..", 1);
                        click_Text = 4;
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..쉬게 두자.", 1);
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Cold)
                    {
                        _random = Random.Range(0, 4);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "콜록콜록, 으.. 아빠..", 1);
                            click_Text = 8;
                        }
                        else if( _random == 1)
                        { 
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "상태는 괜찮니 레베카?", 1);
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(레베카는 열이나고 기침을 하고 있다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "콜록콜록, 고마워요 아빠.. 무리는 하지 마세요..", 1);
                            click_Text = 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {
                        _random = Random.Range(0, 3);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "....", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 뭔가 필요한 거라도..", 1);
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카, 괜찮니..", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Violent)
                    {
                        _random = Random.Range(0, 6);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "하아.. 하아..", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(눈이 흐릿하고 침을 흘린다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "케르르르... 크아악!", 1);
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "쿵.. 쿵...!! ", 1);
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아빠.. 조금만 더 가까이 와줘..", 1);
                        }
                        else if (_random == 5)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "잘근잘근.. 까득, 까드득..", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                        _random = Random.Range(0, 5);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "으윽.. 그르륵.. 으..", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "끼익, 끼이익...", 1);
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(눈과 코, 입에서 피가 새어 나온다.)", 1);
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아..빠.. ", 1);
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카?", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.AlmostZombie)
                    {
                        _random = Random.Range(0, 8);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카... ", 1);
                            click_Text = 8;
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "그르르르르.. ", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(눈과 코, 입에서 검은 피가 쏟아져 나온다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(살이 조금씩 썩어가고 있다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "(방에서 썩은 내가 난다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 5)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "캬아아아악!! ", 1);
                            click_Text = 8;
                        }
                        else if (_random == 6)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "(대화는 할 수 없을 것 같다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 7)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "(가까이 가지 않는게 좋을 것 같다.)", 1);
                            click_Text = 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Zombie)
                    {
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        OverallManager.Instance.GameDataManager.Ending(Ending_type.Infection);
                    }
                    break;
                case 6:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Cold)
                    {
                        if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "네.. 열은 좀 나지만 괜찮아요.. ", 1);
                            click_Text = 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {
                       
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카..?", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", ".... (들리지 않는 것 같다)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "..아빠.. 으.. 머리가 어지러워요..", 1);
                            click_Text= 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Violent)
                    {
                      
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "그르르.. 으윽..!", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아냐, 그건 내가 아냐..!", 1);
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(벽에 머리를 박고 있다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "아니, 오지마... 오면 안돼...!.", 1);
                            click_Text = 8;
                        }
                        else if (_random == 5)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(침대를 물어 뜯고있다.)", 1);
                            click_Text= 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                       
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카.. 조금만 참으렴, 아빠가 어떻게든..", 1);
                            click_Text = 8;
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(정신 나간 것처럼 벽을 손톱으로 긁고 있다.  손끝에서 피가 흘러내린다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(존을 발견하자, 먹잇감을 보는 듯한 눈으로 바라본다.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "나.. 배고파...", 1);
                            click_Text= 8;
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "캬아아악-!!", 1);
                        }
                    }
                    break;
                case 7:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {

                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "먹고싶어.. 물어뜯고싶어.. ", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                        if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "우악?!", 1);
                        }
                    }
                    break;
                case 8:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {

                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "레베카", "(레베카는 고개를 푹 숙이고 뭔가를 빠르게 중얼거리고 있다)", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                        if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "(하마터면 물릴 뻔 했어..)", 1);
                        }
                    }
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "레베카를 돌봐줄까?", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "레베카를 간호합니다. 3시간 / 스태미나 30 사용", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 11:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            if (OverallManager.Instance.PublicVariable.Stamina < 30)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "스태미나가 부족합니다.", 1);
                                click_Text = 3;
                                break;

                            }
                            else if (OverallManager.Instance.PublicVariable.CurrentHour >= 22)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "밤이 너무 늦었어. 자게 두자.", 1);
                                click_Text = 3;
                                break ;
                            }
                            else
                            {
                            if (OverallManager.Instance.PublicVariable.IsGetAntibiotic == true) // 항셍제 소지수 >=1
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "항생제를 사용할까?", 1);
                                OverallManager.Instance.UiManager.ShowChoiceBox();
                                click_Text = 13; 
                                break;
                            }
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...(간호중)", 1);
                        }
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "안정을 취하게 두자..", 1);
                            click_Text = 3;
                        }
                    break;
                case 12:
                    if (OverallManager.Instance.PublicVariable.Contamination <= 80)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "레베카의 상태가 조금 진정됐다.", 1);
                        OverallManager.Instance.PublicVariable.Contamination -= Random.Range(10, 21);
                        OverallManager.Instance.UiManager.ContainRenewal();
                        
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "레베카의 감염 진행도가 심각해서 그냥 간호하는 것만으로는 효과가 없었다..", 1);
                        OverallManager.Instance.PublicVariable.Contamination -= Random.Range(4, 7);
                    }
                    break;
                case 13:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 30;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 14:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...(항생제 투여중)", 1);
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...(간호중)", 1);
                        click_Text =11;
                    }
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "레베카의 상태가 그럭저럭 호전됐다.", 1);
                    OverallManager.Instance.Inventory.useHangSengJe();
                    OverallManager.Instance.PublicVariable.Contamination -= Random.Range(25, 36);
                    OverallManager.Instance.UiManager.ContainRenewal();
                    break;
                case 16:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 30;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    resetSelectRch();
                    click_Text = 0;
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
}