/// @description Insert description here
// You can write your code in this editor
if global.use_mode != MODE_PLAY
	{
	exit;
	}
	
draw_set_alpha(1);

if battlefield != -1
	{
	var map_image = global.maps[battlefield].image_sprite;
	var map_name = global.maps[battlefield].name;
	
	
	//Draw Background
	if map_image != -1
		{
		draw_sprite_stretched(map_image, 0, x - ((size/2)*scale), y - ((size/2)*scale), size*scale, size*scale);
		}
	
	//Draw Map Name
	draw_set_font(fnt_playmatch_map);
	draw_set_halign(fa_center);
	draw_set_valign(fa_middle);
	
	draw_set_color(c_black);
	draw_text(x+4, y+4, map_name);
	
	draw_set_color(c_white);
	draw_text(x, y, map_name);
	}

if p_ids[0] != -1
	{
	var player_data = global.playerlist[p_ids[0]];
	
	var start_x = x-((size/2)*scale);
	var start_y = y-((size/2)*scale);
	
	if point_in_rectangle(mouse_x, mouse_y, start_x, start_y, start_x+size, start_y+(size/6))
		{
		draw_set_color(c_blue);
		draw_rectangle(start_x-4, start_y-4, start_x+size+4, start_y+(size/6)+4, false);
		
		if mouse_check_button_pressed(mb_left)
			{
			if !match_obj.finished
				{
				match_obj.conclude_match(0);
				
				with(obj_match)
					{
					update_players();
					}
				
				instance_destroy();
				}
			}
		}
	
	if match_obj.winner = -1
		{
		draw_set_color(COLOR_BACKGROUND);
		}
	else if match_obj.winner = p_ids[0]
		{
		draw_set_color(c_green);
		}
	else
		{
		draw_set_color(c_red);
		}
	
	draw_rectangle(start_x, start_y, start_x+size, start_y+(size/6), false);
	
	draw_sprite_stretched(player_data.icon_sprite, 0, start_x, start_y+(size/8), size/4, size/4);
	
	draw_set_color(c_black);
	draw_set_font(fnt_playmatch_map);
	draw_set_halign(fa_left);
	draw_set_valign(fa_middle);
	
	draw_text(start_x + (size/30), start_y+(size/16), player_data.name);
	
	draw_set_font(fnt_name);
	draw_text(start_x + (size/4) + (size/30), start_y+(size/6)-(size/30), player_data.army_name);
	}

if p_ids[1] != -1
	{
	var player_data = global.playerlist[p_ids[1]];
	
	var start_x = x+((size/2)*scale);
	var start_y = y+((size/2)*scale);

	if point_in_rectangle(mouse_x, mouse_y, start_x-size, start_y-(size/6), start_x, start_y )
		{
		draw_set_color(c_blue);
		draw_rectangle(start_x+4, start_y+4, start_x-size-4, start_y-(size/6)-4, false);
		
		if mouse_check_button_pressed(mb_left)
			{
			if !match_obj.finished
				{
				match_obj.conclude_match(1);
				
				with(obj_match)
					{
					update_players();
					}
				
				instance_destroy();
				}
			}
		}
	if match_obj.winner = -1
		{
		draw_set_color(COLOR_BACKGROUND);
		}
	else if match_obj.winner = p_ids[1]
		{
		draw_set_color(c_green);
		}
	else
		{
		draw_set_color(c_red);
		}

	draw_rectangle(start_x, start_y, start_x-size, start_y-(size/6), false);
	
	draw_sprite_stretched(player_data.icon_sprite, 0, start_x-(size/4), start_y-(size/8)-(size/4), size/4, size/4);
	
	draw_set_color(c_black);
	draw_set_font(fnt_playmatch_map);
	draw_set_halign(fa_right);
	draw_set_valign(fa_middle);
	
	draw_text(start_x - (size/30), start_y-(size/16), player_data.name);
	
	draw_set_font(fnt_name);
	draw_text(start_x - (size/4) - (size/30), start_y-(size/6)+(size/30), player_data.army_name);
	}