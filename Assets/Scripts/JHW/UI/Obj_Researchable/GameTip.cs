using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTip : Researchable
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
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "게임 팁을 확인할까요?", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 2:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "매일 00시가 되면 잠에 들고, 다음날 08시에 일어납니다.", 1);
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "그럴 시간 없어.", 1);
                        click_Text = 1000;
                    }
                    break;
                case 3:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "15일 째가 되면 게임 진행 상황에 따라 다른 엔딩이 나옵니다.", 1);
                    break;
                case 4:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "1시간이 지나갈 때마다 배부름 수치가 1.5씩 감소합니다.", 1);
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "즉 배부름 수치는 하루 36씩 감소합니다.", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "레베카의 감염도는 매일 아침 25 ~ 35 사이의 랜덤한 값으로 증가합니다.", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "항생제 사용 시 25~30의 오염도 수치를 회복시킬 수 있고, 그냥 간호할 시 10~20을 회복시킬 수 있습니다.", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "라디오와 PC를 사용하면 유용한 정보를 입수할 수도 있습니다.", 1);
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "매일 00시가 되면 좀비들이 폭주하므로 밖에 있는 사람은 살아남지 못합니다.", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "레베카의 감염도가 100이 되면 돌이킬 수 없습니다.", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "배부름이 0이 되면 굶어 죽습니다.", 1);
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "트루 엔딩이 존재합니다. 도달할 수 있을 지는 모르겠지만.", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "그리고 저는 지금 밤을 새서 이걸 쓰고 있습니다. 완전 노가다입니다.", 1);
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "저는 퀄리티 좋고 재밌는 게임을 다같이 으쌰으쌰해서 만들고 싶었는데, 너무 아쉽네요.", 1);
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "책장", "... ... 다음을 기약합시다...", 1);
                    break;
                case 16:
                    OverallManager.Instance.UiManager.HideDialog();
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
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}
