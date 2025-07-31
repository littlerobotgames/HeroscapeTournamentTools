var _w_half = (width / 2) * size;
var _h_half = (height / 2) * size;

var _color = general_get_color(card_general);

draw_sprite_stretched_ext(sprite_index, 0, x - _w_half, y - _h_half, width * size, height * size, _color, 1);
draw_sprite_stretched_ext(spr_unit_card_name, 0, x - _w_half, y - _h_half, width * size, height * size, c_black, 1);

draw_set_font(fnt_small);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);

draw_set_color(c_white);
draw_text_ext(x, y + (25 * size), card_name, 10, 90);