if image != -1
{
	draw_sprite_ext(image, 0, x, y, size, size, 0, c_white, 1);
}

draw_set_valign(fa_middle);
draw_set_halign(fa_center);
draw_set_font(fnt_title);

draw_text_shadow(x + (500 * (size - 1)), y, text, c_white, 400);