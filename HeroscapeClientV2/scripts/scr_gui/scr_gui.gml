function draw_text_shadow(_x, _y, _text, _color, _width)
{
	var _f_size = font_get_size(draw_get_font());
	var _shadow_size = _f_size / 9;
	
	draw_set_color(c_black);
	draw_text_ext(_x + _shadow_size, _y + _shadow_size, _text, _f_size * 1.2, _width);
	
	draw_set_color(_color);
	draw_text_ext(_x, _y, _text, _f_size * 1.2, _width);
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