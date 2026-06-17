/// @description Insert description here
// You can write your code in this editor
draw_self();

image_index = (global.use_mode = my_mode);

var color = c_white;

if image_index = 1
	{
	color = c_blue;
	}

draw_sprite_ext(spr_gui_button_modes, my_mode, x, y, 1, 1, 0, color, 1);