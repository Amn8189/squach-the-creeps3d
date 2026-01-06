using Godot;
using System;

public partial class Player : CharacterBody3D
{
	int speed = 40;

	public override void _PhysicsProcess(double delta)
	{	
		Vector3 direction = new Vector3(0,0,0); //(x,y,z)
		
		
		if (Input.IsActionPressed("moveLeft"))
		{
			direction.X = -1;
		}
		if (Input.IsActionPressed("moveRight"))
		{
			direction.X = 1;
		}
		if (Input.IsActionPressed("moveFront"))
		{
			direction.Z = -1;
		}
		if (Input.IsActionPressed("moveBack"))
		{
			direction.Z = 1;
		}
		
		GetNode<Node3D>("Node3D").Basis = Basis.LookingAt(direction);

		Vector3 velocity = direction * speed;
		
		if (IsOnFloor())
		{
			velocity.Y = 0;
		} 
		else
		{
			velocity.Y -= 100;
		}
		
		Velocity = velocity;
		MoveAndSlide();
		//Vector3 distance = velocity * (float)delta;
		//Position = Position + distance;
		
	}
}
