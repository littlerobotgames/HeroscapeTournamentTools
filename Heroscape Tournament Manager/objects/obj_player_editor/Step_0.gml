/// @description Insert description here
// You can write your code in this editor
visible = global.use_mode = MODE_PARTICPANTS;

if point_in_rectangle(mouse_x, mouse_y, x-(125*size), y-(175*size), x+(125*size), y+(175*size)) and !instance_exists(obj_menu_window_player)
	{
	size += 0.02;
	
	if mouse_check_button_pressed(mb_left) and visible
		{
		var _playerinfo = global.playerlist[p_id];
		my_menu = menu_window_create(p_id, [
			instance_create_depth(x, y, -1010, obj_input_text, {
				box_width : 500,
				box_height : 40,
				text_empty : "player name",
				text : _playerinfo.name
			}),
			instance_create_depth(x, y, -1010, obj_input_text, {
				box_width : 500,
				box_height : 40,
				text_empty : "army name",
				text : _playerinfo.army_name
			}),
			instance_create_depth(x, y, -1010, obj_menu_toggle, {
				text : "By-Round",
				value : _playerinfo.autoby
			}),
			instance_create_depth(x, y, -1010, obj_menu_ok, {
				box_width : 200,
				box_height : 40,
			})
		]);
		}
	}
else
	{
	size -= 0.02;	
	}

size=clamp(size, 1, 1.1);