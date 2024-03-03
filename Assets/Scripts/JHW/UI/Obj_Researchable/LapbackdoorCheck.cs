using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapbackdoorCheck : Researchable
{

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text 값에 따라 다른 동작 수행
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "잠긴 문", "잠겨 있다.", 1);
                    
                    break;
                case 2:
                    if (OverallManager.Instance.PublicVariable.IsLabMainKeyGet == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "카드키를 사용해서 들어갈까?.", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "들어가려면 뭔가 열쇠가 필요할 것 같네.", 1);
                        click_Text = 3;
                    }
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "잠긴 문", "문이 열립니다.", 1);
                        click_Text = 4;
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..오늘은  그만 두자.", 1);
                        click_Text = 3;
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    OverallManager.Instance.PlayerManager.transform.position = new Vector3(-5.89f, -2.67f, 0);
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
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
