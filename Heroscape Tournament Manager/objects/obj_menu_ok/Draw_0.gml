/// @description Insert description here
// You can write your code in this editor
if point_in_rectangle(mouse_x, mouse_y, x, y, x + box_width, y + box_height)
	{
	draw_set_color(color_highlight);
	}
else
	{
	draw_set_color(color_back);
	}

draw_rectangle(x, y, x + box_width, y + box_height, false);

draw_set_font(fnt_pcard_name_1);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);
draw_set_color(color_text);

draw_text(x + (box_width/2), y + (box_height/2), "Ok");