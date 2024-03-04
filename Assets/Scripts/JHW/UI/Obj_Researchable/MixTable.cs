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
            // click_Text ���� ���� �ٸ� ���� ����
            if (OverallManager.Instance.PublicVariable.IsRest == false)
            {
                switch (click_Text)
                {
                    case 1:
                        if(OverallManager.Instance.PublicVariable.IsVaccineGet == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ռ���", "����� ���ϰ� ������ �ִ�.", 1);
                            click_Text = 3; 
                            break;
                        }
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ռ���", "������ �ִ� �����۵��� ��� ������ ���� �� ���� ���� �𸥴�..", 1);
                        break;
                    case 2:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ռ���", "3���� Ȩ�� �ֽ��ϴ�. ������ �ִ� �͵��� �־� ���ðڽ��ϱ�?", 1);
                        OverallManager.Instance.UiManager.ShowChoiceBox();
                        break;
                    case 3:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            if (OverallManager.Instance.PublicVariable.IsDetoA == true && OverallManager.Instance.PublicVariable.IsDetoB == true && OverallManager.Instance.PublicVariable.IsDetoC == true)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "(�̿ϼ� ��� A, B, C �� �ռ����� Ȩ�� ���� �ִ´�.", 1);
                                click_Text = 4;
                            }
                            else
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...Ȩ�� ���� ���� ������ ������.", 1);
                                break;
                            }
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..������� �ͼ� �� �����̴� �ž�?", 1);
                            click_Text = 3;
                        }
                        break;
                    case 4:
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        click_Text = 0;
                        break;
                    case 5:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ռ���", ".......", 1);
                        break;
                    case 6:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ռ���", "��¼-��!!", 1);
                        break;
                    case 7:
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��� - ?!!", 1);
                        break;
                    case 8:
                        OverallManager.Instance.Inventory.Mix();
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ռ���", "�������-!! �ռ���� ��� �������� �����ϴµ� �����ߴ�!", 1);
                        break;
                    case 9:
                        Instantiate(Vac);
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�̰ɷ�..! � ���� ���ư���!", 1);
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