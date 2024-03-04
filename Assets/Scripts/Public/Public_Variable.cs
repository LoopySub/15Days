using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using static Public_Enum;

public class Public_Variable : BaseMonoBehaviour // ���ӿ��� �������� ���Ǵ� ������� ���� �̺�Ʈ�� �ִ� ��ũ��Ʈ
{
    // ==========================================[����� �ʱ�ȭ ������]==============================================
    // ��������Ʈ �� �̺�Ʈ ����
    public delegate void TimeIncreaseEventHandler(int hoursIncreased);
    public static event TimeIncreaseEventHandler OnTimeIncreased;

    // ==========================================[����� �ʱ�ȭ ������]==============================================

    // ============================================[�鿪���� ������]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[�迪���� ������]=================================================

    // ============================================[����� ���� ������]=================================================
    //���⿡ ���� ��ü�� �������� ���Ǵ� �������� �����մϴ�.

    // 1. �ð� ��ġ - ����ð�
    [SerializeField]
    private int currentHour = 0;
    public int CurrentHour
    {
        get { return currentHour; }
        set {
            if ((value) >= 24)
            {
                if (am_I_outside == true)
                {
                    OverallManager.Instance.GameDataManager.Ending(Ending_type.OverNight);
                    return;
                }
                Sleep_and_wake_up();
                if (value == 24)
                {
                    AccumulatedHours += (value - currentHour + 8);
                    currentHour = 8;
                }
                else
                {
                    AccumulatedHours += ((value - 24) + 8);
                    currentHour = 8;
                }
            }
            else
            {
                AccumulatedHours += (value - currentHour);
                currentHour = value;

            }
            if (Am_I_outside == true)
            {
                if (currentHour >= 19 && currentHour < 23)
                {
                    OverallManager.Instance.UiManager.NightLightOn();
                }
                else if (currentHour >= 23)
                {
                    OverallManager.Instance.UiManager.DeepNightLightOn();
                }
                else
                {
                    OverallManager.Instance.UiManager.MorningLightOn();
                }
            }

            OverallManager.Instance.UiManager.textRenewal();
        }
    }

    // 1. �ð� ��ġ - ���� �ð�
    [SerializeField]
    private int accumulatedHours = 0;
    public int AccumulatedHours
    {
        get { return accumulatedHours; }
        set
        {
            int hoursIncreased = value - accumulatedHours;
            accumulatedHours = value;

            // ���� �ð��� ������ �� �̺�Ʈ �߻�
            OnTimeIncreased?.Invoke(hoursIncreased);
        }
    }

    // 1. �ð� ��ġ - ��(day)
    [SerializeField]
    private int day;
    public int Day
    {
        get { return day; }
        set
        {
            day = value;
            OverallManager.Instance.UiManager.textRenewal();
        }
    }

    // 2. ���¹̳� ��ġ
    [SerializeField]
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set
        {
            stamina = Mathf.Clamp(value, -10f, 120f);
            OverallManager.Instance.UiManager.textRenewal();
        }
    }

    // 3. ��θ� ��ġ
    [SerializeField]
    private float fullness = 100.0f;
    public float Fullness
    {
        get { return fullness; }
        set
        {
            fullness = Mathf.Clamp(value, 0f, 100f);
            if (fullness <= 0f)
            {

                OverallManager.Instance.GameDataManager.Ending(Ending_type.Starvation);
            }
        }
    }

    // 4. ����ī�� ������ ��ġ 0~100
    [SerializeField]
    private float contamination = 0.0f;
    public float Contamination
    {
        get { return contamination; }
        set
        {
            contamination = Mathf.Clamp(value, 0f, 100f);
            // ���� ������Ʈ
            UpdateRebeccaStatus();
        }
    }

    // 4. ����ī�� �������� ���� ���°�
    private RebeccaStatus rebeccaStatus = RebeccaStatus.Cold;
    public RebeccaStatus RebeccaStatus
    {
        get { return rebeccaStatus; }
        set { rebeccaStatus = value; }
    }

    // 5. �ٱ� Ž�� �� ü�� ��ġ
    [SerializeField]
    private float hearts = 3;
    [SerializeField]
    private float maxHearts = 3;

    public float Hearts
    {
        get { return hearts; }
        set
        {
            hearts = Mathf.Max(value, 0);
            if (hearts == 0)
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.GameOver);
            }
        }
    }

    // 5. �ִ� ü��
    public float MaxHearts
    {
        get { return maxHearts; }
        set { maxHearts = Mathf.Max(value, 1); }
    }

    // ���� ���°� �ٱ����� ������
    [SerializeField]
    private bool am_I_outside = false;
    public bool Am_I_outside
    {
        get { return am_I_outside; }
        set
        {
            am_I_outside = value;
            if (am_I_outside == false)
            {
                OverallManager.Instance.UiManager.ShowStaminaBar();
                OverallManager.Instance.UiManager.MorningLightOn();
                OverallManager.Instance.UiManager.ShowRebeccaUI(true);
            }
            else
            {
                OverallManager.Instance.UiManager.ShowHpBar();
                OverallManager.Instance.UiManager.ShowRebeccaUI(false);
            }
        }
    }

    //�÷��̾� �� �̵� �� ��ǥ ����
    [SerializeField]
    private Vector3 nextCoordinate;
    public Vector3 NextCoordinate
    {
        get { return nextCoordinate; }
        set { nextCoordinate = value; }
    }

    //���� ���°�
    [SerializeField]
    private GameState gameState;
    public GameState GameState
    {
        get { return gameState; }
        set
        {                         //���� ���� ���� ���� �÷��̾� ĳ���Ͱ� ���̰� �Ⱥ��̰� �� ���� �ð� ���� / ���
            gameState = value;
            OverallManager.Instance.PlayerManager.playerSetActive(gameState);
            GameStateHandler();
        }
    }

    //UI ���ִ��� üũ
    [SerializeField]
    private bool isUIPopup;
    public bool IsUIPopup
    {
        get { return isUIPopup; }
        set { isUIPopup = value; }
    }

    //��ȭâ ���ִ��� üũ
    [SerializeField]
    private bool isDialog;
    public bool IsDialog
    {
        get { return isDialog; }
        set { isDialog = value; }
    }

    //���ùڽ��� ���ִ���
    [SerializeField]
    private bool isChoiceBoxUI;
    public bool IsChoiceBoxUI
    {
        get { return isChoiceBoxUI; }
        set { isChoiceBoxUI = value; }
    }

    //���������� ���ð��� ��������
    [SerializeField]
    private bool isChoice;
    public bool IsChoice
    {
        get { return isChoice; }
        set {
            isChoice = value;
            OverallManager.Instance.UiManager.HandleIsTargetedChanged();
        }
    }

    //�޽��ߴ���
    [SerializeField]
    private bool isRest;
    public bool IsRest
    {
        get { return isRest; }
        set { isRest = value; }
    }

    //���� Ÿ��
    [SerializeField]
    private Ending_type ending_Type = Ending_type.None;
    public Ending_type Ending_Type
    {
        get { return ending_Type; }
        set { ending_Type = value; }
    }

    //����ī �� ���� ������ ����
    [SerializeField]
    private bool isRebeccaRoomEnter;
    public bool IsRebeccaRoomEnter
    {
        get { return isRebeccaRoomEnter; }
        set { isRebeccaRoomEnter = value; }
    }

    //�׳� ��ħ ���� �ߴ��� ����
    [SerializeField]
    private bool isDM;
    public bool IsDM
    {
        get { return isDM; }
        set { isDM = value; }
    }

    //�׳� ���� ����� ����
    [SerializeField]
    private bool isDayRadio;
    public bool IsDayRadio
    {
        get { return isDayRadio; }
        set { isDayRadio = value; }
    }


    //�׳� PC ����� ����
    [SerializeField]
    private bool isDayPC;
    public bool IsDayPC
    {
        get { return isDayPC; }
        set { isDayPC = value; }
    }

    //PC ���峵���� ����
    [SerializeField]
    private bool isPCBrocken;
    public bool IsPCBrocken
    {
        get { return isPCBrocken; }
        set { isPCBrocken = value; }
    }

    //������ �Ա� Ű �������� ����
    [SerializeField]
    private bool isLabMainKeyGet;
    public bool IsLabMainKeyGet
    {
        get{return isLabMainKeyGet;}
        set { isLabMainKeyGet = value;}
    }

    //��� �������� ����
    [SerializeField]
    private bool isVaccineGet;
    public bool IsVaccineGet
    {
        get { return isVaccineGet; }
        set { isVaccineGet = value; }
    }

    //����ī ġ���ƴ��� ����
    [SerializeField]
    private bool isRebeccaCured;
    public bool IsRebeccaCured
    {
        get { return isRebeccaCured; }
        set { isRebeccaCured = value; }
    }

    //�׻��� ���� �ִ��� ����
    [SerializeField]
    private bool isGetAntibiotic;
    public bool IsGetAntibiotic
    {
        get { return isGetAntibiotic; }
        set { isGetAntibiotic = value; }
    }

    [SerializeField]
    private bool isDeto_A;
    public bool IsDetoA
    {
        get { return isDeto_A;}
        set { isDeto_A = value;}
    }

    [SerializeField]
    private bool isDeto_B;
    public bool IsDetoB
    {
        get { return isDeto_B; }
        set { isDeto_B = value;}
    }

    [SerializeField]
    private bool isDeto_C;
    public bool IsDetoC
    {
        get { return isDeto_C; }
        set { isDeto_C = value;}
    }

    [SerializeField]
    private bool isLabkey_B;
    public bool IsLabkey_B
    {
        get { return isLabkey_B; }
        set { isLabkey_B = value;}
    }

    [SerializeField]
    private bool isBattery;
    public bool IsBattery
    {
        get { return isBattery; }
        set { isBattery = value; }
    }

    [SerializeField]
    private int pastDay;
    public int PastDay
    {
        get { return pastDay; }
        set { pastDay = value; } 
    }


    // ============================================[����� ���� ������]=================================================
    // ==============================================[��޼��� ������]==================================================
    //���⿡�� ��ġ ��ȭ�� ���� Ʈ���� �� Ʈ���� ���� �޼��常 �ۼ��մϴ�.


    private void Start()
    {
        // �̺�Ʈ �ڵ鷯 ���
        OnTimeIncreased += HandleTimeIncrease;
    }

    private void HandleTimeIncrease(int hoursIncreased)
    {
        // ��θ� ����
        Fullness -= 1.5f * hoursIncreased;
    }
    private void Sleep_and_wake_up() //��ħ �� ��Ʈ, ���¹̳�, ������ ��ȭ. ��¥ ����
    {

            OverallManager.Instance.GameDataManager.ResetHearts();
            OverallManager.Instance.GameDataManager.RecoverStaminaAfterSleep();
            OverallManager.Instance.GameDataManager.Contamination_Increases();
        if (RebeccaStatus == RebeccaStatus.Cured)
        {
            OverallManager.Instance.UiManager.ShowRebeccaUI(true);
        }
        else
        {
            OverallManager.Instance.UiManager.ContainHide();
        }
            OverallManager.Instance.UiManager.ShowRebeccaUI(true);
            Day = (AccumulatedHours / 24) + 2;
            OverallManager.Instance.UiManager.DayChangeTextOn(true);
            IsDayRadio = false;
            IsDayPC = false;
            IsDM = false;
        if (Day == 7)
        {
            IsPCBrocken = true;
        }
        if(Day >= 15)
        {
            if (IsRebeccaCured)
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.True);
            }
            else
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.Normal);
            }
        }
        if (Ending_Type == Ending_type.None)
        {
            OverallManager.Instance.PublicVariable.NextCoordinate = new Vector3(5.48f, -1.36f, 0); //�÷��̾��� ���� �� ��ġ ����
            Time.timeScale = 0.5f;

            OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
        }
    }
    // Contamination ���� ���� Rebecca ���� ������Ʈ
    private void UpdateRebeccaStatus()
    {
        if (RebeccaStatus != RebeccaStatus.Cured)
        {

            if (contamination < 50)
                rebeccaStatus = RebeccaStatus.Cold;
            else if (contamination < 70)
                rebeccaStatus = RebeccaStatus.Unstable;
            else if (contamination < 80)
                rebeccaStatus = RebeccaStatus.Violent;
            else if (contamination < 90)
                rebeccaStatus = RebeccaStatus.ZombieLike;
            else if (contamination < 100)
                rebeccaStatus = RebeccaStatus.AlmostZombie;
            else
                rebeccaStatus = RebeccaStatus.Zombie;
        }
    }

    private void GameStateHandler()
    {
        if(GameState == GameState.Cutscene)
        {
            OverallManager.Instance.UiManager.HideStateUI();
        }

        if (GameState == GameState.Playing)
        {
            // Playing ������ ���
            Time.timeScale = 1f; // ���� �ӵ��� �۵�
        }
        else if (GameState == GameState.Interface_On)
        {
            Time.timeScale = 0f; // �ð��� ����
        }
    }
    // ==============================================[��޼��� ������]==================================================
}


