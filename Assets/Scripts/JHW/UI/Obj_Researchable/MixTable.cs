using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Public_Enum;

public class MixTable : Researchable
{
    [SerializeField]
    private GameObject Vac;

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text 값에 따라 다른 동작 수행
            if (OverallManager.Instance.PublicVariable.IsRest == false)
            {
                switch (click_Text)
                {
                    case 1:
                        if(OverallManager.Instance.PublicVariable.IsVaccineGet == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "합성대", "기능을 다하고 망가져 있다.", 1);
                            click_Text = 3; 
                            break;
                        }
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "합성대", "가지고 있는 아이템들을 섞어서 뭔가를 만들 수 있을 지도 모른다..", 1);
                        break;
                    case 2:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "합성대", "3개의 홈이 있습니다. 가지고 있는 것들을 넣어 보시겠습니까?", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 3:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            if (OverallManager.Instance.PublicVariable.IsDetoA == true && OverallManager.Instance.PublicVariable.IsDetoB == true && OverallManager.Instance.PublicVariable.IsDetoC == true)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "(미완성 백신 A, B, C 를 합성대의 홈에 끼워 넣는다.", 1);
                                click_Text = 4;
                            }
                            else
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...홈에 넣을 만한 물건이 부족해.", 1);
                                break;
                            }
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..여기까지 와서 뭘 망설이는 거야?", 1);
                            click_Text = 3;
                        }
                        break;
                    case 4:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
                        break;
                    case 5:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "합성대", ".......", 1);
                        break;
                    case 6:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "합성대", "번쩌-억!!", 1);
                        break;
                    case 7:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "우왓 - ?!!", 1);
                        break;
                    case 8:
                        OverallManager.Instance.Inventory.Mix();
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "합성대", "빠밤빠밤-!! 합성대는 백신 제조서를 연성하는데 성공했다!", 1);
                        break;
                    case 9:
                        Instantiate(Vac);
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "이걸로..! 어서 갖고 돌아가자!", 1);
                        break;
                    case 10:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        OverallManager.Instance.UiManager.HideDialog();
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
}