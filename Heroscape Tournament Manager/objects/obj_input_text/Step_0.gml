if mouse_check_button_pressed(mb_left)
	{
	if point_in_rectangle(mouse_x, mouse_y, x, y, x+box_width, y+box_height)
		{
		if !active
			{
			active = true;
			keyboard_string = text;
			}
		}
	else
		{
		active = false;
		}
	}

if active
	{
	text = keyboard_string;
	}