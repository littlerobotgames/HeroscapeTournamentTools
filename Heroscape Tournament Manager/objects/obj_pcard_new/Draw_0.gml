/// @description Insert description here
// You can write your code in this editor
draw_set_color(COLOR_BACKGROUND);
draw_roundrect(x-(125*size), y-(175*size), x+(125*size), y+(175*size), true);

draw_sprite_ext(spr_gui_new, 0, x, y, size, size, 0, c_white, 1);

draw_set_font(fnt_pcard_name_1);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);

draw_text(x,y+(80*size), "New Player");