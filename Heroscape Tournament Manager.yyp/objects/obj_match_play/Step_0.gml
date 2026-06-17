/// @description Insert description here
// You can write your code in this editor
if point_in_rectangle(mouse_x, mouse_y, x-(size/2), y-(size/2), x+(size/2), y+(size/2))
	{
	if scale < 1.1
		{
		scale += 0.01;
		}
	if mouse_check_button_pressed(mb_right)
		{
		if match_obj.finished
			{
			match_obj.undo_match();
			}
		}
	}
else
	{
	if scale > 1
		{
		scale -= 0.01;
		}
	}