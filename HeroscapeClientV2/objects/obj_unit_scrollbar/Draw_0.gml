if !surface_exists(my_surface)
{
	my_surface = surface_create(scrollbar_width, scrollbar_height);
}


surface_set_target(my_surface);

draw_sprite_stretched_ext(spr_unit_card, 0, 0, 0, scrollbar_width, scrollbar_height, c_dkgray, 1);

for (var i = 0; i < ds_list_size(unit_cards); i++)
{
	unit_cards[|i].Draw(scroll_amount_current, x, y);
}

surface_reset_target();

draw_surface(my_surface, x, y);

var _scroll_perc = scroll_amount / scroll_max;

draw_set_color(c_dkgray);
draw_rectangle(x + scrollbar_width + 10, y, x + scrollbar_width + 20, y + scrollbar_height, false);

draw_set_color(c_white);
draw_circle(x + scrollbar_width + 15, y + (_scroll_perc * (scrollbar_height - 20)) + 10, 5, false);

if mouse_check_button_pressed(mb_left)
{
	if mouse_x > x + scrollbar_width + 10 and mouse_y > y + 10
	{
		click_scrolling = true;
	}
}
if mouse_check_button_released(mb_left)
{
	click_scrolling = false;
}

if global.selected_card != -1
{
	var _card_data = unit_find(global.selected_card);
	
	draw_set_font(fnt_lrg);
	draw_set_halign(fa_center);
	draw_set_valign(fa_middle);
	
	draw_text_shadow(260, 100, _card_data.name, c_white, 300);
	
	draw_set_halign(fa_left);
	draw_set_font(fnt_med);
	
	draw_text_shadow(40, 180, _card_data.general, c_white, 200);
	draw_text_shadow(40, 200, _card_data.race, c_white, 200);
	draw_text_shadow(40, 220, $"{_card_data.rarity} {_card_data.type}", c_white, 200);
	draw_text_shadow(40, 240, _card_data.unit_class, c_white, 200);
	draw_text_shadow(40, 260, _card_data.personality, c_white, 200);
	
	draw_text_shadow(40, 300, $"Life: {_card_data.life}", c_white, 200);
	draw_text_shadow(40, 320, $"Move: {_card_data.move}", c_white, 200);
	draw_text_shadow(40, 340, $"Range: {_card_data.range}", c_white, 200);
	draw_text_shadow(40, 360, $"Attack: {_card_data.attack}", c_white, 200);
	draw_text_shadow(40, 380, $"Defense: {_card_data.defense}", c_white, 200);
	draw_text_shadow(40, 400, $"Points: {_card_data.points}", c_white, 200);
	
	draw_text_shadow(40, 440, $"Figures: {_card_data.figures}", c_white, 200);
	draw_text_shadow(40, 460, $"Hexes per Unit: {_card_data.hex_per}", c_white, 200);
	draw_text_shadow(40, 480, $"Total Hexes: {_card_data.figures * _card_data.hex_per}", c_white, 200);
	
	//Abilities
	var _draw_y = 170;
	
	for (var i = 0; i < array_length(_card_data.abilities); i++)
	{
		draw_set_font(fnt_med);
		draw_set_valign(fa_top);
		
		draw_text_shadow(180, _draw_y, _card_data.abilities[i].name, c_white, 250);
		_draw_y += 25;
		
		draw_set_font(fnt_small);
		draw_text_shadow(180, _draw_y, _card_data.abilities[i].description, c_white, 250);
		
		var _f_size = font_get_size(draw_get_font());
		var _height = string_height_ext(_card_data.abilities[i].description, _f_size * 1.7, 250);
		
		_draw_y += _height + 10;
	}
}