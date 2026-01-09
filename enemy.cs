using Godot;
using System;

public partial class Enemy : CharacterBody3D
{
	int speed = 50;

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
	
	public void setupEnemy(Vector3 playerPos, Vector3 startPos)
	{
		LookAtFromPosition(startPos, playerPos, Vector3.Up);
		Velocity = Vector3.Forward * 2;
		Velocity = Velocity.Rotated(Vector3.Up, Rotation.Y);
		Position = startPos;
	}
	
	void enemyExited()
	{
		QueueFree();
	}
}
