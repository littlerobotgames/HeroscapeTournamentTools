/// @description Insert description here
// You can write your code in this editor
global.use_mode = MODE_PLAY;

with(instance_create_layer(224, 32, "Instances", obj_gui_button_mode))
	{
	my_mode = MODE_PLAY;
	}

instance_destroy(obj_gui_button_shuffle);
instance_destroy();