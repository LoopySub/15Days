using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Researchable
{

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ������ �����?", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �����մϴ�. 3�ð� / ���¹̳� 30 ���", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        if(OverallManager.Instance.PublicVariable.Stamina < 30)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "���¹̳��� �����մϴ�.", 1);
                            click_Text = 3;
                            break;

                        }
                        else if(OverallManager.Instance.PublicVariable.CurrentHour >=22)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �ʹ� �ʾ���.", 1);
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ķ�� ����.. ����.. ������..", 1);
                            click_Text = 4;
                        }
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..������ ����.", 1);
                        click_Text = 3;
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �ҽ���...", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����- ������..!", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���İ� �� ��������...", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 30;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    resetSelectRch();
                    click_Text = 0;
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
                // �߰����� ��쿡 ���� ó���� �̾ �ۼ�
                default:
                    // �⺻�����δ� �ƹ� ���۵� ���� ����
                    break;
            }
        }
    }
}