if !click_scrolling
{
	var _in_space = point_in_rectangle(mouse_x, mouse_y, x, y, x + scrollbar_width, y + scrollbar_height);

	if _in_space
	{
		if mouse_wheel_down()
		{
			if scroll_amount < scroll_max
			{
				scroll_amount += scroll_speed;
			}
		}
		if mouse_wheel_up()
		{
			if scroll_amount > 0
			{
				scroll_amount -= scroll_speed;
			}
		}
	}
}
else
{
	var _scroll_perc = (mouse_y - y) / (scrollbar_height - 20);
	
	scroll_amount = _scroll_perc * scroll_max;
}
scroll_amount = clamp(scroll_amount, 0, scroll_max);

scroll_amount_current = lerp(scroll_amount_current, scroll_amount, 0.2);