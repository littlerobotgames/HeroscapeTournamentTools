/// @description Insert description here
// You can write your code in this editor
visible = global.use_mode = MODE_MAPS;

if point_in_rectangle(mouse_x, mouse_y, x-(125*size), y-(175*size), x+(125*size), y+(175*size)) and !instance_exists(obj_menu_window_player)
	{
	size += 0.02;
	
	if mouse_check_button_pressed(mb_left) and visible
		{
		var _mapinfo = global.maps[m_id];
		my_menu = menu_window_create_map(m_id, [
			instance_create_depth(x, y, -1010, obj_input_text, {
				box_width : 500,
				box_height : 40,
				text_empty : "map name",
				text : _mapinfo.name
			}),
			instance_create_depth(x, y, -1010, obj_menu_toggle, {
				text : "Final",
				value : _mapinfo.final
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