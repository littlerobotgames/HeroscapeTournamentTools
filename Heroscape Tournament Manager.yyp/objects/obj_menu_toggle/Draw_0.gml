/// @description Insert description here
// You can write your code in this editor
if point_in_rectangle(mouse_x, mouse_y, x, y, x + 50, y + 50)
	{
	draw_set_color(color_back_highlight);
	}
else
	{
	draw_set_color(color_back);
	}

draw_rectangle(x, y, x+50, y+50, false);

draw_set_color(c_blue);
if value
	{
	draw_line(x, y, x + 50, y + 50);
	draw_line(x + 50, y, x, y + 50);
	}

draw_set_color(color_text);
draw_set_valign(fa_middle);
draw_set_halign(fa_left);
draw_set_font(fnt_pcard_name_1);

draw_text(x+60, y+25, text);