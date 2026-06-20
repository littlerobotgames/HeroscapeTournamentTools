draw_self();

draw_set_font(fnt_medium);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);

draw_set_color(c_black);
draw_text(x + 1, y + 1, map_name);
draw_set_color(c_white);
draw_text(x, y, map_name);

if team_one != -1
{
	var _team = global.players[|team_one];
	
	draw_set_color(c_gray);
	draw_rectangle(x - 150, y - 200, x + 150, y - 125, false);
	
	draw_set_color(c_white);
	draw_set_font(fnt_medium);
	draw_set_halign(fa_left);
	draw_text(x - 130, y - 180, _team.teamname);
	
	draw_set_font(fnt_small);
	draw_text(x - 130, y - 150, _team.players);
}

if team_two != -1
{
	var _team = global.players[|team_two];
	
	draw_set_color(c_gray);
	draw_rectangle(x - 150, y + 125, x + 150, y + 200, false);
	
	draw_set_color(c_white);
	draw_set_font(fnt_medium);
	draw_set_halign(fa_right);
	draw_text(x + 130, y + 150, _team.teamname);
	
	draw_set_font(fnt_small);
	draw_text(x + 130, y + 180, _team.players);
}