/// @description Insert description here
// You can write your code in this editor
draw_set_color(COLOR_BACKGROUND);
draw_roundrect(x-(125*size), y-(175*size), x+(125*size), y+(175*size), false);

var my_player = global.playerlist[p_id];

if my_image != -1
	{
	draw_sprite_stretched(my_image, 0, x-(100*size), y-(150*size), 200*size, 200*size);
	}
else
	{
	draw_sprite_stretched(spr_icon_basic, 0, x-(100*size), y-(150*size), 200*size, 200*size);
	}

draw_set_color(c_black);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);
draw_set_font(fnt_pcard_name_3);

draw_text_ext(x, y+(80*size), my_player.name, 28, 225);

draw_set_font(fnt_name);
draw_set_valign(fa_top);

draw_text_ext(x, y+(110*size), my_player.army_name, 22, 225);

if my_player.autoby
	{
	draw_sprite(spr_gui_autoby, 0, x, y+(155*size));
	}