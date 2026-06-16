/// @description Insert description here
// You can write your code in this editor
if global.use_mode != MODE_BRACKET
	{
	exit;
	}


draw_set_alpha(1);
draw_set_color(c_white);

if match_ahead != noone
	{
	draw_line(x,y,match_ahead.x, y);
	draw_line(match_ahead.x, y, match_ahead.x, match_ahead.y);
	}

draw_self();


if battlefield != -1 and branches[|0].p_id != -1 and branches[|1].p_id != -1
	{
	if finished
		{
		draw_set_alpha(0.5);
		}
	draw_map(battlefield, x, y);
	}

draw_set_alpha(1);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);

if finished
	{
	draw_set_alpha(0.5);
	}

var p_id = branches[|0].p_id;

if p_id != -1
	{
	draw_player(p_id, x-125, y-78);
	}
else
	{
	draw_set_color(c_dkgray);
	draw_rectangle(x-125, y-78, x+125, y-38, false);
	}

p_id = branches[|1].p_id;

if p_id != -1
	{
	draw_player(p_id, x-125, y+32);
	}
else
	{
	draw_set_color(c_dkgray);
	draw_rectangle(x-125, y+32, x+125, y+72, false);
	}

if position_meeting(mouse_x, mouse_y, self)
	{
	draw_sprite(spr_match_highlight, 0, x, y);
	}

draw_set_alpha(1);