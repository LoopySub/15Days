using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalInfo_door : MonoBehaviour
{
    [SerializeField] private string NextMap;
    [SerializeField] private Vector3 NextCoordinate;
    [SerializeField] private bool In_Or_Out;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹�� ���
            OverallManager.Instance.PublicVariable.NextCoordinate = NextCoordinate; //�÷��̾��� ���� �� ��ġ ����
            OverallManager.Instance.PublicVariable.Am_I_outside = In_Or_Out;
            OverallManager.Instance.SceneTransition.TransitToNextScene(NextMap);
        }
    }
}
