switch (room)
{
	case rm_connect:
		draw_set_font(fnt_med);
		draw_set_valign(fa_middle);
		draw_set_halign(fa_center);
		
		draw_text_shadow(room_width / 2, room_height - 50, error, c_red, 1000);
		
		draw_set_halign(fa_right);
		draw_text_shadow(room_width - 75, room_height - 50, status, c_white, 1000);
		
		if error = ""
		{
			draw_sprite_ext(spr_loading, 0, room_width - 50, room_height - 50, 1, 1, -anim_frame, c_maroon, 1);
		}
		break;
	case rm_login:
		draw_set_color(c_white);
		draw_set_halign(fa_center);
		draw_set_valign(fa_middle);
		draw_set_font(fnt_title);
		
		draw_text_shadow(room_width / 2, 150, "Heroscape Tournaments", c_white, 1000);
		break;
	case rm_menu:
		if global.player_data != -1
		{
			draw_set_halign(fa_center);
			draw_set_valign(fa_middle);
			
			draw_set_font(fnt_lrg);
			draw_text_shadow(750, 75, $"{global.player_data.firstname} {global.player_data.lastname}", c_white, 400);
		}
		break;
	
	case rm_build_menu:
		var _draw_x = 275;
		var _draw_y = 125;		
		
		for (var i = 0; i < array_length(armies_data); i++)
		{
			armies_data[i].Draw(_draw_x, _draw_y);
			
			_draw_y += 125;
		}
		break;
}