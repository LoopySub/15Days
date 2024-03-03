using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebeccaOutoor : MonoBehaviour
{
    [SerializeField] private string NextMap;
    [SerializeField] private Vector3 NextCoordinate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���� �� �̵�");
            // �÷��̾�� �浹�� ���
            OverallManager.Instance.PublicVariable.NextCoordinate = NextCoordinate; //�÷��̾��� ���� �� ��ġ ����
            OverallManager.Instance.SceneTransition.TransitToNextScene(NextMap);
        }
    }
}
