var _w_half = width / 2;
var _h_half = height / 2;

if mouse_check_button_pressed(mb_left)
{
	if point_in_rectangle(mouse_x, mouse_y, x - _w_half, y - _h_half, x + _w_half, y + _h_half)
	{
		if !typing
		{
			typing = true;
			keyboard_string = "";
		}
	}
	else
	{
		typing = false;
	}
}

if typing
{
	text = keyboard_string;
}