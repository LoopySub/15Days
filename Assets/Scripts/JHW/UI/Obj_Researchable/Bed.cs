using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Researchable
{
    [SerializeField] private Vector3 NextCoordinate;
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
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..조금 쉴까?", 1);
                        break;
                    case 2:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "침대", "휴식합니다. 2시간 / 스태미나 10 회복", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 3:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            if (OverallManager.Instance.PublicVariable.Fullness < 40)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "배고파서 쉬어도 소용 없겠어.", 1);
                                click_Text = 4;
                                break;
                            }
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...zZZ", 0.5f);
                            OverallManager.Instance.PublicVariable.IsRest = true;
                            OverallManager.Instance.PublicVariable.NextCoordinate = OverallManager.Instance.PlayerManager.transform.position; //플레이어의 다음 맵 위치 전달
                            click_Text = 0;
                            resetSelectRch();
                            OverallManager.Instance.PublicVariable.Stamina += 10;
                            OverallManager.Instance.PublicVariable.CurrentHour += 2;
                            Time.timeScale = 0.7f;
                            OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..쉴 시간은 없어.", 1);
                        }
                        break;
                    case 4:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
                        break;
                    case 5:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "침대", "스태미나를 회복할 수 없어도 쉬시겠습니까?", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 6:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...꼬르륵.", 0.5f);
                            OverallManager.Instance.PublicVariable.IsRest = true;
                            OverallManager.Instance.PublicVariable.NextCoordinate = OverallManager.Instance.PlayerManager.transform.position; //플레이어의 다음 맵 위치 전달
                            click_Text = 0;
                            resetSelectRch();
                            OverallManager.Instance.PublicVariable.CurrentHour += 2;
                            Time.timeScale = 0.7f;
                            OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "...이러다 굶어 죽겠군..", 1);
                        }
                        break;
                    case 7:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
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
}
