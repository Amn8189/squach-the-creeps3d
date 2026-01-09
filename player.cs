using Godot;
using System;

public partial class Player : CharacterBody3D
{
	int speed = 40;
	Vector3 velocity = new Vector3(0,0,0);

	public override void _PhysicsProcess(double delta)
	{	
		Vector3 direction = new Vector3(0,0,0); //(x,y,z)
		
		
		
		if (Input.IsActionPressed("moveLeft"))
		{
			direction.X -= 1;
		}
		if (Input.IsActionPressed("moveRight"))
		{
			direction.X += 1;
		}
		if (Input.IsActionPressed("moveFront"))
		{
			direction.Z -= 1;
		}
		if (Input.IsActionPressed("moveBack"))
		{
			direction.Z += 1;
		}
		
		if(direction!=new Vector3(0,0,0))
		{
			direction = direction.Normalized();
		}
		
		velocity.X = direction.X * speed;
		velocity.Z = direction.Z * speed;
		
		if(direction != Vector3.Zero)
		{
			GetNode<Node3D>("Node3D").Basis = Basis.LookingAt(direction);
		}
		
		
		
		if (IsOnFloor())
		{
			velocity.Y = 0;
		} 
		else
		{
			velocity.Y -= 5;
		}
		
		if (IsOnFloor() && Input.IsActionPressed("jump"))
		{
			velocity.Y = 50;
		}
		
		Velocity = velocity;
		MoveAndSlide();
		//Vector3 distance = velocity * (float)delta;
		//Position = Position + distance;
		
	}
}
