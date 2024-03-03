using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTop : Researchable
{
    public override void Click_Text_Reset()
    {
        if (OverallManager.Instance.PublicVariable.Day == 1)
        {
            click_Text = 4;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 2)
        {
            click_Text = 9;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 3)
        {
            click_Text = 14;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 4)
        {
            click_Text = 18;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 5)
        {
            click_Text = 23;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 6)
        {
            click_Text = 25;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 7)
        {
            click_Text = 28;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 8)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 9)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 10)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 11)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 12)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 13)
        {
            click_Text = 3;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 14)
        {
            click_Text = 3;
        }
    }

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            switch (click_Text)
            {
                case 1:
                    if(OverallManager.Instance.PublicVariable.IsPCBrocken == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�̷�, ������ �� ����. ���� ������ �����̶�..\r\n�����ϱ� �������� �۵����� ���� �� ����. ", 1);
                        click_Text = 3;
                        break;
                    }
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �˻��غ���?.", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "������ �����մϴ�. 3�ð� / ���¹̳� 20 ���", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        if (OverallManager.Instance.PublicVariable.IsDayPC == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������ �� �̻� �ֽ� �Խù��� �� �ö���� �� ����.", 1);
                            click_Text = 3;
                            break;
                        }
                        if (OverallManager.Instance.PublicVariable.Stamina < 20)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "���¹̳��� �����մϴ�.", 1);
                            click_Text = 3;
                            break;

                        }
                        else if (OverallManager.Instance.PublicVariable.CurrentHour >= 22)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �ʹ� �ʾ���.", 1);
                        }
                        else
                        {

                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[������ ķ�� Ŀ�´�Ƽ�� ���� ���� ȯ���մϴ�.]", 1);
                            Click_Text_Reset();
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
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[������ ���� ���� �Խ���]", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "�׻����� ����� ���̷����� ���� �ӵ��� ���� �� �־�.", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "����� ���̳� �� ��ó�� �׻����� ���� �� �ִٸ� ��������.", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��.. �׻���.. �׻����� ��� ���Ѵ�.. ", 1);
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�� ��ó�� �౹�� �־���?.. ", 1);
                    click_Text = 1000;
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[������ �ҽ� �Խ���]", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "��ȭó�� ��򰡿� ����� �������� ������?", 1);
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "�����Ҷ����.", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[���]", "���׷��� �ְڳ�, �ٺ���.", 1);
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..���. �����ϱ⸸ �Ѵٸ�, ����ī��..", 1);
                    click_Text = 1000;
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[������ ���� ���� �Խ���]", 1);
                    break;
                case 16:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "������ ����: ����� �㿡 Ư�� ��������, ������ �Ǹ� ���� 20�� �ӵ��� �� �� �ֽ��ϴ�!", 1);
                    break;
                case 17:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "��ʰ� ���ƴٴ��� ���ð�, ���� �ʸӿ��� ���� �� �ᱸ��, ��� Ȱ���� ���߰� ���̳� �ڼ���!", 1);
                    break;
                case 18:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..���� 20�̶��, �� ��Ʈ��İ�.. ", 1);
                    click_Text = 1000;
                    break;
                case 19:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[������ ���� ���� �Խ���]", 1);
                    break;
                case 20:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "XX���� ������ �ǹ� �޹����� ���ϴ� ���� ����־�.", 1);
                    break;
                case 21:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "�׷��� ��¼�� Ư���� ����� �� �� �������� ����.", 1);
                    break;
                case 22:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "ī��Ű��...", 1);
                    break;
                case 23:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..�� ���� ���ٰ� �� �ž�? ", 1);
                    click_Text = 1000;
                    break;
                case 24:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", "[������ �ҽ� �Խ���]", 1);
                    break;
                case 25:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "���� �ö�Դ� �Խñ۸���, �۾��� ������ �����Ǿ� �ִ���. ", 1);
                    click_Text = 1000;
                    break;
                case 26:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "[�ۼ���]", "�� �ǹ��� ���� �������ִ� �ɱ�?", 1);
                    break;
                case 27:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��.. �׷��� ���� �� �ǹ��� ���� �ǹ��̾�����?", 1);
                    break;
                case 28:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�����ҿ��� �� ������.. ", 1);
                    break ;
                case 29:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "PC", "Ǫ����-!!", 1);
                    break;
                case 30:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "PC", "(�ٿ��)", 1);
                    break;
                case 31:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�̷�, ȭ���� �������ȴ�! �� �� �� �� ����.", 1);
                    click_Text = 1000;
                    break;
                case 32:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 33:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 34:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 35:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 36:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 37:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 38:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 39:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 40:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 41:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 42:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 43:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 44:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 45:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 46:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 47:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 48:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 49:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 50:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 51:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 52:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 53:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 54:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 55:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 56:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 57:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 58:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 59:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 60:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 61:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 62:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 63:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 64:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 65:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 66:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 67:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 68:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 69:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 70:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    click_Text = 1000;
                    break;
                case 71:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 72:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 73:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 74:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 75:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 76:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 77:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 78:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 79:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 80:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 81:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 82:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 83:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 84:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 85:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 86:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 87:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 88:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 89:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 90:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 91:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 92:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 93:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 94:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                case 95:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "PC", " ", 1);
                    break;
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 20;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    OverallManager.Instance.PublicVariable.IsDayPC = true;
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}
