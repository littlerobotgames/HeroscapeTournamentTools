/// @description Insert description here
// You can write your code in this editor
if global.use_mode != MODE_PLAY
	{
	exit;
	}

draw_set_halign(fa_center);
draw_set_valign(fa_middle);
draw_set_font(fnt_title);

draw_set_color(c_white);

var text_width = string_width(text_next);
var text_height = string_height(text_next);
	
if matches_left = 0
	{
	if point_in_rectangle(mouse_x, mouse_y, x - (text_width/2), y - (text_height/2), x + (text_width/2), y + (text_height/2))
		{
		draw_set_color(c_blue);
		
		if mouse_check_button_pressed(mb_left)
			{
			with (obj_match)
				{
				if match_ahead != noone
					{
					match_ahead.update_players();
					}
				}
			play_matches_create();
			
			if instance_number(obj_match_play) = 1
				{
				instance_destroy();
				}
			}
		}
	draw_text(x,y, text_next);
	}
else
	{
	draw_text(x,y, $"Matches left: {matches_left}");
	}