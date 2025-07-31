draw_set_halign(fa_center);
draw_set_valign(fa_middle);
draw_set_font(fnt_title);

var _color = c_white;

if point_in_rectangle(mouse_x, mouse_y, x - 50, y - 40, x + 50, y + 40)
{
	_color = c_blue;
	
	if mouse_check_button_pressed(mb_left)
	{
		room_goto(rm_menu);
	}
}

draw_text_shadow(x, y, text, _color, 200);