extends Node2D

var element = preload("res://Element_loader.tscn")

var elementalArray = ["crate","cargo","shark","crab"]
var queuetracker = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	collision()
	pass # Replace with function body.

func collision():
	var instance = element.instantiate()
	instance.position = (Vector2(77,33))
	instance.texture = applyTexture(elementalArray[queuetracker])
	add_child(instance)
	#main.Roster.RosterElement1.hide()
	++queuetracker

func applyTexture(index):
	match index:
		"crate":
			return load("res://Assets/crate-removebg-preview.png")
		"cargo":
			return  load("res://Assets/cargo-removebg-preview.png")
		"shark":
			return  load("res://Assets/sharkbox-removebg-preview.png")
		"crab":
			return  load("res://Assets/crabtrap-removebg-preview.png")
		

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
