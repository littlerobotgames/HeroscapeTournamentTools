draw_set_color(c_white);

draw_set_halign(fa_center);
draw_set_valign(fa_middle);

draw_set_font(fnt_big);

draw_text(room_width / 2, 50, "Doubles 2026");

if round_current > 0
{
	draw_set_font(fnt_medium);
	draw_text(room_width / 2, 120, $"Round {round_current}");
}

if hold_current > 0
{
	var _size_half = (hold_current * 3) / 2;
	draw_set_color(c_teal);
	draw_rectangle((room_width / 2) - _size_half, room_height - 50, (room_width / 2) + _size_half, room_height - 40, false);
}