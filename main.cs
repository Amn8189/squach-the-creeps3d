using Godot;
using System;

public partial class Main : Node3D
{
	[Export]
	public PackedScene Enemy;
	
	int score = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	void startGame()
	{
		GetNode<Timer>("Control/Timer").Start();
		GetNode<Timer>("Timer").Start();
		GetNode<Button>("Control/Button").Hide();
	}
	
	void spawnEnemy()
	{
		GD.Print("mobSpawned");
		var clone = Enemy.Instantiate<Enemy>();
		var pathFollow = GetNode<PathFollow3D>("Path3D/PathFollow3D");
		pathFollow.ProgressRatio = GD.Randf();
		clone.Position = pathFollow.Position;
		var playerPos = GetNode<CharacterBody3D>("player").Position;
		clone.setupEnemy(playerPos, clone.Position);
		AddChild(clone);
	}
	
	void incScore()
	{
		score += 1;
		GetNode<Label>("Control/Label").Text = score.ToString();
	}
}
