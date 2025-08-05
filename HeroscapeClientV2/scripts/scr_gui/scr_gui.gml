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

function UnitCard(_unit_data, _width, _height, _grid_x, _grid_y, _spacing) constructor
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
	
	function Draw(_scroll_amount, _x, _y)
	{
		var _w_half = (width / 2) * size;
		var _h_half = (height / 2) * size;

		var _color = general_get_color(card_general);
		
		var _draw_x = (grid_x * (width + spacing)) + (width / 2) + spacing;
		var _draw_y = (grid_y * (height + spacing)) + (height / 2) + spacing - _scroll_amount;
		
		var _hover = point_in_rectangle(mouse_x - _x, mouse_y - _y, _draw_x - _w_half, _draw_y - _h_half, _draw_x + _w_half, _draw_y + _h_half)
		
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

		draw_set_font(fnt_small);
		draw_set_halign(fa_center);
		draw_set_valign(fa_middle);

		draw_set_color(c_white);
		draw_text_ext(_draw_x, _draw_y + (25 * size), card_name, 10, 90);
	}
}