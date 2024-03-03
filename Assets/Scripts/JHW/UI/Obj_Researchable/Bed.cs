using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Public_Enum;

public class Bed : Researchable
{
    [SerializeField] private Vector3 NextCoordinate;
    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            if (OverallManager.Instance.PublicVariable.IsRest == false)
            {
                switch (click_Text)
                {
                    case 1:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..���� ����?", 1);
                        break;
                    case 2:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "ħ��", "�޽��մϴ�. 2�ð� / ���¹̳� 10 ȸ��", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 3:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            if (OverallManager.Instance.PublicVariable.Fullness < 20)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ļ� ��� �ҿ� ���ھ�.", 1);
                                click_Text = 4;
                                break;
                            }
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...zZZ", 0.5f);
                            OverallManager.Instance.PublicVariable.IsRest = true;
                            OverallManager.Instance.PublicVariable.NextCoordinate = OverallManager.Instance.PlayerManager.transform.position; //�÷��̾��� ���� �� ��ġ ����
                            click_Text = 0;
                            resetSelectRch();
                            OverallManager.Instance.PublicVariable.Stamina += 10;
                            OverallManager.Instance.PublicVariable.CurrentHour += 2;
                            Time.timeScale = 0.7f;
                            OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..�׷� ǫ ����?", 1);
                            click_Text = 7;
                        }
                        break;
                    case 4:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
                        break;
                    case 5:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "ħ��", "���¹̳��� ���ݹۿ� ȸ���� �� ��� ���ðڽ��ϱ�?", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 6:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...������.", 0.5f);
                            OverallManager.Instance.PublicVariable.IsRest = true;
                            OverallManager.Instance.PublicVariable.NextCoordinate = OverallManager.Instance.PlayerManager.transform.position; //�÷��̾��� ���� �� ��ġ ����
                            click_Text = 0;
                            resetSelectRch();
                            OverallManager.Instance.PublicVariable.Stamina += 5;
                            OverallManager.Instance.PublicVariable.CurrentHour += 2;
                            
                            if (OverallManager.Instance.PublicVariable.Ending_Type == Ending_type.None)
                            {
                                Time.timeScale = 0.7f;
                                OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
                            }
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...�̷��� ���� �װڱ�..", 1);
                        }
                        break;
                    case 7:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
                        break;
                    case 8:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "ħ��", "���� ��ħ���� ���ϴ�. / �Ϸ縦 ��ŵ�մϴ�.", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 9:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...zZZ", 0.5f);
                            OverallManager.Instance.PublicVariable.IsRest = true;
                            OverallManager.Instance.PublicVariable.NextCoordinate = OverallManager.Instance.PlayerManager.transform.position; //�÷��̾��� ���� �� ��ġ ����
                            click_Text = 0;
                            resetSelectRch();
                            OverallManager.Instance.PublicVariable.Stamina += 10;
                            OverallManager.Instance.PublicVariable.CurrentHour = (24);
                            
                            if (OverallManager.Instance.PublicVariable.Ending_Type == Ending_type.None)
                            {
                                Time.timeScale = 0.7f;
                                OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
                            }
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..�׸� ����.", 1);
                        }
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
                    // �߰����� ��쿡 ���� ó���� �̾ �ۼ�
                    default:
                        // �⺻�����δ� �ƹ� ���۵� ���� ����
                        break;
                }
            }
        }
    }
}
