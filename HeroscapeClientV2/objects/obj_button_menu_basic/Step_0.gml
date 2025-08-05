var _hover = point_in_rectangle(mouse_x, mouse_y, bbox_left, bbox_top, bbox_right, bbox_bottom)

if _hover
{
	if size < size_max
	{
		size = lerp(size, size_max, 0.2);
	}
			
	if mouse_check_button_pressed(mb_left)
	{
		room_goto(my_room);
	}
}
else
{
	if size > 1
	{
		size = lerp(size, 1, 0.2);
	}
}