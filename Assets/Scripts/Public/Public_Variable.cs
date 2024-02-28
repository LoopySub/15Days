using System.Collections;
using System.Collections.Generic;
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
                    Sleep_and_wake_up();
                    AccumulatedHours += (32 - value);
                    currentHour = 8;
                }
                else
                {
                    AccumulatedHours += (value - currentHour);
                    currentHour = value;
                }
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
    private int day = 0;
    public int Day
    {
        get { return day; }
        set
        {
            day = value;
        }
    }

    // 2. ���¹̳� ��ġ
    [SerializeField]
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, -10f, 120f); }
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
    private bool am_I_outside =false;
    public bool Am_I_outside
    {
        get { return am_I_outside; }
        set { am_I_outside = value; }
    }

    //�÷��̾� �� �̵� �� ��ǥ ����
    public Vector3 NextCoordinate;

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
        Day = (AccumulatedHours / 24) +1;
    }
    // Contamination ���� ���� Rebecca ���� ������Ʈ
    private void UpdateRebeccaStatus()
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
    // ==============================================[��޼��� ������]==================================================
}


