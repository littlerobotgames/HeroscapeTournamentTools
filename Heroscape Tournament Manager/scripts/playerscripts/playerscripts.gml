// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function Player(_name, _armyname, _icon, _level, _autoby) constructor
{
	name = _name;
	army_name = _armyname;
	icon = _icon;
	level = _level;
	autoby = _autoby;
	icon_sprite = -1;
}
function draw_player(_p_id, _x, _y)
{
	var width = 250;
	var height = 40;
	var icon_size = 32;
	
	var p_icon_sprite = global.playerlist[_p_id].icon_sprite;
	var p_name = global.playerlist[_p_id].name;
	var p_army = global.playerlist[_p_id].army_name;
		
		
	draw_set_color(COLOR_BACKGROUND);
	draw_rectangle(_x, _y, _x+width, _y+height, false);
	draw_set_color(c_dkgray);
	draw_rectangle(_x, _y, _x+width, _y+height, true);
		
	draw_set_halign(fa_left);
	draw_set_valign(fa_center);
		
	draw_rectangle(_x+2, _y+2, _x + icon_size + 5, _y+icon_size+5, false);
		
	if p_icon_sprite!=-1
		{
		var shift = (height - icon_size)/2;
		draw_sprite_stretched(p_icon_sprite, 0, _x+shift, _y+shift, icon_size, icon_size);
		}
		
	draw_set_color(c_black);
	draw_set_font(fnt_name);
	draw_text(_x+height+6, _y+14, p_name);
		
	draw_set_font(fnt_army);
	draw_text(_x+height+6, _y+31, p_army);
}
function players_get_icons()
{
	for (var p = 0; p < array_length(global.playerlist); p++)
		{
		if global.playerlist[p].icon != -1
			{
			global.playerlist[p].icon_sprite = sprite_add($"tourneys/{global.tourney_file}/player_icons/{global.playerlist[p].icon}", 1, false, false, 0, 0);
			}
		else
			{
			global.playerlist[p].icon_sprite = spr_icon_basic;
			}
		}
}