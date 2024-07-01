extends RigidBody2D

@export var MOVE_SPEED = -5
@export var ACCELERATION = -5
var movement_vector = Vector2(MOVE_SPEED, 0)
var timer = 0.0
var rng = RandomNumberGenerator.new()
var rngNumber

# Called when the node enters the scene tree for the first time.
func _ready():
	rngNumber = randf()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	timer += delta * rngNumber
	#print(timer)
	#ACCELERATION += timer
	MOVE_SPEED += log(timer)+1
	print('Timer ' + str(timer) + ' Move Speed ' + str(MOVE_SPEED))
	movement_vector = Vector2(MOVE_SPEED, 0)
	if timer > 1.0:
		MOVE_SPEED = 0
		timer = 0

func _integrate_forces(state):
	state.set_linear_velocity(movement_vector)
