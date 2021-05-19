using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                        mouse.x,
                                                        mouse.y,
                                                        mouse.z));
        float newY;
        if (mouseWorld.y > 4) newY = 4;
        else if (mouseWorld.y < -4) newY = -4;
        else newY = mouseWorld.y;
        Vector3 newPosition = new Vector3(-7.5f, newY, 0);
        this.transform.position = newPosition;
    }
}
