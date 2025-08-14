function draw_text_shadow(_x, _y, _text, _color, _width)
{
	var _f_size = font_get_size(draw_get_font());
	var _shadow_size = _f_size / 9;
	
	draw_set_color(c_black);
	draw_text_ext(_x + _shadow_size, _y + _shadow_size, _text, _f_size * 1.7, _width);
	
	draw_set_color(_color);
	draw_text_ext(_x, _y, _text, _f_size * 1.7, _width);
}

function GeneralData(_name, _col_main, _col_second) constructor
{
	general_name = _name;
	general_color_main = _col_main;
	general_color_second = _col_second;
}

function general_get_color(_name)
{
	for (var i = 0; i < ds_list_size(global.general_data); i++)
	{
		var _general = global.general_data[|i];
		
		if _general.general_name = _name
		{
			return _general.general_color_main;
		}
	}
	
	return noone;
}

function UnitCard(_unit_data, _width, _height, _grid_x, _grid_y, _spacing, _parent) constructor
{
	card_id = _unit_data.id;
	card_name = _unit_data.name;
	card_general = _unit_data.general;
	
	width = _width;
	height = _height;
	size = 1;
	size_max = 1.1;
	amount = 0;
	amount_max = 0;
	
	grid_x = _grid_x;
	grid_y = _grid_y;
	spacing = _spacing;
	parent = _parent;
	
	function Draw()
	{
		var _w_half = (width / 2) * size;
		var _h_half = (height / 2) * size;

		var _color = general_get_color(card_general);
		
		var _draw_x = (grid_x * (width + spacing)) + (width / 2) + spacing;
		var _draw_y = (grid_y * (height + spacing)) + (height / 2) + spacing - parent.scroll_amount_current;
		
		var _m_x = mouse_x - parent.x;
		var _m_y = mouse_y - parent.y;
		
		var _hover = point_in_rectangle(_m_x, _m_y, _draw_x - _w_half, _draw_y - _h_half, _draw_x + _w_half, _draw_y + _h_half)
		
		if _hover
		{
			if size < size_max
			{
				size = lerp(size, size_max, 0.2);
			}
			
			if mouse_check_button_pressed(mb_left)
			{
				global.selected_card = card_id;
			}
		}
		else
		{
			if size > 1
			{
				size = lerp(size, 1, 0.2);
			}
		}

		draw_sprite_stretched_ext(spr_unit_card, 0, _draw_x - _w_half, _draw_y - _h_half, width * size, height * size, _color, 1);
		draw_sprite_stretched_ext(spr_unit_card_name, 0, _draw_x - _w_half, _draw_y - _h_half, width * size, height * size, c_black, 1);

		draw_set_font(fnt_name);
		draw_set_halign(fa_center);
		draw_set_valign(fa_middle);

		draw_set_color(c_white);
		draw_text_ext(_draw_x, _draw_y + (25 * size), card_name, 15, 90);
		
		if parent.mode = MODE_BUILD
		{
			draw_set_halign(fa_right);
			
			if amount_max > 0
			{
				draw_text_shadow(_draw_x + (_w_half - 10), _draw_y - (_h_half - 10), $"{amount}/{amount_max}", c_white, 100);
			}
			else
			{
				draw_text_shadow(_draw_x + (_w_half - 10), _draw_y - (_h_half - 10), amount, c_white, 100);
			}
			
			var _hover_minus = point_in_rectangle(_m_x, _m_y, (_draw_x - _w_half) + 5, _draw_y - 5, (_draw_x - _w_half) + 15, _draw_y + 5);
			var _hover_plus = point_in_rectangle(_m_x, _m_y, (_draw_x + _w_half) - 15, _draw_y - 5, (_draw_x + _w_half) - 5, _draw_y + 5);
			
			if amount > 0
			{
				draw_sprite(spr_icon_minus, _hover_minus, (_draw_x - _w_half) + 10, _draw_y);
			}
			
			draw_sprite(spr_icon_plus, _hover_plus, (_draw_x + _w_half) - 10, _draw_y);
			
			if _hover_plus
			{
				if mouse_check_button_pressed(mb_left)
				{
					amount++;
					
					global.build_army.ChangeEntries(card_id, 1);
					
					if amount_max > 0
					{
						amount = clamp(amount, 0, amount_max);
					}
				}
			}
			if _hover_minus
			{
				if amount > 0
				{
					if mouse_check_button_pressed(mb_left)
					{
						amount--;
						
						global.build_army.ChangeEntries(card_id, -1);
					}
				}
			}
		}
	}
}

function ArmyCard(_army_data) constructor
{
	army_id = _army_data.armyId;
	army_name = _army_data.name;
	playerId = _army_data.playerId;
	army_entries = _army_data.armyEntries;
	army_points = 0;
	army_hexes = 0;
	
	size = 1;
	size_max = 1.05;
	width = 400;
	height = 100;
	
	function Init()
	{
		army_points = army_total_points(army_entries);
		army_hexes = army_total_hexes(army_entries);
		
		var _new_entries = array_create(0);
		
		for (var i = 0; i < array_length(army_entries); i++)
		{
			var _entry = army_entries[i];
			var _unit_data = unit_find(_entry.cardId);
			
			var _new_entry = new ArmyCardEntry(_unit_data, _entry.amount);
			
			array_push(_new_entries, _new_entry);
		}
		
		army_entries = _new_entries;
	}
	
	function ChangeEntries(_unit_id, _amount)
	{
		//Adjust value of existing entry
		var _unit_data = unit_find(_unit_id);
		var _changed = false;
		var _point_change = _unit_data.points * _amount;
		var _hex_change = _unit_data.hex_per * _unit_data.figures * _amount;
		
		for (var i = 0; i < array_length(army_entries); i++)
		{
			if army_entries[i].unit_id = _unit_id
			{
				army_entries[i].unit_amount += _amount;
				_changed = true;
			}
		}
		//Add a new entry if one doesn't exist
		if !_changed and _amount > 0
		{
			array_push(army_entries, new ArmyCardEntry(_unit_data, _amount));
		}
		army_hexes += _hex_change;
		army_points += _point_change;
		
		//Delete empty entries
		for (var i = 0; i < array_length(army_entries); i++)
		{
			if army_entries[i].unit_amount = 0
			{
				array_delete(army_entries, i, 1);
				i = 0;
			}
		}
	}
	
	function Draw(_x, _y)
	{
		var _w_half = width / 2;
		var _h_half = height / 2;
		
		var _hover = point_in_rectangle(mouse_x, mouse_y, _x - _w_half, _y - _h_half, _x + _w_half, _y + _h_half);
		
		if _hover
		{
			if size < size_max
			{
				size = lerp(size, size_max, 0.2);
			}
			
			if mouse_check_button_pressed(mb_left)
			{
				global.build_army = self;
				room_goto(rm_build);
			}
		}
		else
		{
			if size > 1
			{
				size = lerp(size, 1, 0.2);
			}
		}
		
		draw_set_color(c_ltgray);
		draw_sprite_stretched_ext(spr_unit_card, 0, _x - (_w_half * size), _y - (_h_half * size), width * size, height * size, c_ltgray, 1);
		
		draw_set_font(fnt_med);
		draw_set_halign(fa_left);
		draw_set_valign(fa_middle);
		
		draw_text_shadow(_x - (185 * size), _y - (30 * size), army_name, c_white, 200);
		
		draw_set_font(fnt_small);
		draw_set_halign(fa_right);
		draw_text_shadow(_x + (180 * size), _y - (30 * size), $"Points: {army_points}     Hexes: {army_hexes}", c_white, 300);
		
		draw_set_font(fnt_name);
		draw_set_halign(fa_left);
		for (var i = 0; i < array_length(army_entries); i++)
		{
			var _entry = army_entries[i];
			
			draw_text_shadow(_x - (180 * size), _y + (((i * 12) - 5) * size), $"{_entry.unit_name} x{_entry.unit_amount}", c_white, 300);
		}
	}
}

function ArmyCardEntry(_unit_data, _unit_amount) constructor
{
	unit_id = _unit_data.id;
	unit_name = _unit_data.name;
	unit_amount = _unit_amount;
	unit_general = _unit_data.general;
}