using UnityEngine;

[CreateAssetMenu(menuName = "Item/Tool")]
public class ToolItem : Item
{
    public int power = 1;

    public override void Use(GameObject user)
    {
        ToolController controller =
            user.GetComponent<ToolController>();

        if (controller != null)
        {
            controller.UseTool(this);
        }
    }
}