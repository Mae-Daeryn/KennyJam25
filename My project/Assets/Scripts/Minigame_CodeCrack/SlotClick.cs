using UnityEngine;

public class SlotClick : MonoBehaviour
{
    public int slotIndex;
    public ColorCodeGame game;

    public void OnClick()
    {
        game.CycleSlot(slotIndex);
    }
}
