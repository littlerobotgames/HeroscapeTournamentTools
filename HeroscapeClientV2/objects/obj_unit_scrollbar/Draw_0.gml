if !surface_exists(my_surface)
{
	my_surface = surface_create(scrollbar_width, scrollbar_height);
}


surface_set_target(my_surface);

draw_sprite_stretched_ext(spr_unit_card, 0, 0, 0, scrollbar_width, scrollbar_height, c_dkgray, 1);

for (var i = 0; i < ds_list_size(unit_cards); i++)
{
	unit_cards[|i].Draw();
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
	
	if mode = MODE_BROWSE
	{
		draw_set_font(fnt_lrg);
		draw_set_halign(fa_center);
		draw_set_valign(fa_middle);
	
		draw_text_shadow(260, 100, _card_data.name, c_white, 300);
	
		draw_set_halign(fa_left);
		draw_set_font(fnt_med);
	
		draw_text_shadow(40, 160, _card_data.general, c_white, 200);
		draw_text_shadow(40, 185, _card_data.race, c_white, 200);
		draw_text_shadow(40, 210, $"{_card_data.rarity} {_card_data.type}", c_white, 200);
		draw_text_shadow(40, 235, _card_data.unit_class, c_white, 200);
		draw_text_shadow(40, 260, _card_data.personality, c_white, 200);
	
		draw_text_shadow(40, 300, $"Life: {_card_data.life}", c_white, 200);
		draw_text_shadow(40, 325, $"Move: {_card_data.move}", c_white, 200);
		draw_text_shadow(40, 350, $"Range: {_card_data.range}", c_white, 200);
		draw_text_shadow(40, 375, $"Attack: {_card_data.attack}", c_white, 200);
		draw_text_shadow(40, 400, $"Defense: {_card_data.defense}", c_white, 200);
		draw_text_shadow(40, 425, $"Points: {_card_data.points}", c_white, 200);
	
		draw_text_shadow(40, 465, $"Figures: {_card_data.figures}", c_white, 200);
		draw_text_shadow(40, 490, $"Hexes per Unit: {_card_data.hex_per}", c_white, 200);
		draw_text_shadow(40, 515, $"Total Hexes: {_card_data.figures * _card_data.hex_per}", c_white, 200);
	
		//Abilities
		var _draw_y = 150;
	
		for (var i = 0; i < array_length(_card_data.abilities); i++)
		{
			draw_set_font(fnt_med);
			draw_set_valign(fa_top);
		
			draw_text_shadow(220, _draw_y, _card_data.abilities[i].name, c_white, 300);
			_draw_y += 30;
		
			draw_set_font(fnt_small);
			draw_text_shadow(220, _draw_y, _card_data.abilities[i].description, c_white, 300);
		
			var _f_size = font_get_size(draw_get_font());
			var _height = string_height_ext(_card_data.abilities[i].description, _f_size * 1.7, 300);
		
			_draw_y += _height + 15;
		}
	}
}
if mode = MODE_BUILD
{
	if global.build_army != -1
	{
		draw_set_font(fnt_med);
		draw_set_halign(fa_left);
		
		draw_text_shadow(40, 70, global.build_army.army_name, c_white, 200);
	}
}