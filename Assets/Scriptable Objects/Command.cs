using UnityEngine;

public abstract class Command : ScriptableObject
{
	public string[] CommandAliases;

	public string[] CommandHints;

	public string CommandMessage;

	public Command[] CommandUnlocks;

	public abstract void Execute();
}
