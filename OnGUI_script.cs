using UnityEngine;

public class OnGUI_script : MonoBehaviour
{
    public float MoveSpeed = 8.0f;
    public float TurnSpeed = 120.0f;

    private void Update()
    {
        //player control
        float vert = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * vert * MoveSpeed * Time.deltaTime);
        float horz = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, horz * TurnSpeed * Time.deltaTime);
    }
    private void OnGUI()
    {
        OnGui_ScreenText("Hello World!", new Rect(10, 10, 300, 50));
        OnGui_OverheadLabel("Moopy");
    }
    private void OnGui_ScreenText(string text, Rect rect)
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 36;
        style.normal.textColor = Color.black;
        GUI.Label(rect, text, style);
    }
    private void OnGui_OverheadLabel(string text)
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 36;
        style.normal.textColor = Color.black;
        Vector3 location = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 4.5f, 0));
        location.y = Screen.height - location.y; //flip the y-coord
        GUI.Label(new Rect(location.x - 50, location.y - 25, 100, 50), text, style);
    }
}
