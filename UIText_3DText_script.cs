using UnityEngine;

public class UIText_3DText_script : MonoBehaviour
{
    public float MoveSpeed = 8.0f;
    public float TurnSpeed = 120.0f;
    public GameObject OverheadLabel = null;

    private void Update()
    {
        //player control
        float vert = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * vert * MoveSpeed * Time.deltaTime);
        float horz = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, horz * TurnSpeed * Time.deltaTime);

        OverheadLabelText_Face_Camera(OverheadLabel);
    }
    private void OverheadLabelText_Face_Camera(GameObject LabelGameObject)
    {
        Vector3 directionAwayFromCamera = LabelGameObject.transform.position - Camera.main.transform.position;
        LabelGameObject.transform.rotation = Quaternion.LookRotation(directionAwayFromCamera);
        //optional: adjust the rotation keep text upright
        LabelGameObject.transform.rotation = Quaternion.Euler(0, LabelGameObject.transform.rotation.eulerAngles.y, 0);
    }
}
