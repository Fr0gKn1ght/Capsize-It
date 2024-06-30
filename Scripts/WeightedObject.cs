using Godot;
using System;

public partial class WeightedObject : RigidBody2D
{
	private float weight = 50;

	public float GetWeight()
	{
		//GetCollidingBodies();
		return weight;

	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
