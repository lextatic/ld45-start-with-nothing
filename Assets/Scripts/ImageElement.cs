using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageElement : MonoBehaviour
{
	public static Dictionary<string, ImageElement> Elements = new Dictionary<string, ImageElement>();

	[HideInInspector]
	public RawImage RawImage;

	private void Start()
	{
		RawImage = GetComponent<RawImage>();
		RawImage.enabled = false;
		Elements.Add(gameObject.name, this);
	}
}
