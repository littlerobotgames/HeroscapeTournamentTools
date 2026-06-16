/// @description Insert description here
// You can write your code in this editor
visible = global.use_mode = MODE_PARTICPANTS;

if point_in_rectangle(mouse_x, mouse_y, x-(125*size), y-(175*size), x+(125*size), y+(175*size)) and !instance_exists(obj_menu_window_player)
	{
	size += 0.02;
	
	if mouse_check_button_pressed(mb_left) and visible
		{
		array_push(global.playerlist, new Player("New Guy", "New Army", -1, LEVEL_ROOKIE, false));
		player_cards_update();
		instance_destroy();
		}
	}
else
	{
	size -= 0.02;	
	}

size=clamp(size, 1, 1.1);