using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // 1. �ð� ��ġ - ����ð�
    [SerializeField]
    private int currentHour = 0;
    public int CurrentHour
    {
        get { return currentHour; }
        set { currentHour = Mathf.Clamp(value, 0, 24); }
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

    // 2. ���¹̳� ��ġ
    [SerializeField]
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, 0f, 120f); }
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
        }
    }

    // 4. ����ī�� ������ ��ġ 0~100
    [SerializeField]
    private float contamination = 0.0f;
    public float Contamination
    {
        get { return contamination; }
        set { contamination = Mathf.Clamp(value, 0f, 100f); }
    }

    // 5. �ٱ� Ž�� �� ü�� ��ġ
    [SerializeField]
    private float hearts = 3;
    [SerializeField]
    private float maxHearts = 3; 

    public float Hearts
    {
        get { return hearts; }
        set { hearts = Mathf.Max(value, 0); }
    }

    public float MaxHearts
    {
        get { return maxHearts; }
        set { maxHearts = Mathf.Max(value, 1); }
    }

    // ============================================[����� ���� ������]=================================================
    // ==============================================[��޼��� ������]==================================================
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
    // ���� ���� üũ
    public bool IsGameOver()
    {
        return Hearts <= 0;
    }
    // ==============================================[��޼��� ������]==================================================
}


