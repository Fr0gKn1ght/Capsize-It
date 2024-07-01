extends RigidBody2D

@export var MOVE_SPEED = 3
var movement_vector = Vector2(MOVE_SPEED, 0)

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	movement_vector = Vector2(MOVE_SPEED, 0)

func _integrate_forces(state):
	state.set_linear_velocity(movement_vector)
