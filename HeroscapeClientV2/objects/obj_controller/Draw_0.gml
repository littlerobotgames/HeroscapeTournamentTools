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
}