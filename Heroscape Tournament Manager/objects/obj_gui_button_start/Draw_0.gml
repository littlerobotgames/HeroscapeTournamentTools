/// @description Insert description here
// You can write your code in this editor
if global.use_mode != MODE_BRACKET
	{
	exit;
	}

draw_self();

draw_set_valign(fa_middle);
draw_set_halign(fa_center);
draw_set_color(c_white);
draw_set_font(fnt_playmatch_map);

draw_text(x, y, text);