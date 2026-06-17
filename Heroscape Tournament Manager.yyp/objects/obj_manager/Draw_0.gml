/// @description Insert description here
// You can write your code in this editor
draw_set_color(c_white);
draw_set_halign(fa_center);
draw_set_valign(fa_middle);

var cam_y = camera_get_view_y(view_camera[0]);

draw_set_font(fnt_title);
draw_text(room_width/2, cam_y + 50, global.tournament_name);