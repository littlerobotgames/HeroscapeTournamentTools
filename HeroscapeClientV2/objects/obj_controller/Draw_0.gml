switch (room)
{
	case rm_connect:
		break;
	case rm_login:
		draw_set_color(c_white);
		draw_set_halign(fa_center);
		draw_set_valign(fa_middle);
		draw_set_font(fnt_title);
		
		draw_text(room_width / 2, 150, "Heroscape Tournaments");
		
		break;
}