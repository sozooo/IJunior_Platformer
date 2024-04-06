using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private Vector3 _offset;

    private void Update()
    {
        _offset = transform.position;

        _offset.x += 0.5f * transform.localScale.x;
    }

    public Player Detect()
    {
        if (Physics2D.Raycast(_offset, Vector2.right).transform.TryGetComponent<Player>(out Player detectedPlayer))
        {
            return detectedPlayer;
        }

        return null;
    } 
}
 