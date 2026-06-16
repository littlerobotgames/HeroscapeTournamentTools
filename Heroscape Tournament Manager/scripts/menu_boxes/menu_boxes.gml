// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function menu_window_create(_player_id, _element_array)
{
var _obj = instance_create_depth(room_width/2, room_height/2, -1000, obj_menu_window_player)

with (_obj)
	{
	p_id = _player_id;
	for (var i = 0; i < array_length(_element_array); i++)
		{
		array_push(elements, _element_array[i]);
		}
	for (var i = 0; i < array_length(_element_array); i++)
		{
		with (elements[i])
			{
			master = other.id;
			x = other.x - (box_width/2);
			y = other.y + (70 * i)+35;
			}
		}
	}

return _obj;
}

function menu_window_create_map(_map_id, _element_array)
{
var _obj = instance_create_depth(room_width/2, room_height/2, -1000, obj_menu_window_map)

with (_obj)
	{
	m_id = _map_id;
	for (var i = 0; i < array_length(_element_array); i++)
		{
		array_push(elements, _element_array[i]);
		}
	for (var i = 0; i < array_length(_element_array); i++)
		{
		with (elements[i])
			{
			master = other.id;
			x = other.x - (box_width/2);
			y = other.y + (70 * i)+35;
			}
		}
	}

return _obj;
}