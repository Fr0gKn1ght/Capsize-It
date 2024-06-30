using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Boat : RigidBody2D
{

	//The threshold that must be met/exceeded for the boat to capsize.
	[Export]
	private float tiltThreshold = 30;

	[Export]
	private float tiltSpeed = 20;

	private float weight = 0;

	private Godot.Collections.Array<Node2D> collisions;

	//If the ship is not at this current rotation, then "TiltBoat" function will adjust the boat's rotation.
	private float targetRotation = 0;

	private void CalculateRotation()
	{
		targetRotation = weight;
	}
	
	private float RadiansToDegrees(float rads)
	{
		return (float)(rads * (180/Math.PI));
	}

	private float DegreesToRadians(float degrees)
	{
		return (float)(degrees * (Math.PI)/180);
	}

	private void TiltBoat(float delta)
	{
		float currentRotation = RadiansToDegrees(GetTransform().Rotation);
		if(currentRotation != targetRotation && Math.Abs(Math.Abs(targetRotation) - Math.Abs(currentRotation)) > 0.01)
		{
			float rotateDeg = DegreesToRadians(tiltSpeed * ((targetRotation - currentRotation)/Math.Abs(targetRotation - currentRotation)) * delta);
			Rotate(rotateDeg);
		}
	}

	private void Capsize()
	{
		targetRotation = (GetTransform().Rotation > 0) ? 180 : -180;
		tiltSpeed = 200;
	}

	private bool Capsizing()
	{
		return targetRotation == 180 || targetRotation == -180;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ContactMonitor = true;
		MaxContactsReported = 50;
	}

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
		//LinearVelocity = new Vector2(0,0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		if(!Capsizing())
		{
			if(Math.Abs(tiltThreshold - Math.Abs(RadiansToDegrees(GetTransform().Rotation))) <= 0.1)
			{
				Capsize();
			}
		}
		TiltBoat((float)delta);
	}

	private void OnBodyEntered(Node body)
	{
		AngularVelocity += DegreesToRadians(40);
	}

	private void OnScaleAreaEntered(Node2D body)
	{
		GD.Print("Area2D entered");
	}

}
