/// @description Insert description here
// You can write your code in this editor
draw_set_color(COLOR_BACKGROUND);
draw_roundrect(x-(125*size), y-(175*size), x+(125*size), y+(175*size), false);

var my_map = global.maps[m_id];

if my_image != -1
	{
	draw_sprite_stretched(my_image, 0, x-(100*size), y-(150*size), 200*size, 200*size);
	}

draw_set_font(fnt_pcard_name_2);
draw_set_color(c_black);
draw_set_halign(fa_center);
draw_set_valign(fa_top);

draw_text_ext(x, y+(60*size), my_map.name, 30, 225);

if my_map.final
	{
	draw_sprite(spr_gui_map_final, 0, x, y+(150*size));
	}