/// @description Insert description here
// You can write your code in this editor
visible = global.use_mode = MODE_MAPS;

if point_in_rectangle(mouse_x, mouse_y, x-(125*size), y-(175*size), x+(125*size), y+(175*size)) and !instance_exists(obj_menu_window_player)
	{
	size += 0.02;
	
	if mouse_check_button_pressed(mb_left) and visible
		{
		array_push(global.maps, new Map("New Map", "icon_map_plains"));
		map_cards_update();
		instance_destroy();
		}
	}
else
	{
	size -= 0.02;	
	}

size=clamp(size, 1, 1.1);