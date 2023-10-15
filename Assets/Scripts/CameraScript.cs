using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
    [SerializeField] List<Transform> players;
    public Vector3 offset;
    private Vector3 velocity;

    void LateUpdate()
    {
        Vector3 centre = GetCentrePoint();
        Vector3 newPos = centre + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos,ref velocity, 0.5f);
    }

    // Update is called once per frame
    Vector3 GetCentrePoint()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);
        for (int i = 0; i < players.Count; i++)
        {
            //resize to fix players
            bounds.Encapsulate(players[i].position);
        }
        return bounds.center;
    }
}