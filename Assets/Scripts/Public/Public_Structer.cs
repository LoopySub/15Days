using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Structer : BaseMonoBehaviour
{
    // ============================================[↓역참조 구역↓]=================================================

    private IOverallManager _overallManager;

    public IOverallManager OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[↑역참조 구역↑]=================================================

    // ============================================[↓공용 구조체 구역↓]=================================================

    public struct Coordinates       //좌표값
    {
        public float x;
        public float y;
        public float z;
    }

    public struct RGBColor      //RGB값
    {
        public byte red;
        public byte green;
        public byte blue;
    }

    public struct TimeInterval      //시간 단위
    {
        public float seconds;
        public int minutes;
        public int hours;
    }

    public struct PlayerAttributes      //플레이어 속성
    {
        public int health;
        public int attackDamage;
        public float movementSpeed;
    }

    public struct ItemProperties    //아이템 속성
    {
        public string itemName;
        public int itemID;
        public float weight;
    }

    public struct ScreenSize    //화면 크기
    {
        public int width;
        public int height;
    }
    // ============================================[↑공용 구조체 구역↑]=================================================
}
