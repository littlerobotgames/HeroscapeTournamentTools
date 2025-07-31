var _w_half = width / 2;
var _h_half = height / 2;

if point_in_rectangle(mouse_x, mouse_y, x - _w_half, y - _h_half, x + _w_half, y + _h_half)
{
	if size < size_max
	{
		size = lerp(size, size_max, 0.2);
	}
}
else
{
	if size > 1
	{
		size = lerp(size, 1, 0.2);
	}
}

x = 612 + (grid_x * 115);
y = 120 + (grid_y * 90);