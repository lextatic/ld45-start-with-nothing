using UnityEngine;

[CreateAssetMenu(fileName = "New ActivateObject Command", menuName = "Commands/New ActivateObject Command")]
public class ActivateObjectCommand : Command
{
	public string ObjectName;
	public override void Execute()
	{
		ImageElement imageElement;
		if(ImageElement.Elements.TryGetValue(ObjectName, out imageElement))
		{
			imageElement.RawImage.enabled = true;
		}
	}
}
