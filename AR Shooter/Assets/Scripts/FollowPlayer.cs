using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localPosition = player.transform.localPosition + offset;
    }
}