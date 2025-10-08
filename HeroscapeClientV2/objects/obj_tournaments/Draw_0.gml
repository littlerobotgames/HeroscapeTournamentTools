draw_set_font(fnt_med);
draw_set_halign(fa_left);
draw_set_valign(fa_middle);

for (var i = 0; i < array_length(tournaments); i++)
{
	var _t_data = tournaments[i];
	var _draw_y = (i * 26) + 100;
	
	var _hover = point_in_rectangle(mouse_x, mouse_y, 35, _draw_y - 10, 600, _draw_y + 10);
	var _selected = selected_tournament = i;
	
	if _selected
	{
		draw_set_color(c_blue);
		draw_rectangle(35, _draw_y - 10, 600, _draw_y + 12, true);
		
		draw_sprite_stretched_ext(spr_unit_card, 0, 700, 50, 400, 550, c_dkgray, 1);
		
		draw_set_font(fnt_lrg);
		draw_set_halign(fa_left);
		draw_set_valign(fa_middle);
		draw_text_shadow(725, 75, _t_data.name, c_white, 350);
		
		draw_set_font(fnt_small);
		draw_text_shadow(725, 100, "Organizer", c_white, 350);
		
		draw_set_font(fnt_med);
		draw_text_shadow(725, 150, formats[_t_data.format], c_white, 350);
		draw_text_shadow(725, 175, $"Max Points: {_t_data.points}", c_white, 350);
		draw_text_shadow(725, 200, $"Max Hexes: {_t_data.hexes_max}", c_white, 350);
		
		draw_text_shadow(725, 250, $"{months[_t_data.month]} {_t_data.day}, {_t_data.time}", c_white, 350);
		draw_text_shadow(725, 275, $"Entry Fee: ${string_format(_t_data.entry_fee, 0, 2)}", c_white, 350);
		
		draw_text_shadow(725, 325, $"Participants: {array_length(_t_data.entries)}/{_t_data.entrants_max}", c_white, 350);
		
		draw_set_font(fnt_lrg);
		
		var _button_hover = point_in_rectangle(mouse_x, mouse_y, 725, 565, 800, 585);
		var _button_col = c_white;
		
		if _button_hover
		{
			_button_col = c_blue;
		}
		
		draw_text_shadow(725, 575, "Enter", _button_col, 100);
		
		if mouse_check_button_pressed(mb_left)
		{
			if _button_hover
			{
				if _t_data.join_code != -1
				{
					//Create join code window
				}
			}
		}
		
		if _t_data.join_code != -1
		{
			draw_sprite(spr_icon_locked, 0, 800, 575);
		}
	}
	else if _hover
	{
		draw_set_color(c_black);
		draw_rectangle(35, _draw_y - 10, 600, _draw_y + 12, true);
		
		if mouse_check_button_pressed(mb_left)
		{
			selected_tournament = i;
		}
	}
	draw_set_font(fnt_med);
	draw_text_shadow(50, _draw_y, _t_data.name, c_white, 400);
	
	if _t_data.entrants_max > 0
	{
		draw_text_shadow(500, _draw_y, $"{array_length(_t_data.entries)}/{_t_data.entrants_max}", c_white, 100);
	}
	else
	{
		draw_text_shadow(500, _draw_y, array_length(_t_data.entries), c_white, 100);
	}
}