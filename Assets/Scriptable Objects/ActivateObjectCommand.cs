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

	public override string FormattedCommandMessage
	{
		get
		{
			int countTotal = 0;
			int countDone = 0;

			foreach (ImageElement ie in ImageElement.Elements.Values)
			{
				countTotal++;
				if (ie.RawImage.enabled)
				{
					countDone++;
				}
			}

			return $"<color=\"green\">{CommandMessage}</color> (<color=\"yellow\">{countDone}</color>/<color=\"yellow\">{countTotal}</color>)";
		}
	}
}
